using System;

namespace Spreetail_Take_Home.Data
{
    public static class Messages
    {
        public const string EmptySetMessage = ") (empty set)";
        public const string KeyNotExistMessage = ") ERROR, key does not exist";
        public const string MemberNotExistMessage = ") ERROR, member does not exist";
        public const string MemberExistsMessage = ") ERROR, member already exists for key";
        public const string AddedMessage = ") Added";
        public const string RemovedMessage = ") Removed";
        public const string ClearedMessage = ") Cleared";

        public static string ConcatMessage(int idx, string item)
        {
            return $"{idx}) {item}";
        }

        public static string ConcatItemsMessage(string key, string member)
        {
            return $"{key}: {member}";
        }
    }
}