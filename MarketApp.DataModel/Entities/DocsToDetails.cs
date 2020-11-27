using System;

namespace MarketApp.DataModel.Market
{
	public partial class DocsToDetails
    {
        public DocsToDetails()
        {
	        Id = Guid.NewGuid().ToString();
	        CreatedDate = DateTime.UtcNow;
            OnCreated();
        }

        #region Properties

        public virtual string Id { get; set; }
        public virtual global::System.DateTime CreatedDate { get; set; }
        public virtual global::System.DateTime? DeletedDate { get; set; }
        public virtual string IdDetail { get; set; }
        public virtual string IdDoc { get; set; }

		#endregion

		#region Navigation Properties

		public virtual DocAmend DocAmend { get; set; }
        public virtual Detail Detail { get; set; }

		#endregion

		#region Extensibility Method Definitions

		partial void OnCreated();

        #endregion
    }

}
