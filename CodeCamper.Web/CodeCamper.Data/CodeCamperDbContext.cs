using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using CodeCamper.Data.Configuration;
using CodeCamper.Model;

namespace CodeCamper.Data
{
  public class CodeCamperDbContext : DbContext
  {
    public CodeCamperDbContext() 
      : base(nameOrConnectionString: "CodeCamper") { }

    public DbSet<Session> Sessions{ get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Attendance> Attendance { get; set; }

    // Lookup lists
    public DbSet<Room> Rooms { get; set; }
    public DbSet<TimeSlot> TimeSlots { get; set; }
    public DbSet<Track> Tracks { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

      modelBuilder.Configurations.Add(new SessionConfiguration());
      modelBuilder.Configurations.Add(new AttenanceConfiguration());
    }
  }
}
