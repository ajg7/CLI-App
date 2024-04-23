using System;
using System.Collections.Generic;
using System.Text;
using Spreetail_Take_Home.Data;
using Spreetail_Take_Home.Data.Interfaces;

namespace Spreetail_Take_Home.Core
{
    public class MultiValueDictionary : IMultiValueDictionary
    {
        private readonly Dictionary<string, HashSet<string>> _dictionary;
        private readonly IMessageService _messageService;

        public MultiValueDictionary(IMessageService messageService)
        {
            _dictionary = new Dictionary<string, HashSet<string>>();
            _messageService = messageService;
        }

        public string GetKeys()
        {
            if (_dictionary.Count == 0) return _messageService.GetEmptySetMessage();
            StringBuilder result = new StringBuilder();
            int idx = 1;
            foreach (string key in _dictionary.Keys)
            {
                result.AppendLine(_messageService.CreateNumberedListMessage(idx, key));
                idx++;
            }
            return result.ToString().TrimEnd();
        }

        public string GetMembers(string key)
        {
            if (!_dictionary.ContainsKey(key))  return _messageService.GetKeyDoesNotExistMessage();

            List<string> members = new List<string>(_dictionary[key]);
            StringBuilder result = new StringBuilder();
            int idx = 1;
            foreach (string member in members)
            {
                result.AppendLine(_messageService.CreateNumberedListMessage(idx, member));
                idx++;
            }
            return result.ToString().TrimEnd();
        }

        public string Add(string key, string member)
        {
            if (string.IsNullOrEmpty(key)) return _messageService.GetNoKeyProvidedMessage();
            if (string.IsNullOrEmpty(member)) return _messageService.GetNoMemberProvidedMessage();
            if (!_dictionary.ContainsKey(key)) _dictionary[key] = new HashSet<string>();
            if (_dictionary[key].Contains(member)) return _messageService.GetMemberExistsMessage();

            _dictionary[key].Add(member);
            return _messageService.GetAddedMessage();
        }

        public string Remove(string key, string member)
        {
            if (string.IsNullOrEmpty(key)) return _messageService.GetNoKeyProvidedMessage();
            if (string.IsNullOrEmpty(member)) return _messageService.GetNoMemberProvidedMessage();
            if (!_dictionary.ContainsKey(key)) return _messageService.GetKeyDoesNotExistMessage();
            if (!_dictionary[key].Contains(member)) return _messageService.GetMemberDoesNotExistMessage();
            
            if (_dictionary[key].Count == 1) _dictionary.Remove(key);
            else _dictionary[key].Remove(member);
            
            return _messageService.GetRemovedMessage();
        }

        public string RemoveAll(string key)
        {
            if (string.IsNullOrEmpty(key)) return _messageService.GetNoKeyProvidedMessage();
            if (_dictionary.Count == 0) return _messageService.GetEmptySetMessage();
            if (!_dictionary.ContainsKey(key)) return _messageService.GetKeyDoesNotExistMessage();
            
            _dictionary.Remove(key);
            return _messageService.GetRemovedMessage();
        }

        public string Clear()
        {
            if (_dictionary.Count == 0) return _messageService.GetEmptySetMessage();
            
            _dictionary.Clear();
            return _messageService.GetClearedMessage();
        }

        public string KeyExists(string key)
        {
            if (string.IsNullOrEmpty(key)) return _messageService.GetNoKeyProvidedMessage();
            return _dictionary.ContainsKey(key).ToString();
        }

        public string MemberExists(string key, string member)
        {
            if (string.IsNullOrEmpty(key)) return _messageService.GetNoKeyProvidedMessage();
            if (string.IsNullOrEmpty(member)) return _messageService.GetNoMemberProvidedMessage();
            return (_dictionary.ContainsKey(key) && _dictionary[key].Contains(member)).ToString();
        }

        public string GetAllMembers()
        {
            if (_dictionary.Count == 0) return _messageService.GetEmptySetMessage();
            var keys = _dictionary.Keys;
            StringBuilder result = new StringBuilder();
            int idx = 1;
            foreach (string key in keys)
            {
                foreach (string member in _dictionary[key])
                {
                    result.AppendLine(_messageService.CreateNumberedListMessage(idx, member));
                    idx++;
                }
            }
            return result.ToString().TrimEnd();
        }

        public string GetItems()
        {
            if (_dictionary.Count == 0) return _messageService.GetEmptySetMessage();
            var keys = _dictionary.Keys;
            StringBuilder result = new StringBuilder();
            foreach (string key in keys)
            {
                foreach (string member in _dictionary[key])
                {
                    result.AppendLine(_messageService.CreateItemsMessage(key, member));
                }
            }
            return result.ToString().TrimEnd();
        }
    }

}