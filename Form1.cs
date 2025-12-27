using Microsoft.Win32;
using System.Diagnostics;
using NAudio;
using CoreAudio;
namespace MehmetinButonu
{
    public partial class Form1 : Form
    {
        public string dark_theme = @"%windir%\Resources\Themes\dark.theme";
        public string light_theme = @"%windir%\Resources\Themes\aero.theme";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setTheme();
        }

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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int sayi = trackBar1.Value;
            label1.Text = sayi.ToString();
            setVolume(sayi);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Minimum = 0;
            trackBar1.Maximum = 100;

            trackBar1.Value = 50;


        }

        public void setVolume(int volume)
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            var device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            device.AudioEndpointVolume.MasterVolumeLevelScalar = volume / 100.0f;

        }
    }
}
