using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Directory = System.IO.Directory;
using Version = Lucene.Net.Util.Version;

namespace StreetFinder
{
    public class StreetRepositoryLucene: IStreetSearchRepository
    {
        private string _streetsIndex = "LuceneIndex";
        private string _luceneEdgeGramIndexDir = "LuceneEdgegramIndex";

        private string StreetsIndexDirectory {
            get
            {
                return Environment.CurrentDirectory + "\\" + _streetsIndex;
            }
        }

        private string StreetsEdgeGramIndexDirectory
        {
            get
            {
                return Environment.CurrentDirectory + "\\" + _luceneEdgeGramIndexDir;
            }
        }

        public void CreateStreetRepository()
        {
            FSDirectory.Open(new DirectoryInfo(StreetsIndexDirectory));
            FSDirectory.Open(new DirectoryInfo(StreetsEdgeGramIndexDirectory));

        }

        public bool ExistStreetRepository()
        {
            return Directory.Exists(StreetsIndexDirectory) && Directory.Exists(StreetsEdgeGramIndexDirectory);
        }

        public void DeleteStreetRepository()
        {
            Directory.Delete(StreetsIndexDirectory, true);
            Directory.Delete(StreetsEdgeGramIndexDirectory, true);
        }

        public IEnumerable<Street> SearchForStreets(string zipCode, string streetName)
        {
            var directory = FSDirectory.Open(new DirectoryInfo(StreetsIndexDirectory));

            foreach (var street in SearchStreetInIndex(zipCode, streetName, directory)) yield return street;

            var ngramDirectory = FSDirectory.Open(new DirectoryInfo(StreetsEdgeGramIndexDirectory));

            foreach (var street in SearchStreetInIndex(zipCode, streetName, ngramDirectory)) yield return street;

        }

        private string GetQueryForStreetName(string streetName, string queryOperator)
        {
            var streetNameTrimmed = streetName.Trim('-', ' ');
            var streetNameWithoutMinus = streetNameTrimmed.Replace('-', ' ');
            var streetNameWithOneSpace = Regex.Replace(streetNameWithoutMinus, @"\s+", " ");

            var streetNameTokens = streetNameWithOneSpace.Replace('-', ' ').Split(' ');

            var result = "";
            foreach (var streetNameToken in streetNameTokens)
            {
                result += string.Format("+Name:{0}{1} ", streetNameToken, queryOperator);
            }

            return result;
        }

        private IEnumerable<Street> SearchStreetInIndex(string zipCode, string streetName, FSDirectory directory)
        {
            IndexReader indexReader = IndexReader.Open(directory, true);

            Searcher indexSearch = new IndexSearcher(indexReader);

            Analyzer analyzer = new StandardAnalyzer(Version.LUCENE_30);

            var queryParser = new QueryParser(Version.LUCENE_30, "Name", analyzer);

            var foundIds = new List<string>();

            // Search with Query parser
            var streetNameQuery = GetQueryForStreetName(streetName, "*");
            var query = queryParser.Parse(string.Format("{0} AND Pobox:{1}", streetNameQuery, zipCode));

            var resultDocs = indexSearch.Search(query, 5);
            var hits = resultDocs.ScoreDocs;

            foreach (var hit in hits)
            {
                var documentFromSearcher = indexSearch.Doc(hit.Doc);
                if (!foundIds.Contains(documentFromSearcher.Get("Id")))
                {
                    yield return
                        new Street
                            {
                                Name = documentFromSearcher.Get("Name"),
                                Pobox = documentFromSearcher.Get("Pobox")
                            };
                }
            }

            indexSearch.Dispose();

            directory.Dispose();
        }

        public void InsertStreet(Street street)
        {
            var streetDocument = new Document();
            streetDocument.Add(new Field("Id", Guid.NewGuid().ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
            streetDocument.Add(new Field("Name", street.Name, Field.Store.YES, Field.Index.ANALYZED));
            streetDocument.Add(new Field("Pobox", street.Pobox.ToString(CultureInfo.InvariantCulture), Field.Store.YES, Field.Index.NOT_ANALYZED));

            var directory = FSDirectory.Open(new DirectoryInfo(StreetsIndexDirectory));
            Analyzer analyzer = new StandardAnalyzer(Version.LUCENE_30);

            WriteInIndex(streetDocument, directory, analyzer);

            // Write edgegram
            var edgeDirectory = FSDirectory.Open(new DirectoryInfo(StreetsEdgeGramIndexDirectory));
            var streetEdgeGramAnalyzer = new StreetAnalyzer();
            WriteInIndex(streetDocument, edgeDirectory, streetEdgeGramAnalyzer);
        }

        private void WriteInIndex(Document streetDocument, FSDirectory directory, Analyzer analyzer)
        {
            var indexWriter = new IndexWriter(directory, analyzer, true, IndexWriter.MaxFieldLength.LIMITED);

            indexWriter.AddDocument(streetDocument);

            indexWriter.Optimize();

            indexWriter.Commit();

            indexWriter.Dispose(true);
        }

        public void InsertStreets(IList<Street> streets)
        {
            throw new NotImplementedException();
        }
    }
}
