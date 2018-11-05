using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Player
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string NickName { get; set; }
        [Required]
        public string Password { get; set; }

        public int Victory { get; set; }

        public int Draw { get; set; }

        public int Losing { get; set; }

    }
}
