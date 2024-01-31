// ----------------------------------------------------
//
// #RegistrationCheck#.cs
//
// 作成日：12/14
// 作成者：吉田 隼人
//
// 内容：会員登録内容確認画面
// ----------------------------------------------------
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace PurchaseHistory
{
    public partial class RegistrationCheck : Form
    {
        #region 変数

        //DBに使うテキスト
        private readonly string[] memberReads = { "Name_text", "Address_text", "Email_text", "Phone_number", "Post_text", "Client_ID", "Before_Login" };


        #endregion

        /// <summary>
        /// RegistrationCheck
        /// 会員登録確認画面のフォームの作成
        /// </summary>
        public RegistrationCheck()
        {
            //フォームの作成
            InitializeComponent();
        }

        /// <summary>
        /// RegistrationButton
        /// 会員管理画面のフォームに遷移
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void RegistrationButton(object sender, EventArgs e)
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
                    //SQL文
                    memberCommand.CommandText = "INSERT INTO m_member (name_text, address_text, email_text, phone_number, post_text,  before_Login) " +
                        "VALUES (@Name_text, @Address_text, @Email_text, @Phone_number, @Post_text, @Before_Login)";

                    //パラメータセット
                    memberCommand.Parameters.Add(memberReads[0], System.Data.DbType.String);
                    memberCommand.Parameters.Add(memberReads[1], System.Data.DbType.String);
                    memberCommand.Parameters.Add(memberReads[2], System.Data.DbType.String);
                    memberCommand.Parameters.Add(memberReads[3], System.Data.DbType.Int64);
                    memberCommand.Parameters.Add(memberReads[4], System.Data.DbType.String);
                    memberCommand.Parameters.Add(memberReads[6], System.Data.DbType.Boolean);

                    //データ追加
                    memberCommand.Parameters[memberReads[0]].Value = DataSaveClass.InputInsertName.ToString();
                    memberCommand.Parameters[memberReads[1]].Value = DataSaveClass.InputInsertAddress.ToString();
                    memberCommand.Parameters[memberReads[2]].Value = DataSaveClass.InputInsertEmail.ToString();
                    memberCommand.Parameters[memberReads[3]].Value = int.Parse(DataSaveClass.InputInsertPhone.ToString());
                    memberCommand.Parameters[memberReads[4]].Value = DataSaveClass.InputInsertPost.ToString();
                    memberCommand.Parameters[memberReads[6]].Value = Boolean.Parse(false.ToString());

                    //SQLコマンドを終了
                    memberCommand.ExecuteNonQuery();
                    //コミット
                    memberTransaction.Commit();
                }
            }

            //会員データのカウント
            DataSaveClass.MemberCount += 1;

            //会員管理画面のフォームを代入
            Form management = new Management();
            //指定したフォームを開く
            management.Show();
            //現在開いているフォームを閉じる
            this.Hide();
        }

        /// <summary>
        /// ReturnButton
        /// 会員登録入力画面のフォームに遷移
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void ReturnButton(object sender, EventArgs e)
        {
            //会員登録入力画面のフォームを代入
            Form registrationInput = new RegistrationInput();
            //指定したフォームを開く
            registrationInput.Show();
            //現在開いているフォームを閉じる
            this.Hide();
        }

        /// <summary>
        /// RegistrationCheckLoad
        /// フォームが読み込まれた際に、会員のデータを表示
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void RegistrationCheckLoad(object sender, EventArgs e)
        {
            //ラベルに記入
            input_name_label.Text = DataSaveClass.InputInsertName.ToString();
            input_address_label.Text = DataSaveClass.InputInsertAddress.ToString();
            input_email_label.Text = DataSaveClass.InputInsertEmail.ToString();
            input_phone_label.Text = DataSaveClass.InputInsertPhone.ToString();
            input_post_label.Text = DataSaveClass.InputInsertPost.ToString();
        }
    }
}
