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

    public partial class BudgetItemConfiguration : EntityTypeConfiguration<BudgetItem>
    {

        public BudgetItemConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("VIEW_REF_BUDGET_ITEMS", "MARKET");
            // Properties:
            this
                .Property(p => p.Id)
                    .HasColumnName(@"ID")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            this
                .Property(p => p.Name)
                    .HasColumnName(@"NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            this
	            .Property(p => p.IdParent)
	            .HasColumnName(@"ID_PARENT");
			// Association:
			this
				.HasMany( p => p.DocAmendsDetails )
					.WithRequired( c => c.BudgetItem )
				.HasForeignKey( p => p.IdBudget )
					.WillCascadeOnDelete( false );
			OnCreated();
        }

        partial void OnCreated();

    }
}