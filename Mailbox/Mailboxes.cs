using System;
using System.Collections.Generic;

namespace Mailbox
{
    public class Mailboxes : List<Mailbox>
    {
        public Mailboxes(IEnumerable<Mailbox> collection, int width, int height) 
            : base(collection)
        { 
            if (width < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width));
            }
            if (height < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height));
            }
            Width = width;
            Height = height;

            UsedLocations = new bool[height, width];

            
        }

        public int Width { get; }
        public int Height { get; }

        public bool[,] UsedLocations { get; private set; }

        public bool GetAdjacentPeople(int x, int y, out HashSet<Person> adjacentPeople)
        {
            adjacentPeople = new HashSet<Person>();
            bool isOccupied = false;

            foreach(Mailbox mailbox in this)
            {
                //current
                if (mailbox.Location == (x, y))
                {
                    isOccupied = true;
                }
                //above
                if (mailbox.Location == (x, y - 1))
                {
                    adjacentPeople.Add(mailbox.Owner);
                    
                }
                //right
                if (mailbox.Location == (x + 1, y))
                {
                    adjacentPeople.Add(mailbox.Owner);

                }
                //bottom
                if (mailbox.Location == (x, y + 1))
                {
                    adjacentPeople.Add(mailbox.Owner);
                }
                //left
                if (mailbox.Location == (x - 1, y))
                {
                    adjacentPeople.Add(mailbox.Owner);
                }
            }

            return isOccupied;
        }

        public ValueTuple<int, int> GetOpenBox( Person person)
        {

            List<(int x, int y)> unusedLocations = GetOpenBoxes();

            HashSet<Person> adjacentPeople = new HashSet<Person>();

            foreach ((int x, int y) openBox in unusedLocations) {
                GetAdjacentPeople(openBox.x, openBox.y, out adjacentPeople);
                if (!adjacentPeople.Contains(person))
                {
                    return (openBox.x, openBox.y);

                }
            }

            //all boxes used!
            return ValueTuple.Create(-1, -1);
        }

        //public void Add(Mailbox box)
        //{
            
        //    UsedLocations[box.Location.X, box.Location.Y] = true;
            
        //}


        public List<(int x, int y)> GetOpenBoxes() {

            List<(int x, int y)> unusedLocations = new List<(int x, int y)>();

            for (int x = 0; x < Height; x++) {
                for (int y = 0; y < Width; y++)
                {
                    if (UsedLocations[x, y] != true) {
                        unusedLocations.Add((x, y));
                    }
                }
            }

            return unusedLocations;
        } 
        
    }
}
