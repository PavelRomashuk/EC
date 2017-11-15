using EC.Models;
using System.Data.Entity;

namespace EC.DataAccess
{
    public class DataAccess: DbContext
    {
        public DataAccess(): this("name=EbglishCource") {}

        public DataAccess(string connectionString): base(connectionString) {}

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Examination>()
                .HasMany(e => e.ExaminationQuestions)
                .WithRequired(e => e.Examination)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Examination>()
                .HasMany(e => e.ExaminationAnswers)
                .WithRequired(e => e.Examination)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExaminationQuestion>()
                .HasMany(e => e.ExaminationAnswers)
                .WithRequired(e => e.ExaminationQuestion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ScheduledTask>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.ScheduledTask)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ScheduledTaskTemplate>()
                .HasMany(e => e.ScheduledTaskTemplateContents)
                .WithRequired(e => e.ScheduledTaskTemplate)
                .WillCascadeOnDelete(false);
        }
    }
}
