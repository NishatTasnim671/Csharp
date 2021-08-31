using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFishFarming3.io
{
    interface ISensorIO
    {
        void showError(String err);
        void showMessage(string msg);
    }
}
