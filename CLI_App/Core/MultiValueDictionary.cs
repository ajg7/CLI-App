using System;
using System.Collections.Generic;
using System.Linq;
using Spreetail_CLI_Work_Sample.Data;

namespace Spreetail_CLI_Work_Sample.Core
{
    public class MultiValueDictionary
    {
        private readonly Dictionary<string, HashSet<string>> _dictionary;

        public MultiValueDictionary()
        {
            _dictionary = new Dictionary<string, HashSet<string>>();
        }

        public void GetKeys()
        {
            if (_dictionary.Count == 0)
            {
                Console.WriteLine("> (empty set)");
                return;
            }
            List<string> keys = new List<string>(this._dictionary.Keys);
            int idx = 1;
            foreach (string key in keys)
            {
                Console.WriteLine("{0}) {1}", idx, key);
                idx++;
            }
        }

        public void GetMembers(string key)
        {
            if (!_dictionary.ContainsKey(key) || _dictionary[key].Count < 1)
            {
                Console.WriteLine(") ERROR, key does not exist");
                return;
            }

            List<string> members = new List<string>(_dictionary[key]);
            int idx = 1;
            foreach (string member in members)
            {
                Console.WriteLine("{0}) {1}", idx, member);
                idx++;
            }
        }

        public void Add(string key, string value)
        {
            if (!_dictionary.ContainsKey(key)) _dictionary[key] = new HashSet<string>();
            if (_dictionary[key].Contains(value))
            {
                Console.WriteLine(") ERROR, member already exists for key");
                return;
            }
            _dictionary[key].Add(value);
            Console.WriteLine(") Added");
        }

        public void Remove(string key, string member)
        {
            if (!_dictionary.ContainsKey(key))
            {
                Console.WriteLine(") ERROR, key does not exist");
                return;
            }
            if (!_dictionary[key].Contains(member))
            {
                Console.WriteLine(") ERROR, member does not exist");
                return;
            }
            _dictionary[key].Remove(member);
            Console.WriteLine(") Removed");
        }

        public void RemoveAll(string key)
        {
            if (_dictionary.Count == 0)
            {
                Console.WriteLine("> (empty set)");
                return;
            }
            if (!_dictionary.ContainsKey(key))
            {
                Console.WriteLine(") ERROR, key does not exist");
                return;
            }
            _dictionary[key].Clear();
            Console.WriteLine(") Removed");
        }

        public void Clear()
        {
            if (_dictionary.Count == 0)
            {
                Console.WriteLine(") (empty set)");
                return;
            }
            _dictionary.Clear();
            Console.WriteLine(") Cleared");
        }

        public void KeyExists(string key)
        {
            bool hasKey = _dictionary.ContainsKey(key);
            Console.WriteLine(hasKey);
        }

        public void MemberExists(string key, string member)
        {
            bool hasMember = false;
            if (_dictionary.ContainsKey(key) && _dictionary[key].Contains(member))
            {
                hasMember = true;
            }
            Console.WriteLine(hasMember);
        }

        public void GetAllMembers()
        {
            HashSet<string> combinedHashSet = new HashSet<string>(_dictionary.Values.SelectMany(hashSet => hashSet));
            int idx = 1;
            foreach (string set in combinedHashSet)
            {
                Console.WriteLine("{0}) {1}", idx, set);
                idx++;
            }

        }

        public void GetItems()
        {
            if (_dictionary.Count == 0)
            {
                Console.WriteLine(") (empty set)");
                return;
            }
            var keys = _dictionary.Keys;
            foreach (string key in keys)
            {
                foreach (string member in _dictionary[key])
                {
                    Console.WriteLine("{0}: {1}", key, member);
                }
            }
        }
    }

}