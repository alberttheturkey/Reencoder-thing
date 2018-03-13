using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".mp4";
            saveFileDialog1.ShowDialog();
            textBox2.Text = saveFileDialog1.FileName;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var startInfo = new ProcessStartInfo("CMD.exe");
            startInfo.Arguments = "/K ffmpeg -i \"" + textBox1.Text+"\" -c:v h264_nvenc -preset slow -qp 25 -c:a copy -map 0:v -map 0:a:0 -map 0:a:1 -map 0:a:2 -map 0:a:3 -map 0:a:4 \"" + textBox2.Text +"\"";
            
            Process proc = Process.Start(startInfo);
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.CreateNoWindow = true;


            proc.WaitForExit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
