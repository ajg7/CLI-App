using Xunit;
using Spreetail_Take_Home.Core;
using Spreetail_Take_Home.Data;
using System;

namespace Spreetail_Take_Home.Tests
{
    public class MessageServiceTests
    {
        private readonly MessageService _messageService;

        public MessageServiceTests()
        {
            _messageService = new MessageService();
        }

        [Fact]
        public void GetEmptySetMessage_ReturnsCorrectMessage()
        {
            string expected = Messages.EmptySetMessage;
            string actual = _messageService.GetEmptySetMessage();
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void GetKeyDoesNotExistMessage_ReturnsCorrectMessage()
        {
            string expected = Messages.KeyDoesNotExistMessage;
            string actual = _messageService.GetKeyDoesNotExistMessage();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetMemberDoesNotExistMessage_ReturnsCorrectMessage()
        {
            string expected = Messages.MemberDoesNotExistMessage;
            string actual = _messageService.GetMemberDoesNotExistMessage();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetMemberExistMessage_ReturnsCorrectMessage()
        {
            string expected = Messages.MemberExistsMessage;
            string actual = _messageService.GetMemberExistsMessage();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetNoKeyProvidedMessage_ReturnsCorrectMessage()
        {
            string expected = Messages.NoKeyProvidedMessage;
            string actual = _messageService.GetNoKeyProvidedMessage();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetNoMemberProvidedMessage_ReturnsCorrectMessage()
        {
            string expected = Messages.NoMemberProvidedMessage;
            string actual = _messageService.GetNoMemberProvidedMessage();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAddedMessage_ReturnsCorrectMessage()
        {
            string expected = Messages.AddedMessage;
            string actual = _messageService.GetAddedMessage();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetRemovedMessage_ReturnsCorrectMessage()
        {
            string expected = Messages.RemovedMessage;
            string actual = _messageService.GetRemovedMessage();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetClearedMessage_ReturnsCorrectMessage()
        {
            string expected = Messages.ClearedMessage;
            string actual = _messageService.GetClearedMessage();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, "Joker", "1) Joker")]
        [InlineData(2, "Penguin", "2) Penguin")]
        [InlineData(3, "Riddler", "3) Riddler")]
        public void CreateNumberedListMessage_ReturnsCorrectlyFormattedMessage(int idx, string item, string expected)
        {
            string actual = _messageService.CreateNumberedListMessage(idx, item);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Batman", "Joker", "Batman: Joker")]
        [InlineData("Batman", "Penguin", "Batman: Penguin")]
        [InlineData("Batman", "Riddler", "Batman: Riddler")]
        public void CreateItemsMessage_ReturnsCorrectlyFormattedMessage(string key, string member, string expected)
        {
            string actual = _messageService.CreateItemsMessage(key, member);
            Assert.Equal(expected, actual);
        }
    }
}