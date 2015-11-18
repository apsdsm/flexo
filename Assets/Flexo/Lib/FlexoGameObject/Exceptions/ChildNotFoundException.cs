using System;

namespace Flexo.Exceptions
{
    /// <summary>
    /// Is thrown when a request to change focus to a child is made, but the 
    /// specified child can't be found.
    /// </summary>
    class ChildNotFoundException : Exception
    {
        public ChildNotFoundException ()
        {
        }

        public ChildNotFoundException ( string message )
        : base(message)
        {
        }

        public ChildNotFoundException ( string message, Exception inner )
        : base(message, inner)
        {
        }
    }
}
