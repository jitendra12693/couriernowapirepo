using Application.Common.Interfaces;
using Domain.Master;
using InTimeCourier.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext, IApplicationDBContext
    {
        #region Ctor
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
         : base(options)
        {
        }
        #endregion
        #region DbSet
        public DbSet<AppSetting> AppSettings { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<AreaMaster> AreaMasters { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<BillTransaction> BillTransactions { get; set; }
        public DbSet<CompanyMaster> CompanyMasters { get; set; }
        public DbSet<CompanyDetail> CompanyDetails { get; set; }
        public DbSet<CountryMaster> CountryMasters { get; set; }
        public DbSet<CourrierMaster> CourrierMasters { get; set; }
        public DbSet<CourrierMode> CourrierModes {  get; set; }
        public DbSet<DestinationMaster> DestinationMasters { get; set; }
        public DbSet<FinancialYear> FinancialYears { get; set; }
        public DbSet<InvoiceSerialNumber> InvoiceSerialNumbers { get; set; }
        public DbSet<NetworkMaster> NetworkMasters { get; set; }
        public DbSet<PartyMaster> PartyMasters { get; set; }
        public DbSet<PaymentMaster> PaymentMasters { get; set; }
        public DbSet<RateMapping> RateMappings { get; set; }
        public DbSet<RoleMaster> RoleMasters { get; set; }
        public DbSet<SourceMaster>  SourceMasters { get; set; }
        public DbSet<StateMaster> StateMasters { get; set; }
        public DbSet<StatusMaster> StatusMasters { get; set; }
        public DbSet<UserMaster> UserMasters { get; set; }
        #endregion
        #region Methods
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
        #endregion
    }
}
