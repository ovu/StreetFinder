using FluentAssertions;
using NUnit.Framework;
using StreetFinder.AbbreviationsFilter;

namespace Tests.UnitTests
{
    [TestFixture]
    public class AbbreviationTokenExpanderTests
    {
        [Test]
        public void Abbreviation_at_the_beginning_should_be_expanded()
        {
            // Arrange

            var abbreviationTokenExpander = new AbbreviationTokenExpander();

            // Act

            abbreviationTokenExpander.Add("prof");
            abbreviationTokenExpander.Add("abc");

            // Assert
            abbreviationTokenExpander.ElementAt(0).Should().Be("prof");
            abbreviationTokenExpander.ElementAt(1).Should().Be("professor");
            abbreviationTokenExpander.ElementAt(2).Should().Be("abc");
        }

        [Test]
        public void Abbreviation_at_the_end_should_be_expanded()
        {
            // Arrange

            var abbreviationTokenExpander = new AbbreviationTokenExpander();

            // Act

            abbreviationTokenExpander.Add("abc");
            abbreviationTokenExpander.Add("str");

            // Assert
            abbreviationTokenExpander.ElementAt(0).Should().Be("abc");
            abbreviationTokenExpander.ElementAt(1).Should().Be("str");
            abbreviationTokenExpander.ElementAt(2).Should().Be("strasse");
            abbreviationTokenExpander.ElementAt(3).Should().Be("straße");
        }

        [Test]
        public void A_token_ending_with_str_should_be_expanded_to_str()
        {
            // Arrange

            var abbreviationTokenExpander = new AbbreviationTokenExpander();

            // Act

            abbreviationTokenExpander.Add("abc");
            abbreviationTokenExpander.Add("foostr");

            // Assert
            abbreviationTokenExpander.ElementAt(0).Should().Be("abc");
            abbreviationTokenExpander.ElementAt(1).Should().Be("foostr");
            abbreviationTokenExpander.ElementAt(2).Should().Be("strasse");
            abbreviationTokenExpander.ElementAt(3).Should().Be("straße");
        }
    }
}
