using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShipSwift.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        public static string ReadSqlFile(string path)
        {
            var pref = typeof(InitialCreate).Assembly.GetName().Name;
            var rPath = $"../{pref}/CustomSQL/{path}"; Console.WriteLine(rPath);
            return File.ReadAllText(rPath);
        }
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(ReadSqlFile("SqLiteDDL.sql"));
            migrationBuilder.Sql(ReadSqlFile("SqLiteDML.sql"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHIPMENT");

            migrationBuilder.DropTable(
                name: "CARRIER");

            migrationBuilder.DropTable(
                name: "SHIPMENT_RATE");

            migrationBuilder.DropTable(
                name: "SHIPPER");
        }
    }
}
