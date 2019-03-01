using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapters_6_and_7
{
    public static class AStaticClass
    {
        public static void AStaticMethod() { }
        public static String AStaticProperty
        {
            get { return s_AStaticField; }
            set { s_AStaticField = value; }
        }
        private static String s_AStaticField;
        public static event EventHandler AStaticEvent;
    }
}
