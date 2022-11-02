using Microsoft.EntityFrameworkCore;
using SurveyModule.Models;

namespace SurveyModule.Data
{
    public partial class sp_textprocedure:DbContext
    {
        public virtual DbSet<TblProject> sp_project_name { get; set; } = null!;

        public sp_textprocedure() { }

        public sp_textprocedure(DbContextOptions<sp_textprocedure> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblProject>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.Id);
                entity.Property(e => e.ProjectName);
                entity.Property(e => e.ProjectDesc);
                entity.Property(e => e.Createdat);
                entity.Property(e => e.Createdby);
                entity.Property(e => e.Modifiedat);
                entity.Property(e => e.Modifiedby);
                entity.Property(e => e.Isactive);
                entity.Property(e => e.Scheduled);
                entity.Property(e => e.ScheduledStartDatetime);
                entity.Property(e => e.ScheduledEndDatetime);
            });
        }
    }
}
