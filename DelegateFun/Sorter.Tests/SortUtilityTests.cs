using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sorter.Tests
{




    [TestClass]
    public class SortUtilityTests
    {

        public delegate bool SortBy(int i, int j);

        public bool Descending(int first, int second)
        {
            return first > second;
        }

        public bool Asccending(int first, int second)
        {
            return first < second;
        }


        int[] arrayAscending = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[] arrayDescending = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };


        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingLambdaExpression()
        {
            //setup
            int[] array = arrayDescending;

            SortUtility sorter = new SortUtility(sortBy: (x,y)=>x<y);
            
            //sort
            int n = array.Length - 1;

            sorter.QuickSort(array, 0, n);
            //verify
            for (int i = 0; i < array.Length; i++)
            {
                Assert.IsTrue(array[i] == arrayAscending[i]);
            }

        }


        [TestMethod]
        public void SortUtility_ShouldSortDescending_UsingLambdaStatement()
        {
            //setup
            int[] array = arrayAscending;

            Func< int, int, bool> sortByDescending = (x, y) => { return x > y; };

            SortUtility sorter = new SortUtility(sortBy: sortByDescending);
           //sort
            int n = array.Length - 1;

            sorter.QuickSort(array, 0, n);
            //verify
            for (int i = 0; i < array.Length; i++)
            {
                Assert.IsTrue(array[i] == arrayDescending[i]);
            }

        }



        [TestMethod]
        public void SortUtility_ShouldSortDescending_UsingAnonymousMethod()
        {
            //setup
            int[] array = arrayAscending;

            SortUtility sorter = new SortUtility(sortBy: Descending);

            //sort

            int n = array.Length - 1;
            sorter.QuickSort(array, 0, n);

            //verify
            for (int i = 0; i < array.Length; i++)
            {
                Assert.IsTrue(array[i] == arrayDescending[i]);
            }

        }
    }
}
