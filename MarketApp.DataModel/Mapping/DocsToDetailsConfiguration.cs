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

    public partial class DocsToDetailsConfiguration : EntityTypeConfiguration<DocsToDetails>
    {

        public DocsToDetailsConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("MAP_DOC_TO_DETAILS", "MARKET");
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
                    .IsRequired()
                    .HasPrecision(0);
            this
                .Property(p => p.DeletedDate)
                    .HasColumnName(@"DELETED_DATE")
                    .HasPrecision(0);
            this
                .Property(p => p.IdDetail)
                    .HasColumnName(@"ID_DETAIL")
                    .HasMaxLength(38)
                    .IsUnicode(false);
			this
                .Property(p => p.IdDoc)
                    .HasColumnName(@"ID_DOC")
                    .IsRequired()
                    .HasMaxLength(38)
                    .IsUnicode(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
