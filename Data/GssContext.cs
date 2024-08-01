using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using fiql_tools.Models;

namespace fiql_tools.Data;

public partial class GssContext : DbContext
{
    public GssContext()
    {
    }

    public GssContext(DbContextOptions<GssContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<QuestionType> QuestionTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Initial Catalog=GSS;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Question__0DC06FAC1F6A87C7");

            entity.ToTable("Question");

            entity.Property(e => e.QuestionText).HasMaxLength(250);

            entity.HasOne(d => d.QuestionType).WithMany(p => p.Questions)
                .HasForeignKey(d => d.QuestionTypeId)
                .HasConstraintName("FK_Question_QuestionType");
        });

        modelBuilder.Entity<QuestionType>(entity =>
        {
            entity.HasKey(e => e.QuestionTypeId).HasName("PK__Question__7EDFF9316BA50176");

            entity.ToTable("QuestionType");

            entity.Property(e => e.QuestionTypeCode).HasMaxLength(5);
            entity.Property(e => e.QuestionTypeName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
