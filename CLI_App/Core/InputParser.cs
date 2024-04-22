using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Spreetail_Take_Home.Data;

namespace Spreetail_Take_Home.Core
{
    public class InputParser
    {
        public string Command { get; private set; }
        public string? Key { get; private set; }
        public string? Member { get; private set; }

        public InputParser(string input)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input)) throw new ArgumentNullException(Messages.NoInputProvidedMessage);
            string[] tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Command = tokens[0];
            if (tokens.Length > 1) Key = tokens[1];
            if (tokens.Length > 2) Member = tokens[2];
        }
    }
}
