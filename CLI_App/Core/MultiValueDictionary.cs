using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spreetail_Take_Home.Data;

namespace Spreetail_Take_Home.Core
{
    public class MultiValueDictionary 
    {
        private readonly Dictionary<string, HashSet<string>> _dictionary;

        public MultiValueDictionary()
        {
            _dictionary = new Dictionary<string, HashSet<string>>();
        }

        public string GetKeys()
        {
            if (_dictionary.Count == 0) return Messages.EmptySetMessage;
            StringBuilder result = new StringBuilder();
            int idx = 1;
            foreach (string key in _dictionary.Keys)
            {
                result.AppendLine(Messages.CreateNumberedListMessage(idx, key));
                idx++;
            }
            return result.ToString().TrimEnd();
        }

        public string GetMembers(string key)
        {
            if (!_dictionary.ContainsKey(key))  return Messages.KeyDoesNotExistMessage;

            List<string> members = new List<string>(_dictionary[key]);
            StringBuilder result = new StringBuilder();
            int idx = 1;
            foreach (string member in members)
            {
                result.AppendLine(Messages.CreateNumberedListMessage(idx, member));
                idx++;
            }
            return result.ToString().TrimEnd();
        }

        public string Add(string key, string member)
        {
            if (string.IsNullOrEmpty(key)) return Messages.NoKeyProvidedMessage;
            if (string.IsNullOrEmpty(member)) return Messages.NoMemberProvidedMessage;
            if (!_dictionary.ContainsKey(key)) _dictionary[key] = new HashSet<string>();
            if (_dictionary[key].Contains(member)) return Messages.MemberExistsMessage;

            _dictionary[key].Add(member);
            return Messages.AddedMessage;
        }

        public string Remove(string key, string member)
        {
            if (string.IsNullOrEmpty(key)) return Messages.NoKeyProvidedMessage;
            if (string.IsNullOrEmpty(member)) return Messages.NoMemberProvidedMessage;
            if (!_dictionary.ContainsKey(key)) return Messages.KeyDoesNotExistMessage;
            if (!_dictionary[key].Contains(member)) return Messages.MemberDoesNotExistMessage;
            
            if (_dictionary[key].Count == 1) _dictionary.Remove(key);
            else _dictionary[key].Remove(member);
            
            return Messages.RemovedMessage;
        }

        public string RemoveAll(string key)
        {
            if (string.IsNullOrEmpty(key)) return Messages.NoKeyProvidedMessage;
            if (_dictionary.Count == 0) return Messages.EmptySetMessage;
            if (!_dictionary.ContainsKey(key)) return Messages.KeyDoesNotExistMessage;
            
            _dictionary.Remove(key);
            return Messages.RemovedMessage;
        }

        public string Clear()
        {
            if (_dictionary.Count == 0) return Messages.EmptySetMessage;
            
            _dictionary.Clear();
            return Messages.ClearedMessage;
        }

        public string KeyExists(string key)
        {
            if (string.IsNullOrEmpty(key)) return Messages.NoKeyProvidedMessage;
            return _dictionary.ContainsKey(key).ToString();
        }

        public string MemberExists(string key, string member)
        {
            if (string.IsNullOrEmpty(key)) return Messages.NoKeyProvidedMessage;
            if (string.IsNullOrEmpty(member)) return Messages.NoMemberProvidedMessage;
            return (_dictionary.ContainsKey(key) && _dictionary[key].Contains(member)).ToString();
        }

        public string GetAllMembers()
        {
            HashSet<string> combinedHashSet = new HashSet<string>(_dictionary.Values.SelectMany(hashSet => hashSet));
            StringBuilder result = new StringBuilder();
            int idx = 1;
            foreach (string set in combinedHashSet)
            {
                result.AppendLine(Messages.CreateNumberedListMessage(idx, set));
                idx++;
            }
            return result.ToString().TrimEnd();
        }

        public string GetItems()
        {
            if (_dictionary.Count == 0) return Messages.EmptySetMessage;
            
            var keys = _dictionary.Keys;
            StringBuilder result = new StringBuilder();
            foreach (string key in keys)
            {
                foreach (string member in _dictionary[key])
                {
                    result.AppendLine(Messages.CreateItemsMessage(key, member));
                }
            }

            return result.ToString().TrimEnd();
        }
    }

}