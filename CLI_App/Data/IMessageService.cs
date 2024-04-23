using System;

namespace Spreetail_Take_Home.Data
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
        string CreateNumberedListMessage(int idx, string item);
        string CreateItemsMessage(string key, string member);
    }

}

