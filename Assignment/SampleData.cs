using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{


    public class SampleData : ISampleData
    {

        public string PeopleFilePath { get; set; } = "People.csv";


        public HeaderIndexes HeaderIndexes { get; private set; }

        public SampleData(string filePath)
        {
            PeopleFilePath = filePath;
            HeaderIndexes = new HeaderIndexes(filePath);
        }

        public SampleData()
        {
            HeaderIndexes = new HeaderIndexes(PeopleFilePath);
        }

        // 1.
        public IEnumerable<string> CsvRows
        {
            get
            {
                IEnumerable<string> lines = File.ReadAllLines(PeopleFilePath).Where(item =>
                {
                    return !string.IsNullOrWhiteSpace(item);
                }).Skip(1); //skip first line (the header)

                return lines;
            }
        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            IEnumerable<string> distinctStates = CsvRows.Select(item =>
            {
                return item.Split(',')[HeaderIndexes.State];


            }).Distinct().OrderBy(item => item);

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

                        FirstName = columns[HeaderIndexes.FirstName],
                        LastName = columns[HeaderIndexes.LastName],
                        EmailAddress = columns[HeaderIndexes.Email],

                        Address = new Address
                        {
                            StreetAddress = columns[HeaderIndexes.StreetAddress],
                            City = columns[HeaderIndexes.City],
                            State = columns[HeaderIndexes.State],
                            Zip = columns[HeaderIndexes.Zip],
                        }
                    };
                }).OrderBy(item => item.LastName);

                return peopleQuery;
            }

        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) {

            var result = People.Where(item => filter(item.EmailAddress)).Select(item => (item.FirstName,item.LastName));

            return result;
        
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people)
        {

            IEnumerable<string> distinctStateQuery = people.Select(item => item.Address.State).Distinct().OrderBy(item=>item);
            //okay to use this aggregate override as the first item should always be included
            string result = distinctStateQuery.Aggregate((states, nextState) => states + ($",{nextState}"));

            return result;
        }

        public IEnumerable<IPerson> GroupByState()
        {

            IEnumerable<IPerson> people = People;



            IEnumerable<IGrouping<string, IPerson>> query =
                from person in people orderby person.Address.State
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
