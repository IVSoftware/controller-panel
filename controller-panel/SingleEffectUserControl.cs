using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace controller_panel
{
    public partial class SingleEffectUserControl : UserControl
    {
        public SingleEffectUserControl()
        {
            InitializeComponent();
            comboBoxDevices.SelectedIndex = 0;
            comboBoxEffects.SelectedIndex = 0;
        }
    }
}
