using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace controller_panel
{
    public partial class ScalableHeaderUserControl : UserControl
    {
        public ScalableHeaderUserControl()
        {
            InitializeComponent();
            labelAdd.Click += onClickAdd;
        }

        private void onClickAdd(object sender, EventArgs e)
        {
            if(Parent is FlowLayoutPanel flowLayoutPanel) 
            { 
                flowLayoutPanel.Controls.Add(new EffectsGroupUserControl
                {
                    Width= flowLayoutPanel.Width - SystemInformation.VerticalScrollBarWidth,

                });
            }
        }
    }
}
