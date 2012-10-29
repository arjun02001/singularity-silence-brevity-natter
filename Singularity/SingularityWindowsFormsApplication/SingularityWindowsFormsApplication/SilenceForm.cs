using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.AudioVideoPlayback;
using System.IO;
using System.Windows.Documents;


namespace SilenceWindowsFormsApplication
{
    public partial class SilenceForm : Form
    {
        Audio myAudio;
        string song=string.Empty, newSong=string.Empty;
        bool flag = true, remove=false;
        List<string> myFileName = new List<string>();
        string[] filename = new string[10];
        public SilenceForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        void songLoad()
        {
            string s1 = string.Empty;
            int i = myFileName.Count - 1;
            while (i >=0)
            {
                s1 = myFileName[i].ToString();
                if (s1.EndsWith(playlistBox.SelectedItem.ToString()))
                {
                    song = s1;
                    break;
                }
                i--;
            }
            if (flag)
            {
                newSong = song;
                flag = false;
            }
        }
        string ConvertToMin(double time)
        {
            int min, sec;
            string smin, ssec, stime;
            min = (int)time / 60;
            sec = (int)time % 60;
            smin = Convert.ToString(min);
            ssec = Convert.ToString(sec);
            if (ssec.Length == 1)
                ssec = "0" + ssec;
            if (smin.Length == 1)
                smin = "0" + smin;
            stime = smin + ":" + ssec;
            return stime;
        }
        public void playlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (remove != true)
                songLoad();
            else
                remove = false;
        }
        private void playSong()
        {
            try
            {
                if (playlistBox.Items.Count != 0 || (playlistBox.SelectedItem != null))
                {
                    if (myAudio != null)
                        if (!myAudio.Paused)
                        {
                            myAudio.Stop();
                            myAudio = null;
                        }
                    if (myAudio == null || song != newSong)
                    {
                        myAudio = new Audio(song);
                        newSong = song;
                    }
                    seekBar.Value = 0;
                    seekBar.Maximum = (int)myAudio.Duration + 1;
                    if (muteCheckBox.Checked == true)
                        myAudio.Volume = volBar.Minimum;
                    else
                        myAudio.Volume = volBar.Value;
                    myAudio.Play();
                }
            }
            catch(Exception)
            { }
        }
        private void play()
        {
            try
            {
                playSong();
                seekBar.Value = (int)myAudio.CurrentPosition;
                songTimer.Enabled = true;
            }
            catch (Exception)
            { }
        }
        private void pause()
        {
            try
            {
                myAudio.Pause();
                songTimer.Enabled = false;
                seekBar.Value = (int)myAudio.CurrentPosition;
            }
            catch (Exception)
            { }
        }
        private void stop()
        {
            try
            {
                myAudio.Stop();
                songTimer.Enabled = false;
                seekBar.Value = 0;
                songDurationLabel.Text = "00:00";
            }
            catch (Exception)
            { }
        }
        private void forward()
        {
            try
            {
                if (myAudio.CurrentPosition < myAudio.Duration - 5)
                {
                    myAudio.CurrentPosition += 5;
                    songDurationLabel.Text = ConvertToMin(myAudio.CurrentPosition);
                    seekBar.Value = (int)myAudio.CurrentPosition;
                }
            }
            catch (Exception)
            { }
        }
        private void rewind()
        {
            try
            {
                if (myAudio.CurrentPosition > 5)
                {
                    myAudio.CurrentPosition -= 5;
                    songDurationLabel.Text = ConvertToMin(myAudio.CurrentPosition);
                    seekBar.Value = (int)myAudio.CurrentPosition;
                }
            }
            catch (Exception)
            { }
        }
        private void add_to_playlist()
        {
            try
            {
                if (openDialog.ShowDialog() != DialogResult.Cancel)
                {
                    myFileName.AddRange(openDialog.FileNames);
                    foreach (string s in myFileName)
                    {
                        if (!playlistBox.Items.Contains(s.Substring(s.LastIndexOf('\\') + 1)))
                            playlistBox.Items.Add(s.Substring(s.LastIndexOf('\\') + 1));
                    }
                }
            }
            catch (Exception)
            { }
        }
        private void open_playlist()
        {
            try
            {
                if (playlistDialog.ShowDialog() == DialogResult.OK)
                {
                    string s1;
                    System.IO.StreamReader sr = new StreamReader(playlistDialog.FileName);
                    while ((s1 = sr.ReadLine()) != null)
                    {
                        myFileName.Add(s1);
                    }
                    foreach (string s in myFileName)
                    {
                        if (!playlistBox.Items.Contains(s.Substring(s.LastIndexOf('\\') + 1)))
                        {
                            playlistBox.Items.Add(s.Substring(s.LastIndexOf('\\') + 1));
                        }
                    }
                }
            }
            catch (Exception)
            { }
        }
        private void save_playlist()
        {
            try
            {
                if (playlistBox.Items.Count > 0)
                {
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.StreamWriter sw = new System.IO.StreamWriter(saveDialog.FileName);
                        if (myFileName != null)
                            foreach (string item in myFileName)
                                sw.WriteLine(item);
                        sw.Close();
                    }
                }
            }
            catch (Exception)
            { }
        }
        private void delete_song()
        {
            try
            {
                int index = playlistBox.SelectedIndex;
                string s1 = string.Empty, s2 = string.Empty;
                int i = myFileName.Count - 1;
                bool no_load = false;
                while (i >= 0)
                {
                    s1 = myFileName[i].ToString();
                    if (s1.EndsWith(playlistBox.Text))
                    {
                        s2 = s1;
                        myFileName.Remove(s1);
                        break;
                    }
                    i--;
                }
                remove = true;
                playlistBox.Items.Remove(playlistBox.SelectedItem);
                if (s2 == newSong)
                {
                    seekBar.Value = seekBar.Minimum;
                    songDurationLabel.Text = "00:00";
                    myAudio.Stop();
                    myAudio = null;
                    no_load = true;
                }
                if (playlistBox.Items.Count >= 0)
                {
                    if (no_load != true)
                    {
                        i = myFileName.Count - 1;
                        while (i >= 0)
                        {
                            s1 = playlistBox.Items[i].ToString();
                            if (newSong.EndsWith(s1))
                            {
                                playlistBox.SelectedItem = playlistBox.Items[i];
                                break;
                            }
                            i--;
                        }
                    }
                    else
                    {
                        if (index > playlistBox.Items.Count - 1)
                            playlistBox.SelectedIndex = 0;
                        else
                            playlistBox.SelectedIndex = index;
                        playSong();
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void clear_playlist()
        {
            try
            {
                playlistBox.Items.Clear();
                myFileName.Clear();
                myAudio.Stop();
                seekBar.Value = 0;
                songDurationLabel.Text = "00:00";
            }
            catch (Exception)
            { }
        }
        private void instructions()
        {
            Instructions ins = new Instructions();
            ins.Show();
        }
        private void playButton_Click(object sender, EventArgs e)
        {
            play();
        }
        private void pauseButton_Click(object sender, EventArgs e)
        {
            pause();
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            stop();
        }
        private void forwardButton_Click(object sender, EventArgs e)
        {
            forward();
        }
        private void loadButton_Click(object sender, EventArgs e)
        {
            add_to_playlist();
        }
        private void playlistBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            play();
        }
        private void rewindButton_Click(object sender, EventArgs e)
        {
            rewind();
        }
        private void volBar_Scroll(object sender, EventArgs e)
        {
            try
            {
                if (muteCheckBox.Checked == true)
                    myAudio.Volume = volBar.Minimum;
                else if (volBar.Value == volBar.Minimum)
                    muteCheckBox.Checked = true;
                else
                    myAudio.Volume = volBar.Value;
            }
            catch (Exception)
            { }
        }
        private void songTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (myAudio.Playing == true)
                {
                    if (myAudio.CurrentPosition == myAudio.Duration)
                    {
                        myAudio.Stop();
                        seekBar.Value = 0;
                        songDurationLabel.Text = "00:00";
                    }
                    else
                    {
                        seekBar.Value += 1;
                        songDurationLabel.Text = ConvertToMin(myAudio.CurrentPosition);
                    }
                }
                else
                {
                    if (playlistBox.Items.Count == 1)
                        playSong();
                    else
                    {
                        if (playlistBox.SelectedIndex + 1 < playlistBox.Items.Count)
                        {
                            playlistBox.SelectedIndex++;
                        }
                        else
                        {
                            playlistBox.SelectedIndex = 0;
                        }
                        playSong();
                    }
                }
            }
            catch (Exception)
            { }
        }
        private void seekBar_Scroll_1(object sender, EventArgs e)
        {
            try
            {
                myAudio.CurrentPosition = seekBar.Value;
                songDurationLabel.Text = ConvertToMin(myAudio.CurrentPosition);
            }
            catch (Exception)
            { }
        }
        private void delButton_Click(object sender, EventArgs e)
        {
            delete_song();
        }
        private void muteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (muteCheckBox.Checked == true)
                {
                    myAudio.Volume = volBar.Minimum;
                }
                else
                {
                    myAudio.Volume = volBar.Value;
                }
            }
            catch (Exception)
            { }

        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            save_playlist();
        }
        private void clearPlaylistButton_Click(object sender, EventArgs e)
        {
            clear_playlist();
        }
        private void loadPlaylistButton_Click(object sender, EventArgs e)
        {
            open_playlist();
        }
        private void playlistBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'f':
                case 'F': forward();
                    break;
                case 'r':
                case 'R': rewind();
                    break;
                case 'i':
                case 'I': add_to_playlist();
                    break;
                case 'o':
                case 'O': open_playlist();
                    break;
                case 's':
                case 'S': save_playlist();
                    break;
                case 'd':
                case 'D': delete_song();
                    break;
                case 'c':
                case 'C': clear_playlist();
                    break;
                case 'h':
                case 'H': instructions();
                    break;
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                stop();
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                play();
            }
            else if (e.KeyChar == (char)Keys.Space)
            {
                pause();
            }
        }
        private void SilenceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                myAudio.Stop();
                songTimer.Enabled = false;
                seekBar.Value = 0;
                songDurationLabel.Text = "00:00";
            }
            catch (Exception)
            { }
        }

        private void instructionButton_Click(object sender, EventArgs e)
        {
            instructions();
        }
    }
}
