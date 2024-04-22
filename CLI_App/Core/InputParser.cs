using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spreetail_Take_Home.Core
{
    public class InputParser
    {
        public string Command { get; private set; }
        public string Arguments { get; private set; }
        public string[] Tokens { get; private set; }
        public string Key { get; private set; }
        public string Member { get; private set; }

        public InputParser(string input)
        {
            Command = input.Split(" ")[0]; 
            Arguments = input.Substring(this.Command.Length).Trim(); 
            Tokens = this.Arguments.Split(" ");
            Key = this.Tokens[0];
            if (this.Tokens.Length >= 2)
            {
                Member = this.Tokens[1];
            }
        }
    }
}
