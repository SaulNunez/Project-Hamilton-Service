using System;
using System.Runtime.Serialization;

namespace ProjectHamiltonService.Game
{
    [Serializable]
    internal class LobbyNotExistsException : Exception
    {
        public LobbyNotExistsException()
        {
        }

        public LobbyNotExistsException(string message) : base(message)
        {
        }

        public LobbyNotExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LobbyNotExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}