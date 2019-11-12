
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

    }
}
