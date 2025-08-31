
namespace TransliteratorApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtPolski;
        private System.Windows.Forms.TextBox txtRosyjski;
        private System.Windows.Forms.Button btnToCyr;
        private System.Windows.Forms.Button btnToPl;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
   components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtPolski = new System.Windows.Forms.TextBox();
            this.txtRosyjski = new System.Windows.Forms.TextBox();
            this.btnToCyr = new System.Windows.Forms.Button();
            this.btnToPl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPolski
            // 
            this.txtPolski.Location = new System.Drawing.Point(20, 20);
            this.txtPolski.Multiline = true;
            this.txtPolski.Size = new System.Drawing.Size(400, 100);
            // 
            // txtRosyjski
            // 
            this.txtRosyjski.Location = new System.Drawing.Point(20, 140);
            this.txtRosyjski.Multiline = true;
            this.txtRosyjski.Size = new System.Drawing.Size(400, 100);
            // 
            // btnToCyr
            // 
            this.btnToCyr.Location = new System.Drawing.Point(20, 260);
            this.btnToCyr.Size = new System.Drawing.Size(180, 30);
            this.btnToCyr.Text = "Polski → Cyrylica";
            this.btnToCyr.Click += new System.EventHandler(this.btnToCyr_Click);
            // 
            // btnToPl
            // 
            this.btnToPl.Location = new System.Drawing.Point(240, 260);
            this.btnToPl.Size = new System.Drawing.Size(180, 30);
            this.btnToPl.Text = "Cyrylica → Polski";
            this.btnToPl.Click += new System.EventHandler(this.btnToPl_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(450, 320);
            this.Controls.Add(this.txtPolski);
            this.Controls.Add(this.txtRosyjski);
            this.Controls.Add(this.btnToCyr);
            this.Controls.Add(this.btnToPl);
            this.Text = "TransliteratorApp";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
