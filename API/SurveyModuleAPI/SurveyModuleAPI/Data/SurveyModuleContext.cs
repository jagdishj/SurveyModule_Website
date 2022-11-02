using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SurveyModule.Models;

namespace SurveyModule.Data
{
    public partial class SurveyModuleContext : DbContext
    {
        public SurveyModuleContext()
        {
        }

        public SurveyModuleContext(DbContextOptions<SurveyModuleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblLogin> TblLogins { get; set; } = null!;
        public virtual DbSet<TblProject> TblProjects { get; set; } = null!;
        public virtual DbSet<TblQuestionnaire> TblQuestionnaires { get; set; } = null!;
        public virtual DbSet<TblQuestionnaireOption> TblQuestionnaireOptions { get; set; } = null!;
        public virtual DbSet<ViewProjectlist> ViewProjectlists { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<TblLogin>(entity =>
            {
                entity.ToTable("tbl_login");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Createdat)
                    .HasColumnType("datetime")
                    .HasColumnName("createdat");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Loginid)
                    .HasMaxLength(45)
                    .HasColumnName("loginid");

                entity.Property(e => e.Modifiedat)
                    .HasColumnType("datetime")
                    .HasColumnName("modifiedat");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.Password)
                    .HasMaxLength(45)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<TblProject>(entity =>
            {
                entity.ToTable("tbl_project");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Createdat)
                    .HasColumnType("datetime")
                    .HasColumnName("createdat");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Modifiedat)
                    .HasColumnType("datetime")
                    .HasColumnName("modifiedat");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.ProjectDesc)
                    .HasMaxLength(500)
                    .HasColumnName("project_desc");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(45)
                    .HasColumnName("project_name");

                entity.Property(e => e.Scheduled).HasColumnName("scheduled");

                entity.Property(e => e.ScheduledEndDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("scheduled_end_datetime");

                entity.Property(e => e.ScheduledStartDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("scheduled_start_datetime");
            });

            modelBuilder.Entity<TblQuestionnaire>(entity =>
            {
                entity.ToTable("tbl_questionnaire");

                entity.HasIndex(e => e.ProjectId, "fk_project_id_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Createdat)
                    .HasColumnType("datetime")
                    .HasColumnName("createdat");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Modifiedat)
                    .HasColumnType("datetime")
                    .HasColumnName("modifiedat");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.Question)
                    .HasMaxLength(50)
                    .HasColumnName("question");

                entity.Property(e => e.QuestionDesc)
                    .HasMaxLength(500)
                    .HasColumnName("question_desc");

                entity.Property(e => e.QuestionOrder).HasColumnName("question_order");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblQuestionnaires)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("fk_project_id");
            });

            modelBuilder.Entity<TblQuestionnaireOption>(entity =>
            {
                entity.ToTable("tbl_questionnaire_options");

                entity.HasIndex(e => e.TblQuestionnaireId, "fk_questionnaire_id_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Createdat)
                    .HasColumnType("datetime")
                    .HasColumnName("createdat");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Modifiedat)
                    .HasColumnType("datetime")
                    .HasColumnName("modifiedat");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.OptionDesc)
                    .HasMaxLength(45)
                    .HasColumnName("option_desc");

                entity.Property(e => e.OptionOrder).HasColumnName("option_order");

                entity.Property(e => e.OptionScore).HasColumnName("option_score");

                entity.Property(e => e.TblQuestionnaireId).HasColumnName("tbl_questionnaire_id");

                entity.HasOne(d => d.TblQuestionnaire)
                    .WithMany(p => p.TblQuestionnaireOptions)
                    .HasForeignKey(d => d.TblQuestionnaireId)
                    .HasConstraintName("fk_questionnaire_id");
            });

            modelBuilder.Entity<ViewProjectlist>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("view_projectlist");

                entity.Property(e => e.ProjectDesc)
                    .HasMaxLength(500)
                    .HasColumnName("project_desc");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(45)
                    .HasColumnName("project_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
