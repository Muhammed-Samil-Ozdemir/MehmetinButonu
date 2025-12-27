using Microsoft.Win32;
using System.Diagnostics;

namespace MehmetinButonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setTheme();
        }

        public string dark_theme = @"%windir%\Resources\Themes\dark.theme";
        public string light_theme = @"%windir%\Resources\Themes\aero.theme";

        public bool isDark(string theme)
        {
            if (theme == "dark") return true;
            return false;
        }

        public string getTheme()
        {
            string current_theme = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\";
            string theme;
            theme = (string)Registry.GetValue(current_theme, "CurrentTheme", string.Empty);
            theme = theme.Split('\\').Last().Split('.').First().ToString();

            return theme;
        }

        public void setTheme()
        {
            string theme;
            if (isDark(getTheme()))
            {
                theme = light_theme;
            }
            else
            {
                theme = dark_theme;
            }
            ProcessStartInfo cmd = new ProcessStartInfo();
            cmd.FileName = "cmd.exe";
            cmd.Arguments = "/c start " + theme;
            cmd.CreateNoWindow = true;
            cmd.UseShellExecute = false;
            Process.Start(cmd);
        }

    }
}
