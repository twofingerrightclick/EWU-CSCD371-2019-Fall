using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{


    public class SampleData : ISampleData
    {
        //public string PeopleFilePath { get; set; } = @"C:\Users\saffron\source\repos\Cscd371 c#\EWU-CSCD371-2019-Fall\Assignment\People.csv";
        public string PeopleFilePath { get; set; } = @"People.csv";


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

        // 1.
        public IEnumerable<string> CsvRows
        {
            get
            {
                IEnumerable<string> lines = File.ReadAllLines(PeopleFilePath).Where(item =>
                {
                    return !string.IsNullOrWhiteSpace(item);
                }).Skip(1); //skip first lne (the header)

                return lines;
            }
        }
       
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
        public IEnumerable<IPerson> People
        {
            get
            {
                IEnumerable<IPerson> peopleQuery = CsvRows.Select(line =>
                {

                    string[] columns = line.Split(',');
                    return new Person()
                    {

                        FirstName = columns[_HeaderIndexes.FirstName],
                        LastName = columns[_HeaderIndexes.LastName],
                        EmailAddress = columns[_HeaderIndexes.Email],

                        StreetAddress = columns[_HeaderIndexes.StreetAddress],
                       

                        Address = new Address
                        {
                            StreetAddress = columns[_HeaderIndexes.StreetAddress],
                            City = columns[_HeaderIndexes.City],
                            State = columns[_HeaderIndexes.State],
                            Zip = columns[_HeaderIndexes.Zip],
                        }
                    };
                }).OrderBy(item => item.LastName);
             
                return peopleQuery;
            }

        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();

        public IEnumerable<IPerson> GroupByState()
        {

            IEnumerable<IPerson> people = People;



            IEnumerable<IGrouping<string, IPerson>> query =
                from person in people
                group person by person.Address.State;

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
                Console.WriteLine($"{ person.Address.State}, {person.LastName}");
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


            using StreamReader file = new StreamReader(peopleFilePath);
            headerLine = file.ReadLine();
            file.Close();

            List<string> headerIndexes = headerLine.Split(',').ToList();

            Id = headerIndexes.IndexOf("Id");
            FirstName = headerIndexes.IndexOf("FirstName");
            LastName = headerIndexes.IndexOf("LastName");
            Email = headerIndexes.IndexOf("Email");
            StreetAddress = headerIndexes.IndexOf("StreetAddress");
            City = headerIndexes.IndexOf("City");
            State = headerIndexes.IndexOf("State");
            Zip = headerIndexes.IndexOf("Zip");




        }
    }
}
