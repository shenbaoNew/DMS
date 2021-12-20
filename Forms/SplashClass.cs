using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;

namespace DMS.Forms
{
    public interface ISplashForm
    {
        void SetStatusInfo(string statusInfo);
    }

    public class SplashClass
    {
        private static Thread m_SplashThread = null;
        private static Form m_SplashForm = null;
        private static ISplashForm m_SplashInterface = null;
        private static string m_TempStatus = string.Empty;

        public static void Show(Type splashFormType)
        {
            if (m_SplashThread != null)
                return;
            if (splashFormType == null)
                throw new ApplicationException("SplashFormType is null");

            m_SplashThread = new Thread(new ThreadStart(delegate()
            {
                CreateInstance(splashFormType);
                Application.Run(m_SplashForm);
            }));

            m_SplashThread.IsBackground = true;
            m_SplashThread.SetApartmentState(ApartmentState.STA);
            m_SplashThread.Start();
        }

        private static void CreateInstance(Type FormType)
        {
            object obj = FormType.InvokeMember(null, BindingFlags.DeclaredOnly | BindingFlags.Public |
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance,
                null, null, null);

            m_SplashForm = obj as Form;
            m_SplashInterface = obj as ISplashForm;

            if (m_SplashForm == null)
                throw new Exception("Splash screen must inherit from System.Windows.Forms.Form");
            if (m_SplashInterface == null)
                throw new Exception("Splash screen must implement Interface ISplashForm");

            if (!string.IsNullOrEmpty(m_TempStatus))
                m_SplashInterface.SetStatusInfo(m_TempStatus);
        }

        /// <summary>
        /// set the loading Status
        /// </summary>
        public static string Status
        {
            set
            {
                if (m_SplashInterface == null || m_SplashForm == null)
                {
                    m_TempStatus = value;
                    return;
                }
                m_SplashForm.Invoke(
                        new SplashStatusChangedHandle(delegate(string str) { m_SplashInterface.SetStatusInfo(str); }),
                        new object[] { value }
                    );
            }
        }

        /// <summary>
        /// Colse the SplashForm
        /// </summary>
        public static void Close()
        {
            if (m_SplashThread == null || m_SplashForm == null) return;

            try
            {
                m_SplashForm.Invoke(new MethodInvoker(m_SplashForm.Close));

            }
            catch (Exception)
            {
            }
            m_SplashThread = null;
            m_SplashForm = null;
        }

        private delegate void SplashStatusChangedHandle(string NewStatusInfo);
    }
}