using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GYM4UDAL
{
    public partial class GYM4UContext : DbContext
    {
        public GYM4UContext()
            : base("name=GYM4UContext3")
        {
        }

        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<ActivityMembershipCard> ActivityMembershipCard { get; set; }
        public virtual DbSet<AppUser> AppUser { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<MembershipType> MembershipType { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<MembershipCard> MembershipCard { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Activity>()
                .HasMany(e => e.ActivityMembershipCard)
                .WithRequired(e => e.Activity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AppUser>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<AppUser>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<AppUser>()
                .Property(e => e.Sex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AppUser>()
                .Property(e => e.OIB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AppUser>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<AppUser>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.Activity)
                .WithRequired(e => e.AppUser)
                .HasForeignKey(e => e.CreatedByUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.Activity1)
                .WithRequired(e => e.AppUser1)
                .HasForeignKey(e => e.UpdatedByUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.ActivityMembershipCard)
                .WithRequired(e => e.AppUser)
                .HasForeignKey(e => e.CreatedByUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.ActivityMembershipCard1)
                .WithRequired(e => e.AppUser1)
                .HasForeignKey(e => e.UpdatedByUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.Member)
                .WithRequired(e => e.AppUser)
                .HasForeignKey(e => e.AppUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.AppUser1)
                .WithRequired(e => e.AppUser2)
                .HasForeignKey(e => e.CreatedByUserId);

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.AppUser11)
                .WithRequired(e => e.AppUser3)
                .HasForeignKey(e => e.UpdatedByUserId);

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.Member1)
                .WithRequired(e => e.AppUser1)
                .HasForeignKey(e => e.CreatedByUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.Member2)
                .WithRequired(e => e.AppUser2)
                .HasForeignKey(e => e.UpdatedByUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.MembershipCard)
                .WithRequired(e => e.AppUser)
                .HasForeignKey(e => e.CreatedByUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.MembershipCard1)
                .WithRequired(e => e.AppUser1)
                .HasForeignKey(e => e.UpdatedByUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.MembershipType)
                .WithRequired(e => e.AppUser)
                .HasForeignKey(e => e.CreatedByUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.MembershipType1)
                .WithRequired(e => e.AppUser1)
                .HasForeignKey(e => e.UpdatedByUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.Role1)
                .WithRequired(e => e.AppUser1)
                .HasForeignKey(e => e.CreatedByUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.Role2)
                .WithRequired(e => e.AppUser2)
                .HasForeignKey(e => e.UpdatedByUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Sex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.OIB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.ActivityMembershipCard)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.MembershipCardId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.MembershipCard)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.MembershipCard1)
                .WithRequired(e => e.Member1)
                .HasForeignKey(e => e.Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MembershipType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MembershipType>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MembershipType>()
                .HasMany(e => e.MembershipCard)
                .WithRequired(e => e.MembershipType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.AppUser)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.RoleId)
                .WillCascadeOnDelete(false);
        }
    }
}
