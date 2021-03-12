using System;
using System.Collections.Generic;
using System.Linq;
using Otus.AlgoLabs.Configuration;

namespace Otus.AlgoLabs.Algorithms.Lab5
{
    public class ShellGapGenerator
    {
        private readonly Algorithm _algorithm;

        private readonly long _arrayLength;

        public ShellGapGenerator(
            Algorithm algo,
            long arrayLength)
        {
            if (arrayLength <= 0)
            {
                throw new ArgumentOutOfRangeException($"'{arrayLength}' array length is not a valid value for gap genertion.");
            }

            _algorithm = algo;
            _arrayLength = arrayLength;
        }

        public long[] Generate()
        {
            switch (_algorithm)
            {
                case Algorithm.ShellSortingClassic:
                    return GenerateShellGaps();
                    
                case Algorithm.ShellSortingKnuth:
                    return GenerateKnuthGaps();

                case Algorithm.ShellSortingCiura:
                    return GenerateCiuraGaps();

                default:
                    throw new ArgumentOutOfRangeException($"'{_algorithm}' algorithm is not a valid value for gap genertion.");
            }
        }

        private long[] GenerateShellGaps()
        {
            if (_arrayLength <= 2)
            {
                return new long[] { 1 };
            }

            var gaps = new List<long>();

            var gap = _arrayLength / 2;
            while (gap > 1)
            {
                gaps.Add(gap);
                gap /= 2;
            }
            gaps.Add(1);

            return gaps.ToArray();
        }

        private long[] GenerateKnuthGaps()
        {
            if (_arrayLength <= 12)
            {
                return new long[] { 1 };
            }

            var k = (long) Math.Floor(Math.Log(2 * _arrayLength / 3 + 1, 3));
            
            var gaps = new List<long>();
            for (var i = k; i >= 1; i--)
            {
                gaps.Add((long)(Math.Pow(3, i) - 1) / 2);
            }

            return gaps.ToArray();
        }

        private long[] GenerateCiuraGaps()
        {
            var gaps = new long []  { 1750, 701, 301, 132, 57, 23, 10, 4, 1 };
            return gaps.Where(gap => gap < _arrayLength).ToArray();
        }
    }
}