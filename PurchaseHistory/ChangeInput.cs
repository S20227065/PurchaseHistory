// ----------------------------------------------------
//
// #ChangeInput#.cs
//
// 作成日：12/14
// 作成者：吉田 隼人
//
// 内容：DBのデータ変更処理
// ----------------------------------------------------
using System;
using System.Windows.Forms;

namespace PurchaseHistory
{
    public partial class ChangeInput : Form
    {
        #region 変数

        //TextBoxの入力数
        private const int TEXT_BOX_LENGTH = 10;

        #endregion

        /// <summary>
        /// ChangeInput
        /// 会員変更入力画面のフォームを作成
        /// </summary>
        public ChangeInput()
        {
            //フォームの作成
            InitializeComponent();
        }

        /// <summary>
        /// CheckButton
        /// DBを一度読み込み変更前の値を保存し、変更しなかった値には変更前の値を入れる
        /// </summary>
        /// <param name="sender">フォームの作成に必要</param>
        /// <param name="e">フォームの作成に必要</param>
        private void CheckButton(object sender, EventArgs e)
        {
            try
            {
                /**
                *int型のTextBoxにstring型が入っていないかを確認、メッセージを出して、処理を終了
                **/
                if (upDateText_3.Text.ToString() != "")
                {
                    int inputCheack = upDateText_3.Text.Length;

                    if (inputCheack < TEXT_BOX_LENGTH)
                    {
                        inputCheack = int.Parse(upDateText_3.Text);
                    }
                }
                
                //入力データを保存
                DataSaveClass.InputUpdateName = upDateText_0.Text.ToString();
                DataSaveClass.InputUpdateAddress = upDateText_1.Text.ToString();
                DataSaveClass.InputUpdateEmail = upDateText_2.Text.ToString();
                DataSaveClass.InputUpdatePhone = upDateText_3.Text.ToString();
                DataSaveClass.InputUpdatePost = upDateText_4.Text.ToString();

                //変更内容確認画面のフォームを代入
                Form _changeCheck = new ChangeCheck();
                //指定したフォームを開く
                _changeCheck.Show();
                //現在開いているフォームを閉じる
                this.Hide();
            }
            catch
            {
                //メッセージボックスを表示する
                MessageBox.Show("記入内容に間違いがあります。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //処理を終了する
                return;
            }
        }

        /// <summary>
        /// ReturnButton
        /// 検索結果画面のフォームに移動する
        /// </summary>
        /// <param name="sender">フォームの作成に必要</param>
        /// <param name="e">フォームの作成に必要</param>
        private void ReturnButton(object sender, EventArgs e)
        {
            //検索結果画面のフォームを代入
            Form _searchOutput = new SearchOutput();
            //指定したフォームを開く
            _searchOutput.Show();
            //現在開いているフォームを閉じる
            this.Hide();
        }
    }
}
