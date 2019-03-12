using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_8___9
{
    // Tool-produced code in some source code file:
    internal sealed partial class Base
    {
        private String m_name;
        // This defining-partial-method-declaration is called before changing the m_name field
        partial void OnNameChanging(String value);
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
    internal sealed partial class Base
    {
        // This implementing-partial-method-declaration is called before m_name is changed
        partial void OnNameChanging(String value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException("value");
        }
    }
}
