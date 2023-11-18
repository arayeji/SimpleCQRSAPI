using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace FlightBookingAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    name = table.Column<string>(type: "longtext", nullable: true),
                    iata = table.Column<string>(type: "longtext", nullable: true),
                    icao = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    airport_name = table.Column<string>(type: "longtext", nullable: false),
                    iata_code = table.Column<string>(type: "longtext", nullable: false),
                    icao_code = table.Column<string>(type: "longtext", nullable: false),
                    latitude = table.Column<string>(type: "longtext", nullable: true),
                    longitude = table.Column<string>(type: "longtext", nullable: true),
                    geoname_id = table.Column<string>(type: "longtext", nullable: true),
                    timezone = table.Column<string>(type: "longtext", nullable: true),
                    gmt = table.Column<string>(type: "longtext", nullable: true),
                    phone_number = table.Column<string>(type: "longtext", nullable: true),
                    country_name = table.Column<string>(type: "longtext", nullable: true),
                    country_iso2 = table.Column<string>(type: "longtext", nullable: true),
                    city_iata_code = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Arrivals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    airport = table.Column<string>(type: "longtext", nullable: true),
                    timezone = table.Column<string>(type: "longtext", nullable: true),
                    iata = table.Column<string>(type: "longtext", nullable: true),
                    icao = table.Column<string>(type: "longtext", nullable: true),
                    terminal = table.Column<string>(type: "longtext", nullable: true),
                    gate = table.Column<string>(type: "longtext", nullable: true),
                    baggage = table.Column<string>(type: "longtext", nullable: true),
                    delay = table.Column<int>(type: "int", nullable: true),
                    scheduled = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    estimated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    actual = table.Column<string>(type: "longtext", nullable: true),
                    estimated_runway = table.Column<string>(type: "longtext", nullable: true),
                    actual_runway = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrivals", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CodeShareds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    airline_name = table.Column<string>(type: "longtext", nullable: false),
                    airline_iata = table.Column<string>(type: "longtext", nullable: false),
                    airline_icao = table.Column<string>(type: "longtext", nullable: false),
                    flight_number = table.Column<string>(type: "longtext", nullable: false),
                    flight_iata = table.Column<string>(type: "longtext", nullable: false),
                    flight_icao = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeShareds", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Departures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    airport = table.Column<string>(type: "longtext", nullable: true),
                    timezone = table.Column<string>(type: "longtext", nullable: true),
                    iata = table.Column<string>(type: "longtext", nullable: true),
                    icao = table.Column<string>(type: "longtext", nullable: true),
                    terminal = table.Column<string>(type: "longtext", nullable: true),
                    gate = table.Column<string>(type: "longtext", nullable: true),
                    delay = table.Column<int>(type: "int", nullable: true),
                    scheduled = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    estimated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    actual = table.Column<string>(type: "longtext", nullable: true),
                    estimated_runway = table.Column<string>(type: "longtext", nullable: true),
                    actual_runway = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departures", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    number = table.Column<string>(type: "longtext", nullable: true),
                    iata = table.Column<string>(type: "longtext", nullable: true),
                    icao = table.Column<string>(type: "longtext", nullable: true),
                    CodeSharedId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_CodeShareds_CodeSharedId",
                        column: x => x.CodeSharedId,
                        principalTable: "CodeShareds",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FlightDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    flight_date = table.Column<string>(type: "longtext", nullable: true),
                    flight_status = table.Column<string>(type: "longtext", nullable: true),
                    aircraft = table.Column<string>(type: "longtext", nullable: true),
                    live = table.Column<string>(type: "longtext", nullable: true),
                    AirlineId = table.Column<Guid>(type: "char(36)", nullable: true),
                    ArrivalId = table.Column<Guid>(type: "char(36)", nullable: true),
                    DepartureId = table.Column<Guid>(type: "char(36)", nullable: true),
                    FlightId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightDetails_Airlines_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "Airlines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FlightDetails_Arrivals_ArrivalId",
                        column: x => x.ArrivalId,
                        principalTable: "Arrivals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FlightDetails_Departures_DepartureId",
                        column: x => x.DepartureId,
                        principalTable: "Departures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FlightDetails_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FlightDetails_AirlineId",
                table: "FlightDetails",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightDetails_ArrivalId",
                table: "FlightDetails",
                column: "ArrivalId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightDetails_DepartureId",
                table: "FlightDetails",
                column: "DepartureId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightDetails_FlightId",
                table: "FlightDetails",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_CodeSharedId",
                table: "Flights",
                column: "CodeSharedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "FlightDetails");

            migrationBuilder.DropTable(
                name: "Airlines");

            migrationBuilder.DropTable(
                name: "Arrivals");

            migrationBuilder.DropTable(
                name: "Departures");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "CodeShareds");
        }
    }
}
