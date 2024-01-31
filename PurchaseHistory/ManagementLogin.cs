// ----------------------------------------------------
//
// #ManagementLogin#.cs
//
// 作成日：12/11
// 作成者：吉田 隼人
//
// 内容：ログイン処理
// ----------------------------------------------------
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace PurchaseHistory
{
    public partial class ManagementLogin : Form
    {
        #region 変数

        //DBから読み込まれたIDの値の保存
        private string _saveId;
        //DBから読み込まれたパスワードの値の保存
        private string _savePassWord;

        private string _beforeLoginFlag = default;

        #endregion

        /// <summary>
        /// ManagementLogin
        /// ログイン画面のフォームを作成
        /// </summary>
        public ManagementLogin()
        {
            //フォームを作成
            InitializeComponent();
        }

        /// <summary>
        /// IdInputTextBox
        /// テキストボックスに文字が入力された時、ログイン時の比較に必要なデータを読み込む
        /// </summary>
        /// <param name="ad_ID">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void IdInputTextBox(object ad_ID, EventArgs e)
        {
            //DBの処理
            using (SQLiteConnection administratorConnection = new SQLiteConnection("Data Source=administrator.db"))
            {
                administratorConnection.Open();
                using (SQLiteTransaction administratorTransaction = administratorConnection.BeginTransaction())
                {
                    // SQLコマンドを宣言する
                    SQLiteCommand administratorCommand = administratorConnection.CreateCommand();
                    //SQL文
                    administratorCommand.CommandText = $" SELECT * FROM m_administrator WHERE a_managementID = @a_ManagementID";
                    //パラメータセット
                    administratorCommand.Parameters.Add("a_ManagementID", System.Data.DbType.String);
                    //データ追加
                    administratorCommand.Parameters["a_ManagementID"].Value = login_managementID.Text;
                    //データの読み込み
                    SQLiteDataReader reader = administratorCommand.ExecuteReader();
                    //該当するデータを全て読み込む
                    while (reader.Read() == true)
                    {
                        //データベースから取り出したデータを配列に代入する
                        _saveId = reader["a_ManagementID"].ToString();
                        _savePassWord = reader["a_passWord"].ToString();

                        //読み込んだ値をコンソールに表示
                        Console.WriteLine((String.Format($"ID:{_saveId} PassWard:{_savePassWord}")));
                    }
                    //データベースの読み込みを終了
                    reader.Close();
                }
            }
        }

        /// <summary>
        /// LoginButton
        /// ログインボタンが押された際に、IDとパスワードの比較処理
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void LoginButton(object sender, EventArgs e)
        {
            //入力されたIDとパスワードが、DBのIDとパスワードと一致した場合、管理画面を開く
            if (login_managementID.Text == _saveId && login_password.Text == _savePassWord)
            {
                //ログインしている管理者IDを保存
                DataSaveClass.AdministratorId = _saveId;
                //会員管理画面のフォームを代入
                Form managementFrom = new Management();
                //指定したフォームを開く
                managementFrom.Show();
                //現在開いているフォームを閉じる
                this.Hide();
            }
            else
            {
                // メッセージボックスを表示する
                MessageBox.Show("IDまたはパスワードが間違います。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ShutdownButton
        /// システムを終了する
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void ShutdownButton(object sender, EventArgs e)
        {
            //現在開いているフォームを閉じる
            this.Close();
        }

        /// <summary>
        /// ManagementLogin_Load
        /// 読み込んだ際、検索履歴のflagをリセットする
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void ManagementLogin_Load(object sender, EventArgs e)
        {
            //データベースの代入
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
                        _beforeLoginFlag = reader["before_Login"].ToString();
                    }
                    //データの読み込みを終了
                    reader.Close();
                    //SQLコマンドを終了
                    memberCommand.ExecuteNonQuery();

                    //過去に検索したデータがあったら処理する
                    if (_beforeLoginFlag != null)
                    {
                        //SQL文
                        memberCommand.CommandText = "UPDATE m_member set before_Login = @Before_Login WHERE before_Login = @Before_Login";
                        //パラメータセット
                        memberCommand.Parameters.Add("Before_Login", System.Data.DbType.Boolean);
                        //flagをfalseに戻す
                        memberCommand.Parameters["Before_Login"].Value = Boolean.Parse(false.ToString());
                        //SQLコマンドを終了
                        memberCommand.ExecuteNonQuery();
                    }

                    //コミット
                    memberTransaction.Commit();
                }
            }
        }
    }
}
