// ----------------------------------------------------
//
// #PurchaseHistory#.cs
//
// 作成日：12/14
// 作成者：吉田 隼人
//
// 内容：会員の購入履歴
// ----------------------------------------------------
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace PurchaseHistory
{
    public partial class PurchaseHistory : Form
    {
        #region 変数

        //読み込んだ会員情報のデータを一時保存
        private string[] memberSaves = { "nameSave", "addressSave", "emailSave", "phoneSave", "postSave", "clientIdSave", "searchSave" };
        //読み込んだ本の名前のデータを一時保存
        private string[] bookNameSaves = { "", "", "", "", "", "", "", "", "", "", "" };
        //読み込んだ購入日時のデータを一時保存
        private string[] bookDateSaves = { "", "", "", "", "", "", "", "", "", "", "" };
        //テキストデザイン
        private string[] textDesigns = { "・", "／", "" };

        //購入履歴のソートに使用する
        private string _sortForDate = default;
        private string _sortLaterDate = default;
        private string _sortSaveDate = default;
        private string _sortSaveName = default;
        private string _sortYearDateFor = default;
        private string _sortYearDateLater = default;
        private string _sortMonthDateFor = default;
        private string _sortMonthDateLater = default;

        //読み込まれた購入履歴の列数
        private int _historyCount = 0;
        //記入するラベルを数える
        private int _labelTextCount = 0;

        //全てのラベルに記入
        private const int LABEL_ALL_TEXT = 5;
        //記入する個数がラベルを超える場合
        private const int LABEL_OVER_TEXT = 5;
        //カウントをリセットする
        private const int RESET_COUNT = 0;

        #endregion

        /// <summary>
        /// PurchaseHistory
        /// 会員購入履歴画面のフォームの作成
        /// </summary>
        public PurchaseHistory()
        {
            //フォームを作成
            InitializeComponent();
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
        /// PurchaseHistoryLoad
        /// フォームが読み込まれた際に、データベースからデータを取得し、会員の購入履歴を表示
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void PurchaseHistoryLoad(object sender, EventArgs e)
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
                        memberSaves[0] = reader["name_text"].ToString();
                        memberSaves[5] = reader["Client_ID"].ToString();
                    }
                    //ラベルに記入
                    display_name_label.Text = memberSaves[0];
                    //データの読み込みを終了
                    reader.Close();
                    //SQLコマンドを終了
                    memberCommand.ExecuteNonQuery();
                }
            }
            //データベースを代入
            using (SQLiteConnection connection_history = new SQLiteConnection("Data Source=history.db"))
            {
                //データベースを開く
                connection_history.Open();
                //代入したデータベースの処理
                using (SQLiteTransaction transaction_history = connection_history.BeginTransaction())
                {
                    // SQLコマンドを宣言する
                    SQLiteCommand command_history = connection_history.CreateCommand();
                    //DataTableを生成します。
                    DataTable dataTable_ID = new DataTable();
                    //SQL文
                    command_history.CommandText = $" SELECT * FROM m_history WHERE manegement_id = @Manegement_id";
                    //パラメータセット
                    command_history.Parameters.Add("Manegement_id", System.Data.DbType.Int64);
                    //データ追加
                    command_history.Parameters["Manegement_id"].Value = memberSaves[5];
                    //データの読み込み
                    SQLiteDataReader reader = command_history.ExecuteReader();
                    //該当するデータを全て読み込み
                    while (reader.Read() == true)
                    {
                        //データベースから取り出したデータを配列に代入
                        bookNameSaves[_historyCount] = reader["BuyBook_text"].ToString();
                        bookDateSaves[_historyCount] = reader["BuyDate_text"].ToString();

                        //データベースの列数をカウント
                        _historyCount++;
                    }
                    //データの読み込みを終了
                    reader.Close();
                }
            }

            //5項目以上なら5項目まで記入
            if (_historyCount >= LABEL_ALL_TEXT)
            {
                for (int i = 0; i < LABEL_ALL_TEXT; i++)
                {
                    //ラベル記入
                    this.Controls["BookName_label_" + i].Text = bookNameSaves[i].ToString();
                    this.Controls["BookDate_label_" + i].Text = bookDateSaves[i].ToString();
                    this.Controls["Design_label_" + i].Text = textDesigns[0].ToString();
                    this.Controls["Design_slash_label_" + i].Text = textDesigns[1].ToString();
                }

                //次のページを表示するボタンを表示
                NextPageButton.Visible = true;
                //前のページを表示するボタンを非表示
                BackPageButton.Visible = false;
            }
            //5項目以内なら全て記入
            else
            {
                for (int i = 0; i < _historyCount; i++)
                {
                    //ラベル記入
                    this.Controls["BookName_label_" + i].Text = bookNameSaves[i].ToString();
                    this.Controls["BookDate_label_" + i].Text = bookDateSaves[i].ToString();
                    this.Controls["Design_label_" + i].Text = textDesigns[0].ToString();
                    this.Controls["Design_slash_label_" + i].Text = textDesigns[1].ToString();
                }

                //次のページを表示するボタンを非表示
                NextPageButton.Visible = false;
                //前のページを表示するボタンを非表示
                BackPageButton.Visible = false;
            }

            //ComboBoxのリスト
            historyComboBox.Items.Add("昇順");
            historyComboBox.Items.Add("降順");
        }

        /// <summary>
        /// NextButton
        /// 取得した列データが記入するラベルの個数を超えた場合、
        /// 最初のラベルの個数分を表示したデータを非表示にし、残りのデータを表示する
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void NextButton(object sender, EventArgs e)
        {
            //ページのテキストリセット
            for (int i = 0; i < LABEL_ALL_TEXT; i++)
            {
                //ラベル記入
                this.Controls["BookName_label_" + i].Text = textDesigns[2].ToString();
                this.Controls["BookDate_label_" + i].Text = textDesigns[2].ToString();
                this.Controls["Design_label_" + i].Text = textDesigns[2].ToString();
                this.Controls["Design_slash_label_" + i].Text = textDesigns[2].ToString();
            }

            //次のページを表示するボタンを非表示
            NextPageButton.Visible = false;

            for (int i = LABEL_OVER_TEXT; i < _historyCount; i++)
            {
                //ラベル記入
                this.Controls["BookName_label_" + _labelTextCount].Text = bookNameSaves[i].ToString();
                this.Controls["BookDate_label_" + _labelTextCount].Text = bookDateSaves[i].ToString();
                this.Controls["Design_label_" + _labelTextCount].Text = textDesigns[0].ToString();
                this.Controls["Design_slash_label_" + _labelTextCount].Text = textDesigns[1].ToString();
                //記入するラベルのカウント
                _labelTextCount++;
            }

            //前のページを表示するボタンを表示
            BackPageButton.Visible = true;
            //カウントのリセット
            _labelTextCount = RESET_COUNT;
        }

        /// <summary>
        /// BackButton
        /// NextButtonが押された場合、表示されているデータを非表示にし、非表示だったデータを表示する
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void BackButton(object sender, EventArgs e)
        {
            //ページのテキストリセット
            for (int i = 0; i < LABEL_ALL_TEXT; i++)
            {
                //ラベル記入
                this.Controls["BookName_label_" + i].Text = textDesigns[2].ToString();
                this.Controls["BookDate_label_" + i].Text = textDesigns[2].ToString();
                this.Controls["Design_label_" + i].Text = textDesigns[2].ToString();
                this.Controls["Design_slash_label_" + i].Text = textDesigns[2].ToString();
            }

            if (_historyCount >= LABEL_OVER_TEXT)
            {
                for (int i = 0; i < LABEL_ALL_TEXT; i++)
                {
                    //ラベル記入
                    this.Controls["BookName_label_" + i].Text = bookNameSaves[i].ToString();
                    this.Controls["BookDate_label_" + i].Text = bookDateSaves[i].ToString();
                    this.Controls["Design_label_" + i].Text = textDesigns[0].ToString();
                    this.Controls["Design_slash_label_" + i].Text = textDesigns[1].ToString();
                }

                //次のページを表示するボタンを表示
                NextPageButton.Visible = true;
                //前のページを表示するボタンを非表示
                BackPageButton.Visible = false;
            }
            else
            {
                for (int i = 0; i < _historyCount; i++)
                {
                    //ラベル記入
                    this.Controls["BookName_label_" + i].Text = bookNameSaves[i].ToString();
                    this.Controls["BookDate_label_" + i].Text = bookDateSaves[i].ToString();
                    this.Controls["Design_label_" + i].Text = textDesigns[0].ToString();
                    this.Controls["Design_slash_label_" + i].Text = textDesigns[1].ToString();
                }

                //次のページを表示するボタンを非表示
                NextPageButton.Visible = false;
                //前のページを表示するボタンを非表示
                BackPageButton.Visible = false;
            }
        }

        /// <summary>
        /// ComboBoxSelectedIndexChanged
        /// 昇順降順処理
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void ComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            //昇順にソートする
            if (historyComboBox.Text.ToString() == "昇順")
            {
                //年でソート
                for (int yearFor = 0; yearFor < _historyCount; yearFor++)
                {
                    //年だけを取得
                    _sortForDate = DateTime.Parse(bookDateSaves[yearFor].ToString()).ToString("yyyy");

                    for (int yearLater = yearFor + 1; yearLater < _historyCount; yearLater++)
                    {
                        //年だけを取得
                        _sortLaterDate = DateTime.Parse(bookDateSaves[yearLater].ToString()).ToString("yyyy");

                        if (int.Parse(_sortForDate) > int.Parse(_sortLaterDate))
                        {
                            //現在の配列に入っている値を入れる
                            _sortSaveName = bookNameSaves[yearFor].ToString();
                            _sortSaveDate = bookDateSaves[yearFor].ToString();

                            //現在の配列に、次の配列にある本の名前と年月日を代入
                            bookNameSaves[yearFor] = bookNameSaves[yearLater].ToString();
                            bookDateSaves[yearFor] = bookDateSaves[yearLater].ToString();

                            //現在の配列に入っている本の名前と年月日を、次の配列に代入
                            bookNameSaves[yearLater] = _sortSaveName;
                            bookDateSaves[yearLater] = _sortSaveDate;

                            //年だけを取得
                            _sortForDate = DateTime.Parse(bookDateSaves[yearFor].ToString()).ToString("yyyy");
                        }
                    }
                }

                //月でソート
                for (int monthFor = 0; monthFor < _historyCount; monthFor++)
                {
                    //月だけを取得
                    _sortForDate = DateTime.Parse(bookDateSaves[monthFor].ToString()).ToString("MM");
                    //年を取得
                    _sortYearDateFor = DateTime.Parse(bookDateSaves[monthFor].ToString()).ToString("yyyy");

                    for (int monthLater = monthFor + 1; monthLater < _historyCount; monthLater++)
                    {
                        //月だけを取得
                        _sortLaterDate = DateTime.Parse(bookDateSaves[monthLater].ToString()).ToString("MM");
                        //年を取得
                        _sortYearDateLater = DateTime.Parse(bookDateSaves[monthLater].ToString()).ToString("yyyy");

                        //年が同じ場合、月のソートをする
                        if (_sortYearDateFor == _sortYearDateLater)
                        {
                            if (int.Parse(_sortForDate) > int.Parse(_sortLaterDate))
                            {
                                //現在の配列に入っている値を入れる
                                _sortSaveName = bookNameSaves[monthFor].ToString();
                                _sortSaveDate = bookDateSaves[monthFor].ToString();

                                //現在の配列に、次の配列にある本の名前と年月日を代入
                                bookNameSaves[monthFor] = bookNameSaves[monthLater].ToString();
                                bookDateSaves[monthFor] = bookDateSaves[monthLater].ToString();

                                //現在の配列に入っている本の名前と年月日を、次の配列に代入
                                bookNameSaves[monthLater] = _sortSaveName;
                                bookDateSaves[monthLater] = _sortSaveDate;

                                //月だけを取得
                                _sortForDate = DateTime.Parse(bookDateSaves[monthFor].ToString()).ToString("MM");
                            }
                        }
                    }
                }

                //日でソート
                for (int dayFor = 0; dayFor < _historyCount; dayFor++)
                {
                    //日だけを取得
                    _sortForDate = DateTime.Parse(bookDateSaves[dayFor].ToString()).ToString("dd");
                    //年と月を取得
                    _sortYearDateFor = DateTime.Parse(bookDateSaves[dayFor].ToString()).ToString("yyyy");
                    _sortMonthDateFor = DateTime.Parse(bookDateSaves[dayFor].ToString()).ToString("MM");

                    for (int dayLater = dayFor + 1; dayLater < _historyCount; dayLater++)
                    {
                        //日だけを取得
                        _sortLaterDate = DateTime.Parse(bookDateSaves[dayLater].ToString()).ToString("dd");
                        //年と月を取得
                        _sortYearDateLater = DateTime.Parse(bookDateSaves[dayLater].ToString()).ToString("yyyy");
                        _sortMonthDateLater = DateTime.Parse(bookDateSaves[dayLater].ToString()).ToString("MM");

                        //年と月が同じ場合、日のソートをする
                        if (_sortYearDateFor == _sortYearDateLater && _sortMonthDateFor == _sortMonthDateLater)
                        {
                            if (int.Parse(_sortForDate) > int.Parse(_sortLaterDate))
                            {
                                //現在の配列に入っている値を入れる
                                _sortSaveName = bookNameSaves[dayFor].ToString();
                                _sortSaveDate = bookDateSaves[dayFor].ToString();

                                //現在の配列に、次の配列にある本の名前と年月日を代入
                                bookNameSaves[dayFor] = bookNameSaves[dayLater].ToString();
                                bookDateSaves[dayFor] = bookDateSaves[dayLater].ToString();

                                //現在の配列に入っている本の名前と年月日を、次の配列に代入
                                bookNameSaves[dayLater] = _sortSaveName;
                                bookDateSaves[dayLater] = _sortSaveDate;

                                //日だけを取得
                                _sortForDate = DateTime.Parse(bookDateSaves[dayFor].ToString()).ToString("dd");
                            }
                        }
                    }
                }
            }
            else if (historyComboBox.Text.ToString() == "降順")
            {
                //年でソート
                for (int yearFor = 0; yearFor < _historyCount; yearFor++)
                {
                    //年だけを取得
                    _sortForDate = DateTime.Parse(bookDateSaves[yearFor].ToString()).ToString("yyyy");

                    for (int yearLater = yearFor + 1; yearLater < _historyCount; yearLater++)
                    {
                        //年だけを取得
                        _sortLaterDate = DateTime.Parse(bookDateSaves[yearLater].ToString()).ToString("yyyy");

                        if (int.Parse(_sortForDate) < int.Parse(_sortLaterDate))
                        {
                            //現在の配列に入っている値を入れる
                            _sortSaveName = bookNameSaves[yearFor].ToString();
                            _sortSaveDate = bookDateSaves[yearFor].ToString();

                            //現在の配列に、次の配列にある本の名前と年月日を代入
                            bookNameSaves[yearFor] = bookNameSaves[yearLater].ToString();
                            bookDateSaves[yearFor] = bookDateSaves[yearLater].ToString();

                            //現在の配列に入っている本の名前と年月日を、次の配列に代入
                            bookNameSaves[yearLater] = _sortSaveName;
                            bookDateSaves[yearLater] = _sortSaveDate;

                            //年だけを取得
                            _sortForDate = DateTime.Parse(bookDateSaves[yearFor].ToString()).ToString("yyyy");
                        }
                    }
                }

                //月でソート
                for (int monthFor = 0; monthFor < _historyCount; monthFor++)
                {
                    //月だけを取得
                    _sortForDate = DateTime.Parse(bookDateSaves[monthFor].ToString()).ToString("MM");
                    //年を取得
                    _sortYearDateFor = DateTime.Parse(bookDateSaves[monthFor].ToString()).ToString("yyyy");

                    for (int monthLater = monthFor + 1; monthLater < _historyCount; monthLater++)
                    {
                        //月だけを取得
                        _sortLaterDate = DateTime.Parse(bookDateSaves[monthLater].ToString()).ToString("MM");
                        //年を取得
                        _sortYearDateLater = DateTime.Parse(bookDateSaves[monthLater].ToString()).ToString("yyyy");

                        //年が同じ場合、月のソートをする
                        if (_sortYearDateFor == _sortYearDateLater)
                        {
                            if (int.Parse(_sortForDate) < int.Parse(_sortLaterDate))
                            {
                                //現在の配列に入っている値を入れる
                                _sortSaveName = bookNameSaves[monthFor].ToString();
                                _sortSaveDate = bookDateSaves[monthFor].ToString();

                                //現在の配列に、次の配列にある本の名前と年月日を代入
                                bookNameSaves[monthFor] = bookNameSaves[monthLater].ToString();
                                bookDateSaves[monthFor] = bookDateSaves[monthLater].ToString();

                                //現在の配列に入っている本の名前と年月日を、次の配列に代入
                                bookNameSaves[monthLater] = _sortSaveName;
                                bookDateSaves[monthLater] = _sortSaveDate;

                                //月だけを取得
                                _sortForDate = DateTime.Parse(bookDateSaves[monthFor].ToString()).ToString("MM");
                            }
                        }
                    }
                }

                //日でソート
                for (int dayFor = 0; dayFor < _historyCount; dayFor++)
                {
                    //日だけを取得
                    _sortForDate = DateTime.Parse(bookDateSaves[dayFor].ToString()).ToString("dd");
                    //年と月を取得
                    _sortYearDateFor = DateTime.Parse(bookDateSaves[dayFor].ToString()).ToString("yyyy");
                    _sortMonthDateFor = DateTime.Parse(bookDateSaves[dayFor].ToString()).ToString("MM");

                    for (int dayLater = dayFor + 1; dayLater < _historyCount; dayLater++)
                    {
                        //日だけを取得
                        _sortLaterDate = DateTime.Parse(bookDateSaves[dayLater].ToString()).ToString("dd");
                        //年と月を取得
                        _sortYearDateLater = DateTime.Parse(bookDateSaves[dayLater].ToString()).ToString("yyyy");
                        _sortMonthDateLater = DateTime.Parse(bookDateSaves[dayLater].ToString()).ToString("MM");

                        //年と月が同じ場合、日のソートをする
                        if (_sortYearDateFor == _sortYearDateLater && _sortMonthDateFor == _sortMonthDateLater)
                        {
                            if (int.Parse(_sortForDate) < int.Parse(_sortLaterDate))
                            {
                                //現在の配列に入っている値を入れる
                                _sortSaveName = bookNameSaves[dayFor].ToString();
                                _sortSaveDate = bookDateSaves[dayFor].ToString();

                                //現在の配列に、次の配列にある本の名前と年月日を代入
                                bookNameSaves[dayFor] = bookNameSaves[dayLater].ToString();
                                bookDateSaves[dayFor] = bookDateSaves[dayLater].ToString();

                                //現在の配列に入っている本の名前と年月日を、次の配列に代入
                                bookNameSaves[dayLater] = _sortSaveName;
                                bookDateSaves[dayLater] = _sortSaveDate;

                                //日だけを取得
                                _sortForDate = DateTime.Parse(bookDateSaves[dayFor].ToString()).ToString("dd");
                            }
                        }
                    }
                }
            }

            //5項目以上なら5項目まで記入
            if (_historyCount > LABEL_ALL_TEXT)
            {
                for (int label = 0; label < LABEL_ALL_TEXT; label++)
                {
                    //ラベル記入
                    this.Controls["BookName_label_" + label].Text = bookNameSaves[label].ToString();
                    this.Controls["BookDate_label_" + label].Text = bookDateSaves[label].ToString();
                    this.Controls["Design_label_" + label].Text = textDesigns[0].ToString();
                    this.Controls["Design_slash_label_" + label].Text = textDesigns[1].ToString();
                }

                //次のページを表示するボタンを表示
                NextPageButton.Visible = true;
                //前のページを表示するボタンを非表示
                BackPageButton.Visible = false;
            }
            //5項目以内なら全て記入
            else
            {
                for (int label = 0; label < _historyCount; label++)
                {
                    //ラベル記入
                    this.Controls["BookName_label_" + label].Text = bookNameSaves[label].ToString();
                    this.Controls["BookDate_label_" + label].Text = bookDateSaves[label].ToString();
                    this.Controls["Design_label_" + label].Text = textDesigns[0].ToString();
                    this.Controls["Design_slash_label_" + label].Text = textDesigns[1].ToString();
                }

                //次のページを表示するボタンを非表示
                NextPageButton.Visible = false;
                //前のページを表示するボタンを非表示
                BackPageButton.Visible = false;
            }
        }
    }
}
