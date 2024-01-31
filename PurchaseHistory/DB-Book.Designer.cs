
namespace PurchaseHistory
{
    partial class DB_book
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
            this.searchText_id = new System.Windows.Forms.TextBox();
            this.search_label = new System.Windows.Forms.Label();
            this.search_button = new System.Windows.Forms.Button();
            this.deleteText_id = new System.Windows.Forms.TextBox();
            this.upDateText_1 = new System.Windows.Forms.TextBox();
            this.upDateText_0 = new System.Windows.Forms.TextBox();
            this.delete_search_label = new System.Windows.Forms.Label();
            this.upDate_genre_label = new System.Windows.Forms.Label();
            this.upDate_bookName_label = new System.Windows.Forms.Label();
            this.delete_button = new System.Windows.Forms.Button();
            this.upDateText_id = new System.Windows.Forms.TextBox();
            this.upDate_search_label = new System.Windows.Forms.Label();
            this.upDate_button = new System.Windows.Forms.Button();
            this.db_Display = new System.Windows.Forms.DataGridView();
            this.dataRead_button = new System.Windows.Forms.Button();
            this.genre_label = new System.Windows.Forms.Label();
            this.bookName_label = new System.Windows.Forms.Label();
            this.insertText_1 = new System.Windows.Forms.TextBox();
            this.insertText_0 = new System.Windows.Forms.TextBox();
            this.dataRegistration_button = new System.Windows.Forms.Button();
            this.createTable_button = new System.Windows.Forms.Button();
            this.price_label = new System.Windows.Forms.Label();
            this.insertText_2 = new System.Windows.Forms.TextBox();
            this.upDateText_2 = new System.Windows.Forms.TextBox();
            this.upDate_price_label = new System.Windows.Forms.Label();
            this.display_price_label = new System.Windows.Forms.Label();
            this.display_genre_label = new System.Windows.Forms.Label();
            this.display_bookName_label = new System.Windows.Forms.Label();
            this.display_bookId_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.db_Display)).BeginInit();
            this.SuspendLayout();
            // 
            // searchText_id
            // 
            this.searchText_id.Location = new System.Drawing.Point(487, 326);
            this.searchText_id.Margin = new System.Windows.Forms.Padding(4);
            this.searchText_id.Name = "searchText_id";
            this.searchText_id.Size = new System.Drawing.Size(105, 22);
            this.searchText_id.TabIndex = 59;
            // 
            // search_label
            // 
            this.search_label.AutoSize = true;
            this.search_label.Location = new System.Drawing.Point(484, 308);
            this.search_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.search_label.Name = "search_label";
            this.search_label.Size = new System.Drawing.Size(51, 15);
            this.search_label.TabIndex = 58;
            this.search_label.Text = "検索ID";
            // 
            // SearchButton
            // 
            this.search_button.Location = new System.Drawing.Point(487, 265);
            this.search_button.Margin = new System.Windows.Forms.Padding(4);
            this.search_button.Name = "SearchButton";
            this.search_button.Size = new System.Drawing.Size(147, 39);
            this.search_button.TabIndex = 57;
            this.search_button.Text = "検索";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.SearchButton);
            // 
            // deleteText_id
            // 
            this.deleteText_id.Location = new System.Drawing.Point(239, 410);
            this.deleteText_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteText_id.Name = "deleteText_id";
            this.deleteText_id.Size = new System.Drawing.Size(105, 22);
            this.deleteText_id.TabIndex = 56;
            // 
            // upDateText_1
            // 
            this.upDateText_1.Location = new System.Drawing.Point(352, 283);
            this.upDateText_1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.upDateText_1.Name = "upDateText_1";
            this.upDateText_1.Size = new System.Drawing.Size(105, 22);
            this.upDateText_1.TabIndex = 55;
            // 
            // upDateText_0
            // 
            this.upDateText_0.Location = new System.Drawing.Point(236, 326);
            this.upDateText_0.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.upDateText_0.Name = "upDateText_0";
            this.upDateText_0.Size = new System.Drawing.Size(109, 22);
            this.upDateText_0.TabIndex = 54;
            // 
            // delete_search_label
            // 
            this.delete_search_label.AutoSize = true;
            this.delete_search_label.Location = new System.Drawing.Point(236, 393);
            this.delete_search_label.Name = "delete_search_label";
            this.delete_search_label.Size = new System.Drawing.Size(51, 15);
            this.delete_search_label.TabIndex = 53;
            this.delete_search_label.Text = "検索ID";
            // 
            // upDate_genre_label
            // 
            this.upDate_genre_label.AutoSize = true;
            this.upDate_genre_label.Location = new System.Drawing.Point(349, 265);
            this.upDate_genre_label.Name = "upDate_genre_label";
            this.upDate_genre_label.Size = new System.Drawing.Size(43, 15);
            this.upDate_genre_label.TabIndex = 52;
            this.upDate_genre_label.Text = "genre";
            // 
            // upDate_bookName_label
            // 
            this.upDate_bookName_label.AutoSize = true;
            this.upDate_bookName_label.Location = new System.Drawing.Point(235, 308);
            this.upDate_bookName_label.Name = "upDate_bookName_label";
            this.upDate_bookName_label.Size = new System.Drawing.Size(73, 15);
            this.upDate_bookName_label.TabIndex = 51;
            this.upDate_bookName_label.Text = "bookName";
            // 
            // DeleteButton
            // 
            this.delete_button.Location = new System.Drawing.Point(60, 393);
            this.delete_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.delete_button.Name = "DeleteButton";
            this.delete_button.Size = new System.Drawing.Size(147, 40);
            this.delete_button.TabIndex = 50;
            this.delete_button.Text = "データ削除";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.DeleteButton);
            // 
            // upDateText_id
            // 
            this.upDateText_id.Location = new System.Drawing.Point(237, 283);
            this.upDateText_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.upDateText_id.Name = "upDateText_id";
            this.upDateText_id.Size = new System.Drawing.Size(105, 22);
            this.upDateText_id.TabIndex = 49;
            // 
            // upDate_search_label
            // 
            this.upDate_search_label.AutoSize = true;
            this.upDate_search_label.Location = new System.Drawing.Point(235, 265);
            this.upDate_search_label.Name = "upDate_search_label";
            this.upDate_search_label.Size = new System.Drawing.Size(51, 15);
            this.upDate_search_label.TabIndex = 48;
            this.upDate_search_label.Text = "検索ID";
            // 
            // upDate_button
            // 
            this.upDate_button.Location = new System.Drawing.Point(60, 265);
            this.upDate_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.upDate_button.Name = "upDate_button";
            this.upDate_button.Size = new System.Drawing.Size(147, 46);
            this.upDate_button.TabIndex = 47;
            this.upDate_button.Text = "データ修正";
            this.upDate_button.UseVisualStyleBackColor = true;
            this.upDate_button.Click += new System.EventHandler(this.DataUpDateButton);
            // 
            // db_Display
            // 
            this.db_Display.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.db_Display.Location = new System.Drawing.Point(239, 120);
            this.db_Display.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.db_Display.Name = "db_Display";
            this.db_Display.RowHeadersWidth = 51;
            this.db_Display.RowTemplate.Height = 24;
            this.db_Display.Size = new System.Drawing.Size(411, 132);
            this.db_Display.TabIndex = 46;
            // 
            // dataRead_button
            // 
            this.dataRead_button.Location = new System.Drawing.Point(60, 120);
            this.dataRead_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataRead_button.Name = "dataRead_button";
            this.dataRead_button.Size = new System.Drawing.Size(147, 46);
            this.dataRead_button.TabIndex = 45;
            this.dataRead_button.Text = "データ読み込み";
            this.dataRead_button.UseVisualStyleBackColor = true;
            this.dataRead_button.Click += new System.EventHandler(this.DataReadButton);
            // 
            // genre_label
            // 
            this.genre_label.AutoSize = true;
            this.genre_label.Location = new System.Drawing.Point(540, 49);
            this.genre_label.Name = "genre_label";
            this.genre_label.Size = new System.Drawing.Size(43, 15);
            this.genre_label.TabIndex = 44;
            this.genre_label.Text = "genre";
            // 
            // bookName_label
            // 
            this.bookName_label.AutoSize = true;
            this.bookName_label.Location = new System.Drawing.Point(412, 49);
            this.bookName_label.Name = "bookName_label";
            this.bookName_label.Size = new System.Drawing.Size(73, 15);
            this.bookName_label.TabIndex = 43;
            this.bookName_label.Text = "bookName";
            // 
            // insertText_1
            // 
            this.insertText_1.Location = new System.Drawing.Point(543, 68);
            this.insertText_1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.insertText_1.Name = "insertText_1";
            this.insertText_1.Size = new System.Drawing.Size(105, 22);
            this.insertText_1.TabIndex = 42;
            // 
            // insertText_0
            // 
            this.insertText_0.Location = new System.Drawing.Point(413, 68);
            this.insertText_0.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.insertText_0.Name = "insertText_0";
            this.insertText_0.Size = new System.Drawing.Size(107, 22);
            this.insertText_0.TabIndex = 41;
            // 
            // dataRegistration_button
            // 
            this.dataRegistration_button.Location = new System.Drawing.Point(236, 54);
            this.dataRegistration_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataRegistration_button.Name = "dataRegistration_button";
            this.dataRegistration_button.Size = new System.Drawing.Size(147, 46);
            this.dataRegistration_button.TabIndex = 40;
            this.dataRegistration_button.Text = "データ追加";
            this.dataRegistration_button.UseVisualStyleBackColor = true;
            this.dataRegistration_button.Click += new System.EventHandler(this.DataInsertButton);
            // 
            // createTable_button
            // 
            this.createTable_button.Location = new System.Drawing.Point(60, 54);
            this.createTable_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.createTable_button.Name = "createTable_button";
            this.createTable_button.Size = new System.Drawing.Size(147, 46);
            this.createTable_button.TabIndex = 39;
            this.createTable_button.Text = "デーブル作成";
            this.createTable_button.UseVisualStyleBackColor = true;
            this.createTable_button.Click += new System.EventHandler(this.CreateTableButton);
            // 
            // price_label
            // 
            this.price_label.AutoSize = true;
            this.price_label.Location = new System.Drawing.Point(661, 49);
            this.price_label.Name = "price_label";
            this.price_label.Size = new System.Drawing.Size(38, 15);
            this.price_label.TabIndex = 61;
            this.price_label.Text = "price";
            // 
            // insertText_2
            // 
            this.insertText_2.Location = new System.Drawing.Point(664, 68);
            this.insertText_2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.insertText_2.Name = "insertText_2";
            this.insertText_2.Size = new System.Drawing.Size(105, 22);
            this.insertText_2.TabIndex = 60;
            // 
            // upDateText_2
            // 
            this.upDateText_2.Location = new System.Drawing.Point(352, 325);
            this.upDateText_2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.upDateText_2.Name = "upDateText_2";
            this.upDateText_2.Size = new System.Drawing.Size(105, 22);
            this.upDateText_2.TabIndex = 63;
            // 
            // upDate_price_label
            // 
            this.upDate_price_label.AutoSize = true;
            this.upDate_price_label.Location = new System.Drawing.Point(349, 307);
            this.upDate_price_label.Name = "upDate_price_label";
            this.upDate_price_label.Size = new System.Drawing.Size(38, 15);
            this.upDate_price_label.TabIndex = 62;
            this.upDate_price_label.Text = "price";
            // 
            // display_price_label
            // 
            this.display_price_label.Font = new System.Drawing.Font("BIZ UDPゴシック", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.display_price_label.Location = new System.Drawing.Point(392, 420);
            this.display_price_label.Name = "display_price_label";
            this.display_price_label.Size = new System.Drawing.Size(377, 24);
            this.display_price_label.TabIndex = 129;
            this.display_price_label.Text = "Email";
            this.display_price_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // display_genre_label
            // 
            this.display_genre_label.Font = new System.Drawing.Font("BIZ UDPゴシック", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.display_genre_label.Location = new System.Drawing.Point(392, 399);
            this.display_genre_label.Name = "display_genre_label";
            this.display_genre_label.Size = new System.Drawing.Size(377, 24);
            this.display_genre_label.TabIndex = 128;
            this.display_genre_label.Text = "Address";
            this.display_genre_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // display_bookName_label
            // 
            this.display_bookName_label.Font = new System.Drawing.Font("BIZ UDPゴシック", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.display_bookName_label.Location = new System.Drawing.Point(392, 377);
            this.display_bookName_label.Name = "display_bookName_label";
            this.display_bookName_label.Size = new System.Drawing.Size(377, 22);
            this.display_bookName_label.TabIndex = 127;
            this.display_bookName_label.Text = "Name";
            this.display_bookName_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // display_bookId_label
            // 
            this.display_bookId_label.Font = new System.Drawing.Font("BIZ UDPゴシック", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.display_bookId_label.Location = new System.Drawing.Point(392, 352);
            this.display_bookId_label.Name = "display_bookId_label";
            this.display_bookId_label.Size = new System.Drawing.Size(377, 25);
            this.display_bookId_label.TabIndex = 126;
            this.display_bookId_label.Text = "ID";
            this.display_bookId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DB_book
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.display_price_label);
            this.Controls.Add(this.display_genre_label);
            this.Controls.Add(this.display_bookName_label);
            this.Controls.Add(this.display_bookId_label);
            this.Controls.Add(this.upDateText_2);
            this.Controls.Add(this.upDate_price_label);
            this.Controls.Add(this.price_label);
            this.Controls.Add(this.insertText_2);
            this.Controls.Add(this.searchText_id);
            this.Controls.Add(this.search_label);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.deleteText_id);
            this.Controls.Add(this.upDateText_1);
            this.Controls.Add(this.upDateText_0);
            this.Controls.Add(this.delete_search_label);
            this.Controls.Add(this.upDate_genre_label);
            this.Controls.Add(this.upDate_bookName_label);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.upDateText_id);
            this.Controls.Add(this.upDate_search_label);
            this.Controls.Add(this.upDate_button);
            this.Controls.Add(this.db_Display);
            this.Controls.Add(this.dataRead_button);
            this.Controls.Add(this.genre_label);
            this.Controls.Add(this.bookName_label);
            this.Controls.Add(this.insertText_1);
            this.Controls.Add(this.insertText_0);
            this.Controls.Add(this.dataRegistration_button);
            this.Controls.Add(this.createTable_button);
            this.Name = "DB_book";
            this.Text = "DB_book";
            ((System.ComponentModel.ISupportInitialize)(this.db_Display)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchText_id;
        private System.Windows.Forms.Label search_label;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.TextBox deleteText_id;
        private System.Windows.Forms.TextBox upDateText_1;
        private System.Windows.Forms.TextBox upDateText_0;
        private System.Windows.Forms.Label delete_search_label;
        private System.Windows.Forms.Label upDate_genre_label;
        private System.Windows.Forms.Label upDate_bookName_label;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.TextBox upDateText_id;
        private System.Windows.Forms.Label upDate_search_label;
        private System.Windows.Forms.Button upDate_button;
        private System.Windows.Forms.DataGridView db_Display;
        private System.Windows.Forms.Button dataRead_button;
        private System.Windows.Forms.Label genre_label;
        private System.Windows.Forms.Label bookName_label;
        private System.Windows.Forms.TextBox insertText_1;
        private System.Windows.Forms.TextBox insertText_0;
        private System.Windows.Forms.Button dataRegistration_button;
        private System.Windows.Forms.Button createTable_button;
        private System.Windows.Forms.Label price_label;
        private System.Windows.Forms.TextBox insertText_2;
        private System.Windows.Forms.TextBox upDateText_2;
        private System.Windows.Forms.Label upDate_price_label;
        private System.Windows.Forms.Label display_price_label;
        private System.Windows.Forms.Label display_genre_label;
        private System.Windows.Forms.Label display_bookName_label;
        private System.Windows.Forms.Label display_bookId_label;
    }
}