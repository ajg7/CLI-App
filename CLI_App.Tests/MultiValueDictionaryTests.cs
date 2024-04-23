using Xunit;
using Spreetail_Take_Home.Core;

namespace Spreetail_Take_Home.Tests
{
    public class MultiValueDictionaryTests
    {
        private readonly MultiValueDictionary _dictionary;
        private readonly MessageService _messageService;

        public MultiValueDictionaryTests()
        {
            _messageService = new MessageService();
            _dictionary = new MultiValueDictionary(_messageService);
        }

        [Fact]
        public void GetKeys_WhenEmpty_ReturnsEmptySetMessage()
        {
            var result = _dictionary.GetKeys();
            Assert.Equal(_messageService.GetEmptySetMessage(), result);
        }

        [Fact]
        public void GetKeys_WhenNotEmpty_ReturnsListOfKeys()
        {
            _dictionary.Add("Batman", "PoisonIvy");
            _dictionary.Add("Superman", "LexLuthor");
            _dictionary.Add("WonderWoman", "Cheetah");

            var result = _dictionary.GetKeys();
            Assert.Contains("1) Batman", result);
            Assert.Contains("2) Superman", result);
            Assert.Contains("3) WonderWoman", result);
        }

        [Fact]
        public void GetMembers_WhenKeyIsEmpty_ReturnsError()
        {
            var result = _dictionary.GetMembers("");
            Assert.Equal(_messageService.GetNoKeyProvidedMessage(), result);
        }

        [Fact]
        public void GetMembers_WhenKeyIsNotPresent_ReturnsError()
        {
            _dictionary.Add("Batman", "PoisonIvy");
            _dictionary.Add("Superman", "LexLuthor");
            _dictionary.Add("WonderWoman", "Cheetah");

            var result = _dictionary.GetMembers("SpiderMan");
            Assert.Equal(_messageService.GetKeyDoesNotExistMessage(), result);
        }

        [Fact]
        public void GetMembers_WhenKeyIsPresent_ReturnsListOfMembers()
        {
            _dictionary.Add("Batman", "PoisonIvy");
            _dictionary.Add("Batman", "Riddler");
            _dictionary.Add("Superman", "LexLuthor");
            _dictionary.Add("WonderWoman", "Cheetah");
            _dictionary.Add("Batman", "Joker");

            var result = _dictionary.GetMembers("Batman");
            Assert.Contains("1) PoisonIvy", result);
            Assert.Contains("2) Riddler", result);
            Assert.Contains("3) Joker", result);
        }

        [Fact]
        public void Add_WhenKeyAndMemberProvided_AddsSuccessfully()
        {
            var addResult = _dictionary.Add("SpiderMan", "DocOck");
            Assert.Equal(_messageService.GetAddedMessage(), addResult);

            var keysResult = _dictionary.GetKeys();
            Assert.Contains("1) SpiderMan", keysResult);

            var membersResult = _dictionary.GetMembers("SpiderMan");
            Assert.Contains("1) DocOck", membersResult);
        }

        [Fact]
        public void Add_WhenKeyOrMemberAreNotProvided_ReturnsError()
        {
            var noKeyAddResult = _dictionary.Add("", "");
            Assert.Equal(_messageService.GetNoKeyProvidedMessage(), noKeyAddResult);

            var noMemberAddResult = _dictionary.Add("IronMan", "");
            Assert.Equal(_messageService.GetNoMemberProvidedMessage(), noMemberAddResult);
        }

        [Fact]
        public void Add_WhenDuplicateAdded_ReturnsError()
        {
            _dictionary.Add("Batman", "PoisonIvy");
            var result = _dictionary.Add("Batman", "PoisonIvy");
            Assert.Equal(_messageService.GetMemberExistsMessage(), result);

            var otherResult = _dictionary.Add("Robin", "PoisonIvy");
            Assert.Equal(_messageService.GetAddedMessage(), otherResult);
        }

        [Fact]
        public void Remove_WhenMemberExists_RemovesMember()
        {
            _dictionary.Add("Batman", "Joker");
            var result = _dictionary.Remove("Batman", "Joker");
            Assert.Equal(_messageService.GetRemovedMessage(), result);
            var removedResult = _dictionary.GetKeys();
            Assert.Equal(_messageService.GetEmptySetMessage(), removedResult);
        }

        [Fact]
        public void Remove_WhenKeyDoesNotExists_RemovesErrorMessage()
        {
            _dictionary.Add("Batman", "Joker");
            var result = _dictionary.Remove("Superman", "LexLuthor");
            Assert.Equal(_messageService.GetKeyDoesNotExistMessage(), result);
        }

