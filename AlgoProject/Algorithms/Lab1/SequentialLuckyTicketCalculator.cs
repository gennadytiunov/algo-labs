using System;

namespace Otus.AlgoLabs.Algorithms.Lab1
{
    public class SequentialLuckyTicketCalculator
    {
        private readonly int _n;

        public SequentialLuckyTicketCalculator(int ticketLength)
        {
            _n = ticketLength / 2;
        }

        public long CalculateTicketCount()
        {
            var count = 1L; // сразу учитываем нулевой билет

            var ticketDigits = 2 * _n; // длина билета

            var halfTicketMaxNumber = (int)Math.Pow(10, _n) - 1;
            var maxTicketNumber = (int)Math.Pow(10, ticketDigits) - 1;

            // перебираем билеты
            // лёгка оптимизация - начинаем не с нулевого, а с первого ненулевого в левой части - 0100 (при n = 2), 001000 (при n = 3), etc.
            for (var i = halfTicketMaxNumber + 1; i <= maxTicketNumber; i++)
            {
                var sumLeft = 0;
                var sumRight = 0;

                // суммируем цифры в левой и правой частях билеты
                // конкретную цифру получаем остатком от деления на 10
                var currentNumber = i;
                for (var j = ticketDigits;
                    j >= 1 && currentNumber > 0;
                    j--)
                {
                    var digit = currentNumber % 10;

                    if (j > _n)
                    {
                        sumRight += digit;
                    }

                    if (j <= _n)
                    {
                        sumLeft += digit;
                    }

                    currentNumber = (int)Math.Floor((decimal)currentNumber / 10);
                }

                // увеличиваем счётчик, если билет счастливый
                count += sumLeft == sumRight ? 1 : 0;
            }

            return count;
        }
    }
}
