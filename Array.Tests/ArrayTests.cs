
using System;
using System.Collections.Generic;
using System.Text;
using Assignment6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Array.Tests
{
    [TestClass]
    public class ArrayTests
    {
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Cannot_Add_When_Capacity_Is_Full()
        {

            Array<int> testArray = new Array<int>(0);
            testArray.Add(2);


        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Cannot_Add_Null_Type()
        {

            Array<string> testArray = new Array<string>(1);
            string? t = null;
#pragma warning disable CS8604 // Possible null reference argument.
            testArray.Add(t);
#pragma warning restore CS8604 // Possible null reference argument.


        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Exception_When_Item_Isnt_Present_Array_Empty()
        {

            Array<string> testArray = new Array<string>(1);
            testArray.Contains("Inigo");


        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Exception_When_Item_Isnt_Present_Array_Not_Empty()
        {

            Array<string> testArray = new Array<string>(1);
            testArray.Add("Montoya");
            testArray.Contains("Inigo");


        }

        [TestMethod]

        public void Contains_Returns_True_When_Item_Is_Found()
        {

            Array<string> testArray = new Array<string>(1);
            string name = "Montoya";
            testArray.Add(name);
            Assert.IsTrue(testArray.Contains(name));


        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CopyTo_Validates_Array_Is_Large_Enough_Exception_When_Not()
        {
            int genericSize = 2;
            int copyArraySizeisSmaller = 1;
            Array<string> testArray = new Array<string>(genericSize);

            string[] copyArray = new string[copyArraySizeisSmaller];

            testArray.CopyTo(copyArray, 0);




        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CopyTo_Validates_Index_Is_Valid_For_Array()
        {
            int genericSize = 2;
            int copyArraySize = 1;
            Array<string> testArray = new Array<string>(genericSize);

            string[] copyArray = new string[copyArraySize];

            testArray.CopyTo(copyArray, copyArraySize);

        }


        [TestMethod]

        public void CopyTo_Copies_All_Items()
        {

            Array<string> testArray = new Array<string>(2);

            List<string> list = new List<string>();

            list.Add("one");
            list.Add("two");

            foreach (string s in list) {
                testArray.Add(s);
            }

            string[] copyArray = new string[testArray.Count];

            testArray.CopyTo(copyArray, 0);

            int i = 0;
            foreach (string s in list)
            {

                Assert.IsTrue(s == copyArray[i]);
                i++;
            }


        }


        [TestMethod]

        public void Collection_Initializer()
        {

            Array<string> testArray = new Array<string>() { "one", "two", "three" };

            Assert.IsTrue(testArray.Count == 3);




        }

        [TestMethod]

        public void Index_Operator_Retrieves_Correctly()
        {
            string[] basicArray = new string[] { "one", "two", "three" };

            Array<string> testArray = new Array<string>() { "one", "two", "three" };


            for (int i = 0; i < basicArray.Length; i++)
            {
                Assert.IsTrue(testArray[i] == basicArray[i]);
            }

        }


        [TestMethod]

        public void Index_Operator_Sets_Correctly()
        {
            string[] basicArray = new string[] { "one", "two", "three" };

            Array<string> testArray = new Array<string>() { "1", "2", "3" };
    


            for (int i = 0; i < basicArray.Length; i++)
            {
                testArray[i] = basicArray[i];
            }

            for (int i = 0; i < basicArray.Length; i++)
            {
                Assert.IsTrue(testArray[i] == basicArray[i]);
            }


        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Index_Operator_Validates_Index_Exception_When_Index_Too_Big()
        {
            

            Array<string> testArray = new Array<string>() { "one", "two", "three" };

            string s = testArray[3];

            
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Index_Operator_Validates_Index_Exception_When_Item_At_Index_Has_Not_Been_Initialized()
        {
            string[] basicArray = new string[] { "one", "two", "three" };

            Array<string> testArray = new Array<string>(3);


            for (int i = 0; i < basicArray.Length; i++)
            {
                testArray[i] = basicArray[i];
            }

            string s = testArray[3];




        }


        [TestMethod]
       
        public void Remove_Returns_True_Decrements_Count()
        {
            int genericSize = 2;
            
            Array<string> testArray = new Array<string>(genericSize);

            string testString = "montoya";

            testArray.Add(testString);
            Assert.IsTrue(testArray.Remove(testString));
            Assert.IsTrue(testArray.Count == 0);

        }

        [TestMethod]

        public void Remove_Returns_False_Count_Unchanged()
        {
            int genericSize = 2;

            Array<string> testArray = new Array<string>(genericSize);

            

            string testString = "montoya";

            string testString1 = "Inigo";

            testArray.Add(testString);
            Assert.IsFalse(testArray.Remove(testString1));
            Assert.IsTrue(testArray.Count == 1);

        }

        [TestMethod]
        public void Clear_Sets_Count_to_Zero_And_All_Items_Removed_And_Capacity_Same()
        {
            int capacity = 1;
            Array<string> testArray = new Array<string>(capacity);
            string name = "Montoya";
            testArray.Add(name);

            testArray.Clear();

            Assert.IsTrue(testArray.Capacity == capacity,"capacity wasn't preserved");
            Assert.IsTrue(testArray.Count == 0,"count not zero");
            Assert.IsFalse(testArray.Remove(name),"name was still found");


        }




        [TestMethod]
        public void Foreach_Returns_All_Items()
        {
            int size = 3;

            string[] testArray = new string[] { "one", "two", "three" }; 

            

            Array<string> testArrayGeneric = new Array<string>(size);

            foreach (string s in testArray)
            {
                testArrayGeneric.Add(s);
            }

            int i = 0;
            foreach ( string itemFromGenericArray in testArrayGeneric ) {

                Assert.IsTrue(itemFromGenericArray == testArray[i]);
                i++;
            }
            


        }




    }
}
