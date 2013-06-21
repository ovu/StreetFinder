using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using PlainElastic.Net;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Serialization;

namespace StreetFinder
{
    public class StreetSearchRepository: IStreetSearchRepository
    {
        private ElasticConnection _connection;

        public StreetSearchRepository()
        {
            _connection = new ElasticConnection("localhost", 9200);
        }

        public void CreateStreetRepository()
        {
            string jsonMapping = GetPrefixIndexMapping();

            _connection.Put("streets", jsonMapping);
        }

        public bool ExistStreetRepository()
        {
            try
            {
                _connection.Head("streets");
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public void DeleteStreetRepository()
        {
            _connection.Delete("streets");
        }

        public IEnumerable<Street> SearchForStreets(int zipCode, string streetName)
        {
            string query = new QueryBuilder<Street>()
                .Query(q => q
                    .Bool(b => b
                       .Must(m => m
                           .Prefix(p => p
                                .Field(street => street.Name).Prefix(streetName)
                            
                           ).Term(t => t.Field(s=>s.Pobox).Value(zipCode.ToString()))
                       )
                    )
                )
                //.Filter(f => f
                //    .Term(t => t 
                //        .Field(street => street.Name).Value("true")
                //    )
                //)
                .BuildBeautified();

            string result = _connection.Post(Commands.Search("streets"), query);

            var serializer = new JsonNetSerializer();

            var resultList = serializer.ToSearchResult<Street>(result).Documents.ToList();

            return resultList;
        }

        public void InsertStreet(Street street)
        {
            var serializer = new JsonNetSerializer();
            var streetJson = serializer.ToJson(street);
            var guid = Guid.NewGuid();
            _connection.Put(new IndexCommand("streets", "street", "10"), streetJson);
        }

        public void InsertStreets(IList<Street> streets)
        {
            throw new NotImplementedException();
        }

        private string GetPrefixIndexMapping()
        {
            return ExtractFileFromAssembly("prefixindex.json");
        }

        private string ExtractFileFromAssembly(string fileName)
        {
            string result = string.Empty;

            using (Stream stream = Assembly.GetExecutingAssembly()
                                           .GetManifestResourceStream("StreetFinder." + fileName))
            {

                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }
    }
}
