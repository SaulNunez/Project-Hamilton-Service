using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Models
{
    public class Items
    {
        public Guid Id { get; set; }
        [ForeignKey("Players")]
        public Guid PlayersId { get; set; }
        public int Prototype { get; set; }
        public string Name { get; set; }

        public virtual Players Player { get; set; }
    }
}
