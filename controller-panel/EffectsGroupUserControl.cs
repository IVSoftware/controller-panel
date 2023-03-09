using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace controller_panel
{
    public partial class EffectsGroupUserControl : UserControl
    {
        public EffectsGroupUserControl()
        {
            InitializeComponent();
            labelAdd.Click += onClickAdd;
            labelTiming.Click += onClickTiming;
            Controls.Add(_timeEditorControl);
            _timeEditorControl.KeyDown += onKeyDownTimeEditor;
        }

        private void onClickAdd(object sender, EventArgs e)
        {
            SingleEffectUserControl effect = new SingleEffectUserControl
            {
                Anchor = (AnchorStyles)0xF,
            };
            
            tableLayoutPanel.Controls.Add(effect, 3, _effects.Count);
            tableLayoutPanel.SetColumnSpan(effect, 9);
            _effects.Add(effect);
        }
        private List<SingleEffectUserControl> _effects = new List<SingleEffectUserControl>();

        MaskedTextBox _timeEditorControl = new MaskedTextBox()
        {
            Mask = "00:00:000",
            Font = new Font("Segoe UI", 12),
        };

        private void onClickTiming(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                _timeEditorControl.Tag = control;
                _timeEditorControl.Location = control.Location;
                _timeEditorControl.Show();
                _timeEditorControl.BringToFront();
                _timeEditorControl.Focus();
            }
        }

        private void onKeyDownTimeEditor(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_timeEditorControl.Tag is Control control)
                {
                    control.Text = _timeEditorControl.Text;
                }
                _timeEditorControl.Hide();
            }
        }
    }
}
