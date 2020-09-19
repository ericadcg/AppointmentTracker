using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentTracker.Migrations
{
    public partial class CreateAppointment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ClientId",
                table: "Appointment",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Client_ClientId",
                table: "Appointment",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Client_ClientId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_ClientId",
                table: "Appointment");
        }
    }
}
