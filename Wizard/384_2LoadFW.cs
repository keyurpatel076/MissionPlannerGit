using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MissionPlanner.Arduino;
using MissionPlanner.Controls;

namespace MissionPlanner.Wizard
{
    public partial class _384_2LoadFW : MyUserControl
    {
        Utilities.Firmware fw = new Utilities.Firmware();
        string custom_fw_dir = "";
        ProgressReporterDialogue pdr;

        public _384_2LoadFW()
        {
            InitializeComponent();
        }

        void fw_Progress(int progress, string status)
        {
            pdr.UpdateProgressAndStatus(progress, status);
        }

        private void lbl_Custom_firmware_label_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog { Filter = "Firmware (*.hex;*.px4)|*.hex;*.px4" };
            if (Directory.Exists(custom_fw_dir))
                fd.InitialDirectory = custom_fw_dir;
            fd.ShowDialog();
            if (File.Exists(fd.FileName))
            {
                custom_fw_dir = Path.GetDirectoryName(fd.FileName);

                //fw.Progress -= fw_Progress;
                fw.Progress += fw_Progress;

                BoardDetect.boards boardtype = BoardDetect.boards.none;
                try
                {
                    boardtype = BoardDetect.DetectBoard(MainV2.comPortName);
                }
                catch
                {
                    CustomMessageBox.Show("Can not connect to com port and detect board type", "Error");
                    return;
                }

                fw.UploadFlash(MainV2.comPortName, fd.FileName, boardtype);
            }
        }
    }
}
