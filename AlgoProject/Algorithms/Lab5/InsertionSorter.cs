namespace Otus.AlgoLabs.Algorithms.Lab5
{
    public class InsertionSorter
    {
        private readonly int[] _array;
        private readonly long _arrayLength;

        public InsertionSorter(int[] array)
        {
            _array = array;
            _arrayLength = array.Length;
        }

        public int[] Sort()
        {
            if (_arrayLength <= 1)
            {
                return _array;
            }
            
            for (long i = 1; i < _arrayLength; i++)
            {
                var x = _array[i];

                var j = i;

                while (j > 0 && _array[j - 1] > x)
                {
                    _array[j] = _array[j - 1];

                    j = j - 1;
                }

                _array[j] = x;
            }

            return _array;
        }
    }
}