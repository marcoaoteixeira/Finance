using System.Collections.Generic;
using System.Linq;

namespace Finance.Core.Entities {

    public sealed class Entry : EntityBase {

        #region Public Properties

        public string Description { get; set; }
        public decimal Value => Payments.Sum(_ => _.Value);
        public ISet<Payment> Payments { get; } = new HashSet<Payment>();

        #endregion Public Properties
    }
}