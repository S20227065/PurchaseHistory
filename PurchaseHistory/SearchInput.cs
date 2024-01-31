// ----------------------------------------------------
//
// #SearchInput#.cs
//
// 作成日：1/25
// 作成者：吉田 隼人
//
// 内容：会員データの検索処理
// ----------------------------------------------------
using System;
using System.Windows.Forms;
using System.Data.SQLite;

namespace PurchaseHistory
{
    public partial class SearchInput : Form
    {
        #region 変数

        //読み込んだデータを一時保存
        private string[] memberSaves = { "_nameSave", "_addressSave", "_emailSave", "_phoneSave", "_postSave", "_clientIdSave", "_searchSave" };
        //読み込んだIDの名前のデータを一時保存
        private string[] clientIdSaves = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        //読み込んだ会員名のデータを一時保存
        private string[] clientNameSaves = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        //読み込んだbookのデータを一時保存
        private string[] bookSearchSaves = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        //テキストデザイン
        private string[] textDesigns = { "・", "／", "","ー" };

        //読み込まれた購入履歴の列数
        private int _historyCount = 0;
        //記入するラベルを数える
        private int _labelTextCount = 0;
        //ページ数をカウントする
        private int _pageCount = 1;
        //最後のページを保存する
        private int _lastPage = default;
        //ページごとに会員名、IDを表示の始点
        private int _saveDataReadFast = default;
        //ページごとに会員名、IDを表示の終点
        private int _saveDataReadLast = default;
        //保存するデータのカウント
        private int _saveCount = 0;

        //配列に同じものがあるかを比較するための一時保存に使用
        private string _saveId = default;
        //前回調べた会員のラベル
        private string _beforeLabel = "前回検索した会員：";
        //前回調べた会員IDのラベル
        private string _beforeIdLabel = "ID-";

        //昇順のソート
        private int _sortFor = default;
        private int _sortLater = default;
        private int _sortSave = default;
        private string _sortSaveName = default;

        //全てのラベルに記入
        private const int LABEL_ALL_TEXT = 5;
        //カウントをリセットする
        private const int RESET_COUNT = 0;
        //最初のページを保存する
        private const int FAST_PAGE = 1;

        //配列に同じものがあった場合true
        private bool IsSaveId = false;


        #endregion

        /// <summary>
        /// SearchInput
        /// 会員検索入力画面のフォームを作成
        /// </summary>
        public SearchInput()
        {
            //フォームを作成
            InitializeComponent();
        }

