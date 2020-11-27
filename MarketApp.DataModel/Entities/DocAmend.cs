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
    public partial class DocAmend
    {

        public DocAmend()
        {
	        this.CreatedDate = DateTime.UtcNow;
	        this.DeletedDate = null;
	        this.Id = Guid.NewGuid().ToString();
            this.DocToDetails = new List<DocsToDetails>();
            OnCreated();
        }

        #region Properties

        public virtual string Id { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual DateTime? DeletedDate { get; set; }
        public virtual DateTime RegDate { get; set; }
        public virtual string CommentId { get; set; }
        public virtual string StatusId { get; set; }
        public virtual decimal CompanyId { get; set; }
        public virtual decimal ProviderId { get; set; }
        public virtual string PayMethodId { get; set; }
        public virtual DateTime? PayedDate { get; set; }
        public virtual bool HasOriginal { get; set; }
		public virtual decimal IdUserCreator { get; set; }

		#endregion

		#region Navigation Properties

		public virtual Comment Comment { get; set; }
        public virtual Status DocStatus { get; set; }
        public virtual PayMethod PayMethod { get; set; }
        public virtual List<DocsToDetails> DocToDetails { get; set; }
        public virtual Company Company { get; set; }
        public virtual Provider Provider { get; set; }
		public virtual User UserCreator { get; set; }

		#endregion

		#region Extensibility Method Definitions

		partial void OnCreated();

        #endregion
    }

}