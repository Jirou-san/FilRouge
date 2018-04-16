using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilRouge.Model.Entities
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    public partial class Contact : IdentityUser
    {
        
        /*public enum typeEnum
        {
            Undefined = 0,
            Admin = 1,
            Agent = 2
        }*/

        #region Proporties
        [MaxLength(20)]
        [Required]
        public string LastName { get; set; }
        [MaxLength(20)]
        [Required]
        public string FirstName { get; set; }
        //Type enum géré à travers UserRoles MVC
        //public typeEnum Type { get; set; } //0 for & 1 for agent
        #endregion
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Contact> manager, string authenticationType)
        {
            // Notez que authenticationType doit correspondre à l'instance définie dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Ajouter des revendications d’utilisateur personnalisées ici
            return userIdentity;
        }
        #region Association
        public virtual List<Quizz> Quizzs { get; set; }
        #endregion

    }
}

