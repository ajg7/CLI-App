using System;
using Spreetail_Take_Home.Data;
using Spreetail_Take_Home.Data.Interfaces;
using Spreetail_Take_Home.Core;
using System.ComponentModel.Design;

namespace Spreetail_Take_Home
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            IMessageService messageService = new MessageService();
            IMultiValueDictionary multiValueDictionary = new MultiValueDictionary(messageService);

            while (isRunning)
            {
                Console.Write("> ");
                string input = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input)) continue;
                InputParser parser = new InputParser(input);
                switch (parser.Command)
                 {
                     case Commands.ADD:
                         Console.WriteLine(multiValueDictionary.Add(parser.Key, parser.Member));
                         break;
                     case Commands.KEYS:
                         Console.WriteLine(multiValueDictionary.GetKeys());
                         break;
                     case Commands.MEMBERS:
                         Console.WriteLine(multiValueDictionary.GetMembers(parser.Key));
                         break;
                     case Commands.REMOVE:
                         Console.WriteLine(multiValueDictionary.Remove(parser.Key, parser.Member));
                         break;
                     case Commands.REMOVEALL:
                         Console.WriteLine(multiValueDictionary.RemoveAll(parser.Key));
                         break;
                     case Commands.CLEAR:
                         Console.WriteLine(multiValueDictionary.Clear());
                         break;
                     case Commands.KEYEXISTS:
                         Console.WriteLine(multiValueDictionary.KeyExists(parser.Key));
                         break;
                     case Commands.MEMBEREXISTS:
                         Console.WriteLine(multiValueDictionary.MemberExists(parser.Key, parser.Member));
                         break;
                     case Commands.ALLMEMBERS:
                         Console.WriteLine(multiValueDictionary.GetAllMembers());
                         break;
                     case Commands.ITEMS:
                         Console.WriteLine(multiValueDictionary.GetItems());
                         break;
                     case Commands.EXIT:
                         isRunning = false;
                         break;
                     default:
                         Console.WriteLine(messageService.GetNotValidCommandMessage());
                         break;
                 }
            }
        }
    }
}
