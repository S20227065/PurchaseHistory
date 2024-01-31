// ----------------------------------------------------
//
// #DB-Management#.cs
//
// 作成日：12/14
// 作成者：吉田 隼人
//
// 内容：会員情報管理のDB
// ----------------------------------------------------
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace PurchaseHistory
{
    public partial class DB_Manegement : Form
    {
        #region 変数

        //DBに使うテキスト
        private string[] memberReads = { "Name_text", "Address_text", "Email_text", "Phone_number", "Post_text", "Client_ID", "before_login" };
        //読み込んだデータを一時保存
        private string[] memberSaves = { "nameSave", "addressSave", "emailSave", "phoneSave", "postSave", "clientIbSave", "searchSave" };

        //int型のTextBoxにstring型が入っていた場合、代わりに返す値
        private int _notUpDateInteger = 1;
        private int _notInSertInteger = default;
        //空欄カウント
        private int _notText = 0;

        #endregion

        /// <summary>
        /// DB_Manegement
        /// memberデータベースのフォームの作成
        /// </summary>
        public DB_Manegement()
        {
            //フォームを作成
            InitializeComponent();
        }

        /// <summary>
        /// CreateTableButton
        /// memberのデータベースのテーブルの作成
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void CreateTableButton(object sender, EventArgs e)
        {
            //データベースを代入
            using (SQLiteConnection memberConnection = new SQLiteConnection("Data Source=member.db"))
            {
                //データベースを開く
                memberConnection.Open();
                //コマンドを宣言する
                using (SQLiteCommand memberCommand = memberConnection.CreateCommand())
                {
                    //テーブル作成
                    memberCommand.CommandText = "create table m_member(client_ID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                        "name_text TEXT, address_text TEXT, email_text TEXT, phone_number INTEGER, post_text TEXT, " +
                        "before_Login NUMERIC)";
                    //SQLコマンドを終了
                    memberCommand.ExecuteNonQuery();
                }
                //データベースを閉じる
                memberConnection.Close();
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
            using (SQLiteConnection memberConnection = new SQLiteConnection("Data Source=member.db"))
            {
                //DataTableを生成します。
                DataTable dataTable = new DataTable();
                //SQLの実行
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM m_member", memberConnection);
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
            //カウントをリセット
            _notText = 0;

            //空欄がないか確認、あればカウント
            for (int i = 0; i < 5; i++)
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

            //int型のTextBoxにstring型が入っていないかを確認、メッセージを出して、処理を終了
            if (false == int.TryParse(insertText_3.Text, out _notInSertInteger))
            {
                if (_notInSertInteger == 0)
                {
                    // メッセージボックスを表示する
                    MessageBox.Show("記入内容に間違いがあります。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //処理を終了
                    return;
                }
            }

            //trueかfalseのみ通す、それ以外の値の場合エラー
            if (!(this.Controls["insertText_6"].Text == "false" || this.Controls["insertText_6"].Text == "true"))
            {
                // メッセージボックスを表示する
                MessageBox.Show("記入内容に間違いがあります。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //処理を終了
                return;
            }

            //データベースを代入
            using (SQLiteConnection memberConnection = new SQLiteConnection("Data Source=member.db"))
            {
                //データベースを開く
                memberConnection.Open();
                //代入したデータベースの処理
                using (SQLiteTransaction memberTransaction = memberConnection.BeginTransaction())
                {
                    //コマンドを宣言する
                    SQLiteCommand memberCommand = memberConnection.CreateCommand();
                    //SQL文
                    memberCommand.CommandText = "INSERT INTO m_member (name_text, address_text, email_text, phone_number, " +
                        "post_text,  before_Login) VALUES (@Name_text, @Address_text, @Email_text, @Phone_number, " +
                        "@Post_text, @Before_Login)";
                    //パラメータセット
                    memberCommand.Parameters.Add("Name_text", System.Data.DbType.String);
                    memberCommand.Parameters.Add("Address_text", System.Data.DbType.String);
                    memberCommand.Parameters.Add("Email_text", System.Data.DbType.String);
                    memberCommand.Parameters.Add("Phone_number", System.Data.DbType.Int64);
                    memberCommand.Parameters.Add("Post_text", System.Data.DbType.String);
                    memberCommand.Parameters.Add("Before_Login", System.Data.DbType.Boolean);

                    //データ追加
                    for (int i = 0; i < 5; i++)
                    {
                        //変更内容が記入されている場合、変更内容の値を代入
                        //stringの場合
                        if (String.IsNullOrEmpty(this.Controls["insertText_" + i].Text) == false)
                        {
                            memberCommand.Parameters[memberReads[i]].Value = this.Controls["insertText_" + i].Text;
                        }
                        //intの場合
                        else if (i == 3)
                        {
                            //変更内容が記入されている場合、変更内容の値を代入
                            if (String.IsNullOrEmpty(this.Controls["insertText_" + i].Text) == false)
                            {
                                memberCommand.Parameters[memberReads[i]].Value = Int64.Parse(this.Controls["insertText_" + i].Text);
                            }
                        }
                    }
                    //trueかfalseに変更
                    memberCommand.Parameters["Before_Login"].Value = Boolean.Parse(this.Controls["insertText_6"].Text.ToString());

                    //SQLコマンドを終了
                    memberCommand.ExecuteNonQuery();
                    //コミット
                    memberTransaction.Commit();
                }
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
            //int型のTextBoxにstring型が入っていないかを確認、メッセージを出して、処理を終了
            if (String.IsNullOrEmpty(this.Controls["upDateText_3"].Text) == false) 
            { 
                if (false == int.TryParse(upDateText_3.Text, out _notUpDateInteger))
                {
                    if (_notUpDateInteger == 1)
                    {
                        // メッセージボックスを表示する
                        MessageBox.Show("記入内容に間違いがあります。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //処理を終了
                        return;
                    }
                }
            }

            if (String.IsNullOrEmpty(this.Controls["upDateText_3"].Text) == true)
            {
                //trueかfalseのみ通す、それ以外の値の場合エラー
                if (!(this.Controls["upDateText_6"].Text == "false" || this.Controls["upDateText_6"].Text == "true"))
                {
                    // メッセージボックスを表示する
                    MessageBox.Show("記入内容に間違いがあります。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //データベースを代入
            using (SQLiteConnection memberConnection = new SQLiteConnection("Data Source=member.db"))
            {
                //データベースを開く
                memberConnection.Open();
                //代入したデータベースの処理
                using (SQLiteTransaction memberTransaction = memberConnection.BeginTransaction())
                {
                    //SQLコマンドを宣言する
                    SQLiteCommand memberCommand = memberConnection.CreateCommand();
                    //DataTableを生成します。
                    DataTable dataTable_update = new DataTable();
                    //SQL文
                    memberCommand.CommandText = $" SELECT * FROM m_member WHERE client_ID = @Client_ID";
                    //パラメータセット
                    memberCommand.Parameters.Add("Client_ID", System.Data.DbType.Int64);
                    //データ追加
                    memberCommand.Parameters["Client_ID"].Value = upDateText_id.Text;
                    //データの読み込み
                    SQLiteDataReader reader = memberCommand.ExecuteReader();
                    //該当するデータの読み込み
                    while (reader.Read() == true)
                    {
                        //データベースから取り出したデータを配列に代入
                        memberSaves[0] = reader["Name_text"].ToString();
                        memberSaves[1] = reader["Address_text"].ToString();
                        memberSaves[2] = reader["Email_text"].ToString();
                        memberSaves[3] = reader["Phone_number"].ToString();
                        memberSaves[4] = reader["Post_text"].ToString();
                        memberSaves[5] = reader["Client_ID"].ToString();
                        memberSaves[6] = reader["before_Login"].ToString();
                    }
                    //データの読み込みを終了
                    reader.Close();
                    //SQLコマンドを終了
                    memberCommand.ExecuteNonQuery();

                    //SQL文
                    memberCommand.CommandText = "UPDATE m_member set name_text = @Name_text, address_text = @Address_text, email_text = @Email_text, phone_number = @Phone_number, post_text = @Post_text,before_Login = @Before_Login  WHERE client_ID = @Client_ID";
                    //パラメータセット
                    memberCommand.Parameters.Add("Name_text", System.Data.DbType.String);
                    memberCommand.Parameters.Add("Address_text", System.Data.DbType.String);
                    memberCommand.Parameters.Add("Email_text", System.Data.DbType.String);
                    memberCommand.Parameters.Add("Phone_number", System.Data.DbType.Int64);
                    memberCommand.Parameters.Add("Post_text", System.Data.DbType.String);
                    memberCommand.Parameters.Add("Client_ID", System.Data.DbType.Int64);
                    memberCommand.Parameters.Add("Before_Login", System.Data.DbType.Boolean);

                    //データ追加
                    for (int i = 0; i < 5; i++)
                    {
                        //変更内容が記入されている場合、変更内容の値を代入
                        if (String.IsNullOrEmpty(this.Controls["upDateText_" + i].Text) == false)
                        {
                            memberCommand.Parameters[memberReads[i]].Value = this.Controls["upDateText_" + i].Text;
                        }
                        //変更内容が記入されていない場合、前に入っていた値を代入
                        else
                        {
                            memberCommand.Parameters[memberReads[i]].Value = memberSaves[i];
                        }
                    }

                    //tureかfalseが記入されて入れば処理、空欄だったらfalse
                    if (String.IsNullOrEmpty(this.Controls["upDateText_3"].Text) == true)
                    {
                        //trueかfalseに変更
                        if (this.Controls["upDateText_6"].Text.ToString() == "true")
                        {
                            memberCommand.Parameters["Before_Login"].Value = Boolean.Parse(true.ToString());
                        }
                        else if (this.Controls["upDateText_6"].Text.ToString() == "false")
                        {
                            memberCommand.Parameters["Before_Login"].Value = Boolean.Parse(false.ToString());
                        }
                    }
                    else
                    {
                        //falseを代入
                        memberCommand.Parameters["Before_Login"].Value = Boolean.Parse(false.ToString());
                    }
                    memberCommand.Parameters["Client_ID"].Value = int.Parse(upDateText_id.Text);

                    //SQLコマンドを終了
                    memberCommand.ExecuteNonQuery();
                    //コミット
                    memberTransaction.Commit();
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
            //データベースに代入
            using (SQLiteConnection memberConnection = new SQLiteConnection("Data Source=member.db"))
            {
                //データベースを開く
                memberConnection.Open();
                //代入したデータベースの処理
                using (SQLiteTransaction memberTransaction = memberConnection.BeginTransaction())
                {
                    //SQLコマンドを宣言する
                    SQLiteCommand memberCommand = memberConnection.CreateCommand();
                    //SQL文
                    memberCommand.CommandText = "DELETE FROM m_member WHERE client_ID = @Client_ID;";
                    //パラメータセット
                    memberCommand.Parameters.Add("Client_ID", System.Data.DbType.Int64);
                    //データ削除
                    memberCommand.Parameters["Client_ID"].Value = int.Parse(deleteText_id.Text);
                    //SQLコマンドを終了
                    memberCommand.ExecuteNonQuery();
                    //コミット
                    memberTransaction.Commit();
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
            using (SQLiteConnection memberConnection = new SQLiteConnection("Data Source=member.db"))
            {
                //データベースを開く
                memberConnection.Open();
                //代入したデータベースの処理
                using (SQLiteTransaction memberTransaction = memberConnection.BeginTransaction())
                {
                    // SQLコマンドを宣言する
                    SQLiteCommand memberCommand = memberConnection.CreateCommand();
                    //DataTableを生成します。
                    DataTable dataTable_ID = new DataTable();
                    //SQL文
                    memberCommand.CommandText = $" SELECT * FROM m_member WHERE client_ID = @Client_ID";
                    //パラメータセット
                    memberCommand.Parameters.Add("Client_ID", System.Data.DbType.Int64);
                    //データ追加
                    memberCommand.Parameters["Client_ID"].Value = searchText_id.Text;
                    //データの読み込み
                    SQLiteDataReader reader = memberCommand.ExecuteReader();
                    //該当するデータの読み込み
                    while (reader.Read() == true)
                    {
                        //データベースから取り出したデータを配列に代入
                        memberSaves[0] = reader["Name_text"].ToString();
                        memberSaves[1] = reader["Address_text"].ToString();
                        memberSaves[2] = reader["Email_text"].ToString();
                        memberSaves[3] = reader["Phone_number"].ToString();
                        memberSaves[4] = reader["Post_text"].ToString();
                        memberSaves[5] = reader["Client_ID"].ToString();
                        memberSaves[6] = reader["before_Login"].ToString();
                    }
                    //データの読み込みを終了
                    reader.Close();
                }
            }

            //ラベルに記入
            display_id_label.Text = "ID:" + memberSaves[5].ToString();
            display_name_label.Text = "Name:" + memberSaves[0].ToString();
            display_address_label.Text = "Address:" + memberSaves[1].ToString();
            display_email_label.Text = "Email:" + memberSaves[2].ToString();
            display_phone_label.Text = "Phone:" + memberSaves[3].ToString();
            display_post_label.Text = "Post:" + memberSaves[4].ToString();
        }

        /// <summary>
        /// SaveSearchButton
        /// 検索中の会員を表示する
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void SaveSearchButton(object sender, EventArgs e)
        {
            //データベースを代入
            using (SQLiteConnection memberConnection = new SQLiteConnection("Data Source=member.db"))
            {
                //データベースを開く
                memberConnection.Open();
                //代入したデータベースの処理
                using (SQLiteTransaction memberTransaction = memberConnection.BeginTransaction())
                {
                    //SQLコマンドを宣言する
                    SQLiteCommand memberCommand = memberConnection.CreateCommand();
                    //DataTableを生成します。
                    DataTable dataTable_ID = new DataTable();
                    //SQL文
                    memberCommand.CommandText = $" SELECT * FROM m_member WHERE before_Login = @Before_Login";
                    //パラメータセット
                    memberCommand.Parameters.Add("Before_Login", System.Data.DbType.Boolean);
                    //データ追加
                    memberCommand.Parameters["Before_Login"].Value = Boolean.Parse(true.ToString()); ;
                    //データの読み込み
                    SQLiteDataReader reader = memberCommand.ExecuteReader();
                    //該当するデータの読み込み
                    while (reader.Read() == true)
                    {
                        //データベースから取り出したデータを配列に代入
                        memberSaves[0] = reader["Name_text"].ToString();
                        memberSaves[1] = reader["Address_text"].ToString();
                        memberSaves[2] = reader["Email_text"].ToString();
                        memberSaves[3] = reader["Phone_number"].ToString();
                        memberSaves[4] = reader["Post_text"].ToString();
                        memberSaves[5] = reader["Client_ID"].ToString();
                        memberSaves[6] = reader["before_Login"].ToString();
                    }
                    //データの読み込みを終了
                    reader.Close();
                }
            }

            //ラベルに記入
            display_id_label.Text = "ID:" + memberSaves[5].ToString();
            display_name_label.Text = "Name:" + memberSaves[0].ToString();
            display_address_label.Text = "Address:" + memberSaves[1].ToString();
            display_email_label.Text = "Email:" + memberSaves[2].ToString();
            display_phone_label.Text = "Phone:" + memberSaves[3].ToString();
            display_post_label.Text = "Post:" + memberSaves[4].ToString();
        }
    }
}
