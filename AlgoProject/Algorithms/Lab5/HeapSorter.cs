namespace Otus.AlgoLabs.Algorithms.Lab5
{
    public class HeapSorter
    {
        private readonly int[] _array;
        private readonly long _arrayLength;

        public HeapSorter(int[] array)
        {
            _array = array;
            _arrayLength = array.Length;
        }

        public int[] Sort()
        {
            InitializeHeap();

            for (var i = _arrayLength - 1; i >= 0; i--)
            {
                Swap(0, i);
                Heapify(0, i);
            }

            return _array;
        }

        private void Swap(long index1, long index2)
        {
            var x = _array[index1];
            _array[index1] = _array[index2];
            _array[index2] = x;
        }

        private void InitializeHeap()
        {
            var lastParentIndex = _arrayLength / 2 - 1;
            for (var parent = lastParentIndex; parent >= 0; parent--)
            {
                Heapify(parent, _arrayLength);
            }
        }
        
        private void Heapify(long parentIndex, long size)
        {
            var leftChildIndex = 2 * parentIndex + 1;
            var rightChildIndex = leftChildIndex + 1;

            var maxElementIndex = parentIndex;
            if (leftChildIndex < size && _array[leftChildIndex] > _array[maxElementIndex])
            {
                maxElementIndex = leftChildIndex;
            }
            if (rightChildIndex < size && _array[rightChildIndex] > _array[maxElementIndex])
            {
                maxElementIndex = rightChildIndex;
            }

            if (maxElementIndex == parentIndex)
            {
                return;
            }

            Swap(maxElementIndex, parentIndex);
            Heapify(maxElementIndex, size);
        }
    }
}