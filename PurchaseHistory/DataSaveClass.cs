using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseHistory
{
    /// <summary>
    /// DataSaveClass
    /// 管理者IDを保存
    /// </summary>
    class DataSaveClass
    {
        //管理者IDの保存
        private static string _administratorId;

        //データベースに入っているデータの数を保存
        private static int _memberCount = 0;

        //会員データの数を一回だけ数える
        private static bool IsClientCount = true;

        //削除した会員データの保存
        private static string[] _deleteId = {"0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };

        //会員登録で入力されたデータの一時的な保存
        private static string _inputInsertName;
        private static string _inputInsertPhone;
        private static string _inputInsertAddress;
        private static string _inputInsertPost;
        private static string _inputInsertEmail;

        //会員登録で入力されたデータの一時的な保存
        private static string _inputUpdateName;
        private static string _inputUpdatePhone;
        private static string _inputUpdateAddress;
        private static string _inputUpdatePost;
        private static string _inputUpdateEmail;

        public static string AdministratorId { get => _administratorId; set => _administratorId = value; }

        public static string InputInsertName { get => _inputInsertName; set => _inputInsertName = value; }
        public static string InputInsertPhone { get => _inputInsertPhone; set => _inputInsertPhone = value; }
        public static string InputInsertAddress { get => _inputInsertAddress; set => _inputInsertAddress = value; }
        public static string InputInsertPost { get => _inputInsertPost; set => _inputInsertPost = value; }
        public static string InputInsertEmail { get => _inputInsertEmail; set => _inputInsertEmail = value; }

        public static string InputUpdateName { get => _inputUpdateName; set => _inputUpdateName = value; }
        public static string InputUpdatePhone { get => _inputUpdatePhone; set => _inputUpdatePhone = value; }
        public static string InputUpdateAddress { get => _inputUpdateAddress; set => _inputUpdateAddress = value; }
        public static string InputUpdatePost { get => _inputUpdatePost; set => _inputUpdatePost = value; }
        public static string InputUpdateEmail { get => _inputUpdateEmail; set => _inputUpdateEmail = value; }
        public static int MemberCount { get => _memberCount; set => _memberCount = value; }
        public static string[] DeleteId { get => _deleteId; set => _deleteId = value; }
        public static bool IsClient { get => IsClientCount; set => IsClientCount = value; }
    }
}
