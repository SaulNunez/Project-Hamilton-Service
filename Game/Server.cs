using ProjectHamiltonService.Game;
using ProjectHamiltonService.Game.Abstracts;
using ProjectHamiltonService.Game.ServerActions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaCasaDelTerror.Models
{
    public class Server
    {
        private static readonly Lazy<Server> lazy = new Lazy<Server>(() => new Server());

        public static Server Instance { get { return lazy.Value; } }

        private Server() {}

        public Dictionary<string, Lobby> lobbies = new Dictionary<string, Lobby>();

        public List<ServerPlayer> players = new List<ServerPlayer>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hubCode"></param>
        /// <param name="playerAuth"></param>
        /// <returns></returns>
        public List<Items> GetItems(string hubCode, string playerAuth)
        {
            if (!lobbies.ContainsKey(hubCode))
            {
                throw new Exception("Hub was not found");
            }

            return lobbies[hubCode].GetPlayer().items;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hubCode"></param>
        /// <param name="userVerification"></param>
        /// <param name="itemIdentification"></param>
        public void UseItem(string hubCode, string userVerification, string itemIdentification)
        {
            if (!lobbies.ContainsKey(hubCode))
            {
                throw new Exception("Hub was not found");
            }

            lobbies[hubCode].UseItem(userVerification, itemIdentification);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="verificationCode"></param>
        /// <param name="hubCode"></param>
        /// <returns></returns>
        public int MoveVertical(string hubCode, int direction, string verificationCode)
        {
            if (!lobbies.ContainsKey(hubCode))
            {
                throw new Exception("Hub was not found");
            }

            return lobbies[hubCode].MoveVertical(verificationCode, direction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hubCode"></param>
        /// <param name="direction"></param>
        /// <param name="verificationCode"></param>
        /// <returns></returns>
        public int MoveHorizontal(string hubCode, int direction, string verificationCode)
        {
            if (!lobbies.ContainsKey(hubCode))
            {
                throw new Exception("Hub was not found");
            }

            return lobbies[hubCode].MoveHorizontal(verificationCode, direction);
        }

        public async Task<bool> SolvePuzzle(string hubCode, string verificationCode, string codeResult)
        {
            if (!lobbies.ContainsKey(hubCode))
            {
                throw new Exception("Hub was not found");
            }

            return await lobbies[hubCode].CheckPuzzle(verificationCode, codeResult);
        }

        /// <summary>
        /// Moves current player in a lobby to a position
        /// </summary>
        /// <param name="pos"></param>
        /// <returns>A position if the player can move</returns>
        public Position? MoveTo(Position pos)
        {
            return null;
        }
    }
}