using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace controller_panel
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            flowLayoutPanel.Controls.Add(
                new ScalableHeaderUserControl
                {
                    Width= flowLayoutPanel.Width - SystemInformation.VerticalScrollBarWidth,
                }
            );
            flowLayoutPanel.SizeChanged += (sender, e) =>
            { 
                foreach ( Control control in flowLayoutPanel.Controls )
                {
                    control.Width = flowLayoutPanel.Width - SystemInformation.VerticalScrollBarWidth;
                }
            };
        }
        private MediaPlayer MediaPlayer { get; } = new MediaPlayer();
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            MediaPlayer.MediaOpened += (sender, e) =>
            {
                MediaPlayer.Play();
            };
            var path = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "MP3",
                "sample-3s.mp3"
                );
            MediaPlayer.Open(new Uri(path));
        }
    }
}
