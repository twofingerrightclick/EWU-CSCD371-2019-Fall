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
                .Select(propertyInfo => { return (value:(string)propertyInfo.GetValue(person)!, propertyInfo); })
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
                .Select(propertyInfo => { return (value:(string)propertyInfo.GetValue(person.Address)!, propertyInfo); })
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
            //kind of a bad test as it uses the same code as the method being tested does. thinking of another way to test...
            IEnumerable<string> expectedData = File.ReadAllLines(_TestFilePath).Skip(1);


            bool contentsMatch = Enumerable.SequenceEqual<string>(expectedData, people);

            Assert.IsTrue(contentsMatch);


        }


        [TestMethod]
        public void Gets_DistinctList_Of_States_Using_HardCodedList()
        {

            SampleData sampleData = new SampleData(_TestFilePath);


            List<String> hardCodedStatesFromTestCSV = new List<string>() { "CA", "WA", "AL" };

            hardCodedStatesFromTestCSV.Sort();

            IEnumerable<string> distinctStateQuery = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            bool contentsMatch = Enumerable.SequenceEqual<string>(distinctStateQuery, hardCodedStatesFromTestCSV);

            Assert.IsTrue(contentsMatch);

        }



        [TestMethod]
        public void Gets_DistinctList_Of_States_Using_Linq_To_Verify()
        {

            SampleData sampleData = new SampleData(_TestFilePath);

            int expectedCount = 3;

            var uniqueListofStatesQuery = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            var uniqueListofStatesDistinctQuery = uniqueListofStatesQuery.Distinct();

            Assert.IsTrue(uniqueListofStatesQuery.Count() == uniqueListofStatesDistinctQuery.Count() && uniqueListofStatesQuery.Count() == expectedCount);


        }

       

        [TestMethod]
        public void Gets_String_With_Unique_States_Using_CSVROWS_Returns_Unique_Ordered_String()
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


        [TestMethod]
        public void Gets_String_With_Unique_States_Using_PEOPLE_Returns_Unique_Ordered_String()
        {

            SampleData sampleData = new SampleData(_TestFilePath);

            List<String> hardCodedStatesFromTestCSV = new List<string>() { "CA", "WA", "AL" };

            hardCodedStatesFromTestCSV.Sort();

            var peoples = sampleData.People;

            string result = sampleData.GetAggregateListOfStatesGivenPeopleCollection(peoples);

            string[] resultAsArray = result.Split(',');

            for (int i = 0; i < hardCodedStatesFromTestCSV.Count; i++)
            {
                Assert.IsTrue(hardCodedStatesFromTestCSV[i] == resultAsArray[i]);

            }


        }


        [TestMethod]
        public void EmailAddressFilter_CorrectlyReturns_Tuples_That_Match_ThePredicate()
        {

            SampleData sampleData = new SampleData("EmailFilterTest.csv"); //contains 2 entries with firstname of Steve that should match 
                                                                           //the criteria of the predicate.

            Predicate <string> getAnyEmailthatIsGmail = s => s.Contains("gmail");

            IEnumerable<(string FirstName, string LastName)> gmailQuery = sampleData.FilterByEmailAddress(getAnyEmailthatIsGmail);

            Assert.IsTrue(gmailQuery.Count() == 2);
            
            foreach ((string firstName, string lastName) result in gmailQuery) {

                Assert.IsTrue(result.firstName == "Steve");
            }

        }
    }
}
