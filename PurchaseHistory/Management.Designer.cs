
namespace PurchaseHistory
{
    partial class Management
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
            this.MemberRegistrationButton = new System.Windows.Forms.Button();
            this.MemberSearchButton = new System.Windows.Forms.Button();
            this.ManagementReturnButton = new System.Windows.Forms.Button();
            this.Design_panel_up = new System.Windows.Forms.Panel();
            this.management_label = new System.Windows.Forms.Label();
            this.Design_panel_down = new System.Windows.Forms.Panel();
            this.Design_panel = new System.Windows.Forms.Panel();
            this.administrator_Name_label = new System.Windows.Forms.Label();
            this.administrator_ID_label = new System.Windows.Forms.Label();
            this.Design_panel_up.SuspendLayout();
            this.Design_panel_down.SuspendLayout();
            this.SuspendLayout();
            // 
            // MemberRegistrationButton
            // 
            this.MemberRegistrationButton.Font = new System.Drawing.Font("HGSｺﾞｼｯｸE", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MemberRegistrationButton.Location = new System.Drawing.Point(255, 177);
            this.MemberRegistrationButton.Name = "MemberRegistrationButton";
            this.MemberRegistrationButton.Size = new System.Drawing.Size(276, 68);
            this.MemberRegistrationButton.TabIndex = 1;
            this.MemberRegistrationButton.Text = "会員登録";
            this.MemberRegistrationButton.UseVisualStyleBackColor = true;
            this.MemberRegistrationButton.Click += new System.EventHandler(this.RegistrationButton);
            // 
            // MemberSearchButton
            // 
            this.MemberSearchButton.Font = new System.Drawing.Font("HGSｺﾞｼｯｸE", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MemberSearchButton.Location = new System.Drawing.Point(255, 268);
            this.MemberSearchButton.Name = "MemberSearchButton";
            this.MemberSearchButton.Size = new System.Drawing.Size(276, 66);
            this.MemberSearchButton.TabIndex = 2;
            this.MemberSearchButton.Text = "会員検索";
            this.MemberSearchButton.UseVisualStyleBackColor = true;
            this.MemberSearchButton.Click += new System.EventHandler(this.SearchButton);
            // 
            // ManagementReturnButton
            // 
            this.ManagementReturnButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ManagementReturnButton.Font = new System.Drawing.Font("HGSｺﾞｼｯｸE", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ManagementReturnButton.Location = new System.Drawing.Point(66, 7);
            this.ManagementReturnButton.Name = "ManagementReturnButton";
            this.ManagementReturnButton.Size = new System.Drawing.Size(140, 45);
            this.ManagementReturnButton.TabIndex = 4;
            this.ManagementReturnButton.Text = "戻る";
            this.ManagementReturnButton.UseVisualStyleBackColor = false;
            this.ManagementReturnButton.Click += new System.EventHandler(this.ReturnButton);
            // 
            // Design_panel_up
            // 
            this.Design_panel_up.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Design_panel_up.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Design_panel_up.Controls.Add(this.management_label);
            this.Design_panel_up.Location = new System.Drawing.Point(-3, 0);
            this.Design_panel_up.Name = "Design_panel_up";
            this.Design_panel_up.Size = new System.Drawing.Size(800, 83);
            this.Design_panel_up.TabIndex = 8;
            // 
            // management_label
            // 
            this.management_label.BackColor = System.Drawing.Color.Transparent;
            this.management_label.Font = new System.Drawing.Font("HGSｺﾞｼｯｸE", 15F);
            this.management_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.management_label.Location = new System.Drawing.Point(3, 0);
            this.management_label.Name = "management_label";
            this.management_label.Size = new System.Drawing.Size(797, 83);
            this.management_label.TabIndex = 2;
            this.management_label.Text = "会員情報管理";
            this.management_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Design_panel_down
            // 
            this.Design_panel_down.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Design_panel_down.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Design_panel_down.Controls.Add(this.ManagementReturnButton);
            this.Design_panel_down.Location = new System.Drawing.Point(-3, 389);
            this.Design_panel_down.Name = "Design_panel_down";
            this.Design_panel_down.Size = new System.Drawing.Size(805, 61);
            this.Design_panel_down.TabIndex = 132;
            // 
            // Design_panel
            // 
            this.Design_panel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Design_panel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Design_panel.Location = new System.Drawing.Point(2, 89);
            this.Design_panel.Name = "Design_panel";
            this.Design_panel.Size = new System.Drawing.Size(800, 10);
            this.Design_panel.TabIndex = 133;
            // 
            // administrator_Name_label
            // 
            this.administrator_Name_label.Font = new System.Drawing.Font("BIZ UDPゴシック", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.administrator_Name_label.Location = new System.Drawing.Point(632, 361);
            this.administrator_Name_label.Name = "administrator_Name_label";
            this.administrator_Name_label.Size = new System.Drawing.Size(156, 25);
            this.administrator_Name_label.TabIndex = 135;
            this.administrator_Name_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // administrator_ID_label
            // 
            this.administrator_ID_label.Font = new System.Drawing.Font("BIZ UDPゴシック", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.administrator_ID_label.Location = new System.Drawing.Point(579, 361);
            this.administrator_ID_label.Name = "administrator_ID_label";
            this.administrator_ID_label.Size = new System.Drawing.Size(47, 25);
            this.administrator_ID_label.TabIndex = 134;
            this.administrator_ID_label.Text = "ID：";
            this.administrator_ID_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.administrator_Name_label);
            this.Controls.Add(this.administrator_ID_label);
            this.Controls.Add(this.Design_panel);
            this.Controls.Add(this.Design_panel_down);
            this.Controls.Add(this.Design_panel_up);
            this.Controls.Add(this.MemberRegistrationButton);
            this.Controls.Add(this.MemberSearchButton);
            this.Name = "Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会員管理画面";
            this.Load += new System.EventHandler(this.ManagementLoad);
            this.Design_panel_up.ResumeLayout(false);
            this.Design_panel_down.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button MemberRegistrationButton;
        private System.Windows.Forms.Button MemberSearchButton;
        private System.Windows.Forms.Button ManagementReturnButton;
        private System.Windows.Forms.Panel Design_panel_up;
        private System.Windows.Forms.Label management_label;
        private System.Windows.Forms.Panel Design_panel_down;
        private System.Windows.Forms.Panel Design_panel;
        private System.Windows.Forms.Label administrator_Name_label;
        private System.Windows.Forms.Label administrator_ID_label;
    }
}