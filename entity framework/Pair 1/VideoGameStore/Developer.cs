using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EstablishedDate { get; set; }
        public virtual ICollection<Game> Games { get; set; }

        public Developer()
        {
            Games = new HashSet<Game>();
        }
    }
}

