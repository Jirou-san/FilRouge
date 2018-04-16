using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilRouge.Model;


namespace FilRouge.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataset = new DataSetTest();
            dataset.FillAllTables();
        }
    }
}
