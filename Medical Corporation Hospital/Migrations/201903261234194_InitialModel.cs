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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Wards", t => t.WardId, cascadeDelete: true)
                .Index(t => t.WardId);
            
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
                        BedId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hospitals", t => t.HospitalId, cascadeDelete: true)
                .ForeignKey("dbo.Wards", t => t.Id)
                .ForeignKey("dbo.Beds", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.HospitalId);
            
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
                "dbo.Hospitals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
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
                "dbo.Wards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        HospitalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hospitals", t => t.HospitalId, cascadeDelete: true)
                .Index(t => t.HospitalId);
            
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
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DoctorId, t.PatientId })
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "Id", "dbo.Beds");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Wards", "HospitalId", "dbo.Hospitals");
            DropForeignKey("dbo.Patients", "Id", "dbo.Wards");
            DropForeignKey("dbo.Beds", "WardId", "dbo.Wards");
            DropForeignKey("dbo.Patients", "HospitalId", "dbo.Hospitals");
            DropForeignKey("dbo.Works", "DoctorsId", "dbo.Doctors");
            DropForeignKey("dbo.Works", "HospitalId", "dbo.Hospitals");
            DropForeignKey("dbo.Hospitals", "CityId", "dbo.Cities");
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropIndex("dbo.Works", new[] { "DoctorsId" });
            DropIndex("dbo.Works", new[] { "HospitalId" });
            DropIndex("dbo.Wards", new[] { "HospitalId" });
            DropIndex("dbo.Hospitals", new[] { "CityId" });
            DropIndex("dbo.Patients", new[] { "HospitalId" });
            DropIndex("dbo.Patients", new[] { "Id" });
            DropIndex("dbo.Beds", new[] { "WardId" });
            DropTable("dbo.Appointments");
            DropTable("dbo.Works");
            DropTable("dbo.Wards");
            DropTable("dbo.Cities");
            DropTable("dbo.Hospitals");
            DropTable("dbo.Doctors");
            DropTable("dbo.Patients");
            DropTable("dbo.Beds");
        }
    }
}