        /// <summary>
        /// SearchButton
        /// 会員の検索処理
        /// 検索対象のflagをtrueにする
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void SearchButton(object sender, EventArgs e)
        {
            //空欄あればメッセージを出して、処理を終了
            if (String.IsNullOrEmpty(searchText_id.Text) == true)
            {
                // メッセージボックスを表示する
                MessageBox.Show("未記入があります。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //会員データを超える数で検索するとメッセージを出して、処理を終了
            if (int.Parse(searchText_id.Text) < 0 || int.Parse(searchText_id.Text) > DataSaveClass.MemberCount)
            {
                // メッセージボックスを表示する
                MessageBox.Show("該当するデータがありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //削除されたデータを検索した場合、検索できなくする
            for (int i = 0; i < DataSaveClass.MemberCount; i++)
            {
                if (int.Parse(DataSaveClass.DeleteId[i]) == int.Parse(searchText_id.Text))
                {
                    // メッセージボックスを表示する
                    MessageBox.Show("該当するデータがありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
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
                        memberCommand.CommandText = $" SELECT * FROM m_member WHERE client_ID = @Client_ID";
                        //パラメータセット
                        memberCommand.Parameters.Add("Client_ID", System.Data.DbType.Int64);
                        //データ追加
                        memberCommand.Parameters["Client_ID"].Value = searchText_id.Text;
                        //データの読み込み
                        SQLiteDataReader reader = memberCommand.ExecuteReader();
                        //該当するデータを読み込む
                        while (reader.Read() == true)
                        {
                            //データベースから取り出したデータを配列に代入する
                            memberSaves[5] = reader["Client_ID"].ToString();
                        }
                        //データの読み込みを終了
                        reader.Close();
                        //SQLコマンドを終了
                        memberCommand.ExecuteNonQuery();

                        //SQL文
                        memberCommand.CommandText = "UPDATE m_member set before_Login = @Before_Login  WHERE client_ID = @Client_ID";
                        //パラメータセット
                        memberCommand.Parameters.Add("Client_ID", System.Data.DbType.Int64);
                        memberCommand.Parameters.Add("Before_Login", System.Data.DbType.Boolean);
                        //データ追加
                        memberCommand.Parameters["Client_ID"].Value = int.Parse(searchText_id.Text);
                        //前回の会員データ表示のため、検索している会員をtrueにする
                        memberCommand.Parameters["Before_Login"].Value = Boolean.Parse(true.ToString());
                        memberCommand.ExecuteNonQuery();
                        //コミット
                        memberTransaction.Commit();
                    }
                }
            }
            catch
            {
                // メッセージボックスを表示する
                MessageBox.Show("記入内容に間違い、または存在しないIDが入力されています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //検索結果画面のフォームを代入
            Form searchOutput = new SearchOutput();
            //指定したフォームを開く
            searchOutput.Show();
            //現在開いているフォームを閉じる
            this.Hide();
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

        /// <summary>
        /// SearchInputLoad
        /// 前回調べた会員情報を取得し、あればflagをfalseに戻す
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void SearchInputLoad(object sender, EventArgs e)
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

                    //過去に検索したデータがあったら処理する
                    if (memberSaves[6] == "1")
                    {
                        //SQL文
                        memberCommand.CommandText = "UPDATE m_member set before_Login = @Before_Login  WHERE client_ID = @Client_ID";
                        //パラメータセット
                        memberCommand.Parameters.Add("Client_ID", System.Data.DbType.Int64);
                        memberCommand.Parameters.Add("Before_Login", System.Data.DbType.Boolean);
                        //データ追加
                        memberCommand.Parameters["Client_ID"].Value = int.Parse(memberSaves[5]);
                        //flagをfalseに戻す
                        memberCommand.Parameters["Before_Login"].Value = Boolean.Parse(false.ToString());
                        //SQLコマンドを終了
                        memberCommand.ExecuteNonQuery();

                        //前回ログインした会員データ
                        ClientID_label_before.Text = memberSaves[5].ToString();
                        ClientName_label_before.Text = memberSaves[0].ToString();
                        //ページ数表示のデザイン表示
                        Design_slash_label_before.Text = textDesigns[1].ToString();
                        //前回検索した会員の表示
                        beforeName_label.Text = _beforeLabel;
                        //前回検索した会員のIDの表示
                        beforeId_label.Text = _beforeIdLabel.ToString();
                    }

                    //SQLコマンドを宣言する
                    memberCommand = memberConnection.CreateCommand();
                    //SQL文
                    memberCommand.CommandText = $" SELECT * FROM m_member";
                    //データの読み込み
                    reader = memberCommand.ExecuteReader();
                    //該当するデータの読み込み
                    while (reader.Read() == true)
                    {
                        //会員データのカウント
                        if (DataSaveClass.IsClient)
                        {
                            DataSaveClass.MemberCount++;
                        }
                    }
                    //flagをfalseにする
                    DataSaveClass.IsClient = false;
                    //データの読み込みを終了
                    reader.Close();
                    //SQLコマンドを終了
                    memberCommand.ExecuteNonQuery();

                    //コミット
                    memberTransaction.Commit();
                }
            }

            //ComboBoxのリスト
            searchComboBox.Items.Add("全て");
            searchComboBox.Items.Add("漫画");
            searchComboBox.Items.Add("雑誌");
            searchComboBox.Items.Add("小説");
            searchComboBox.Items.Add("辞書");
            searchComboBox.Items.Add("図鑑");
            searchComboBox.Items.Add("教材");

            //次のページを表示するボタンを非表示
            NextPageButton.Visible = false;
            //前のページを表示するボタンを非表示
            BackPageButton.Visible = false;
        }

        /// <summary>
        /// SearchComboBoxSelectedIndexChanged
        /// ComboBoxで選択された内容を表示するための処理
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void SearchComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            //ページのテキストリセット
            for (int i = 0; i < LABEL_ALL_TEXT; i++)
            {
                //ラベル記入
                this.Controls["ClientID_label_" + i].Text = textDesigns[2].ToString();
                this.Controls["ClientName_label_" + i].Text = textDesigns[2].ToString();
                this.Controls["Design_label_" + i].Text = textDesigns[2].ToString();
                this.Controls["Design_slash_label_" + i].Text = textDesigns[2].ToString();
            }

            //配列内と使用している変数ののリセット
            for (int i = 0; i < 20; i++)
            {
                bookSearchSaves[i] = "";
                clientIdSaves[i] = "";
                clientNameSaves[i] = "";
                _historyCount = RESET_COUNT;
            }

            //ComboBoxで選んだ項目を表示
            if (searchComboBox.Text.ToString() == "全て")
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
                        //SQL文
                        memberCommand.CommandText = "SELECT * FROM m_member";
                        //データの読み込み
                        SQLiteDataReader reader = memberCommand.ExecuteReader();
                        //該当するデータを全て読み込み
                        while (reader.Read() == true)
                        {
                            //データベースから取り出したデータを配列に代入
                            clientIdSaves[_historyCount] = reader["client_ID"].ToString();
                            clientNameSaves[_historyCount] = reader["name_text"].ToString();

                            //データベースの列数をカウント
                            _historyCount++;
                        }
                        //データの読み込みを終了
                        reader.Close();
                    }
                }
            }
            else if (searchComboBox.Text.ToString() == "漫画" || searchComboBox.Text.ToString() == "雑誌" || 
                searchComboBox.Text.ToString() == "小説" || searchComboBox.Text.ToString() == "辞書" || 
                searchComboBox.Text.ToString() == "図鑑" || searchComboBox.Text.ToString() == "教材")
            {
                    //データベースを代入
                using (SQLiteConnection bookConnection = new SQLiteConnection("Data Source=book.db"))
                {
                    //データベースを開く
                    bookConnection.Open();
                    //代入したデータベースの処理
                    using (SQLiteTransaction bookTransaction = bookConnection.BeginTransaction())
                    {
                        // SQLコマンドを宣言する
                        SQLiteCommand bookCommand = bookConnection.CreateCommand();
                        //SQL文
                        bookCommand.CommandText = "SELECT * FROM m_book WHERE genre_text = @Genre_text";
                        //パラメータセット
                        bookCommand.Parameters.Add("Genre_text", System.Data.DbType.String);
                        //データ追加
                        bookCommand.Parameters["Genre_text"].Value = searchComboBox.Text;
                        //データの読み込み
                        SQLiteDataReader reader = bookCommand.ExecuteReader();
                        //該当するデータを全て読み込み
                        while (reader.Read() == true)
                        {
                            //データベースから取り出したデータを配列に代入
                            bookSearchSaves[_saveCount] = reader["book_ID"].ToString();

                            //データベースの列数をカウント
                            _saveCount++;
                        }
                        //データの読み込みを終了
                        reader.Close();
                    }
                }
                
                //データベースを代入
                using (SQLiteConnection historyConnection = new SQLiteConnection("Data Source=history.db"))
                {
                    //データベースを開く
                    historyConnection.Open();
                    //代入したデータベースの処理
                    using (SQLiteTransaction historyTransaction = historyConnection.BeginTransaction())
                    {
                        //bookDBから取り出した回数分回す
                        for (int bookIdRead = 0; bookIdRead < _saveCount; bookIdRead++)
                        {
                            // SQLコマンドを宣言する
                            SQLiteCommand historyCommand = historyConnection.CreateCommand();
                            //SQL文
                            historyCommand.CommandText = "SELECT * FROM m_history WHERE book_id = @Book_id";
                            //パラメータセット
                            historyCommand.Parameters.Add("Book_id", System.Data.DbType.Int64);
                            //データ追加
                            historyCommand.Parameters["Book_id"].Value = int.Parse(bookSearchSaves[bookIdRead].ToString());
                            //データの読み込み
                            SQLiteDataReader reader = historyCommand.ExecuteReader();
                            //該当するデータを全て読み込み
                            while (reader.Read() == true)
                            {
                                //比較用に一時保存
                                _saveId = reader["manegement_id"].ToString();

                                //配列内を全て確認
                                for (int i = 0; i < _historyCount; i++)
                                {
                                    //配列に同じものがないか比較
                                    if (_saveId == bookSearchSaves[i].ToString())
                                    {
                                        //同じものがあったらtrue
                                        IsSaveId = true;
                                    }
                                }

                                //配列に同じものがなければ代入する、あれば代入しない
                                if (!IsSaveId)
                                {
                                    //データベースから取り出したデータを配列に代入
                                    bookSearchSaves[_historyCount] = _saveId;

                                    //カウント
                                    _historyCount++;
                                }
                                else if(IsSaveId)
                                {
                                    //フラグをfalseに戻す
                                    IsSaveId = false;
                                }
                            }
                            //データの読み込みを終了
                            reader.Close();
                        }

                        //リセット
                        _saveCount = RESET_COUNT;
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
                        //historyDBから会員IDを取り出した回数分回す
                        for (int memberIdRead = 0; memberIdRead < _historyCount; memberIdRead++)
                        {
                            // SQLコマンドを宣言する
                            SQLiteCommand memberCommand = memberConnection.CreateCommand();
                            //SQL文
                            memberCommand.CommandText = "SELECT * FROM m_member WHERE client_ID = @Client_ID";
                            //パラメータセット
                            memberCommand.Parameters.Add("Client_ID", System.Data.DbType.Int64);
                            //データ追加
                            memberCommand.Parameters["Client_ID"].Value = int.Parse(bookSearchSaves[memberIdRead].ToString());
                            //データの読み込み
                            SQLiteDataReader reader = memberCommand.ExecuteReader();
                            //該当するデータを全て読み込み
                            while (reader.Read() == true)
                            {
                                //比較用に一時保存
                                clientIdSaves[memberIdRead] = reader["client_ID"].ToString();
                                clientNameSaves[memberIdRead] = reader["name_text"].ToString();
                            }
                            //データの読み込みを終了
                            reader.Close();
                        }
                    }
                }
            }

            //昇順のソート
            for (int clientIdFor = 0; clientIdFor < _historyCount; clientIdFor++)
            {
                _sortFor = int.Parse(clientIdSaves[clientIdFor]);

                for (int clientIdLater = clientIdFor + 1; clientIdLater < _historyCount; clientIdLater++)
                {
                    _sortLater = int.Parse(clientIdSaves[clientIdLater]);

                    if (_sortFor > _sortLater)
                    {
                        //現在の配列に入っている値を入れる
                        _sortSaveName = clientNameSaves[clientIdFor].ToString();
                        _sortSave = int.Parse(clientIdSaves[clientIdFor]);

                        //現在の配列に、次の配列にある本の名前と年月日を代入
                        clientNameSaves[clientIdFor] = clientNameSaves[clientIdLater].ToString();
                        clientIdSaves[clientIdFor] = clientIdSaves[clientIdLater].ToString();

                        //現在の配列に入っている本の名前と年月日を、次の配列に代入
                        clientNameSaves[clientIdLater] = _sortSaveName;
                        clientIdSaves[clientIdLater] = _sortSave.ToString();

                        //年だけを取得
                        _sortFor = int.Parse(clientIdSaves[clientIdFor]);
                    }
                }
            }

            //全ページ数
            if (_historyCount <= LABEL_ALL_TEXT)
            {
                _lastPage = 1;
            }
            else if (_historyCount <= 10)
            {
                _lastPage = 2;
            }
            else if (_historyCount <= 15)
            {
                _lastPage = 3;
            }
            else if (_historyCount <= 20)
            {
                _lastPage = 4;
            }

            //全ページが2ページ以上になる場合
            if (_lastPage > 1)
            {
                for (int i = 0; i < LABEL_ALL_TEXT; i++)
                {
                    //ラベル記入
                    this.Controls["ClientID_label_" + i].Text = clientIdSaves[i].ToString();
                    this.Controls["ClientName_label_" + i].Text = clientNameSaves[i].ToString();
                    this.Controls["Design_label_" + i].Text = textDesigns[0].ToString();
                    this.Controls["Design_slash_label_" + i].Text = textDesigns[1].ToString();
                }

                //次のページを表示するボタンを表示
                NextPageButton.Visible = true;
                //前のページを表示するボタンを非表示
                BackPageButton.Visible = false;
            }
            //全ページが1ページなら全て記入
            else
            {
                for (int i = 0; i < _historyCount; i++)
                {
                    //ラベル記入
                    this.Controls["ClientID_label_" + i].Text = clientIdSaves[i].ToString();
                    this.Controls["ClientName_label_" + i].Text = clientNameSaves[i].ToString();
                    this.Controls["Design_label_" + i].Text = textDesigns[0].ToString();
                    this.Controls["Design_slash_label_" + i].Text = textDesigns[1].ToString();
                }

                //次のページを表示するボタンを非表示
                NextPageButton.Visible = false;
                //前のページを表示するボタンを非表示
                BackPageButton.Visible = false;
            }

            //ページ数を表示
            PageCountLabel.Text = _pageCount.ToString();
            //ページ数表示のデザイン表示
            Design_line_label_0.Text = textDesigns[3];
            //ページ数表示のデザイン表示
            Design_line_label_1.Text = textDesigns[3];
            
        }

