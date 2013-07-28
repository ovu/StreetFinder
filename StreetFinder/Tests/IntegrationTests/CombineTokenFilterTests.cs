using System.Linq;
using FluentAssertions;
using Lucene.Net.Util;
using NUnit.Framework;
using StreetFinder;
using Tests.UnitTests;

namespace Tests.IntegrationTests
{
    [TestFixture]
    public class CombineTokenFilterTests
    {
        [Test]
        public void The_terms_in_a_streetName_should_be_combined()
        {
            // Act
            var tokens = AnalyzerTestHelper.TokensFromAnalysis(new StreetAnalyzer(Version.LUCENE_30), "Erika Mann");
            var listTokens = tokens.ToList();

            // Assert
            listTokens.Should().Contain("erikamann");
            listTokens.Should().Contain("mann");
        }

        [Test]
        public void The_first_terms_in_a_streetName_should_be_combined()
        {
            // Act
            var tokens = AnalyzerTestHelper.TokensFromAnalysis(new StreetAnalyzer(Version.LUCENE_30), "Am Bietricher Holz");
            var listTokens = tokens.ToList();

            // Assert
            listTokens.Should().Contain("ambietricher");
            listTokens.Should().Contain("bietricherholz");
        }

        [Test]
        public void The_last_terms_in_a_streetName_should_be_combined()
        {
            // Act
            var tokens = AnalyzerTestHelper.TokensFromAnalysis(new StreetAnalyzer(Version.LUCENE_30), "Am Bietricher Holz");
            var listTokens = tokens.ToList();

            // Assert
            listTokens.Should().Contain("bietricherholz");
        }

        [Test]
        public void All_the_terms_should_not_be_combined()
        {
            // Act
            var tokens = AnalyzerTestHelper.TokensFromAnalysis(new StreetAnalyzer(Version.LUCENE_30), "Am Bietricher Holz");
            var listTokens = tokens.ToList();

            // Assert
            listTokens.Should().NotContain("ambietricherholz");
        }

        [Test]
        public void The_terms_in_a_streetName_should_not_be_combined_when_the_name_starts_with_st()
        {
            // Act
            var tokens = AnalyzerTestHelper.TokensFromAnalysis(new StreetAnalyzer(Version.LUCENE_30), "St. Ottilien");
            var listTokens = tokens.ToList();

            // Assert
            listTokens.Should().Contain("st");
            listTokens.Should().Contain("ottilien");
            listTokens.Should().NotContain("stottilien");
        }

        [Test]
        public void The_terms_in_a_streetName_should_not_be_combined_when_the_name_starts_with_st_and_had_other_characters()
        {
            // Act
            var tokens = AnalyzerTestHelper.TokensFromAnalysis(new StreetAnalyzer(Version.LUCENE_30), "St.-Martin-Platz");
            var listTokens = tokens.ToList();

            // Assert
            listTokens.Should().Contain("st");
            listTokens.Should().Contain("martinplatz");
            listTokens.Should().Contain("platz");
        }

        [Test]
        public void The_terms_in_a_streetName_should_not_be_combined_when_the_name_starts_with_dr()
        {
            // Act
            var tokens = AnalyzerTestHelper.TokensFromAnalysis(new StreetAnalyzer(Version.LUCENE_30), "Dr.-Blaich-Str.");
            var listTokens = tokens.ToList();

            // Assert
            listTokens.Should().NotContain("drblaich");
        }

        [Test]
        public void The_terms_in_a_streetName_should_not_be_combined_when_the_name_starts_with_prof()
        {
            // Act
            var tokens = AnalyzerTestHelper.TokensFromAnalysis(new StreetAnalyzer(Version.LUCENE_30), "Prof.-Benjamin-Allee");
            var listTokens = tokens.ToList();

            // Assert
            listTokens.Should().NotContain("profbenjamin");
        }

        [Test]
        public void The_last_terms_in_a_streetName_should_not_combined_when_the_name_starts_with_prof()
        {
            // Act
            var tokens = AnalyzerTestHelper.TokensFromAnalysis(new StreetAnalyzer(Version.LUCENE_30), "Prof.-Benjamin-Allee");
            var listTokens = tokens.ToList();

            // Assert
            listTokens.Should().Contain("benjaminallee");
        }                
    }
}