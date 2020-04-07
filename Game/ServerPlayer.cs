using LaCasaDelTerror.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game
{
    public class ServerPlayer : Players
    {
        public string code;

        public ServerPlayer(Character characterPrototype) : base(characterPrototype)
        {
        }
    }
}
