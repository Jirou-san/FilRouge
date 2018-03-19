using System;
using System.Collections.Generic;


namespace FilRouge.Testing
{
    public class ToolBox
    {


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
    }
}
