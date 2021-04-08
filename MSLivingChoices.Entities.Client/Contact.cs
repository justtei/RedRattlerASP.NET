using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSLivingChoices.Entities.Client
{
    public class Contact
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public int Interest { get; set; }
        public String Message { get; set; }
        public bool Result { get; set; }
    }
}
