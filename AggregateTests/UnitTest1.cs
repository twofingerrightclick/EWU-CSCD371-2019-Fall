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


            IEnumerable<IPerson> people = sampleData.People();

            //var peoplefromWA = people.Select(person =>  );



            foreach (IPerson person in people)
            {
                Console.WriteLine($"{ person.State}, {person.LastName}");

            }
        }



        [TestMethod]
        public void CSVRows_ReturnsAll_Rows_Excluding_Header()
        {

            SampleData sampleData = new SampleData();


            IEnumerable<string> people = sampleData.CsvRows;

            int count = 0;
            foreach (var item in people)
            {
                count++;
            }

            

            Assert.IsTrue(count==File.ReadAllLines(sampleData.PeopleFilePath).Length - 1);

            
        }


        [TestMethod]
        public void Gets_DistinctList_Of_States()
        {

            SampleData sampleData = new SampleData();
            sampleData.PeopleFilePath = @"C:\Users\saffron\source\repos\Cscd371 c#\EWU-CSCD371-2019-Fall\AggregateTests\TestPeople.csv";

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
    }
}
