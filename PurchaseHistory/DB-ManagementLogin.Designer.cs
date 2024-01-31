
namespace PurchaseHistory
{
    partial class DB_managementLogin
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
            this.deleteText_id = new System.Windows.Forms.TextBox();
            this.upDate_password = new System.Windows.Forms.TextBox();
            this.upDate_managementID = new System.Windows.Forms.TextBox();
            this.delete_search_label = new System.Windows.Forms.Label();
            this.upDate_password_label = new System.Windows.Forms.Label();
            this.upDate_managementID_label = new System.Windows.Forms.Label();
            this.delete_button = new System.Windows.Forms.Button();
            this.update_id = new System.Windows.Forms.TextBox();
            this.upDate_search_label = new System.Windows.Forms.Label();
            this.upDate_button = new System.Windows.Forms.Button();
            this.db_Display = new System.Windows.Forms.DataGridView();
            this.dataRead_button = new System.Windows.Forms.Button();
            this.password_label = new System.Windows.Forms.Label();
            this.managementID_label = new System.Windows.Forms.Label();
            this.insertText_password = new System.Windows.Forms.TextBox();
            this.insertText_managementID = new System.Windows.Forms.TextBox();
            this.dataRegistration_button = new System.Windows.Forms.Button();
            this.createTable_button = new System.Windows.Forms.Button();
            this.searchText_id = new System.Windows.Forms.TextBox();
            this.search_label = new System.Windows.Forms.Label();
            this.search_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.db_Display)).BeginInit();
            this.SuspendLayout();
            // 
            // deleteText_id
            // 
            this.deleteText_id.Location = new System.Drawing.Point(247, 355);
            this.deleteText_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteText_id.Name = "deleteText_id";
            this.deleteText_id.Size = new System.Drawing.Size(105, 22);
            this.deleteText_id.TabIndex = 35;
            // 
            // upDate_password
            // 
            this.upDate_password.Location = new System.Drawing.Point(359, 302);
            this.upDate_password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.upDate_password.Name = "upDate_password";
            this.upDate_password.Size = new System.Drawing.Size(105, 22);
            this.upDate_password.TabIndex = 34;
            // 
            // upDate_managementID
            // 
            this.upDate_managementID.Location = new System.Drawing.Point(244, 302);
            this.upDate_managementID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.upDate_managementID.Name = "upDate_managementID";
            this.upDate_managementID.Size = new System.Drawing.Size(109, 22);
            this.upDate_managementID.TabIndex = 33;
            // 
            // delete_search_label
            // 
            this.delete_search_label.AutoSize = true;
            this.delete_search_label.Location = new System.Drawing.Point(244, 338);
            this.delete_search_label.Name = "delete_search_label";
            this.delete_search_label.Size = new System.Drawing.Size(57, 15);
            this.delete_search_label.TabIndex = 32;
            this.delete_search_label.Text = "検索CD";
            // 
            // upDate_password_label
            // 
            this.upDate_password_label.AutoSize = true;
            this.upDate_password_label.Location = new System.Drawing.Point(356, 284);
            this.upDate_password_label.Name = "upDate_password_label";
            this.upDate_password_label.Size = new System.Drawing.Size(67, 15);
            this.upDate_password_label.TabIndex = 31;
            this.upDate_password_label.Text = "PassWard";
            // 
            // upDate_managementID_label
            // 
            this.upDate_managementID_label.AutoSize = true;
            this.upDate_managementID_label.Location = new System.Drawing.Point(243, 284);
            this.upDate_managementID_label.Name = "upDate_managementID_label";
            this.upDate_managementID_label.Size = new System.Drawing.Size(101, 15);
            this.upDate_managementID_label.TabIndex = 30;
            this.upDate_managementID_label.Text = "ManagementID";
            // 
            // DeleteButton
            // 
            this.delete_button.Location = new System.Drawing.Point(68, 338);
            this.delete_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.delete_button.Name = "DeleteButton";
            this.delete_button.Size = new System.Drawing.Size(147, 40);
            this.delete_button.TabIndex = 29;
            this.delete_button.Text = "データ削除";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.DataDeleteButton);
            // 
            // update_id
            // 
            this.update_id.Location = new System.Drawing.Point(245, 259);
            this.update_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.update_id.Name = "update_id";
            this.update_id.Size = new System.Drawing.Size(105, 22);
            this.update_id.TabIndex = 28;
            // 
            // upDate_search_label
            // 
            this.upDate_search_label.AutoSize = true;
            this.upDate_search_label.Location = new System.Drawing.Point(243, 241);
            this.upDate_search_label.Name = "upDate_search_label";
            this.upDate_search_label.Size = new System.Drawing.Size(57, 15);
            this.upDate_search_label.TabIndex = 27;
            this.upDate_search_label.Text = "検索CD";
            // 
            // upDate_button
            // 
            this.upDate_button.Location = new System.Drawing.Point(68, 241);
            this.upDate_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.upDate_button.Name = "upDate_button";
            this.upDate_button.Size = new System.Drawing.Size(147, 46);
            this.upDate_button.TabIndex = 26;
            this.upDate_button.Text = "データ修正";
            this.upDate_button.UseVisualStyleBackColor = true;
            this.upDate_button.Click += new System.EventHandler(this.DataUpDateButton);
            // 
            // db_Display
            // 
            this.db_Display.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.db_Display.Location = new System.Drawing.Point(247, 96);
            this.db_Display.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.db_Display.Name = "db_Display";
            this.db_Display.RowHeadersWidth = 51;
            this.db_Display.RowTemplate.Height = 24;
            this.db_Display.Size = new System.Drawing.Size(411, 132);
            this.db_Display.TabIndex = 25;
            // 
            // dataRead_button
            // 
            this.dataRead_button.Location = new System.Drawing.Point(68, 96);
            this.dataRead_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataRead_button.Name = "dataRead_button";
            this.dataRead_button.Size = new System.Drawing.Size(147, 46);
            this.dataRead_button.TabIndex = 24;
            this.dataRead_button.Text = "データ読み込み";
            this.dataRead_button.UseVisualStyleBackColor = true;
            this.dataRead_button.Click += new System.EventHandler(this.DataReadButton);
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(548, 25);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(67, 15);
            this.password_label.TabIndex = 23;
            this.password_label.Text = "PassWard";
            // 
            // managementID_label
            // 
            this.managementID_label.AutoSize = true;
            this.managementID_label.Location = new System.Drawing.Point(420, 25);
            this.managementID_label.Name = "managementID_label";
            this.managementID_label.Size = new System.Drawing.Size(101, 15);
            this.managementID_label.TabIndex = 22;
            this.managementID_label.Text = "ManagementID";
            // 
            // insertText_password
            // 
            this.insertText_password.Location = new System.Drawing.Point(551, 44);
            this.insertText_password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.insertText_password.Name = "insertText_password";
            this.insertText_password.Size = new System.Drawing.Size(105, 22);
            this.insertText_password.TabIndex = 21;
            // 
            // insertText_managementID
            // 
            this.insertText_managementID.Location = new System.Drawing.Point(421, 44);
            this.insertText_managementID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.insertText_managementID.Name = "insertText_managementID";
            this.insertText_managementID.Size = new System.Drawing.Size(107, 22);
            this.insertText_managementID.TabIndex = 20;
            // 
            // dataRegistration_button
            // 
            this.dataRegistration_button.Location = new System.Drawing.Point(244, 30);
            this.dataRegistration_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataRegistration_button.Name = "dataRegistration_button";
            this.dataRegistration_button.Size = new System.Drawing.Size(147, 46);
            this.dataRegistration_button.TabIndex = 19;
            this.dataRegistration_button.Text = "データ追加";
            this.dataRegistration_button.UseVisualStyleBackColor = true;
            this.dataRegistration_button.Click += new System.EventHandler(this.DataInsertButton);
            // 
            // createTable_button
            // 
            this.createTable_button.Location = new System.Drawing.Point(68, 30);
            this.createTable_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.createTable_button.Name = "createTable_button";
            this.createTable_button.Size = new System.Drawing.Size(147, 46);
            this.createTable_button.TabIndex = 18;
            this.createTable_button.Text = "デーブル作成";
            this.createTable_button.UseVisualStyleBackColor = true;
            this.createTable_button.Click += new System.EventHandler(this.CreateTableButton);
            // 
            // searchText_id
            // 
            this.searchText_id.Location = new System.Drawing.Point(644, 259);
            this.searchText_id.Margin = new System.Windows.Forms.Padding(4);
            this.searchText_id.Name = "searchText_id";
            this.searchText_id.Size = new System.Drawing.Size(105, 22);
            this.searchText_id.TabIndex = 38;
            // 
            // search_label
            // 
            this.search_label.AutoSize = true;
            this.search_label.Location = new System.Drawing.Point(641, 241);
            this.search_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.search_label.Name = "search_label";
            this.search_label.Size = new System.Drawing.Size(51, 15);
            this.search_label.TabIndex = 37;
            this.search_label.Text = "検索ID";
            // 
            // SearchButton
            // 
            this.search_button.Location = new System.Drawing.Point(475, 241);
            this.search_button.Margin = new System.Windows.Forms.Padding(4);
            this.search_button.Name = "SearchButton";
            this.search_button.Size = new System.Drawing.Size(147, 46);
            this.search_button.TabIndex = 36;
            this.search_button.Text = "検索";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.DataSearchButton);
            // 
            // DB_managementLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.searchText_id);
            this.Controls.Add(this.search_label);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.deleteText_id);
            this.Controls.Add(this.upDate_password);
            this.Controls.Add(this.upDate_managementID);
            this.Controls.Add(this.delete_search_label);
            this.Controls.Add(this.upDate_password_label);
            this.Controls.Add(this.upDate_managementID_label);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.update_id);
            this.Controls.Add(this.upDate_search_label);
            this.Controls.Add(this.upDate_button);
            this.Controls.Add(this.db_Display);
            this.Controls.Add(this.dataRead_button);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.managementID_label);
            this.Controls.Add(this.insertText_password);
            this.Controls.Add(this.insertText_managementID);
            this.Controls.Add(this.dataRegistration_button);
            this.Controls.Add(this.createTable_button);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DB_managementLogin";
            this.Text = "管理者IDtoPS";
            ((System.ComponentModel.ISupportInitialize)(this.db_Display)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox deleteText_id;
        private System.Windows.Forms.TextBox upDate_password;
        private System.Windows.Forms.TextBox upDate_managementID;
        private System.Windows.Forms.Label delete_search_label;
        private System.Windows.Forms.Label upDate_password_label;
        private System.Windows.Forms.Label upDate_managementID_label;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.TextBox update_id;
        private System.Windows.Forms.Label upDate_search_label;
        private System.Windows.Forms.Button upDate_button;
        private System.Windows.Forms.DataGridView db_Display;
        private System.Windows.Forms.Button dataRead_button;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Label managementID_label;
        private System.Windows.Forms.TextBox insertText_password;
        private System.Windows.Forms.TextBox insertText_managementID;
        private System.Windows.Forms.Button dataRegistration_button;
        private System.Windows.Forms.Button createTable_button;
        private System.Windows.Forms.TextBox searchText_id;
        private System.Windows.Forms.Label search_label;
        private System.Windows.Forms.Button search_button;
    }
}