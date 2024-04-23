using System;

namespace Spreetail_Take_Home.Data.Interfaces
{
    public interface IMessageService
    {
        string GetEmptySetMessage();
        string GetKeyDoesNotExistMessage();
        string GetMemberDoesNotExistMessage();
        string GetMemberExistsMessage();
        string GetNoKeyProvidedMessage();
        string GetNoMemberProvidedMessage();
        string GetAddedMessage();
        string GetRemovedMessage();
        string GetClearedMessage();
        string GetNotValidCommandMessage();
        string CreateNumberedListMessage(int idx, string item);
        string CreateItemsMessage(string key, string member);
    }

}

