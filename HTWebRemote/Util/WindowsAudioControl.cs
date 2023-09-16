using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HTWebRemote.Util
{
    class WindowsAudioControl
    {
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        [ComImport]
        [Guid("A95664D2-9614-4F35-A746-DE8DB63617E6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IMMDeviceEnumerator
        {
            void _VtblGap1_1();
            int GetDefaultAudioEndpoint(int dataFlow, int role, out IMMDevice ppDevice);
        }
        private static class MMDeviceEnumeratorFactory
        {
            public static IMMDeviceEnumerator CreateInstance()
            {
                return (IMMDeviceEnumerator)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("BCDE0395-E52F-467C-8E3D-C4579291692E")));
            }
        }
        [Guid("D666063F-1587-4E43-81F1-B948E807363F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IMMDevice
        {
            int Activate([MarshalAs(UnmanagedType.LPStruct)] Guid iid, int dwClsCtx, IntPtr pActivationParams, [MarshalAs(UnmanagedType.IUnknown)] out object ppInterface);
        }

        [Guid("5CDF2C82-841E-4546-9722-0CF74078229A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IAudioEndpointVolume
        {
            int RegisterControlChangeNotify(IntPtr pNotify);
            int UnregisterControlChangeNotify(IntPtr pNotify);
            int GetChannelCount(ref uint pnChannelCount);
            int SetMasterVolumeLevel(float fLevelDB, Guid pguidEventContext);
            int SetMasterVolumeLevelScalar(float fLevel, Guid pguidEventContext);
            int GetMasterVolumeLevel(ref float pfLevelDB);
            float GetMasterVolumeLevelScalar();
        }

        public static int GetVolume()
        {
            try
            {
                IMMDeviceEnumerator deviceEnumerator = MMDeviceEnumeratorFactory.CreateInstance();
                const int eRender = 0;
                const int eMultimedia = 1;
                deviceEnumerator.GetDefaultAudioEndpoint(eRender, eMultimedia, out IMMDevice speakers);

                speakers.Activate(typeof(IAudioEndpointVolume).GUID, 0, IntPtr.Zero, out object o);
                IAudioEndpointVolume aepv = (IAudioEndpointVolume)o;
                float volume = aepv.GetMasterVolumeLevelScalar();
                Marshal.ReleaseComObject(aepv);
                Marshal.ReleaseComObject(speakers);
                Marshal.ReleaseComObject(deviceEnumerator);
                return Convert.ToInt32(volume * 100);
            }
            catch (Exception e)
            {
                ErrorHandler.SendError($"Error getting volume: \n\n{e.AllMessages()}");
            }

            return 0;
        }

        public static void SetVolume(int vol)
        {
            try
            {
                IMMDeviceEnumerator deviceEnumerator = MMDeviceEnumeratorFactory.CreateInstance();
                const int eRender = 0;
                const int eMultimedia = 1;
                deviceEnumerator.GetDefaultAudioEndpoint(eRender, eMultimedia, out IMMDevice speakers);

                speakers.Activate(typeof(IAudioEndpointVolume).GUID, 0, IntPtr.Zero, out object aepv_obj);
                IAudioEndpointVolume aepv = (IAudioEndpointVolume)aepv_obj;
                Guid ZeroGuid = new Guid();
                int res = aepv.SetMasterVolumeLevelScalar(vol / 100f, ZeroGuid);
                Marshal.ReleaseComObject(aepv);
                Marshal.ReleaseComObject(speakers);
                Marshal.ReleaseComObject(deviceEnumerator);
            }
            catch (Exception e)
            {
                ErrorHandler.SendError($"Error setting volume: \n\n{e.AllMessages()}");
            }
        }

        public static void AddSubtractVolume(int amount)
        {
            int newVol = GetVolume() + amount;

            if(newVol > 100)
            {
                newVol = 100;
            }
            else if(newVol < 0)
            {
                newVol = 0;
            }

            SetVolume(newVol);
        }

        public static void MuteVolume()
        {
            try
            {
                keybd_event((byte)Keys.VolumeMute, 0, 0, 0);
            }
            catch(Exception e)
            {
                ErrorHandler.SendError($"Error muting volume: \n\n{e.AllMessages()}");
            }
        }
    }
}