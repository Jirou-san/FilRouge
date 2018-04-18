using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilRouge.Model;
using FilRouge.Model.Entities;
using FilRouge.Service;

namespace FilRouge.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataset = new DataSetTest();
            dataset.FillAllTables();

            FilRougeDBContext db = new FilRougeDBContext();
            ServiceTest svc = new ServiceTest(new ReferencesService(db));

            //svc.Test();
            Console.ReadKey();
        }
    }
}
