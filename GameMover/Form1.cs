using Gameloop.Vdf;
using Gameloop.Vdf.Linq;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace GameMover
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            FillDropDownList(cb_Source);
        }

        public void FillDropDownList(ComboBox _comboBox)
        {
            _comboBox.Items.Clear();

           DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (var d in drives)
            {
               DirectoryInfo drive = d.RootDirectory;
               string driveletter = drive.Root.ToString();
               if(Directory.Exists(driveletter + @"Steam"))
                {
                    _comboBox.Items.Add(driveletter + @"Steam");


                }
                else if (Directory.Exists(driveletter + @"SteamLibrary"))
                {
                    _comboBox.Items.Add(driveletter + @"SteamLibrary");


                }
                else if (Directory.Exists(driveletter + @"Programmer (x86)\\Steam"))
                {
                    _comboBox.Items.Add(driveletter + @"Programmer (x86)\\Steam");


                }

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDropDownList(cb_Dest);
            cb_Dest.Items.Remove(cb_Source.Text);

            cb_Game.Items.Clear();

            string[] acffiles = Directory.GetFiles(cb_Source.Text + "\\SteamApps", "*.acf");
            foreach (string file in acffiles)
            {
                VProperty volvo = VdfConvert.Deserialize(File.ReadAllText(file));
                string game = volvo.Value["installdir"].ToString();

                ComboboxItem comboboxItem = new ComboboxItem();
                comboboxItem.Text = game;
                comboboxItem.Value = file;
                cb_Game.Items.Add(comboboxItem);
            }

            cb_Game.Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_Dest.Enabled = true;
        }

        private void btnMoveGame_Click(object sender, EventArgs e)
        {
            

            cb_Source.Enabled = false;
            cb_Game.Enabled = false;
            cb_Dest.Enabled = false;
            btnMoveGame.Enabled = false;

            ComboboxItem comboboxItem = (ComboboxItem)cb_Game.SelectedItem;

            DirectoryInfo di = Directory.CreateDirectory(cb_Source.Text + "\\steamapps\\common\\" + comboboxItem.Text);
            long foldersize = DirSize(di);
            long freespace = GetTotalFreeSpace(Directory.GetDirectoryRoot(cb_Dest.Text));

            if (foldersize <= freespace)
            {
                int fileCount = Directory.GetFiles(cb_Source.Text + "\\steamapps\\common\\" + comboboxItem.Text, "*.*", SearchOption.AllDirectories).Length;

                progressBar1.Maximum = fileCount;
                label4.Text = "0/" + fileCount;



                string combobox1s = cb_Source.Text;
                string combobox3s = cb_Dest.Text;
                Thread t = new Thread(() => DoCopyWork(combobox1s, combobox3s, comboboxItem));
                t.Start();

            }
            else
            {
                MessageBox.Show("Not enough free space on destination drive!");
                cb_Source.Enabled = true;
                cb_Game.Enabled = true;
                cb_Dest.Enabled = true;
                btnMoveGame.Enabled = true;
            }






        }

        private long GetTotalFreeSpace(string driveName)
        { 
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == driveName)
                {
                    return drive.TotalFreeSpace;
                }
            }
            return -1;
        }

        public long DirSize(DirectoryInfo d)
        {
            long size = 0;

            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }

            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }
            return size;
        }

        public void DoCopyWork(string _source, string _dest, ComboboxItem _comboboxItem)
        {


            File.Copy(_comboboxItem.Value, _dest + "\\steamapps\\" + Path.GetFileName(_comboboxItem.Value), true);



            Copy(_source + "\\steamapps\\common\\" + _comboboxItem.Text, _dest + "\\steamapps\\common\\" + _comboboxItem.Text);



            Directory.Delete(_source + "\\steamapps\\common\\" + _comboboxItem.Text, true);
            File.Delete(_comboboxItem.Value);

            MessageBox.Show("Done!");

            Invoke(new Action(() =>
            {
                cb_Source.Enabled = true;
                cb_Game.Enabled = true;
                cb_Dest.Enabled = true;
                btnMoveGame.Enabled = true;
            }));

        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnMoveGame.Enabled = true;
        }

        public void Copy(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            

            Directory.CreateDirectory(target.FullName);

            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);


                Invoke(new Action(() =>
                {
                    progressBar1.Value++;
                    label4.Text = progressBar1.Value + "/" + progressBar1.Maximum + " file(s) copied";
                }));

            }

            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
