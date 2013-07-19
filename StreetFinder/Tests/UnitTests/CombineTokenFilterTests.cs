using System.Linq;
using FluentAssertions;
using Lucene.Net.Util;
using NUnit.Framework;
using StreetFinder;

namespace Tests.UnitTests
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
            listTokens.Should().Contain("erika");
            listTokens.Should().Contain("mann");
            listTokens.Should().Contain("erikamann");
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