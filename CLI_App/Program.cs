using System;
using Spreetail_Take_Home.Data;
using Spreetail_Take_Home.Core;
using System.ComponentModel.Design;

namespace Spreetail_Take_Home
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;

            MultiValueDictionary multiValueDictionary = new MultiValueDictionary();

            while (isRunning)
            {
                Console.Write("> ");
                string input = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrEmpty(input)) continue;
                string command = input.Split(" ")[0]; // First part of the input string
                string arguments = input.Substring(command.Length).Trim(); // The rest of the input string
                string[] tokens = arguments.Split(" ");

                switch (command)
                {
                    case Commands.ADD:
                        if (tokens.Length >= 2)
                        {
                            string key = tokens[0];
                            string value = tokens[1];
                            multiValueDictionary.Add(key, value);
                        }
                        break;
                    case Commands.KEYS:
                        multiValueDictionary.GetKeys();
                        break;
                    case Commands.MEMBERS:
                        if (tokens.Length >= 1)
                        {
                            string key = tokens[0];
                            multiValueDictionary.GetMembers(key);
                        }
                        break;
                    case Commands.REMOVE:
                        if (tokens.Length >= 2)
                        {
                            string key = tokens[0];
                            string value = tokens[1];
                            multiValueDictionary.Remove(key, value);
                        }
                        break;
                    case Commands.REMOVEALL:
                        if (tokens.Length >= 1)
                        {
                            string key = tokens[0];
                            multiValueDictionary.RemoveAll(key);
                        }
                        break;
                    case Commands.CLEAR:
                        multiValueDictionary.Clear();
                        break;
                    case Commands.KEYEXISTS:
                        if (tokens.Length >= 1)
                        {
                            string key = tokens[0];
                            multiValueDictionary.KeyExists(key);
                        }
                        break;
                    case Commands.MEMBEREXISTS:
                        if (tokens.Length >= 2)
                        {
                            string key = tokens[0];
                            string value = tokens[1];
                            multiValueDictionary.MemberExists(key, value);
                        }
                        break;
                    case Commands.ALLMEMBERS:
                        multiValueDictionary.GetAllMembers();
                        break;
                    case Commands.ITEMS:
                        multiValueDictionary.GetItems();
                        break;
                    default:
                        Console.WriteLine("No command found");
                        break;
                }
            }
        }
    }
}
