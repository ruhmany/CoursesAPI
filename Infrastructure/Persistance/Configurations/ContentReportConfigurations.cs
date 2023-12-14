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
    internal class ContentReportConfigurations : IEntityTypeConfiguration<ContentReport>
    {
        public void Configure(EntityTypeBuilder<ContentReport> builder)
        {
            builder.HasKey(cr => new { cr.ContentID, cr.UserID });
            builder.HasOne(cr => cr.User)
                    .WithMany(u => u.ContentReports)
                        .HasForeignKey(cr => cr.UserID);
            builder.HasOne(cr => cr.Content)
                    .WithMany(c => c.ContentReports)
                        .HasForeignKey(cr => cr.ContentID);
        }
    }
}
