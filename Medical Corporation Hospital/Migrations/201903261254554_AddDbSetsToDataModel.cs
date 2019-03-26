namespace Medical_Corporation_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDbSetsToDataModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Occupied = c.String(),
                        Ward_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Wards", t => t.Ward_Id)
                .Index(t => t.Ward_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Province = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Initials = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        Telephone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        AdmissionTime = c.DateTime(),
                        Address = c.String(),
                        Telephone = c.String(),
                        Bed_Id = c.Int(),
                        Hospital_Id = c.Int(),
                        Ward_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Beds", t => t.Bed_Id)
                .ForeignKey("dbo.Hospitals", t => t.Hospital_Id)
                .ForeignKey("dbo.Wards", t => t.Ward_Id)
                .Index(t => t.Bed_Id)
                .Index(t => t.Hospital_Id)
                .Index(t => t.Ward_Id);
            
            CreateTable(
                "dbo.Wards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Hospital_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hospitals", t => t.Hospital_Id)
                .Index(t => t.Hospital_Id);
            
            CreateTable(
                "dbo.DoctorHospitals",
                c => new
                    {
                        Doctor_Id = c.Int(nullable: false),
                        Hospital_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Doctor_Id, t.Hospital_Id })
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Hospitals", t => t.Hospital_Id, cascadeDelete: true)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Hospital_Id);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Patient_Id = c.Int(nullable: false),
                        Doctor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Patient_Id, t.Doctor_Id })
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id, cascadeDelete: true)
                .Index(t => t.Patient_Id)
                .Index(t => t.Doctor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "Ward_Id", "dbo.Wards");
            DropForeignKey("dbo.Wards", "Hospital_Id", "dbo.Hospitals");
            DropForeignKey("dbo.Beds", "Ward_Id", "dbo.Wards");
            DropForeignKey("dbo.Patients", "Hospital_Id", "dbo.Hospitals");
            DropForeignKey("dbo.Appointments", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.Appointments", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Patients", "Bed_Id", "dbo.Beds");
            DropForeignKey("dbo.DoctorHospitals", "Hospital_Id", "dbo.Hospitals");
            DropForeignKey("dbo.DoctorHospitals", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.Hospitals", "City_Id", "dbo.Cities");
            DropIndex("dbo.Appointments", new[] { "Doctor_Id" });
            DropIndex("dbo.Appointments", new[] { "Patient_Id" });
            DropIndex("dbo.DoctorHospitals", new[] { "Hospital_Id" });
            DropIndex("dbo.DoctorHospitals", new[] { "Doctor_Id" });
            DropIndex("dbo.Wards", new[] { "Hospital_Id" });
            DropIndex("dbo.Patients", new[] { "Ward_Id" });
            DropIndex("dbo.Patients", new[] { "Hospital_Id" });
            DropIndex("dbo.Patients", new[] { "Bed_Id" });
            DropIndex("dbo.Hospitals", new[] { "City_Id" });
            DropIndex("dbo.Beds", new[] { "Ward_Id" });
            DropTable("dbo.Appointments");
            DropTable("dbo.DoctorHospitals");
            DropTable("dbo.Wards");
            DropTable("dbo.Patients");
            DropTable("dbo.Doctors");
            DropTable("dbo.Hospitals");
            DropTable("dbo.Cities");
            DropTable("dbo.Beds");
        }
    }
}
