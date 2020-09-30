using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Models
{
    public class Items
    {
        public Guid id;
        [ForeignKey("Players")]
        public Guid playersId;
        public int prototype;
        public string name;

        public Players player;
    }
}
