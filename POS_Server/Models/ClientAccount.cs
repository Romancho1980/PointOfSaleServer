using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Server.Models
{
    public class ClientAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string INN { get; set; }
        public string City { get; set; }
        public string Passport { get; set; }
        public DateTime Birthday { get; set; }
        public string Account { get; set; }
        public int Balance { get; set; }
        public string Description { get; set; }

    }
}
