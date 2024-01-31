// ----------------------------------------------------
//
// #DB-History#.cs
//
// 作成日：1/12
// 作成者：吉田 隼人
//
// 内容：会員の購入履歴DB
// ----------------------------------------------------
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace PurchaseHistory
{
    public partial class DB_History : Form
    {
        #region 変数

        //DBに使うテキスト
        private string[] historyReads = { "Manegement_id", "Book_id", "BuyBook_text", "BuyDate_text", "History_id" };
        //読み込んだデータを一時保存
        private string[] historySaves = { "_manegementIdSave", "_bookIdSave", "_buyBookSave", "_buyDateSave", "_historyIbSave" };

        #endregion

        /// <summary>
        /// DB_History
        /// Historyデータベースのフォームを作成
        /// </summary>
        public DB_History()
        {
            //フォームを作成
            InitializeComponent();
        }

        /// <summary>
        /// CreateTableButton
        /// Historyデータベースのテーブルを作成
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void CreateTableButton(object sender, EventArgs e)
        {
            //データベースを代入
            using (SQLiteConnection historyConnection = new SQLiteConnection("Data Source=history.db"))
            {
                //データベースを開く
                historyConnection.Open();
                //SQLコマンドの宣言する
                using (SQLiteCommand historyCommand = historyConnection.CreateCommand())
                {
                    //テーブル作成
                    historyCommand.CommandText = "create table m_history(history_id INTEGER PRIMARY KEY AUTOINCREMENT," +
                        " manegement_id INTEGER, book_id INTEGER, buyBook_text TEXT, buyDate_text TEXT," +
                        " FOREIGN KEY(manegement_id) REFERENCES m_member(client_ID)," +
                        " FOREIGN KEY(book_id) REFERENCES m_book(book_ID)" +
                        " FOREIGN KEY(buyBook_text) REFERENCES m_book(bookName_text))";
                    //SQLコマンドを終了
                    historyCommand.ExecuteNonQuery();
                }
                //データベースを閉じる
                historyConnection.Close();
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
            //データベースを代入
            using (SQLiteConnection historyConnection = new SQLiteConnection("Data Source=history.db"))
            {
                //DataTableを生成します。
                DataTable dataTable = new DataTable();
                //SQLの実行
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM m_history", historyConnection);
                //データテーブルにSQLコマンドを代入
                adapter.Fill(dataTable);
                //データテーブルを代入し、データベースを表示
                db_Display.DataSource = dataTable;
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
            //データベースに代入
            using (SQLiteConnection historyConnection = new SQLiteConnection("Data Source=history.db"))
            {
                //データベースを開く
                historyConnection.Open();
                //代入したデータベースの処理
                using (SQLiteTransaction historyTransaction = historyConnection.BeginTransaction())
                {
                    //SQLコマンドの宣言をする
                    SQLiteCommand historyCommand = historyConnection.CreateCommand();
                    //SQL文
                    historyCommand.CommandText = "INSERT INTO m_history (manegement_id, book_id, buyBook_text, buyDate_text) " +
                        "VALUES (@Manegement_id, @Book_id, @BuyBook_text, @BuyDate_text)";
                    //パラメータセット
                    historyCommand.Parameters.Add("Manegement_id", System.Data.DbType.Int64);
                    historyCommand.Parameters.Add("Book_id", System.Data.DbType.Int64);
                    historyCommand.Parameters.Add("BuyBook_text", System.Data.DbType.String);
                    historyCommand.Parameters.Add("BuyDate_text", System.Data.DbType.String);

                    //データ追加
                    for (int i = 0; i < 4; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                historyCommand.Parameters[historyReads[i]].Value = int.Parse(this.Controls["insertText_" + i].Text);
                                break;

                            case 1:
                                historyCommand.Parameters[historyReads[i]].Value = int.Parse(this.Controls["insertText_" + i].Text);
                                break;

                            case 2:
                                historyCommand.Parameters[historyReads[i]].Value = historySaves[2];
                                break;

                            case 3:
                                historyCommand.Parameters[historyReads[i]].Value = this.Controls["insertText_" + i].Text;
                                break;
                        }
                    }
                    //SQLコマンドを終了
                    historyCommand.ExecuteNonQuery();
                    //コミット
                    historyTransaction.Commit();
                }
            }
        }

        /// <summary>
        /// DataUpDateButton
        /// データの更新
        /// </summary>
        /// <param name="sender">フォームの作成に追加</param>
        /// <param name="e">フォームの作成に追加</param>
        private void DataUpDateButton(object sender, EventArgs e)
        {
            //データベースを代入
            using (SQLiteConnection historyConnection = new SQLiteConnection("Data Source=history.db"))
            {
                //データベースを開く
                historyConnection.Open();
                //代入したデータベースの処理
                using (SQLiteTransaction historyTransaction = historyConnection.BeginTransaction())
                {
                    //SQLコマンドを宣言する
                    SQLiteCommand historyCommand = historyConnection.CreateCommand();
                    //DataTableを生成します。
                    DataTable dataTableUpDate = new DataTable();
                    //SQL文
                    historyCommand.CommandText = $" SELECT * FROM m_history WHERE history_id = @History_id";
                    //パラメータセット
                    historyCommand.Parameters.Add("History_id", System.Data.DbType.Int64);
                    //データ追加
                    historyCommand.Parameters["History_id"].Value = upDateText_id.Text;
                    //データの読み込み
                    SQLiteDataReader reader = historyCommand.ExecuteReader();
                    //該当するデータの読み込み
                    while (reader.Read() == true)
                    {
                        //データベースから取り出したデータを配列に代入
                        historySaves[0] = reader["Manegement_id"].ToString();
                        historySaves[1] = reader["Book_id"].ToString();
                        historySaves[3] = reader["BuyDate_text"].ToString();
                        historySaves[4] = reader["History_id"].ToString();
                    }
                    //データの読み込みを終了
                    reader.Close();
                    //SQLコマンドを終了
                    historyCommand.ExecuteNonQuery();

                    //SQL文
                    historyCommand.CommandText = "UPDATE m_history set manegement_id = @Manegement_id, book_id = @Book_id, " +
                        "buyBook_text = @BuyBook_text, buyDate_text = @BuyDate_text WHERE history_id = @History_id";
                    //パラメータセット
                    historyCommand.Parameters.Add("Manegement_id", System.Data.DbType.Int64);
                    historyCommand.Parameters.Add("Book_id", System.Data.DbType.Int64);
                    historyCommand.Parameters.Add("BuyBook_text", System.Data.DbType.String);
                    historyCommand.Parameters.Add("BuyDate_text", System.Data.DbType.String);

                    //データ追加
                    for (int i = 0; i < 4; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                //変更内容が記入されている場合、変更内容の値を代入
                                if (String.IsNullOrEmpty(this.Controls["upDateText_" + i].Text) == false)
                                {
                                    historyCommand.Parameters[historyReads[i]].Value = int.Parse(this.Controls["upDateText_" + i].Text);
                                }
                                //変更内容が記入されていない場合、前に入っていた値を代入
                                else
                                {
                                    historyCommand.Parameters[historyReads[i]].Value = int.Parse(historySaves[i]);
                                }
                                break;

                            case 1:
                                //変更内容が記入されている場合、変更内容の値を代入
                                if (String.IsNullOrEmpty(this.Controls["upDateText_" + i].Text) == false)
                                {
                                    historyCommand.Parameters[historyReads[i]].Value = int.Parse(this.Controls["upDateText_" + i].Text);
                                }
                                //変更内容が記入されていない場合、前に入っていた値を代入
                                else
                                {
                                    historyCommand.Parameters[historyReads[i]].Value = int.Parse(historySaves[i]);
                                }
                                break;

                            case 2:
                                historyCommand.Parameters[historyReads[i]].Value = historySaves[i];
                                break;

                            case 3:
                                //変更内容が記入されている場合、変更内容の値を代入
                                if (String.IsNullOrEmpty(this.Controls["upDateText_" + i].Text) == false)
                                {
                                    historyCommand.Parameters[historyReads[i]].Value = this.Controls["upDateText_" + i].Text;
                                }
                                //変更内容が記入されていない場合、前に入っていた値を代入
                                else
                                {
                                    historyCommand.Parameters[historyReads[i]].Value = historySaves[i];
                                }
                                break;
                        }
                    }
                    historyCommand.Parameters["History_id"].Value = int.Parse(upDateText_id.Text);

                    //SQLコマンドを終了
                    historyCommand.ExecuteNonQuery();
                    //コミット
                    historyTransaction.Commit();
                }
            }
        }

        /// <summary>
        /// DataDeleteButton
        /// データの削除
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void DataDeleteButton(object sender, EventArgs e)
        {
            //データベースを代入
            using (SQLiteConnection historyConnection = new SQLiteConnection("Data Source=history.db"))
            {
                //データベースを開く
                historyConnection.Open();
                //代入したデータベースの処理
                using (SQLiteTransaction historyTransaction = historyConnection.BeginTransaction())
                {
                    //SQLコマンドを宣言する
                    SQLiteCommand historyCommand = historyConnection.CreateCommand();
                    //SQL文
                    historyCommand.CommandText = "DELETE FROM m_history WHERE history_id = @History_id;";
                    //パラメータセット
                    historyCommand.Parameters.Add("History_id", System.Data.DbType.Int64);
                    //データ削除
                    historyCommand.Parameters["History_id"].Value = int.Parse(deleteText_id.Text);
                    //SQLコマンドを終了
                    historyCommand.ExecuteNonQuery();
                    //コミット
                    historyTransaction.Commit();
                }
            }
        }

        /// <summary>
        /// DataSearchButton
        /// データの検索
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void DataSearchButton(object sender, EventArgs e)
        {
            //データベースを代入
            using (SQLiteConnection historyConnection = new SQLiteConnection("Data Source=history.db"))
            {
                //データベースを開く
                historyConnection.Open();
                //代入したデータベースの処理
                using (SQLiteTransaction historyTransaction = historyConnection.BeginTransaction())
                {
                    //SQLコマンドを宣言する
                    SQLiteCommand historyCommand = historyConnection.CreateCommand();
                    //DataTableを生成します。
                    DataTable dataTable_ID = new DataTable();
                    //SQL文
                    historyCommand.CommandText = $" SELECT * FROM m_history WHERE history_id = @History_id";
                    //パラメータセット
                    historyCommand.Parameters.Add("History_id", System.Data.DbType.Int64);
                    //データ追加
                    historyCommand.Parameters["History_id"].Value = searchText_id.Text;
                    //データの読み込み
                    SQLiteDataReader reader = historyCommand.ExecuteReader();
                    //該当するデータの読み込み
                    while (reader.Read() == true)
                    {
                        //データベースから取り出したデータを配列に代入
                        historySaves[0] = reader["Manegement_id"].ToString();
                        historySaves[1] = reader["Book_id"].ToString();
                        historySaves[2] = reader["BuyBook_text"].ToString();
                        historySaves[3] = reader["BuyDate_text"].ToString();
                        historySaves[4] = reader["History_id"].ToString();
                    }
                    //SQLコマンドを終了
                    reader.Close();
                }
            }

            //ラベルに記入
            display_ManagementID_label.Text = "ManagementID:" + historySaves[0].ToString();
            display_BookID_label.Text = "BookID:" + historySaves[1].ToString();
            display_buyBook_label.Text = "BuyBook:" + historySaves[2].ToString();
            display_buyDeta_label.Text = "BuyDeta:" + historySaves[3].ToString();

        }

        /// <summary>
        /// InsertTextBox
        /// Insertテキストボックスに文字が入力された時、BookIDからBookNameを取り出し、代入
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void InsertTextBox(object sender, EventArgs e)
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
                    DataTable dataTableUpDate = new DataTable();
                    //SQL文
                    bookCommand.CommandText = $" SELECT * FROM m_book WHERE book_ID = @Book_ID";
                    //パラメータセット
                    bookCommand.Parameters.Add("Book_ID", System.Data.DbType.Int64);
                    //データ追加
                    bookCommand.Parameters["Book_ID"].Value = insertText_1.Text;
                    //データの読み込み
                    SQLiteDataReader reader = bookCommand.ExecuteReader();
                    //該当するデータの読み込み
                    while (reader.Read() == true)
                    {
                        //データベースから取り出したデータを配列に代入
                        historySaves[2] = reader["BookName_text"].ToString();
                    }
                    //データの読み込みを終了
                    reader.Close();
                    //SQLコマンドを終了
                    bookCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// UpDataTextBox
        /// UpDataテキストボックスに文字が入力された時、BookIDからBookNameを取り出し、代入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpDataTextBox(object sender, EventArgs e)
        {
            //データベースを代入
            using (SQLiteConnection bookConnection= new SQLiteConnection("Data Source=book.db"))
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
                    //インサート
                    bookCommand.CommandText = $" SELECT * FROM m_book WHERE book_ID = @Book_ID";
                    //パラメータセット
                    bookCommand.Parameters.Add("Book_ID", System.Data.DbType.Int64);
                    //データ追加
                    bookCommand.Parameters["Book_ID"].Value = upDateText_1.Text;
                    //データの読み込み
                    SQLiteDataReader reader = bookCommand.ExecuteReader();
                    //該当するデータの読み込み
                    while (reader.Read() == true)
                    {
                        //データベースから取り出したデータを配列に代入
                        historySaves[2] = reader["BookName_text"].ToString();
                    }
                    //データの読み込みを終了
                    reader.Close();
                    //SQLコマンドを終了
                    bookCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
