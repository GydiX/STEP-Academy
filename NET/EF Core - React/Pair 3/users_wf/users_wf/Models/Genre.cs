using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace users_wf.Models
{
    public class Genre
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
