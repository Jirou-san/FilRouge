using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilRouge.Model.Entities;
using System.Collections.Generic;

namespace FilRouge.UnitTests.Services.QuestionTests
{
    /// <summary>
    /// Classe d'instanciation d'objets propre aux questions
    /// </summary>
    [TestClass]
    public class GetQuestion
    {
        //TODO: Les autres tests
        
        [TestMethod]
        public void TestGetQuestion()
        {
            

            var questionHandler = new QuestionReference();
            var reference = TestReference.QuestionResponseService();
            Assert.IsNotNull(questionHandler.NewQuestion());
            //Bug bizzare
            Assert.AreSame(questionHandler.NewQuestion(), typeof(int));

        }
    }
}
