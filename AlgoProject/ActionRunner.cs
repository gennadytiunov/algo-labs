using System;

namespace Otus.AlgoLabs
{
    public class ActionRunner
    {
        public void Run(Action action)
        {
            action();
        }
    }
}