        /// <summary>
        /// NextButton
        /// 取得した列データが記入するラベルの個数を超えた場合、
        /// 最初のラベルの個数分を表示したデータを非表示にし、残りのデータを表示する
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void NextPageButton_Click(object sender, EventArgs e)
        {
            //ページのテキストリセット
            for (int i = 0; i < 5; i++)
            {
                //ラベル記入
                this.Controls["ClientID_label_" + i].Text = textDesigns[2].ToString();
                this.Controls["ClientName_label_" + i].Text = textDesigns[2].ToString();
                this.Controls["Design_label_" + i].Text = textDesigns[2].ToString();
                this.Controls["Design_slash_label_" + i].Text = textDesigns[2].ToString();
            }

            //前のページを表示するボタンを表示
            BackPageButton.Visible = true;

            //ページごとに記入
            switch (_pageCount)
            {
                case 1:
                    //配列から読み込むデータの始点
                    _saveDataReadFast = 5;
                    //配列から読み込むデータの終点
                    _saveDataReadLast = 10;

                    //データの終点より読み込むデータ数が小さいとき、読み込むデータ数を代入する
                    if (_historyCount < _saveDataReadLast)
                    {
                        _saveDataReadLast = _historyCount;
                    }

                    //データの記入
                    for (int i = _saveDataReadFast; i < _saveDataReadLast; i++)
                    {
                        //ラベル記入
                        this.Controls["ClientID_label_" + _labelTextCount].Text = clientIdSaves[i].ToString();
                        this.Controls["ClientName_label_" + _labelTextCount].Text = clientNameSaves[i].ToString();
                        this.Controls["Design_label_" + _labelTextCount].Text = textDesigns[0].ToString();
                        this.Controls["Design_slash_label_" + _labelTextCount].Text = textDesigns[1].ToString();
                        //記入するラベルのカウント
                        _labelTextCount++;
                    }
                    //カウントのリセット
                    _labelTextCount = RESET_COUNT;
                    break;
                case 2:
                    //配列から読み込むデータの始点
                    _saveDataReadFast = 10;
                    //配列から読み込むデータの終点
                    _saveDataReadLast = 15;

                    //データの終点より読み込むデータ数が小さいとき、読み込むデータ数を代入する
                    if (_historyCount < _saveDataReadLast)
                    {
                        _saveDataReadLast = _historyCount;
                    }

                    //データの記入
                    for (int i = _saveDataReadFast; i < _saveDataReadLast; i++)
                    {
                        //ラベル記入
                        this.Controls["ClientID_label_" + _labelTextCount].Text = clientIdSaves[i].ToString();
                        this.Controls["ClientName_label_" + _labelTextCount].Text = clientNameSaves[i].ToString();
                        this.Controls["Design_label_" + _labelTextCount].Text = textDesigns[0].ToString();
                        this.Controls["Design_slash_label_" + _labelTextCount].Text = textDesigns[1].ToString();
                        //記入するラベルのカウント
                        _labelTextCount++;
                    }
                    //カウントのリセット
                    _labelTextCount = RESET_COUNT;
                    break;
                case 3:
                    //配列から読み込むデータの始点
                    _saveDataReadFast = 15;
                    //配列から読み込むデータの終点
                    _saveDataReadLast = 20;

                    //データの終点より読み込むデータ数が小さいとき、読み込むデータ数を代入する
                    if (_historyCount < _saveDataReadLast)
                    {
                        _saveDataReadLast = _historyCount;
                    }

                    //データの記入
                    for (int i = _saveDataReadFast; i < _saveDataReadLast; i++)
                    {
                        //ラベル記入
                        this.Controls["ClientID_label_" + _labelTextCount].Text = clientIdSaves[i].ToString();
                        this.Controls["ClientName_label_" + _labelTextCount].Text = clientNameSaves[i].ToString();
                        this.Controls["Design_label_" + _labelTextCount].Text = textDesigns[0].ToString();
                        this.Controls["Design_slash_label_" + _labelTextCount].Text = textDesigns[1].ToString();
                        //記入するラベルのカウント
                        _labelTextCount++;
                    }
                    //カウントのリセット
                    _labelTextCount = RESET_COUNT;
                    break;
                case 4:
                    //配列から読み込むデータの始点
                    _saveDataReadFast = 20;
                    //配列から読み込むデータの終点
                    _saveDataReadLast = 25;

                    //データの終点より読み込むデータ数が小さいとき、読み込むデータ数を代入する
                    if (_historyCount < _saveDataReadLast)
                    {
                        _saveDataReadLast = _historyCount;
                    }

                    //データの記入
                    for (int i = _saveDataReadFast; i < _saveDataReadLast; i++)
                    {
                        //ラベル記入
                        this.Controls["ClientID_label_" + _labelTextCount].Text = clientIdSaves[i].ToString();
                        this.Controls["ClientName_label_" + _labelTextCount].Text = clientNameSaves[i].ToString();
                        this.Controls["Design_label_" + _labelTextCount].Text = textDesigns[0].ToString();
                        this.Controls["Design_slash_label_" + _labelTextCount].Text = textDesigns[1].ToString();
                        //記入するラベルのカウント
                        _labelTextCount++;
                    }
                    //カウントのリセット
                    _labelTextCount = RESET_COUNT;
                    break;
            }

            //ページカウント
            _pageCount++;
            //ページ数を表示
            PageCountLabel.Text = _pageCount.ToString();

            //最後のページになったら次へのボタンを非表示
            if (_pageCount == _lastPage)
            {
                //次のページを表示するボタンを非表示
                NextPageButton.Visible = false;
            }

            //前後にページがある場合、両方のボタンを表示する
            if (1 < _pageCount && _pageCount < _lastPage)
            {
                //次のページを表示するボタンを表示
                NextPageButton.Visible = true;
                //前のページを表示するボタンを表示
                BackPageButton.Visible = true;
            }
        }

