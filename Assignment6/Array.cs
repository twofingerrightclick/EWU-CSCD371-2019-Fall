using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T> : ICollection<T>, IEnumerable<T> where T : IEquatable<T>
    {
        public int Capacity { get; private set; }

        private List<T> _Array;

        public Array(int capacity)
        {
            if (capacity<=0)
            {
                throw new IndexOutOfRangeException($"{nameof(capacity)} must be greater than 0");
            }
            Capacity = capacity;
            _Array = new List<T>();
        }

        public Array()
        {
            _Array = new List<T>();
        }

        public int Count { get; private set; } = 0;

        public bool IsReadOnly => throw new NotImplementedException();

      

        //object IEnumerator.Current => throw new NotImplementedException();

        public void Add(T item)
        {
            if (Count >= Capacity&& Capacity!=0)
            {
                throw new IndexOutOfRangeException("Array is Full");
            }
            if (item ==null)
            {
                throw new ArgumentNullException(nameof(item), "Cannot Add Null Item Reference");
            }

            Count++;
            _Array.Add(item);



        }

        public void Clear()
        {
            _Array = new List<T>();
            Count = 0;
            
        }

        public bool Contains(T item)
        {
            if (Count > Capacity)
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
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length - arrayIndex <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(arrayIndex)}: { arrayIndex}");
            }

            if ((array.Length - arrayIndex) < Capacity)
            {
                throw new ArgumentOutOfRangeException($"more items in collection than { nameof(array)} can fit from index: {nameof(arrayIndex)} = { arrayIndex}");
            }

            
            
            for (int i=arrayIndex; i < Capacity; i++)
            {
                array[i] = _Array[i];
            }
        }

        
        
        
      

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Array()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion


        public IEnumerator<T> GetEnumerator()
        {
            return new ArrayEnumerator(_Array);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class ArrayEnumerator : IEnumerator<T>
        {
            private List<T> _Array;
            int _Index = -1;


            public ArrayEnumerator(List<T> array)
            {
                _Array = array;
            }

            public T Current
            {
                get
                {
                    try
                    {
                        return _Array[_Index];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
                //this enumertor doesn't need to be disposed
            }

            public bool MoveNext()
            {
                _Index++;
                return (_Index < _Array.Count);
            }

            public void Reset()
            {
                _Index = -1;
            }
        }
    }
}
