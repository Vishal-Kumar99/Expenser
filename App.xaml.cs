using Expenser.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace Expenser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Database.Migrate();
            }
            base.OnStartup(e);
        }
    }

}
