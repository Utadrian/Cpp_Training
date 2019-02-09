using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft {
    class Widget
    {

    }
}

namespace Wintellect {
    class Widget
    {

    }
}

namespace Chapter3
{
    internal class Employee{
    }
    internal class Manager : Employee{
    }
    class Program
    {
        public static void Test1()
        {
            // No cast needed since new returns an Employee object
            // and Object is a base type of Employee.
            Object o = new Employee();
            // Cast required since Employee is derived from Object.
            // Other languages (such as Visual Basic) might not require
            // this cast to compile.
            Employee e = (Employee)o;
        }
        public static void Test2()
        {
            // Construct a Manager object and pass it to PromoteEmployee.
            // A Manager IS-A Object: PromoteEmployee runs OK.
            Manager m = new Manager();
            PromoteEmployee(m);
            // Construct a DateTime object and pass it to PromoteEmployee.
            // A DateTime is NOT derived from Employee. PromoteEmployee
            // throws a System.InvalidCastException exception.
            DateTime newYears = new DateTime(2013, 1, 1);
            PromoteEmployee(newYears);
        }
        public static void PromoteEmployee(Object o)
        {
            // At this point, the compiler doesn't know exactly what
            // type of object o refers to. So the compiler allows the
            // code to compile. However, at run time, the CLR does know
            // what type o refers to (each time the cast is performed) and
            // it checks whether the object's type is Employee or any type
            // that is derived from Employee.
            Employee e = (Employee)o;
        }

        // Reference type (because of 'class')
        class SomeRef { public Int32 x; }

        // Value type (because of 'struct')
        struct SomeVal { public Int32 x; }

        static void ValueTypeDemo()
        {
            SomeRef r1 = new SomeRef(); // Allocated in heap
            SomeVal v1 = new SomeVal(); // Allocated on stack
            r1.x = 5; // Pointer dereference
            v1.x = 5; // Changed on stack
            Console.WriteLine(r1.x); // Displays "5"
            Console.WriteLine(v1.x); // Also displays "5"
                                     // The left side of Figure 5-2 reflects the situation
                                     // after the lines above have executed.
            SomeRef r2 = r1; // Copies reference (pointer) only
            SomeVal v2 = v1; // Allocate on stack & copies members
            r1.x = 8; // Changes r1.x and r2.x
            v1.x = 9; // Changes v1.x, not v2.x
            Console.WriteLine(r1.x); // Displays "8"
            Console.WriteLine(r2.x); // Displays "8"
            Console.WriteLine(v1.x); // Displays "9"
            Console.WriteLine(v2.x); // Displays "5"
                                     // The right side of Figure 5-2 reflects the situation
                                     // after ALL of the lines above have executed.
        }

        static void Main(string[] args)
        {
            Object o = new Object();
            Boolean b1 = (o is Object); // b1 is true.
            Boolean b2 = (o is Employee); // b2 is false.

            if (o is Employee)
            {
                Employee m = (Employee)o;
                // Use e within the remainder of the 'if' statement.
            }

            Employee e1 = o as Employee;
            if (e1 != null)
            {
                // Use e within the 'if' statement.
            }

            Object o1 = new Object(); // Creates a new Object object
            Employee e2 = o as Employee; // Casts o to an Employee
                                        // The cast above fails: no exception is thrown, but e is set to null.
            //!e2.ToString(); // Accessing e throws a NullReferenceException.
        }

        Wintellect.Widget w = new Wintellect.Widget(); // Not ambiguous

    }
}
