namespace Finance.Core.Entities {

    public sealed class DebitCard : EntityBase {

        #region Public Properties

        public BankAccount BankAccount { get; set; }

        #endregion Public Properties

        #region Public Methods

        public bool Equals(DebitCard obj) {
            return obj != null &&
                   obj.BankAccount == BankAccount;
        }

        #endregion Public Methods

        #region Public Override Methods

        public override bool Equals(object obj) {
            return Equals(obj as DebitCard);
        }

        public override int GetHashCode() {
            var hash = 13;
            unchecked {
                hash += (BankAccount != null ? BankAccount.GetHashCode() : 0) * 7;
            }
            return hash;
        }

        #endregion Public Override Methods
    }
}