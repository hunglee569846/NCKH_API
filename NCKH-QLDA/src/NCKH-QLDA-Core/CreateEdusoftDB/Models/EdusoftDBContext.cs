using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CreateEdusoftDB.Models
{
    public partial class EdusoftDBContext : DbContext
    {
        public EdusoftDBContext()
            : base("name=EdusoftDBContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<BoMon> BoMons { get; set; }
        public virtual DbSet<ChuongTrinhDaoTao> ChuongTrinhDaoTaos { get; set; }
        public virtual DbSet<ChuyenNganh> ChuyenNganhs { get; set; }
        public virtual DbSet<GiangVien> GiangViens { get; set; }
        public virtual DbSet<KetQuaHocTap> KetQuaHocTaps { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<LopHoc> LopHocs { get; set; }
        public virtual DbSet<Nganh> Nganhs { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoMon>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<BoMon>()
                .Property(e => e.MaBoMon)
                .IsUnicode(false);

            modelBuilder.Entity<BoMon>()
                .Property(e => e.IdKhoa)
                .IsUnicode(false);

            modelBuilder.Entity<ChuongTrinhDaoTao>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<ChuongTrinhDaoTao>()
                .Property(e => e.MaChuongTrinhDaoTao)
                .IsUnicode(false);

            modelBuilder.Entity<ChuyenNganh>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<ChuyenNganh>()
                .Property(e => e.MaChuyenNganh)
                .IsUnicode(false);

            modelBuilder.Entity<ChuyenNganh>()
                .Property(e => e.MaNganh)
                .IsUnicode(false);

            modelBuilder.Entity<GiangVien>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<GiangVien>()
                .Property(e => e.MaGiangVien)
                .IsUnicode(false);

            modelBuilder.Entity<GiangVien>()
                .Property(e => e.MaBoMon)
                .IsUnicode(false);

            modelBuilder.Entity<KetQuaHocTap>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<KetQuaHocTap>()
                .Property(e => e.MaSinhVien)
                .IsUnicode(false);

            modelBuilder.Entity<KetQuaHocTap>()
                .Property(e => e.MaLop)
                .IsUnicode(false);

            modelBuilder.Entity<Khoa>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Khoa>()
                .Property(e => e.MaKhoa)
                .IsUnicode(false);

            modelBuilder.Entity<LopHoc>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<LopHoc>()
                .Property(e => e.MaLop)
                .IsUnicode(false);

            modelBuilder.Entity<LopHoc>()
                .Property(e => e.MaChuyenNganh)
                .IsUnicode(false);

            modelBuilder.Entity<LopHoc>()
                .Property(e => e.MaChuongTrinhDaoTao)
                .IsUnicode(false);

            modelBuilder.Entity<Nganh>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Nganh>()
                .Property(e => e.MaNganh)
                .IsUnicode(false);

            modelBuilder.Entity<Nganh>()
                .Property(e => e.IdBoMon)
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.MaSinhVien)
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.MaLop)
                .IsUnicode(false);
        }
    }
}
