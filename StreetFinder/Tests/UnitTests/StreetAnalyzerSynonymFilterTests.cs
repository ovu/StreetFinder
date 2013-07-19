using FluentAssertions;
using Lucene.Net.Util;
using NUnit.Framework;
using StreetFinder;
using System.Linq;

namespace Tests.UnitTests
{
    [TestFixture]
    public class StreetAnalyzerSynonymFilterTests
    {
        [Test]
        public void When_the_streetName_ends_with_the_word_str_the_synonyms_strasse_and_straße_should_be_added()
        {
            // Act
            var tokens = AnalyzerTestHelper.TokensFromAnalysis(new StreetAnalyzer(Version.LUCENE_30), "Einestr.");
            var listTokens = tokens.ToList();

            // Assert
            listTokens.Should().Contain("strasse");
            listTokens.Should().Contain("straße");
        }

        [Test]
        public void When_the_streetName_does_not_end_with_the_word_str_the_synonyms_strasse_and_straße_should_not_be_added()
        {
            // Act
            var tokens = AnalyzerTestHelper.TokensFromAnalysis(new StreetAnalyzer(Version.LUCENE_30), "Marienplatz");
            var listTokens = tokens.ToList();

            // Assert
            listTokens.Should().NotContain("strasse");
            listTokens.Should().NotContain("straße");
        }

    }
}