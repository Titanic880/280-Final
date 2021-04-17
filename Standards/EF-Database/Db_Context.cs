using Microsoft.EntityFrameworkCore;
using Standards.User;

namespace Standards.EF_Database
{
    public class Db_Context : DbContext
    {
        /// <summary>
        /// Collection of user accounts
        /// </summary>
        public DbSet<User_Data> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("server=localhost,1433;database=280Final;user id=SA;password=SchoolCont");
        }
    }
}
