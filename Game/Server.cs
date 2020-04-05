﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LaCasaDelTerror.Models
{
    class Server
    {
        private static readonly Lazy<Server> lazy = new Lazy<Server>(() => new Server());

        public static Server Instance { get { return lazy.Value; } }

        private Server() {}

        public Dictionary<string, Lobby> lobbies = new Dictionary<string, Lobby>();

        public void UseItem(string hubCode)
        {

        }

        public void MoveRight(string hubCode)
        {

        }

        public void MoveLeft(string hubCode)
        {

        }

        public void MoveTop(string hubCode)
        {

        }

        public void MoveBottom(string hubCode)
        {

        }
    }
}