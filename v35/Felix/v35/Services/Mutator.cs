using System;
using System.Collections.Generic;
using System.Linq;

namespace v35.Services
{
    public abstract class Mutator<T, TU>
    {
        private readonly TU _cell;
        private readonly List<Func<TU, T, TU>> _mutations = new List<Func<TU, T, TU>>();

        protected Mutator(TU cell)
        {
            _cell = cell;
        }

        public TU Mutate(T substanse)
        {
            return _mutations.Aggregate(_cell, (u, func) => func.Invoke(u, substanse));
        }

        public void AddMutation(Func<TU, T, TU> mutation)
        {
            _mutations.Add(mutation);
        }
    }
}