namespace Medical_Corporation_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Occupied = c.String(nullable: false, maxLength: 10),
                        WardId = c.Int(nullable: false),
                        HospitalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hospitals", t => t.HospitalId)
                .ForeignKey("dbo.Wards", t => t.WardId)
                .Index(t => t.WardId)
                .Index(t => t.HospitalId);
            
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        Province = c.String(nullable: false, maxLength: 250),
                        Country = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Initials = c.String(nullable: false, maxLength: 10),
                        LastName = c.String(nullable: false, maxLength: 250),
                        Address = c.String(nullable: false, maxLength: 1000),
                        Telephone = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FullName = c.String(nullable: false, maxLength: 250),
                        AdmissionTime = c.DateTime(nullable: false),
                        Address = c.String(nullable: false, maxLength: 1000),
                        Telephone = c.String(nullable: false, maxLength: 10),
                        HospitalId = c.Int(nullable: false),
                        WardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hospitals", t => t.HospitalId)
                .ForeignKey("dbo.Wards", t => t.WardId)
                .ForeignKey("dbo.Beds", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.HospitalId)
                .Index(t => t.WardId);
            
            CreateTable(
                "dbo.Wards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        HospitalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hospitals", t => t.HospitalId)
                .Index(t => t.HospitalId);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        PatientId = c.Int(nullable: false),
                        DoctorsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PatientId, t.DoctorsId })
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorsId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorsId);
            
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        HospitalId = c.Int(nullable: false),
                        DoctorsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HospitalId, t.DoctorsId })
                .ForeignKey("dbo.Hospitals", t => t.HospitalId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorsId, cascadeDelete: true)
                .Index(t => t.HospitalId)
                .Index(t => t.DoctorsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Beds", "WardId", "dbo.Wards");
            DropForeignKey("dbo.Patients", "Id", "dbo.Beds");
            DropForeignKey("dbo.Beds", "HospitalId", "dbo.Hospitals");
            DropForeignKey("dbo.Works", "DoctorsId", "dbo.Doctors");
            DropForeignKey("dbo.Works", "HospitalId", "dbo.Hospitals");
            DropForeignKey("dbo.Patients", "WardId", "dbo.Wards");
            DropForeignKey("dbo.Wards", "HospitalId", "dbo.Hospitals");
            DropForeignKey("dbo.Patients", "HospitalId", "dbo.Hospitals");
            DropForeignKey("dbo.Appointments", "DoctorsId", "dbo.Doctors");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Hospitals", "CityId", "dbo.Cities");
            DropIndex("dbo.Works", new[] { "DoctorsId" });
            DropIndex("dbo.Works", new[] { "HospitalId" });
            DropIndex("dbo.Appointments", new[] { "DoctorsId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropIndex("dbo.Wards", new[] { "HospitalId" });
            DropIndex("dbo.Patients", new[] { "WardId" });
            DropIndex("dbo.Patients", new[] { "HospitalId" });
            DropIndex("dbo.Patients", new[] { "Id" });
            DropIndex("dbo.Hospitals", new[] { "CityId" });
            DropIndex("dbo.Beds", new[] { "HospitalId" });
            DropIndex("dbo.Beds", new[] { "WardId" });
            DropTable("dbo.Works");
            DropTable("dbo.Appointments");
            DropTable("dbo.Wards");
            DropTable("dbo.Patients");
            DropTable("dbo.Doctors");
            DropTable("dbo.Cities");
            DropTable("dbo.Hospitals");
            DropTable("dbo.Beds");
        }
    }
}
