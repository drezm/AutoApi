using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Practice.Models
{
    public partial class PracticeContext : DbContext
    {
        public PracticeContext()
        {
        }

        public PracticeContext(DbContextOptions<PracticeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdStatus> AdStatuses { get; set; } = null!;
        public virtual DbSet<Advertisement> Advertisements { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<CarStatus> CarStatuses { get; set; } = null!;
        public virtual DbSet<Chat> Chats { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Model> Models { get; set; } = null!;
        public virtual DbSet<Owner> Owners { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=356B\\MSSQLSERVER1;Database=Practice;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdStatus>(entity =>
            {
                entity.ToTable("AdStatus");

                entity.Property(e => e.AdStatusId).HasColumnName("AdStatusID");

                entity.Property(e => e.StatusName).HasMaxLength(30);
            });

            modelBuilder.Entity<Advertisement>(entity =>
            {
                entity.HasKey(e => e.AdId)
                    .HasName("PK__Advertis__7130D58E722FE02D");

                entity.ToTable("Advertisement");

                entity.Property(e => e.AdId).HasColumnName("AdID");

                entity.Property(e => e.AdStatusId).HasColumnName("AdStatusID");

                entity.Property(e => e.AddedBy).HasColumnName("Added_by");

                entity.Property(e => e.AddedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Added_time");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_by");

                entity.Property(e => e.DeletedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Deleted_time");

                entity.Property(e => e.Discription).HasMaxLength(600);

                entity.Property(e => e.EditBy).HasColumnName("Edit_by");

                entity.Property(e => e.EditTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Edit_time");

                entity.Property(e => e.Title).HasMaxLength(30);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.AdStatus)
                    .WithMany(p => p.Advertisements)
                    .HasForeignKey(d => d.AdStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Advertisement_AdStatus");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Advertisements)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Advertisement_Car");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.CarStatusId).HasColumnName("CarStatusID");

                entity.Property(e => e.Color).HasMaxLength(30);

                entity.Property(e => e.Description).HasMaxLength(600);

                entity.Property(e => e.Image).HasMaxLength(300);

                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.CarStatus)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.CarStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Car_CarStatus");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Car_Model");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Car_Users");
            });

            modelBuilder.Entity<CarStatus>(entity =>
            {
                entity.ToTable("CarStatus");

                entity.Property(e => e.CarStatusId).HasColumnName("CarStatusID");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.ToTable("Chat");

                entity.Property(e => e.ChatId)
                    .ValueGeneratedNever()
                    .HasColumnName("ChatID");

                entity.Property(e => e.AdId).HasColumnName("AdID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Ad)
                    .WithMany(p => p.Chats)
                    .HasForeignKey(d => d.AdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chat_Advertisement");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Chats)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chat_Users");

                entity.HasMany(d => d.Users)
                    .WithMany(p => p.ChatsNavigation)
                    .UsingEntity<Dictionary<string, object>>(
                        "Participant",
                        l => l.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Participants_Users"),
                        r => r.HasOne<Chat>().WithMany().HasForeignKey("ChatId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Participants_Chat"),
                        j =>
                        {
                            j.HasKey("ChatId", "UserId");

                            j.ToTable("Participants");

                            j.IndexerProperty<int>("ChatId").HasColumnName("ChatID");

                            j.IndexerProperty<int>("UserId").HasColumnName("UserID");
                        });
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.AddedBy).HasColumnName("Added_by");

                entity.Property(e => e.AddedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Added_time");

                entity.Property(e => e.ChatId).HasColumnName("ChatID");

                entity.Property(e => e.Contents).HasMaxLength(1000);

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_by");

                entity.Property(e => e.DeletedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Deleted_time");

                entity.Property(e => e.EditBy).HasColumnName("Edit_by");

                entity.Property(e => e.EditTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Edit_time");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Chat)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ChatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_Chat");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("Model");

                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.Brand).HasMaxLength(30);

                entity.Property(e => e.Model1)
                    .HasMaxLength(30)
                    .HasColumnName("Model");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(e => e.OwnnerId)
                    .HasName("PK__Owner__D8BDD92F6A17E7ED");

                entity.ToTable("Owner");

                entity.Property(e => e.OwnnerId).HasColumnName("OwnnerID");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.TenurePeriodFrom).HasColumnType("datetime");

                entity.Property(e => e.TenurePeriodTo).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Owners)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Owner_Car");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Owners)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Owner_Users");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.AddedBy).HasColumnName("Added_by");

                entity.Property(e => e.AddedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Added_time");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_by");

                entity.Property(e => e.DeletedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Deleted_time");

                entity.Property(e => e.EditBy).HasColumnName("Edit_by");

                entity.Property(e => e.EditTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Edit_time");

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.Location).HasMaxLength(200);

                entity.Property(e => e.Password).HasMaxLength(40);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserName).HasMaxLength(20);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
