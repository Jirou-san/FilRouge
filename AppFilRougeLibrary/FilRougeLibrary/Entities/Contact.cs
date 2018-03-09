using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.Library
{
    #region Exceptions
    public class ContactExeptionOverQuestions:Exception
    {
        public ContactExeptionOverQuestions(string message) :base(message)
            {
            }
    }
    public class ContactExeptionCantAdd:Exception
    {
        public ContactExeptionCantAdd(string message) :base(message)
            {
            }
    }
    public class ContactExeptionWrongTechno:Exception
    {
        public ContactExeptionWrongTechno(string message) :base(message)
            {
            }
    }
    public class ContactExeptionWrongDifficulty:Exception
    {
        public ContactExeptionWrongDifficulty(string message) :base(message)
            {
            }
    }
    #endregion
    public class Contact
    {
        #region Proporties
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        #endregion
        #region Association
        #endregion

    }
}

