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

            UsedLocations = new bool[width, height];
            
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

        public ValueTuple<int, int> GetOpenBox((int x, int y) start)
        {
           
            for (int x = start.x; x < Width; ++x)
            {
                for (int y = 0; start.y < Height; ++y)
                {
                    if (UsedLocations[x, y].Equals(false)) {
                        UsedLocations[x, y] = true;
                        return ValueTuple.Create(x, y); 
                    }

                }
            }
            //all boxes used!
            return ValueTuple.Create(-1, -1);
        }


        public ValueTuple<int,int> PlaceNonAdjacent(ValueTuple <int,int> startCoordinate, Person person)
        {
            (int x, int y) newBoxLocation;
            HashSet<Person> adjacentPeople = new HashSet<Person>();
            
            
            newBoxLocation = GetOpenBox(startCoordinate);

            GetAdjacentPeople(newBoxLocation.x, newBoxLocation.y, out adjacentPeople);

            if (newBoxLocation == (-1, -1))
            {
                return (-1,-1);
            }

            if (adjacentPeople.Contains(person))
            {
                newBoxLocation = ValidIncrementBoxLocation(newBoxLocation);
                PlaceNonAdjacent(newBoxLocation, person);

            }



            return newBoxLocation;

            
        }

        private (int x, int y) ValidIncrementBoxLocation((int x, int y) newBoxLocation)
        {
            int newX = newBoxLocation.x;
            int newY = newBoxLocation.y;

            if (newBoxLocation.x < Height-1) {
                newX += 1;
            }
            else
            {
                newX = 0;
            }

            if (newBoxLocation.y < Width-1)
            {
                newY += 1;
            }
            else
            {
                newY = 0;
            }

            return (newX, newY);
           
        }
    }
}
