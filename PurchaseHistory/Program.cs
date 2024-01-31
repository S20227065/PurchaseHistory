using System;
using System.Windows.Forms;

namespace PurchaseHistory
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //ログイン画面
            Application.Run(new ManagementLogin());

            //ログインDB
            //Application.Run(new DB_managementLogin());
            //会員DB
            //Application.Run(new DB_Manegement());
            //購入する本DB
            //Application.Run(new DB_book());
            //購入履歴DB
            //Application.Run(new DB_History());

            //Application.Run(new SearchInput());
        }
    }
}
