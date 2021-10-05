
namespace WinFormsApp4
{
    partial class Form6
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
			this.userControl11 = new WinFormsApp4.UserControl1();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.userControl12 = new WinFormsApp4.UserControl1();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// userControl11
			// 
			this.userControl11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.userControl11.ContextMenuStrip = this.contextMenuStrip1;
			this.userControl11.Location = new System.Drawing.Point(52, 42);
			this.userControl11.Name = "userControl11";
			this.userControl11.Size = new System.Drawing.Size(528, 291);
			this.userControl11.TabIndex = 0;
			this.toolTip1.SetToolTip(this.userControl11, "ra đây đăng nhập nè");
			this.userControl11.checklogin += new WinFormsApp4.checkLogin(this.userControl11_checklogin);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(145, 76);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(144, 24);
			this.toolStripMenuItem1.Text = "clear data";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(144, 24);
			this.toolStripMenuItem2.Text = "add data";
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(144, 24);
			this.toolStripMenuItem3.Text = "set focus";
			// 
			// userControl12
			// 
			this.userControl12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.userControl12.Location = new System.Drawing.Point(664, 42);
			this.userControl12.Name = "userControl12";
			this.userControl12.Size = new System.Drawing.Size(590, 329);
			this.userControl12.TabIndex = 1;
			this.toolTip1.SetToolTip(this.userControl12, "cái này cx đc nốt");
			// 
			// Form6
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1305, 450);
			this.Controls.Add(this.userControl12);
			this.Controls.Add(this.userControl11);
			this.Name = "Form6";
			this.Text = "Form6";
			this.toolTip1.SetToolTip(this, "Mời Bạn đang nhâp");
			this.Load += new System.EventHandler(this.Form6_Load);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private UserControl1 userControl11;
        private UserControl1 userControl12;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    }
}