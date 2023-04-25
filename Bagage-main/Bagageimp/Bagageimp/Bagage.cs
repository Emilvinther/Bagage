using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagageimp
{
    internal class Bagage
    {
        // Bagage class with a destination valueable to check that it gets to the right place
        private string destination;

        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        public Bagage(string destination)
        {
            this.destination = destination;
        }
    }
}
