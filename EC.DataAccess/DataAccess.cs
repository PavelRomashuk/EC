using EC.Models;
using Microsoft.EntityFrameworkCore;

namespace EC.DataAccess
{
    public class DatabaseAccess: DbContext
    {

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Theory> Theory { get; set; }
        public virtual DbSet<Models.Task> Tasks { get; set; }
        public virtual DbSet<ScheduledTaskTemplateContent> ScheduledTaskTemplateContents { get; set; }
        public virtual DbSet<ScheduledTaskTemplate> ScheduledTaskTemplates { get; set; }
        public virtual DbSet<ScheduledTask> ScheduledTasks { get; set; }
        public virtual DbSet<ExaminationQuestion> ExaminationQuestions { get; set; }
        public virtual DbSet<ExaminationAnswer> ExaminationAnswers { get; set; }
        public virtual DbSet<Examination> Examinations { get; set; }
        public virtual DbSet<Document> Documents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=.;initial catalog=EnglishCource;integrated security=True;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Examination>()
                .HasMany(e => e.ExaminationQuestions)
                .WithOne(x => x.Examination)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Examination>()
                .HasMany(e => e.ExaminationAnswers)
                .WithOne(x => x.Examination)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExaminationQuestion>()
                .HasMany(e => e.ExaminationAnswers)
                .WithOne(x => x.ExaminationQuestion)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ScheduledTask>()
                .HasMany(e => e.Tasks)
                .WithOne(e => e.ScheduledTask)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ScheduledTaskTemplate>()
                .HasMany(e => e.ScheduledTaskTemplateContents)
                .WithOne(e => e.ScheduledTaskTemplate)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
