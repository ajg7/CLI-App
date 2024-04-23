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

        private string FormatNumberedList(IEnumerable<string> values) 
        {
            StringBuilder result = new StringBuilder();
            int idx = 1;
            foreach (string value in values)
            {
                result.AppendLine(_messageService.CreateNumberedListMessage(idx, value));
                idx++;
            }
            return result.ToString().TrimEnd();
        }

        private string IterateDictionary(IEnumerable<string> keys, bool isCreateItemsList)
        {
            StringBuilder result = new StringBuilder();
            int idx = 1;
            foreach (string key in keys)
            {
                foreach (string member in _dictionary[key])
                {
                    if (isCreateItemsList)
                    {
                        result.AppendLine(_messageService.CreateItemsMessage(key, member));
                    } else
                    {
                        result.AppendLine(_messageService.CreateNumberedListMessage(idx, member));
                        idx++;
                    }
                    
                }
            }
            return result.ToString().TrimEnd();

        }

        public string GetKeys()
        {
            if (_dictionary.Count == 0) return _messageService.GetEmptySetMessage();
            return FormatNumberedList(_dictionary.Keys);
        }

        public string GetMembers(string key)
        {
            if (!_dictionary.ContainsKey(key))  return _messageService.GetKeyDoesNotExistMessage();
            List<string> members = new List<string>(_dictionary[key]);
            return FormatNumberedList(members);

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
            return IterateDictionary(keys, false);
        }

        public string GetItems()
        {
            if (_dictionary.Count == 0) return _messageService.GetEmptySetMessage();
            var keys = _dictionary.Keys;
            return IterateDictionary(keys, true);
        }
    }

}