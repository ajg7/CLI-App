using Xunit;
using Spreetail_Take_Home.Core;
using Spreetail_Take_Home.Data;
using System;

namespace Spreetail_Take_Home.Tests
{
    public class InputParserTests
    {
        [Fact]
        public void Constructor_WhenInputIsNull_ThrowsArgumentNullException()
        {
            string input = null;

            var exception = Assert.Throws<ArgumentNullException>(() => new InputParser(input));

            Assert.Equal(Messages.NoInputProvidedMessage, exception.ParamName);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_WhenInputIsEmptyOrWhitespace_ThrowsArgumentNullException(string input)
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new InputParser(input));
            Assert.Equal(Messages.NoInputProvidedMessage, exception.ParamName);
        }

        [Fact]
        public void Constructor_WhenInputHasOneWord_SetsCommandOnly()
        {
            string input = "ADD";
            InputParser parser = new InputParser(input);

            Assert.Equal("ADD", parser.Command);
            Assert.Null(parser.Key);
            Assert.Null(parser.Member);
        }

        [Fact]
        public void Constructor_WhenInputHasTwoWords_SetsCommandKeyAndMember()
        {
            string input = "ADD Batman";
            InputParser parser = new InputParser(input);

            Assert.Equal("ADD", parser.Command);
            Assert.Equal("Batman", parser.Key);
            Assert.Null(parser.Member);
        }

        [Fact]
        public void Constructor_WhenInputHasThreeWords_SetsCommandKeyAndMember()
        {
            string input = "ADD Batman Joker";
            InputParser parser = new InputParser(input);

            Assert.Equal("ADD", parser.Command);
            Assert.Equal("Batman", parser.Key);
            Assert.Equal("Joker", parser.Member);
        }

        [Fact]
        public void Constructor_WhenInputHasMoreThanThreeWords_IgnoresExtraWords()
        {
            string input = "ADD Superman LexLuthor ToyMan Brianiac";
            InputParser parser = new InputParser(input);

            Assert.Equal("ADD", parser.Command);
            Assert.Equal("Superman", parser.Key);
            Assert.Equal("LexLuthor", parser.Member);
        }

        [Fact]
        public void Constructor_WhenInputHasExcessiveSpaces_HandlesGracefully()
        {
            string input = "      ADD   GreenLantern                      Sinestro   ";
            InputParser parser = new InputParser(input);

            Assert.Equal("ADD", parser.Command);
            Assert.Equal("GreenLantern", parser.Key);
            Assert.Equal("Sinestro", parser.Member);
        }
    }

}