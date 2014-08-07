using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MissionPlanner.Controls;

namespace MissionPlanner.GCSViews.ConfigurationView
{
    public partial class ConfigWizard384 : UserControl, IActivate
    {
        public ConfigWizard384()
        {
            InitializeComponent();
        }

        private void PIC_wizard_Click(object sender, EventArgs e)
        {
            Wizard.Wizard cfg = new Wizard.Wizard(true);

            cfg.ShowDialog(this);
        }

        public void Activate()
        {
            PIC_wizard_Click(null, null);
        }
    }
}
