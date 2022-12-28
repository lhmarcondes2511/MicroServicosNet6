﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShopping.CuponAPI.Migrations
{
    public partial class ajusteCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cupon_code",
                table: "cart_header",
                newName: "coupon_code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "coupon_code",
                table: "cart_header",
                newName: "cupon_code");
        }
    }
}
