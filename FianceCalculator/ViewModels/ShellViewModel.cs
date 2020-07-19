using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public void LoadRefiancePage()
        {
            ActivateItem(new RefianceViewModel());
        }

        public void LoadMorgagePage()
        {
            //ActivateItem();
        }
    }
}
