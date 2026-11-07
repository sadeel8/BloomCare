using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloomCare.Migrations
{
    /// <inheritdoc />
    public partial class AddDeviceUniqueIdToSensorReading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Humidity",
                table: "SensorReadings");

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
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "LightLevel",
                table: "SensorReadings",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "DeviceUniqueId",
                table: "SensorReadings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceUniqueId",
                table: "SensorReadings");

            migrationBuilder.AlterColumn<float>(
                name: "Temperature",
                table: "SensorReadings",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "SoilMoisture",
                table: "SensorReadings",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "LightLevel",
                table: "SensorReadings",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<float>(
                name: "Humidity",
                table: "SensorReadings",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
