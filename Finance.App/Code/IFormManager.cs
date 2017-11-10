﻿using System.Windows.Forms;

namespace Finance.App.Code {

    public interface IFormManager {

        #region Methods

        TForm Get<TForm>(Form mdi = null, bool multipleInstance = true, object state = null) where TForm : Form;

        #endregion Methods
    }
}