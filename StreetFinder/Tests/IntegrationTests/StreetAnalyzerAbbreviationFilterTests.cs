using System.Linq;
using FluentAssertions;
using Lucene.Net.Util;
using NUnit.Framework;
using StreetFinder;
using Tests.UnitTests;

namespace Tests.IntegrationTests
{
    [TestFixture]
    public class StreetAnalyzerAbbreviationFilterTests
    {
        [Test]
        public void When_the_streetName_ends_with_the_word_str_the_synonyms_strasse_and_straße_should_be_added()
        {
            // Act
            var tokens = AnalyzerTestHelper.TokensFromAnalysis(new StreetAnalyzer(Version.LUCENE_30), "Einestr.");
            var listTokens = tokens.ToList();

            // Assert
            listTokens.Should().Contain("einestr");
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

        [Test]
        public void When_the_streetName_starts_with_st_the_word_sankt_should_be_added_to_the_tokens()
        {
            // Act
            var tokens = AnalyzerTestHelper.TokensFromAnalysis(new StreetAnalyzer(Version.LUCENE_30), "St.-Ulrich-Str.");
            var listTokens = tokens.ToList();

            // Assert
            listTokens.Should().Contain("sankt");
        }

        [Test]
        public void When_the_streetName_starts_with_sankt_the_word_st_should_be_added_to_the_tokens()
        {
            // Act
            var tokens = AnalyzerTestHelper.TokensFromAnalysis(new StreetAnalyzer(Version.LUCENE_30), "Sankt.-Ulrich-Str.");
            var listTokens = tokens.ToList();

            // Assert
            listTokens.Should().Contain("st");
        }

        [Test]
        public void When_the_streetName_starts_with_prof_the_word_professor_should_be_added_to_the_tokens()
        {
            // Act
            var tokens = AnalyzerTestHelper.TokensFromAnalysis(new StreetAnalyzer(Version.LUCENE_30), "Prof.-Eichmann-Str.");
            var listTokens = tokens.ToList();

            // Assert
            listTokens.Should().Contain("professor");
        }

        [Test]
        public void When_the_streetName_starts_with_Dr_the_word_Doktor_should_be_added_to_the_tokens()
        {
            // Act
            var tokens = AnalyzerTestHelper.TokensFromAnalysis(new StreetAnalyzer(Version.LUCENE_30), "Dr.-Schweninger-Str.");
            var listTokens = tokens.ToList();

            // Assert
            listTokens.Should().Contain("doktor");
        }

        [Test]
        public void When_the_streetName_starts_with_Doktor_the_word_Dr_should_be_added_to_the_tokens()
        {
            // Act
            var tokens = AnalyzerTestHelper.TokensFromAnalysis(new StreetAnalyzer(Version.LUCENE_30), "Doktor.-Schweninger-Str.");
            var listTokens = tokens.ToList();

            // Assert
            listTokens.Should().Contain("dr");
        }
    }
}