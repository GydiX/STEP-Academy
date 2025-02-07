using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore
{
    public class VideoGameStoreContext : DbContext
    {
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Game> Games { get; set; }

        public VideoGameStoreContext() : base("VideoGameStoreDb") { }
    }
}