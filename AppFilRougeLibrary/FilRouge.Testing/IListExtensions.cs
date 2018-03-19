using System;
using System.Collections.Generic;


namespace FilRouge.Testing
{
    public class IListExtensions
    {
        public IListExtensions()
        {
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Shuffles the element order of the specified list.
        /// </summary>
        public void Shuffle<T>(IList<T> ts)
        {
            Random rng = new Random();
            var count = ts.Count;
            var last = count - 1;
            for (var i = 0; i < last; ++i)
            {
                var r = rng.Next(i, count);
                var tmp = ts[i];
                ts[i] = ts[r];
                ts[r] = tmp;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
