namespace Finance.Core.Entities {

    public sealed class Bank : EntityBase {

        #region Public Properties

        public string Name { get; set; }

        #endregion Public Properties

        #region Public Methods

        public bool Equals(Bank obj) {
            return obj != null &&
                   obj.Name == Name;
        }

        #endregion Public Methods

        #region Public Override Methods

        public override bool Equals(object obj) {
            return Equals(obj as Bank);
        }

        public override int GetHashCode() {
            var hash = 13;
            unchecked {
                hash += (Name ?? string.Empty).GetHashCode() * 7;
            }
            return hash;
        }

        #endregion Public Override Methods
    }
}