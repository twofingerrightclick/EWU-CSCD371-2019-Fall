
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

            Array<string> testArray = new Array<string>(0);
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
        
        public void True_When_Item_Is_Found()
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

            string[] copyArray= new string[copyArraySizeisSmaller];

            testArray.CopyTo(copyArray, 0);

           


        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CopyTo_Validates_Index_Is_Valid_For_Array()
        {
            int genericSize = 2;
            int copyArraySize= 1;
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
        public void Foreach_Implemented()
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
