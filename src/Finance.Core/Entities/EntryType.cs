using Finance.Core.Properties;
using Nameless.WinFormsApplication;

namespace Finance.Core.Entities {

    public enum EntryType : int {
        [Description(ResourceKey = "Debit", ResourceType = typeof(Resources))]
        Debit,
        [Description(ResourceKey = "Credit", ResourceType = typeof(Resources))]
        Credit
    }
}