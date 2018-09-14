namespace WindowServiceDemo
{
    partial class NotificationService
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.timer = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timer)).BeginInit();
            // 
            // eventLog1
            // 
            this.eventLog1.Log = "Application";
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1500D;
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Elapsed);
            // 
            // NotificationService
            // 
            this.ServiceName = "NotificationService";
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timer)).EndInit();

        }

        #endregion

        private System.Diagnostics.EventLog eventLog1;
        private System.IO.FileSystemWatcher fileSystemWatcher;
        private System.Timers.Timer timer;
    }
}
