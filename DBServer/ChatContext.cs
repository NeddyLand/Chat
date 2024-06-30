using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBServer
{
    internal class ChatContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=myDataBase; Trusted_Conenection=True;").UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id).HasName("user_pk");
                entity.ToTable("user");

                entity.Property(e => e.FullName).HasColumnName("FullName").HasMaxLength(255);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(x => x.MessageId).HasName("msg_pk");
                entity.ToTable("message");

                entity.Property(e => e.Text).HasColumnName("msg_text");
                entity.Property(e => e.IsSent).HasColumnName("msg_sendLED");
                entity.Property(e => e.MessageId).HasColumnName("msg_ID");
            });
            
        }
        public ChatContext()
        {

        }
    }
}
