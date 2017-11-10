using System;

namespace Finance.Core.Entities {

    public abstract class EntityBase {

        #region Public Properties

        public int ID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }

        #endregion Public Properties
    }
}