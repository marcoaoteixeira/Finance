using System;

namespace Finance.Core.Entities {

    public sealed class CreditCard : EntityBase {

        #region Public Properties

        public string Holder { get; set; }

        public string LastFourDigits { get; set; }

        public CreditCardFlag Flag { get; set; }

        public DateTime ExpirationDate { get; set; }

        #endregion Public Properties

        #region Public Methods

        public bool Equals(CreditCard obj) {
            return obj != null &&
                   obj.Holder == Holder &&
                   obj.LastFourDigits == LastFourDigits &&
                   obj.Flag == Flag;
        }

        #endregion Public Methods

        #region Public Override Methods

        public override bool Equals(object obj) {
            return Equals(obj as CreditCard);
        }

        public override int GetHashCode() {
            var hash = 13;
            unchecked {
                hash += (Holder ?? string.Empty).GetHashCode() * 7;
                hash += (LastFourDigits ?? string.Empty).GetHashCode() * 7;
                hash += (Flag != null ? Flag.GetHashCode() : 0) * 7;
            }
            return hash;
        }

        #endregion Public Override Methods
    }
}