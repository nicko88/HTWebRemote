using System;
using System.Runtime.InteropServices;

namespace HTWebRemote.Util
{
    public static class KeyboardHook
    {
        public static bool Register(int key, int modifier, IntPtr hWnd)
        {
            int id = modifier ^ key ^ hWnd.ToInt32();

            return RegisterHotKey(hWnd, id, modifier, key);
        }

        public static bool Unregister(int key, int modifier, IntPtr hWnd)
        {
            int id = modifier ^ key ^ hWnd.ToInt32();

            return UnregisterHotKey(hWnd, id);
        }

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }
}