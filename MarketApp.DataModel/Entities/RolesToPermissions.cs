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
    public partial class RolesToPermissions
    {

        public RolesToPermissions()
        {
            OnCreated();
        }

        #region Properties

        public virtual string Id { get; set; }

        public virtual global::System.DateTime CreatedDate { get; set; }

        public virtual global::System.DateTime? DeletedDate { get; set; }

        public virtual string IdRole { get; set; }

        public virtual string IdPermission { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Role Role { get; set; }
        public virtual Permission Permission { get; set; }

        #endregion

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
