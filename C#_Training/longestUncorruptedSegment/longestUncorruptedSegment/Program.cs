using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesignal
{
    class Program
    {
        static int[] longestUncorruptedSegment(int[] sourceArray, int[] destinationArray)
        {
            int index = 0, longestSegmentLength = 0;
            int saveStartIndex = 0;
            while(index < sourceArray.Length)
            {
                int currentSegmentLength = 0;
                int currentStartIndex = index;
                while(index < sourceArray.Length && sourceArray[index] == destinationArray[index])
                {
                    index++;
                    currentSegmentLength++;
                }
                if(index < sourceArray.Length && sourceArray[index] != destinationArray[index])
                {
                    index++;
                }
                if(currentSegmentLength > longestSegmentLength)
                {
                    saveStartIndex = currentStartIndex;
                    longestSegmentLength = currentSegmentLength;
                }
            }
            int[] ReturnedArray = new int[] { longestSegmentLength, saveStartIndex };
            return ReturnedArray;
        }
        static void Main(string[] args)
        {
            int[] sourceArray = new int[] { 33531593, 96933415, 28506400, 39457872, 29684716, 86010806 };
            int[] destinationArray = new int[] { 33531593, 96913415, 28506400, 39457872, 29684716, 86010806 };

            foreach(int elem in longestUncorruptedSegment(sourceArray,destinationArray))
            {
                Console.Write(elem + " ");
            }

            sourceArray = new int[] { 10000000 };
            destinationArray = new int[] { 99999999 };

            foreach (int elem in longestUncorruptedSegment(sourceArray, destinationArray))
            {
                Console.Write(elem + " ");
            }

            sourceArray = new int[] { 28813641, 31985183, 49809398, 48959083, 59368847, 37296474, 92567090, 50320165, 12197477, 28906340 };
            destinationArray = new int[] { 38813641, 31983183, 49879398, 48959043, 59468847, 35296474, 92567020, 80320165, 14197477, 28906360 };

            foreach (int elem in longestUncorruptedSegment(sourceArray, destinationArray))
            {
                Console.Write(elem + " ");
            }
        }
    }
}
