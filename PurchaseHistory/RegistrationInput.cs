// ----------------------------------------------------
//
// #RegistrationInput#.cs
//
// 作成日：12/13
// 作成者：吉田 隼人
//
// 内容：DBのデータ新規登録処理
// ----------------------------------------------------
using System;
using System.Windows.Forms;

namespace PurchaseHistory
{
    public partial class RegistrationInput : Form
    {
        #region 変数

        //空欄カウント
        private int _notText = 0;
        //TextBoxの入力数
        private const int TEXT_BOX_LENGTH = 10;

        #endregion

        /// <summary>
        /// RegistrationInput
        /// 会員登録入力画面のフォームを作成
        /// </summary>
        public RegistrationInput()
        {
            //フォームを作成
            InitializeComponent();
        }

        /// <summary>
        /// CheckButton
        /// データの登録処理
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void CheckButton(object sender, EventArgs e)
        {
            try
            {
                //カウントのリセット
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
                    return;
                }

                /**
                *int型のTextBoxにstring型が入っていないかを確認、メッセージを出して、処理を終了
                **/
                if (insertText_3.Text.ToString() != "")
                {
                    int inputCheack = insertText_3.Text.Length;

                    if (inputCheack < TEXT_BOX_LENGTH)
                    {
                        inputCheack = int.Parse(insertText_3.Text);
                    }
                }

                //入力されたデータの保存
                DataSaveClass.InputInsertName = insertText_0.Text;
                DataSaveClass.InputInsertAddress = insertText_1.Text;
                DataSaveClass.InputInsertEmail = insertText_2.Text;
                DataSaveClass.InputInsertPhone = insertText_3.Text;
                DataSaveClass.InputInsertPost = insertText_4.Text;


                //登録内容確認画面のフォームを代入
                Form registrationCheck = new RegistrationCheck();
                //指定したフォームを開く
                registrationCheck.Show();
                //現在開いているフォームを閉じる
                this.Hide();
            }
            catch
            {
                // メッセージボックスを表示する
                MessageBox.Show("記入方法が違います。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// ReturnButton
        /// 管理選択画面のフォームに遷移
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void ReturnButton(object sender, EventArgs e)
        {
            //管理選択画面のフォームを代入
            Form management = new Management();
            //指定したフォームを開く
            management.Show();
            //現在開いているフォームを閉じる
            this.Hide();
        }
    }
}
