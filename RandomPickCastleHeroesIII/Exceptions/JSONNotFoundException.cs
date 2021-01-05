using System;

namespace RandomPickCastleHeroesIII
{
    public class JSONNotFoundException : Exception
    {
        public JSONNotFoundException() { }
        public JSONNotFoundException(string message) : base(message) { }
        public JSONNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
