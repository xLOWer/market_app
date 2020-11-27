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

namespace MarketApp.DataModel.Market
{
    public partial class User
    {

        public User()
        {
            this.UserToPerms = new List<UsersToPermissons>();
            OnCreated();
        }

        #region Properties

        public virtual decimal Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string Fio { get; set; }

        #endregion

        #region Navigation Properties

        public virtual List<UsersToPermissons> UserToPerms { get; set; }		
		public virtual List<DocAmend> Docs { get; set; }

		#endregion

		#region Extensibility Method Definitions

		partial void OnCreated();

        #endregion
    }

}