using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FSK_BusinessObjects;

public partial class FengShuiKoiDbContext : DbContext
{
    public FengShuiKoiDbContext()
    {
    }

    public FengShuiKoiDbContext(DbContextOptions<FengShuiKoiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdsImage> AdsImages { get; set; }

    public virtual DbSet<Advertisement> Advertisements { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<BlogImage> BlogImages { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Element> Elements { get; set; }

    public virtual DbSet<KoiFish> KoiFishes { get; set; }

    public virtual DbSet<KoiImage> KoiImages { get; set; }

    public virtual DbSet<KoiType> KoiTypes { get; set; }

    public virtual DbSet<PricingPlan> PricingPlans { get; set; }

    public virtual DbSet<Tank> Tanks { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=VUI-CHOI-LA-TU-\\MSSQLSERVER01; Database=FengShuiKoiDB; Uid=sa; Pwd=12345; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdsImage>(entity =>
        {
            entity.HasKey(e => e.AdImageId).HasName("PK__Ads_Imag__A736F7E91A1400B5");

            entity.ToTable("Ads_Image");

            entity.Property(e => e.AdImageId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("AdImageID");
            entity.Property(e => e.AdId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("AdID");
            entity.Property(e => e.AdImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("AdImageURL");

            entity.HasOne(d => d.Ad).WithMany(p => p.AdsImages)
                .HasForeignKey(d => d.AdId)
                .HasConstraintName("FK_Image_Ads");
        });

        modelBuilder.Entity<Advertisement>(entity =>
        {
            entity.HasKey(e => e.AdId).HasName("PK__Advertis__7130D58EB3F9FF54");

            entity.ToTable("Advertisement");

            entity.Property(e => e.AdId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("AdID");
            entity.Property(e => e.AdImageId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("AdImageID");
            entity.Property(e => e.CategoryId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CategoryID");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.ElementId).HasColumnName("ElementID");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.Category).WithMany(p => p.Advertisements)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Advertisement_Category");

            entity.HasOne(d => d.Element).WithMany(p => p.Advertisements)
                .HasForeignKey(d => d.ElementId)
                .HasConstraintName("FK_Advertisement_Element");

            entity.HasOne(d => d.User).WithMany(p => p.Advertisements)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Advertisement_User");
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PK__Blog__54379E505F5FCDC4");

            entity.ToTable("Blog");

            entity.Property(e => e.BlogId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BlogID");
            entity.Property(e => e.BlogImageId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("BlogImageID");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("ImageURL");
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Blog_User");
        });

        modelBuilder.Entity<BlogImage>(entity =>
        {
            entity.HasKey(e => e.BlogImageId).HasName("PK__Blog_Ima__63C7F19E5341FB1C");

            entity.ToTable("Blog_Image");

            entity.Property(e => e.BlogImageId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("BlogImageID");
            entity.Property(e => e.BlogId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BlogID");
            entity.Property(e => e.BlogImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("BlogImageURL");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A2B6D7A676D");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(255);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comment__C3B4DFAA0D5E3FD4");

            entity.ToTable("Comment");

            entity.Property(e => e.CommentId)
                .ValueGeneratedNever()
                .HasColumnName("CommentID");
            entity.Property(e => e.BlogId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BlogID");
            entity.Property(e => e.Content).HasMaxLength(1000);
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.Blog).WithMany(p => p.Comments)
                .HasForeignKey(d => d.BlogId)
                .HasConstraintName("FK_Comment_Blog");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Comment_User");
        });

        modelBuilder.Entity<Element>(entity =>
        {
            entity.HasKey(e => e.ElementId).HasName("PK__Element__A429723A250C76A3");

            entity.ToTable("Element");

            entity.Property(e => e.ElementId)
                .ValueGeneratedNever()
                .HasColumnName("ElementID");
            entity.Property(e => e.Color).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Direction).HasMaxLength(255);
            entity.Property(e => e.ElementName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Generation).HasMaxLength(255);
            entity.Property(e => e.Inhibition).HasMaxLength(255);
            entity.Property(e => e.Quantity).HasMaxLength(255);
        });

        modelBuilder.Entity<KoiFish>(entity =>
        {
            entity.HasKey(e => e.KoiId).HasName("PK__KoiFish__E03435B8A484F672");

            entity.ToTable("KoiFish");

            entity.Property(e => e.KoiId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("KoiID");
            entity.Property(e => e.Color).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.KoiTypeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("KoiTypeID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Size).HasMaxLength(255);
            entity.Property(e => e.Weight).HasMaxLength(255);

            entity.HasOne(d => d.KoiType).WithMany(p => p.KoiFishes)
                .HasForeignKey(d => d.KoiTypeId)
                .HasConstraintName("FK_KoiFish_KoiTypes");

            entity.HasMany(d => d.Elements).WithMany(p => p.Kois)
                .UsingEntity<Dictionary<string, object>>(
                    "KoiElement",
                    r => r.HasOne<Element>().WithMany()
                        .HasForeignKey("ElementId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_KoiElement_Element"),
                    l => l.HasOne<KoiFish>().WithMany()
                        .HasForeignKey("KoiId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_KoiElement_KoiFish"),
                    j =>
                    {
                        j.HasKey("KoiId", "ElementId").HasName("PK__Koi_Elem__5A76A29B803C9F42");
                        j.ToTable("Koi_Element");
                        j.IndexerProperty<string>("KoiId")
                            .HasMaxLength(50)
                            .IsUnicode(false)
                            .HasColumnName("KoiID");
                        j.IndexerProperty<int>("ElementId").HasColumnName("ElementID");
                    });
        });

        modelBuilder.Entity<KoiImage>(entity =>
        {
            entity.HasKey(e => e.KoiImageId).HasName("PK__Koi_Imag__11060AB2C61AB07B");

            entity.ToTable("Koi_Image");

            entity.Property(e => e.KoiImageId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("KoiImageID");
            entity.Property(e => e.KoiId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("KoiID");
            entity.Property(e => e.KoiImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("KoiImageURL");

            entity.HasOne(d => d.Koi).WithMany(p => p.KoiImages)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK_Image_Koi");
        });

        modelBuilder.Entity<KoiType>(entity =>
        {
            entity.HasKey(e => e.KoiTypeId).HasName("PK__KoiTypes__040BD455E2B98372");

            entity.Property(e => e.KoiTypeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("KoiTypeID");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<PricingPlan>(entity =>
        {
            entity.HasKey(e => e.PlanId).HasName("PK__PricingP__755C22D7229DA1FB");

            entity.ToTable("PricingPlan");

            entity.Property(e => e.PlanId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PlanID");
            entity.Property(e => e.PlanName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tank>(entity =>
        {
            entity.HasKey(e => e.TankId).HasName("PK__Tank__97DE7005CC25CEE5");

            entity.ToTable("Tank");

            entity.Property(e => e.TankId)
                .HasMaxLength(50)
                .HasColumnName("TankID");
            entity.Property(e => e.ElementId).HasColumnName("ElementID");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("ImageURL");
            entity.Property(e => e.Shape).HasMaxLength(50);

            entity.HasOne(d => d.Element).WithMany(p => p.Tanks)
                .HasForeignKey(d => d.ElementId)
                .HasConstraintName("FK_Tank_Element");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.SubscriptionId).HasName("PK__Transact__9A2B24BDC67D7C87");

            entity.ToTable("Transaction");

            entity.Property(e => e.SubscriptionId)
                .HasMaxLength(100)
                .HasColumnName("SubscriptionID");
            entity.Property(e => e.SubscriptionName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_User_Subscription");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCACA0818D82");

            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("UserID");
            entity.Property(e => e.ElementId).HasColumnName("ElementID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("ImageURL");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PlanId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PlanID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Element).WithMany(p => p.Users)
                .HasForeignKey(d => d.ElementId)
                .HasConstraintName("FK_User_Element");

            entity.HasOne(d => d.Plan).WithMany(p => p.Users)
                .HasForeignKey(d => d.PlanId)
                .HasConstraintName("FK_User_PricingPlan");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
