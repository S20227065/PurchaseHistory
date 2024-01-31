
namespace PurchaseHistory
{
    partial class ManagementLogin
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.ManagementLoginButton = new System.Windows.Forms.Button();
            this.ManagemantShutdownButton = new System.Windows.Forms.Button();
            this.managementLogin_label = new System.Windows.Forms.Label();
            this.managementID_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.login_managementID = new System.Windows.Forms.TextBox();
            this.login_password = new System.Windows.Forms.TextBox();
            this.Design_panel_up = new System.Windows.Forms.Panel();
            this.Design_panel_down = new System.Windows.Forms.Panel();
            this.Design_panel = new System.Windows.Forms.Panel();
            this.Design_panel_up.SuspendLayout();
            this.Design_panel_down.SuspendLayout();
            this.SuspendLayout();
            // 
            // ManagementLoginButton
            // 
            this.ManagementLoginButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ManagementLoginButton.Font = new System.Drawing.Font("HGSｺﾞｼｯｸE", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ManagementLoginButton.Location = new System.Drawing.Point(597, 7);
            this.ManagementLoginButton.Name = "ManagementLoginButton";
            this.ManagementLoginButton.Size = new System.Drawing.Size(140, 45);
            this.ManagementLoginButton.TabIndex = 0;
            this.ManagementLoginButton.Text = "ログイン";
            this.ManagementLoginButton.UseVisualStyleBackColor = false;
            this.ManagementLoginButton.Click += new System.EventHandler(this.LoginButton);
            // 
            // ManagemantShutdownButton
            // 
            this.ManagemantShutdownButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ManagemantShutdownButton.Font = new System.Drawing.Font("HGSｺﾞｼｯｸE", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ManagemantShutdownButton.Location = new System.Drawing.Point(63, 7);
            this.ManagemantShutdownButton.Name = "ManagemantShutdownButton";
            this.ManagemantShutdownButton.Size = new System.Drawing.Size(140, 45);
            this.ManagemantShutdownButton.TabIndex = 1;
            this.ManagemantShutdownButton.Text = "終了";
            this.ManagemantShutdownButton.UseVisualStyleBackColor = false;
            this.ManagemantShutdownButton.Click += new System.EventHandler(this.ShutdownButton);
            // 
            // managementLogin_label
            // 
            this.managementLogin_label.BackColor = System.Drawing.Color.Transparent;
            this.managementLogin_label.Font = new System.Drawing.Font("HGSｺﾞｼｯｸE", 15F);
            this.managementLogin_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.managementLogin_label.Location = new System.Drawing.Point(0, 0);
            this.managementLogin_label.Name = "managementLogin_label";
            this.managementLogin_label.Size = new System.Drawing.Size(800, 83);
            this.managementLogin_label.TabIndex = 2;
            this.managementLogin_label.Text = "会員情報管理システム";
            this.managementLogin_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // managementID_label
            // 
            this.managementID_label.AutoSize = true;
            this.managementID_label.Font = new System.Drawing.Font("HGSｺﾞｼｯｸE", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.managementID_label.Location = new System.Drawing.Point(266, 185);
            this.managementID_label.Name = "managementID_label";
            this.managementID_label.Size = new System.Drawing.Size(73, 17);
            this.managementID_label.TabIndex = 3;
            this.managementID_label.Text = "管理者ID";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Font = new System.Drawing.Font("HGSｺﾞｼｯｸE", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.password_label.Location = new System.Drawing.Point(266, 266);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(93, 17);
            this.password_label.TabIndex = 4;
            this.password_label.Text = "パスワード";
            // 
            // login_managementID
            // 
            this.login_managementID.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.login_managementID.Location = new System.Drawing.Point(293, 212);
            this.login_managementID.Name = "login_managementID";
            this.login_managementID.Size = new System.Drawing.Size(216, 22);
            this.login_managementID.TabIndex = 5;
            this.login_managementID.TextChanged += new System.EventHandler(this.IdInputTextBox);
            // 
            // login_password
            // 
            this.login_password.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.login_password.Location = new System.Drawing.Point(293, 286);
            this.login_password.Name = "login_password";
            this.login_password.PasswordChar = '●';
            this.login_password.Size = new System.Drawing.Size(216, 22);
            this.login_password.TabIndex = 6;
            // 
            // Design_panel_up
            // 
            this.Design_panel_up.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Design_panel_up.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Design_panel_up.Controls.Add(this.managementLogin_label);
            this.Design_panel_up.Location = new System.Drawing.Point(0, 0);
            this.Design_panel_up.Name = "Design_panel_up";
            this.Design_panel_up.Size = new System.Drawing.Size(800, 83);
            this.Design_panel_up.TabIndex = 7;
            // 
            // Design_panel_down
            // 
            this.Design_panel_down.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Design_panel_down.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Design_panel_down.Controls.Add(this.ManagemantShutdownButton);
            this.Design_panel_down.Controls.Add(this.ManagementLoginButton);
            this.Design_panel_down.Location = new System.Drawing.Point(0, 387);
            this.Design_panel_down.Name = "Design_panel_down";
            this.Design_panel_down.Size = new System.Drawing.Size(800, 63);
            this.Design_panel_down.TabIndex = 132;
            // 
            // Design_panel
            // 
            this.Design_panel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Design_panel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Design_panel.Location = new System.Drawing.Point(0, 89);
            this.Design_panel.Name = "Design_panel";
            this.Design_panel.Size = new System.Drawing.Size(800, 10);
            this.Design_panel.TabIndex = 133;
            // 
            // ManagementLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Design_panel);
            this.Controls.Add(this.Design_panel_down);
            this.Controls.Add(this.Design_panel_up);
            this.Controls.Add(this.managementID_label);
            this.Controls.Add(this.login_password);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.login_managementID);
            this.Name = "ManagementLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ログイン画面";
            this.Load += new System.EventHandler(this.ManagementLogin_Load);
            this.Design_panel_up.ResumeLayout(false);
            this.Design_panel_down.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ManagementLoginButton;
        private System.Windows.Forms.Button ManagemantShutdownButton;
        private System.Windows.Forms.Label managementLogin_label;
        private System.Windows.Forms.Label managementID_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.TextBox login_managementID;
        private System.Windows.Forms.TextBox login_password;
        private System.Windows.Forms.Panel Design_panel_up;
        private System.Windows.Forms.Panel Design_panel_down;
        private System.Windows.Forms.Panel Design_panel;
    }
}

