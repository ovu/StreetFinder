using NUnit.Framework;
using StreetFinder.CombineFilter;

namespace Tests.UnitTests
{
    [TestFixture]
    public class StringTokenCombinerTests
    {
        [Test]
        public void Abbreviation_at_the_beginning_should_not_be_combined()
        {
            // Arrange
            var tokenCombiner = new StreetTokenCombiner();

            // Act
            tokenCombiner.Add("dr");
            tokenCombiner.Add("abc");
            tokenCombiner.Add("str");

            // Assert

            Assert.AreEqual("dr", tokenCombiner.ElementAt(0));
        }

        [Test]
        public void Abbreviation_at_the_end_should_be_combined_and_should_be_included_in_the_result()
        {
            // Arrange
            var tokenCombiner = new StreetTokenCombiner();

            // Act
            tokenCombiner.Add("dr");
            tokenCombiner.Add("abc");
            tokenCombiner.Add("str");

            // Assert
            Assert.AreEqual("abcstr", tokenCombiner.ElementAt(1));
            Assert.AreEqual("str", tokenCombiner.ElementAt(2));
        }

        [Test]
        public void Abbreviation_at_the_end_and_any_at_the_beginning_should_be_combined_and_should_be_included_in_the_result()
        {
            // Arrange
            var tokenCombiner = new StreetTokenCombiner();

            // Act
            tokenCombiner.Add("abc");
            tokenCombiner.Add("str");

            // Assert
            Assert.AreEqual("abcstr", tokenCombiner.ElementAt(0));
            Assert.AreEqual("str", tokenCombiner.ElementAt(1));
        }

        [Test]
        public void Text_without_abbreviaton_should_be_included_in_the_result()
        {
            // Arrange
            var tokenCombiner = new StreetTokenCombiner();

            // Act
            tokenCombiner.Add("abc");

            // Assert
            Assert.AreEqual("abc", tokenCombiner.ElementAt(0));
        }

        [Test]
        public void Text_with_only_abbreviaton_should_be_included_in_the_result()
        {
            // Arrange
            var tokenCombiner = new StreetTokenCombiner();

            // Act
            tokenCombiner.Add("st");

            // Assert
            Assert.AreEqual("st", tokenCombiner.ElementAt(0));
        }

        [Test]
        public void Text_with_two_abbreviatons_should_be_included_in_the_result()
        {
            // Arrange
            var tokenCombiner = new StreetTokenCombiner();

            // Act
            tokenCombiner.Add("prof");
            tokenCombiner.Add("dr");
            tokenCombiner.Add("abc");

            // Assert
            Assert.AreEqual("prof", tokenCombiner.ElementAt(0));
            Assert.AreEqual("dr", tokenCombiner.ElementAt(1));
            Assert.AreEqual("abc", tokenCombiner.ElementAt(2));
        }

        [Test]
        public void Two_tokens_should_be_combined()
        {
            // Arrange
            var tokenCombiner = new StreetTokenCombiner();

            // Act
            tokenCombiner.Add("bar");
            tokenCombiner.Add("foo");

            // Assert
            Assert.AreEqual("barfoo", tokenCombiner.ElementAt(0));
            Assert.AreEqual("foo", tokenCombiner.ElementAt(1));
        }

        [Test]
        public void Three_tokens_should_be_combined()
        {
            // Arrange
            var tokenCombiner = new StreetTokenCombiner();

            // Act
            tokenCombiner.Add("bar");
            tokenCombiner.Add("foo");
            tokenCombiner.Add("abc");

            // Assert
            Assert.AreEqual("barfoo", tokenCombiner.ElementAt(0));
            Assert.AreEqual("fooabc", tokenCombiner.ElementAt(1));
            Assert.AreEqual("abc", tokenCombiner.ElementAt(2));
        }

        [Test]
        public void Three_tokens_with_abbreviation_at_the_beginning_should_be_combined()
        {
            // Arrange
            var tokenCombiner = new StreetTokenCombiner();

            // Act
            tokenCombiner.Add("dr");
            tokenCombiner.Add("bar");
            tokenCombiner.Add("foo");
            tokenCombiner.Add("abc");

            // Assert
            Assert.AreEqual("dr", tokenCombiner.ElementAt(0));
            Assert.AreEqual("barfoo", tokenCombiner.ElementAt(1));
            Assert.AreEqual("fooabc", tokenCombiner.ElementAt(2));
            Assert.AreEqual("abc", tokenCombiner.ElementAt(3));
        }

        [Test]
        public void Three_tokens_with_abbreviation_at_the_beginning_and_at_the_end_should_be_combined()
        {
            // Arrange
            var tokenCombiner = new StreetTokenCombiner();

            // Act
            tokenCombiner.Add("dr");
            tokenCombiner.Add("bar");
            tokenCombiner.Add("foo");
            tokenCombiner.Add("abc");
            tokenCombiner.Add("str");

            // Assert
            Assert.AreEqual("dr", tokenCombiner.ElementAt(0));
            Assert.AreEqual("barfoo", tokenCombiner.ElementAt(1));
            Assert.AreEqual("fooabc", tokenCombiner.ElementAt(2));
            Assert.AreEqual("abcstr", tokenCombiner.ElementAt(3));
            Assert.AreEqual("str", tokenCombiner.ElementAt(4));
        }

    }
}
