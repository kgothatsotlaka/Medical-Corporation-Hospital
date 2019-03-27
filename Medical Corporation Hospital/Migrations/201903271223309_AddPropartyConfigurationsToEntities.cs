namespace Medical_Corporation_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropartyConfigurationsToEntities : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Beds", "Occupied", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Cities", "Name", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Cities", "Province", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Cities", "Country", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Hospitals", "Name", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Doctors", "Initials", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Doctors", "LastName", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Doctors", "Address", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Doctors", "Telephone", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Patients", "FullName", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Patients", "AdmissionTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Patients", "Address", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Patients", "Telephone", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Wards", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Wards", "Name", c => c.String());
            AlterColumn("dbo.Patients", "Telephone", c => c.String());
            AlterColumn("dbo.Patients", "Address", c => c.String());
            AlterColumn("dbo.Patients", "AdmissionTime", c => c.DateTime());
            AlterColumn("dbo.Patients", "FullName", c => c.String());
            AlterColumn("dbo.Doctors", "Telephone", c => c.String());
            AlterColumn("dbo.Doctors", "Address", c => c.String());
            AlterColumn("dbo.Doctors", "LastName", c => c.String());
            AlterColumn("dbo.Doctors", "Initials", c => c.String());
            AlterColumn("dbo.Hospitals", "Name", c => c.String());
            AlterColumn("dbo.Cities", "Country", c => c.String());
            AlterColumn("dbo.Cities", "Province", c => c.String());
            AlterColumn("dbo.Cities", "Name", c => c.String());
            AlterColumn("dbo.Beds", "Occupied", c => c.String());
        }
    }
}
