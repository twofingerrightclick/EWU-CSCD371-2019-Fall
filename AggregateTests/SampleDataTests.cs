using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AggregateTests
{
    [TestClass]
    public class SampleDataTests
    {

   
        private string _TestFilePath = "TestPeople.csv";
        private string _PropertyTestFilePath = "PropertyTestFile.csv";



        [TestMethod]
        public void All_Person_Properties_Are_Filled_Correctly_No_Nulls()
        {

            SampleData sampleData = new SampleData(_PropertyTestFilePath);

            IEnumerable<IPerson> people = sampleData.People;


            foreach (IPerson person in people)
            {

                IEnumerable<PropertyInfo> personProperties = person.GetType().GetProperties();

                //done this way to practice with linq and reflection

                bool nullsInPersonProperties = personProperties.Where(propertyInfo => {  return propertyInfo.PropertyType == typeof(string); })
                .Select(propertyInfo => { return (value:(string)propertyInfo.GetValue(person), propertyInfo); })
                .Any((valueAndProperty) =>
                {
                    //not concerned about empty string values here.
                    if (valueAndProperty.value == null) {
                        Trace.WriteLine($"Person { valueAndProperty.propertyInfo} was null");
                        return true;
                    }
                    
                    if (valueAndProperty.propertyInfo.Name != valueAndProperty.value)
                    {
                        Trace.WriteLine($"Person { valueAndProperty.propertyInfo} was incorrectly assigned: {valueAndProperty.value}");
                        return true;
                    }
                    return false;
                });

                Assert.IsFalse(nullsInPersonProperties);
             
            }
        }


        [TestMethod]
        public void All_Address_Properties_Are_Filled_Correctly_No_Nulls()
        {

            SampleData sampleData = new SampleData(_PropertyTestFilePath);

            IEnumerable<IPerson> people = sampleData.People;


            foreach (IPerson person in people)
            {

              
                IEnumerable<PropertyInfo> personAddressProperties = person.Address.GetType().GetProperties();

                bool nullsInPersonAddressProperties = personAddressProperties.Where(propertyInfo => propertyInfo.PropertyType == typeof(string))
                .Select(propertyInfo => { return (value:(string)propertyInfo.GetValue(person.Address), propertyInfo); })
                .Any((valueAndProperty) =>
                {
                    if (string.IsNullOrEmpty(valueAndProperty.value))
                    {
                        Trace.WriteLine($"Person { valueAndProperty.propertyInfo} was null or empty");
                        return true;
                    }

                    if (valueAndProperty.propertyInfo.Name != valueAndProperty.value)
                    {
                        Trace.WriteLine($"Person { valueAndProperty.propertyInfo} was incorrectly assigned: {valueAndProperty.value}");
                        return true;
                    }
                    return false;
                });

                Assert.IsFalse(nullsInPersonAddressProperties);

            }
        }


        [TestMethod]
        public void CSVRows_ReturnsAll_Rows_Excluding_Header()
        {


            SampleData sampleData = new SampleData(_TestFilePath);


            IEnumerable<string> people = sampleData.CsvRows;

            int count = 0;
            foreach (var item in people)
            {
                count++;
            }



            Assert.IsTrue(count == File.ReadAllLines(_TestFilePath).Length - 1);


        }


        [TestMethod]
        public void Gets_DistinctList_Of_States_Using_HardCodedList()
        {

            SampleData sampleData = new SampleData(_TestFilePath);


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

            SampleData sampleData = new SampleData(_TestFilePath);

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

            SampleData sampleData = new SampleData(_TestFilePath);

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
