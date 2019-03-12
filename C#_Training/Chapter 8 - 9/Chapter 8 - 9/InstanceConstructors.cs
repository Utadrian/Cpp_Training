using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_8___9
{
    class InstanceConstructors
    {
        internal struct SomeValType
        {
            private Int32 m_x, m_y;
            // C# allows value types to have constructors that take parameters.
            public SomeValType(Int32 x)
            {
                // Looks strange but compiles fine and initializes all fields to 0/null.
                this = new SomeValType();
                m_x = x; // Overwrite m_x's 0 with x
                         // Notice that m_y was initialized to 0.
            }
        }
    }
}
