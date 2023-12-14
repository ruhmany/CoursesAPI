using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Configurations
{
    internal class RateReportConfigurations : IEntityTypeConfiguration<RateReport>
    {
        public void Configure(EntityTypeBuilder<RateReport> builder)
        {
            builder.HasKey(rr => new { rr.ReporterUserID, rr.ReportedRateID });
            builder.HasOne(rr => rr.User).WithMany(u => u.RateReports).HasForeignKey(rr => rr.ReporterUserID);
            builder.HasOne(rr => rr.ReportedRate).WithMany(r => r.RateReports).HasForeignKey(rr => rr.ReportedRateID);
        }
    }
}
