using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsbRelay;

namespace UsbRelayTestGUI
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// Result of device dll initialization
        /// </summary>
        int UsbRelayDllInitResult = -1;

        /// <summary>
        /// Relay channel number
        /// </summary>
        private int RelayChannel
        {
            get { return (int)numericUpDownRelayNum.Value; }
            set { numericUpDownRelayNum.Value = (int)value; }
        }
        /// <summary>
        /// Relay device serial number
        /// </summary>
        private string RelaySerial
        {
            get
            {
                if (comboBoxRelaySerial.Items.Count == 0) return "";
                else return comboBoxRelaySerial.SelectedItem.ToString();
            }
            set
            {
                if (value != null)
                {
                    comboBoxRelaySerial.Items.Clear();
                    comboBoxRelaySerial.Items.Add(value);
                    comboBoxRelaySerial.SelectedIndex = comboBoxRelaySerial.FindString(value);
                }
            }
        }

        public bool SerialExist
        {
            get { return RelaySerial.Length != 0; }
        }

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                //Get and save result of device library initialization
                UsbRelayDllInitResult = UsbRelayDevice.usb_relay_init();
                if (UsbRelayDllInitResult != 0)
                {
                    MessageBox.Show("Couldn't initialize! usb relay device library");
                    Application.Exit();
                }
                else
                {
                    //Get the serial number of the device when you start the window.
                    //For convenience, that each time the "Update" button is not pressed when the application starts
                    RelaySerial = UsbRelayDevice.usb_relay_device_enumerate().serial_number;
                }
            }
            catch (DllNotFoundException ex)
            {
                MessageBox.Show("Set usb_relay_device.dll into output path!");
                Application.Exit();
            }
            
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UsbRelayDllInitResult == 0)
            {
                //If library initialization was success
                //Finalize USB relay device library for clearing resources. 
                //If you need total control, you can process the return value of this function.
                UsbRelayDevice.usb_relay_finalize();
            }
        }


        private void buttonGetRelay_Click(object sender, EventArgs e)
        {
            //Get device serial number
            RelaySerial = UsbRelayDevice.usb_relay_device_enumerate().serial_number;
        }

        /// <summary>
        /// Open single relay channel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            //To simplify the example, write the code in the button click handler. Sorry for a bad code style.

            //Check serial number existing
            if (SerialExist)
            {
                //Open device by serial number and get device handle 
                int deviceHandle = UsbRelayDevice.usb_relay_device_open_with_serial_number(RelaySerial, RelaySerial.Length);
                    
                //Try to open relay device channel specified in propety "RelayChannel"
                int openResult = UsbRelayDevice.usb_relay_device_open_one_relay_channel(deviceHandle, RelayChannel);

                //Show result
                if (openResult == 0) MessageBox.Show(string.Format("USB relay channel {0} is opened.", RelayChannel));
                else if (openResult == 1) MessageBox.Show("Error!");
                else if (openResult == 2) MessageBox.Show(string.Format("USB relay doesn't contains channel {0}.", RelayChannel));
                    
                //Close USB relay device. 
                UsbRelayDevice.usb_relay_device_close(deviceHandle);
            }
            else MessageBox.Show("Get serial number first!");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (SerialExist)
            {           
                int deviceHandle = UsbRelayDevice.usb_relay_device_open_with_serial_number(RelaySerial, RelaySerial.Length);

                //Try to close relay device channel specified in propety "RelayChannel"
                int closeResult = UsbRelayDevice.usb_relay_device_close_one_relay_channel(deviceHandle, RelayChannel);

                if (closeResult == 0) MessageBox.Show(string.Format("USB relay channel {0} is closed.", RelayChannel));
                else if (closeResult == 1) MessageBox.Show("Error!");
                else if (closeResult == 2) MessageBox.Show(string.Format("USB relay doesn't contains channel {0}.", RelayChannel));
                UsbRelayDevice.usb_relay_device_close(deviceHandle);
            }
            else MessageBox.Show("Get serial number first!");
        }

        private void buttonStatus_Click(object sender, EventArgs e)
        {
            //Get status of channel entered in numericUpDown component
            if (SerialExist) 
            {           
                int deviceHandle = UsbRelayDevice.usb_relay_device_open_with_serial_number(RelaySerial, RelaySerial.Length);                 
                //Create variable  for returnable value
                int result;

                //Get device channel status
                int openResult = UsbRelayDevice.GetStatus(deviceHandle, out result);
                //Create bits array from result
                BitArray ba = new BitArray(new int[] { result });

                if (openResult == 0)
                {
                    //Show device channel status
                    if (ba[RelayChannel - 1])
                        MessageBox.Show(string.Format("USB relay channel {0} status is ON.", RelayChannel));
                    else MessageBox.Show(string.Format("USB relay channel {0} status is OFF.", RelayChannel));
                }
                else if (openResult == 1) MessageBox.Show("Error!");
                UsbRelayDevice.usb_relay_device_close(deviceHandle);
            }
            else MessageBox.Show("Get serial number first!");
        }

        private void buttonOpenAll_Click(object sender, EventArgs e)
        {
            if (SerialExist)
            {        
                int deviceHandle = UsbRelayDevice.usb_relay_device_open_with_serial_number(RelaySerial, RelaySerial.Length);

                //Open all channels
                int openResult = UsbRelayDevice.usb_relay_device_open_all_relay_channel(deviceHandle);

                if (openResult == 0) MessageBox.Show("All channels are opened.");
                else if (openResult == 1) MessageBox.Show("Error!");
                UsbRelayDevice.usb_relay_device_close(deviceHandle);
            }
            else MessageBox.Show("Get serial number first!");
        }

        private void buttonCloseAll_Click(object sender, EventArgs e)
        {
            if (SerialExist)
            {
                int deviceHandle = UsbRelayDevice.usb_relay_device_open_with_serial_number(RelaySerial, RelaySerial.Length);

                //Close all channels
                int closeResult = UsbRelayDevice.usb_relay_device_close_all_relay_channel(deviceHandle);

                if (closeResult == 0) MessageBox.Show("All channels are closed.");
                else if (closeResult == 1) MessageBox.Show("Error!");
                UsbRelayDevice.usb_relay_device_close(deviceHandle);
            }
            else MessageBox.Show("Get serial number first!");
        }

        private void buttonDevType_Click(object sender, EventArgs e)
        {
            //Get device info
            Usb_relay_device_info devInfo = UsbRelayDevice.usb_relay_device_enumerate();
            if (devInfo.channel_quantity > 0) MessageBox.Show(string.Format("This is {0} chanel device.", devInfo.channel_quantity));
            else MessageBox.Show("The device is not connected");
        }

        
    }
}
