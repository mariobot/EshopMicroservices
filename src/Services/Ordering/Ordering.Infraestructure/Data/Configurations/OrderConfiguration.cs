using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Enums;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infraestructure.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id).HasConversion(
            orderId => orderId.Value,
            dbId => OrderId.Of(dbId));

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(o => o.CustomerId)
            .IsRequired();

        builder.HasMany(o => o.OrderItems)
            .WithOne()
            .HasForeignKey(o => o.OrderId);

        builder.ComplexProperty(
            o => o.OrderName, nameBuilder =>
            {
                nameBuilder.Property(n => n.Value)
                    .HasColumnName(nameof(Order.OrderName))
                    .HasMaxLength(180)
                    .IsRequired();
            });

        builder.ComplexProperty(
            o => o.ShippingAddress, nameBuilder =>
            {
                nameBuilder.Property(n => n.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                nameBuilder.Property(n => n.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                nameBuilder.Property(n => n.EmailAddress)
                    .HasMaxLength(255);

                nameBuilder.Property(n => n.AddressLine)
                    .HasMaxLength(180)
                    .IsRequired();

                nameBuilder.Property(n => n.Country)
                    .HasMaxLength(50);

                nameBuilder.Property(n => n.State)
                    .HasMaxLength(50);

                nameBuilder.Property(n => n.ZipCode)
                    .HasMaxLength(5)
                    .IsRequired();
            });

        builder.ComplexProperty(
            o => o.BillingAddress, nameBuilder =>
            {
                nameBuilder.Property(n => n.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                nameBuilder.Property(n => n.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                nameBuilder.Property(n => n.EmailAddress)
                    .HasMaxLength(255);

                nameBuilder.Property(n => n.AddressLine)
                    .HasMaxLength(180)
                    .IsRequired();

                nameBuilder.Property(n => n.Country)
                    .HasMaxLength(50);

                nameBuilder.Property(n => n.State)
                    .HasMaxLength(50);

                nameBuilder.Property(n => n.ZipCode)
                    .HasMaxLength(5)
                    .IsRequired();
            });

        builder.ComplexProperty(
            o => o.Payment, nameBuilder =>
            {
                nameBuilder.Property(n => n.CardName)
                    .HasMaxLength(50);

                nameBuilder.Property(n => n.CardNumber)
                    .HasMaxLength(24)
                    .IsRequired();

                nameBuilder.Property(n => n.Expiration)
                    .HasMaxLength(10);

                nameBuilder.Property(n => n.CVV)
                    .HasMaxLength(3);

                nameBuilder.Property(n => n.PaymentMethod);
            });

        builder.Property(o => o.Status)
            .HasDefaultValue(OrderStatus.Draft)
            .HasConversion(
                s => s.ToString(),
                dbStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbStatus));

        builder.Property(o => o.TotalPrice);
    }
}
