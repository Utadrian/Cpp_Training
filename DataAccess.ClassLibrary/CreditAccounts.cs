using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ClassLibrary
{
    public class CreditAccounts
    {
        public int CreditId { get; set; }
        public string Valută { get; set; }
    }

    public class CompleteCreditAccounts:CreditAccounts
    {
        public string SumăCurentă { get; set; }
        public string SumăIniţială { get; set; }
        public int PerioadăÎnLuni { get; set; }
        public int ProcentDobândă { get; set; }
        public string CNPclient { get; set; }
    }
}
