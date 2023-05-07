using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb_4_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonHobbies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    HobbyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonHobbies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonHobbies_Hobbies_HobbyId",
                        column: x => x.HobbyId,
                        principalTable: "Hobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonHobbies_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PersonHobbyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_PersonHobbies_PersonHobbyId",
                        column: x => x.PersonHobbyId,
                        principalTable: "PersonHobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Konsten att ta bilder med en kamera", "Fotografering" },
                    { 2, "Att skapa kulinariska mästerverk i köket", "Matlagning" },
                    { 3, "Odlar växter och blommor utomhus", "Trädgårdsarbete" },
                    { 4, "Ett spel som spelas på ett bord med kulor och köer", "Biljard" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Anna Svensson", "070-1234567" },
                    { 2, "Karl Nilsson", "072-9876543" },
                    { 3, "Emma Johansson", "073-4567890" },
                    { 4, "Erik Andersson", "071-6543210" },
                    { 5, "Sofia Gustafsson", "075-9876123" }
                });

            migrationBuilder.InsertData(
                table: "PersonHobbies",
                columns: new[] { "Id", "HobbyId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 1, 3 },
                    { 4, 3, 3 },
                    { 5, 4, 4 },
                    { 6, 2, 5 },
                    { 7, 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "PersonHobbyId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQcRmT6uWEdqwp8Rb7_ovgPvSxF--xYUzle3w&usqp=CAU" },
                    { 2, 2, "https://t4.ftcdn.net/jpg/03/32/75/39/360_F_332753934_tBacXEgxnVplFBRyKbCif49jh0Wz89ns.jpg" },
                    { 3, 5, "https://i.guim.co.uk/img/media/ef96c1f2495b60ec83379962d4aec38bfb1ce039/0_187_5600_3363/master/5600.jpg?width=1200&height=900&quality=85&auto=format&fit=crop&s=a96e7cb435ac3a89558b8315d39c068d" },
                    { 4, 6, "https://lirp.cdn-website.com/5152f937/dms3rep/multi/opt/GettyImages-582313494-553w.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonHobbyId",
                table: "Links",
                column: "PersonHobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonHobbies_HobbyId",
                table: "PersonHobbies",
                column: "HobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonHobbies_PersonId",
                table: "PersonHobbies",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "PersonHobbies");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
