using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Changedorderheaderpaymentname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymnetDueDate",
                table: "OrderHeaders",
                newName: "PaymentDueDate");

            migrationBuilder.RenameColumn(
                name: "PaymnetDate",
                table: "OrderHeaders",
                newName: "PaymentDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentDueDate",
                table: "OrderHeaders",
                newName: "PaymnetDueDate");

            migrationBuilder.RenameColumn(
                name: "PaymentDate",
                table: "OrderHeaders",
                newName: "PaymnetDate");
        }
    }
}
