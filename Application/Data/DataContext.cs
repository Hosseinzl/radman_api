using Application.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Application.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
                       
        }
        
        public DbSet<User> users { get; set; }
        public DbSet<Profile> profiles { get; set; }
        public DbSet<PointInfo> pointInfos { get; set; }
        public DbSet<State> states { get; set; }
        public DbSet<Competition> competitions { get; set; }
        public DbSet<Credit> credits { get; set; }
        public DbSet<GeneralInfo> generalinfos { get; set; }
        public DbSet<PortfoloItems> portfolioItems { get; set; }
        public DbSet<Model.File> file { get; set; }
        public DbSet<Friends> friends { get; set; }
        public DbSet<FriendInvitation> friendInvitations { get; set; }
        public DbSet<InvitationStatistics> invitationStatistics { get; set; }
        public DbSet<Grade> grades { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Reward> rewards { get; set; }
        public DbSet<SortType> sortTypes { get; set; }
        public DbSet<RewardDetails> rewardDetails { get; set; }
        public DbSet<PointState> pointState { get; set; }
        public DbSet<TransactionType> transactionType { get; set; }
        public DbSet<EventType> eventType { get; set; }
        public DbSet<TurnOverDataBase> turnOvers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.id)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasOne(u => u.profile)
                .WithOne()
                .HasForeignKey<Profile>(p => p.userId);
            
            modelBuilder.Entity<Profile>()
                .HasOne(p => p.pointInfo)
                .WithOne()
                .HasForeignKey<PointInfo>(p => p.profileId);

            modelBuilder.Entity<PointInfo>()
                .HasKey(p => p.pointId);
            
            modelBuilder.Entity<Competition>()
               .HasIndex(c => c.id)
               .IsUnique();

            modelBuilder.Entity<State>()
               .HasIndex(s => s.stateId)
               .IsUnique();
            
            modelBuilder.Entity<Credit>()
               .HasIndex(s => s.id)
               .IsUnique();
            
            modelBuilder.Entity<Credit>()
                .HasOne(c => c.generalInfo)
                .WithOne()
                .HasForeignKey<GeneralInfo>(g => g.creditId);

            modelBuilder.Entity<Credit>()
                .HasMany(c => c.portfoloItems)
                .WithOne()
                .HasForeignKey(p => p.idOfCredit);
            
            modelBuilder.Entity<PortfoloItems>()
                .HasKey(p => p.portfoloItemId);

            modelBuilder.Entity<Model.File>()
                .HasIndex(f => f.id)
                .IsUnique();
            
            modelBuilder.Entity<Grade>()
                .HasIndex(g => g.id)
                .IsUnique();
            
            modelBuilder.Entity<Friends>()
                .HasIndex(f => f.id)
                .IsUnique();

            modelBuilder.Entity<Friends>()
                .HasMany(f => f.friendInvitations)
                .WithOne()
                .HasForeignKey(fi => fi.UserId);

            modelBuilder.Entity<Friends>()
                .HasOne(f => f.invitationStatistics)
                .WithOne()
                .HasForeignKey<InvitationStatistics>(i => i.idUser);

            modelBuilder.Entity<FriendInvitation>()
                .HasKey(fi => fi.invitationId);
               
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.id)
                .IsUnique();

            modelBuilder.Entity<Reward>()
                .HasIndex(r => r.id)
                .IsUnique();

            modelBuilder.Entity<SortType>()
                .HasKey(s => s.key);

            modelBuilder.Entity<RewardDetails>()
                .HasIndex(r => r.id)
                .IsUnique();

            modelBuilder.Entity<PointState>()
                .HasIndex(r => r.id)
                .IsUnique();

            modelBuilder.Entity<PointState>()
                .Property(r => r.id)
                .ValueGeneratedNever();
            
            modelBuilder.Entity<EventType>()
                .HasIndex(r => r.id)
                .IsUnique();
            
            modelBuilder.Entity<EventType>()
                .Property(r => r.id)
                .ValueGeneratedNever();
            
            modelBuilder.Entity<TransactionType>()
                .HasIndex(r => r.id)
                .IsUnique();
            
            modelBuilder.Entity<TransactionType>()
                .Property(r => r.id)
                .ValueGeneratedNever();

            modelBuilder.Entity<TransactionType>()
                .HasIndex(r => r.id)
                .IsUnique();

            modelBuilder.Entity<TransactionType>()
                .Property(r => r.id)
                .ValueGeneratedNever();
        }
    }
}
