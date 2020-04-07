using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaCasaDelTerror.Models;
using LaCasaDelTerror.Models.Abstracts;
using ProjectHamiltonService.Game.Abstracts;

namespace ProjectHamiltonService.Game
{
    public interface IClientActions
    {
        void ChangeStats(string playerName, Stats stats);
        void SetItemList(string playerName, List<Items> items);
        void MoveTo(string playerName, Position pos);
        void StartPuzzle(string xmlTemplate, string instructions);
    }
}
