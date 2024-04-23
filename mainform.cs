using SecuGen.FDxSDKPro.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace sgdm
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>

        private SGFingerPrintManager m_FPM;

        private bool m_LedOn = false;
        private Int32 m_ImageWidth;
        private Int32 m_ImageHeight;
        private Byte[] m_RegMin1;
        private Byte[] m_RegMin2;
        private Byte[] m_RegMin3;
        private Byte[] m_RegMin4;
        private Byte[] m_RegMin5;
        private Byte[] m_RegMin6;
        private Byte[] fp_image1;
        private Byte[] fp_image2;
        private Byte[] imageV1;
        private Byte[] profilepic;



        private Byte[] m_VrfMin;
        private Byte[] m_VrfMin1;
        private Byte[] m_VrfMin2;
        private SGFPMDeviceList[] m_DevList; // Used for EnumerateDevice

        private System.ComponentModel.Container components = null;
        private GroupBox groupBoxUsbDevs;
        private Button OpenDeviceBtn;
        private Button EnumerateBtn;
        private Label label1;
        private ComboBox comboBoxDeviceName;
        private GroupBox groupBoxSda;
        private Label label2;
        private ComboBox comboBoxComPorts;
        private Button OpenSdaBtn;
        private System.Windows.Forms.Label StatusBar;
        private TabPage tabPage1;
        private Button GetBtn;
        private GroupBox groupBox3;
        private TextBox textImageDPI;
        private TextBox textImageHeight;
        private TextBox textImageWidth;
        private TextBox textSerialNum;
        private TextBox textFWVersion;
        private TextBox textDeviceID;
        private TextBox textBrightness;
        private TextBox textGain;
        private TextBox textContrast;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label13;
        private TabPage tabPage3;
        private Button BtnVerify;
        private GroupBox groupBox6;
        private ComboBox comboBoxSecuLevel_V;
        private Label label14;
        private GroupBox groupBox2;
        private ProgressBar progressBar_V1;
        private PictureBox pictureBoxV1;
        private Button Verifybtn;
        private ComboBox comboBox1;
        private TabControl tbUserVerify;
        private ComboBox comboBox3;
        private Button btnUverifyV;
        private PictureBox pbUverifyV;
        private ProgressBar pbUverifyV1;
        private TabPage tabPage9;
        private TabPage tabPage8;
        private PictureBox pictureBox3;
        private TextBox textImgQuality;
        private Label label15;
        private Label label16;
        private TextBox textTimeout;
        internal Button SetBrightnessBtn;
        internal NumericUpDown BrightnessUpDown;
        private Button btnUCap2;
        private Button btnUCap1;
        private PictureBox UserpictureBox2;
        private PictureBox userPictureBox1;
        private ProgressBar UserprogressBar2;
        private ProgressBar UserprogressBar1;
        private ComboBox comboBox2;
        private Button btnV1;
        private PictureBox pictureBox4;
        private ProgressBar UserverifyBar;
        private TabPage tabPage6;
        private TabPage tabPage5;
        private PictureBox pictureBox2;
        private Button btnClear;
        private Label label4;
        private Label label24;
        private Label label25;
        private GroupBox grpVerifybox;
        private TextBox Regverify;
        private TextBox verifyPassport;
        private DateTimePicker dateTimePicker1;
        private PictureBox propicbox;
        Object Identity = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.StatusBar = new System.Windows.Forms.Label();
            this.groupBoxUsbDevs = new System.Windows.Forms.GroupBox();
            this.OpenDeviceBtn = new System.Windows.Forms.Button();
            this.EnumerateBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDeviceName = new System.Windows.Forms.ComboBox();
            this.groupBoxSda = new System.Windows.Forms.GroupBox();
            this.OpenSdaBtn = new System.Windows.Forms.Button();
            this.comboBoxComPorts = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.GetBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textImageDPI = new System.Windows.Forms.TextBox();
            this.textImageHeight = new System.Windows.Forms.TextBox();
            this.textImageWidth = new System.Windows.Forms.TextBox();
            this.textSerialNum = new System.Windows.Forms.TextBox();
            this.textFWVersion = new System.Windows.Forms.TextBox();
            this.textDeviceID = new System.Windows.Forms.TextBox();
            this.textBrightness = new System.Windows.Forms.TextBox();
            this.textGain = new System.Windows.Forms.TextBox();
            this.textContrast = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnClear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.grpVerifybox = new System.Windows.Forms.GroupBox();
            this.Regverify = new System.Windows.Forms.TextBox();
            this.verifyPassport = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.BtnVerify = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.comboBoxSecuLevel_V = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.progressBar_V1 = new System.Windows.Forms.ProgressBar();
            this.pictureBoxV1 = new System.Windows.Forms.PictureBox();
            this.Verifybtn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tbUserVerify = new System.Windows.Forms.TabControl();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.btnUverifyV = new System.Windows.Forms.Button();
            this.pbUverifyV = new System.Windows.Forms.PictureBox();
            this.pbUverifyV1 = new System.Windows.Forms.ProgressBar();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.textImgQuality = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textTimeout = new System.Windows.Forms.TextBox();
            this.SetBrightnessBtn = new System.Windows.Forms.Button();
            this.BrightnessUpDown = new System.Windows.Forms.NumericUpDown();
            this.btnUCap2 = new System.Windows.Forms.Button();
            this.btnUCap1 = new System.Windows.Forms.Button();
            this.UserpictureBox2 = new System.Windows.Forms.PictureBox();
            this.userPictureBox1 = new System.Windows.Forms.PictureBox();
            this.UserprogressBar2 = new System.Windows.Forms.ProgressBar();
            this.UserprogressBar1 = new System.Windows.Forms.ProgressBar();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btnV1 = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.UserverifyBar = new System.Windows.Forms.ProgressBar();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.propicbox = new System.Windows.Forms.PictureBox();
            this.groupBoxUsbDevs.SuspendLayout();
            this.groupBoxSda.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.grpVerifybox.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxV1)).BeginInit();
            this.tbUserVerify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUverifyV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserpictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.propicbox)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusBar
            // 
            this.StatusBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.StatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StatusBar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.StatusBar.Location = new System.Drawing.Point(0, 816);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(841, 27);
            this.StatusBar.TabIndex = 7;
            this.StatusBar.Text = "Click Init Button";
            // 
            // groupBoxUsbDevs
            // 
            this.groupBoxUsbDevs.Controls.Add(this.OpenDeviceBtn);
            this.groupBoxUsbDevs.Controls.Add(this.EnumerateBtn);
            this.groupBoxUsbDevs.Controls.Add(this.label1);
            this.groupBoxUsbDevs.Controls.Add(this.comboBoxDeviceName);
            this.groupBoxUsbDevs.Location = new System.Drawing.Point(5, 2);
            this.groupBoxUsbDevs.Name = "groupBoxUsbDevs";
            this.groupBoxUsbDevs.Size = new System.Drawing.Size(497, 66);
            this.groupBoxUsbDevs.TabIndex = 10;
            this.groupBoxUsbDevs.TabStop = false;
            this.groupBoxUsbDevs.Text = "USB";
            // 
            // OpenDeviceBtn
            // 
            this.OpenDeviceBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.OpenDeviceBtn.Location = new System.Drawing.Point(294, 22);
            this.OpenDeviceBtn.Name = "OpenDeviceBtn";
            this.OpenDeviceBtn.Size = new System.Drawing.Size(86, 28);
            this.OpenDeviceBtn.TabIndex = 13;
            this.OpenDeviceBtn.Text = "Init";
            this.OpenDeviceBtn.UseVisualStyleBackColor = false;
            this.OpenDeviceBtn.Click += new System.EventHandler(this.OpenDeviceBtn_Click);
            // 
            // EnumerateBtn
            // 
            this.EnumerateBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.EnumerateBtn.Location = new System.Drawing.Point(395, 22);
            this.EnumerateBtn.Name = "EnumerateBtn";
            this.EnumerateBtn.Size = new System.Drawing.Size(86, 28);
            this.EnumerateBtn.TabIndex = 12;
            this.EnumerateBtn.Text = "Enumerate";
            this.EnumerateBtn.UseVisualStyleBackColor = false;
            this.EnumerateBtn.Click += new System.EventHandler(this.EnumerateBtn_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 28);
            this.label1.TabIndex = 11;
            this.label1.Text = "Device Name";
            // 
            // comboBoxDeviceName
            // 
            this.comboBoxDeviceName.Location = new System.Drawing.Point(97, 22);
            this.comboBoxDeviceName.Name = "comboBoxDeviceName";
            this.comboBoxDeviceName.Size = new System.Drawing.Size(183, 24);
            this.comboBoxDeviceName.TabIndex = 10;
            // 
            // groupBoxSda
            // 
            this.groupBoxSda.Controls.Add(this.OpenSdaBtn);
            this.groupBoxSda.Controls.Add(this.comboBoxComPorts);
            this.groupBoxSda.Controls.Add(this.label2);
            this.groupBoxSda.Location = new System.Drawing.Point(5, 76);
            this.groupBoxSda.Name = "groupBoxSda";
            this.groupBoxSda.Size = new System.Drawing.Size(497, 60);
            this.groupBoxSda.TabIndex = 11;
            this.groupBoxSda.TabStop = false;
            this.groupBoxSda.Text = "SDA-Serial";
            // 
            // OpenSdaBtn
            // 
            this.OpenSdaBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.OpenSdaBtn.Location = new System.Drawing.Point(294, 22);
            this.OpenSdaBtn.Name = "OpenSdaBtn";
            this.OpenSdaBtn.Size = new System.Drawing.Size(86, 28);
            this.OpenSdaBtn.TabIndex = 14;
            this.OpenSdaBtn.Text = "Init";
            this.OpenSdaBtn.UseVisualStyleBackColor = false;
            this.OpenSdaBtn.Click += new System.EventHandler(this.OpenSdaBtn_Click);
            // 
            // comboBoxComPorts
            // 
            this.comboBoxComPorts.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9"});
            this.comboBoxComPorts.Location = new System.Drawing.Point(97, 21);
            this.comboBoxComPorts.Name = "comboBoxComPorts";
            this.comboBoxComPorts.Size = new System.Drawing.Size(183, 24);
            this.comboBoxComPorts.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Port";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.GetBtn);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(760, 615);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DeviceInfo";
            // 
            // GetBtn
            // 
            this.GetBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.GetBtn.Location = new System.Drawing.Point(346, 18);
            this.GetBtn.Name = "GetBtn";
            this.GetBtn.Size = new System.Drawing.Size(115, 28);
            this.GetBtn.TabIndex = 43;
            this.GetBtn.Text = "Get";
            this.GetBtn.UseVisualStyleBackColor = false;
            this.GetBtn.Click += new System.EventHandler(this.GetBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textImageDPI);
            this.groupBox3.Controls.Add(this.textImageHeight);
            this.groupBox3.Controls.Add(this.textImageWidth);
            this.groupBox3.Controls.Add(this.textSerialNum);
            this.groupBox3.Controls.Add(this.textFWVersion);
            this.groupBox3.Controls.Add(this.textDeviceID);
            this.groupBox3.Controls.Add(this.textBrightness);
            this.groupBox3.Controls.Add(this.textGain);
            this.groupBox3.Controls.Add(this.textContrast);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Location = new System.Drawing.Point(10, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(316, 286);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DeviceInfo";
            // 
            // textImageDPI
            // 
            this.textImageDPI.Enabled = false;
            this.textImageDPI.Location = new System.Drawing.Point(115, 166);
            this.textImageDPI.Name = "textImageDPI";
            this.textImageDPI.Size = new System.Drawing.Size(183, 22);
            this.textImageDPI.TabIndex = 66;
            // 
            // textImageHeight
            // 
            this.textImageHeight.Enabled = false;
            this.textImageHeight.Location = new System.Drawing.Point(115, 138);
            this.textImageHeight.Name = "textImageHeight";
            this.textImageHeight.Size = new System.Drawing.Size(183, 22);
            this.textImageHeight.TabIndex = 65;
            // 
            // textImageWidth
            // 
            this.textImageWidth.Enabled = false;
            this.textImageWidth.Location = new System.Drawing.Point(115, 111);
            this.textImageWidth.Name = "textImageWidth";
            this.textImageWidth.Size = new System.Drawing.Size(183, 22);
            this.textImageWidth.TabIndex = 64;
            // 
            // textSerialNum
            // 
            this.textSerialNum.Enabled = false;
            this.textSerialNum.Location = new System.Drawing.Point(115, 83);
            this.textSerialNum.Name = "textSerialNum";
            this.textSerialNum.Size = new System.Drawing.Size(183, 22);
            this.textSerialNum.TabIndex = 63;
            // 
            // textFWVersion
            // 
            this.textFWVersion.Enabled = false;
            this.textFWVersion.Location = new System.Drawing.Point(115, 55);
            this.textFWVersion.Name = "textFWVersion";
            this.textFWVersion.Size = new System.Drawing.Size(183, 22);
            this.textFWVersion.TabIndex = 62;
            // 
            // textDeviceID
            // 
            this.textDeviceID.Enabled = false;
            this.textDeviceID.Location = new System.Drawing.Point(115, 28);
            this.textDeviceID.Name = "textDeviceID";
            this.textDeviceID.Size = new System.Drawing.Size(183, 22);
            this.textDeviceID.TabIndex = 61;
            // 
            // textBrightness
            // 
            this.textBrightness.Enabled = false;
            this.textBrightness.Location = new System.Drawing.Point(115, 194);
            this.textBrightness.Name = "textBrightness";
            this.textBrightness.Size = new System.Drawing.Size(183, 22);
            this.textBrightness.TabIndex = 58;
            // 
            // textGain
            // 
            this.textGain.Enabled = false;
            this.textGain.Location = new System.Drawing.Point(115, 249);
            this.textGain.Name = "textGain";
            this.textGain.Size = new System.Drawing.Size(183, 22);
            this.textGain.TabIndex = 57;
            // 
            // textContrast
            // 
            this.textContrast.Enabled = false;
            this.textContrast.Location = new System.Drawing.Point(115, 222);
            this.textContrast.Name = "textContrast";
            this.textContrast.Size = new System.Drawing.Size(183, 22);
            this.textContrast.TabIndex = 56;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(19, 249);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 19);
            this.label12.TabIndex = 55;
            this.label12.Text = "Gain";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(19, 222);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 18);
            this.label11.TabIndex = 54;
            this.label11.Text = "Contrast";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(19, 194);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 18);
            this.label10.TabIndex = 53;
            this.label10.Text = "Brightness";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(19, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 19);
            this.label9.TabIndex = 51;
            this.label9.Text = "Image DPI";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(19, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 19);
            this.label8.TabIndex = 49;
            this.label8.Text = "Serial #";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(19, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 19);
            this.label7.TabIndex = 47;
            this.label7.Text = "F/W Version";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(19, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 19);
            this.label6.TabIndex = 45;
            this.label6.Text = "Image Height";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(19, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 18);
            this.label5.TabIndex = 43;
            this.label5.Text = "Image Width";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(19, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 18);
            this.label13.TabIndex = 41;
            this.label13.Text = "Device ID";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnClear);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label24);
            this.tabPage3.Controls.Add(this.label25);
            this.tabPage3.Controls.Add(this.grpVerifybox);
            this.tabPage3.Controls.Add(this.Regverify);
            this.tabPage3.Controls.Add(this.verifyPassport);
            this.tabPage3.Controls.Add(this.dateTimePicker1);
            this.tabPage3.Controls.Add(this.BtnVerify);
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(760, 615);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Register/Verify";
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(569, 375);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(114, 29);
            this.btnClear.TabIndex = 71;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 16);
            this.label4.TabIndex = 70;
            this.label4.Text = "Reg";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(60, 140);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(82, 16);
            this.label24.TabIndex = 69;
            this.label24.Text = "Passport No";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(61, 190);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(36, 16);
            this.label25.TabIndex = 68;
            this.label25.Text = "Date";
            // 
            // grpVerifybox
            // 
            this.grpVerifybox.Controls.Add(this.propicbox);
            this.grpVerifybox.Location = new System.Drawing.Point(537, 32);
            this.grpVerifybox.Name = "grpVerifybox";
            this.grpVerifybox.Size = new System.Drawing.Size(163, 205);
            this.grpVerifybox.TabIndex = 66;
            this.grpVerifybox.TabStop = false;
            // 
            // Regverify
            // 
            this.Regverify.Location = new System.Drawing.Point(188, 83);
            this.Regverify.Name = "Regverify";
            this.Regverify.ReadOnly = true;
            this.Regverify.Size = new System.Drawing.Size(281, 22);
            this.Regverify.TabIndex = 65;
            // 
            // verifyPassport
            // 
            this.verifyPassport.Location = new System.Drawing.Point(188, 134);
            this.verifyPassport.Name = "verifyPassport";
            this.verifyPassport.ReadOnly = true;
            this.verifyPassport.Size = new System.Drawing.Size(281, 22);
            this.verifyPassport.TabIndex = 63;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(188, 190);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(281, 22);
            this.dateTimePicker1.TabIndex = 64;
            // 
            // BtnVerify
            // 
            this.BtnVerify.BackColor = System.Drawing.SystemColors.Desktop;
            this.BtnVerify.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.BtnVerify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnVerify.Location = new System.Drawing.Point(324, 375);
            this.BtnVerify.Name = "BtnVerify";
            this.BtnVerify.Size = new System.Drawing.Size(130, 27);
            this.BtnVerify.TabIndex = 34;
            this.BtnVerify.Text = "Verify";
            this.BtnVerify.UseVisualStyleBackColor = false;
            this.BtnVerify.Click += new System.EventHandler(this.BtnVerify_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.comboBoxSecuLevel_V);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Location = new System.Drawing.Point(10, 9);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(249, 65);
            this.groupBox6.TabIndex = 30;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Security Level";
            // 
            // comboBoxSecuLevel_V
            // 
            this.comboBoxSecuLevel_V.Items.AddRange(new object[] {
            "LOWEST",
            "LOWER",
            "LOW",
            "BELOW_NORMAL",
            "NORMAL",
            "ABOVE_NORMAL",
            "HIGH",
            "HIGHER",
            "HIGHEST"});
            this.comboBoxSecuLevel_V.Location = new System.Drawing.Point(93, 28);
            this.comboBoxSecuLevel_V.Name = "comboBoxSecuLevel_V";
            this.comboBoxSecuLevel_V.Size = new System.Drawing.Size(135, 24);
            this.comboBoxSecuLevel_V.TabIndex = 24;
            this.comboBoxSecuLevel_V.Text = "NORMAL";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(17, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 27);
            this.label14.TabIndex = 23;
            this.label14.Text = "Verification";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.progressBar_V1);
            this.groupBox2.Controls.Add(this.pictureBoxV1);
            this.groupBox2.Controls.Add(this.Verifybtn);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Location = new System.Drawing.Point(78, 261);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 254);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Verification";
            // 
            // progressBar_V1
            // 
            this.progressBar_V1.Location = new System.Drawing.Point(19, 175);
            this.progressBar_V1.Name = "progressBar_V1";
            this.progressBar_V1.Size = new System.Drawing.Size(125, 14);
            this.progressBar_V1.TabIndex = 31;
            // 
            // pictureBoxV1
            // 
            this.pictureBoxV1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxV1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxV1.Location = new System.Drawing.Point(19, 28);
            this.pictureBoxV1.Name = "pictureBoxV1";
            this.pictureBoxV1.Size = new System.Drawing.Size(125, 147);
            this.pictureBoxV1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxV1.TabIndex = 29;
            this.pictureBoxV1.TabStop = false;
            // 
            // Verifybtn
            // 
            this.Verifybtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Verifybtn.Location = new System.Drawing.Point(19, 203);
            this.Verifybtn.Name = "Verifybtn";
            this.Verifybtn.Size = new System.Drawing.Size(125, 27);
            this.Verifybtn.TabIndex = 27;
            this.Verifybtn.Text = "Capture V1";
            this.Verifybtn.UseVisualStyleBackColor = false;
            this.Verifybtn.Click += new System.EventHandler(this.BtnCapture3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Items.AddRange(new object[] {
            "LOWEST",
            "LOWER",
            "LOW",
            "BELOW_NORMAL",
            "NORMAL",
            "ABOVE_NORMAL",
            "HIGH",
            "HIGHER",
            "HIGHEST"});
            this.comboBox1.Location = new System.Drawing.Point(58, -46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(105, 24);
            this.comboBox1.TabIndex = 30;
            this.comboBox1.Text = "NORMAL";
            // 
            // tbUserVerify
            // 
            this.tbUserVerify.Controls.Add(this.tabPage3);
            this.tbUserVerify.Controls.Add(this.tabPage1);
            this.tbUserVerify.HotTrack = true;
            this.tbUserVerify.Location = new System.Drawing.Point(5, 143);
            this.tbUserVerify.Name = "tbUserVerify";
            this.tbUserVerify.SelectedIndex = 0;
            this.tbUserVerify.Size = new System.Drawing.Size(768, 644);
            this.tbUserVerify.TabIndex = 0;
            // 
            // comboBox3
            // 
            this.comboBox3.Items.AddRange(new object[] {
            "LOWEST",
            "LOWER",
            "LOW",
            "BELOW_NORMAL",
            "NORMAL",
            "ABOVE_NORMAL",
            "HIGH",
            "HIGHER",
            "HIGHEST"});
            this.comboBox3.Location = new System.Drawing.Point(58, -46);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(105, 24);
            this.comboBox3.TabIndex = 30;
            // 
            // btnUverifyV
            // 
            this.btnUverifyV.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnUverifyV.Location = new System.Drawing.Point(19, 203);
            this.btnUverifyV.Name = "btnUverifyV";
            this.btnUverifyV.Size = new System.Drawing.Size(125, 27);
            this.btnUverifyV.TabIndex = 27;
            this.btnUverifyV.Text = "Capture V1";
            this.btnUverifyV.UseVisualStyleBackColor = false;
            this.btnUverifyV.Click += new System.EventHandler(this.btnUverifyV_Click);
            // 
            // pbUverifyV
            // 
            this.pbUverifyV.BackColor = System.Drawing.SystemColors.Window;
            this.pbUverifyV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbUverifyV.Location = new System.Drawing.Point(19, 28);
            this.pbUverifyV.Name = "pbUverifyV";
            this.pbUverifyV.Size = new System.Drawing.Size(125, 147);
            this.pbUverifyV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUverifyV.TabIndex = 29;
            this.pbUverifyV.TabStop = false;
            // 
            // pbUverifyV1
            // 
            this.pbUverifyV1.Location = new System.Drawing.Point(19, 175);
            this.pbUverifyV1.Name = "pbUverifyV1";
            this.pbUverifyV1.Size = new System.Drawing.Size(125, 14);
            this.pbUverifyV1.TabIndex = 31;
            // 
            // tabPage9
            // 
            this.tabPage9.Location = new System.Drawing.Point(4, 25);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(0, 0);
            this.tabPage9.TabIndex = 1;
            this.tabPage9.Text = "tabPage9";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 25);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(0, 0);
            this.tabPage8.TabIndex = 0;
            this.tabPage8.Text = "tabPage8";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Location = new System.Drawing.Point(3, 18);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(157, 184);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 42;
            this.pictureBox3.TabStop = false;
            // 
            // textImgQuality
            // 
            this.textImgQuality.Location = new System.Drawing.Point(10, 42);
            this.textImgQuality.MaxLength = 3;
            this.textImgQuality.Name = "textImgQuality";
            this.textImgQuality.Size = new System.Drawing.Size(105, 22);
            this.textImgQuality.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(10, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 19);
            this.label15.TabIndex = 16;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(10, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(115, 28);
            this.label16.TabIndex = 17;
            // 
            // textTimeout
            // 
            this.textTimeout.Location = new System.Drawing.Point(10, 92);
            this.textTimeout.Name = "textTimeout";
            this.textTimeout.Size = new System.Drawing.Size(105, 22);
            this.textTimeout.TabIndex = 18;
            // 
            // SetBrightnessBtn
            // 
            this.SetBrightnessBtn.Location = new System.Drawing.Point(67, 28);
            this.SetBrightnessBtn.Name = "SetBrightnessBtn";
            this.SetBrightnessBtn.Size = new System.Drawing.Size(67, 23);
            this.SetBrightnessBtn.TabIndex = 19;
            this.SetBrightnessBtn.Text = "Apply";
            this.SetBrightnessBtn.Click += new System.EventHandler(this.SetBrightnessBtn_Click);
            // 
            // BrightnessUpDown
            // 
            this.BrightnessUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.BrightnessUpDown.Location = new System.Drawing.Point(10, 28);
            this.BrightnessUpDown.Name = "BrightnessUpDown";
            this.BrightnessUpDown.Size = new System.Drawing.Size(52, 22);
            this.BrightnessUpDown.TabIndex = 20;
            this.BrightnessUpDown.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // btnUCap2
            // 
            this.btnUCap2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnUCap2.Location = new System.Drawing.Point(154, 203);
            this.btnUCap2.Name = "btnUCap2";
            this.btnUCap2.Size = new System.Drawing.Size(124, 27);
            this.btnUCap2.TabIndex = 24;
            this.btnUCap2.Text = "Capture 2";
            this.btnUCap2.UseVisualStyleBackColor = false;
            this.btnUCap2.Click += new System.EventHandler(this.btnUCap2_Click);
            // 
            // btnUCap1
            // 
            this.btnUCap1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnUCap1.Location = new System.Drawing.Point(10, 203);
            this.btnUCap1.Name = "btnUCap1";
            this.btnUCap1.Size = new System.Drawing.Size(124, 27);
            this.btnUCap1.TabIndex = 23;
            this.btnUCap1.Text = "Capture 1";
            this.btnUCap1.UseVisualStyleBackColor = false;
            this.btnUCap1.Click += new System.EventHandler(this.btnUCap1_Click);
            // 
            // UserpictureBox2
            // 
            this.UserpictureBox2.BackColor = System.Drawing.SystemColors.Window;
            this.UserpictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.UserpictureBox2.Location = new System.Drawing.Point(10, 28);
            this.UserpictureBox2.Name = "UserpictureBox2";
            this.UserpictureBox2.Size = new System.Drawing.Size(124, 147);
            this.UserpictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UserpictureBox2.TabIndex = 26;
            this.UserpictureBox2.TabStop = false;
            // 
            // userPictureBox1
            // 
            this.userPictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.userPictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.userPictureBox1.Location = new System.Drawing.Point(154, 28);
            this.userPictureBox1.Name = "userPictureBox1";
            this.userPictureBox1.Size = new System.Drawing.Size(124, 147);
            this.userPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userPictureBox1.TabIndex = 27;
            this.userPictureBox1.TabStop = false;
            // 
            // UserprogressBar2
            // 
            this.UserprogressBar2.Location = new System.Drawing.Point(10, 175);
            this.UserprogressBar2.Name = "UserprogressBar2";
            this.UserprogressBar2.Size = new System.Drawing.Size(124, 14);
            this.UserprogressBar2.TabIndex = 28;
            // 
            // UserprogressBar1
            // 
            this.UserprogressBar1.Location = new System.Drawing.Point(154, 175);
            this.UserprogressBar1.Name = "UserprogressBar1";
            this.UserprogressBar1.Size = new System.Drawing.Size(124, 14);
            this.UserprogressBar1.TabIndex = 29;
            // 
            // comboBox2
            // 
            this.comboBox2.Items.AddRange(new object[] {
            "LOWEST",
            "LOWER",
            "LOW",
            "BELOW_NORMAL",
            "NORMAL",
            "ABOVE_NORMAL",
            "HIGH",
            "HIGHER",
            "HIGHEST"});
            this.comboBox2.Location = new System.Drawing.Point(58, -46);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(105, 24);
            this.comboBox2.TabIndex = 30;
            // 
            // btnV1
            // 
            this.btnV1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnV1.Location = new System.Drawing.Point(19, 203);
            this.btnV1.Name = "btnV1";
            this.btnV1.Size = new System.Drawing.Size(125, 27);
            this.btnV1.TabIndex = 27;
            this.btnV1.Text = "Capture V1";
            this.btnV1.UseVisualStyleBackColor = false;
            this.btnV1.Click += new System.EventHandler(this.btnV1_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox4.Location = new System.Drawing.Point(19, 28);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(125, 147);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 29;
            this.pictureBox4.TabStop = false;
            // 
            // UserverifyBar
            // 
            this.UserverifyBar.Location = new System.Drawing.Point(19, 175);
            this.UserverifyBar.Name = "UserverifyBar";
            this.UserverifyBar.Size = new System.Drawing.Size(125, 14);
            this.UserverifyBar.TabIndex = 31;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(0, 0);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(0, 0);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(3, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(157, 184);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 42;
            this.pictureBox2.TabStop = false;
            // 
            // propicbox
            // 
            this.propicbox.BackColor = System.Drawing.SystemColors.Window;
            this.propicbox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.propicbox.Location = new System.Drawing.Point(6, 5);
            this.propicbox.Name = "propicbox";
            this.propicbox.Size = new System.Drawing.Size(151, 194);
            this.propicbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.propicbox.TabIndex = 30;
            this.propicbox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(841, 843);
            this.Controls.Add(this.groupBoxSda);
            this.Controls.Add(this.groupBoxUsbDevs);
            this.Controls.Add(this.tbUserVerify);
            this.Controls.Add(this.StatusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "FP Scanner";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBoxUsbDevs.ResumeLayout(false);
            this.groupBoxSda.ResumeLayout(false);
            this.groupBoxSda.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.grpVerifybox.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxV1)).EndInit();
            this.tbUserVerify.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUverifyV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserpictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.propicbox)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new MainForm());
        }

        ///////////////////////
        /// Create SGFingerPrintManager Object
        /// new SGFingerPrintManager()
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            m_LedOn = false;

            m_RegMin1 = new Byte[400];
            m_RegMin2 = new Byte[400];
            m_VrfMin = new Byte[400];
            m_RegMin3 = new Byte[400];
            m_RegMin4 = new Byte[400];
            m_VrfMin1 = new Byte[400];
            m_RegMin5 = new Byte[400];
            m_RegMin6 = new Byte[400];
            m_VrfMin2 = new Byte[400];


            //comboBoxSecuLevel_R.SelectedIndex = 4;
            comboBoxSecuLevel_V.SelectedIndex = 3;
            comboBoxComPorts.SelectedIndex = 5;    // com6

            EnableButtons(false);

            m_FPM = new SGFingerPrintManager();
            EnumerateBtn_Click(sender, e);
        }

        ///////////////////////
        /// EnumerateDevice(), GetEnumDeviceInfo()
        /// EnumerateDevice() can be called before Initializing SGFingerPrintManager
        private void EnumerateBtn_Click(object sender, System.EventArgs e)
        {
            Int32 iError;
            string enum_device;

            comboBoxDeviceName.Items.Clear();
            comboBoxDeviceName.ResetText();    // remove text as well

            // Enumerate Device
            iError = m_FPM.EnumerateDevice();

            // Get enumeration info into SGFPMDeviceList
            m_DevList = new SGFPMDeviceList[m_FPM.NumberOfDevice];

            for (int i = 0; i < m_FPM.NumberOfDevice; i++)
            {
                m_DevList[i] = new SGFPMDeviceList();
                m_FPM.GetEnumDeviceInfo(i, m_DevList[i]);
                enum_device = m_DevList[i].DevName.ToString() + " : " + m_DevList[i].DevID;
                comboBoxDeviceName.Items.Add(enum_device);
            }

            if (comboBoxDeviceName.Items.Count > 0)
            {
                // Add Auto Selection
                enum_device = "Auto Selection";
                comboBoxDeviceName.Items.Add(enum_device);

                comboBoxDeviceName.SelectedIndex = 0;  //First selected one
            }

        }


        ///////////////////////
        // Initialize SGFingerprint manage with device name
        // Init(), OpenDeice()
        private void OpenDeviceBtn_Click(object sender, System.EventArgs e)
        {
            if (m_FPM.NumberOfDevice == 0)
                return;

            SGFPMDeviceName device_name;
            Int32 device_id;

            Int32 numberOfDevices = comboBoxDeviceName.Items.Count;
            Int32 deviceSelected = comboBoxDeviceName.SelectedIndex;
            Boolean autoSelection = (deviceSelected == (numberOfDevices - 1));  // Last index

            if (autoSelection)
            {
                // Order of search: Hamster IV(HFDU04) -> Plus(HFDU03) -> III (HFDU02)
                device_name = SGFPMDeviceName.DEV_AUTO;

                device_id = (Int32)(SGFPMPortAddr.USB_AUTO_DETECT);
            }
            else
            {
                device_name = m_DevList[deviceSelected].DevName;
                device_id = m_DevList[deviceSelected].DevID;
            }

            Int32 iError = OpenDevice(device_name, device_id);

            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                //GroupBoxBrightness.Enabled = true;
                //ConfigBtn.Enabled = true;
            }

        }

        ///////////////////////
        /// Oepn SDA device throught comport
        private void OpenSdaBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SGFPMDeviceName device_name = SGFPMDeviceName.DEV_FDUSDA;
            Int32 port_no = comboBoxComPorts.SelectedIndex + 1;

            Int32 iError = OpenDevice(device_name, port_no);

            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                // These are not supported for SDA device
                //GroupBoxBrightness.Enabled = false;
                //ConfigBtn.Enabled = false;
            }

            Cursor.Current = Cursors.Default;
        }

        private Int32 OpenDevice(SGFPMDeviceName device_name, Int32 device_id)
        {
            Int32 iError = m_FPM.Init(device_name);
            iError = m_FPM.OpenDevice(device_id);

            //CheckBoxAutoOn.Enabled = false;
            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                //GetBtn_Click(sender, e);
                GetBtn_Click(null, null);
                StatusBar.Text = "Initialization Success";
                EnableButtons(true);

                // FDU03, FDU04 or higher
                //if (device_name >= SGFPMDeviceName.DEV_FDU03)
                    //CheckBoxAutoOn.Enabled = true;
            }
            else
                DisplayError("OpenDevice()", iError);
            return iError;
        }

        private void CloseDevice()
        {
            m_FPM.CloseDevice();
        }

        ///////////////////////
        /// SetLedOn()
        private void LedBtn_Click(object sender, System.EventArgs e)
        {
            m_LedOn = !m_LedOn;
            m_FPM.SetLedOn(m_LedOn);
        }

        ///////////////////////
        /// Configure()
        private void ConfigBtn_Click(object sender, System.EventArgs e)
        {
            m_FPM.Configure((int)this.Handle);
        }

        ///////////////////////
        /// GetImage()
        private void GetImageBtn_Click(object sender, System.EventArgs e)
        {
            Int32 iError;
            Int32 elap_time;
            Byte[] fp_image;

            Cursor.Current = Cursors.WaitCursor;

            elap_time = Environment.TickCount;
            fp_image = new Byte[m_ImageWidth * m_ImageHeight];

            iError = m_FPM.GetImage(fp_image);

            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                elap_time = Environment.TickCount - elap_time;
                //DrawImage(fp_image, pictureBox1);
                StatusBar.Text = "Capture Time : " + elap_time + " ms";
            }
            else
                DisplayError("GetImage()", iError);

            Cursor.Current = Cursors.Default;
        }


        ///////////////////////
        /// GetImageEx()
        //private void GetLiveImageBtn_Click(object sender, System.EventArgs e)
        //{
        //    Cursor.Current = Cursors.WaitCursor;

        //    Int32 iError;
        //    Int32 timeout;
        //    Int32 quality;
        //    Byte[] fp_image;
        //    Int32 elap_time;

        //    timeout = Convert.ToInt32(textTimeout.Text);
        //    quality = Convert.ToInt32(textImgQuality.Text);
        //    fp_image = new Byte[m_ImageWidth * m_ImageHeight];
        //    elap_time = Environment.TickCount;

        //    //iError = m_FPM.GetImageEx(fp_image, timeout, this.pictureBox1.Handle.ToInt32(), quality);

        //    if (iError == 0)
        //    {
        //        elap_time = Environment.TickCount - elap_time;
        //        StatusBar.Text = "Capture Time : " + elap_time + "millisec";
        //    }
        //    else
        //        DisplayError("GetLiveImageEx()", iError);

        //    Cursor.Current = Cursors.Default;
        //}

        public static class DatabaseConfig
        {
            public static SqlConnection GetSqlConnection()
            {
                string connectionString = ConfigurationManager.ConnectionStrings["FingerprintDbConnection"].ConnectionString;
                return new SqlConnection(connectionString);
            }
        }

        ///////////////////////
        /// GetImage(), GetImageQuality(), CreateTemplate
        private void BtnCapture1_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Int32 iError;
            Byte[] fp_image;
            Int32 img_qlty;

            fp_image = new Byte[m_ImageWidth * m_ImageHeight];
            img_qlty = 0;

            iError = m_FPM.GetImage(fp_image);

            m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_image, ref img_qlty);
            //progressBar_R1.Value = img_qlty;

            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                //DrawImage(fp_image, pictureBoxR1);
                iError = m_FPM.CreateTemplate(fp_image, m_RegMin1);

                if (iError == (Int32)SGFPMError.ERROR_NONE)
                    StatusBar.Text = "First image is captured";
                else
                    DisplayError("CreateTemplate()", iError);
            }
            else
                DisplayError("GetImage()", iError);

            Cursor.Current = Cursors.Default;
        }

        /// GetImage(), GetImageQuality(), CreateTemplate
        private void BtnCapture2_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Int32 iError;
            Byte[] fp_image;
            Int32 img_qlty;

            fp_image = new Byte[m_ImageWidth * m_ImageHeight];
            img_qlty = 0;

            iError = m_FPM.GetImage(fp_image);
            m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_image, ref img_qlty);
            //progressBar_R2.Value = img_qlty;

            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                //DrawImage(fp_image, pictureBoxR2);
                iError = m_FPM.CreateTemplate(fp_image, m_RegMin2);

                if (iError == (Int32)SGFPMError.ERROR_NONE)
                    StatusBar.Text = "Second image is captured";
                else
                    DisplayError("CreateTemplate()", iError);
            }
            else
                DisplayError("GetImage()", iError);

            Cursor.Current = Cursors.Default;
        }

        ///////////////////////
        /// GetImage(), GetImageQuality(), CreateTemplate
        private void BtnCapture3_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Int32 iError;
            Byte[] fp_image;
            Int32 img_qlty;

            fp_image = new Byte[m_ImageWidth * m_ImageHeight];
            img_qlty = 0;

            iError = m_FPM.GetImage(fp_image);

            m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_image, ref img_qlty);
            progressBar_V1.Value = img_qlty;

            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                DrawImage(fp_image, pictureBoxV1);
                iError = m_FPM.CreateTemplate(null, fp_image, m_VrfMin1);

                if (iError == (Int32)SGFPMError.ERROR_NONE)
                    StatusBar.Text = "Image for verification is captured";
                else
                    DisplayError("CreateTemplate()", iError);
            }
            else
                DisplayError("GetImage()", iError);

            Cursor.Current = Cursors.Default;
        }


        ///////////////////////
        /// MatchTemplate(), GetMatchingScore()
        private void BtnRegister_Click(object sender, System.EventArgs e)
        {
            Int32 iError;
            bool matched = false;
            Int32 match_score = 0;
            SGFPMSecurityLevel secu_level; //

            //secu_level = (SGFPMSecurityLevel)comboBoxSecuLevel_R.SelectedIndex;

            //iError = m_FPM.MatchTemplate(m_RegMin1, m_RegMin2, secu_level, ref matched);
            iError = m_FPM.GetMatchingScore(m_RegMin1, m_RegMin2, ref match_score);

            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                if (matched)
                    StatusBar.Text = "Registration Success, Matching Score: " + match_score;
                else
                    StatusBar.Text = "Registration Failed";
            }
            else
                DisplayError("GetMatchingScore()", iError);

        }

        ///////////////////////
        /// MatchTemplate(), GetMatchingScore()
        private void BtnVerify_Click(object sender, System.EventArgs e)
        {
            Int32 iError;
            //bool matched1 = false;
            //bool matched2 = false;
            SGFPMSecurityLevel secu_level;
            List<int> matchedAutoIDs = new List<int>();
            float highestMatchScore = 0.0f;

            secu_level = (SGFPMSecurityLevel)comboBoxSecuLevel_V.SelectedIndex;

            //iError = m_FPM.MatchTemplate(m_RegMin1, m_VrfMin, secu_level, ref matched1);
            //iError = m_FPM.MatchTemplate(m_RegMin2, m_VrfMin, secu_level, ref matched2);


            using (SqlConnection conn = DatabaseConfig.GetSqlConnection())
            {
                conn.Open();

                //string sqlQuery = "SELECT [AutoID], [image1],[image2],[regno],[name],[ppno],[entrydate],[profilepic] FROM [dbo].[FingerPrint]";
                string sqlQuery = "SELECT [AutoID], [image1],[image2],[regno],[name],[ppno],[entrydate],[profilepic] FROM [dbo].[FingerPrintN]";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int autoID = (int)reader["AutoID"];
                            byte[] image1Data = (byte[])reader["image1"];
                            string regno = reader["regno"].ToString();
                            string name = reader["name"].ToString();
                            string ppno = reader["ppno"].ToString();
                            DateTime dateTimeValue = (DateTime)reader["entrydate"];
                            byte[] profilepic = (byte[])reader["profilepic"];

                            //byte[] image1Data = (byte[])reader["image1"];

                            bool matched = false;
                            iError = m_FPM.CreateTemplate(image1Data, m_RegMin4);
                            //iError = m_FPM.GetMatchingScore(m_RegMin4, m_VrfMin2, ref match_score1);
                            iError = m_FPM.MatchTemplate(m_RegMin4, m_VrfMin1, secu_level, ref matched);

                            if (iError == (Int32)SGFPMError.ERROR_NONE && matched)
                            {
                                float matchScore = 1.0f;

                                if (matchScore > highestMatchScore)
                                {
                                    highestMatchScore = matchScore;
                                    matchedAutoIDs.Clear();
                                    matchedAutoIDs.Add(autoID);

                                    Regverify.Text = regno;
                                    //txtUVName.Text = name;
                                    verifyPassport.Text = ppno;
                                    //dtpUV.Value = dateTimeValue;
                                    propicbox.Image = ByteArrayToImage(profilepic);
                                    propicbox.SizeMode = PictureBoxSizeMode.Zoom;

                                    // Helper method to convert byte array to Image
                                    Image ByteArrayToImage(byte[] byteArrayIn)
                                    {
                                        if (byteArrayIn == null)
                                        {
                                            return null;
                                        }

                                        using (MemoryStream ms = new MemoryStream(byteArrayIn))
                                        {
                                            Image img = Image.FromStream(ms);

                                            // Set the size of the PictureBox to match the size of the image
                                            pictureBox3.Size = img.Size;

                                            return img;
                                        }
                                    }

                                }
                                else if (matchScore == highestMatchScore)
                                {
                                    matchedAutoIDs.Add(autoID);
                                }
                            }
                        }
                    }
                }
            }

            //    if (iError == (Int32)SGFPMError.ERROR_NONE)
            //{
            //    if (matched1 & matched2)
            //        StatusBar.Text = "Verification Success";
            //    else
            //        StatusBar.Text = "Verification Failed";
            //}
            //else
            //    DisplayError("MatchTemplate()", iError);
        }


        ///////////////////////
        /// GetDeviceInfo()
        private void GetBtn_Click(object sender, System.EventArgs e)
        {
            SGFPMDeviceInfoParam pInfo = new SGFPMDeviceInfoParam();
            Int32 iError = m_FPM.GetDeviceInfo(pInfo);

            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                m_ImageWidth = pInfo.ImageWidth;
                m_ImageHeight = pInfo.ImageHeight;

                textDeviceID.Text = Convert.ToString(pInfo.DeviceID);
                textImageDPI.Text = Convert.ToString(pInfo.ImageDPI);
                textFWVersion.Text = Convert.ToString(pInfo.FWVersion, 16);

                ASCIIEncoding encoding = new ASCIIEncoding();
                textSerialNum.Text = encoding.GetString(pInfo.DeviceSN);

                textImageHeight.Text = Convert.ToString(pInfo.ImageHeight);
                textImageWidth.Text = Convert.ToString(pInfo.ImageWidth);
                textBrightness.Text = Convert.ToString(pInfo.Brightness);
                textContrast.Text = Convert.ToString(pInfo.Contrast);
                textGain.Text = Convert.ToString(pInfo.Gain);

                BrightnessUpDown.Value = pInfo.Brightness;
            }
        }

        ///////////////////////
        private void SetBrightnessBtn_Click(object sender, System.EventArgs e)
        {
            Int32 iError;
            Int32 brightness;

            brightness = (int)BrightnessUpDown.Value;
            iError = m_FPM.SetBrightness(brightness);
            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                StatusBar.Text = "SetBrightness success";
                GetBtn_Click(sender, e);
            }
            else
                DisplayError("SetBrightness()", iError);

        }


        ///////////////////////
        private void CheckBoxAutoOn_CheckedChanged(object sender, System.EventArgs e)
        {
            //if (CheckBoxAutoOn.Checked)
            //    m_FPM.EnableAutoOnEvent(true, (int)this.Handle);
            //else
            //    m_FPM.EnableAutoOnEvent(false, 0);
        }

        ///////////////////////
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class LPDeviceInfoParam
        {
            public Int32 DeviceID;         // 0 - 9

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public Byte[] DeviceSN;         // Device Serial Number, Length of SN = 15, Total 16bytes    

            public Int32 ComPort;          // Parallel device=>PP address, USB device=>USB(0x3BC+1)
            public Int32 ComSpeed;         // Parallel device=>PP mode, USB device=>0 
            public Int32 ImageWidth;       // Image Width
            public Int32 ImageHeight;      // Image Height
            public Int32 Contrast;        // 0 ~ 100
            public Int32 Brightness;       // 0 ~ 100
            public Int32 Gain;             // Dependent on each device
            public Int32 ImageDPI;         // DPI
            public Int32 FWVersion;        // FWVersion
        }
        protected override void WndProc(ref Message message)
        {
            if (message.Msg == (int)SGFPMMessages.DEV_AUTOONEVENT)
            {
                if (message.WParam.ToInt32() == (Int32)SGFPMAutoOnEvent.FINGER_ON)
                {
                    LPDeviceInfoParam lparam = new LPDeviceInfoParam();
                    Marshal.PtrToStructure(message.LParam, lparam);

                    var serialNum = Encoding.ASCII.GetString(lparam.DeviceSN, 0, lparam.DeviceSN.Length);
                    StatusBar.Text = "Device Message: Finger On" + ", " + serialNum;

                }
                else if (message.WParam.ToInt32() == (Int32)SGFPMAutoOnEvent.FINGER_OFF)
                {
                    StatusBar.Text = "Device Message: Finger Off";
                }
            }
            base.WndProc(ref message);
        }

        ///////////////////////
        private void DrawImage(Byte[] imgData, PictureBox picBox)
        {
            int colorval;
            Bitmap bmp = new Bitmap(m_ImageWidth, m_ImageHeight);
            picBox.Image = (Image)bmp;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    colorval = (int)imgData[(j * m_ImageWidth) + i];
                    bmp.SetPixel(i, j, Color.FromArgb(colorval, colorval, colorval));
                }
            }
            picBox.Refresh();
        }

        ///////////////////////
        private void EnableButtons(bool enable)
        {
            //ConfigBtn.Enabled = enable;
            //GetImageBtn.Enabled = enable.
            //GetLiveImageBtn.Enabled = enable;
            Verifybtn.Enabled = enable;
            btnUCap1.Enabled = enable;
            btnUCap2.Enabled = enable;
            btnUverifyV.Enabled = enable;
            btnV1.Enabled = enable;
            //btnUserRegister.Enabled = enable;
            //btnUsergetVerified.Enabled = enable;
            //btnUserVerify.Enabled = enable;
            //btnprofilepic.Enabled = enable;
            //BtnCapture1.Enabled = enable;
            //BtnCapture2.Enabled = enable;
            //BtnCapture3.Enabled = enable;
            //BtnRegister.Enabled = enable;
            BtnVerify.Enabled = enable;
            GetBtn.Enabled = enable;
            SetBrightnessBtn.Enabled = enable;
        }

        ///////////////////////
        void DisplayError(string funcName, int iError)
        {
            string text = "";

            switch (iError)
            {
                case 0:                             //SGFDX_ERROR_NONE				= 0,
                    text = "Error none";
                    break;

                case 1:                             //SGFDX_ERROR_CREATION_FAILED	= 1,
                    text = "Can not create object";
                    break;

                case 2:                             //   SGFDX_ERROR_FUNCTION_FAILED	= 2,
                    text = "Function Failed";
                    break;

                case 3:                             //   SGFDX_ERROR_INVALID_PARAM	= 3,
                    text = "Invalid Parameter";
                    break;

                case 4:                          //   SGFDX_ERROR_NOT_USED			= 4,
                    text = "Not used function";
                    break;

                case 5:                                //SGFDX_ERROR_DLLLOAD_FAILED	= 5,
                    text = "Can not create object";
                    break;

                case 6:                                //SGFDX_ERROR_DLLLOAD_FAILED_DRV	= 6,
                    text = "Can not load device driver";
                    break;
                case 7:                                //SGFDX_ERROR_DLLLOAD_FAILED_ALGO = 7,
                    text = "Can not load sgfpamx.dll";
                    break;

                case 51:                //SGFDX_ERROR_SYSLOAD_FAILED	   = 51,	// system file load fail
                    text = "Can not load driver kernel file";
                    break;

                case 52:                //SGFDX_ERROR_INITIALIZE_FAILED  = 52,   // chip initialize fail
                    text = "Failed to initialize the device";
                    break;

                case 53:                //SGFDX_ERROR_LINE_DROPPED		   = 53,   // image data drop
                    text = "Data transmission is not good";
                    break;

                case 54:                //SGFDX_ERROR_TIME_OUT			   = 54,   // getliveimage timeout error
                    text = "Time out";
                    break;

                case 55:                //SGFDX_ERROR_DEVICE_NOT_FOUND	= 55,   // device not found
                    text = "Device not found";
                    break;

                case 56:                //SGFDX_ERROR_DRVLOAD_FAILED	   = 56,   // dll file load fail
                    text = "Can not load driver file";
                    break;

                case 57:                //SGFDX_ERROR_WRONG_IMAGE		   = 57,   // wrong image
                    text = "Wrong Image";
                    break;

                case 58:                //SGFDX_ERROR_LACK_OF_BANDWIDTH  = 58,   // USB Bandwith Lack Error
                    text = "Lack of USB Bandwith";
                    break;

                case 59:                //SGFDX_ERROR_DEV_ALREADY_OPEN	= 59,   // Device Exclusive access Error
                    text = "Device is already opened";
                    break;

                case 60:                //SGFDX_ERROR_GETSN_FAILED		   = 60,   // Fail to get Device Serial Number
                    text = "Device serial number error";
                    break;

                case 61:                //SGFDX_ERROR_UNSUPPORTED_DEV		   = 61,   // Unsupported device
                    text = "Unsupported device";
                    break;

                // Extract & Verification error
                case 101:                //SGFDX_ERROR_FEAT_NUMBER		= 101, // utoo small number of minutiae
                    text = "The number of minutiae is too small";
                    break;

                case 102:                //SGFDX_ERROR_INVALID_TEMPLATE_TYPE		= 102, // wrong template type
                    text = "Template is invalid";
                    break;

                case 103:                //SGFDX_ERROR_INVALID_TEMPLATE1		= 103, // wrong template type
                    text = "1st template is invalid";
                    break;

                case 104:                //SGFDX_ERROR_INVALID_TEMPLATE2		= 104, // vwrong template type
                    text = "2nd template is invalid";
                    break;

                case 105:                //SGFDX_ERROR_EXTRACT_FAIL		= 105, // extraction fail
                    text = "Minutiae extraction failed";
                    break;

                case 106:                //SGFDX_ERROR_MATCH_FAIL		= 106, // matching  fail
                    text = "Matching failed";
                    break;

            }

            text = funcName + " Error # " + iError + " :" + text;
            StatusBar.Text = text;
        }

        //private void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string Name = txtName.Text;
        //        string PPNO = txtPPNO.Text;
        //        string RegNo= txtReg.Text;
        //        DateTime EntryDate = dateTimePicker1.Value;




        //        using (SqlConnection dbConnection = DatabaseConfig.GetSqlConnection())
        //        {
        //            dbConnection.Open();
        //            string insertQuery = "INSERT INTO FingerPrint (regno,name, ppno, entrydate) OUTPUT INSERTED.AutoID VALUES (@RegNo,@Name, @PPNO, @EntryDate)";

        //            SqlCommand cmd = new SqlCommand(insertQuery, dbConnection);

        //            // Add parameters 
        //            cmd.Parameters.AddWithValue("@RegNo", RegNo);
        //            cmd.Parameters.AddWithValue("@Name", Name);
        //            cmd.Parameters.AddWithValue("@PPNO", PPNO);
        //            cmd.Parameters.AddWithValue("@EntryDate", EntryDate);

        //            Identity = (int)cmd.ExecuteScalar(); // Assuming Identity is of type int

        //            MessageBox.Show("Data inserted successfully with AutoID: " + Identity);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void btnClear_Click(object sender, EventArgs e)
        {
            //txtName.Text = string.Empty;
            ////txtPPNO.Text = string.Empty;
            //txtReg.Text = string.Empty;
            // Clear ProgressBar values
            UserprogressBar1.Value = 0;
            UserprogressBar2.Value = 0;
            UserverifyBar.Value = 0;

            // Clear PictureBox images
            UserpictureBox2.Image = null;
            userPictureBox1.Image = null;
            pictureBox4.Image = null;
            pictureBox2.Image = null;



        }

        private void btnUserVerify_Click(object sender, EventArgs e)
        {

        }

        private void btnUserRegister_Click(object sender, EventArgs e)
        {
            Int32 iError;
            bool matched = false;
            Int32 match_score = 0;
            SGFPMSecurityLevel secu_level; //

            //string Name = txtName.Text;
            //string PPNO = txtPPNO.Text;
            //string RegNo = txtReg.Text;
            //DateTime EntryDate = dateTimePicker1.Value;

            //secu_level = (SGFPMSecurityLevel)comboBoxSecuLevel_R.SelectedIndex;

            //iError = m_FPM.MatchTemplate(m_RegMin3, m_RegMin4, secu_level, ref matched);
            iError = m_FPM.GetMatchingScore(m_RegMin3, m_RegMin4, ref match_score);

            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                if (matched)
                {
                    StatusBar.Text = "Registration Success, Matching Score: " + match_score;

                    using (SqlConnection dbConnection = DatabaseConfig.GetSqlConnection())
                    {
                        dbConnection.Open();
                        //string insertQuery = "INSERT INTO FingerPrint (regno,name, ppno, entrydate,image1,image2,registration,profilepic) OUTPUT INSERTED.AutoID VALUES (@RegNo,@Name, @PPNO, @EntryDate,@Image1,@Image2,1,@profilepic)";
                        string insertQuery = "INSERT INTO FingerPrintN (regno,name, ppno, entrydate,image1,image2,registration,profilepic) OUTPUT INSERTED.AutoID VALUES (@RegNo,@Name, @PPNO, @EntryDate,@Image1,@Image2,1,@profilepic)";

                        SqlCommand cmd = new SqlCommand(insertQuery, dbConnection);

                        // Add parameters 
                        //cmd.Parameters.AddWithValue("@RegNo", RegNo);
                        //cmd.Parameters.AddWithValue("@Name", Name);
                        //cmd.Parameters.AddWithValue("@PPNO", PPNO);
                        //cmd.Parameters.AddWithValue("@EntryDate", EntryDate);
                        //cmd.Parameters.AddWithValue("@Image1", fp_image1);
                        cmd.Parameters.AddWithValue("@Image2", fp_image2);
                        cmd.Parameters.AddWithValue("@profilepic", profilepic);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("User added to the database successfully!");
                    }
                }

                else
                    StatusBar.Text = "Registration Failed";
            }
            else
                DisplayError("GetMatchingScore()", iError);
        }

        private void btnUCap1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Int32 iError;
            Byte[] fp_image;
            Int32 img_qlty;

            fp_image = new Byte[m_ImageWidth * m_ImageHeight];
            img_qlty = 0;

            iError = m_FPM.GetImage(fp_image);

            m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_image, ref img_qlty);
            UserprogressBar2.Value = img_qlty;

            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                DrawImage(fp_image, UserpictureBox2);
                iError = m_FPM.CreateTemplate(fp_image, m_RegMin3);

                if (iError == (Int32)SGFPMError.ERROR_NONE)
                {
                    StatusBar.Text = "First image is captured";


                    //fp_image1 = fp_image;
                    // //Convert Byte Array to Image
                    MemoryStream ms = new MemoryStream(fp_image);

                    fp_image1 = ms.ToArray();

                    // try
                    // {
                    //     // Replace the following with your database connection logic
                    //     using (SqlConnection dbConnection = DatabaseConfig.GetSqlConnection())
                    //     {
                    //         dbConnection.Open();
                    //         string insertQuery = "UPDATE FingerPrint SET image1=@Image WHERE AutoID=" + Identity;
                    //         SqlCommand cmd = new SqlCommand(insertQuery, dbConnection);
                    //         cmd.Parameters.AddWithValue("@Image", imageBytes);
                    //         cmd.ExecuteNonQuery();
                    //     }
                    // }
                    // catch (Exception ex)
                    // {
                    //     MessageBox.Show(ex.Message);
                    // }
                }

                else
                {
                    DisplayError("CreateTemplate()", iError);
                }

            }
            else
                DisplayError("GetImage()", iError);

            Cursor.Current = Cursors.Default;
        }

        private void btnUCap2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Int32 iError;
            Byte[] fp_image;
            Int32 img_qlty;

            fp_image = new Byte[m_ImageWidth * m_ImageHeight];
            img_qlty = 0;

            iError = m_FPM.GetImage(fp_image);

            m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_image, ref img_qlty);
            UserprogressBar1.Value = img_qlty;

            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                DrawImage(fp_image, userPictureBox1);
                iError = m_FPM.CreateTemplate(fp_image, m_RegMin4);

                if (iError == (Int32)SGFPMError.ERROR_NONE)
                {
                    StatusBar.Text = "Second image is captured";



                    //Convert Byte Array to Image
                    MemoryStream ms = new MemoryStream(fp_image);

                    fp_image2 = ms.ToArray();

                    //try
                    //{
                    //    // Replace the following with your database connection logic
                    //    using (SqlConnection dbConnection = DatabaseConfig.GetSqlConnection())
                    //    {
                    //        dbConnection.Open();
                    //        string insertQuery = "UPDATE FingerPrint SET image2=@Image WHERE AutoID=" + Identity;
                    //        SqlCommand cmd = new SqlCommand(insertQuery, dbConnection);
                    //        cmd.Parameters.AddWithValue("@Image", imageBytes);
                    //        cmd.ExecuteNonQuery();
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.Message);
                    // }
                }

                else
                {
                    DisplayError("CreateTemplate()", iError);
                }

            }
            else
                DisplayError("GetImage()", iError);

            Cursor.Current = Cursors.Default;
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblNam_Click(object sender, EventArgs e)
        {

        }

        private void lblPPNo_Click(object sender, EventArgs e)
        {

        }

        private void txtPPNO_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Int32 iError;
            SGFPMSecurityLevel secu_level;

            // Assuming m_VrfMin is your verification template
            byte[] m_VrfMin = imageV1;

            List<int> matchedAutoIDs = new List<int>();
            float highestMatchScore = 0.0f;

            secu_level = (SGFPMSecurityLevel)comboBoxSecuLevel_V.SelectedIndex;

            using (SqlConnection conn = DatabaseConfig.GetSqlConnection())
            {
                conn.Open();

                string sqlQuery = "SELECT [AutoID], [image1],[image2],[regno],[name],[ppno],[entrydate],[profilepic] FROM [dbo].[FingerPrint]";
                //string sqlQuery = "SELECT [AutoID], [image1],[image2],[regno],[name],[ppno],[entrydate],[profilepic] FROM [dbo].[FingerPrintN]";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int autoID = (int)reader["AutoID"];
                            byte[] image1Data = (byte[])reader["image1"];
                            string regno = reader["regno"].ToString();
                            string name = reader["name"].ToString();
                            string ppno = reader["ppno"].ToString();
                            DateTime dateTimeValue = (DateTime)reader["entrydate"];
                            byte[] profilepic = (byte[])reader["profilepic"];

                            //byte[] image1Data = (byte[])reader["image1"];

                            bool matched = false;
                            iError = m_FPM.CreateTemplate(image1Data, m_RegMin4);
                            //iError = m_FPM.GetMatchingScore(m_RegMin4, m_VrfMin2, ref match_score1);
                            iError = m_FPM.MatchTemplate(m_RegMin4, m_VrfMin2, secu_level, ref matched);

                            if (iError == (Int32)SGFPMError.ERROR_NONE && matched)
                            {
                                float matchScore = 1.0f;

                                if (matchScore > highestMatchScore)
                                {
                                    highestMatchScore = matchScore;
                                    matchedAutoIDs.Clear();
                                    matchedAutoIDs.Add(autoID);

                                    //txtVerifyUser.Text = regno;
                                    //txtUVName.Text = name;
                                    //txtUVPPNO.Text = ppno;
                                    //dtpUV.Value = dateTimeValue;
                                    pictureBox3.Image = ByteArrayToImage(profilepic);
                                    pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;

                                    // Helper method to convert byte array to Image
                                    Image ByteArrayToImage(byte[] byteArrayIn)
                                    {
                                        if (byteArrayIn == null)
                                        {
                                            return null;
                                        }

                                        using (MemoryStream ms = new MemoryStream(byteArrayIn))
                                        {
                                            Image img = Image.FromStream(ms);

                                            // Set the size of the PictureBox to match the size of the image
                                            pictureBox3.Size = img.Size;

                                            return img;
                                        }
                                    }

                                }
                                else if (matchScore == highestMatchScore)
                                {
                                    matchedAutoIDs.Add(autoID);
                                }
                            }
                        }
                    }
                }
            }




        }

        private void btnV1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Int32 iError;
            Byte[] fp_image;
            Int32 img_qlty;

            fp_image = new Byte[m_ImageWidth * m_ImageHeight];
            img_qlty = 0;

            iError = m_FPM.GetImage(fp_image);

            m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_image, ref img_qlty);
            UserverifyBar.Value = img_qlty;

            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                DrawImage(fp_image, pictureBox4);
                iError = m_FPM.CreateTemplate(null, fp_image, m_VrfMin1);

                if (iError == (Int32)SGFPMError.ERROR_NONE)
                    StatusBar.Text = "Image for verification is captured";
                else
                    DisplayError("CreateTemplate()", iError);
            }
            else
                DisplayError("GetImage()", iError);

            Cursor.Current = Cursors.Default;
        }


        private void SetImage(byte[] imageData, PictureBox pictureBox)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    pictureBox.Image = Image.FromStream(ms, false, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Image Error: " + ex.Message);
            }

            //try
            //{
            //    using (MemoryStream ms = new MemoryStream(imageData))
            //    {
            //        ms.Position = 0; // Reset the position to the beginning
            //        Image image = Image.FromStream(ms);
            //        pictureBox.Image = image;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Image Error: " + ex.Message);
            //}
        }

        private void btnUverifyV_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Int32 iError;
            Byte[] fp_image;
            Int32 img_qlty;

            fp_image = new Byte[m_ImageWidth * m_ImageHeight];
            img_qlty = 0;

            iError = m_FPM.GetImage(fp_image);

            m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_image, ref img_qlty);
            pbUverifyV1.Value = img_qlty;

            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                DrawImage(fp_image, pbUverifyV);
                iError = m_FPM.CreateTemplate(null, fp_image, m_VrfMin2);

                imageV1 = fp_image;


                if (iError == (Int32)SGFPMError.ERROR_NONE)
                    StatusBar.Text = "Image for verification is captured";
                else
                    DisplayError("CreateTemplate()", iError);
            }
            else
                DisplayError("GetImage()", iError);

            Cursor.Current = Cursors.Default;
        }

        private void btnUVClear_Click(object sender, EventArgs e)
        {
        //    txtVerifyUser.Text = string.Empty;
        //    txtUVName.Text = string.Empty;
        //    txtUVPPNO.Text = string.Empty;
            pictureBox3.Image = null;
            //SetpictureBox2.Image = null;
            pbUverifyV.Image = null;
            pbUverifyV1.Value = 0;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Title = "Open Image File";
            ofd.Filter = "Images (*.JPG;*.PNG)|*.JPG;*.PNG;";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //if ((new FileInfo(ofd.FileName).Length / 1024) > 1024)
                //{
                //    MessageBox.Show("File size cannot be greater than 1MB", CommonData.SoftwareName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}


                //  picStudent.Image = Image.FromFile(ofd.FileName);
                string filename = ofd.FileName;
                string FileType = Path.GetExtension(filename);
                Byte[] imgbytes = File.ReadAllBytes(filename);









                //   
                pictureBox2.ImageLocation = filename;
                pictureBox2.Size = new System.Drawing.Size(10, 10);
                //DrawImage(imgbytes, pictureBox2);
                MemoryStream ms = new MemoryStream(imgbytes);

                profilepic = ms.ToArray();


            }
        }

        private void btnveryfiy_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Int32 iError;
            Byte[] fp_image;
            Int32 img_qlty;

            fp_image = new Byte[m_ImageWidth * m_ImageHeight];
            img_qlty = 0;

            iError = m_FPM.GetImage(fp_image);

            m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_image, ref img_qlty);
            pbUverifyV1.Value = img_qlty;

            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                DrawImage(fp_image, pbUverifyV);
                iError = m_FPM.CreateTemplate(null, fp_image, m_VrfMin2);

                imageV1 = fp_image;


                if (iError == (Int32)SGFPMError.ERROR_NONE)
                    StatusBar.Text = "Image for verification is captured";
                else
                    DisplayError("CreateTemplate()", iError);
            }
            else
                DisplayError("GetImage()", iError);

            Cursor.Current = Cursors.Default;
        }

        private void comboBoxSecuLevel_R_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {

            Regverify.Text = string.Empty;
            verifyPassport.Text = string.Empty;
            propicbox.Image = null;
            //SetpictureBox2.Image = null;
            pictureBoxV1.Image = null;
            progressBar_V1.Value = 0;
        }
    }

}


