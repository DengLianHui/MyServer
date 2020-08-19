using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace ERP_Demo_WinForm
{
    class ProtoKey
    {
        [Serializable]
        public struct UserConfig
        {
            string m_userID;
            string m_password;
            Bitmap m_head_thumb;
            bool m_rememberPassword;

            public string UserID { get => m_userID; set => m_userID = value; }
            public string Password { get => m_password; set => m_password = value; }
            public bool RememberPassword { get => m_rememberPassword; set => m_rememberPassword = value; }
            public Bitmap Head_thumb { get => m_head_thumb; set => m_head_thumb = value; }
        }
    }
}
