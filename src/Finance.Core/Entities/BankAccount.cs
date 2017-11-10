namespace Finance.Core.Entities {

    public sealed class BankAccount : EntityBase {

        #region Public Properties

        public string Holder { get; set; }
        public Bank Bank { get; set; }
        public string AgencyNumber { get; set; }
        public string AccountNumber { get; set; }

        #endregion Public Properties

        #region Public Methods

        public bool Equals(BankAccount obj) {
            return obj != null &&
                   obj.Holder == Holder &&
                   obj.Bank == Bank &&
                   obj.AgencyNumber == AgencyNumber &&
                   obj.AccountNumber == AccountNumber;
        }

        #endregion Public Methods

        #region Public Override Methods

        public override bool Equals(object obj) {
            return Equals(obj as BankAccount);
        }

        public override int GetHashCode() {
            var hash = 13;
            unchecked {
                hash += (Holder ?? string.Empty).GetHashCode() * 7;
                hash += (Bank != null ? Bank.GetHashCode() : 0) * 7;
                hash += (AgencyNumber ?? string.Empty).GetHashCode() * 7;
                hash += (AccountNumber ?? string.Empty).GetHashCode() * 7;
            }
            return hash;
        }

        #endregion Public Override Methods
    }
}