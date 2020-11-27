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

    public partial class DocAmendConfiguration : EntityTypeConfiguration<DocAmend>
    {

        public DocAmendConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("DOC_AMENDS", "MARKET");
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
                .Property(p => p.RegDate)
                    .HasColumnName(@"REG_DATE")
                    .IsRequired()
                    .HasPrecision(0);

            this
                .Property(p => p.CommentId )
                    .HasColumnName(@"ID_COMMENT")
                    .HasMaxLength(38)
                    .IsUnicode(false);
            this
                .Property(p => p.StatusId )
                    .HasColumnName(@"ID_STATUS")
                    .IsRequired()
                    .HasMaxLength(38)
                    .IsUnicode(false);
            this
                .Property(p => p.CompanyId )
                    .HasColumnName(@"ID_COMPANY")
                    .IsRequired();
            this
                .Property(p => p.ProviderId )
                    .HasColumnName(@"ID_PROVIDER")
                    .IsRequired();
            this
                .Property(p => p.PayMethodId )
                    .HasColumnName(@"ID_PAY_METHOD")
                    .IsRequired()
                    .HasMaxLength(38)
                    .IsUnicode(false);
            this
                .Property(p => p.PayedDate)
                    .HasColumnName(@"PAYED_DATE")
                    .HasPrecision(0);
            this
                .Property(p => p.HasOriginal)
                    .HasColumnName(@"HAS_ORIGINAL")
                    .IsRequired();
			this
				.Property( p => p.IdUserCreator )
					.HasColumnName( @"ID_USER_CREATOR" );
			// Association:
			this
                .HasMany(p => p.DocToDetails)
                    .WithRequired(c => c.DocAmend)
                .HasForeignKey(p => p.IdDoc)
                    .WillCascadeOnDelete(false);

            //this.HasOptional(x => x.Company)
	           // .WithMany()
	           // .HasForeignKey(x => x.CompanyId )
	           // .WillCascadeOnDelete( false );
            OnCreated();
        }

        partial void OnCreated();

    }
}