        /// <summary>
        /// BackButton
        /// NextButtonが押された場合、表示されているデータを非表示にし、非表示だったデータを表示する
        /// </summary>
        /// <param name="sender">フォームの作成に使用</param>
        /// <param name="e">フォームの作成に使用</param>
        private void BackPageButton_Click(object sender, EventArgs e)
        {
            //ページのテキストリセット
            for (int i = 0; i < LABEL_ALL_TEXT; i++)
            {
                //ラベル記入
                this.Controls["ClientID_label_" + i].Text = textDesigns[2].ToString();
                this.Controls["ClientName_label_" + i].Text = textDesigns[2].ToString();
                this.Controls["Design_label_" + i].Text = textDesigns[2].ToString();
                this.Controls["Design_slash_label_" + i].Text = textDesigns[2].ToString();
            }

            //ページカウント
            _pageCount--;
            //ページ数を表示
            PageCountLabel.Text = _pageCount.ToString();

            //ページごとに記入
            switch (_pageCount)
            {
                case 1:
                    //配列から読み込むデータの始点
                    _saveDataReadFast = 0;
                    //配列から読み込むデータの終点
                    _saveDataReadLast = 5;

                    //データの終点より読み込むデータ数が小さいとき、読み込むデータ数を代入する
                    if (_historyCount < _saveDataReadLast)
                    {
                        _saveDataReadLast = _historyCount;
                    }

                    //データの記入
                    for (int i = _saveDataReadFast; i < _saveDataReadLast; i++)
                    {
                        //ラベル記入
                        this.Controls["ClientID_label_" + _labelTextCount].Text = clientIdSaves[i].ToString();
                        this.Controls["ClientName_label_" + _labelTextCount].Text = clientNameSaves[i].ToString();
                        this.Controls["Design_label_" + _labelTextCount].Text = textDesigns[0].ToString();
                        this.Controls["Design_slash_label_" + _labelTextCount].Text = textDesigns[1].ToString();
                        //記入するラベルのカウント
                        _labelTextCount++;
                    }
                    break;
                case 2:
                    //配列から読み込むデータの始点
                    _saveDataReadFast = 5;
                    //配列から読み込むデータの終点
                    _saveDataReadLast = 10;

                    //データの終点より読み込むデータ数が小さいとき、読み込むデータ数を代入する
                    if (_historyCount < _saveDataReadLast)
                    {
                        _saveDataReadLast = _historyCount;
                    }

                    //データの記入
                    for (int i = _saveDataReadFast; i < _saveDataReadLast; i++)
                    {
                        //ラベル記入
                        this.Controls["ClientID_label_" + _labelTextCount].Text = clientIdSaves[i].ToString();
                        this.Controls["ClientName_label_" + _labelTextCount].Text = clientNameSaves[i].ToString();
                        this.Controls["Design_label_" + _labelTextCount].Text = textDesigns[0].ToString();
                        this.Controls["Design_slash_label_" + _labelTextCount].Text = textDesigns[1].ToString();
                        //記入するラベルのカウント
                        _labelTextCount++;
                    }
                    break;
                case 3:
                    //配列から読み込むデータの始点
                    _saveDataReadFast = 10;
                    //配列から読み込むデータの終点
                    _saveDataReadLast = 15;

                    //データの終点より読み込むデータ数が小さいとき、読み込むデータ数を代入する
                    if (_historyCount < _saveDataReadLast)
                    {
                        _saveDataReadLast = _historyCount;
                    }

                    //データの記入
                    for (int i = _saveDataReadFast; i < _saveDataReadLast; i++)
                    {
                        //ラベル記入
                        this.Controls["ClientID_label_" + _labelTextCount].Text = clientIdSaves[i].ToString();
                        this.Controls["ClientName_label_" + _labelTextCount].Text = clientNameSaves[i].ToString();
                        this.Controls["Design_label_" + _labelTextCount].Text = textDesigns[0].ToString();
                        this.Controls["Design_slash_label_" + _labelTextCount].Text = textDesigns[1].ToString();
                        //記入するラベルのカウント
                        _labelTextCount++;
                    }
                    break;
            }

            //カウントのリセット
            _labelTextCount = RESET_COUNT;

            //最初のページに戻ったら、前へボタンを非表示
            if (_pageCount == FAST_PAGE)
            {
                //次のページを表示するボタンを表示
                NextPageButton.Visible = true;
                //前のページを表示するボタンを非表示
                BackPageButton.Visible = false;
            }
        }
    }
}
