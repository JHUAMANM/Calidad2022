using FinancialApp.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialApp.Web.DB.Mapping;

public class TipoCuentaMapping: IEntityTypeConfiguration<TipoCuenta>
{
    public void Configure(EntityTypeBuilder<TipoCuenta> builder)
    {
        builder.ToTable("TipoCuenta", "dbo");
        builder.HasKey(o => o.Id);
    }
}