namespace Otus.AlgoLabs.Algorithms.Lab5
{
    public class ShellSorter
    {
        private readonly int[] _array;
        private readonly long _arrayLength;
        private long[] _gaps;

        public ShellSorter(int[] array, long[] gaps)
        {
            _array = array;
            _arrayLength = array.Length;
            _gaps = gaps;
        }

        public int[] Sort()
        {
            foreach (var gap in _gaps)
            {
                for (var i = gap; i < _arrayLength; i += 1)
                {
                    var x = _array[i];

                    var j = i;
                    while (j >= gap && _array[j - gap] > x)
                    {
                        _array[j] = _array[j - gap];
                        j -= gap;
                    }
                    _array[j] = x;
                }
            }
            
            return _array;
        }
    }
}