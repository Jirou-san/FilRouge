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
            Assert.IsNotNull(questionHandler.NewQuestion());
            //Bug bizzare

            Assert.IsInstanceOfType(questionHandler.NewQuestion(), typeof(int));

            //Assert.AreSame(questionHandler.NewQuestion(), typeof());

        }
    }
}
