namespace Otus.AlgoLabs.Algorithms.Lab1
{
    public class CombinatorialLuckyTicketCalculator
    {
        private readonly int _n;
        private readonly long[,] _sumCombinations;

        public CombinatorialLuckyTicketCalculator(int ticketLength)
        {
            _n = ticketLength / 2; 
            _sumCombinations = new long[9 * _n + 1, _n]; // таблица с количествами возможных комбинаций для сумм цифр
        }

        public long CalculateTicketCount()
        {
            FillInitialCombinations(); // заполняем единицами количества комбинаций для n = 1

            for (var i = 9 * _n; i >= 0; i--) // начинаем подсчёт количеств комбинаций с самого правого столбца 
            {
                CalculateSumCombinations(i, _n - 1);
            }

            return SumCombinations(); // суммируем квадраты количеств комбинаций (для подсчёта суммарного количества комбинаций с учётом обеих частей билета)
        }

        private void FillInitialCombinations()
        {
            for (var i = 0; i <= 9; i++)
            {
                _sumCombinations[i, 0] = 1;
            }
        }

        // Подсчёт количеста комбинаций цифр для суммы в конкретной ячейке таблицы
        private void CalculateSumCombinations(int k, int n)
        {
            var currentSumCombinations = 0L;
            
            if (n >= 1) // игнорируем самый первый / левый столбец таблицы (с 0-м индексом, так как он уже заполнен изначально)
            {
                for (var i = k; i > k - 10 && i >= 0; i--)
                {
                    CalculateSumCombinations(i, n - 1); // заполняем 10 предыдущих ячеек в предыдущем столбце

                    currentSumCombinations += _sumCombinations[i, n - 1];
                }
                
                _sumCombinations[k, n] = currentSumCombinations; // вносим рассчитанную сумму в ячейку
            }
        }

        // Рассчёт количества билетов - то есть количества комбинаций для обеих частей билета (предварительно рассчитанных для одной части билета)
        private long SumCombinations()
        {
            var sum = 0L;

            for (var i = 0; i <= 9 * _n; i++)
            {
                sum += _sumCombinations[i, _n - 1] * _sumCombinations[i, _n - 1];
            }

            return sum;
        }
    }
}
