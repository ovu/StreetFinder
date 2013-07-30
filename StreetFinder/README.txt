Important Classes
=================

+ AproximativeSearchImpl.AddressService
  It is a thread safe implementation of the IAddressService. It uses the class StreetRepositoryLucene for inserting and searching for documents
in the lucene index.

+ StreetFinder.StreetRepositoryLucene
  It is a lucene wrapper that allows for indexing street documents and offers a method for searching for streets aproximatively.
It uses the StreetAnalyzer for analyzing the street before they are indexed.

+ StreetFinder.StreetAnalyzer
  It is the implementation of a Lucene analyzer that it used for analyzing street documents. It generates the tokens for the reverted index
that are later indexed. The generated tokens are Edge-Ngram, abbreviations tokens and combined tokens.

+ StreetFinder.CombineFilter.CombineTokenFilter
  It is a Lucene filter that combines tokens. Combined tokens are necessary when searching for street names without spaces between them.

+ StreetFinder.AbbreviationsFilter.AbbreviationTokenFilter
  It is a Lucene filter that uses an abbreviation engine to add abbreviations or introduce the text that was abbreviated to the list of tokens that will be indexed.
  

   