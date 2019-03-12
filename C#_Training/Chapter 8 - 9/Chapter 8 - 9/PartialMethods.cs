using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_8___9
{
    class PartialMethods
    {
        // Tool-produced code in some source code file:
        internal class Base
        {
            private String m_name;
            // Called before changing the m_name field
            protected virtual void OnNameChanging(String value)
            {
            }
            public String Name
            {
                get { return m_name; }
                set
                {
                    OnNameChanging(value.ToUpper()); // Inform class of potential change
                    m_name = value; // Change the field
                }
            }
        }
        // Developer-produced code in some other source code file:
        internal class Derived : Base
        {
            protected override void OnNameChanging(string value)
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("value");
            }
        }
    }
}
