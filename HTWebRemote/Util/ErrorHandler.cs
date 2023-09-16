using System;
using System.Windows.Forms;

namespace HTWebRemote.Util
{
    static class ErrorHandler
    {
        public static void SendError(string error)
        {
            if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTWebRemote", "ShowErrors"))
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void SendMsg(string msg)
        {
            MessageBox.Show(msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

namespace HTWebRemote
{
    public static class ExceptionExtensions
    {
        public static string AllMessages(this Exception ex)
        {
            string allMessages = string.Empty;

            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                allMessages += ex.Message + "\n\n";
            }

            return allMessages;
        }
    }
}