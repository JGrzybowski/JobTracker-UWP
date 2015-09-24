using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTracker.Models
{
    public class EmailData
    {
        private string address;
        //TODO Notify and Validation
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Addressee { get; set; }
    }
}
