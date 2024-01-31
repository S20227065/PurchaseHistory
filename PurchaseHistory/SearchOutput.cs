// ----------------------------------------------------
//
// #SearchOutput#.cs
//
// 作成日：12/14
// 作成者：吉田 隼人
//
// 内容：処理選択画面
// ----------------------------------------------------
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace PurchaseHistory
{
    public partial class SearchOutput : Form
    {
        #region 変数

        //読み込んだデータを一時保存
        private string[] memberSaves = { "_nameSave", "_addressSave", "_emailSave", "_phoneSave", "_postSave", "_clientIdSave", "_searchSave" };

        #endregion

        /// <summary>
        /// SearchOutput
        /// 会員検索結果画面のフォームの作成
        /// </summary>
        public SearchOutput()
        {
            //フォームの作成
            InitializeComponent();
        }

        /// <summary>
        /// SearchOutputLoad
        /// フォームが読み込まれた際に、会員のデータを表示
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void SearchOutputLoad(object sender, EventArgs e)
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
                    //DataTableを生成します。
                    DataTable dataTable_ID = new DataTable();
                    //SQL文
                    memberCommand.CommandText = $" SELECT * FROM m_member WHERE before_Login = @Before_Login";
                    //パラメータセット
                    memberCommand.Parameters.Add("Before_Login", System.Data.DbType.Boolean);
                    //データ追加
                    memberCommand.Parameters["Before_Login"].Value = Boolean.Parse(true.ToString());
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
            output_ID_label.Text = memberSaves[5].ToString();
            output_name_label.Text = memberSaves[0].ToString();
            output_address_label.Text = memberSaves[1].ToString();
            output_email_label.Text = memberSaves[2].ToString();
            output_phone_label.Text = memberSaves[3].ToString();
            output_post_label.Text = memberSaves[4].ToString();
        }

        /// <summary>
        /// HistoryButton
        /// 会員購入履歴画面のフォームに遷移
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void HistoryButton(object sender, EventArgs e)
        {
            //会員購入履歴画面のフォームを代入
            Form purchaseHistory = new PurchaseHistory();
            //指定したフォームを開く
            purchaseHistory.Show();
            //現在開いているフォームを閉じる
            this.Hide();
        }

        /// <summary>
        /// ChangeButton
        /// 会員変更入力画面のフォームに遷移
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void ChangeButton(object sender, EventArgs e)
        {
            //会員変更入力画面のフォームを代入
            Form changeInput = new ChangeInput();
            //指定したフォームを開く
            changeInput.Show();
            //現在開いているフォームを閉じる
            this.Hide();
        }

        /// <summary>
        /// DeleteButtton
        /// 会員削除画面のフォームに遷移
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void DeleteButtton(object sender, EventArgs e)
        {
            //会員削除画面のフォームを代入
            Form deleteCheck = new DeleteCheck();
            //指定したフォームを開く
            deleteCheck.Show();
            //現在開いているフォームを閉じる
            this.Hide();
        }

        /// <summary>
        /// ReturnButton
        /// 会員検索入力画面のフォームに遷移
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void ReturnButton(object sender, EventArgs e)
        {
            //会員検索入力画面のフォームを代入
            Form searchInput = new SearchInput();
            //指定したフォームを開く
            searchInput.Show();
            //現在開いているフォームを閉じる
            this.Hide();
        }
    }
}
