using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ClassLibrary
{
    public class DebitAccounts
    {
        public int DebitId { get; set; }
        public string Valută { get; set; }
    }

    public class CompleteDebitAccounts:DebitAccounts
    {
        public string SumăCurentă { get; set; }
        public string CNPclient { get; set; }
    }
}
