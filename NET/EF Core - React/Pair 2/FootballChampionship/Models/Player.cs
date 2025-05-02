using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballChampionship.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Country { get; set; }
        public int Number { get; set; }
        public string Position { get; set; }
    }
}