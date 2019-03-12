using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_8___9
{
    public class Program
    {
        private static Int32 s_n = 0;
        private static void M(Int32 x = 9, String s = "A",
        DateTime dt = default(DateTime), Guid guid = new Guid())
        {
            Console.WriteLine("x={0}, s={1}, dt={2}, guid={3}", x, s, dt, guid);
        }

        static void Main(string[] args)
        {
            // 1. Same as: M(9, "A", default(DateTime), new Guid());
            M();
            // 2. Same as: M(8, "X", default(DateTime), new Guid());
            M(8, "X");
            // 3. Same as: M(5, "A", DateTime.Now, Guid.NewGuid());
            M(5, guid: Guid.NewGuid(), dt: DateTime.Now);
            // 4. Same as: M(0, "1", default(DateTime), new Guid());
            M(s_n++, s_n++.ToString());
            // 5. Same as: String t1 = "2"; Int32 t2 = 3;
            // M(t2, t1, default(DateTime), new Guid());
            M(s: (s_n++).ToString(), x: s_n++);
        }

        internal sealed class SomeType
        {
            // Do not explicitly initialize the fields here.
            private Int32 m_x;
            private String m_s;
            private Double m_d;
            private Byte m_b;
            // This constructor sets all fields to their default.
            // All of the other constructors explicitly invoke this constructor.
            public SomeType()
            {
                m_x = 5;
                m_s = "Hi there";
                m_d = 3.14159;
                m_b = 0xff;
            }
            // This constructor sets all fields to their default, then changes m_x.
            public SomeType(Int32 x) : this()
            {
                m_x = x;
            }
            // This constructor sets all fields to their default, then changes m_s.
            public SomeType(String s) : this()
            {
                m_s = s;
            }
            // This constructor sets all fields to their default, then changes m_x & m_s.
            public SomeType(Int32 x, String s) : this()
            {
                m_x = x;
                m_s = s;
            }

            private static void ImplicitlyTypedLocalVariables()
            {
                var name = "Jeff";
                ShowVariableType(name); // Displays: System.String
                // var n = null; // Error: Cannot assign <null> to an implicitly-typed local variable
                var x = (String)null; // OK, but not much value
                ShowVariableType(x); // Displays: System.String
                var numbers = new Int32[] { 1, 2, 3, 4 };
                ShowVariableType(numbers); // Displays: System.Int32[]
                                           // Less typing for complex types
                var collection = new Dictionary<String, Single>() { { "Grant", 4.0f } };
                // Displays: System.Collections.Generic.Dictionary`2[System.String,System.Single]
                ShowVariableType(collection);
                foreach (var item in collection)
                {
                    // Displays: System.Collections.Generic.KeyValuePair`2[System.String,System.Single]
                    ShowVariableType(item);
                }
            }
            private static void ShowVariableType<T>(T t)
            {
                Console.WriteLine(typeof(T));
            }
        }
    }
}
