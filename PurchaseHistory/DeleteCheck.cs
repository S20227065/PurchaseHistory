// ----------------------------------------------------
//
// #DeleteCheck#.cs
//
// 作成日：12/14
// 作成者：吉田 隼人
//
// 内容：会員情報削除確認画面
// ----------------------------------------------------
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace PurchaseHistory
{
    public partial class DeleteCheck : Form
    {
        #region 変数

        //読み込んだデータを一時保存
        private string[] memberSaves = { "name", "address", "email", "phone", "post", "clientID", "login" };
        //削除した回数をカウント
        private int _countDelete = 0;

        #endregion

        /// <summary>
        /// DeleteCheck
        /// 会員削除確認画面のフォームを作成
        /// </summary>
        public DeleteCheck()
        {
            //フォームを作成
            InitializeComponent();
        }

        /// <summary>
        /// DeleteButton
        /// 現在開いている会員のデータを削除する
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void DeleteButton(object sender, EventArgs e)
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
                    memberCommand.CommandText = "DELETE FROM m_member WHERE client_ID = @Client_ID;";
                    //パラメータセット
                    memberCommand.Parameters.Add("Client_ID", System.Data.DbType.Int64);
                    //データ追加
                    memberCommand.Parameters["Client_ID"].Value = int.Parse(memberSaves[5]);
                    //SQLコマンドを終了する
                    memberCommand.ExecuteNonQuery();
                    //コミット
                    memberTransaction.Commit();
                }
            }

            //削除したIDを保存
            for (int i = _countDelete; i < _countDelete + 1; i++)
            {
                DataSaveClass.DeleteId[i] = memberSaves[5];
            }

            //会員管理画面のフォームを代入
            Form management = new Management();
            //指定したフォームを開く
            management.Show();
            //現在開いているフォームを閉じる
            this.Hide();
        }

        /// <summary>
        /// ReturnButton
        /// 検索結果画面のフォームに遷移
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void ReturnButton(object sender, EventArgs e)
        {
            //検索結果画面のフォームを代入
            Form searchOutput = new SearchOutput();
            //指定したフォームを開く
            searchOutput.Show();
            //現在開いているフォームを閉じる
            this.Hide();
        }

        /// <summary>
        /// DeleteCheckLoad
        /// フォームを読み込んだ際に、現在開いている会員の名前を表示
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void DeleteCheckLoad(object sender, EventArgs e)
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
                    DataTable dataTableId = new DataTable();
                    //インサート
                    memberCommand.CommandText = $" SELECT * FROM m_member WHERE before_Login = @Before_Login";
                    //パラメータセット
                    memberCommand.Parameters.Add("Before_Login", System.Data.DbType.Boolean);
                    //データ追加
                    memberCommand.Parameters["Before_Login"].Value = Boolean.Parse(true.ToString()); ;
                    //データの読み込み
                    SQLiteDataReader reader = memberCommand.ExecuteReader();
                    //該当するデータを全て取得
                    while (reader.Read() == true)
                    {
                        //データベースから取り出したデータを配列に代入する
                        memberSaves[5] = reader["Client_ID"].ToString();
                    }
                    //データベースの読み込みを終了
                    reader.Close();
                }
            }

            //ラベルに記入
            Delete_check_ID.Text = "ID：" + memberSaves[5].ToString();
        }
    }
}
