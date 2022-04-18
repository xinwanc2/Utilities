using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneBookWeb.Migrations
{
    public partial class AddScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sqlFile = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"Migrations\SQLScripts", "proc_CreateContact.sql"));
            migrationBuilder.Sql(File.ReadAllText(sqlFile));

            string sqlFile1 = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"Migrations\SQLScripts", "proc_DeleteContact.sql"));
            migrationBuilder.Sql(File.ReadAllText(sqlFile1));

            string sqlFile2 = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"Migrations\SQLScripts", "proc_GetContactById.sql"));
            migrationBuilder.Sql(File.ReadAllText(sqlFile2));

            string sqlFile3 = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"Migrations\SQLScripts", "proc_GetContacts.sql"));
            migrationBuilder.Sql(File.ReadAllText(sqlFile3));

            string sqlFile4 = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"Migrations\SQLScripts", "proc_UpdateContact.sql"));
            migrationBuilder.Sql(File.ReadAllText(sqlFile4));

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
