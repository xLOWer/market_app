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
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using MarketApp.DataModel.Market;

namespace MarketApp.DataModel
{
	public partial class MarketDbContext : DbContext
    {
        #region Constructors

        /// <summary>
        /// Initialize a new MarketDbContext object.
        /// </summary>
        public MarketDbContext() :
                base(MarketDbContext.GetDefaultConnection(), true)
        {
            Configure();
        }
        
        /// <summary>
        /// Initializes a new MarketDbContext object using the connection string found in the 'MarketDbContext' section of the application configuration file.
        /// </summary>
        public MarketDbContext(string nameOrConnectionString) :
                base(nameOrConnectionString)
        {
            Configure();
        }

        /// <summary>
        /// Initialize a new MarketDbContext object.
        /// </summary>
        public MarketDbContext(DbConnection existingConnection, bool contextOwnsConnection) :
                base(existingConnection, contextOwnsConnection)
        {
            Configure();
        }

        /// <summary>
        /// Initialize a new MarketDbContext object.
        /// </summary>
        public MarketDbContext(ObjectContext objectContext, bool dbContextOwnsObjectContext) :
                base(objectContext, dbContextOwnsObjectContext)
        {
            Configure();
        }

        /// <summary>
        /// Initialize a new MarketDbContext object.
        /// </summary>
        public MarketDbContext(string nameOrConnectionString, DbCompiledModel model) :
                base(nameOrConnectionString, model)
        {
            Configure();
        }

        /// <summary>
        /// Initialize a new MarketDbContext object.
        /// </summary>
        public MarketDbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection) :
                base(existingConnection, model, contextOwnsConnection)
        {
            Configure();
        }

        private void Configure()
        {
            this.Configuration.AutoDetectChangesEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.ValidateOnSaveEnabled = true;
        }


        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Market.Mapping.DocAmendConfiguration());
            modelBuilder.Configurations.Add(new Market.Mapping.DetailConfiguration());
            modelBuilder.Configurations.Add(new Market.Mapping.DocsToDetailsConfiguration());
            modelBuilder.Configurations.Add(new Market.Mapping.RolesToPermissionsConfiguration());
            modelBuilder.Configurations.Add(new Market.Mapping.RoleConfiguration());
            modelBuilder.Configurations.Add(new Market.Mapping.PermissionConfiguration());
            modelBuilder.Configurations.Add(new Market.Mapping.PayMethodConfiguration());
            modelBuilder.Configurations.Add(new Market.Mapping.StatusConfiguration());
            modelBuilder.Configurations.Add(new Market.Mapping.CommentConfiguration());
            modelBuilder.Configurations.Add(new Market.Mapping.UsersToPermissonsConfiguration());
            modelBuilder.Configurations.Add(new Market.Mapping.BudgetItemConfiguration());
            modelBuilder.Configurations.Add(new Market.Mapping.UserConfiguration());
            modelBuilder.Configurations.Add(new Market.Mapping.ProviderConfiguration());
            modelBuilder.Configurations.Add(new Market.Mapping.CompanyConfiguration());

            CustomizeMapping(modelBuilder);
        }

        partial void CustomizeMapping(DbModelBuilder modelBuilder);

        public virtual DbSet<DocAmend> DocAmends { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<DocsToDetails> DocsToDetails { get; set; }
        public virtual DbSet<RolesToPermissions> RolesToPermissions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PayMethod> PayMethods { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<UsersToPermissons> UsersToPermissons { get; set; }
        public virtual DbSet<BudgetItem> BudgetItems { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Company> Companies { get; set; }

        [NonSerialized]
        private static volatile MarketDbContext _instance;
        [NonSerialized]
        private static readonly object syncRoot = new object();
        //private AuthCache() { }
        public static MarketDbContext GetInstance()
        {
	        if (_instance == null)
		        lock (syncRoot)
			        if (_instance == null)
			        {
				        MarketDbContext context = new MarketDbContext();
				        _instance = context;
			        }

	        return _instance;
        }
    }
}
