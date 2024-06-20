namespace Astrilla_WebEditor_WinForms
{
    partial class Selection
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            appTitle = new Label();
            btn_aboutUs = new Button();
            btn_zodiacSigns = new Button();
            label_choosePage = new Label();
            SuspendLayout();
            // 
            // appTitle
            // 
            appTitle.AutoSize = true;
            appTitle.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            appTitle.Location = new Point(143, 58);
            appTitle.Name = "appTitle";
            appTitle.Size = new Size(273, 40);
            appTitle.TabIndex = 0;
            appTitle.Text = "Astrilla Web Editor";
            // 
            // btn_aboutUs
            // 
            btn_aboutUs.Location = new Point(217, 266);
            btn_aboutUs.Name = "btn_aboutUs";
            btn_aboutUs.Size = new Size(119, 43);
            btn_aboutUs.TabIndex = 2;
            btn_aboutUs.Text = "Über Uns";
            btn_aboutUs.UseVisualStyleBackColor = true;
            btn_aboutUs.Click += btn_aboutUs_Click;
            // 
            // btn_zodiacSigns
            // 
            btn_zodiacSigns.Location = new Point(218, 203);
            btn_zodiacSigns.Name = "btn_zodiacSigns";
            btn_zodiacSigns.Size = new Size(119, 43);
            btn_zodiacSigns.TabIndex = 1;
            btn_zodiacSigns.Text = "Sternzeichen";
            btn_zodiacSigns.UseVisualStyleBackColor = true;
            btn_zodiacSigns.Click += btn_zodiacSigns_Click;
            // 
            // label_choosePage
            // 
            label_choosePage.AutoSize = true;
            label_choosePage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_choosePage.Location = new Point(143, 151);
            label_choosePage.Name = "label_choosePage";
            label_choosePage.Size = new Size(272, 21);
            label_choosePage.TabIndex = 3;
            label_choosePage.Text = "Bitte wähle eine Seite zum Bearbeiten:";
            // 
            // Selection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(555, 502);
            Controls.Add(label_choosePage);
            Controls.Add(btn_aboutUs);
            Controls.Add(btn_zodiacSigns);
            Controls.Add(appTitle);
            Name = "Selection";
            Text = "Astrilla Web Editor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label appTitle;
        private Button btn_aboutUs;
        private Button btn_zodiacSigns;
        private Label label_choosePage;
    }
}
