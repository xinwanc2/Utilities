using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneBookWeb.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_contact",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    f_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    f_phone_no = table.Column<string>(type: "varchar(11)", nullable: false),
                    f_address = table.Column<string>(type: "varchar(50)", nullable: false),
                    f_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_contact", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_contact");
        }
    }
}
