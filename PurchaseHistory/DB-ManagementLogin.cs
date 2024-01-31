// ----------------------------------------------------
//
// #DB-ManagementLogin#.cs
//
// 作成日：12/14
// 作成者：吉田 隼人
//
// 内容：管理者ログインに必要なDB
// ----------------------------------------------------
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace PurchaseHistory
{
    public partial class DB_managementLogin : Form
    {
        #region 変数

        string _id = default;
        string _passWord = default;

        #endregion

        /// <summary>
        /// DB_managementLogin
        /// administratorデータベースのフォームを作成
        /// </summary>
        public DB_managementLogin()
        {
            //フォームを作成
            InitializeComponent();
        }

        /// <summary>
        /// CreateTableButton
        /// administratorのデータベースのテーブルの作成
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void CreateTableButton(object sender, EventArgs e)
        {
            //データベースを代入
            using (SQLiteConnection administratorConnection = new SQLiteConnection("Data Source=administrator.db"))
            {
                //データベースを開く
                administratorConnection.Open();
                //SQLコマンドを宣言する
                using (SQLiteCommand administratorCommand = administratorConnection.CreateCommand())
                {
                    //テーブル作成
                    administratorCommand.CommandText = "create table m_administrator(ad INTEGER PRIMARY KEY AUTOINCREMENT, " +
                        "a_managementID TEXT, a_passWord TEXT)";
                    //SQLコマンドを終了
                    administratorCommand.ExecuteNonQuery();
                }
                //データベースを閉じる
                administratorConnection.Close();
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
            //データベースを代入
            using (SQLiteConnection administratorConnection = new SQLiteConnection("Data Source=administrator.db"))
            {
                //データベースを開く
                administratorConnection.Open();
                //代入したデータベースの処理
                using (SQLiteTransaction administratorTransaction = administratorConnection.BeginTransaction())
                {
                    //SQLコマンドを宣言する
                    SQLiteCommand administratorCommand = administratorConnection.CreateCommand();
                    //SQL文
                    administratorCommand.CommandText = "INSERT INTO m_administrator (a_managementID, a_passWord) " +
                        "VALUES (@a_ManagementID, @_passWord)";
                    //パラメータセット
                    administratorCommand.Parameters.Add("a_ManagementID", System.Data.DbType.String);
                    administratorCommand.Parameters.Add("_passWord", System.Data.DbType.String);
                    //データ追加
                    administratorCommand.Parameters["a_ManagementID"].Value = insertText_managementID.Text;
                    administratorCommand.Parameters["_passWord"].Value = insertText_password.Text;
                    //SQLコマンドを終了
                    administratorCommand.ExecuteNonQuery();
                    //コミット
                    administratorTransaction.Commit();
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
            //データベースを代入
            using (SQLiteConnection administratorConnection = new SQLiteConnection("Data Source=administrator.db"))
            {
                //DataTableを生成します。
                DataTable dataTable = new DataTable();
                //SQLの実行
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM m_administrator", administratorConnection);
                //データテーブルにSQLコマンドを代入
                adapter.Fill(dataTable);
                //データテーブルを代入し、データベースを表示
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
            using (SQLiteConnection administratorConnection = new SQLiteConnection("Data Source=administrator.db"))
            {
                //データベースを開く
                administratorConnection.Open();
                //代入したデータベースの処理
                using (SQLiteTransaction administratorTransaction = administratorConnection.BeginTransaction())
                {
                    //SQLコマンドを宣言する
                    SQLiteCommand administratorCommand = administratorConnection.CreateCommand();
                    //SQL文
                    administratorCommand.CommandText = "UPDATE m_administrator set a_managementID = @a_ManagementID, a_passWord = @_passWord WHERE ad = @Ad";
                    //パラメータセット
                    administratorCommand.Parameters.Add("a_ManagementID", System.Data.DbType.String);
                    administratorCommand.Parameters.Add("_passWord", System.Data.DbType.String);
                    administratorCommand.Parameters.Add("Ad", System.Data.DbType.Int64);
                    //データ追加
                    administratorCommand.Parameters["a_ManagementID"].Value = upDate_managementID.Text;
                    administratorCommand.Parameters["_passWord"].Value = upDate_password.Text;
                    administratorCommand.Parameters["Ad"].Value = int.Parse(update_id.Text);
                    //SQLコマンドを終了
                    administratorCommand.ExecuteNonQuery();
                    //コミット
                    administratorTransaction.Commit();
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
            using (SQLiteConnection administratorConnection = new SQLiteConnection("Data Source=administrator.db"))
            {
                //データベースを開く
                administratorConnection.Open();
                //代入したデータベースの処理
                using (SQLiteTransaction administratorTransaction = administratorConnection.BeginTransaction())
                {
                    //SQLコマンドを宣言する
                    SQLiteCommand administratorCommand = administratorConnection.CreateCommand();
                    //SQL文
                    administratorCommand.CommandText = "DELETE FROM m_administrator WHERE ad = @Ad;";
                    //パラメータセット
                    administratorCommand.Parameters.Add("Ad", System.Data.DbType.Int64);
                    //データ削除
                    administratorCommand.Parameters["Ad"].Value = int.Parse(deleteText_id.Text);
                    //SQLコマンドを終了
                    administratorCommand.ExecuteNonQuery();
                    //コミット
                    administratorTransaction.Commit();
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
            using (SQLiteConnection administratorConnection = new SQLiteConnection("Data Source=administrator.db"))
            {
                //データベースを開く
                administratorConnection.Open();
                //代入したデータベースの処理
                using (SQLiteTransaction administratorTransaction = administratorConnection.BeginTransaction())
                {
                    // SQLコマンドを宣言する
                    SQLiteCommand administratorCommand = administratorConnection.CreateCommand();
                    //DataTableを生成します。
                    DataTable dataTableId = new DataTable();
                    //SQL文
                    administratorCommand.CommandText = $" SELECT * FROM m_administrator WHERE a_managementID = @a_ManagementID";
                    //パラメータセット
                    administratorCommand.Parameters.Add("a_ManagementID", System.Data.DbType.Int64);
                    //データ追加
                    administratorCommand.Parameters["a_ManagementID"].Value = searchText_id.Text;
                    //データ読み込み
                    SQLiteDataReader reader = administratorCommand.ExecuteReader();
                    //データの読み込みを終了
                    while (reader.Read() == true)
                    {
                        //データベースから取り出したデータを配列に代入
                        _id = reader["a_ManagementID"].ToString();
                        _passWord = reader["_passWord"].ToString();

                        //ID、パスワードを表示
                        Console.WriteLine((String.Format($"ID:{_id} PassWard:{_passWord}")));
                    }
                    //データの読み込みを終了
                    reader.Close();
                }
            }   
        }
    }
}
