// ----------------------------------------------------
//
// #ChangeCheck#.cs
//
// 作成日：12/14
// 作成者：吉田 隼人
//
// 内容：会員情報変更内容確認画面
// ----------------------------------------------------
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace PurchaseHistory
{
    public partial class ChangeCheck : Form
    {
        #region 変数

        //読み込んだデータを一時保存
        private string[] memberSaves = { "_nameSave", "_addressSave", "_emailSave", "_phoneSave", "_postSave", "_memberIdSave", "_searchSave" };

        //SQLコマンドの変数を指定する時に使用
        private enum memberEnums
        {
            _nameText,
            _addressText,
            _emailText,
            _phoneNumber,
            _postText,
            _clientId,
            _beforeBool
        }

        //データ読み込み時のカウント
        private int _readCount = 0;

        //データ追加する際に、for文を回す回数
        private const int CHANGE_INPUT_COUNT = 5;
        //データを読み込む際に、for文を回す回数
        private const int READ_COUNT = 6;

        #endregion

        /// <summary>
        /// ChangeCheck
        /// 会員変更確認画面のフォームを作成
        /// </summary>
        public ChangeCheck()
        {
            //フォームを作成
            InitializeComponent();
        }

        /// <summary>
        /// ChangeButton
        /// 会員検索結果画面のフォームに遷移
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void ChangeButton(object sender, EventArgs e)
        {
            //データベースを代入
            using (SQLiteConnection connectionMemberDb = new SQLiteConnection("Data Source=member.db"))
            {
                //データベースを開く
                connectionMemberDb.Open();
                //代入したデータベースの処理
                using (SQLiteTransaction transactionMemberDb = connectionMemberDb.BeginTransaction())
                {
                    //SQLコマンドを宣言する
                    SQLiteCommand commandMemberDb = connectionMemberDb.CreateCommand();
                    //SQL文
                    commandMemberDb.CommandText = $" SELECT * FROM m_member WHERE before_Login = @_beforeBool";
                    //パラメータセット
                    commandMemberDb.Parameters.Add(memberEnums._beforeBool.ToString(), System.Data.DbType.Boolean);
                    //データ追加
                    commandMemberDb.Parameters[memberEnums._beforeBool.ToString()].Value = Boolean.Parse(true.ToString());
                    //データの読み込み
                    SQLiteDataReader reader = commandMemberDb.ExecuteReader();
                    //読み込み開始
                    reader.Read();
                    /**
                    *データを配列に保存
                    **/
                    while (_readCount <= READ_COUNT)
                    {
                        switch (_readCount)
                        {
                            case 0:
                                memberSaves[_readCount] = reader["name_text"].ToString();
                                _readCount++;
                                break;
                            case 1:
                                memberSaves[_readCount] = reader["address_text"].ToString();
                                _readCount++;
                                break;
                            case 2:
                                memberSaves[_readCount] = reader["email_text"].ToString();
                                _readCount++;
                                break;
                            case 3:
                                memberSaves[_readCount] = reader["phone_number"].ToString();
                                _readCount++;
                                break;
                            case 4:
                                memberSaves[_readCount] = reader["post_text"].ToString();
                                _readCount++;
                                break;
                            case 5:
                                memberSaves[_readCount] = reader["client_ID"].ToString();
                                _readCount++;
                                break;
                            case 6:
                                memberSaves[_readCount] = reader["before_Login"].ToString();
                                _readCount++;
                                break;
                        }
                    }
                    //カウントのリセット
                    _readCount = 0;
                    //読み込み終了
                    reader.Close();
                    //SQLの停止
                    commandMemberDb.ExecuteNonQuery();

                    //SQL文
                    commandMemberDb.CommandText = "UPDATE m_member set name_text = @_nameText, address_text = @_addressText," +
                        " email_text = @_emailText, phone_number = @_phoneNumber, post_text = @_postText, before_Login = @_beforeBool" +
                        " WHERE client_ID = @_clientId";
                    //パラメータセット
                    commandMemberDb.Parameters.Add(memberEnums._nameText.ToString(), System.Data.DbType.String);
                    commandMemberDb.Parameters.Add(memberEnums._addressText.ToString(), System.Data.DbType.String);
                    commandMemberDb.Parameters.Add(memberEnums._emailText.ToString(), System.Data.DbType.String);
                    commandMemberDb.Parameters.Add(memberEnums._phoneNumber.ToString(), System.Data.DbType.Int64);
                    commandMemberDb.Parameters.Add(memberEnums._postText.ToString(), System.Data.DbType.String);
                    commandMemberDb.Parameters.Add(memberEnums._clientId.ToString(), System.Data.DbType.Int64);
                    commandMemberDb.Parameters.Add(memberEnums._beforeBool.ToString(), System.Data.DbType.Boolean);

                    /**
                    *データ追加
                    **/
                    for (int i = 0; i < CHANGE_INPUT_COUNT; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                //変更内容が記入されていない場合、元々に入っていた値を代入
                                if (DataSaveClass.InputUpdateName.ToString() == "")
                                {
                                    commandMemberDb.Parameters[memberEnums._nameText.ToString()].Value = memberSaves[i];
                                }
                                else
                                {
                                    commandMemberDb.Parameters[memberEnums._nameText.ToString()].Value = DataSaveClass.InputUpdateName.ToString();
                                }
                                break;
                            case 1:
                                //変更内容が記入されていない場合、元々に入っていた値を代入
                                if (DataSaveClass.InputUpdateAddress.ToString() == "")
                                {
                                    commandMemberDb.Parameters[memberEnums._addressText.ToString()].Value = memberSaves[i];
                                }
                                else
                                {
                                    commandMemberDb.Parameters[memberEnums._addressText.ToString()].Value = DataSaveClass.InputUpdateAddress.ToString();
                                }
                                break;
                            case 2:
                                //変更内容が記入されていない場合、元々に入っていた値を代入
                                if (DataSaveClass.InputUpdateEmail.ToString() == "")
                                {
                                    commandMemberDb.Parameters[memberEnums._emailText.ToString()].Value = memberSaves[i];
                                }
                                else
                                {
                                    commandMemberDb.Parameters[memberEnums._emailText.ToString()].Value = DataSaveClass.InputUpdateEmail.ToString();
                                }
                                break;
                            case 3:
                                //変更内容が記入されていない場合、元々に入っていた値を代入
                                if (DataSaveClass.InputUpdatePhone.ToString() == "")
                                {
                                    commandMemberDb.Parameters[memberEnums._phoneNumber.ToString()].Value = memberSaves[i];
                                }
                                else
                                {
                                    commandMemberDb.Parameters[memberEnums._phoneNumber.ToString()].Value = DataSaveClass.InputUpdatePhone.ToString();
                                }
                                break;
                            case 4:
                                //変更内容が記入されていない場合、元々に入っていた値を代入
                                if (DataSaveClass.InputUpdatePost.ToString() == "")
                                {
                                    commandMemberDb.Parameters[memberEnums._postText.ToString()].Value = memberSaves[i];
                                }
                                else
                                {
                                    commandMemberDb.Parameters[memberEnums._postText.ToString()].Value = DataSaveClass.InputUpdatePost.ToString();
                                }
                                break;
                        }
                    }
                    //検索、編集中であるためtrueを代入
                    commandMemberDb.Parameters[memberEnums._beforeBool.ToString()].Value = Boolean.Parse(true.ToString());
                    //IDは変更しないため、元々入っていた値を代入
                    commandMemberDb.Parameters[memberEnums._clientId.ToString()].Value = int.Parse(memberSaves[5]);

                    //SQL文を停止
                    commandMemberDb.ExecuteNonQuery();
                    //コミット
                    transactionMemberDb.Commit();
                }
            }

            //会員検索結果画面のフォームを代入
            Form searchOutput = new SearchOutput();
            //指定したフォームを開く
            searchOutput.Show();
            //現在開いているフォームを閉じる
            this.Hide();
        }

        /// <summary>
        /// ReturnButton
        /// 会員変更入力画面のフォームに遷移
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void ReturnButton(object sender, EventArgs e)
        {
            //会員変更入力画面のフォームを代入
            Form changeInput = new ChangeInput();
            //指定したフォームを開く
            changeInput.Show();
            //現在開いているフォームを閉じる
            this.Hide();
        }

        /// <summary>
        /// ChangeCheckLoad
        /// フォームを読み込んだ際に、変更内容入力内容を取得し、表示する
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void ChangeCheckLoad(object sender, EventArgs e)
        {
            //データベースを代入
            using (SQLiteConnection connectionMember = new SQLiteConnection("Data Source=member.db"))
            {
                //データベースを開く
                connectionMember.Open();
                //代入したデータベースの処理
                using (SQLiteTransaction transactionMember = connectionMember.BeginTransaction())
                {
                    // SQLコマンドを宣言する
                    SQLiteCommand commandMember = connectionMember.CreateCommand();
                    //DataTableを生成します。
                    DataTable dataTableID = new DataTable();
                    //SQL文
                    commandMember.CommandText = $" SELECT * FROM m_member WHERE before_Login = @Before_Login";
                    //パラメータセット
                    commandMember.Parameters.Add("Before_Login", System.Data.DbType.Boolean);
                    //データ追加
                    commandMember.Parameters["Before_Login"].Value = Boolean.Parse(true.ToString());
                    //データの読み込み
                    SQLiteDataReader reader = commandMember.ExecuteReader();
                    //該当するデータを全て取得
                    while (reader.Read() == true)
                    {
                        //データベースから取り出したデータを配列に代入する
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

            for (int i = 0; i < CHANGE_INPUT_COUNT; i++)
            {
                switch (i)
                {
                    case 0:
                        //変更内容が記入されていない場合、元々に入っていた値を代入
                        if (DataSaveClass.InputUpdateName.ToString() == "")
                        {
                            input_name_label.Text = memberSaves[i];
                        }
                        else
                        {
                            input_name_label.Text = DataSaveClass.InputUpdateName.ToString();
                        }
                        break;
                    case 1:
                        //変更内容が記入されていない場合、元々に入っていた値を代入
                        if (DataSaveClass.InputUpdateAddress.ToString() == "")
                        {
                            input_address_label.Text = memberSaves[i].ToString();
                        }
                        else
                        {
                            input_address_label.Text = DataSaveClass.InputUpdateAddress.ToString();
                        }
                        break;
                    case 2:
                        //変更内容が記入されていない場合、元々に入っていた値を代入
                        if (DataSaveClass.InputUpdateEmail.ToString() == "")
                        {
                            input_email_label.Text = memberSaves[i].ToString();
                        }
                        else
                        {
                            input_email_label.Text = DataSaveClass.InputUpdateEmail.ToString();
                        }
                        break;
                    case 3:
                        //変更内容が記入されていない場合、元々に入っていた値を代入
                        if (DataSaveClass.InputUpdatePhone.ToString() == "")
                        {
                            input_phone_label.Text = memberSaves[i].ToString();
                        }
                        else
                        {
                            input_phone_label.Text = DataSaveClass.InputUpdatePhone.ToString();
                        }
                        break;
                    case 4:
                        //変更内容が記入されていない場合、元々に入っていた値を代入
                        if (DataSaveClass.InputUpdatePost.ToString() == "")
                        {
                            input_post_label.Text = memberSaves[i].ToString();
                        }
                        else
                        {
                            input_post_label.Text = DataSaveClass.InputUpdatePost.ToString();
                        }
                        break;
                }
            }
        }
    }
}