        [Fact]
        public void Remove_WhenMemberDoesNotExists_ReturnsErrorMessage()
        {
            _dictionary.Add("Batman", "Joker");
            var result = _dictionary.Remove("Batman", "PoisonIvy");
            Assert.Equal(_messageService.GetMemberDoesNotExistMessage(), result);
        }

        [Fact]
        public void RemoveAll_WhenKeyExists_RemovesAllMembers()
        {
            _dictionary.Add("Superman", "LexLuthor");
            _dictionary.Add("Superman", "Brianiac");
            _dictionary.Add("Superman", "ToyMan");
            var result = _dictionary.RemoveAll("Superman");
            Assert.Equal(_messageService.GetRemovedMessage(), result);

            var keysResult = _dictionary.GetKeys();
            Assert.Equal(_messageService.GetEmptySetMessage(), keysResult);            
        }

        [Fact]
        public void Clear_WhenDictionaryNotEmpty_ClearsAll()
        {
            _dictionary.Add("Batman", "Joker");
            _dictionary.Add("Batman", "Catwoman");
            _dictionary.Add("Superman", "LexLuthor");
            _dictionary.Add("GreenLantern", "Sinestro");
            var result = _dictionary.Clear();
            Assert.Equal(_messageService.GetClearedMessage(), result);

            var keysResult = _dictionary.GetKeys();
            Assert.Equal(_messageService.GetEmptySetMessage(), keysResult);
        }

        [Fact]
        public void KeyExists_WhenKeyPresent_ReturnsTrue()
        {
            _dictionary.Add("SpiderMan", "Venom");
            var result = _dictionary.KeyExists("SpiderMan");
            Assert.Equal("True", result);
        }

        [Fact]
        public void KeyExists_WhenKeyIsNotPresent_ReturnsFalse()
        {
            _dictionary.Add("SpiderMan", "Venom");
            var result = _dictionary.KeyExists("Batman");
            Assert.Equal("False", result);
        }

        [Fact]
        public void MemberExists_WhenCorrectKeyOrMemberPresent_ReturnsTrue()
        {
            _dictionary.Add("SpiderMan", "Venom");
            var result = _dictionary.MemberExists("SpiderMan", "Venom");
            Assert.Equal("True", result);
        }

        [Fact]
        public void MemberExists_WhenCorrectKeyOrMemberIsNotPresent_ReturnsFalse()
        {
            _dictionary.Add("SpiderMan", "Venom");
            var result1 = _dictionary.MemberExists("SpiderMan", "GreenGoblin");
            var result2 = _dictionary.MemberExists("Batman", "Venom");
            Assert.Equal("False", result1);
            Assert.Equal("False", result2);
        }

        [Fact]
        public void AllMembers_WhenMembersArePresent_ReturnAllMembersInDict()
        {
            _dictionary.Add("Batman", "Joker");
            _dictionary.Add("SpiderMan", "Venom");
            _dictionary.Add("Superman", "LexLuthor");
            _dictionary.Add("GreenLantern", "Sinestro");

            var result = _dictionary.GetAllMembers();
            Assert.Contains("1) Joker", result);
            Assert.Contains("2) Venom", result);
            Assert.Contains("3) LexLuthor", result); 
            Assert.Contains("4) Sinestro", result);
        }

        [Fact]
        public void AllMembers_WhenMembersAreNotPresent_ReturnEmptySetMessage()
        {
            var result = _dictionary.GetAllMembers();
            Assert.Equal(_messageService.GetEmptySetMessage(), result);
        }

        [Fact]
        public void GetItems_WhenKeysAndMembersArePresent_ReturnAllKeyMemberPairsInDict()
        {
            _dictionary.Add("Batman", "Joker");
            _dictionary.Add("SpiderMan", "Venom");
            _dictionary.Add("Superman", "LexLuthor");
            _dictionary.Add("GreenLantern", "Sinestro");

            var result = _dictionary.GetItems();
            Assert.Contains("Batman: Joker", result);
            Assert.Contains("SpiderMan: Venom", result);
            Assert.Contains("Superman: LexLuthor", result);
            Assert.Contains("GreenLantern: Sinestro", result);
        }

        [Fact]
        public void GetItems_WhenKeysAndMembersAreNotPresent_ReturnEmptySetMessage()
        {
            var result = _dictionary.GetItems();
            Assert.Equal(_messageService.GetEmptySetMessage(), result);
        }
    }
}