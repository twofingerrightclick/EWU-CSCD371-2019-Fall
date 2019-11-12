using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T> : ICollection<T> where T : IEquatable<T>
    {
        public int Capacity { get; private set; }

        private List<T> _Array;

        public Array(int capacity)
        {
            Capacity = capacity;
            _Array = new List<T>();
        }

        public int Count { get; private set; } = 0;

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            if (Count >= Capacity)
            {
                throw new IndexOutOfRangeException("Array is Full");
            }
            if (item ==null)
            {
                throw new ArgumentNullException(nameof(item), "Cannot Add Null Item Reference");
            }

            _Array.Add(item);



        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            if (Count >= Capacity)
            {
                throw new InvalidOperationException($"{nameof(item)} was not found");

            }

            if (_Array.Contains(item)) {
                return true;
            }

            throw new InvalidOperationException($"{nameof(item)} was not found");

        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
