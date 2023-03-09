What you do with this is a matter of programming style, but what I see here are three custom `UserControl` for **header**, **group** and **effect** that each contain `TableLayoutPanel` and are inserted into a `FlowLayoutPanel`.

This example is going to need some work, but this will give you the general idea.

[![main][1]][1]

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
    }


***
**Header**

[![header][2]][2]

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

***
**Effect Group**

[![group][3]][3]


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

***
**Effect**
    
[![single][4]][4]


    public partial class SingleEffectUserControl : UserControl
    {
        public SingleEffectUserControl()
        {
            InitializeComponent();
            comboBoxDevices.SelectedIndex = 0;
            comboBoxEffects.SelectedIndex = 0;
        }
    }


  [1]: https://i.stack.imgur.com/5NIUr.png
  [2]: https://i.stack.imgur.com/0XVQb.png
  [3]: https://i.stack.imgur.com/6sBD3.png
  [4]: https://i.stack.imgur.com/7CBYr.png