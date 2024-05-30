using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backendGameHub.Migrations
{
    /// <inheritdoc />
    public partial class CreacionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    protegido = table.Column<bool>(type: "boolean", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    categoriaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre_categoria = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.categoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Disponibilidad",
                columns: table => new
                {
                    disponibilidadId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre_disponibilidad = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disponibilidad", x => x.disponibilidadId);
                });

            migrationBuilder.CreateTable(
                name: "Estatus",
                columns: table => new
                {
                    estatusId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre_estatus = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estatus", x => x.estatusId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    equipoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    url_imagen = table.Column<string>(type: "text", nullable: false),
                    modelo = table.Column<string>(type: "text", nullable: false),
                    marca = table.Column<string>(type: "text", nullable: false),
                    disponibilidadId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.equipoId);
                    table.ForeignKey(
                        name: "FK_Equipos_Disponibilidad_disponibilidadId",
                        column: x => x.disponibilidadId,
                        principalTable: "Disponibilidad",
                        principalColumn: "disponibilidadId");
                });

            migrationBuilder.CreateTable(
                name: "Juegos",
                columns: table => new
                {
                    juegoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre_juego = table.Column<string>(type: "text", nullable: false),
                    plataforma = table.Column<string>(type: "text", nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false),
                    url_imagen = table.Column<string>(type: "text", nullable: false),
                    estatusId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juegos", x => x.juegoId);
                    table.ForeignKey(
                        name: "FK_Juegos_Estatus_estatusId",
                        column: x => x.estatusId,
                        principalTable: "Estatus",
                        principalColumn: "estatusId");
                });

            migrationBuilder.CreateTable(
                name: "CategoriaJuego",
                columns: table => new
                {
                    categoriascategoriaId = table.Column<int>(type: "integer", nullable: false),
                    juegosjuegoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaJuego", x => new { x.categoriascategoriaId, x.juegosjuegoId });
                    table.ForeignKey(
                        name: "FK_CategoriaJuego_Categorias_categoriascategoriaId",
                        column: x => x.categoriascategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "categoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaJuego_Juegos_juegosjuegoId",
                        column: x => x.juegosjuegoId,
                        principalTable: "Juegos",
                        principalColumn: "juegoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a3f9656-b7a3-4d56-bbf3-910c26e0eb92", null, "Recepcionista", "RECEPCIONISTA" },
                    { "ef404a9f-8efb-4de9-9b4f-05705d604bac", null, "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "nombre", "protegido" },
                values: new object[,]
                {
                    { "4ecf76a1-704f-46f5-9d58-2ba8ad601845", 0, "aa72f48f-7179-4f05-a99c-e047533a0cf1", "zkorpio12", false, false, null, "ZKORPIO12", "ZKORPIO12", "AQAAAAIAAYagAAAAEP3I1AvELGNfAlZwQuZCA978uZQnEkNgIwvV5wzyXMdRu4ptDbHjtxtfllF0o+e7Uw==", null, false, "c559b1b0-d536-4eab-87db-6cd68b3d0447", false, "zkorpio12", "Uriel", true },
                    { "df98ea20-9e1f-4bf7-9501-74cd4126a0bc", 0, "142aa57e-e6b0-437f-bba3-1b661028d2e3", "patito123", false, false, null, "PATITO123", "PATITO123", "AQAAAAIAAYagAAAAEGZFpXXMvfJj0KwRGsb7Cf9Scl0aUALo6ZLskZBorLc1iBAyxxXyFehOjS3lxluWNw==", null, false, "cb8fc689-9e5d-46b4-bb5e-ff6754f5c13e", false, "patito123", "Pato Gonzalez Perez", false }
                });

            migrationBuilder.InsertData(
                table: "Disponibilidad",
                columns: new[] { "disponibilidadId", "nombre_disponibilidad" },
                values: new object[,]
                {
                    { 1, "Disponible" },
                    { 2, "Ocupado" },
                    { 3, "En mantenimiento" }
                });

            migrationBuilder.InsertData(
                table: "Estatus",
                columns: new[] { "estatusId", "nombre_estatus" },
                values: new object[,]
                {
                    { 1, "Activo" },
                    { 2, "Inactivo" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ef404a9f-8efb-4de9-9b4f-05705d604bac", "4ecf76a1-704f-46f5-9d58-2ba8ad601845" },
                    { "4a3f9656-b7a3-4d56-bbf3-910c26e0eb92", "df98ea20-9e1f-4bf7-9501-74cd4126a0bc" }
                });

            migrationBuilder.InsertData(
                table: "Equipos",
                columns: new[] { "equipoId", "disponibilidadId", "marca", "modelo", "nombre", "url_imagen" },
                values: new object[,]
                {
                    { 1, 1, "DELL", "50i", "PC Gamer Delios", "https://th.bing.com/th/id/OIP.pqgvcdzTUqEg1Dn4TB6p9QHaHa?rs=1&pid=ImgDetMain" },
                    { 2, 1, "DELL", "R11", "Alienware Aurora", "https://th.bing.com/th/id/OIP.ybUvOyf2tQLPRjKpvZqhPgHaHa?rs=1&pid=ImgDetMain" },
                    { 3, 1, "HP", "30L", "HP Omen", "https://th.bing.com/th/id/OIP.kuD2oV-5Gh6pxBKcC5BltAHaFj?rs=1&pid=ImgDetMain" },
                    { 4, 1, "ASUS", "G15", "ASUS ROG Strix", "https://th.bing.com/th/id/R.62ff86997b0fa6088ffdd0cc6c50db28?rik=k3MAQ1hNeojL7A&pid=ImgRaw&r=0" },
                    { 5, 3, "MSI", "Arctic", "MSI Trident 3", "https://www.bhphotovideo.com/images/images2500x2500/msi_mpg_trident_3_12tc_007us_trident_3_i7f_3060_1709605.jpg" },
                    { 6, 1, "Microsoft", "1TB", "Xbox Series S", "https://th.bing.com/th/id/R.2abcd1e0694b7d96057df2ffc77b5ac9?rik=MtyoTVw3ZbrXYw&pid=ImgRaw&r=0" },
                    { 7, 1, "Microsoft", "1TB", "Xbox Series S", "https://th.bing.com/th/id/R.2abcd1e0694b7d96057df2ffc77b5ac9?rik=MtyoTVw3ZbrXYw&pid=ImgRaw&r=0" },
                    { 8, 1, "Microsoft", "1TB", "Xbox Series S", "https://th.bing.com/th/id/R.2abcd1e0694b7d96057df2ffc77b5ac9?rik=MtyoTVw3ZbrXYw&pid=ImgRaw&r=0" },
                    { 9, 1, "Microsoft", "1TB", "Xbox Series S", "https://th.bing.com/th/id/R.2abcd1e0694b7d96057df2ffc77b5ac9?rik=MtyoTVw3ZbrXYw&pid=ImgRaw&r=0" },
                    { 10, 3, "Microsoft", "1TB", "Xbox Series S", "https://th.bing.com/th/id/R.2abcd1e0694b7d96057df2ffc77b5ac9?rik=MtyoTVw3ZbrXYw&pid=ImgRaw&r=0" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaJuego_juegosjuegoId",
                table: "CategoriaJuego",
                column: "juegosjuegoId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_disponibilidadId",
                table: "Equipos",
                column: "disponibilidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Juegos_estatusId",
                table: "Juegos",
                column: "estatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CategoriaJuego");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Juegos");

            migrationBuilder.DropTable(
                name: "Disponibilidad");

            migrationBuilder.DropTable(
                name: "Estatus");
        }
    }
}
