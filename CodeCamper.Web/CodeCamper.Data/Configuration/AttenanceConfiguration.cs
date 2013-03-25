using System;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using CodeCamper.Model;

namespace CodeCamper.Data.Configuration
{
  public class AttenanceConfiguration : EntityTypeConfiguration<Attendance>
  {
    public AttenanceConfiguration()
    {
      HasKey(a => new { a.SessionId, a.PersonId });

      HasRequired(a => a.Session)
        .WithMany(s => s.AttendanceList)
        .HasForeignKey(a => a.SessionId)
        .WillCascadeOnDelete(false);

      HasRequired(a => a.Person)
        .WithMany(p => p.AttendanceList)
        .HasForeignKey(a => a.PersonId)
        .WillCascadeOnDelete(false);
    }
  }
}
