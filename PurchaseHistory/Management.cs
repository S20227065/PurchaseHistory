// ----------------------------------------------------
//
// #Management#.cs
//
// 作成日：12/14
// 作成者：吉田 隼人
//
// 内容：管理画面の遷移選択
// ----------------------------------------------------
using System;
using System.Windows.Forms;

namespace PurchaseHistory
{
    public partial class Management : Form
    {
        /// <summary>
        /// Management
        /// 会員管理画面のフォームを作成
        /// </summary>
        public Management()
        {
            //フォームを作成
            InitializeComponent();
        }

        /// <summary>
        /// RegistrationButton
        /// 会員登録フォームに遷移
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void RegistrationButton(object sender, EventArgs e)
        {
            //会員登録入力画面のフォームを代入
            Form registrationInput = new RegistrationInput();
            //指定したフォームを開く
            registrationInput.Show();
            //現在開いているフォームを閉じる
            this.Hide();
        }

        /// <summary>
        /// SearchButton
        /// 会員検索画面のフォームに遷移
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void SearchButton(object sender, EventArgs e)
        {
            //検索入力画面のフォームを代入
            Form searchInput = new SearchInput();
            //指定したフォームを開く
            searchInput.Show();
            //現在開いているフォームを閉じる
            this.Hide();
        }

        /// <summary>
        /// ReturnButton
        /// ログイン画面のフォームに遷移
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void ReturnButton(object sender, EventArgs e)
        {
            //ログイン画面のフォームを代入
            Form managementLogin = new ManagementLogin();
            //指定したフォームを開く
            managementLogin.Show();
            //現在開いているフォームを閉じる
            this.Hide();
        }

        /// <summary>
        /// ManagementLoad
        /// 読み込んだ際、管理者IDを表示する処理
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void ManagementLoad(object sender, EventArgs e)
        {
            //管理者IDを表示
            administrator_Name_label.Text = DataSaveClass.AdministratorId.ToString();
        }
    }
}
