namespace SilenceWindowsFormsApplication
{
    partial class SilenceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SilenceForm));
            this.playButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.forwardButton = new System.Windows.Forms.Button();
            this.rewindButton = new System.Windows.Forms.Button();
            this.playlistBox = new System.Windows.Forms.ListBox();
            this.volBar = new System.Windows.Forms.TrackBar();
            this.seekBar = new System.Windows.Forms.TrackBar();
            this.loadButton = new System.Windows.Forms.Button();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.songTimer = new System.Windows.Forms.Timer(this.components);
            this.songDurationLabel = new System.Windows.Forms.Label();
            this.delButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.muteCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.clearPlaylistButton = new System.Windows.Forms.Button();
            this.loadPlaylistButton = new System.Windows.Forms.Button();
            this.playlistDialog = new System.Windows.Forms.OpenFileDialog();
            this.Play = new System.Windows.Forms.ToolTip(this.components);
            this.Pause = new System.Windows.Forms.ToolTip(this.components);
            this.Stop = new System.Windows.Forms.ToolTip(this.components);
            this.Forward = new System.Windows.Forms.ToolTip(this.components);
            this.Rewind = new System.Windows.Forms.ToolTip(this.components);
            this.Add_to_Playlist = new System.Windows.Forms.ToolTip(this.components);
            this.Remove_from_Playlist = new System.Windows.Forms.ToolTip(this.components);
            this.Save_Playlist = new System.Windows.Forms.ToolTip(this.components);
            this.Clear_Playlist = new System.Windows.Forms.ToolTip(this.components);
            this.Open_playlist = new System.Windows.Forms.ToolTip(this.components);
            this.instructionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.volBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seekBar)).BeginInit();
            this.SuspendLayout();
            // 
            // playButton
            // 
            resources.ApplyResources(this.playButton, "playButton");
            this.playButton.Name = "playButton";
            this.Play.SetToolTip(this.playButton, resources.GetString("playButton.ToolTip"));
            this.Pause.SetToolTip(this.playButton, resources.GetString("playButton.ToolTip1"));
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // pauseButton
            // 
            resources.ApplyResources(this.pauseButton, "pauseButton");
            this.pauseButton.Name = "pauseButton";
            this.Rewind.SetToolTip(this.pauseButton, resources.GetString("pauseButton.ToolTip"));
            this.Pause.SetToolTip(this.pauseButton, resources.GetString("pauseButton.ToolTip1"));
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // stopButton
            // 
            resources.ApplyResources(this.stopButton, "stopButton");
            this.stopButton.Name = "stopButton";
            this.Rewind.SetToolTip(this.stopButton, resources.GetString("stopButton.ToolTip"));
            this.Stop.SetToolTip(this.stopButton, resources.GetString("stopButton.ToolTip1"));
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // forwardButton
            // 
            resources.ApplyResources(this.forwardButton, "forwardButton");
            this.forwardButton.Name = "forwardButton";
            this.Forward.SetToolTip(this.forwardButton, resources.GetString("forwardButton.ToolTip"));
            this.Pause.SetToolTip(this.forwardButton, resources.GetString("forwardButton.ToolTip1"));
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // rewindButton
            // 
            this.rewindButton.FlatAppearance.BorderSize = 0;
            this.rewindButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.rewindButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.rewindButton, "rewindButton");
            this.rewindButton.Name = "rewindButton";
            this.Rewind.SetToolTip(this.rewindButton, resources.GetString("rewindButton.ToolTip"));
            this.rewindButton.UseVisualStyleBackColor = true;
            this.rewindButton.Click += new System.EventHandler(this.rewindButton_Click);
            // 
            // playlistBox
            // 
            this.playlistBox.AllowDrop = true;
            resources.ApplyResources(this.playlistBox, "playlistBox");
            this.playlistBox.BackColor = System.Drawing.Color.White;
            this.playlistBox.ForeColor = System.Drawing.Color.Black;
            this.playlistBox.FormattingEnabled = true;
            this.playlistBox.Name = "playlistBox";
            this.playlistBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.playlistBox_MouseDoubleClick);
            this.playlistBox.SelectedIndexChanged += new System.EventHandler(this.playlistBox_SelectedIndexChanged);
            this.playlistBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.playlistBox_KeyPress);
            // 
            // volBar
            // 
            this.volBar.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.volBar, "volBar");
            this.volBar.Maximum = 0;
            this.volBar.Minimum = -7500;
            this.volBar.Name = "volBar";
            this.volBar.Scroll += new System.EventHandler(this.volBar_Scroll);
            // 
            // seekBar
            // 
            this.seekBar.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.seekBar, "seekBar");
            this.seekBar.Maximum = 10000;
            this.seekBar.Name = "seekBar";
            this.seekBar.Scroll += new System.EventHandler(this.seekBar_Scroll_1);
            // 
            // loadButton
            // 
            resources.ApplyResources(this.loadButton, "loadButton");
            this.loadButton.Name = "loadButton";
            this.Rewind.SetToolTip(this.loadButton, resources.GetString("loadButton.ToolTip"));
            this.Add_to_Playlist.SetToolTip(this.loadButton, resources.GetString("loadButton.ToolTip1"));
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // openDialog
            // 
            this.openDialog.AddExtension = false;
            resources.ApplyResources(this.openDialog, "openDialog");
            this.openDialog.Multiselect = true;
            // 
            // songTimer
            // 
            this.songTimer.Enabled = true;
            this.songTimer.Interval = 1000;
            this.songTimer.Tick += new System.EventHandler(this.songTimer_Tick);
            // 
            // songDurationLabel
            // 
            resources.ApplyResources(this.songDurationLabel, "songDurationLabel");
            this.songDurationLabel.BackColor = System.Drawing.Color.White;
            this.songDurationLabel.Name = "songDurationLabel";
            // 
            // delButton
            // 
            resources.ApplyResources(this.delButton, "delButton");
            this.delButton.Name = "delButton";
            this.Rewind.SetToolTip(this.delButton, resources.GetString("delButton.ToolTip"));
            this.Remove_from_Playlist.SetToolTip(this.delButton, resources.GetString("delButton.ToolTip1"));
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // muteCheckBox
            // 
            resources.ApplyResources(this.muteCheckBox, "muteCheckBox");
            this.muteCheckBox.BackColor = System.Drawing.Color.White;
            this.muteCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.muteCheckBox.Name = "muteCheckBox";
            this.muteCheckBox.UseVisualStyleBackColor = false;
            this.muteCheckBox.CheckedChanged += new System.EventHandler(this.muteCheckBox_CheckedChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.Rewind.SetToolTip(this.saveButton, resources.GetString("saveButton.ToolTip"));
            this.Save_Playlist.SetToolTip(this.saveButton, resources.GetString("saveButton.ToolTip1"));
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // saveDialog
            // 
            this.saveDialog.CheckPathExists = false;
            this.saveDialog.FileName = "Playlist.pl";
            resources.ApplyResources(this.saveDialog, "saveDialog");
            this.saveDialog.RestoreDirectory = true;
            // 
            // clearPlaylistButton
            // 
            resources.ApplyResources(this.clearPlaylistButton, "clearPlaylistButton");
            this.clearPlaylistButton.Name = "clearPlaylistButton";
            this.Rewind.SetToolTip(this.clearPlaylistButton, resources.GetString("clearPlaylistButton.ToolTip"));
            this.Clear_Playlist.SetToolTip(this.clearPlaylistButton, resources.GetString("clearPlaylistButton.ToolTip1"));
            this.clearPlaylistButton.UseVisualStyleBackColor = true;
            this.clearPlaylistButton.Click += new System.EventHandler(this.clearPlaylistButton_Click);
            // 
            // loadPlaylistButton
            // 
            resources.ApplyResources(this.loadPlaylistButton, "loadPlaylistButton");
            this.loadPlaylistButton.Name = "loadPlaylistButton";
            this.Rewind.SetToolTip(this.loadPlaylistButton, resources.GetString("loadPlaylistButton.ToolTip"));
            this.Open_playlist.SetToolTip(this.loadPlaylistButton, resources.GetString("loadPlaylistButton.ToolTip1"));
            this.loadPlaylistButton.UseVisualStyleBackColor = true;
            this.loadPlaylistButton.Click += new System.EventHandler(this.loadPlaylistButton_Click);
            // 
            // playlistDialog
            // 
            resources.ApplyResources(this.playlistDialog, "playlistDialog");
            // 
            // Play
            // 
            this.Play.BackColor = System.Drawing.Color.Transparent;
            // 
            // Pause
            // 
            this.Pause.BackColor = System.Drawing.Color.White;
            // 
            // Stop
            // 
            this.Stop.BackColor = System.Drawing.Color.White;
            this.Stop.ForeColor = System.Drawing.Color.Black;
            // 
            // Forward
            // 
            this.Forward.BackColor = System.Drawing.Color.White;
            // 
            // Rewind
            // 
            this.Rewind.BackColor = System.Drawing.Color.White;
            // 
            // Add_to_Playlist
            // 
            this.Add_to_Playlist.BackColor = System.Drawing.Color.White;
            // 
            // Remove_from_Playlist
            // 
            this.Remove_from_Playlist.BackColor = System.Drawing.Color.White;
            // 
            // Save_Playlist
            // 
            this.Save_Playlist.BackColor = System.Drawing.Color.White;
            // 
            // Clear_Playlist
            // 
            this.Clear_Playlist.BackColor = System.Drawing.Color.White;
            // 
            // Open_playlist
            // 
            this.Open_playlist.BackColor = System.Drawing.Color.White;
            // 
            // instructionButton
            // 
            resources.ApplyResources(this.instructionButton, "instructionButton");
            this.instructionButton.Name = "instructionButton";
            this.Rewind.SetToolTip(this.instructionButton, resources.GetString("instructionButton.ToolTip"));
            this.Clear_Playlist.SetToolTip(this.instructionButton, resources.GetString("instructionButton.ToolTip1"));
            this.instructionButton.UseVisualStyleBackColor = true;
            this.instructionButton.Click += new System.EventHandler(this.instructionButton_Click);
            // 
            // SilenceForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.instructionButton);
            this.Controls.Add(this.loadPlaylistButton);
            this.Controls.Add(this.clearPlaylistButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.muteCheckBox);
            this.Controls.Add(this.seekBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.songDurationLabel);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.playlistBox);
            this.Controls.Add(this.rewindButton);
            this.Controls.Add(this.forwardButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.volBar);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "SilenceForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SilenceForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.volBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seekBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button rewindButton;
        private System.Windows.Forms.TrackBar volBar;
        private System.Windows.Forms.TrackBar seekBar;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.Timer songTimer;
        private System.Windows.Forms.Label songDurationLabel;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox muteCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.Button clearPlaylistButton;
        private System.Windows.Forms.Button loadPlaylistButton;
        private System.Windows.Forms.OpenFileDialog playlistDialog;
        public System.Windows.Forms.ListBox playlistBox;
        private System.Windows.Forms.ToolTip Play;
        private System.Windows.Forms.ToolTip Pause;
        private System.Windows.Forms.ToolTip Stop;
        private System.Windows.Forms.ToolTip Forward;
        private System.Windows.Forms.ToolTip Rewind;
        private System.Windows.Forms.ToolTip Add_to_Playlist;
        private System.Windows.Forms.ToolTip Remove_from_Playlist;
        private System.Windows.Forms.ToolTip Save_Playlist;
        private System.Windows.Forms.ToolTip Clear_Playlist;
        private System.Windows.Forms.ToolTip Open_playlist;
        private System.Windows.Forms.Button instructionButton;




    }
}

