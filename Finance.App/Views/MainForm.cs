using System.Windows.Forms;
using Finance.App.Code;
using Nameless.WinFormsApplication;

namespace Finance.App.Views {

    public partial class MainForm : Form {
        #region Private Read-Only Fields

        private readonly IFormManager _formManager;

        #endregion

        #region Public Constructors

        public MainForm(IFormManager formManager) {
            Prevent.ParameterNull(formManager, nameof(formManager));

            _formManager = formManager;

            InitializeComponent();
        }

        #endregion Public Constructors
    }
}