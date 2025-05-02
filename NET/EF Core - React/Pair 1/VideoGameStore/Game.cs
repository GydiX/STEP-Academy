using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public bool IsMultiplayer { get; set; }
        public int DeveloperId { get; set; }
        public virtual Developer Developer { get; set; }
    }
}
