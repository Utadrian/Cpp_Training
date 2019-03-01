using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Sort(int[] Array)
        {
            for(int i = 0; i<Array.Length; i++)
            {
                for(int j = i; j<Array.Length; j++)
                {
                    if(Array[i]>Array[j])
                    {
                        int aux = Array[j];
                        Array[j] = Array[i];
                        Array[i] = aux;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int[] Array = new int[] { 1, 2, 4, 0, 512, 0, 125, 11};

            Sort(Array);

            foreach(int elem in Array)
            {
                Console.Write(elem + " ");
            }
        }
    }
}
