using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game
{
    /// <summary>
    /// Base para acciones que hace el cliente
    /// </summary>
    public class LobbyAction
    {
        /// <summary>
        /// Codigo personal para autentificarse como el que tiene el personaje
        /// </summary>
        public string playerToken;
        /// <summary>
        /// Codigo del lobby donde esta jugando
        /// </summary>
        public string lobbyCode;
    }
}
