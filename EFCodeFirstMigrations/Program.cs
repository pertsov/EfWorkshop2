namespace EFCodeFirstMigrations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // install packages
            //  Microsoft.EntityFrameworkCore 8.0.3
            //  Microsoft.EntityFrameworkCore.SqlServer 8.0.3
            //  Microsoft.EntityFrameworkCore.Tools 8.0.3

            // install the dotnet EF CLI toolset: dotnet tool install --global dotnet-ef --version 8.0.3

            // manage migrations
            //  dotnet ef migrations add InitialCreate
            //  dotnet ef migrations list
            //  dotnet ef migrations script > migration_scripts.txt
            //  dotnet ef migrations script InitialCreate > migration_scripts_initial.txt
            //  dotnet ef migrations script --idempotent > migration_scripts_idempotent.txt
            //  dotnet ef migrations remove

            // apply migrations
            //  dotnet ef database update
            //  dotnet ef database update 0
            //  dotnet ef database update InitialCreate

            // Documentation
            //  Managing Migrations: https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli
            //  Applying Migrations: https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli


            // Code snippet to populate Departments table via migrations

            //protected override void Up(MigrationBuilder migrationBuilder)
            //{
            //    migrationBuilder.InsertData(
            //        table: "Departments",
            //        columns: new[] { "DepartmentId", "Name", "Description" },
            //        values: new[] { "1", "Sales", "Sales department" });

            //    migrationBuilder.InsertData(
            //        table: "Departments",
            //        columns: new[] { "DepartmentId", "Name", "Description" },
            //        values: new[] { "2", "Logistics", "Logistics department" });

            //    migrationBuilder.InsertData(
            //        table: "Departments",
            //        columns: new[] { "DepartmentId", "Name", "Description" },
            //        values: new[] { "3", "Warehouse", "Warehouse department" });
            //}

            //protected override void Down(MigrationBuilder migrationBuilder)
            //{
            //    migrationBuilder.DeleteData(
            //        table: "Departments",
            //        keyColumn: "DepartmentId",
            //        keyValue: 1);

            //    migrationBuilder.DeleteData(
            //        table: "Departments",
            //        keyColumn: "DepartmentId",
            //        keyValue: 2);

            //    migrationBuilder.DeleteData(
            //        table: "Departments",
            //        keyColumn: "DepartmentId",
            //        keyValue: 3);

            //    // migrationBuilder.Sql("DELETE FROM Departments", true);
            //}
        }
    }
}