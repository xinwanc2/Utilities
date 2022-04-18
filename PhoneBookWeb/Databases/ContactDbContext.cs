using Microsoft.EntityFrameworkCore;
using PhoneBookWeb.Databases.Contacts;

namespace PhoneBookWeb.Databases
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        { }

        public DbSet<Contact> Contacts { get; set; }
    }
}
