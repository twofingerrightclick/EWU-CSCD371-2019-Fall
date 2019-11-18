


using System;

namespace Sorter
{
    public class SortUtility
    {

        public delegate bool SortByDelegate(int i, int j);

        public SortByDelegate SortBy { get; set; }

        public SortUtility(SortByDelegate sortBy)
        {
            SortBy = sortBy;
        }
        // Sort method should be implemented here
        // It should accept an int[] and a delegate you define that performs the actual comparison

        /* low  --> Starting index,  high  --> Ending index */

        public void Sort(int[] arr)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }

            QuickSort(arr, 0, arr.Length - 1);
        }


            private void QuickSort(int[] arr, int low, int high)
        {
            
            if (low < high)
            {
                /* pi is partitioning index, arr[pi] is now
                   at right place */
                int pivotIndex = Partition(arr, low, high);

                QuickSort(arr, low, pivotIndex - 1);  // Before pi
                QuickSort(arr, pivotIndex + 1, high); // After pi
            }

        }


        private int Partition(int[] arr, int low, int high)
        {
            // pivot (Element to be placed at right position)
            int pivot = arr[high];

            int i = (low - 1);  // Index of smaller element

            for (int j = low; j <= high - 1; j++)
            {
                // If current element is smaller than the pivot
                if (SortBy(arr[j] , pivot))
                {
                    i++;    // increment index of smaller element
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, high);

            return (i + 1);
        }

        private void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

       
    }
}
