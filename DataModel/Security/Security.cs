using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS
{
    class Security
    {
        public static int[] mmskeys = { 2, 1, 3, 4, 8, 4, 5, 9, 1, 7, 2, 6, 1, 5, 8 };
        public static int[] imskeys = { 1, 2, 4, 8, 4, 5, 1, 3, 2, 6, 5, 9, 1, 7, 1, 8, 3 };
        public static int[] commonkeys = { 1, 9, 1, 7, 3, 2, 5, 1, 8, 6, 3 };

        public const int DefalutNumber = 2;

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Encryp(string password, SecurityEnum flag)
        {
            string enPas = string.Empty;
            int[] keys = null;
            if (flag == SecurityEnum.MMS)
                keys = mmskeys;
            else if (flag == SecurityEnum.IMS)
                keys = imskeys;
            else
                keys = commonkeys;
            for (int i = 0; i < password.Length; i++)
            {
                char ch;
                if (i < keys.Length)
                    ch = (char)(password[i] + keys[i]);
                else
                    ch = (char)(password[i] + DefalutNumber);

                enPas += ch;
            }

            return enPas;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="enPas"></param>
        /// <returns></returns>
        public static string Decrypt(string enPas, SecurityEnum flag)
        {
            string psd = string.Empty;

            int[] keys = null;
            if (flag == SecurityEnum.MMS)
                keys = mmskeys;
            else if (flag == SecurityEnum.IMS)
                keys = imskeys;
            else
                keys = commonkeys;
            for (int i = 0; i < enPas.Length; i++)
            {
                char ch;
                if (i < keys.Length)
                    ch = (char)(enPas[i] - keys[i]);
                else
                    ch = (char)(enPas[i] - DefalutNumber);

                psd += ch;
            }

            return psd;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="enPas"></param>
        /// <returns></returns>
        public static string DecryptBak(string enPas, SecurityEnum flag)
        {
            string psd = string.Empty;

            int[] keys = null;
            if (flag == SecurityEnum.MMS)
                keys = mmskeys;
            else if (flag == SecurityEnum.IMS)
                keys = imskeys;
            else
                keys = commonkeys;
            for (int i = 0; i < enPas.Length; i++)
            {
                if (i < keys.Length)
                {
                    char ch = (char)(enPas[i] - 1);
                    if (!IsXMLChar(ch.ToString()))
                        psd += (char)(enPas[i] - keys[i]);
                    else
                        psd += (char)(enPas[i] - keys[i] - 1);
                }
                else
                {
                    char ch = (char)(enPas[i] - 1);
                    if (!IsXMLChar(ch.ToString()))
                        psd += (char)(enPas[i] - 2);
                    else
                        psd += (char)(enPas[i] - 3);
                }
            }

            return psd;
        }

        /// <summary>
        /// 判断是否为XML关键字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsXMLChar(string str)
        {
            string[] strss = { "&", "'", "\"", ">", "<" };
            return strss.Contains(str);
        }
    }
}
