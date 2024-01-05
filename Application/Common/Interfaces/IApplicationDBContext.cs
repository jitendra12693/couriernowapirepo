using Domain.Master;
using InTimeCourier.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDBContext
    {
        DbSet<AppSetting> AppSettings { get; set; }
        DbSet<AdminUser> AdminUsers { get; set; }
        DbSet<AreaMaster> AreaMasters { get; set; }
        DbSet<BillDetail> BillDetails { get; set; }
        DbSet<BillTransaction> BillTransactions { get; set; }
        public DbSet<CompanyMaster> CompanyMasters { get; set; }
        public DbSet<CompanyDetail> CompanyDetails { get; set; }
        DbSet<CountryMaster> CountryMasters { get; set; }
        DbSet<CourrierMaster> CourrierMasters { get; set; }
        DbSet<CourrierMode> CourrierModes { get; set; }
        DbSet<DestinationMaster> DestinationMasters { get; set; }
        DbSet<FinancialYear> FinancialYears { get; set; }
        DbSet<InvoiceSerialNumber> InvoiceSerialNumbers { get; set; }
        DbSet<NetworkMaster> NetworkMasters { get; set; }
        DbSet<PartyMaster> PartyMasters { get; set; }
        DbSet<PaymentMaster> PaymentMasters { get; set; }
        DbSet<RateMapping> RateMappings { get; set; }
        DbSet<RoleMaster> RoleMasters { get; set; }
        DbSet<SourceMaster> SourceMasters { get; set; }
        DbSet<StateMaster> StateMasters { get; set; }
        DbSet<StatusMaster> StatusMasters { get; set; }
        public DbSet<UserMaster> UserMasters { get; set; }
        Task<int> SaveChangesAsync();
    }
}
