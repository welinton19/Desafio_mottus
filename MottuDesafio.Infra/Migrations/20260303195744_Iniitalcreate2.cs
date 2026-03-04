using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MottuDesafio.InfraData.Migrations
{
    /// <inheritdoc />
    public partial class Iniitalcreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lease_DeliveryMen_deliveryMenId",
                table: "Lease");

            migrationBuilder.DropForeignKey(
                name: "FK_Lease_Motorcycle_motorcycleId",
                table: "Lease");

            migrationBuilder.RenameColumn(
                name: "motorcycleId",
                table: "Lease",
                newName: "MotorcycleId");

            migrationBuilder.RenameColumn(
                name: "deliveryMenId",
                table: "Lease",
                newName: "DeliveryMenId");

            migrationBuilder.RenameIndex(
                name: "IX_Lease_motorcycleId",
                table: "Lease",
                newName: "IX_Lease_MotorcycleId");

            migrationBuilder.RenameIndex(
                name: "IX_Lease_deliveryMenId",
                table: "Lease",
                newName: "IX_Lease_DeliveryMenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lease_DeliveryMen_DeliveryMenId",
                table: "Lease",
                column: "DeliveryMenId",
                principalTable: "DeliveryMen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lease_Motorcycle_MotorcycleId",
                table: "Lease",
                column: "MotorcycleId",
                principalTable: "Motorcycle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lease_DeliveryMen_DeliveryMenId",
                table: "Lease");

            migrationBuilder.DropForeignKey(
                name: "FK_Lease_Motorcycle_MotorcycleId",
                table: "Lease");

            migrationBuilder.RenameColumn(
                name: "MotorcycleId",
                table: "Lease",
                newName: "motorcycleId");

            migrationBuilder.RenameColumn(
                name: "DeliveryMenId",
                table: "Lease",
                newName: "deliveryMenId");

            migrationBuilder.RenameIndex(
                name: "IX_Lease_MotorcycleId",
                table: "Lease",
                newName: "IX_Lease_motorcycleId");

            migrationBuilder.RenameIndex(
                name: "IX_Lease_DeliveryMenId",
                table: "Lease",
                newName: "IX_Lease_deliveryMenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lease_DeliveryMen_deliveryMenId",
                table: "Lease",
                column: "deliveryMenId",
                principalTable: "DeliveryMen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lease_Motorcycle_motorcycleId",
                table: "Lease",
                column: "motorcycleId",
                principalTable: "Motorcycle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
