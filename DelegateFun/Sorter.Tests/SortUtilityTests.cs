using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorter;
using System;

namespace Sorter.Tests
{
    
    


    [TestClass]
    public class SortUtilityTests
    {

        public delegate bool SortBy(int i, int j);

        public bool IsGreater(int first, int second)
    {
        return first > second;
    }

        public bool IsLess(int first, int second)
        {
            return first > second;
        }


        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingAnAnonymousMethod()
        {

            int[] array = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9 };
            
            SortUtility sorter = new SortUtility(S: IsGreater);
            int n = array.Length-1;

            sorter.QuickSort(array,0,n);

            foreach (int i in array)
            {
                Console.Write(i);

            }

        }
    }
}
