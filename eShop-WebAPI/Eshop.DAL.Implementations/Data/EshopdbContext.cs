using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Eshop.Web.Data.EFModels
{
    public partial class EshopdbContext : DbContext
    {
        public EshopdbContext(DbContextOptions<EshopdbContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Customer> Customers { get; set; } = default!;
        public virtual DbSet<CustomerPaymentMethod> CustomerPaymentMethods { get; set; } = default!;
        public virtual DbSet<Invoice> Invoices { get; set; } = default!;
        public virtual DbSet<Order> Orders { get; set; } = default!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = default!;
        public virtual DbSet<Payment> Payments { get; set; } = default!;
        public virtual DbSet<Product> Products { get; set; } = default!;
        public virtual DbSet<RefInvoiceStatusCode> RefInvoiceStatusCodes { get; set; } = default!;
        public virtual DbSet<RefOrderItemStatusCode> RefOrderItemStatusCodes { get; set; } = default!;
        public virtual DbSet<RefOrderStatusCode> RefOrderStatusCodes { get; set; } = default!;
        public virtual DbSet<RefPaymentMethod> RefPaymentMethods { get; set; } = default!;
        public virtual DbSet<RefProductType> RefProductTypes { get; set; } = default!;
        public virtual DbSet<Shipment> Shipments { get; set; } = default!;
        public virtual DbSet<ShipmentItem> ShipmentItems { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Host=localhost;Database=eshopdb;Username=postgres;Password=ppwrb4y");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => new { e.EmailAddress, e.LoginName }, "Customers_email_address_login_name_key")
                    .IsUnique();

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasDefaultValueSql("nextval('customers'::regclass)");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(30)
                    .HasColumnName("address_line_1");

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(30)
                    .HasColumnName("address_line_2");

                entity.Property(e => e.AddressLine3)
                    .HasMaxLength(30)
                    .HasColumnName("address_line_3");

                entity.Property(e => e.AddressLine4)
                    .HasMaxLength(30)
                    .HasColumnName("address_line_4");

                entity.Property(e => e.Age)
                    .HasColumnName("age")
                    .HasDefaultValueSql("18");

                entity.Property(e => e.Country)
                    .HasMaxLength(30)
                    .HasColumnName("country");

                entity.Property(e => e.County)
                    .HasMaxLength(30)
                    .HasColumnName("county");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(30)
                    .HasColumnName("email_address");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("first_name");

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .HasColumnName("gender");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("last_name");

                entity.Property(e => e.LoginName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("login_name");

                entity.Property(e => e.LoginPassword)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("login_password");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(30)
                    .HasColumnName("middle_name");

                entity.Property(e => e.OrganisationName)
                    .HasMaxLength(30)
                    .HasColumnName("organisation_name");

                entity.Property(e => e.OrganisationOrPerson)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("organisation_or_person");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(30)
                    .HasColumnName("phone_number");

                entity.Property(e => e.TownCity)
                    .HasMaxLength(20)
                    .HasColumnName("town_city");
            });

            modelBuilder.Entity<CustomerPaymentMethod>(entity =>
            {
                entity.HasKey(e => e.CustomerPaymentId)
                    .HasName("Customer_Payment_Methods_pkey");

                entity.ToTable("Customer_Payment_Methods");

                entity.Property(e => e.CustomerPaymentId).HasColumnName("customer_payment_id");

                entity.Property(e => e.CreditCardNumber)
                    .HasMaxLength(40)
                    .HasColumnName("credit_card_number");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.PaymentMethodCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("payment_method_code");

                entity.Property(e => e.PaymentMethodDetails)
                    .HasMaxLength(40)
                    .HasColumnName("payment_method_details");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerPaymentMethods)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Customer_Payment_Methods_customer_id_fkey");

                entity.HasOne(d => d.PaymentMethodCodeNavigation)
                    .WithMany(p => p.CustomerPaymentMethods)
                    .HasForeignKey(d => d.PaymentMethodCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Customer_Payment_Methods_payment_method_code_fkey");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceNumber)
                    .HasName("Invoices_pkey");

                entity.Property(e => e.InvoiceNumber).HasColumnName("invoice_number");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnName("invoice_date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.InvoiceDetails)
                    .HasMaxLength(40)
                    .HasColumnName("invoice_details");

                entity.Property(e => e.InvoiceStatusCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("invoice_status_code");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.HasOne(d => d.InvoiceStatusCodeNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.InvoiceStatusCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Invoices_invoice_status_code_fkey");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Invoices_order_id_fkey");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DataOrderPlaced)
                    .HasMaxLength(30)
                    .HasColumnName("data_order_placed");

                entity.Property(e => e.OrderDetails)
                    .HasMaxLength(30)
                    .HasColumnName("order_details");

                entity.Property(e => e.OrderStatusCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("order_status_code");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Orders_customer_id_fkey");

                entity.HasOne(d => d.OrderStatusCodeNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatusCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Orders_order_status_code_fkey");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("Order_Items");

                entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.OrderItemPrice).HasColumnName("order_item_price");

                entity.Property(e => e.OrderItemQuantity).HasColumnName("order_item_quantity");

                entity.Property(e => e.OrderItemStatusCode).HasColumnName("order_item_status_code");

                entity.Property(e => e.OtherOrderItemDetails)
                    .HasMaxLength(40)
                    .HasColumnName("other_order_item_details");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.RmaIssuedBy)
                    .HasMaxLength(40)
                    .HasColumnName("rma_issued_by");

                entity.Property(e => e.RmaIssuedDate)
                    .HasColumnName("rma_issued_date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.RmaNumber).HasColumnName("rma_number");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Items_order_id_fkey");

                entity.HasOne(d => d.OrderItemStatusCodeNavigation)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderItemStatusCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Items_order_item_status_code_fkey");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Items_product_id_fkey");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.InvoiceNumber).HasColumnName("invoice_number");

                entity.Property(e => e.PaymentAmount)
                    .HasColumnName("payment_amount")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("payment_date")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.InvoiceNumberNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.InvoiceNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Payments_invoice_number_fkey");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.OtherProductDetails)
                    .HasMaxLength(30)
                    .HasColumnName("other_product_details");

                entity.Property(e => e.ProductColor)
                    .HasMaxLength(20)
                    .HasColumnName("product_color");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(100)
                    .HasColumnName("product_description");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("product_name");

                entity.Property(e => e.ProductPrice)
                    .HasColumnName("product_price")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProductSize)
                    .HasMaxLength(20)
                    .HasColumnName("product_size");

                entity.Property(e => e.ProductTypeCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("product_type_code");

                entity.Property(e => e.ReturnMerchandiseAuthorizationNr)
                    .HasMaxLength(40)
                    .HasColumnName("return_merchandise_authorization_nr");

                entity.HasOne(d => d.ProductTypeCodeNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Products_product_type_code_fkey");
            });

            modelBuilder.Entity<RefInvoiceStatusCode>(entity =>
            {
                entity.HasKey(e => e.InvoiceStatusCode)
                    .HasName("Ref_Invoice_Status_Codes_pkey");

                entity.ToTable("Ref_Invoice_Status_Codes");

                entity.Property(e => e.InvoiceStatusCode)
                    .HasMaxLength(20)
                    .HasColumnName("invoice_status_code");

                entity.Property(e => e.InvoiceStatusCodeDescription)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("invoice_status_code_description");
            });

            modelBuilder.Entity<RefOrderItemStatusCode>(entity =>
            {
                entity.HasKey(e => e.OrderItemStatusCode)
                    .HasName("Ref_Order_Item_Status_Codes_pkey");

                entity.ToTable("Ref_Order_Item_Status_Codes");

                entity.Property(e => e.OrderItemStatusCode).HasColumnName("order_item_status_code");

                entity.Property(e => e.OrderItemStatusCodeDescription)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("order_item_status_code_description");
            });

            modelBuilder.Entity<RefOrderStatusCode>(entity =>
            {
                entity.HasKey(e => e.OrderStatusCode)
                    .HasName("Ref_Order_Status_Code_pkey");

                entity.ToTable("Ref_Order_Status_Code");

                entity.Property(e => e.OrderStatusCode)
                    .HasMaxLength(20)
                    .HasColumnName("order_status_code");

                entity.Property(e => e.OrderStatusDescription)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("order_status_description");
            });

            modelBuilder.Entity<RefPaymentMethod>(entity =>
            {
                entity.HasKey(e => e.PaymentMethodCode)
                    .HasName("Ref_Payment_Methods_pkey");

                entity.ToTable("Ref_Payment_Methods");

                entity.Property(e => e.PaymentMethodCode)
                    .HasMaxLength(20)
                    .HasColumnName("payment_method_code");

                entity.Property(e => e.PaymentMethodDescription)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("payment_method_description");
            });

            modelBuilder.Entity<RefProductType>(entity =>
            {
                entity.HasKey(e => e.ProductTypeCode)
                    .HasName("Ref_Product_Types_pkey");

                entity.ToTable("Ref_Product_Types");

                entity.Property(e => e.ProductTypeCode)
                    .HasMaxLength(20)
                    .HasColumnName("product_type_code");

                entity.Property(e => e.ParentProductTypeCode)
                    .HasMaxLength(20)
                    .HasColumnName("parent_product_type_code");

                entity.Property(e => e.ProductTypeDescription)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("product_type_description");

                entity.HasOne(d => d.ParentProductTypeCodeNavigation)
                    .WithMany(p => p.InverseParentProductTypeCodeNavigation)
                    .HasForeignKey(d => d.ParentProductTypeCode)
                    .HasConstraintName("Ref_Product_Types_parent_product_type_code_fkey");
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.Property(e => e.ShipmentId).HasColumnName("shipment_id");

                entity.Property(e => e.InvoiceNumber).HasColumnName("invoice_number");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.OtherShipmentDetails)
                    .HasMaxLength(40)
                    .HasColumnName("other_shipment_details");

                entity.Property(e => e.ShipmentDate)
                    .HasColumnName("shipment_date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ShipmentTrackingNymber)
                    .HasMaxLength(40)
                    .HasColumnName("shipment_tracking_nymber");

                entity.HasOne(d => d.InvoiceNumberNavigation)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.InvoiceNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Shipments_invoice_number_fkey");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Shipments_order_id_fkey");
            });

            modelBuilder.Entity<ShipmentItem>(entity =>
            {
                entity.HasKey(e => new { e.ShipmentId, e.OrderItemId })
                    .HasName("shipment_order_pkey");

                entity.ToTable("Shipment_Items");

                entity.Property(e => e.ShipmentId).HasColumnName("shipment_id");

                entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");

                entity.HasOne(d => d.OrderItem)
                    .WithMany(p => p.ShipmentItems)
                    .HasForeignKey(d => d.OrderItemId)
                    .HasConstraintName("Shipment_Items_order_item_id_fkey");

                entity.HasOne(d => d.Shipment)
                    .WithMany(p => p.ShipmentItems)
                    .HasForeignKey(d => d.ShipmentId)
                    .HasConstraintName("Shipment_Items_shipment_id_fkey");
            });

            modelBuilder.HasSequence("customers");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
