using FilRouge.Model.Entities;
using FilRouge.Model.Interfaces;
using FilRouge.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.Tests
{
    class ServiceTest
    {
        public ReferencesService _service;

        public ServiceTest (ReferencesService service)
        {
            _service = service;
        }

        public void Test()
        {
            List<Difficulty> difficulties = _service.GetAllDifficuties();
            difficulties.ForEach(o => Console.WriteLine(o.Id+" "+o.Name));
        }

    }
}
