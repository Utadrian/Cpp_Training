using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapters_6_and_7
{
    public sealed class SomeType
    {
        // SomeType is not a primitive type but C# does allow
        // a constant variable of this type to be set to 'null'.
        public const SomeType Empty = null;
    }

    public sealed class SomeLibraryType
    {
        // NOTE: C# doesn't allow you to specify static for constants
        // because constants are always implicitly static.
        public const Int32 MaxEntriesInList = 50;
    }

    public sealed class SomeType2
    {
        // This is a static read-only field; its value is calculated and
        // stored in memory when this class is initialized at run time.
        public static readonly Random s_random = new Random();

        // This is a static read/write field.
        private static Int32 s_numberOfWrites = 0;

        // This is an instance read-only field.
        public readonly String Pathname = "Untitled";

        // This is an instance read/write field.
        private System.IO.FileStream m_fs;

        public SomeType2(String pathname)
        {
            // This line changes a read-only field.
            // This is OK because the code is in a constructor.
            this.Pathname = pathname;
        }

        public String DoSomething()
        {
            // This line reads and writes to the static read/write field.
            s_numberOfWrites = s_numberOfWrites + 1;
            // This line reads the read-only instance field.
            return Pathname;
        }

        public sealed class AType
        {
            // InvalidChars must always refer to the same array object
            public static readonly Char[] InvalidChars = new Char[] { 'A', 'B', 'C' };
        }

        public sealed class AnotherType
        {
            public static void M()
            {
                // The lines below are legal, compile, and successfully
                // change the characters in the InvalidChars array
                AType.InvalidChars[0] = 'X';
                AType.InvalidChars[1] = 'Y';
                AType.InvalidChars[2] = 'Z';

                // The line below is illegal and will not compile because
                // what InvalidChars refers to cannot be changed
                // (!) AType.InvalidChars = new Char[] { 'X', 'Y', 'Z' };
            }
        }
    }
}
