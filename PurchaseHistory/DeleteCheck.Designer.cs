
namespace PurchaseHistory
{
    partial class DeleteCheck
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
            this.DeleteCheckDeleteButton = new System.Windows.Forms.Button();
            this.DeleteCheckReturnButton = new System.Windows.Forms.Button();
            this.Delete_check_ID = new System.Windows.Forms.Label();
            this.Delete_check_Text = new System.Windows.Forms.Label();
            this.Design_panel_up = new System.Windows.Forms.Panel();
            this.deleteDecision_label = new System.Windows.Forms.Label();
            this.Design_panel_down = new System.Windows.Forms.Panel();
            this.Design_panel = new System.Windows.Forms.Panel();
            this.Design_panel_up.SuspendLayout();
            this.Design_panel_down.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeleteCheckDeleteButton
            // 
            this.DeleteCheckDeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.DeleteCheckDeleteButton.Font = new System.Drawing.Font("HGSｺﾞｼｯｸE", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DeleteCheckDeleteButton.Location = new System.Drawing.Point(597, 7);
            this.DeleteCheckDeleteButton.Name = "DeleteCheckDeleteButton";
            this.DeleteCheckDeleteButton.Size = new System.Drawing.Size(140, 45);
            this.DeleteCheckDeleteButton.TabIndex = 1;
            this.DeleteCheckDeleteButton.Text = "削除";
            this.DeleteCheckDeleteButton.UseVisualStyleBackColor = false;
            this.DeleteCheckDeleteButton.Click += new System.EventHandler(this.DeleteButton);
            // 
            // DeleteCheckReturnButton
            // 
            this.DeleteCheckReturnButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.DeleteCheckReturnButton.Font = new System.Drawing.Font("HGSｺﾞｼｯｸE", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DeleteCheckReturnButton.Location = new System.Drawing.Point(63, 7);
            this.DeleteCheckReturnButton.Name = "DeleteCheckReturnButton";
            this.DeleteCheckReturnButton.Size = new System.Drawing.Size(140, 45);
            this.DeleteCheckReturnButton.TabIndex = 2;
            this.DeleteCheckReturnButton.Text = "戻る";
            this.DeleteCheckReturnButton.UseVisualStyleBackColor = false;
            this.DeleteCheckReturnButton.Click += new System.EventHandler(this.ReturnButton);
            // 
            // Delete_check_ID
            // 
            this.Delete_check_ID.AutoSize = true;
            this.Delete_check_ID.Font = new System.Drawing.Font("HGSｺﾞｼｯｸE", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Delete_check_ID.Location = new System.Drawing.Point(315, 169);
            this.Delete_check_ID.Name = "Delete_check_ID";
            this.Delete_check_ID.Size = new System.Drawing.Size(45, 20);
            this.Delete_check_ID.TabIndex = 3;
            this.Delete_check_ID.Text = "ID：";
            this.Delete_check_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Delete_check_Text
            // 
            this.Delete_check_Text.Font = new System.Drawing.Font("HGSｺﾞｼｯｸE", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Delete_check_Text.Location = new System.Drawing.Point(270, 213);
            this.Delete_check_Text.Name = "Delete_check_Text";
            this.Delete_check_Text.Size = new System.Drawing.Size(256, 73);
            this.Delete_check_Text.TabIndex = 4;
            this.Delete_check_Text.Text = "会員を削除します。\r\nよろしいですか？";
            this.Delete_check_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Design_panel_up
            // 
            this.Design_panel_up.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Design_panel_up.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Design_panel_up.Controls.Add(this.deleteDecision_label);
            this.Design_panel_up.Location = new System.Drawing.Point(0, 0);
            this.Design_panel_up.Name = "Design_panel_up";
            this.Design_panel_up.Size = new System.Drawing.Size(800, 83);
            this.Design_panel_up.TabIndex = 28;
            // 
            // deleteDecision_label
            // 
            this.deleteDecision_label.BackColor = System.Drawing.Color.Transparent;
            this.deleteDecision_label.Font = new System.Drawing.Font("HGSｺﾞｼｯｸE", 15F);
            this.deleteDecision_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.deleteDecision_label.Location = new System.Drawing.Point(0, 0);
            this.deleteDecision_label.Name = "deleteDecision_label";
            this.deleteDecision_label.Size = new System.Drawing.Size(800, 83);
            this.deleteDecision_label.TabIndex = 2;
            this.deleteDecision_label.Text = "会員情報削除確認";
            this.deleteDecision_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Design_panel_down
            // 
            this.Design_panel_down.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Design_panel_down.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Design_panel_down.Controls.Add(this.DeleteCheckReturnButton);
            this.Design_panel_down.Controls.Add(this.DeleteCheckDeleteButton);
            this.Design_panel_down.Location = new System.Drawing.Point(0, 388);
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
            // DeleteCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Design_panel);
            this.Controls.Add(this.Design_panel_down);
            this.Controls.Add(this.Design_panel_up);
            this.Controls.Add(this.Delete_check_Text);
            this.Controls.Add(this.Delete_check_ID);
            this.Name = "DeleteCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会員削除確認画面";
            this.Load += new System.EventHandler(this.DeleteCheckLoad);
            this.Design_panel_up.ResumeLayout(false);
            this.Design_panel_down.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button DeleteCheckDeleteButton;
        private System.Windows.Forms.Button DeleteCheckReturnButton;
        private System.Windows.Forms.Label Delete_check_ID;
        private System.Windows.Forms.Label Delete_check_Text;
        private System.Windows.Forms.Panel Design_panel_up;
        private System.Windows.Forms.Label deleteDecision_label;
        private System.Windows.Forms.Panel Design_panel_down;
        private System.Windows.Forms.Panel Design_panel;
    }
}