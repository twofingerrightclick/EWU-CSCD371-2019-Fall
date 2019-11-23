using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace AggregateTests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {

            SampleData sampleData = new SampleData();


            IEnumerable<IPerson> people = sampleData.People;

            //var peoplefromWA = people.Select(person =>  );



            foreach (IPerson person in people)
            {
                Console.WriteLine($"{ person.Address.State}, {person.LastName}");

            }
        }



        [TestMethod]
        public void CSVRows_ReturnsAll_Rows_Excluding_Header()
        {

            string testFilePath = @"C:\Users\saffron\source\repos\Cscd371 c#\EWU-CSCD371-2019-Fall\AggregateTests\TestPeople.csv";
            SampleData sampleData = new SampleData(testFilePath);


            IEnumerable<string> people = sampleData.CsvRows;

            int count = 0;
            foreach (var item in people)
            {
                count++;
            }

            

            Assert.IsTrue(count==File.ReadAllLines(testFilePath).Length - 1);

            
        }


        [TestMethod]
        public void Gets_DistinctList_Of_States_Using_HardCodedList()
        {

            SampleData sampleData = new SampleData(@"C:\Users\saffron\source\repos\Cscd371 c#\EWU-CSCD371-2019-Fall\AggregateTests\TestPeople.csv");
            

            List<String> hardCodedStatesFromTestCSV = new List<string>() { "CA", "WA", "AL" };
            
            hardCodedStatesFromTestCSV.Sort();

            IEnumerable<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            List<string> orderedStates = new List<string>();

            foreach (var item in states)
            {
                orderedStates.Add(item);
                Console.WriteLine(item);
            }


            for (int i = 0; i < hardCodedStatesFromTestCSV.Count; i++)
            {
                Assert.IsTrue(hardCodedStatesFromTestCSV[i] == orderedStates[i]);

            }


        }

   //to do :

        [TestMethod]
        public void Gets_DistinctList_Of_States_Using_Linq_To_Verify()
        {

            SampleData sampleData = new SampleData(@"C:\Users\saffron\source\repos\Cscd371 c#\EWU-CSCD371-2019-Fall\AggregateTests\TestPeople.csv");

            List<String> hardCodedStatesFromTestCSV = new List<string>() { "CA", "WA", "AL" };

            hardCodedStatesFromTestCSV.Sort();

            IEnumerable<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            List<string> orderedStates = new List<string>();

            foreach (var item in states)
            {
                orderedStates.Add(item);
            }


            for (int i = 0; i < hardCodedStatesFromTestCSV.Count; i++)
            {
                Assert.IsTrue(hardCodedStatesFromTestCSV[i] == orderedStates[i]);

            }


        }

//end to do/

        [TestMethod]
        public void Gets_String_With_Unique_States()
        {

            SampleData sampleData = new SampleData(@"C:\Users\saffron\source\repos\Cscd371 c#\EWU-CSCD371-2019-Fall\AggregateTests\TestPeople.csv");

            List<String> hardCodedStatesFromTestCSV = new List<string>() { "CA", "WA", "AL" };

            hardCodedStatesFromTestCSV.Sort();

            string result = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

            string[] orderedStates = result.Split(',');

            Console.WriteLine(result);

           
            for (int i = 0; i < hardCodedStatesFromTestCSV.Count; i++)
            {
                Assert.IsTrue(hardCodedStatesFromTestCSV[i] == orderedStates[i]);

            }


        }
    }
}
