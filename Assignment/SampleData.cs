using FileHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{


    public class SampleData : ISampleData
    {
        public string PeopleFilePath { get; set; } = @"C:\Users\saffron\source\repos\Cscd371 c#\EWU-CSCD371-2019-Fall\Assignment\People.csv";
        //public List<string> Headers { get; set; } = null;

        private HeaderIndexes _HeaderIndexes;

        public SampleData(string filePath)
        {
            PeopleFilePath = filePath;
           _HeaderIndexes = new HeaderIndexes(filePath);
    }

        public SampleData()
        {
            _HeaderIndexes = new HeaderIndexes(PeopleFilePath);
        }

        public IEnumerable<string> CsvRows
        {   
            get
            {
                IEnumerable<string> lines = File.ReadAllLines(PeopleFilePath).Where(item =>
                {
                    if (item.StartsWith("0"))
                    {
                       
                        return false;
                    }

                    return !string.IsNullOrWhiteSpace(item);
                });

                return lines;
            }
        }

        IEnumerable<IPerson> ISampleData.People => throw new NotImplementedException();

        // 1.
        //public IEnumerable<string> CsvRows() { throw new NotImplementedException(); }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            IEnumerable<string> distinctStates = CsvRows.Select(item =>
            {
                return item.Split(',')[_HeaderIndexes.State];


            }).Distinct().OrderBy(item => item);

            //IEnumerable<string> distinctStates = from item in CsvRows where item.Split(',')[Headers.IndexOf("State")] select  ;


            return distinctStates;
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            IEnumerable<string> uniqueStatesQuery = GetUniqueSortedListOfStatesGivenCsvRows();

            string result = string.Join(",", uniqueStatesQuery);

            return result;

        }

        // 4.
        public IEnumerable<IPerson> People()
        {

            var engine = new FileHelperEngine<Person>();

            string fileAdress = @"C:\Users\saffron\source\repos\Cscd371 c#\EWU-CSCD371-2019-Fall\Assignment\People.csv";

            var result = engine.ReadFile(fileAdress);

            IEnumerable<IPerson> people = result;

            return people;

        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();

        public IEnumerable<IPerson> GroupByState()
        {

            IEnumerable<IPerson> people = People();



            IEnumerable<IGrouping<string, IPerson>> query =
                from person in people
                group person by person.State;

            List<IPerson> peopleCollection = new List<IPerson>();

            foreach (IGrouping<string, IPerson> personGroup in query)
            {
                foreach (IPerson person in personGroup)
                {
                    peopleCollection.Add(person);
                }
            }

            foreach (IPerson person in peopleCollection)
            {
                Console.WriteLine($"{ person.State}, {person.LastName}");
            }


            return people;
        }
    }

    public class HeaderIndexes
    {


        public int Id { get; }
        public int FirstName { get; }
        public int LastName { get; }
        public int Email { get; }
        public int StreetAddress { get; }
        public int City { get; }
        public int State { get; }
        public int Zip { get; }

        public HeaderIndexes(string peopleFilePath)
        {
            string headerLine;


            using StreamReader file =
                new StreamReader(peopleFilePath);
            while ((headerLine = file.ReadLine()) != null)
            {

            }

            file.Close();

            string[] headerIndexs = headerLine.Split(',');

            Id = headerLine.IndexOf("Id");
            FirstName = headerLine.IndexOf("FirstName");
            LastName = headerLine.IndexOf("LastName");
            Email = headerLine.IndexOf("Email");
            StreetAddress = headerLine.IndexOf("StreetAddress");
            City = headerLine.IndexOf("City");
            State = headerLine.IndexOf("State");
            Zip = headerLine.IndexOf("Zip");




        }
    }
}
