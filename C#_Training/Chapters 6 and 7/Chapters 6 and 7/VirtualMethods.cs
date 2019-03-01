using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyA
{
    public class Phone
    {
        public void Dial()
        {
            Console.WriteLine("Phone.Dial");
            // Do work to dial the phone here.
        }
    }
}

namespace CompanyB
{
    public class BetterPhone : CompanyA.Phone
    {
        // This Dial method has nothing to do with Phone's Dial method.
        public new void Dial()
        {
            Console.WriteLine("BetterPhone.Dial");
            EstablishConnection();
            base.Dial();
        }
        protected virtual void EstablishConnection()
        {
            Console.WriteLine("BetterPhone.EstablishConnection");
            // Do work to establish the connection.
        }
    }
}