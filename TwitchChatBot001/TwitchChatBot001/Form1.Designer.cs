namespace TwitchChatBot001
{
    partial class Form1
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblServer = new System.Windows.Forms.Label();
            this.rtbRoom = new System.Windows.Forms.RichTextBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.rtbServer = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServer.Location = new System.Drawing.Point(13, 13);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(55, 18);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "Server:";
            // 
            // rtbRoom
            // 
            this.rtbRoom.DetectUrls = false;
            this.rtbRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbRoom.Location = new System.Drawing.Point(629, 34);
            this.rtbRoom.Name = "rtbRoom";
            this.rtbRoom.ReadOnly = true;
            this.rtbRoom.Size = new System.Drawing.Size(443, 606);
            this.rtbRoom.TabIndex = 1;
            this.rtbRoom.Text = "";
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoom.Location = new System.Drawing.Point(626, 13);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(54, 18);
            this.lblRoom.TabIndex = 2;
            this.lblRoom.Text = "Room:";
            // 
            // rtbServer
            // 
            this.rtbServer.DetectUrls = false;
            this.rtbServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbServer.Location = new System.Drawing.Point(16, 34);
            this.rtbServer.Name = "rtbServer";
            this.rtbServer.ReadOnly = true;
            this.rtbServer.Size = new System.Drawing.Size(443, 606);
            this.rtbServer.TabIndex = 3;
            this.rtbServer.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 682);
            this.Controls.Add(this.rtbServer);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.rtbRoom);
            this.Controls.Add(this.lblServer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.RichTextBox rtbRoom;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.RichTextBox rtbServer;
    }
}

