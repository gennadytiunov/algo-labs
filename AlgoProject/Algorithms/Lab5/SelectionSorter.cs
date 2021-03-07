namespace Otus.AlgoLabs.Algorithms.Lab5
{
    public class SelectionSorter
    {
        private readonly int[] _array;
        private readonly long _arrayLength;

        public SelectionSorter(int[] array)
        {
            _array = array;
            _arrayLength = array.Length;
        }

        public int[] Sort()
        {
            for (var i = 0; i < _arrayLength - 1; i++)
            {
                var minValue = _array[i];
                var minValueIndex = i;

                for (var j = i + 1; j <= _arrayLength - 1; j++)
                {
                    if (_array[j] < minValue)
                    {
                        minValue = _array[j];
                        minValueIndex = j;
                    }
                }

                var x = _array[i];
                _array[i] = minValue;
                _array[minValueIndex] = x;
            }

            return _array;
        }
    }
}