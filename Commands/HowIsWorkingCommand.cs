
namespace Knv.DAQ.Commands
{
   using Properties;
    using System;
    using System.Diagnostics;
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

            /*
            var hiw = new HowIsWorkingForm();
            
            hiw.ShowDialog();
            */

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "C:\\Windows\\System32\\mshta.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = $"{Application.StartupPath}\\Help\\index.html";

            // Start the process with the info we specified.
            // Call WaitForExit and then the using statement will close.
            using (Process exeProcess = Process.Start(startInfo))
            {
                exeProcess.WaitForExit();
            }
        }
    }
}
