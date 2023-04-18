using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAF_Event_Center.Domain.Entities
{
    public class Game
    {
        public Guid Id { get; set; }
        public string ?Name { get; set; }
        public string ?ImageUrl { get; set; }
        
        internal Game() { }
        public Game(string? name, string? imageUrl)
        {
            Id = Guid.NewGuid();
            Name = name;
            ImageUrl = imageUrl;
        }
    }
}
