using Microsoft.EntityFrameworkCore;

namespace Stormwater_Analysis
{
    class AssetManagementModel:DbContext
    {
        public DbSet<Pipe> Pipes { get; set; }
        public DbSet<Manhole> Manholes { get; set; }
        public DbSet<ManholeMaintenance> ManholesMaintenance { get; set;}

        //overide the vritual methods of the base class DbContext 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder); // replace this method by our own method for Configuring the database
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StormAssetManagement;Integrated Security=True;Connect Timeout=30;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder); //take off call to base class method and provide our own OnModelCreating method
            modelBuilder.Entity<Pipe>(entity =>

                 {
                     entity.HasKey(e => e.Pipe_ID)
                         .HasName("PK_Pipes");
                     entity.Property(e => e.Pipe_ID).ValueGeneratedOnAdd();

                     entity.Property(e => e.Pipe_Type);

                     entity.Property(e => e.Start_Manhole_ID);
                     entity.Property(e => e.Pipe_Length);
                     entity.Property(e => e.Depth);
                     entity.Property(e => e.Material);
                     entity.Property(e => e.Slope);
                     entity.Property(e => e.Est_Life);
                     entity.Property(e => e.Critical_Infrastructure);
                     entity.Property(e => e.Critical_Structure);
                     entity.Property(e => e.DateOfInstallation);
                     entity.Property(e => e.Maintenance_Records_ID);
                 }
                 );

            modelBuilder.Entity<Manhole>(entity =>
                        {
                            entity.HasKey(e => e.ManholeID)
                            .HasName("PK_Manholes");

                            entity.Property(e => e.ManholeID).ValueGeneratedOnAdd();
                            entity.Property(e => e.PipeID);
                            entity.Property(e => e.ManagedBy);
                            entity.Property(e => e.InstallationDt);
                            entity.Property(e => e.DrainageArea);                          

                        }
                        );

            modelBuilder.Entity<ManholeMaintenance>(entity =>
            {
                entity.HasKey(e => e.MaintenanceID).HasName("PK_Maintenance");
                entity.Property(e => e.MaintenanceID).ValueGeneratedOnAdd();
                entity.Property(e => e.ManholeID);
                entity.Property(e => e.LastMaintenanceDt);
                entity.Property(e => e.MaintenanceIssues);
                entity.Property(e => e.MaintenanceLevel);
                entity.Property(e => e.FrameCondition);
                entity.Property(e => e.FrameSealCondition);
                entity.Property(e => e.CoverCondition);
                entity.Property(e => e.CheckedBy).IsRequired();
            }
            
            );
        }


    }
}
