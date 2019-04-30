using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ClassLibrary
{
    public class CNPTriggerException : Exception
    {
        public CNPTriggerException()
        {
        }
        public CNPTriggerException(string exceptionMessage) : base(exceptionMessage)
        {
        }
    }
}
