using System;

namespace Spreetail_Take_Home.Data.Interfaces
{
    public interface IMultiValueDictionary
    {
        string GetKeys();
        string GetMembers(string key);
        string Add(string key, string member);
        string Remove(string key, string member);
        string RemoveAll(string key);
        string Clear();
        string KeyExists(string key);
        string MemberExists(string key, string member);
        string GetAllMembers();
        string GetItems();
    }
}
