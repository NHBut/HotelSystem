﻿namespace QuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        idBooking = c.Int(nullable: false, identity: true),
                        totalMoney = c.Int(nullable: false),
                        checkInDate = c.String(),
                        checkOutDate = c.String(),
                        status = c.Int(nullable: false),
                        isPayment = c.Boolean(nullable: false),
                        createdDate = c.DateTime(nullable: false),
                        idRoom = c.Int(nullable: false),
                        idUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idBooking)
                .ForeignKey("dbo.Rooms", t => t.idRoom)
                .ForeignKey("dbo.Users", t => t.idUser)
                .Index(t => t.idRoom)
                .Index(t => t.idUser);
            
            CreateTable(
                "dbo.BookingServices",
                c => new
                    {
                        idBookingService = c.Int(nullable: false, identity: true),
                        idBooking = c.Int(nullable: false),
                        idService = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idBookingService)
                .ForeignKey("dbo.Bookings", t => t.idBooking)
                .ForeignKey("dbo.Services", t => t.idService)
                .Index(t => t.idBooking)
                .Index(t => t.idService);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        idService = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                        HotelId = c.Int(nullable: false),
                        cost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idService)
                .ForeignKey("dbo.Hotels", t => t.HotelId)
                .Index(t => t.HotelId);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        HotelId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HotelId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        idRoom = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                        image = c.String(nullable: false, maxLength: 255),
                        description = c.String(),
                        discount = c.Int(nullable: false),
                        cost = c.Int(nullable: false),
                        view = c.Int(nullable: false),
                        numberChildren = c.Int(nullable: false),
                        numberAdult = c.Int(nullable: false),
                        HotelId = c.Int(),
                        idType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idRoom)
                .ForeignKey("dbo.Hotels", t => t.HotelId)
                .ForeignKey("dbo.Types", t => t.idType)
                .Index(t => t.HotelId)
                .Index(t => t.idType);
            
            CreateTable(
                "dbo.RoomComments",
                c => new
                    {
                        idRoomComment = c.Int(nullable: false, identity: true),
                        idRoom = c.Int(nullable: false),
                        text = c.String(),
                        idUser = c.Int(nullable: false),
                        star = c.Int(nullable: false),
                        createdDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idRoomComment)
                .ForeignKey("dbo.Rooms", t => t.idRoom)
                .ForeignKey("dbo.Users", t => t.idUser)
                .Index(t => t.idRoom)
                .Index(t => t.idUser);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        idUser = c.Int(nullable: false, identity: true),
                        fullName = c.String(nullable: false, maxLength: 255),
                        userName = c.String(nullable: false, maxLength: 255),
                        email = c.String(nullable: false, maxLength: 255),
                        password = c.String(nullable: false, maxLength: 255),
                        phoneNumber = c.String(maxLength: 255),
                        address = c.String(maxLength: 255),
                        gender = c.String(),
                        status = c.Int(nullable: false),
                        idRole = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idUser)
                .ForeignKey("dbo.Roles", t => t.idRole)
                .Index(t => t.idRole);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        idRole = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.idRole);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        idType = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.idType);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "HotelId", "dbo.Hotels");
            DropForeignKey("dbo.Rooms", "idType", "dbo.Types");
            DropForeignKey("dbo.RoomComments", "idUser", "dbo.Users");
            DropForeignKey("dbo.Users", "idRole", "dbo.Roles");
            DropForeignKey("dbo.Bookings", "idUser", "dbo.Users");
            DropForeignKey("dbo.RoomComments", "idRoom", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "HotelId", "dbo.Hotels");
            DropForeignKey("dbo.Bookings", "idRoom", "dbo.Rooms");
            DropForeignKey("dbo.Hotels", "CityId", "dbo.Cities");
            DropForeignKey("dbo.BookingServices", "idService", "dbo.Services");
            DropForeignKey("dbo.BookingServices", "idBooking", "dbo.Bookings");
            DropIndex("dbo.Users", new[] { "idRole" });
            DropIndex("dbo.RoomComments", new[] { "idUser" });
            DropIndex("dbo.RoomComments", new[] { "idRoom" });
            DropIndex("dbo.Rooms", new[] { "idType" });
            DropIndex("dbo.Rooms", new[] { "HotelId" });
            DropIndex("dbo.Hotels", new[] { "CityId" });
            DropIndex("dbo.Services", new[] { "HotelId" });
            DropIndex("dbo.BookingServices", new[] { "idService" });
            DropIndex("dbo.BookingServices", new[] { "idBooking" });
            DropIndex("dbo.Bookings", new[] { "idUser" });
            DropIndex("dbo.Bookings", new[] { "idRoom" });
            DropTable("dbo.Types");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.RoomComments");
            DropTable("dbo.Rooms");
            DropTable("dbo.Cities");
            DropTable("dbo.Hotels");
            DropTable("dbo.Services");
            DropTable("dbo.BookingServices");
            DropTable("dbo.Bookings");
        }
    }
}
