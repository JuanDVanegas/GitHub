using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GigHub.Core.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public ICollection<Following> Followees { get; set; }
        public ICollection<Following> Followers { get; set; }
        public ICollection<UserNotification> UserNotifications { get; set; }

        public ApplicationUser()
        {
            Followees = new Collection<Following>();
            Followers = new Collection<Following>();
            UserNotifications = new Collection<UserNotification>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }

        public void Notify(Notification notification)
        {
            UserNotifications.Add(new UserNotification(this, notification));
        }
    }
}