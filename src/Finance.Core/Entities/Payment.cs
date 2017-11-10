using System;

namespace Finance.Core.Entities {

    public abstract class Payment : EntityBase {

        #region Public Abstract Properties

        public abstract PaymentType Type { get; }

        #endregion Public Abstract Properties

        #region Public Properties

        public decimal Value { get; set; }
        public DateTime OccurenceDate { get; set; }
        public bool PaidOut { get; set; }

        #endregion Public Properties
    }

    public sealed class CreditCardPayment : Payment {

        #region Public Override Properties

        public override PaymentType Type => PaymentType.CreditCard;

        #endregion Public Override Properties

        #region Public Properties

        public CreditCard CreditCard { get; set; }

        #endregion Public Properties
    }

    public sealed class DebitCardPayment : Payment {

        #region Public Override Properties

        public override PaymentType Type => PaymentType.DebitCard;

        #endregion Public Override Properties

        #region Public Properties

        public DebitCard DebitCard { get; set; }

        #endregion Public Properties
    }

    public sealed class CashPayment : Payment {

        #region Public Override Properties

        public override PaymentType Type => PaymentType.Cash;

        #endregion Public Override Properties
    }

    public sealed class BankSlipPayment : Payment {

        #region Public Override Properties

        public override PaymentType Type => PaymentType.BankSlip;

        #endregion Public Override Properties

        #region Public Properties

        public string Number { get; set; }

        public Bank Bank { get; set; }

        #endregion Public Properties
    }

    public sealed class BankCheckPayment : Payment {

        #region Public Override Properties

        public override PaymentType Type => PaymentType.BankCheck;

        #endregion Public Override Properties

        #region Public Properties

        public string Number { get; set; }

        public Bank Bank { get; set; }

        #endregion Public Properties
    }

    public sealed class AccountTransferPayment : Payment {

        #region Public Override Properties

        public override PaymentType Type => PaymentType.AccountTransfer;

        #endregion Public Override Properties

        #region Public Properties

        public BankAccount From { get; set; }

        public BankAccount To { get; set; }

        #endregion Public Properties
    }
}