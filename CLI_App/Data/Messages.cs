using System;

namespace Spreetail_Take_Home.Data
{
    public static class Messages
    {
        public const string EmptySetMessage = ") (empty set)";
        public const string KeyDoesNotExistMessage = ") ERROR, key does not exist";
        public const string MemberDoesNotExistMessage = ") ERROR, member does not exist";
        public const string MemberExistsMessage = ") ERROR, member already exists for key";
        public const string NoKeyProvidedMessage = ") ERROR, no key was provided";
        public const string NoMemberProvidedMessage = ") ERROR, no member was provided";
        public const string NoInputProvidedMessage = ") ERROR, no input was provided";
        public const string NotValidCommandMessage = ") ERROR, not a valid command";
        public const string AddedMessage = ") Added";
        public const string RemovedMessage = ") Removed";
        public const string ClearedMessage = ") Cleared";

        public static string CreateNumberedListMessage(int idx, string item)
        {
            return $"{idx}) {item}";
        }

        public static string CreateItemsMessage(string key, string member)
        {
            return $"{key}: {member}";
        }
    }
}