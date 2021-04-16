using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSLivingChoices.Entities.Client
{
    public class EbookOrder
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Magazine { get; set; }
        public String street { get; set; }
        public String city { get; set; }
        public String state { get; set; }
        public String zip { get; set; }
        public bool chkCommunities { get; set; }
        public bool chkHomeHealth { get; set; }
        public bool chkPAS { get; set; }
        public String rad { get; set; }
        public String ExtraMessage { get; set; }
        public bool Result { get; set; }
    }
}
