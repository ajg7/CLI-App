using System;

namespace Spreetail_Take_Home.Data.Interfaces
{
    public interface IInputParser
    {
        string Command { get; }
        string? Key { get; }
        string? Member { get; }
    }
}

