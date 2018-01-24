using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace UsbRelay
{
    /// <summary>
    /// Type of usb relay device. 
    /// The type is determined by the number of relay modules physically installed in the device.
    /// </summary>
    public enum Enum_Usb_relay_device_type
    {
        USB_RELAY_DEVICE_ONE_CHANNEL = 1,
        USB_RELAY_DEVICE_TWO_CHANNEL = 2,
        USB_RELAY_DEVICE_FOUR_CHANNEL = 4,
        USB_RELAY_DEVICE_EIGHT_CHANNEL = 8
    }

    /// <summary>
    /// Information of USB relay device
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Usb_relay_device_info
    {
        /// <summary>
        /// Usb relay serial number.
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string serial_number;
        public IntPtr device_path { get; set; }
        /// <summary>
        /// Type of usb relay device. 
        /// </summary>
        public Enum_Usb_relay_device_type type { get; set; }
        public IntPtr next { get; set; }

        /// <summary>
        /// channels quantity
        /// </summary>
        public int channel_quantity
        {
            get
            {
                if (type == Enum_Usb_relay_device_type.USB_RELAY_DEVICE_ONE_CHANNEL) return 1;
                else if (type == Enum_Usb_relay_device_type.USB_RELAY_DEVICE_TWO_CHANNEL) return 2;
                else if (type == Enum_Usb_relay_device_type.USB_RELAY_DEVICE_FOUR_CHANNEL) return 4;
                else if (type == Enum_Usb_relay_device_type.USB_RELAY_DEVICE_EIGHT_CHANNEL) return 8;
                else return 0;
            }
        }
    }

    public static class UsbRelayDevice
    {
        /// <summary>
        /// Init the USB relay Libary.
        /// </summary>
        /// <returns>Returns 0 on success and -1 on error.</returns>
        [DllImport("usb_relay_device.dll", EntryPoint = "usb_relay_init", SetLastError = true,
                     CharSet = CharSet.Ansi, ExactSpelling = true,
                     CallingConvention = CallingConvention.Cdecl)]
        public static extern int usb_relay_init();
        
        /// <summary>
        /// Finalize the USB Relay Libary. 
        /// It clears all of the data associated with USB relay libary.
        /// </summary>
        /// <returns>Returns 0 on success and -1 on error.</returns>
        [DllImport("usb_relay_device.dll", EntryPoint = "usb_relay_init", SetLastError = true,
                     CharSet = CharSet.Ansi, ExactSpelling = true,
                     CallingConvention = CallingConvention.Cdecl)]
        public static extern int usb_relay_finalize();

        [DllImport("usb_relay_device.dll", EntryPoint = "usb_relay_device_enumerate",CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Pusb_relay_device_enumerate();

        /// <summary>
        /// Get data of USB relay device. Here we get the serial number of the USB relay device.
        /// We can call this function once when the device is first connected, 
        /// and then save the device parameters in the settings and use them.
        /// </summary>
        /// <returns>Information of USB relay device. If USB relay device didn't plug retuns empty structure.</returns>
        public static Usb_relay_device_info usb_relay_device_enumerate()
        {
            IntPtr x = Pusb_relay_device_enumerate();
            if (x.ToInt32() != 0) return (Usb_relay_device_info)Marshal.PtrToStructure(x, typeof(Usb_relay_device_info));
            return new Usb_relay_device_info();
        }
        
        /// <summary>
        /// Open USB relay device
        /// </summary>
        /// <param name="serial_number">Relay serial number</param>
        /// <param name="len">Serial number string lenght</param>
        /// <returns>Ruturn relay device handle or 0 if device dont plug or any error</returns>
        [DllImport("usb_relay_device.dll", EntryPoint = "usb_relay_device_open_with_serial_number", SetLastError = true,
                    CharSet = CharSet.Ansi, ExactSpelling = true,
                    CallingConvention = CallingConvention.Cdecl)]
        public static extern int usb_relay_device_open_with_serial_number([MarshalAs(UnmanagedType.LPStr)] string serial_number, int len);
        
        /// <summary>
        /// Close USB relay device
        /// </summary>
        /// <param name="hHandle">Relay handle</param>
        [DllImport("usb_relay_device.dll", EntryPoint = "usb_relay_device_close", SetLastError = true,
                    CharSet = CharSet.Ansi, ExactSpelling = true,
                    CallingConvention = CallingConvention.Cdecl)]
        public static extern void usb_relay_device_close(int hHandle);

        /// <summary>
        /// Open one relay channel
        /// </summary>
        /// <param name="hHandle">Relay handle</param>
        /// <param name="index">Relay number</param>
        /// <returns>0 -- success; 1 -- error; 2 -- index is out of range in this USB relay device</returns>
        [DllImport("usb_relay_device.dll", EntryPoint = "usb_relay_device_open_one_relay_channel", SetLastError = true,
                    CharSet = CharSet.Ansi, ExactSpelling = true,
                    CallingConvention = CallingConvention.Cdecl)]
        public static extern int usb_relay_device_open_one_relay_channel(int hHandle, int index);

        /// <summary>
        /// Close one relay channel
        /// </summary>
        /// <param name="hHandle">Relay handle</param>
        /// <param name="index">Relay number</param>
        /// <returns>0 -- success; 1 -- error; 2 -- index is out of range in this USB relay device</returns>
        [DllImport("usb_relay_device.dll", EntryPoint = "usb_relay_device_close_one_relay_channel", SetLastError = true,
                    CharSet = CharSet.Ansi, ExactSpelling = true,
                    CallingConvention = CallingConvention.Cdecl)]
        public static extern int usb_relay_device_close_one_relay_channel(int hHandle, int index);

        /// <summary>
        /// Open all relay channels
        /// </summary>
        /// <param name="hHandle">Relay handle</param>
        /// <returns>0 -- success; 1 -- error</returns>
        [DllImport("usb_relay_device.dll", EntryPoint = "usb_relay_device_open_all_relay_channel", SetLastError = true,
                    CharSet = CharSet.Ansi, ExactSpelling = true,
                    CallingConvention = CallingConvention.Cdecl)]
        public static extern int usb_relay_device_open_all_relay_channel(int hHandle);

        /// <summary>
        /// Close all relay channels
        /// </summary>
        /// <param name="hHandle">Relay handle</param>
        /// <returns>0 -- success; 1 -- error</returns>
        [DllImport("usb_relay_device.dll", EntryPoint = "usb_relay_device_close_all_relay_channel", SetLastError = true,
                     CharSet = CharSet.Ansi, ExactSpelling = true,
                     CallingConvention = CallingConvention.Cdecl)]
        public static extern int usb_relay_device_close_all_relay_channel(int hHandle);

        /// <summary>
        /// Get channel status of USB relay drvice.
        /// To obtain the values, it is necessary to convert the parameter "status" to BitArray and take the value of the first N bits. 
        /// Where N is equal to the number of channels of our device. 
        /// The value is true - the channel is open, the false is closed.
        /// For a example:
        /// BitArray ba = new BitArray(new int[] { status });
        /// ba[0] - get status of first chanel. True - first channel is open, false - close
        /// ba[0] - get status of second chanel. True - second channel is open, false - close
        /// For four channel device getting value 0,1,2,3. For two channel - 0,1. etc. 
        /// </summary>
        /// <param name="hHandle">Relay handle</param>
        /// <param name="status">Send the relay channel number that we want to poll. Back we get the status of this channel: 1 - On, 0 - Off.</param>
        /// <returns>0 -- success; 1 -- error</returns>
        [DllImport("usb_relay_device.dll", EntryPoint = "usb_relay_device_get_status", SetLastError = true,
                     CharSet = CharSet.Ansi, ExactSpelling = true,
                     CallingConvention = CallingConvention.Cdecl)]
        //public static extern int GetStatus(int hHandle, ref int status);
        public static extern int GetStatus(int hHandle, out int status);

    }
}
