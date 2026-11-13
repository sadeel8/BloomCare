using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloomCare.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBloomCareSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LightLevel",
                table: "SensorReadings");

            migrationBuilder.DropColumn(
                name: "PlantName",
                table: "Devices");

            migrationBuilder.AlterColumn<float>(
                name: "Temperature",
                table: "SensorReadings",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "SoilMoisture",
                table: "SensorReadings",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<float>(
                name: "Humidity",
                table: "SensorReadings",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "PlantId",
                table: "SensorReadings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentPlantId",
                table: "Devices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SensorReadings_PlantId",
                table: "SensorReadings",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_CurrentPlantId",
                table: "Devices",
                column: "CurrentPlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Plants_CurrentPlantId",
                table: "Devices",
                column: "CurrentPlantId",
                principalTable: "Plants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SensorReadings_Plants_PlantId",
                table: "SensorReadings",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Plants_CurrentPlantId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_SensorReadings_Plants_PlantId",
                table: "SensorReadings");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_SensorReadings_PlantId",
                table: "SensorReadings");

            migrationBuilder.DropIndex(
                name: "IX_Devices_CurrentPlantId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Humidity",
                table: "SensorReadings");

            migrationBuilder.DropColumn(
                name: "PlantId",
                table: "SensorReadings");

            migrationBuilder.DropColumn(
                name: "CurrentPlantId",
                table: "Devices");

            migrationBuilder.AlterColumn<double>(
                name: "Temperature",
                table: "SensorReadings",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "SoilMoisture",
                table: "SensorReadings",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<double>(
                name: "LightLevel",
                table: "SensorReadings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "PlantName",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
