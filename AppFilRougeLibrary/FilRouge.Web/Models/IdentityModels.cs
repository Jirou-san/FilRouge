using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using FilRouge.Model.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FilRouge.Web.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser. Pour en savoir plus, consultez https://go.microsoft.com/fwlink/?LinkID=317594.


    public class ApplicationDbContext : IdentityDbContext<Contact>
    {
        public ApplicationDbContext()
            : base("name=ConnexionStringFilRouge", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}