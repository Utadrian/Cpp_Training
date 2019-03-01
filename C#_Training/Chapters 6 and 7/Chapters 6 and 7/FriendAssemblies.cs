using System;
using System.Runtime.CompilerServices; // For InternalsVisibleTo attribute
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapters_6_and_7
{
    class FriendAssemblies
    {
        // This assembly's internal types can be accessed by any code written
        // in the following two assemblies (regardless of version or culture):
        [assembly: InternalsVisibleTo("Wintellect, PublicKey=12345678...90abcdef")]
        [assembly: InternalsVisibleTo("Microsoft, PublicKey=b77a5c56...1934e089")]

        internal sealed class SomeInternalType { }
        internal sealed class AnotherInternalType { }

        internal sealed class Foo
        {
            private static Object SomeMethod()
            {
                // This "Wintellect" assembly accesses the other assembly's
                // internal type as if it were a public type
                SomeInternalType sit = new SomeInternalType();
                return sit;
            }
        }
    }
}
