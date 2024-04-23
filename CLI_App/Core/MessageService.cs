using System;
using Spreetail_Take_Home.Data;
using Spreetail_Take_Home.Data.Interfaces;

namespace Spreetail_Take_Home.Core
{
    public class MessageService : IMessageService
    {
        public string GetEmptySetMessage() => Messages.EmptySetMessage;
        public string GetKeyDoesNotExistMessage() => Messages.KeyDoesNotExistMessage;
        public string GetMemberDoesNotExistMessage() => Messages.MemberDoesNotExistMessage;
        public string GetMemberExistsMessage() => Messages.MemberExistsMessage;
        public string GetNoKeyProvidedMessage() => Messages.NoKeyProvidedMessage;
        public string GetNoMemberProvidedMessage() => Messages.NoMemberProvidedMessage;
        public string GetAddedMessage() => Messages.AddedMessage;
        public string GetRemovedMessage() => Messages.RemovedMessage;
        public string GetClearedMessage() => Messages.ClearedMessage;
        public string GetClearedExceptMessage(string key) => Messages.ClearedExceptMessage(key);
        public string GetNotValidCommandMessage() => Messages.NotValidCommandMessage;
        public string CreateNumberedListMessage(int idx, string item) => Messages.CreateNumberedListMessage(idx, item);
        public string CreateItemsMessage(string key, string member) => Messages.CreateItemsMessage(key, member);
    }

}