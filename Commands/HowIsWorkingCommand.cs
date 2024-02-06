﻿
namespace Knv.DAQ.Commands
{
   using Properties;
    using System;
    using System.Windows.Forms;
    using View;

    class HowIsWorkingCommand : ToolStripMenuItem
    {
        readonly IMainForm _mainForm;
        public HowIsWorkingCommand(IMainForm mainForm)
        {
            Image = Resources.Help_circle_outline_48;
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            Text = "How is Working?";
            _mainForm = mainForm;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if(_mainForm.AlwaysOnTop) 
                _mainForm.AlwaysOnTop = false;

            var hiw = new HowIsWorkingForm();
            
            hiw.ShowDialog();
        }
    }
}
