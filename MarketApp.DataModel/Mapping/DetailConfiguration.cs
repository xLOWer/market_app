﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 29.10.2020 20:51:50
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity.ModelConfiguration;

namespace MarketApp.DataModel.Market.Mapping
{

    public partial class DetailConfiguration : EntityTypeConfiguration<Detail>
    {

        public DetailConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("DOC_AMENDS_DETAILS", "MARKET");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"ID")
                    .IsRequired()
                    .HasMaxLength(38)
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)
                    .IsUnicode(false);
            this
                .Property(p => p.CreatedDate)
                    .HasColumnName(@"CREATED_DATE")
                    .HasPrecision(0);
            this
                .Property(p => p.DeletedDate)
                    .HasColumnName(@"DELETED_DATE")
                    .HasPrecision(0);
            this
                .Property(p => p.InvoiceNumber)
                    .HasColumnName(@"INVOICE_NUMBER")
                    .HasMaxLength(38)
                    .IsUnicode(false);
            this
                .Property(p => p.PlanSum)
                    .HasColumnName(@"PLAN_SUM");
            this
                .Property(p => p.InvoiceFile)
                    .HasColumnName(@"INVOICE_FILE");
            this
                .Property(p => p.Coment)
                    .HasColumnName(@"COMENT")
                    .HasMaxLength(64)
                    .IsUnicode(true);
            this
                .Property(p => p.DocDate)
                    .HasColumnName(@"DOC_DATE")
                    .HasPrecision(0);
            this
                .Property(p => p.IdBudget)
                    .HasColumnName(@"ID_BUDGET")
                    .IsRequired();
			this
				.Property( p => p.AccrualDate )
				.HasColumnName( @"ACCRUAL_DATE" )
				.IsRequired()
				.HasPrecision( 0 );
			this
				.Property( p => p.AccountNumber )
				 .HasColumnName( @"ACCOUNT_NUMBER" );
			// Association:
			this
                .HasMany(p => p.DocToDetails)
                    .WithRequired(c => c.Detail)
                .HasForeignKey(p => p.IdDetail)
                    .WillCascadeOnDelete(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
