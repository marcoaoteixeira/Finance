using Finance.Core.Properties;
using Nameless.WinFormsApplication;

namespace Finance.Core.Entities {

    public enum PaymentType : int {

        [Description(ResourceKey = "CreditCart", ResourceType = typeof(Resources))]
        CreditCard,

        [Description(ResourceKey = "DebitCart", ResourceType = typeof(Resources))]
        DebitCard,

        [Description(ResourceKey = "Cash", ResourceType = typeof(Resources))]
        Cash,

        [Description(ResourceKey = "BankSlip", ResourceType = typeof(Resources))]
        BankSlip,

        [Description(ResourceKey = "BankCheck", ResourceType = typeof(Resources))]
        BankCheck,

        [Description(ResourceKey = "AccountTransfer", ResourceType = typeof(Resources))]
        AccountTransfer
    }
}