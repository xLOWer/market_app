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

    public partial class CommentConfiguration : EntityTypeConfiguration<Comment>
    {

        public CommentConfiguration()
        {
            this
                .HasKey(p => p.Id)
                .ToTable("REF_DOC_COMMENTS", "MARKET");
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
                .Property(p => p.Name)
                    .HasColumnName(@"NAME")
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);
            // Association:
            this
                .HasMany(p => p.DocAmends)
                    .WithOptional(c => c.Comment)
                .HasForeignKey(p => p.CommentId )
                    .WillCascadeOnDelete(false);
            OnCreated();
        }

        partial void OnCreated();

    }
}
