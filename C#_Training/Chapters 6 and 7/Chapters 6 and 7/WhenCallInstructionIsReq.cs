using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapters_6_and_7
{
    internal class SomeClass
    {
        // ToString is a virtual method defined in the base class: Object.
        public override String ToString()
        {
            // Compiler uses the 'call' IL instruction to call
            // Object’s ToString method nonvirtually.
            // If the compiler were to use 'callvirt' instead of 'call', this
            // method would call itself recursively until the stack overflowed.
            return base.ToString();
        }
    }
}
