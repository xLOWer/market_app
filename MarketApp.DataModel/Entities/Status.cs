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
    public partial class Status
    {

        public Status()
        {
            this.DocAmends = new List<DocAmend>();
            OnCreated();
        }

        #region Properties

        public virtual string Id { get; set; }

        public virtual global::System.DateTime CreatedDate { get; set; }

        public virtual global::System.DateTime? DeletedDate { get; set; }

        public virtual string Name { get; set; }

        public virtual decimal Order { get; set; }

        #endregion

        #region Navigation Properties

        public virtual List<DocAmend> DocAmends { get; set; }

        #endregion

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}