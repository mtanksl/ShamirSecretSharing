using System;
using System.Windows.Forms;

namespace mtanksl.ShamirSecretSharing.GUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.Run(new MainForm() );
        }
    }
}