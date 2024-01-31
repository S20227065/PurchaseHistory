// ----------------------------------------------------
//
// #DB-book#.cs
//
// 作成日：1/12
// 作成者：吉田 隼人
//
// 内容：会員の購入した本のDB
// ----------------------------------------------------
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace PurchaseHistory
{
    public partial class DB_book : Form
    {
        #region 変数

        //DBに使うテキスト
        private string[] bookReads = { "BookName_text", "Genre_text", "Price_text", "Book_ID"};
        //読み込んだデータを一時保存
        private string[] bookSaves = { "bookNameSave", "genreSave", "priceSave", "bookIbSave"};
        //空欄カウント
        private int _notText = 0;

        #endregion

        /// <summary>
        /// DB_book
        /// Bookデータベースのフォームを作成
        /// </summary>
        public DB_book()
        {
            //フォームの作成
            InitializeComponent();
        }

        /// <summary>
        /// CreateTableButton
        /// Bookデータベースを作成
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void CreateTableButton(object sender, EventArgs e)
        {
            //データベースの代入
            using (SQLiteConnection bookConnection = new SQLiteConnection("Data Source=book.db"))
            {
                //データベースを開く
                bookConnection.Open();
                //代入したデータベースの処理
                using (SQLiteCommand bookCommand = bookConnection.CreateCommand())
                {
                    //テーブル作成
                    bookCommand.CommandText = "create table m_book(book_ID INTEGER PRIMARY KEY AUTOINCREMENT," +
                        " bookName_text TEXT, genre_text TEXT, price_text TEXT)";
                    //SQLコマンドの終了
                    bookCommand.ExecuteNonQuery();
                }
                //データベースを閉じる
                bookConnection.Close();
            }
        }

        /// <summary>
        /// DataInsertButton
        /// データの追加
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void DataInsertButton(object sender, EventArgs e)
        {
            //カウントのリセット
            _notText = 0;

            //空欄がないか確認、あればカウント
            for (int i = 0; i < 3; i++)
            {
                if (String.IsNullOrEmpty(this.Controls["insertText_" + i].Text) == true)
                {
                    _notText++;
                }
            }

            //空欄が1箇所以上あればメッセージを出して、処理を終了
            if (_notText > 0)
            {
                // メッセージボックスを表示する
                MessageBox.Show("未記入が" + _notText + "箇所あります。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //処理を終了
                return;
            }

            //データベースの代入
            using (SQLiteConnection bookConnection = new SQLiteConnection("Data Source=book.db"))
            {
                //データベースを開く
                bookConnection.Open();
                //代入したデータベースの処理
                using (SQLiteTransaction bookTransaction = bookConnection.BeginTransaction())
                {
                    //SQLコマンドを宣言する
                    SQLiteCommand bookCommand = bookConnection.CreateCommand();
                    //SQL文
                    bookCommand.CommandText = "INSERT INTO m_book (bookName_text, genre_text, price_text) VALUES (@BookName_text, @Genre_text, @Price_text)";
                    //パラメータセット
                    bookCommand.Parameters.Add("BookName_text", System.Data.DbType.String);
                    bookCommand.Parameters.Add("Genre_text", System.Data.DbType.String);
                    bookCommand.Parameters.Add("Price_text", System.Data.DbType.String);

                    //データ追加
                    for (int i = 0; i < 3; i++)
                    {
                        //変更内容が記入されている場合、変更内容の値を代入
                        if (String.IsNullOrEmpty(this.Controls["insertText_" + i].Text) == false)
                        {
                            bookCommand.Parameters[bookReads[i]].Value = this.Controls["insertText_" + i].Text;
                        }
                    }

                    //SQLコマンドを終了
                    bookCommand.ExecuteNonQuery();
                    //コミット
                    bookTransaction.Commit();
                }
            }
        }

        /// <summary>
        /// DataReadButton
        /// データの読み込み
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void DataReadButton(object sender, EventArgs e)
        {
            //データベースの代入
            using (SQLiteConnection bookConnection = new SQLiteConnection("Data Source=book.db"))
            {
                //DataTableを生成します。
                DataTable dataTable = new DataTable();
                //SQLの実行
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM m_book", bookConnection);
                //SQLコマンドをデータテーブルに読み込み
                adapter.Fill(dataTable);
                //データテーブルを代入し、データベースの表示
                db_Display.DataSource = dataTable;
            }
        }

        /// <summary>
        /// DataUpDateButton
        /// データの更新
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void DataUpDateButton(object sender, EventArgs e)
        {
            //データベースを代入
            using (SQLiteConnection bookConnection = new SQLiteConnection("Data Source=book.db"))
            {
                //データベースを開く
                bookConnection.Open();
                //代入したデータベースの処理
                using (SQLiteTransaction bookTransaction = bookConnection.BeginTransaction())
                {
                    //SQLコマンドを宣言する
                    SQLiteCommand bookCommand = bookConnection.CreateCommand();
                    //DataTableを生成します。
                    DataTable dataTableUpDate = new DataTable();
                    //SQL文
                    bookCommand.CommandText = $" SELECT * FROM m_book WHERE book_ID = @Book_ID";
                    //パラメータセット
                    bookCommand.Parameters.Add("Book_ID", System.Data.DbType.Int64);
                    //データ追加
                    bookCommand.Parameters["Book_ID"].Value = upDateText_id.Text;
                    //データの読み込み
                    SQLiteDataReader reader = bookCommand.ExecuteReader();
                    //該当するデータの読み込み
                    while (reader.Read() == true)
                    {
                        //データベースから取り出したデータを配列に代入
                        bookSaves[0] = reader["BookName_text"].ToString();
                        bookSaves[1] = reader["Genre_text"].ToString();
                        bookSaves[2] = reader["Price_text"].ToString();
                        bookSaves[3] = reader["Book_ID"].ToString();
                    }
                    //データの読み込みを終了
                    reader.Close();
                    //SQLコマンドの終了
                    bookCommand.ExecuteNonQuery();

                    //SQL文
                    bookCommand.CommandText = "UPDATE m_book set bookName_text = @BookName_text, genre_text = @Genre_text," +
                        " price_text = @Price_text WHERE book_ID = @Book_ID";
                    //パラメータセット
                    bookCommand.Parameters.Add("BookName_text", System.Data.DbType.String);
                    bookCommand.Parameters.Add("Genre_text", System.Data.DbType.String);
                    bookCommand.Parameters.Add("Price_text", System.Data.DbType.String);

                    //データ追加
                    for (int i = 0; i < 3; i++)
                    {
                        //変更内容が記入されている場合、変更内容の値を代入
                        if (String.IsNullOrEmpty(this.Controls["upDateText_" + i].Text) == false)
                        {
                            bookCommand.Parameters[bookReads[i]].Value = this.Controls["upDateText_" + i].Text;
                        }
                        //変更内容が記入されていない場合、前に入っていた値を代入
                        else
                        {
                            bookCommand.Parameters[bookReads[i]].Value = bookSaves[i];
                        }
                    }
                    bookCommand.Parameters["Book_ID"].Value = int.Parse(upDateText_id.Text);

                    //SQLコマンドの終了
                    bookCommand.ExecuteNonQuery();
                    //コミット
                    bookTransaction.Commit();
                }
            }
        }

        /// <summary>
        /// DeleteButton
        /// データの削除
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void DeleteButton(object sender, EventArgs e)
        {
            //データベースの代入
            using (SQLiteConnection bookConnection = new SQLiteConnection("Data Source=book.db"))
            {
                //データベースを開く
                bookConnection.Open();
                //代入したデータベースの処理
                using (SQLiteTransaction bookTransaction = bookConnection.BeginTransaction())
                {
                    //SQLコマンドを宣言する
                    SQLiteCommand bookCommand = bookConnection.CreateCommand();
                    //SQL文
                    bookCommand.CommandText = "DELETE FROM m_book WHERE book_ID = @Book_ID;";
                    //パラメータセット
                    bookCommand.Parameters.Add("Book_ID", System.Data.DbType.Int64);
                    //データ削除
                    bookCommand.Parameters["Book_ID"].Value = int.Parse(deleteText_id.Text);
                    //SQLコマンドを終了
                    bookCommand.ExecuteNonQuery();
                    //コミット
                    bookTransaction.Commit();
                }
            }
        }

        /// <summary>
        /// SearchButton
        /// データの検索
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void SearchButton(object sender, EventArgs e)
        {
            //データベースの代入
            using (SQLiteConnection bookConnection = new SQLiteConnection("Data Source=book.db"))
            {
                //データベースを開く
                bookConnection.Open();
                //代入したデータベースの処理
                using (SQLiteTransaction bookTransaction = bookConnection.BeginTransaction())
                {
                    //SQLコマンドを宣言する
                    SQLiteCommand bookCommand = bookConnection.CreateCommand();
                    //DataTableを生成します。
                    DataTable dataTableId = new DataTable();
                    //SQL文
                    bookCommand.CommandText = $" SELECT * FROM m_book WHERE book_ID = @Book_ID";
                    //パラメータセット
                    bookCommand.Parameters.Add("Book_ID", System.Data.DbType.Int64);
                    //データ追加
                    bookCommand.Parameters["Book_ID"].Value = searchText_id.Text;
                    //データの読み込み
                    SQLiteDataReader reader = bookCommand.ExecuteReader();
                    //該当するデータの読み込み
                    while (reader.Read() == true)
                    {
                        //データベースから取り出したデータを配列に代入
                        bookSaves[0] = reader["BookName_text"].ToString();
                        bookSaves[1] = reader["Genre_text"].ToString();
                        bookSaves[2] = reader["Price_text"].ToString();
                        bookSaves[3] = reader["Book_ID"].ToString();
                    }
                    //データの読み込みを終了
                    reader.Close();
                }
            }

            //ラベルに記入
            display_bookId_label.Text = "ID:" + bookSaves[3].ToString();
            display_bookName_label.Text = "BookName:" + bookSaves[0].ToString();
            display_genre_label.Text = "Genre:" + bookSaves[1].ToString();
            display_price_label.Text = "Price:" + bookSaves[2].ToString();

        }
    }
}
