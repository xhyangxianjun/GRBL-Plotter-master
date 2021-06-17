﻿/*  GRBL-Plotter. Another GCode sender for GRBL.
    This file is part of the GRBL-Plotter application.
   
    Copyright (C) 2015-2018 Sven Hasemann contact: svenhb@web.de

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
/*  Thanks to https://github.com/PavelTorgashov/FastColoredTextBox
*/
/*  2016-09-18  improve performance for low-performance PC: during streaming show background-image with toolpath
 *              instead of redrawing toolpath with each onPaint.
 *              Joystick-control: adjustable step-width and speed.
 *  2016-12-31  Add GRBL 1.1 function
 *  2017-01-01  check form-location and fix strange location
 *  2017-01-03  Add 'Replace M3 by M4' during GCode file open
 *  2017-06-22  Cleanup transform actions
 *  2018-01-02  Add Override Buttons
 *              Bugfix - no zooming during  streaming - disable background image (XP Problems?)
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using virtualJoystick;
using FastColoredTextBoxNS;
using System.Globalization;
using System.Threading;
using System.Text;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Resources;
using System.Diagnostics;
using System.Linq;

namespace GRBL_Plotter
{
    public struct xyzPoint
    {
        public double X, Y, Z, A;
        public xyzPoint(double x, double y, double z, double a = 0)
        { X = x; Y = y; Z = z; A = a; }
    };

    public partial class MainForm : Form
    {
        ControlSerialForm _serial_form = null;
        ControlSerialForm _serial_form2 = null;
        Control2ndGRBL _2ndGRBL_form = null;
        ControlStreamingForm _streaming_form = null;
        ControlStreamingForm2 _streaming_form2 = null;
        ControlCameraForm _camera_form = null;
        ControlSetupForm _setup_form = null;
        ControlHeightMapForm _heightmap_form = null;
        GCodeFromText _text_form = null;
        GCodeFromImage _image_form = null;
        GCodeFromShape _shape_form = null;

        private const string appName = "GRBL Plotter";
        private xyzPoint posMachine = new xyzPoint(0, 0, 0);
        private xyzPoint posWorld = new xyzPoint(0, 0, 0);
        private xyzPoint posProbe = new xyzPoint(0, 0, 0);
        private grblState machineStatus;
        public bool flagResetOffset = false;
        private double[] joystickXYStep = { 0, 1, 2, 3, 4, 5 };
        private double[] joystickZStep = { 0, 1, 2, 3, 4, 5 };
        private double[] joystickXYSpeed = { 0, 1, 2, 3, 4, 5 };
        private double[] joystickZSpeed = { 0, 1, 2, 3, 4, 5 };

        private bool ctrl4thAxis = false;
        private string ctrl4thName = "A";
        private string lastLoadSource = "Nothing loaded";
        string dxcb = "";
        string generateGCode = "";
        Point colorPoint = new Point();
        GraphicsPath UpdateGr = new GraphicsPath();
        Color colorChoosed = new Color();
        public MainForm()
        {
            CultureInfo ci = new CultureInfo(Properties.Settings.Default.language);
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(ci.ToString());
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            InitializeComponent();
            gcode.setup();
            updateDrawing();
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(Application_UnhandledException);
        }
        //Unhandled exception
        private void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            MessageBox.Show(ex.Message, "Thread exception");
        }
        private void Application_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject != null)
            {
                Exception ex = (Exception)e.ExceptionObject;
                MessageBox.Show(ex.Message, "Application exception");
            }
        }

        // initialize Main form
        private void MainForm_Load(object sender, EventArgs e)
        {
          
            Properties.Settings.Default.colorPenDown = Color.Red;
            Properties.Settings.Default.colorRuler = Color.Blue;
            Properties.Settings.Default.colorPenUp = Color.Green;
            Properties.Settings.Default.colorTool = Color.Black;
            Properties.Settings.Default.colorMarker = Color.DeepPink;
            Size desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorSize;
            Location = Properties.Settings.Default.locationMForm;
            if ((Location.X < -20) || (Location.X > (desktopSize.Width - 100)) || (Location.Y < -20) || (Location.Y > (desktopSize.Height - 100))) { Location = new Point(0, 0); }
            //this.Text = appName + " Ver " + System.Windows.Forms.Application.ProductVersion.ToString(); // Application.ProductVersion.ToString();    //Application.ProductVersion;
            this.Text = "丹佛数控DXF转G代码V1.0";
            checkUpdate.CheckVersion();  // check update

            if (_serial_form == null)
            {
                #region 隐藏com窗体
                //if (Properties.Settings.Default.useSerial2)
                //{
                //    _serial_form2 = new ControlSerialForm("COM Tool changer", 2);
                //    _serial_form2.Show(this);
                //}
                //_serial_form = new ControlSerialForm("COM CNC", 1, _serial_form2);
                //_serial_form.Show(this);
                //_serial_form.RaisePosEvent += OnRaisePosEvent;
                //_serial_form.RaiseStreamEvent += OnRaiseStreamEvent;
                #endregion
            }
            _serial_form = new ControlSerialForm("COM CNC", 1, _serial_form2);
            lbDimension.Select(0, 0);
            loadSettings(sender, e);
            //updateControls();
            LoadRecentList();
            foreach (string item in MRUlist)
            {
                ToolStripMenuItem fileRecent = new ToolStripMenuItem(item, null, RecentFile_click);  //create new menu for each item in list
                toolStripMenuItem2.DropDownItems.Add(fileRecent); //add the menu to "recent" menu
            }

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            { loadFile(args[1]); }
        }
        // close Main form
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Properties.Settings.Default.locationMForm = Location;
                saveSettings();
                if (_2ndGRBL_form != null) _2ndGRBL_form.Close();
                if (_heightmap_form != null) _heightmap_form.Close();
                if (_setup_form != null) _setup_form.Close();
                if (_camera_form != null) _camera_form.Close();
                if (_streaming_form != null) _streaming_form.Close();
                if (_heightmap_form != null) _heightmap_form.Close();
                _serial_form.Close();
            }
            catch (Exception)
            {

            }

        }
        // load settings
        private void loadSettings(object sender, EventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.UpgradeRequired)
                {
                    Properties.Settings.Default.Upgrade();
                    Properties.Settings.Default.UpgradeRequired = false;
                    Properties.Settings.Default.Save();
                }
                tbFile.Text = Properties.Settings.Default.file;
                setCustomButton(btnCustom1, Properties.Settings.Default.custom1);
                setCustomButton(btnCustom2, Properties.Settings.Default.custom2);
                setCustomButton(btnCustom3, Properties.Settings.Default.custom3);
                setCustomButton(btnCustom4, Properties.Settings.Default.custom4);
                setCustomButton(btnCustom5, Properties.Settings.Default.custom5);
                setCustomButton(btnCustom6, Properties.Settings.Default.custom6);
                setCustomButton(btnCustom7, Properties.Settings.Default.custom7);
                setCustomButton(btnCustom8, Properties.Settings.Default.custom8);
                fCTBCode.BookmarkColor = Properties.Settings.Default.colorMarker; ;
                //pictureBox1.BackColor = Properties.Settings.Default.colorBackground;
                //                visuGCode.setColors();
                penUp.Color = Properties.Settings.Default.colorPenUp;

                penDown.Color = Properties.Settings.Default.colorPenDown;
                penHeightMap.Color = Properties.Settings.Default.colorHeightMap;
                penRuler.Color = Properties.Settings.Default.colorRuler;
                penTool.Color = Properties.Settings.Default.colorTool;
                penMarker.Color = Properties.Settings.Default.colorMarker;
                penHeightMap.Width = (float)Properties.Settings.Default.widthHeightMap;
                penRuler.Width = (float)Properties.Settings.Default.widthRuler;
                penUp.Width = (float)Properties.Settings.Default.widthPenUp;
                penDown.Width = (float)Properties.Settings.Default.widthPenDown;
                penTool.Width = (float)Properties.Settings.Default.widthTool;
                penMarker.Width = (float)Properties.Settings.Default.widthMarker;
                picBoxBackround = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                updateDrawing();

                joystickXYStep[1] = (double)Properties.Settings.Default.joyXYStep1;
                joystickXYStep[2] = (double)Properties.Settings.Default.joyXYStep2;
                joystickXYStep[3] = (double)Properties.Settings.Default.joyXYStep3;
                joystickXYStep[4] = (double)Properties.Settings.Default.joyXYStep4;
                joystickXYStep[5] = (double)Properties.Settings.Default.joyXYStep5;
                joystickZStep[1] = (double)Properties.Settings.Default.joyZStep1;
                joystickZStep[2] = (double)Properties.Settings.Default.joyZStep2;
                joystickZStep[3] = (double)Properties.Settings.Default.joyZStep3;
                joystickZStep[4] = (double)Properties.Settings.Default.joyZStep4;
                joystickZStep[5] = (double)Properties.Settings.Default.joyZStep5;
                joystickXYSpeed[1] = (double)Properties.Settings.Default.joyXYSpeed1;
                joystickXYSpeed[2] = (double)Properties.Settings.Default.joyXYSpeed2;
                joystickXYSpeed[3] = (double)Properties.Settings.Default.joyXYSpeed3;
                joystickXYSpeed[4] = (double)Properties.Settings.Default.joyXYSpeed4;
                joystickXYSpeed[5] = (double)Properties.Settings.Default.joyXYSpeed5;
                joystickZSpeed[1] = (double)Properties.Settings.Default.joyZSpeed1;
                joystickZSpeed[2] = (double)Properties.Settings.Default.joyZSpeed2;
                joystickZSpeed[3] = (double)Properties.Settings.Default.joyZSpeed3;
                joystickZSpeed[4] = (double)Properties.Settings.Default.joyZSpeed4;
                joystickZSpeed[5] = (double)Properties.Settings.Default.joyZSpeed5;
                virtualJoystickXY.JoystickLabel = joystickXYStep;
                virtualJoystickZ.JoystickLabel = joystickZStep;
                virtualJoystickA.JoystickLabel = joystickZStep;
                skaliereXAufDrehachseToolStripMenuItem.Enabled = false;
                skaliereXAufDrehachseToolStripMenuItem.BackColor = SystemColors.Control;
                skaliereXAufDrehachseToolStripMenuItem.ToolTipText = "Enable rotary axis in Setup - Control";
                skaliereAufXUnitsToolStripMenuItem.BackColor = SystemColors.Control;
                skaliereAufXUnitsToolStripMenuItem.ToolTipText = "Enable in Setup - Control";
                skaliereYAufDrehachseToolStripMenuItem.Enabled = false;
                skaliereYAufDrehachseToolStripMenuItem.BackColor = SystemColors.Control;
                skaliereYAufDrehachseToolStripMenuItem.ToolTipText = "Enable rotary axis in Setup - Control";
                skaliereAufYUnitsToolStripMenuItem.BackColor = SystemColors.Control;
                skaliereAufYUnitsToolStripMenuItem.ToolTipText = "Enable in Setup - Control";
                toolStrip_tb_rotary_diameter.Text = string.Format("{0:0.00}", Properties.Settings.Default.rotarySubstitutionDiameter);

                if (Properties.Settings.Default.rotarySubstitutionEnable)
                {
                    string tmp = string.Format("Calculating rotary angle depending on part diameter ({0:0.00} units) and desired size.\r\nSet part diameter in Setup - Control.", Properties.Settings.Default.rotarySubstitutionDiameter);
                    if (Properties.Settings.Default.rotarySubstitutionX)
                    {
                        skaliereXAufDrehachseToolStripMenuItem.Enabled = true;
                        skaliereXAufDrehachseToolStripMenuItem.BackColor = Color.Yellow;
                        skaliereAufXUnitsToolStripMenuItem.BackColor = Color.Yellow;
                        skaliereAufXUnitsToolStripMenuItem.ToolTipText = tmp;
                        skaliereXAufDrehachseToolStripMenuItem.ToolTipText = "";
                    }
                    else
                    {
                        skaliereYAufDrehachseToolStripMenuItem.Enabled = true;
                        skaliereYAufDrehachseToolStripMenuItem.BackColor = Color.Yellow;
                        skaliereAufYUnitsToolStripMenuItem.BackColor = Color.Yellow;
                        skaliereAufYUnitsToolStripMenuItem.ToolTipText = tmp;
                        skaliereYAufDrehachseToolStripMenuItem.ToolTipText = "";
                    }
                }
                if (Properties.Settings.Default.rotarySubstitutionSetupEnable)
                {
                    string[] commands;
                    if (Properties.Settings.Default.rotarySubstitutionEnable)
                    { commands = Properties.Settings.Default.rotarySubstitutionSetupOn.Split(';'); }
                    else
                    { commands = Properties.Settings.Default.rotarySubstitutionSetupOff.Split(';'); }
                    if (_serial_form.serialPortOpen)
                        foreach (string cmd in commands)
                        {
                            sendCommand(cmd.Trim());
                            Thread.Sleep(100);
                        }
                }

                ctrl4thAxis = Properties.Settings.Default.ctrl4thUse;
                ctrl4thName = Properties.Settings.Default.ctrl4thName;
                label_a.Visible = ctrl4thAxis;
                label_a.Text = ctrl4thName;
                label_wa.Visible = ctrl4thAxis;
                label_ma.Visible = ctrl4thAxis;
                btnZeroA.Visible = ctrl4thAxis;
                btnZeroA.Text = "Zero " + ctrl4thName;
                if (Properties.Settings.Default.language == "de-DE")
                    btnZeroA.Text = ctrl4thName + " nullen";

                virtualJoystickA.Visible = ctrl4thAxis;
                btnJogZeroA.Visible = ctrl4thAxis;
                btnJogZeroA.Text = ctrl4thName + "=0";
                if (ctrl4thAxis)
                {
                    label_status0.Location = new Point(1, 128);
                    label_status.Location = new Point(1, 148);
                    btnHome.Location = new Point(122, 138);
                    btnHome.Size = new Size(117, 30);
                    virtualJoystickXY.Size = new Size(160, 160);
                    virtualJoystickZ.Size = new Size(30, 160);
                    virtualJoystickZ.Location = new Point(166, 119);
                }
                else
                {
                    label_status0.Location = new Point(1, 118);
                    label_status.Location = new Point(1, 138);
                    btnHome.Location = new Point(122, 111);
                    btnHome.Size = new Size(117, 57);
                    virtualJoystickXY.Size = new Size(180, 180);
                    virtualJoystickZ.Size = new Size(40, 180);
                    virtualJoystickZ.Location = new Point(186, 119);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Load Settings: " + a);
                //               logError("Loading settings", e);
            }
        }
        // Save settings
        public void saveSettings()
        {
            try
            {
                Properties.Settings.Default.file = tbFile.Text;
                Properties.Settings.Default.Save();
            }
            catch (Exception e)
            {
                MessageBox.Show("Save Settings: " + e);
                //               logError("Saving settings", e);
            }
        }
        // update controls on Main form
        public void updateControls(bool allowControl = false)
        {
            bool isConnected = _serial_form.serialPortOpen;
            virtualJoystickXY.Enabled = isConnected && (!isStreaming || allowControl);
            virtualJoystickZ.Enabled = isConnected && (!isStreaming || allowControl);
            virtualJoystickA.Enabled = isConnected && (!isStreaming || allowControl);
            btnCustom1.Enabled = isConnected && (!isStreaming || allowControl);
            btnCustom2.Enabled = isConnected & !isStreaming | allowControl;
            btnCustom3.Enabled = isConnected & !isStreaming | allowControl;
            btnCustom4.Enabled = isConnected & !isStreaming | allowControl;
            btnCustom5.Enabled = isConnected & !isStreaming | allowControl;
            btnCustom6.Enabled = isConnected & !isStreaming | allowControl;
            btnCustom7.Enabled = isConnected & !isStreaming | allowControl;
            btnCustom8.Enabled = isConnected & !isStreaming | allowControl;
            btnHome.Enabled = isConnected & !isStreaming | allowControl;
            btnZeroX.Enabled = isConnected & !isStreaming | allowControl;
            btnZeroY.Enabled = isConnected & !isStreaming | allowControl;
            btnZeroZ.Enabled = isConnected & !isStreaming | allowControl;
            btnZeroA.Enabled = isConnected & !isStreaming | allowControl;
            btnZeroXY.Enabled = isConnected & !isStreaming | allowControl;
            btnZeroXYZ.Enabled = isConnected & !isStreaming | allowControl;
            btnJogZeroX.Enabled = isConnected & !isStreaming | allowControl;
            btnJogZeroY.Enabled = isConnected & !isStreaming | allowControl;
            btnJogZeroZ.Enabled = isConnected & !isStreaming | allowControl;
            btnJogZeroA.Enabled = isConnected & !isStreaming | allowControl;
            btnJogZeroXY.Enabled = isConnected & !isStreaming | allowControl;
            cBSpindle.Enabled = isConnected & !isStreaming | allowControl;
            tBSpeed.Enabled = isConnected & !isStreaming | allowControl;
            cBCoolant.Enabled = isConnected & !isStreaming | allowControl;
            cBTool.Enabled = isConnected & !isStreaming | allowControl;
            btnReset.Enabled = isConnected;
            btnFeedHold.Enabled = isConnected;
            btnResume.Enabled = isConnected;
            btnKillAlarm.Enabled = isConnected;
            btnStreamStart.Enabled = isConnected;// & isFileLoaded;
            btnStreamStop.Enabled = isConnected; // & isFileLoaded;
            btnStreamCheck.Enabled = isConnected;// & isFileLoaded;

            btnJogStop.Visible = !_serial_form.isGrblVers0;
            btnJogStop.Enabled = isConnected & !isStreaming | allowControl;
            btnOverrideFRGB.Enabled = !_serial_form.isGrblVers0 & isConnected & isStreaming | allowControl;
            btnOverrideSSGB.Enabled = !_serial_form.isGrblVers0 & isConnected & isStreaming | allowControl;
        }

        // handle position events from serial form
        private void OnRaisePosEvent(object sender, PosEventArgs e)
        {
            posWorld = e.PosWorld;
            posMachine = e.PosMachine;
            machineStatus = e.Status;
            if (e.StatMsg.Ov.Length > 1)    // check and submit override values
            {
                if (_streaming_form2 != null)
                { _streaming_form2.showOverrideValues(e.StatMsg.Ov); }

                string[] value = e.StatMsg.Ov.Split(',');
                if (value.Length > 2)
                {
                    lblOverrideFRValue.Text = value[0];
                    lblOverrideSSValue.Text = value[2];
                }
            }
            if (e.StatMsg.FS.Length > 1)    // check and submit override values
            {
                if (_streaming_form2 != null)
                    _streaming_form2.showActualValues(e.StatMsg.FS);
            }
            if (e.Status == grblState.probe)
            {
                posProbe = _serial_form.posProbe;
                if (_heightmap_form != null)
                    _heightmap_form.setPosProbe = posProbe;
            }

            label_mx.Text = string.Format("{0:0.000}", posMachine.X);
            label_my.Text = string.Format("{0:0.000}", posMachine.Y);
            label_mz.Text = string.Format("{0:0.000}", posMachine.Z);
            label_ma.Text = string.Format("{0:0.000}", posMachine.A);
            label_wx.Text = string.Format("{0:0.000}", posWorld.X);
            label_wy.Text = string.Format("{0:0.000}", posWorld.Y);
            label_wz.Text = string.Format("{0:0.000}", posWorld.Z);
            label_wa.Text = string.Format("{0:0.000}", posWorld.A);
            visuGCode.setPosTool(posWorld.X, posWorld.Y, posWorld.Z);
            if (_camera_form != null)
            {
                _camera_form.setPosWorld = posWorld;
                _camera_form.setPosMachine = posMachine;
            }
            if (_heightmap_form != null)
            {
                _heightmap_form.setPosWorld = posWorld;
                _heightmap_form.setPosMachine = posMachine;
                //         _heightmap_form.setPosProbe = posProbe;
            }
            if (flagResetOffset)
            {
                double x = Properties.Settings.Default.lastOffsetX;
                double y = Properties.Settings.Default.lastOffsetY;
                double z = Properties.Settings.Default.lastOffsetZ;
                double a = Properties.Settings.Default.lastOffsetA;
                _serial_form.addToLog("Restore saved position after reset\r\nand set initial feed rate:");
                if (ctrl4thAxis)
                    sendCommand(String.Format("G92 X{0} Y{1} Z{2} {3}{4}F10", x, y, z, ctrl4thName, a).Replace(',', '.'));
                else
                    sendCommand(String.Format("G92 X{0} Y{1} Z{2} F10", x, y, z).Replace(',', '.'));
                flagResetOffset = false;
                updateControls();
            }
            processStatus();
            processLastCommand(e.lastCommand);
            visuGCode.createMarkerPath();
            pictureBox1.Invalidate();
        }
        // handle status events from serial form
        private grblState lastMachineStatus = grblState.unknown;
        private string lastInfoText = "";
        private string lastLabelInfoText = "";
        private bool updateDrawingPath = false;
        private void processStatus() // {idle, run, hold, home, alarm, check, door}
        {
            if (machineStatus != lastMachineStatus)
            {
                label_status.Text = grbl.statusToText(machineStatus);
                label_status.BackColor = grbl.grblStateColor(machineStatus);
                switch (machineStatus)
                {
                    case grblState.idle:
                        if ((lastMachineStatus == grblState.hold) || (lastMachineStatus == grblState.alarm))
                        {
                            lbInfo.Text = lastInfoText;
                            lbInfo.BackColor = SystemColors.Control;
                        }
                        signalResume = 0;
                        btnResume.BackColor = SystemColors.Control;
                        cBTool.Checked = _serial_form.toolInSpindle;
                        if (!isStreaming)                       // update drawing if G91 is used
                            updateDrawingPath = true;
                        break;
                    case grblState.run:
                        if (lastMachineStatus == grblState.hold)
                        {
                            lbInfo.Text = lastInfoText;
                            lbInfo.BackColor = SystemColors.Control;
                        }
                        signalResume = 0;
                        btnResume.BackColor = SystemColors.Control;
                        break;
                    case grblState.hold:
                        btnResume.BackColor = Color.Yellow;
                        lastInfoText = lbInfo.Text;
                        lbInfo.Text = "Press 'Resume' to proceed";
                        lbInfo.BackColor = Color.Yellow;
                        if (signalResume == 0) { signalResume = 1; }
                        break;
                    case grblState.home:
                        break;
                    case grblState.alarm:
                        signalLock = 1;
                        btnKillAlarm.BackColor = Color.Yellow;
                        lbInfo.Text = "Press 'Kill Alarm' to proceed";
                        lbInfo.BackColor = Color.Yellow;
                        if (_heightmap_form != null)
                            _heightmap_form.stopScan();
                        break;
                    case grblState.check:
                        break;
                    case grblState.door:
                        break;
                    case grblState.probe:
                        lastInfoText = lbInfo.Text;
                        lbInfo.Text = string.Format("Probing: Z={0:0.000}", posProbe.Z);
                        lbInfo.BackColor = Color.Yellow;
                        break;
                    default:
                        break;
                }
            }
            lastMachineStatus = machineStatus;
        }

        // handle last sent commands from serial form
        private string actualFR = "";
        private string actualSS = "";
        private void processLastCommand(string cmd)
        {
            if (cmd.Length < 2) return;
            if (cmd.LastIndexOf("F") >= 0)
            {
                actualFR = gcode.getStringValue('F', cmd).Substring(1);
                if (_streaming_form != null)
                    _streaming_form.show_value_FR(actualFR);
            }
            if (cmd.LastIndexOf("S") >= 0)
            {
                actualSS = gcode.getStringValue('S', cmd).Substring(1);
                if (_streaming_form != null)
                    _streaming_form.show_value_SS(actualSS);
            }
            foreach (string singleCmd in cmd.Split('M'))
            {
                int cmdNr = gcode.getIntGCode('M', "M" + singleCmd);
                if ((cmdNr == 3) || (cmdNr == 3)) cBSpindle.Checked = true;
                if (cmdNr == 5) cBSpindle.Checked = false;
                if ((cmdNr == 7) || (cmdNr == 8)) cBCoolant.Checked = true;
                if (cmdNr == 9) cBCoolant.Checked = false;
                if (cmdNr == 6)
                { lblTool.Text = cmd.Substring(cmd.IndexOf("T")); }
            }
        }

        // update drawing on Main form
        private void updateDrawing()
        {
            visuGCode.createImagePath();  // show initial empty picture
            pictureBox1.Invalidate();
            if (visuGCode.containsG2G3Command())
            {
                skaliereXUmToolStripMenuItem.Enabled = false;
                skaliereAufXUnitsToolStripMenuItem.Enabled = false;
                skaliereYUmToolStripMenuItem.Enabled = false;
                skaliereAufYUnitsToolStripMenuItem.Enabled = false;
                skaliereXAufDrehachseToolStripMenuItem.Enabled = false;
                skaliereYAufDrehachseToolStripMenuItem.Enabled = false;
                ersetzteG23DurchLinienToolStripMenuItem.Enabled = true;
            }
            else
            {
                skaliereXUmToolStripMenuItem.Enabled = true;
                skaliereAufXUnitsToolStripMenuItem.Enabled = true;
                skaliereYUmToolStripMenuItem.Enabled = true;
                skaliereAufYUnitsToolStripMenuItem.Enabled = true;
                skaliereXAufDrehachseToolStripMenuItem.Enabled = true;
                skaliereYAufDrehachseToolStripMenuItem.Enabled = true;
                ersetzteG23DurchLinienToolStripMenuItem.Enabled = false;
            }
        }

        // send command via serial form
        private void sendRealtimeCommand(int cmd)
        { _serial_form.realtimeCommand(cmd); }

        // send command via serial form
        private void sendCommand(string txt, bool jogging = false)
        {
            if ((jogging) && (_serial_form.isGrblVers0 == false))
                txt = "$J=" + txt;
            _serial_form.requestSend(txt);
        }

        private void OnRaiseOverrideMessage(object sender, OverrideMsgArgs e)
        { sendRealtimeCommand(e.MSG); }

        // get override events from form "StreamingForm" for GRBL 0.9
        private string overrideMessage = "";
        private void OnRaiseOverrideEvent(object sender, OverrideEventArgs e)
        {
            if (e.Source == overrideSource.feedRate)
                _serial_form.injectCode("F", (int)e.Value, e.Enable);
            if (e.Source == overrideSource.spindleSpeed)
                _serial_form.injectCode("S", (int)e.Value, e.Enable);

            overrideMessage = "";
            if (e.Enable)
                overrideMessage = " !!! Override !!!";
            lbInfo.Text = lastLabelInfoText + overrideMessage;
        }
        public void isNUllParameter()
        {
            #region 判断非空
            if (txt_ModelSetting.Text == "")
            {
                MessageBox.Show("模式设置不能为空"); return;
            }
            else if (!(System.Text.RegularExpressions.Regex.IsMatch(txt_ModelSetting.Text, @"^[0-2]{1,1}$")))
            {
                MessageBox.Show("模式设置有误,请重新设置"); return;
            }
            else if (txt_ColorSetting.Text == "")
            {
                MessageBox.Show("颜色设置不能为空"); return;
            }
            else if (!(System.Text.RegularExpressions.Regex.IsMatch(txt_ColorSetting.Text, @"^[0-1]{1,1}$")))
            {
                MessageBox.Show("颜色设置有误,请重新设置"); return;
            }
            else if (txt_knife.Text == "")
            {
                MessageBox.Show("铣削刀号不能为空"); return;
            }
            else if (!(System.Text.RegularExpressions.Regex.IsMatch(txt_knife.Text, @"^[1-6]{1,1}$")))
            {
                MessageBox.Show("铣削刀号输入有误,请重新输入"); return;
            }
            else if (txt_CutterDiameter.Text == "")
            {
                MessageBox.Show("刀具直径值不能为空"); return;
            }
            else if (txt_caoRevolutions.Text == "")
            {
                MessageBox.Show("铣槽主轴转数不能为空"); return;
            }
            else if (txt_caoPlane.Text == "")
            {
                MessageBox.Show("铣槽平面R点不能为空"); return;
            }
            else if (txt_yuanDepth.Text == "")
            {
                MessageBox.Show("铣圆深度Z不能为空"); return;
            }
            else if (txt_yuanCutting.Text == "")
            {
                MessageBox.Show("铣圆Z向首次切削W不能为空"); return;
            }
            else if (txt_yuanWidth.Text == "")
            {
                MessageBox.Show("铣圆XY宽度增量L不能为空"); return;
            }
            else if (txt_yuanSingleCutting.Text == "")
            {
                MessageBox.Show("铣圆Z向单次切削Q不能为空"); return;
            }
            else if (txt_yuanDistance.Text == "")
            {
                MessageBox.Show("铣圆预留距离V不能为空"); return;
            }
            else if (txt_yuanSpeed.Text == "")
            {
                MessageBox.Show("铣圆运行速度F不能为空"); return;
            }
            else if (txt_juDepth.Text == "")
            {
                MessageBox.Show("铣矩深度Z不能为空"); return;
            }
            else if (txt_juCutting.Text == "")
            {
                MessageBox.Show("铣矩Z像首次切削W不能为空"); return;
            }
            else if (txt_juWidth.Text == "")
            {
                MessageBox.Show("铣矩XY宽度增量L不能为空"); return;
            }
            else if (txt_juSingleCutting.Text == "")
            {
                MessageBox.Show("铣矩Z像单次切削Q不能为空"); return;
            }
            else if (txt_juDistance.Text == "")
            {
                MessageBox.Show("铣矩预留距离V不能为空"); return;
            }
            else if (txt_juSpeed.Text == "")
            {
                MessageBox.Show("铣矩运行速度F不能为空"); return;
            }
            else if (txt_X.Text == "")
            {
                MessageBox.Show("X轴对刀不能为空"); return;
            }
            else if (txt_Y.Text == "")
            {
                MessageBox.Show("Y轴对刀不能为空"); return;
            }
            else if (txt_Z.Text == "")
            {
                MessageBox.Show("Z轴对刀不能为空"); return;
            }
            dxcb = "22";
            #endregion
        }
        #region MAIN-MENU FILE
        // open a file via dialog
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            //判断所有参数是否为空
            //isNUllParameter();
            //if (dxcb!="")
            //{
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "DXF files (*.dxf)|*.dxf|SVG files (*.svg)|*.svg|gcode files (*.nc)|*.nc|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                loadFile(openFileDialog1.FileName);
                //fCTBCode.ForeColor = Color.White;
                generateGCode = fCTBCode.Text;
                fCTBCode.Text = "";
                isHeightMapApplied = false;
            }
            //    }
        }
        // handle MRU List
        private int MRUnumber = 20;
        private List<string> MRUlist = new List<string>();
        private void SaveRecentFile(string path)
        {
            //   recentToolStripMenuItem.DropDownItems.Clear();
            toolStripMenuItem2.DropDownItems.Clear();
            LoadRecentList(); //load list from file
            if (MRUlist.Contains(path)) //prevent duplication on recent list
                MRUlist.Remove(path);
            MRUlist.Insert(0, path);    //insert given path into list on top
                                        //keep list number not exceeded the given value
            while (MRUlist.Count > MRUnumber)
            { MRUlist.RemoveAt(MRUlist.Count - 1); }
            foreach (string item in MRUlist)
            {
                ToolStripMenuItem fileRecent = new ToolStripMenuItem(item, null, RecentFile_click);
                //           recentToolStripMenuItem.DropDownItems.Add(fileRecent);
                toolStripMenuItem2.DropDownItems.Add(fileRecent); //add the menu to "recent" menu
            }
            StreamWriter stringToWrite =
            new StreamWriter(System.Environment.CurrentDirectory + "\\Recent.txt");
            foreach (string item in MRUlist)
            { stringToWrite.WriteLine(item); }
            stringToWrite.Flush(); //write stream to file
            stringToWrite.Close(); //close the stream and reclaim memory
        }
        private void LoadRecentList()
        {
            MRUlist.Clear();
            try
            {
                StreamReader listToRead =
                new StreamReader(System.Environment.CurrentDirectory + "\\Recent.txt");
                string line;
                MRUlist.Clear();
                while ((line = listToRead.ReadLine()) != null) //read each line until end of file
                    MRUlist.Add(line); //insert to list
                listToRead.Close(); //close the stream
            }
            catch (Exception) { }
        }
        private void RecentFile_click(object sender, EventArgs e)
        {
            loadFile(sender.ToString());
        }

        private void loadFile(string fileName)
        {
            if (fileName.IndexOf("http") >= 0)
            {
                //tBURL.Text = fileName;
                return;
            }
            else
            {
                if (!File.Exists(fileName))
                {
                    MessageBox.Show("File not found: '" + fileName + "'");
                    return;
                }
            }
            Cursor.Current = Cursors.WaitCursor;

            pictureBox1.BackgroundImage = null;
            visuGCode.setPosMarker(0, 0);
            visuGCode.createMarkerPath(); ;
            String ext = Path.GetExtension(fileName).ToLower();
            if (ext == ".svg")
            { startConvertSVG(fileName); }
            else if (ext == ".dxf")
            { startConvertDXF(fileName); }
            else if (ext == ".nc")
            {
                tbFile.Text = fileName;
                loadGcode();
            }
            else if ((ext == ".bmp") || (ext == ".gif") || (ext == ".png") || (ext == ".jpg"))
            {
                if (_image_form == null)
                {
                    _image_form = new GCodeFromImage(true);
                    _image_form.FormClosed += formClosed_ImageToGCode;
                    _image_form.btnGenerate.Click += getGCodeFromImage;      // assign btn-click event
                }
                else
                {
                    _image_form.Visible = false;
                }
                _image_form.Show(this);
                _image_form.loadExtern(fileName);
            }
            SaveRecentFile(fileName);
            setLastLoadedFile("Data from file: " + fileName);

            if (ext == ".url")
            { getURL(fileName); }
            Cursor.Current = Cursors.Default;
            pBoxTransform.Reset();
        }

        private void setLastLoadedFile(string text)
        {
            lastLoadSource = text;
            if (_setup_form != null)
            { _setup_form.setLastLoadedFile(lastLoadSource); }
        }
        private void getURL(string filename)
        {
            var MyIni = new IniFile(filename);
            //tBURL.Text = MyIni.Read("URL", "InternetShortcut");
        }

        // drag and drop file or URL
        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string s = (string)e.Data.GetData(DataFormats.Text);
            if (files != null)
            {
                loadFile(files[0]);
            }
            else
            { }
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        public void reStartConvertSVG(object sender, EventArgs e)   // event from setup form//来自设置表单的事件
        {
            if (!isStreaming)
            {
                if (lastLoadSource.IndexOf("Clipboard") >= 0)
                { loadFromClipboard(); }
                else
                { loadFile(lastSource); }
            }
        }
        private string lastSource = "";
        private void startConvertSVG(string source)
        {
            lastSource = source;
            this.Cursor = Cursors.WaitCursor;
            string gcode = GCodeFromSVG.convertFromFile(source);
            if (gcode.Length > 2)
            {
                fCTBCode.Text = gcode;
                fCTBCode.UnbookmarkLine(fCTBCodeClickedLineLast);
                redrawGCodePath();
                SaveRecentFile(source);
                this.Text = appName + " | Source: " + source;
            }
            this.Cursor = Cursors.Default;
            updateControls();
        }

        private void startConvertDXF(string source)
        {
            lastSource = source;
            this.Cursor = Cursors.WaitCursor;
            string gcode = GCodeFromDXF.ConvertFile(source, txt_knife.Text);
            if (gcode.Length > 2)
            {
                fCTBCode.Text = gcode;
                fCTBCode.UnbookmarkLine(fCTBCodeClickedLineLast);
                redrawGCodePath();
                SaveRecentFile(source);
                //isFileLoaded = true;
                this.Text = appName + " | Source: " + source;
            }
            this.Cursor = Cursors.Default;
            updateControls();
        }

        bool blockRTBEvents = false;
        private void loadGcode()
        {
            if (File.Exists(tbFile.Text))
            {
                fCTBCode.UnbookmarkLine(fCTBCodeClickedLineLast);
                fCTBCodeClickedLineNow = 0;
                fCTBCodeClickedLineLast = 0;
                visuGCode.setPosMarker(0, 0);
                blockRTBEvents = true;
                fCTBCode.OpenFile(tbFile.Text);
                if (_serial_form.isLasermode && Properties.Settings.Default.ctrlReplaceEnable)
                {
                    if (Properties.Settings.Default.ctrlReplaceM3)
                    {
                        fCTBCode.Text = fCTBCode.Text.Replace("M3", "M4");
                        fCTBCode.Text = "(!!! Replaced M3 by M4 !!!)\r\n" + fCTBCode.Text.Replace("M03", "M04");
                    }
                    else
                    {
                        fCTBCode.Text = fCTBCode.Text.Replace("M4", "M3");
                        fCTBCode.Text = "(!!! Replaced M4 by M3 !!!)\r\n" + fCTBCode.Text.Replace("M04", "M03");
                    }
                }

                redrawGCodePath();
                blockRTBEvents = false;
                lbInfo.Text = "G-Code loaded";
                lbInfo.BackColor = SystemColors.Control;
                updateControls();
                SaveRecentFile(tbFile.Text);
                this.Text = appName + " | File: " + tbFile.Text;
            }
        }

        // save content from TextEditor (GCode) to file
        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "GCode|*.nc";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string txt = fCTBCode.Text;
                File.WriteAllText(sfd.FileName, txt);
            }
        }
        // save Properties.Settings.Default... to text-file
        private void saveMachineParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Machine Ini files (*.ini)|*.ini";
            sfd.FileName = "GRBL-Plotter.ini";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var MyIni = new IniFile(sfd.FileName);
                MyIni.WriteAll(_serial_form.GRBLSettings);
            }
        }
        // load Properties.Settings.Default... from text-file
        private void loadMachineParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "GRBL-Plotter.ini";
            openFileDialog1.Filter = "Machine Ini files (*.ini)|*.ini";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var MyIni = new IniFile(openFileDialog1.FileName);
                MyIni.ReadAll();
                loadSettings(sender, e);
            }
        }

        // switch language
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.language = "en";
            //ResourceManager LocRM = new ResourceManager("GRBL-Plotter.MainForm", typeof(MainForm).Assembly);
            MessageBox.Show("正在重启系统，请稍后");
            Process pr = Process.GetCurrentProcess();
            pr.Close();
            Application.Restart();
        }
        private void deutschToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.language = "de-DE";
            //ResourceManager LocRM = new ResourceManager("GRBL-Plotter.MainForm", typeof(MainForm).Assembly);
            MessageBox.Show("正在重启系统，请稍后");
            Process pr = Process.GetCurrentProcess();
            pr.Close();
            Application.Restart();
        }
        private void chineseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.language = "zh";
            //ResourceManager LocRM = new ResourceManager("GRBL-Plotter.MainForm", typeof(MainForm).Assembly);
            MessageBox.Show("正在重启系统，请稍后");
            Process pr = Process.GetCurrentProcess();
            pr.Close();
            Application.Restart();
        }
        #endregion
        #region MAIN-MENU GCode creation
        // open text creation form
        private void textWizzardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_text_form == null)
            {
                _text_form = new GCodeFromText();
                _text_form.FormClosed += formClosed_TextToGCode;
                _text_form.btnApply.Click += getGCodeFromText;      // assign btn-click event
            }
            else
            {
                _text_form.Visible = false;
            }
            _text_form.Show(this);
        }
        private void formClosed_TextToGCode(object sender, FormClosedEventArgs e)
        { _text_form = null; }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_image_form == null)
            {
                _image_form = new GCodeFromImage();
                _image_form.FormClosed += formClosed_ImageToGCode;
                _image_form.btnGenerate.Click += getGCodeFromImage;      // assign btn-click event
            }
            else
            {
                _image_form.Visible = false;
            }
            _image_form.Show(this);
        }
        private void formClosed_ImageToGCode(object sender, FormClosedEventArgs e)
        { _image_form = null; }

        private void createSimpleShapesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_shape_form == null)
            {
                _shape_form = new GCodeFromShape();
                _shape_form.FormClosed += formClosed_ShapeToGCode;
                _shape_form.btnApply.Click += getGCodeFromShape;      // assign btn-click event
            }
            else
            {
                _shape_form.Visible = false;
            }
            _shape_form.Show(this);
        }
        private void formClosed_ShapeToGCode(object sender, FormClosedEventArgs e)
        { _shape_form = null; }
        #endregion

        #region MAIN-MENU GCode Transform
        private void mirrorXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            pBoxTransform.Reset();
            fCTBCode.Text = visuGCode.transformGCodeMirror(GCodeVisuAndTransform.translate.MirrorX);
            Cursor.Current = Cursors.Default;
            updateGUI();
        }

        private void mirrorYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            pBoxTransform.Reset();
            fCTBCode.Text = visuGCode.transformGCodeMirror(GCodeVisuAndTransform.translate.MirrorY);
            Cursor.Current = Cursors.Default;
            updateGUI();
        }

        private void rotate90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            pBoxTransform.Reset();
            fCTBCode.Text = visuGCode.transformGCodeRotate(90);
            Cursor.Current = Cursors.Default;
            updateGUI();
        }

        private void rotate90ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            pBoxTransform.Reset();
            fCTBCode.Text = visuGCode.transformGCodeRotate(-90);
            Cursor.Current = Cursors.Default;
            updateGUI();
        }

        private void toolStrip_tb_rotate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)13)
            {
                double sizenew;
                if (Double.TryParse(toolStrip_tb_rotate.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out sizenew))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    pBoxTransform.Reset();
                    fCTBCode.Text = visuGCode.transformGCodeRotate(sizenew);
                    Cursor.Current = Cursors.Default;
                    updateGUI();
                }
                else
                {
                    MessageBox.Show("Not a valid number", "Attention");
                    toolStrip_tb_rotate.Text = "0.0";
                }
            }
        }

        private void toolStrip_tb_XY_scale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)13)
            {
                double size;
                if (Double.TryParse(toolStrip_tb_XY_scale.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out size))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    fCTBCode.Cursor = Cursors.WaitCursor;
                    pBoxTransform.Reset();
                    fCTBCode.Text = visuGCode.transformGCodeScale(size, size);
                    updateGUI();
                    fCTBCodeClickedLineNow = fCTBCodeClickedLineLast;
                    fCTBCodeMarkLine();
                    fCTBCode.Cursor = Cursors.IBeam;
                    Cursor.Current = Cursors.Default;
                    showChangedMessage = true;
                }
                else
                {
                    MessageBox.Show("Not a valid number", "Attention");
                    toolStrip_tb_XY_scale.Text = "100.00";
                }
                gCodeToolStripMenuItem.HideDropDown();
            }
        }

        private void toolStrip_tb_XY_X_scale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)13)
            {
                double sizenew;
                double sizeold = visuGCode.xyzSize.dimx;
                if (Double.TryParse(toolStrip_tb_XY_X_scale.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out sizenew))
                {
                    toolStrip_tb_XY_scale.Text = string.Format("{0:0.00000}", (100 * sizenew / sizeold));
                    toolStrip_tb_XY_scale_KeyDown(sender, e);
                }
                else
                {
                    MessageBox.Show("Not a valid number", "Attention");
                    toolStrip_tb_XY_X_scale.Text = string.Format("{0:0.00}", sizeold);
                }
                gCodeToolStripMenuItem.HideDropDown();
            }
        }

        private void toolStrip_tb_XY_Y_scale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)13)
            {
                double sizenew;
                double sizeold = visuGCode.xyzSize.dimy;
                if (Double.TryParse(toolStrip_tb_XY_Y_scale.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out sizenew))
                {
                    toolStrip_tb_XY_scale.Text = string.Format("{0:0.00000}", (100 * sizenew / sizeold));
                    toolStrip_tb_XY_scale_KeyDown(sender, e);
                }
                else
                {
                    MessageBox.Show("Not a valid number", "Attention");
                    toolStrip_tb_XY_Y_scale.Text = string.Format("{0:0.00}", sizeold);
                }
                gCodeToolStripMenuItem.HideDropDown();
            }
        }

        private void toolStrip_tb_X_scale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)13)
            {
                double size;
                if (Double.TryParse(toolStrip_tb_X_scale.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out size))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    fCTBCode.Cursor = Cursors.WaitCursor;
                    pBoxTransform.Reset();
                    fCTBCode.Text = visuGCode.transformGCodeScale(size, 100);
                    updateGUI();
                    fCTBCodeClickedLineNow = fCTBCodeClickedLineLast;
                    fCTBCodeMarkLine();
                    fCTBCode.Cursor = Cursors.IBeam;
                    Cursor.Current = Cursors.Default;
                    showChangedMessage = true;
                }
                else
                {
                    MessageBox.Show("Not a valid number", "Attention");
                    toolStrip_tb_X_scale.Text = "100.00";
                }
                gCodeToolStripMenuItem.HideDropDown();
            }
        }

        private void toolStrip_tb_X_X_scale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)13)
            {
                double sizenew;
                double sizeold = visuGCode.xyzSize.dimx;
                if (Double.TryParse(toolStrip_tb_X_X_scale.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out sizenew))
                {
                    if (Properties.Settings.Default.rotarySubstitutionEnable)
                    {
                        double length = (float)Properties.Settings.Default.rotarySubstitutionDiameter * Math.PI;
                        sizenew = (float)Properties.Settings.Default.rotarySubstitutionScale * sizenew / length;
                    }
                    toolStrip_tb_X_scale.Text = string.Format("{0:0.00000}", (100 * sizenew / sizeold));
                    toolStrip_tb_X_scale_KeyDown(sender, e);
                }
                else
                {
                    MessageBox.Show("Not a valid number", "Attention");
                    toolStrip_tb_X_X_scale.Text = string.Format("{0:0.00}", sizeold);
                }
                gCodeToolStripMenuItem.HideDropDown();
            }
        }

        private void toolStrip_tb_X_A_scale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)13)
            {
                double sizenew;
                double sizeold = visuGCode.xyzSize.dimx;
                if (Double.TryParse(toolStrip_tb_X_A_scale.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out sizenew))
                {
                    sizenew = (float)Properties.Settings.Default.rotarySubstitutionScale * sizenew / 360;
                    toolStrip_tb_X_scale.Text = string.Format("{0:0.00000}", (100 * sizenew / sizeold));
                    toolStrip_tb_X_scale_KeyDown(sender, e);
                }
                else
                {
                    MessageBox.Show("Not a valid number", "Attention");
                    toolStrip_tb_X_A_scale.Text = string.Format("{0:0.00}", sizeold);
                }
                gCodeToolStripMenuItem.HideDropDown();
            }
        }

        private void toolStrip_tb_Y_scale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)13)
            {
                double size;
                if (Double.TryParse(toolStrip_tb_Y_scale.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out size))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    fCTBCode.Cursor = Cursors.WaitCursor;
                    pBoxTransform.Reset();
                    fCTBCode.Text = visuGCode.transformGCodeScale(100, size);
                    updateGUI();
                    fCTBCodeClickedLineNow = fCTBCodeClickedLineLast;
                    fCTBCodeMarkLine();
                    fCTBCode.Cursor = Cursors.IBeam;
                    Cursor.Current = Cursors.Default;
                    showChangedMessage = true;
                }
                else
                {
                    MessageBox.Show("Not a valid number", "Attention");
                    toolStrip_tb_Y_scale.Text = "100.00";
                }
                gCodeToolStripMenuItem.HideDropDown();
            }
        }

        private void toolStrip_tb_Y_Y_scale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)13)
            {
                double sizenew;
                double sizeold = visuGCode.xyzSize.dimy;
                if (Double.TryParse(toolStrip_tb_Y_Y_scale.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out sizenew))
                {
                    if (Properties.Settings.Default.rotarySubstitutionEnable)
                    {
                        double length = (float)Properties.Settings.Default.rotarySubstitutionDiameter * Math.PI;
                        sizenew = (float)Properties.Settings.Default.rotarySubstitutionScale * sizenew / length;
                    }
                    toolStrip_tb_Y_scale.Text = string.Format("{0:0.00000}", (100 * sizenew / sizeold));
                    toolStrip_tb_Y_scale_KeyDown(sender, e);
                }
                else
                {
                    MessageBox.Show("Not a valid number", "Attention");
                    toolStrip_tb_Y_Y_scale.Text = string.Format("{0:0.00}", sizeold);
                }
                gCodeToolStripMenuItem.HideDropDown();
            }
        }

        private void toolStrip_tb_Y_A_scale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)13)
            {
                double sizenew;
                double sizeold = visuGCode.xyzSize.dimy;
                if (Double.TryParse(toolStrip_tb_Y_A_scale.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out sizenew))
                {
                    sizenew = (float)Properties.Settings.Default.rotarySubstitutionScale * sizenew / 360;
                    toolStrip_tb_Y_scale.Text = string.Format("{0:0.00000}", (100 * sizenew / sizeold));
                    toolStrip_tb_Y_scale_KeyDown(sender, e);
                }
                else
                {
                    MessageBox.Show("Not a valid number", "Attention");
                    toolStrip_tb_Y_A_scale.Text = string.Format("{0:0.00}", sizeold);
                }
                gCodeToolStripMenuItem.HideDropDown();
            }
        }

        private void toolStrip_tb_rotary_diameter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)13)
            {
                double sizenew;
                double sizeold = visuGCode.xyzSize.dimx;
                if (Double.TryParse(toolStrip_tb_rotary_diameter.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out sizenew))
                {
                    Properties.Settings.Default.rotarySubstitutionDiameter = (decimal)sizenew;
                    string tmp = string.Format("Calculating rotary angle depending on part diameter ({0:0.00} units) and desired size.\r\nSet part diameter in Setup - Control.", Properties.Settings.Default.rotarySubstitutionDiameter);
                    skaliereAufXUnitsToolStripMenuItem.ToolTipText = tmp;
                    skaliereAufYUnitsToolStripMenuItem.ToolTipText = tmp;
                }
                else
                {
                    MessageBox.Show("Not a valid number", "Attention");
                    toolStrip_tb_rotary_diameter.Text = string.Format("{0:0.00}", Properties.Settings.Default.rotarySubstitutionDiameter);
                }
                gCodeToolStripMenuItem.HideDropDown();
            }
        }

        private void ersetzteG23DurchLinienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            pBoxTransform.Reset();
            fCTBCode.Text = visuGCode.replaceG23();
            Cursor.Current = Cursors.Default;
            updateGUI();
        }

        private void updateGUI()
        {
            updateDrawing();
            lbDimension.Text = visuGCode.xyzSize.getMinMaxString(); //String.Format("X:[ {0:0.0} | {1:0.0} ];    Y:[ {2:0.0} | {3:0.0} ];    Z:[ {4:0.0} | {5:0.0} ]", visuGCode.xyzSize.minx, visuGCode.xyzSize.maxx, visuGCode.xyzSize.miny, visuGCode.xyzSize.maxy, visuGCode.xyzSize.minz, visuGCode.xyzSize.maxz);
            lbDimension.Select(0, 0);
            toolStrip_tb_XY_X_scale.Text = string.Format("{0:0.000}", visuGCode.xyzSize.dimx);
            toolStrip_tb_X_X_scale.Text = string.Format("{0:0.000}", visuGCode.xyzSize.dimx);
            toolStrip_tb_XY_Y_scale.Text = string.Format("{0:0.000}", visuGCode.xyzSize.dimy);
            toolStrip_tb_Y_Y_scale.Text = string.Format("{0:0.000}", visuGCode.xyzSize.dimy);
        }
        #endregion

        #region MAIN-MENU Machine control
        private void controlStreamingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_serial_form.isGrblVers0)
            {
                if (_streaming_form2 != null)
                    _streaming_form2.Visible = false;
                if (_streaming_form == null)
                {
                    _streaming_form = new ControlStreamingForm();
                    _streaming_form.RaiseOverrideEvent += OnRaiseOverrideEvent;      // assign  event
                    _streaming_form.show_value_FR(actualFR);
                    _streaming_form.show_value_SS(actualSS);
                }
                else
                {
                    _streaming_form.Visible = false;
                }
                _streaming_form.Show(this);
            }
            else
            {
                if (_streaming_form != null)
                    _streaming_form.Visible = false;
                if (_streaming_form2 == null)
                {
                    _streaming_form2 = new ControlStreamingForm2();
                    _streaming_form2.RaiseOverrideEvent += OnRaiseOverrideMessage;      // assign  event
                }
                else
                {
                    _streaming_form2.Visible = false;
                }
                _streaming_form2.Show(this);
            }
        }
        private void control2ndGRBLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_2ndGRBL_form == null)
            {
                _2ndGRBL_form = new Control2ndGRBL(_serial_form2);
                if (_serial_form2 == null)
                {
                    _serial_form2 = new ControlSerialForm("COM Tool changer", 2);
                    _serial_form2.Show(this);
                }
                _2ndGRBL_form.set2ndSerial(_serial_form2);
                _serial_form.set2ndSerial(_serial_form2);
                _2ndGRBL_form.FormClosed += formClosed_2ndGRBLForm;
            }
            else
            {
                _2ndGRBL_form.Visible = false;
            }
            _2ndGRBL_form.Show(this);
        }
        private void formClosed_2ndGRBLForm(object sender, FormClosedEventArgs e)
        { _2ndGRBL_form = null; }
        // open Camera form
        private void cameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_camera_form == null)
            {
                _camera_form = new ControlCameraForm();
                _camera_form.FormClosed += formClosed_CameraForm;
                _camera_form.RaiseXYEvent += OnRaiseCameraClickEvent;
            }
            else
            {
                _camera_form.Visible = false;
            }
            _camera_form.Show(this);
        }
        private void formClosed_CameraForm(object sender, FormClosedEventArgs e)
        { _camera_form = null; }
        // Height Map
        private void heightMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_heightmap_form == null)
            {
                _heightmap_form = new ControlHeightMapForm();
                _heightmap_form.FormClosed += formClosed_HeightmapForm;
                _heightmap_form.btnStartHeightScan.Click += getGCodeFromHeightMap;      // assign btn-click event
                _heightmap_form.loadHeightMapToolStripMenuItem.Click += loadHeightMap;
                _heightmap_form.btnApply.Click += applyHeightMap;
                //                _heightmap_form.btnApply.Click += applyHeightMap;
                _heightmap_form.RaiseXYZEvent += OnRaisePositionClickEvent;

            }
            else
            {
                _heightmap_form.Visible = false;
            }
            _heightmap_form.Show(this);
        }
        private void formClosed_HeightmapForm(object sender, FormClosedEventArgs e)
        {
            _heightmap_form = null;
            GCodeVisuAndTransform.clearHeightMap();
            _serial_form.stopStreaming();
        }

        // open Setup form
        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_setup_form == null)
            {
                _setup_form = new ControlSetupForm();
                _setup_form.FormClosed += formClosed_SetupForm;
                _setup_form.btnApplyChangings.Click += loadSettings;
                _setup_form.btnReloadFile.Click += reStartConvertSVG;
                _setup_form.setLastLoadedFile(lastLoadSource);
            }
            else
            {
                _setup_form.Visible = false;
            }
            _setup_form.Show(this);
        }
        private void formClosed_SetupForm(object sender, FormClosedEventArgs e)
        { loadSettings(sender, e); _setup_form = null; }
        #endregion
        // open About form
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAbout = new AboutForm();
            frmAbout.ShowDialog();
        }



        private void showLaserMode()
        {
            if (!_serial_form.isGrblVers0 && _serial_form.isLasermode)
            {
                lbInfo.Text = "Laser Mode active $32=1";
                lbInfo.BackColor = Color.Fuchsia;
            }
            else
            {
                lbInfo.Text = "Laser Mode not active $32=0";
                lbInfo.BackColor = Color.Lime;
            }
        }

        #region Streaming
        // handle file streaming
        TimeSpan elapsed;               //elapsed time from file burnin
        DateTime timeInit;              //time start to burning file
        private int signalResume = 0;   // blinking button
        private int signalLock = 0;     // blinking button
        private int signalPlay = 0;     // blinking button
        private bool isStreaming = false;
        private bool isStreamingPause = false;
        private bool isStreamingCheck = false;
        private bool isStreamingOk = true;
        private void OnRaiseStreamEvent(object sender, StreamEventArgs e)
        {
            int cPrgs = (int)Math.Max(0, Math.Min(100, e.CodeProgress));
            int bPrgs = (int)Math.Max(0, Math.Min(100, e.BuffProgress));
            pbFile.Value = cPrgs;
            pbBuffer.Value = bPrgs;
            lblFileProgress.Text = string.Format("Progress {0:0.0}%", e.CodeProgress);
            fCTBCode.Selection = fCTBCode.GetLine(e.CodeLine);
            fCTBCodeClickedLineNow = e.CodeLine - 1;
            fCTBCodeMarkLine();
            fCTBCode.DoCaretVisible();

            if (e.Status == grblStreaming.lasermode)
            {
                showLaserMode();
            }
            if (e.Status == grblStreaming.reset)
            {
                flagResetOffset = true;
                isStreaming = false;
                isStreamingCheck = false;
                showLaserMode();
                updateControls();
            }
            if (e.Status == grblStreaming.error)
            {
                pbFile.ForeColor = Color.Red;
                lbInfo.Text = "Error before line " + e.CodeLine.ToString();
                lbInfo.BackColor = Color.Fuchsia;
                fCTBCode.BookmarkLine(e.CodeLine - 1);
                fCTBCode.DoSelectionVisible();
                fCTBCode.CurrentLineColor = Color.Red;
                isStreamingOk = false;
            }
            if ((e.Status == grblStreaming.ok) && !isStreamingCheck)
            {
                updateControls();
                lbInfo.Text = "Send G-Code (" + e.CodeLine.ToString() + ")";
                lbInfo.BackColor = Color.Lime;
                signalPlay = 0;
                btnStreamStart.BackColor = SystemColors.Control;
                //                btnStreamPause.BackColor = SystemColors.Control; 
            }
            if (e.Status == grblStreaming.finish)
            {
                if (isStreamingOk)
                {
                    if (isStreamingCheck)
                    { lbInfo.Text = "Finish checking G-Code"; }
                    else
                    { lbInfo.Text = "Finish sending G-Code"; }
                    lbInfo.BackColor = Color.Lime;
                    pbFile.Value = 0;
                    pbBuffer.Value = 0;
                }
                isStreaming = false; isStreamingCheck = false;
                btnStreamStart.Image = Properties.Resources.btn_play;
                btnStreamStart.Enabled = true;
                btnStreamCheck.Enabled = true;
                picBoxCopy = 0;                     // don't show background image anymore
                pictureBox1.BackgroundImage = null;
                updateControls();
            }
            if (e.Status == grblStreaming.waitidle)
            {
                updateControls(true);
                btnStreamStart.Image = Properties.Resources.btn_play;
                isStreamingPause = true;
                lbInfo.Text = "Wait for IDLE, then pause (" + e.CodeLine.ToString() + ")";
                lbInfo.BackColor = Color.Yellow;
            }
            if (e.Status == grblStreaming.pause)
            {
                updateControls(true);
                btnStreamStart.Image = Properties.Resources.btn_play;
                isStreamingPause = true;
                lbInfo.Text = "Pause streaming - press play (" + e.CodeLine.ToString() + ")";
                signalPlay = 1;
                lbInfo.BackColor = Color.Yellow;
            }
            if (e.Status == grblStreaming.toolchange)
            {
                updateControls();
                btnStreamStart.Image = Properties.Resources.btn_play;
                lbInfo.Text = "Tool change...";
                lbInfo.BackColor = Color.Yellow;
                cBTool.Checked = _serial_form.toolInSpindle;
            }

            if (e.Status == grblStreaming.stop)
            {
                lbInfo.Text = " STOP streaming (" + e.CodeLine.ToString() + ")";
                lbInfo.BackColor = Color.Fuchsia;
            }
            lastLabelInfoText = lbInfo.Text;
            lbInfo.Text += overrideMessage;
        }
        private void btnStreamStart_Click(object sender, EventArgs e)
        {
            if (fCTBCode.LinesCount > 1)
            {
                if (!isStreaming)
                {
                    if (_streaming_form != null)
                    {
                        //                        _streaming_form.cBOverrideFREnable.Checked = false;
                        //                        _streaming_form.cBOverrideSSEnable.Checked = false;
                    }
                    isStreaming = true;
                    isStreamingPause = false;
                    isStreamingCheck = false;
                    isStreamingOk = true;
                    updateControls();
                    timeInit = DateTime.UtcNow;
                    elapsed = TimeSpan.Zero;
                    lbInfo.Text = "Send G-Code";
                    lbInfo.BackColor = Color.Lime;
                    for (int i = 0; i < fCTBCode.LinesCount; i++)
                        fCTBCode.UnbookmarkLine(i);
                    lblElapsed.Text = "Time " + elapsed.ToString(@"hh\:mm\:ss");
                    _serial_form.startStreaming(fCTBCode.Lines);
                    btnStreamStart.Image = Properties.Resources.btn_pause;
                    btnStreamCheck.Enabled = false;
                    onPaint_setBackground();
                }
                else
                {
                    if (!isStreamingPause)
                    {
                        btnStreamStart.Image = Properties.Resources.btn_play;
                        _serial_form.pauseStreaming();
                        isStreamingPause = true;
                    }
                    else
                    {
                        btnStreamStart.Image = Properties.Resources.btn_pause;
                        _serial_form.pauseStreaming();
                        isStreamingPause = false;
                    }
                }
            }
        }
        private void btnStreamCheck_Click(object sender, EventArgs e)
        {
            if ((fCTBCode.LinesCount > 1) && (!isStreaming))
            {
                isStreaming = true;
                isStreamingCheck = true;
                isStreamingOk = true;
                updateControls();
                timeInit = DateTime.UtcNow;
                elapsed = TimeSpan.Zero;
                lbInfo.Text = "Check G-Code";
                lbInfo.BackColor = SystemColors.Control;
                for (int i = 0; i < fCTBCode.LinesCount; i++)
                    fCTBCode.UnbookmarkLine(i);
                _serial_form.startStreaming(fCTBCode.Lines, true);
                btnStreamStart.Enabled = false;
                onPaint_setBackground();
            }
        }
        private void btnStreamStop_Click(object sender, EventArgs e)
        {
            picBoxCopy = 0;                 // don't show background image anymore
            pictureBox1.BackgroundImage = null;
            btnStreamStart.Image = Properties.Resources.btn_play;
            btnStreamStart.Enabled = true;
            btnStreamCheck.Enabled = true;
            _serial_form.stopStreaming();
            if (isStreaming || isStreamingCheck)
            {
                lbInfo.Text = " STOP streaming (" + (fCTBCodeClickedLineNow + 1).ToString() + ")";
                lbInfo.BackColor = Color.Fuchsia;
            }
            isStreaming = false;
            isStreamingCheck = false;
            pbFile.Value = 0;
            pbBuffer.Value = 0;
            signalPlay = 0;
            updateControls();
        }
        private void btnStreamPause_Click(object sender, EventArgs e)
        { _serial_form.pauseStreaming(); }
        #endregion

        // handle event from create Height Map form
        private void getGCodeFromHeightMap(object sender, EventArgs e)
        {
            if (!isStreaming && _serial_form.serialPortOpen)
            {
                if (_heightmap_form.scanStarted)
                {
                    string[] commands = _heightmap_form.getCode.ToString().Split('\r');
                    _serial_form.isHeightProbing = true;
                    foreach (string cmd in commands)
                        sendCommand(cmd);
                    visuGCode.drawHeightMap(_heightmap_form.Map);
                }
                else
                {
                    _serial_form.stopStreaming();
                }
                isHeightMapApplied = false;
            }
        }
        private void loadHeightMap(object sender, EventArgs e)
        {
            visuGCode.drawHeightMap(_heightmap_form.Map);
            visuGCode.createMarkerPath();
            visuGCode.createImagePath();
            pictureBox1.BackgroundImage = null;
            pictureBox1.Invalidate();
            isHeightMapApplied = false;
        }

        private bool isHeightMapApplied = false;
        private StringBuilder codeBeforeHeightMap = new StringBuilder();
        private void applyHeightMap(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (!isHeightMapApplied)
            {
                codeBeforeHeightMap.Clear();
                foreach (string codeline in fCTBCode.Lines)
                {
                    if (codeline.Length > 0)
                        codeBeforeHeightMap.AppendLine(codeline);
                }
                visuGCode.getGCodeLines(fCTBCode.Lines);
                fCTBCode.Text = visuGCode.applyHeightMap(fCTBCode.Lines, _heightmap_form.Map);
                updateGUI();
                _heightmap_form.setBtnApply(isHeightMapApplied);
                isHeightMapApplied = true;
            }
            else
            {
                fCTBCode.Text = codeBeforeHeightMap.ToString();
                updateGUI();
                _heightmap_form.setBtnApply(isHeightMapApplied);
                isHeightMapApplied = false;
            }
            Cursor.Current = Cursors.Default;
        }


        // handle event from create Text form
        private void getGCodeFromText(object sender, EventArgs e)
        {
            if (!isStreaming)
            {
                picBoxCopy = 0;                 // don't show background image anymore
                pictureBox1.BackgroundImage = null;
                fCTBCode.Text = _text_form.textGCode;
                redrawGCodePath();
                updateControls();
            }
        }
        // handle event from create Text form
        private void getGCodeFromShape(object sender, EventArgs e)
        {
            if (!isStreaming)
            {
                picBoxCopy = 0;                     // don't show background image anymore
                pictureBox1.BackgroundImage = null;
                fCTBCode.Text = _shape_form.shapeGCode;
                redrawGCodePath();
                updateControls();
            }
        }
        // handle event from create Image form
        private void getGCodeFromImage(object sender, EventArgs e)
        {
            if (!isStreaming)
            {
                picBoxCopy = 0;                 // don't show background image anymore
                pictureBox1.BackgroundImage = null;
                fCTBCode.Text = _image_form.imageGCode;
                redrawGCodePath();
                updateControls();
            }
        }
        // update 500ms
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if (isStreaming)
            {
                elapsed = DateTime.UtcNow - timeInit;
                lblElapsed.Text = "Time " + elapsed.ToString(@"hh\:mm\:ss");
            }
            else
            {
                if (updateDrawingPath && visuGCode.containsG91Command())
                {
                    redrawGCodePath();
                    pictureBox1.Invalidate(); // will be called by parent function
                }
                updateDrawingPath = false;
            }
            if (signalResume > 0)   // activate blinking buttob
            {
                if ((signalResume++ % 2) > 0) btnResume.BackColor = Color.Yellow;
                else btnResume.BackColor = SystemColors.Control;
            }
            if (signalLock > 0) // activate blinking buttob
            {
                if ((signalLock++ % 2) > 0) btnKillAlarm.BackColor = Color.Yellow;
                else btnKillAlarm.BackColor = SystemColors.Control;
            }
            if (signalPlay > 0) // activate blinking buttob
            {
                if ((signalPlay++ % 2) > 0) btnStreamStart.BackColor = Color.Yellow;
                else btnStreamStart.BackColor = SystemColors.Control;
            }
        }

        // handle positon click event from camera form
        private void OnRaisePositionClickEvent(object sender, XYZEventArgs e)
        {
            if (e.Command.IndexOf("G91") >= 0)
            {
                string final = e.Command;
                if (e.PosX != null)
                    final += string.Format(" X{0}", gcode.frmtNum((float)e.PosX));
                if (e.PosY != null)
                    final += string.Format(" Y{0}", gcode.frmtNum((float)e.PosY));
                if (e.PosZ != null)
                    final += string.Format(" Z{0}", gcode.frmtNum((float)e.PosZ));
                sendCommand(final.Replace(',', '.'), true);
            }
        }
        private void OnRaiseCameraClickEvent(object sender, XYEventArgs e)
        {
            if (e.Command == "a")
            { routeTransformCode((float)e.PosX); }
            else
            {
                double realStepX = Math.Round(e.PosX, 3);
                double realStepY = Math.Round(e.PosY, 3);
                int speed = 1000;
                string s = "";
                if (e.Command == "G92")
                {
                    s = String.Format(e.Command + " X{0} Y{1}", realStepX, realStepY).Replace(',', '.');
                    sendCommand(s);
                }
                else
                {
                    speed = 100 + (int)Math.Sqrt(realStepX * realStepX + realStepY * realStepY) * 120;
                    s = String.Format("F{0} " + e.Command + " X{1} Y{2}", speed, realStepX, realStepY).Replace(',', '.');
                    sendCommand(s, true);
                }

            }
        }
        public void routeTransformCode(float angle)
        {
            fCTBCode.Text = visuGCode.transformGCodeRotate((double)angle);
            updateGUI();
            return;
        }


        #region GUI Objects

        private void btnOffsetApply_Click(object sender, EventArgs e)
        {
            //groupBox6.Width += 20 ;
            Cursor.Current = Cursors.WaitCursor;
            pBoxTransform.Reset();
            double offsetx = 0, offsety = 0;
            if (!Double.TryParse(tbOffsetX.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out offsetx))
            {
                MessageBox.Show("Not a valid number", "Attention");
                tbOffsetX.Text = string.Format("{0:0.00}", offsetx);
            }
            if (!Double.TryParse(tbOffsetY.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out offsety))
            {
                MessageBox.Show("Not a valid number", "Attention");
                tbOffsetY.Text = string.Format("{0:0.00}", offsety);
            }
            if (fCTBCode.Lines.Count > 1)
            {
                fCTBCode.Cursor = Cursors.WaitCursor;
                if (rBOrigin1.Checked) { fCTBCode.Text = visuGCode.transformGCodeOffset(-offsetx, -offsety, GCodeVisuAndTransform.translate.Offset1); }
                if (rBOrigin2.Checked) { fCTBCode.Text = visuGCode.transformGCodeOffset(-offsetx, -offsety, GCodeVisuAndTransform.translate.Offset2); }
                if (rBOrigin3.Checked) { fCTBCode.Text = visuGCode.transformGCodeOffset(-offsetx, -offsety, GCodeVisuAndTransform.translate.Offset3); }
                if (rBOrigin4.Checked) { fCTBCode.Text = visuGCode.transformGCodeOffset(-offsetx, -offsety, GCodeVisuAndTransform.translate.Offset4); }
                if (rBOrigin5.Checked) { fCTBCode.Text = visuGCode.transformGCodeOffset(-offsetx, -offsety, GCodeVisuAndTransform.translate.Offset5); }
                if (rBOrigin6.Checked) { fCTBCode.Text = visuGCode.transformGCodeOffset(-offsetx, -offsety, GCodeVisuAndTransform.translate.Offset6); }
                if (rBOrigin7.Checked) { fCTBCode.Text = visuGCode.transformGCodeOffset(-offsetx, -offsety, GCodeVisuAndTransform.translate.Offset7); }
                if (rBOrigin8.Checked) { fCTBCode.Text = visuGCode.transformGCodeOffset(-offsetx, -offsety, GCodeVisuAndTransform.translate.Offset8); }
                if (rBOrigin9.Checked) { fCTBCode.Text = visuGCode.transformGCodeOffset(-offsetx, -offsety, GCodeVisuAndTransform.translate.Offset9); }
                updateDrawing();
                fCTBCodeClickedLineNow = fCTBCodeClickedLineLast;
                fCTBCodeClickedLineLast = 0;
                fCTBCodeMarkLine();
                fCTBCode.Cursor = Cursors.IBeam;
                showChangedMessage = true;
            }
            Cursor.Current = Cursors.Default;
        }
        // Setup Custom Buttons during loadSettings()
        string[] btnCustomCommand = new string[9];
        private void setCustomButton(Button btn, string text)
        {
            int index = Convert.ToUInt16(btn.Name.Substring("btnCustom".Length));
            string[] parts = text.Split('|');
            if (parts.Length > 1)
            {
                btn.Text = parts[0];
                if (File.Exists(parts[1]))
                { toolTip1.SetToolTip(btn, parts[0] + "\r\nFile: " + parts[1] + "\r\n" + File.ReadAllText(parts[1])); }
                else
                { toolTip1.SetToolTip(btn, parts[0] + "\r\n" + parts[1]); }
                btnCustomCommand[index] = parts[1];
            }
            else
                btnCustomCommand[index] = "";
        }
        private void btnCustomButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int index = Convert.ToUInt16(clickedButton.Name.Substring("btnCustom".Length));
            string btnCmd = btnCustomCommand[index];
            string[] commands;
            if (File.Exists(btnCmd))
            {
                string fileCmd = File.ReadAllText(btnCmd);
                _serial_form.addToLog("file: " + btnCmd);
                commands = fileCmd.Split('\n');
            }
            else
            {
                commands = btnCustomCommand[index].Split(';');
            }
            foreach (string cmd in commands)
                sendCommand(cmd.Trim());
        }


        // virtualJoystic sends two step-width-values per second. One position should be reached before next command
        // speed (units/min) = 2 * stepsize * 60 * factor (to compensate speed-ramps)
        private void virtualJoystickXY_JoyStickEvent(object sender, JogEventArgs e)
        {
            int indexX = Math.Abs(e.JogPosX);
            int indexY = Math.Abs(e.JogPosY);
            int dirX = Math.Sign(e.JogPosX);
            int dirY = Math.Sign(e.JogPosY);
            int speed = (int)Math.Max(joystickXYSpeed[indexX], joystickXYSpeed[indexY]);
            String strX = gcode.frmtNum(joystickXYStep[indexX] * dirX);
            String strY = gcode.frmtNum(joystickXYStep[indexY] * dirY);
            String s = "";
            if (speed > 0)
            {
                if (e.JogPosX == 0)
                    s = String.Format("G91 Y{0} F{1}", strY, speed).Replace(',', '.');
                else if (e.JogPosY == 0)
                    s = String.Format("G91 X{0} F{1}", strX, speed).Replace(',', '.');
                else
                    s = String.Format("G91 X{0} Y{1} F{2}", strX, strY, speed).Replace(',', '.');
                sendCommand(s, true);
            }
        }
        private void virtualJoystickXY_Enter(object sender, EventArgs e)
        { if (_serial_form.isGrblVers0) sendCommand("G91G1F100"); }
        private void virtualJoystickXY_Leave(object sender, EventArgs e)
        { if (_serial_form.isGrblVers0) sendCommand("G90"); }
        private void virtualJoystickZ_JoyStickEvent(object sender, JogEventArgs e)
        {
            int indexZ = Math.Abs(e.JogPosY);
            int dirZ = Math.Sign(e.JogPosY);
            int speed = (int)joystickZSpeed[indexZ];
            String strZ = gcode.frmtNum(joystickZStep[indexZ] * dirZ);
            if (speed > 0)
            {
                String s = String.Format("G91 Z{0} F{1}", strZ, speed).Replace(',', '.');
                sendCommand(s, true);
            }
        }
        private void virtualJoystickA_JoyStickEvent(object sender, JogEventArgs e)
        {
            int indexZ = Math.Abs(e.JogPosY);
            int dirZ = Math.Sign(e.JogPosY);
            int speed = (int)joystickZSpeed[indexZ];
            String strZ = gcode.frmtNum(joystickZStep[indexZ] * dirZ);
            if (speed > 0)
            {
                String s = String.Format("G91 {0}{1} F{2}", ctrl4thName, strZ, speed).Replace(',', '.');
                sendCommand(s, true);
            }
        }

        // Spindle and coolant
        private void cBSpindle_CheckedChanged(object sender, EventArgs e)
        {
            if (cBSpindle.Checked)
            { sendCommand("M3 S" + tBSpeed.Text); }
            else
            { sendCommand("M5"); }
        }
        private void cBCoolant_CheckedChanged(object sender, EventArgs e)
        {
            if (cBCoolant.Checked)
            { sendCommand("M8"); }
            else
            { sendCommand("M9"); }
        }
        private void btnHome_Click(object sender, EventArgs e)
        { sendCommand("$H"); }
        private void btnZeroX_Click(object sender, EventArgs e)
        { sendCommand("G92 X0"); }
        private void btnZeroY_Click(object sender, EventArgs e)
        { sendCommand("G92 Y0"); }
        private void btnZeroZ_Click(object sender, EventArgs e)
        { sendCommand("G92 Z0"); }
        private void btnZeroA_Click(object sender, EventArgs e)
        { sendCommand("G92 " + ctrl4thName + "0"); }
        private void btnZeroXY_Click(object sender, EventArgs e)
        { sendCommand("G92 X0 Y0"); }
        private void btnZeroXYZ_Click(object sender, EventArgs e)
        { sendCommand("G92 X0 Y0 Z0"); }

        private void btnJogX_Click(object sender, EventArgs e)
        { sendCommand("G90 X0 F" + joystickXYSpeed[5].ToString(), true); }
        private void btnJogY_Click(object sender, EventArgs e)
        { sendCommand("G90 Y0 F" + joystickXYSpeed[5].ToString(), true); }
        private void btnJogZ_Click(object sender, EventArgs e)
        { sendCommand("G90 Z0 F" + joystickZSpeed[5].ToString(), true); }
        private void btnJogZeroA_Click(object sender, EventArgs e)
        { sendCommand("G90 " + ctrl4thName + "0 F" + joystickZSpeed[5].ToString(), true); }
        private void btnJogXY_Click(object sender, EventArgs e)
        { sendCommand("G90 X0 Y0 F" + joystickXYSpeed[5].ToString(), true); }
        private void btnJogStop_Click(object sender, EventArgs e)
        { sendRealtimeCommand(133); }    //0x85

        private void btnReset_Click(object sender, EventArgs e)
        {
            _serial_form.grblReset();
            pbFile.Value = 0;
            signalResume = 0;
            signalLock = 0;
            signalPlay = 0;
            btnResume.BackColor = SystemColors.Control;
            lbInfo.Text = "";
            lbInfo.BackColor = SystemColors.Control;
            cBSpindle.Checked = false;
            cBCoolant.Checked = false;
            updateControls();
        }
        private void btnFeedHold_Click(object sender, EventArgs e)
        {
            sendRealtimeCommand('!');
            signalResume = 1;
            updateControls(true);
        }
        private void btnResume_Click(object sender, EventArgs e)
        {
            sendRealtimeCommand('~');
            btnResume.BackColor = SystemColors.Control;
            signalResume = 0;
            lbInfo.Text = "";
            lbInfo.BackColor = SystemColors.Control;
            updateControls();
        }
        private void btnKillAlarm_Click(object sender, EventArgs e)
        {
            sendCommand("$X");
            signalLock = 0;
            btnKillAlarm.BackColor = SystemColors.Control;
            lbInfo.Text = "";
            lbInfo.BackColor = SystemColors.Control;
            updateControls();
        }

        #endregion


        /// <summary>
        /// Handling of RichTextBox rtBCode
        /// </summary>
        bool showChangedMessage = true;     // show Message if TextChanged
        int rtbSize = 0;
        private void rtbCode_TextChanged(object sender, EventArgs e)
        {
            if (!blockRTBEvents)
            {
                int rtbActualSize = fCTBCode.LinesCount;
                if (Math.Abs(rtbActualSize - rtbSize) > 20)     // Highlight / Redraw after huge change
                {
                    redrawGCodePath();
                    showChangedMessage = true;
                }
                else
                {
                    if (showChangedMessage)
                    {
                        lbInfo.Text = "G-Code was changed";
                        lbInfo.BackColor = Color.Orange;
                        if (Math.Abs(rtbActualSize - rtbSize) > 20)     // Highlight / Redraw after huge change
                            redrawGCodePath();
                    }
                }
                rtbSize = rtbActualSize;
            }
        }

        public GCodeVisuAndTransform visuGCode = new GCodeVisuAndTransform();
        // Refresh drawing path in GCodeVisuAndTransform by applying no transform
        private void redrawGCodePath()
        {
            //            visuGCode.transformGCode(fCTBCode.Lines, 100, 0, GCodeVisuAndTransform.translate.None);
            visuGCode.getGCodeLines(fCTBCode.Lines);
            updateDrawing();
            lbDimension.Text = visuGCode.xyzSize.getMinMaxString(); //String.Format("X:[ {0:0.0} | {1:0.0} ];    Y:[ {2:0.0} | {3:0.0} ];    Z:[ {4:0.0} | {5:0.0} ]", visuGCode.xyzSize.minx, visuGCode.xyzSize.maxx, visuGCode.xyzSize.miny, visuGCode.xyzSize.maxy, visuGCode.xyzSize.minz, visuGCode.xyzSize.maxz);
            lbDimension.Select(0, 0);
            toolStrip_tb_XY_X_scale.Text = string.Format("{0:0.000}", visuGCode.xyzSize.dimx);
            toolStrip_tb_X_X_scale.Text = string.Format("{0:0.000}", visuGCode.xyzSize.dimx);
            toolStrip_tb_XY_Y_scale.Text = string.Format("{0:0.000}", visuGCode.xyzSize.dimy);
            toolStrip_tb_Y_Y_scale.Text = string.Format("{0:0.000}", visuGCode.xyzSize.dimy);
        }

        #region fCTB FastColoredTextBox related
        // highlight code in editor
        Style StyleComment = new TextStyle(Brushes.Gray, null, FontStyle.Italic);
        Style StyleGWord = new TextStyle(Brushes.Blue, null, FontStyle.Bold);
        Style StyleMWord = new TextStyle(Brushes.SaddleBrown, null, FontStyle.Regular);
        Style StyleFWord = new TextStyle(Brushes.Red, null, FontStyle.Regular);
        Style StyleSWord = new TextStyle(Brushes.OrangeRed, null, FontStyle.Regular);
        Style StyleTool = new TextStyle(Brushes.Black, null, FontStyle.Regular);
        Style StyleXAxis = new TextStyle(Brushes.Green, null, FontStyle.Bold);
        Style StyleYAxis = new TextStyle(Brushes.BlueViolet, null, FontStyle.Bold);
        Style StyleZAxis = new TextStyle(Brushes.Red, null, FontStyle.Bold);
        private void fCTBCode_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            e.ChangedRange.ClearStyle(StyleComment);
            e.ChangedRange.SetStyle(StyleComment, "(\\(.*\\))", System.Text.RegularExpressions.RegexOptions.Compiled);
            e.ChangedRange.SetStyle(StyleGWord, "(G\\d{1,2})", System.Text.RegularExpressions.RegexOptions.Compiled);
            e.ChangedRange.SetStyle(StyleMWord, "(M\\d{1,2})", System.Text.RegularExpressions.RegexOptions.Compiled);
            e.ChangedRange.SetStyle(StyleFWord, "(F\\d+)", System.Text.RegularExpressions.RegexOptions.Compiled);
            e.ChangedRange.SetStyle(StyleSWord, "(S\\d+)", System.Text.RegularExpressions.RegexOptions.Compiled);
            e.ChangedRange.SetStyle(StyleTool, "(T\\d{1,2})", System.Text.RegularExpressions.RegexOptions.Compiled);
            e.ChangedRange.SetStyle(StyleXAxis, "[XIxi]{1}-?\\d+(.\\d+)?", System.Text.RegularExpressions.RegexOptions.Compiled);
            e.ChangedRange.SetStyle(StyleYAxis, "[YJyj]{1}-?\\d+(.\\d+)?", System.Text.RegularExpressions.RegexOptions.Compiled);
            e.ChangedRange.SetStyle(StyleZAxis, "[Zz]{1}-?\\d+(.\\d+)?", System.Text.RegularExpressions.RegexOptions.Compiled);
        }
        private void fCTBCode_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            showChangedMessage = true;
            if (fCTBCode.LinesCount > 2)
            {
                pictureBox1.BackgroundImage = null;
                redrawGCodePath();
            }
        }
        // mark clicked line in editor
        int fCTBCodeClickedLineNow = 0;
        int fCTBCodeClickedLineLast = 0;
        private void fCTBCode_Click(object sender, EventArgs e)
        {
            fCTBCodeClickedLineNow = fCTBCode.Selection.ToLine;
            fCTBCodeMarkLine();
            //           MessageBox.Show(visuGCode.getLineInfo(fCTBCodeClickedLineNow));
            //            fCTBCode.t  (visuGCode.getLineInfo(fCTBCodeClickedLineNow));
        }
        private void fCTBCode_KeyDown(object sender, KeyEventArgs e)
        {
            int key = e.KeyValue;
            if ((key == 38) && (fCTBCodeClickedLineNow > 0))
            {
                fCTBCodeClickedLineNow -= 1;
                fCTBCode.Selection = fCTBCode.GetLine(fCTBCodeClickedLineNow);
                fCTBCodeMarkLine();
            }
            if ((key == 40) && (fCTBCodeClickedLineNow < (fCTBCode.Lines.Count - 1)))
            {
                fCTBCodeClickedLineNow += 1;
                fCTBCode.Selection = fCTBCode.GetLine(fCTBCodeClickedLineNow);
                fCTBCodeMarkLine();
            }
        }
        private void fCTBCodeMarkLine()
        {
            if ((fCTBCodeClickedLineNow <= fCTBCode.LinesCount) && (fCTBCodeClickedLineNow >= 0))
            {
                if (fCTBCodeClickedLineNow != fCTBCodeClickedLineLast)
                {
                    fCTBCode.UnbookmarkLine(fCTBCodeClickedLineLast);
                    fCTBCode.BookmarkLine(fCTBCodeClickedLineNow);
                    Range selected = fCTBCode.GetLine(fCTBCodeClickedLineNow);
                    fCTBCode.Selection = selected;
                    fCTBCode.SelectionColor = Color.Orange;
                    fCTBCodeClickedLineLast = fCTBCodeClickedLineNow;
                    // Set marker in drawing
                    //visuGCode.setMarkerOnDrawing(fCTBCode.SelectedText);
                    visuGCode.setPosMarkerLine(fCTBCodeClickedLineNow);
                    pictureBox1.Invalidate(); // avoid too much events
                    if (_camera_form != null)
                        _camera_form.setPosMarker(visuGCode.GetPosMarkerX(), visuGCode.GetPosMarkerY());
                }
            }
        }

        // context Menu on fastColoredTextBox
        private void cmsCode_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "cmsCodeSelect")
            {
                fCTBCode.SelectAll();
            }
            if (e.ClickedItem.Name == "cmsCodeCopy")
            {
                if (fCTBCode.SelectedText.Length > 0)
                    fCTBCode.Copy();
            }
            if (e.ClickedItem.Name == "cmsCodePaste")
            {
                fCTBCode.Paste();
            }
            if (e.ClickedItem.Name == "cmsCodeSendLine")
            {
                int clickedLine = fCTBCode.Selection.ToLine;
                sendCommand(fCTBCode.Lines[clickedLine], false);
                //MessageBox.Show(fCTBCode.Lines[clickedLine]);
            }
        }

        #endregion



        #region paintBox
        // onPaint drawing
        private Pen penUp = new Pen(Color.Green, 0.1F);
        private Pen penDown = new Pen(Color.Red, 0.4F);
        private Pen penHeightMap = new Pen(Color.Yellow, 1F);
        private Pen penRuler = new Pen(Color.Blue, 0.1F);
        private Pen penTool = new Pen(Color.Black, 0.5F);
        private Pen penMarker = new Pen(Color.DeepPink, 1F);
        private double picAbsPosX = 0;
        private double picAbsPosY = 0;
        private Bitmap picBoxBackround;
        private int picBoxCopy = 0;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            double minx = GCodeVisuAndTransform.drawingSize.minX;                  // extend dimensions/扩展维度
            double maxx = GCodeVisuAndTransform.drawingSize.maxX;
            double miny = GCodeVisuAndTransform.drawingSize.minY;
            double maxy = GCodeVisuAndTransform.drawingSize.maxY;
            double xRange = (maxx - minx);                                              // calculate new size
            double yRange = (maxy - miny);
            double picScaling = Math.Min(pictureBox1.Width / (xRange), pictureBox1.Height / (yRange));               // calculate scaling px/unit

            if ((picScaling > 0.001) && (picScaling < 10000))
            {
                double relposX = zoomOffsetX + zoomRange * (Convert.ToDouble(pictureBox1.PointToClient(MousePosition).X) / pictureBox1.Width);
                double relposY = zoomOffsetY + zoomRange * (Convert.ToDouble(pictureBox1.PointToClient(MousePosition).Y) / pictureBox1.Height);
                double ratioVisu = xRange / yRange;
                double ratioPic = Convert.ToDouble(pictureBox1.Width) / pictureBox1.Height;
                if (ratioVisu > ratioPic)
                    relposY = relposY * ratioVisu / ratioPic;
                else
                    relposX = relposX * ratioPic / ratioVisu;

                picAbsPosX = relposX * xRange + minx;
                picAbsPosY = yRange - relposY * yRange + miny;
                int offX = +5;

                if (pictureBox1.PointToClient(MousePosition).X > (pictureBox1.Width - 100))
                { offX = -75; }

                Point stringpos = new Point(pictureBox1.PointToClient(MousePosition).X + offX, pictureBox1.PointToClient(MousePosition).Y - 10);
                e.Graphics.DrawString(String.Format("Worl-Pos:\r\nX:{0,7:0.00}\r\nY:{1,7:0.00}", picAbsPosX, picAbsPosY), new Font("Lucida Console", 8), Brushes.Black, stringpos);
                e.Graphics.DrawString(String.Format("Zooming: {0,2:0.00}%", 100 / zoomRange), new Font("Lucida Console", 8), Brushes.Black, new Point(5, 5));

                e.Graphics.Transform = pBoxTransform;
                e.Graphics.ScaleTransform((float)picScaling, (float)-picScaling);        // apply scaling (flip Y)
                e.Graphics.TranslateTransform((float)-minx, (float)(-yRange - miny));
                onPaint_drawToolPath(e.Graphics);

                e.Graphics.DrawPath(penMarker, GCodeVisuAndTransform.pathMarker);
                e.Graphics.DrawPath(penTool, GCodeVisuAndTransform.pathTool);

            }

        }
        private void onPaint_scaling(Graphics e)
        {
            double minx = GCodeVisuAndTransform.drawingSize.minX;                  // extend dimensions
            double maxx = GCodeVisuAndTransform.drawingSize.maxX;
            double miny = GCodeVisuAndTransform.drawingSize.minY;
            double maxy = GCodeVisuAndTransform.drawingSize.maxY;
            double xRange = (maxx - minx);                                              // calculate new size
            double yRange = (maxy - miny);
            double picScaling = Math.Min(pictureBox1.Width / (xRange), pictureBox1.Height / (yRange));               // calculate scaling px/unit
            e.ScaleTransform((float)picScaling, (float)-picScaling);        // apply scaling (flip Y)
            e.TranslateTransform((float)-minx, (float)(-yRange - miny));       // apply offset
        }
        private void onPaint_drawToolPath(Graphics e)
        {
            Pen pen = new Pen(colorChoosed,0.4f);
            e.DrawPath(penHeightMap, GCodeVisuAndTransform.pathHeightMap);
            e.DrawPath(penRuler, GCodeVisuAndTransform.pathRuler);
            e.DrawPath(penDown, GCodeVisuAndTransform.pathPenDown);
            e.DrawPath(penUp, GCodeVisuAndTransform.pathPenUp);
            e.DrawPath(pen, UpdateGr);
        }
        private void onPaint_setBackground()
        {
            picBoxCopy = 1;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            picBoxBackround = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics graphics = Graphics.FromImage(picBoxBackround);
            graphics.DrawString("Streaming", new Font("Lucida Console", 8), Brushes.Black, 1, 1);
            onPaint_scaling(graphics);
            onPaint_drawToolPath(graphics);
            pictureBox1.BackgroundImage = new Bitmap(picBoxBackround);//Properties.Resources.modell;

        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            if (picBoxCopy > 0)
                onPaint_setBackground();
            pictureBox1.Invalidate();
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.Invalidate();
            colorPoint = new Point((int)picAbsPosX, (int)picAbsPosY);
        }

        // find closest coordinate in GCode and mark
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (fCTBCode.LinesCount > 2)
            {
                int line;
                line = visuGCode.setPosMarkerNearBy(picAbsPosX, picAbsPosY);
                fCTBCode.Selection = fCTBCode.GetLine(line);
                fCTBCodeClickedLineNow = line;
                fCTBCodeMarkLine();
                fCTBCode.DoCaretVisible();
            }
        }

        private Matrix pBoxTransform = new Matrix();
        private static float s_dScrollValue = 2f; // zoom factor   
        private float zoomRange = 1f;
        private float zoomOffsetX = 0f;
        private float zoomOffsetY = 0f;

        private void pictureBox1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            pictureBox1.Focus();
            if (pictureBox1.Focused == true && e.Delta != 0)
            { ZoomScroll(e.Location, e.Delta > 0); }
        }
        private void ZoomScroll(Point location, bool zoomIn)
        {
            float locX = -location.X;
            float locY = -location.Y;
            float posX = (float)location.X / (float)pictureBox1.Width;      // range 0..1
            float posY = (float)location.Y / (float)pictureBox1.Height;     // range 0..1
            float valX = zoomOffsetX + posX * zoomRange;                    // range offset...(offset+range)
            float valY = zoomOffsetY + posY * zoomRange;

            pBoxTransform.Translate(-locX, -locY);
            if (zoomIn)
            {
                pBoxTransform.Scale((float)s_dScrollValue, (float)s_dScrollValue);
                zoomRange *= 1 / s_dScrollValue;
            }
            else
            {
                pBoxTransform.Scale(1 / (float)s_dScrollValue, 1 / (float)s_dScrollValue);
                zoomRange *= s_dScrollValue;
            }
            zoomOffsetX = valX - posX * zoomRange;
            zoomOffsetY = valY - posY * zoomRange;
            pBoxTransform.Translate(locX, locY);
            if (zoomRange == 1)
            { pBoxTransform.Reset(); zoomRange = 1; zoomOffsetX = 0; zoomOffsetY = 0; }

            pictureBox1.Invalidate();
        }
        private void resetZoomingToolStripMenuItem_Click(object sender, EventArgs e)
        { pBoxTransform.Reset(); zoomRange = 1; zoomOffsetX = 0; zoomOffsetY = 0; }
        private float transformMousePos(float old, float offset)
        { return old * zoomRange + offset; }
        #endregion



        private int findEndOfPath(int startLine, bool toEnd)
        {
            int endVal = fCTBCode.LinesCount;
            int lineNr = startLine;
            int lastNr = lineNr;
            string curLine;
            if (endVal < 2) return -1;
            if (toEnd)
            { if (startLine > endVal) return -1; }
            else
            {
                endVal = 0;
                if (startLine < endVal) return -1;
            }
            do
            {
                curLine = fCTBCode.Lines[lineNr];
                if ((curLine.IndexOf("X") >= 0) || (curLine.IndexOf("Y") >= 0))
                { lastNr = lineNr; }
                if ((curLine.IndexOf("Z") >= 0) || (curLine.IndexOf("G0") >= 0) || (curLine.IndexOf("M30") >= 0) || (curLine.IndexOf("F") >= 0))
                {
                    if (toEnd)
                        lastNr++;
                    return lastNr;
                }
                if (toEnd)
                { lineNr++; }
                else
                { lineNr--; }
            } while ((lineNr <= fCTBCode.LinesCount) || (lineNr > 0));
            return -1;
        }

        private void moveToFirstPosToolStripMenuItem_Click(object sender, EventArgs e)
        {   // rotate coordinates until marked line first
            int lineNr = fCTBCodeClickedLineNow;
            Range mySelection = fCTBCode.Range;
            Place selStart, selEnd;
            selStart.iLine = fCTBCodeClickedLineNow;
            selStart.iChar = 0;
            mySelection.Start = selStart;
            selEnd.iLine = lineNr;
            selEnd.iChar = 0;
            // select from marked line until end of this path - needs to be moved to front
            lineNr = findEndOfPath(fCTBCodeClickedLineNow, true);            // find end
            if (lineNr > 0)
            {
                selEnd.iLine = lineNr;
                selEnd.iChar = 0;
                mySelection.End = selEnd;
                fCTBCode.Selection = mySelection;
                fCTBCode.SelectionColor = Color.Red;
                // find current begin of path, to insert selected code
                lineNr = findEndOfPath(fCTBCodeClickedLineNow, false);      // find start
                if (lineNr > 0)
                {
                    if (deleteMarkedCode)
                    {
                        fCTBCode.Cut();
                        selStart.iLine = lineNr;
                        selStart.iChar = 0;
                        selEnd.iLine = lineNr;
                        selEnd.iChar = 0;
                        mySelection.Start = selStart;
                        mySelection.End = selEnd;
                        fCTBCode.Selection = mySelection;
                        fCTBCode.Paste();
                        fCTBCodeClickedLineNow = lineNr;
                        fCTBCodeMarkLine();
                    }
                    fCTBCode.DoCaretVisible();
                    redrawGCodePath();
                    return;
                }
            }
            MessageBox.Show("Path start / end could not be identified");
        }

        private void deletePathToolStripMenuItem_Click(object sender, EventArgs e)
        {   // mark start to end of path and delete
            int lineNr = fCTBCodeClickedLineNow;
            Range mySelection = fCTBCode.Range;
            Place selStart, selEnd;
            selStart.iLine = fCTBCodeClickedLineNow;
            selStart.iChar = 0;
            mySelection.Start = selStart;
            selEnd.iLine = lineNr;
            selEnd.iChar = 0;
            // find start of path
            lineNr = findEndOfPath(fCTBCodeClickedLineNow, false);
            if (lineNr > 0)
            {
                if (fCTBCode.Lines[lineNr].IndexOf("Z") >= 0) { lineNr--; }
                selStart.iLine = lineNr;
                selStart.iChar = 0;
                mySelection.Start = selStart;
                // find end of path
                lineNr = findEndOfPath(fCTBCodeClickedLineNow, true);
                if (lineNr > 0)
                {
                    if (fCTBCode.Lines[lineNr].IndexOf("Z") >= 0) { lineNr++; }
                    selEnd.iLine = lineNr;
                    selEnd.iChar = 0;
                    mySelection.End = selEnd;
                    fCTBCode.Selection = mySelection;
                    fCTBCode.SelectionColor = Color.Red;
                    fCTBCodeClickedLineNow = selStart.iLine;

                    if (deleteMarkedCode)
                    {
                        fCTBCode.Cut();
                        fCTBCodeMarkLine();
                    }
                    fCTBCode.DoCaretVisible();
                    redrawGCodePath();
                    return;
                }
            }
            MessageBox.Show("Path start / end could not be identified");
        }

        private void deleteThisCodeLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fCTBCode.LinesCount < 1) return;
            fCTBCodeClickedLineLast = 1;
            fCTBCodeMarkLine();
            if (deleteMarkedCode)
            {
                fCTBCode.Cut();
                fCTBCodeClickedLineNow--;
                fCTBCodeMarkLine();
            }
            fCTBCode.DoCaretVisible();
            redrawGCodePath();
            return;
        }

        private bool deleteMarkedCode = false;
        private void deletenotMarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (deleteMarkedCode)
            {
                deleteMarkedCode = false;
                deletenotMarkToolStripMenuItem.Text = "Mark (not delete)";
            }
            else
            {
                deleteMarkedCode = true;
                deletenotMarkToolStripMenuItem.Text = "Delete (not mark)";
            }
        }

        private void cBTool_CheckedChanged(object sender, EventArgs e)
        {
            _serial_form.toolInSpindle = cBTool.Checked;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                loadFromClipboard();
                e.SuppressKeyPress = true;
            }
        }
        private void loadFromClipboard()
        {
            string svg_format1 = "image/x-inkscape-svg";
            string svg_format2 = "image/svg+xml";
            IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.Text))
            {
                fCTBCode.Text = (String)iData.GetData(DataFormats.Text);
                setLastLoadedFile("Data from Clipboard: Text");
            }
            else if (iData.GetDataPresent(svg_format1) || iData.GetDataPresent(svg_format2))
            {
                MemoryStream stream = new MemoryStream();
                if (iData.GetDataPresent(svg_format1))
                    stream = (MemoryStream)iData.GetData(svg_format1);
                else
                    stream = (MemoryStream)iData.GetData(svg_format2);

                byte[] bytes = stream.ToArray();
                string txt = System.Text.Encoding.Default.GetString(bytes);
                this.Cursor = Cursors.WaitCursor;

                string gcode = GCodeFromSVG.convertFromText(txt);
                if (gcode.Length > 2)
                {
                    fCTBCode.Text = gcode;
                    fCTBCode.UnbookmarkLine(fCTBCodeClickedLineLast);
                    redrawGCodePath();
                    this.Text = appName + " | Source: from Clipboard";
                }
                this.Cursor = Cursors.Default;
                updateControls();
                setLastLoadedFile("Data from Clipboard: SVG");
            }
            else if (iData.GetDataPresent(DataFormats.Bitmap))
            {
                if (_image_form == null)
                {
                    _image_form = new GCodeFromImage(true);
                    _image_form.FormClosed += formClosed_ImageToGCode;
                    _image_form.btnGenerate.Click += getGCodeFromImage;      // assign btn-click event
                }
                else
                {
                    _image_form.Visible = false;
                }
                _image_form.Show(this);
                _image_form.loadClipboard();
                setLastLoadedFile("Data from Clipboard: Image");
            }
            else
            {
                string tmp = "";
                foreach (string format in iData.GetFormats())
                { tmp += format + "\r\n"; }
                MessageBox.Show(tmp);
            }
        }

        private void pasteFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        { loadFromClipboard(); }




        private void btnOverrideFR0_Click(object sender, EventArgs e)
        { sendRealtimeCommand(144); }     // 0x90 : Set 100% of programmed rate.    
        private void btnOverrideFR1_Click(object sender, EventArgs e)
        { sendRealtimeCommand(145); }     // 0x91 : Increase 10%        
        private void btnOverrideFR4_Click(object sender, EventArgs e)
        { sendRealtimeCommand(146); }     // 0x92 : Decrease 10%   
        private void btnOverrideFR2_Click(object sender, EventArgs e)
        { sendRealtimeCommand(147); }     // 0x93 : Increase 1%   
        private void btnOverrideFR3_Click(object sender, EventArgs e)
        { sendRealtimeCommand(148); }     // 0x94 : Decrease 1%   

        private void btnOverrideSS0_Click(object sender, EventArgs e)
        { sendRealtimeCommand(153); }     // 0x99 : Set 100% of programmed spindle speed    
        private void btnOverrideSS1_Click(object sender, EventArgs e)
        { sendRealtimeCommand(154); }     // 0x9A : Increase 10%        
        private void btnOverrideSS4_Click(object sender, EventArgs e)
        { sendRealtimeCommand(155); }     // 0x9B : Decrease 10%   
        private void btnOverrideSS2_Click(object sender, EventArgs e)
        { sendRealtimeCommand(156); }     // 0x9C : Increase 1%   
        private void btnOverrideSS3_Click(object sender, EventArgs e)
        { sendRealtimeCommand(157); }     // 0x9D : Decrease 1%   

        private void saveToToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog dial = new SaveFileDialog();
            dial.Title = "请选择文件夹";
            dial.Filter = "GCode|*.txt";
            if (dial.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dial.FileName;
                File.WriteAllText(file, fCTBCode.Text);
                MessageBox.Show("保存成功！");
            }

        }

        private void txt_ModelSetting_Enter(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo(Properties.Settings.Default.language);
            if (ci.ToString() == "zh")
            {
                label35.Text = "0:仅钻孔 1:先钻后攻 2:铣槽";
            }
            else if (ci.ToString() == "en")
            {
                label35.Text = "0: Only drill hole 1: drill first and then attack 2: slot milling";
            }
        }

        private void txt_ColorSetting_Enter(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo(Properties.Settings.Default.language);
            if (ci.ToString() == "zh")
            {
                label35.Text = "铣削时用颜色识别刀号0:黄色 1:绿色";
            }
            else if (ci.ToString() == "en")
            {
                label35.Text = "Milling with color identification tool number 0: yellow 1: green";
            }
        }

        private void txt_knife_Enter(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo(Properties.Settings.Default.language);
            if (ci.ToString() == "zh")
            {
                label35.Text = "进行铣槽时选择的刀号(1-6)";
            }
            else if (ci.ToString() == "en")
            {
                label35.Text = "The tool number selected for milling grooves (1-6)";
            }
        }

        private void txt_CutterDiameter_Enter(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo(Properties.Settings.Default.language);
            if (ci.ToString() == "zh")
            {
                label35.Text = "铣刀的直径值";
            }
            else if (ci.ToString() == "en")
            {
                label35.Text = "Diameter value of milling cutter";
            }
        }

        private void txt_caoRevolutions_Enter(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo(Properties.Settings.Default.language);
            if (ci.ToString() == "zh")
            {
                label35.Text = "进行铣槽时选择的刀号(1-6)";
            }
            else if (ci.ToString() == "en")
            {
                label35.Text = "The tool number selected for milling grooves (1-6)";
            }
        }

        private void txt_caoPlane_Enter(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo(Properties.Settings.Default.language);
            if (ci.ToString() == "zh")
            {
                label35.Text = "铣槽下刀初始平面R点";
            }
            else if (ci.ToString() == "en")
            {
                label35.Text = "R point on the initial plane of the cutting tool under milling groove";
            }

        }

        private void txt_yuanDepth_Enter(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo(Properties.Settings.Default.language);
            if (ci.ToString() == "zh")
            {
                label35.Text = "铣圆时Z轴下刀的深度";
            }
            else if (ci.ToString() == "en")
            {
                label35.Text = "The depth of the tool under the Z axis when milling round";
            }

        }

        private void txt_yuanCutting_Enter(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo(Properties.Settings.Default.language);
            if (ci.ToString() == "zh")
            {
                label35.Text = "铣圆Z轴方向从R点首次向下的距离";
            }
            else if (ci.ToString() == "en")
            {
                label35.Text = "Milling circle Z axis direction from point R first downward distance";
            }

        }

        private void txt_yuanWidth_Enter(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo(Properties.Settings.Default.language);
            if (ci.ToString() == "zh")
            {
                label35.Text = "铣圆时XY平面单次增量";
            }
            else if (ci.ToString() == "en")
            {
                label35.Text = "Single increment of XY plane when milling a circle";
            }

        }

        private void txt_yuanSingleCutting_Enter(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo(Properties.Settings.Default.language);
            if (ci.ToString() == "zh")
            {
                label35.Text = "铣圆Z轴每次切削进给的深度";
            }
            else if (ci.ToString() == "en")
            {
                label35.Text = "The depth of feed per cutting on the Z axis of the milling circle";
            }

        }

        private void txt_yuanDistance_Enter(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo(Properties.Settings.Default.language);
            if (ci.ToString() == "zh")
            {
                label35.Text = "快速下刀时，离未加工表面距离";
            }
            else if (ci.ToString() == "en")
            {
                label35.Text = "Distance from the unmachined surface when cutting quickly";
            }

        }

        private void txt_yuanSpeed_Enter(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo(Properties.Settings.Default.language);
            if (ci.ToString() == "zh")
            {
                label35.Text = "铣槽运行速度设定";
            }
            else if (ci.ToString() == "en")
            {
                label35.Text = "Milling slot running speed setting";
            }

        }

        private void txt_juDepth_Enter(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo(Properties.Settings.Default.language);
            if (ci.ToString() == "zh")
            {
                label35.Text = "铣矩形时Z轴下刀的深度";
            }
            else if (ci.ToString() == "en")
            {
                label35.Text = "The depth of the cutter under the Z axis when milling the rectangle";
            }

        }

        private void txt_juCutting_Enter(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo(Properties.Settings.Default.language);
            if (ci.ToString() == "zh")
            {
                label35.Text = "铣矩Z轴方向从R点首次向下的距离";
            }
            else if (ci.ToString() == "en")
            {
                label35.Text = "Milling moment Z axis direction from point R first downward distance";
            }

        }

        private void txt_juWidth_Enter(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo(Properties.Settings.Default.language);
            if (ci.ToString() == "zh")
            {
                label35.Text = "铣矩时XY平面单次增量";
            }
            else if (ci.ToString() == "en")
            {
                label35.Text = "Single increment of XY plane at milling moment";
            }

        }

        private void txt_juSingleCutting_Enter(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo(Properties.Settings.Default.language);
            if (ci.ToString() == "zh")
            {
                label35.Text = "铣矩Z轴每次切削进给的深度";
            }
            else if (ci.ToString() == "en")
            {
                label35.Text = "Milling moment Z-axis feed depth per cutting";
            }

        }

        private void txt_juDistance_Enter(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo(Properties.Settings.Default.language);
            if (ci.ToString() == "zh")
            {
                label35.Text = "快速下刀时，离未加工表面距离";
            }
            else if (ci.ToString() == "en")
            {
                label35.Text = "Distance from the unmachined surface when cutting quickly";
            }

        }

        private void txt_juSpeed_Enter(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo(Properties.Settings.Default.language);
            if (ci.ToString() == "zh")
            {
                label35.Text = "铣矩运行速度设定";
            }
            else if (ci.ToString() == "en")
            {
                label35.Text = "Milling moment speed setting";
            }

        }

        private void txt_X_Enter(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo(Properties.Settings.Default.language);
            if (ci.ToString() == "zh")
            {
                label35.Text = "X轴对刀位置设定";
            }
            else if (ci.ToString() == "en")
            {
                label35.Text = "X axis tool position setting";
            }

        }

        private void txt_Y_Enter(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo(Properties.Settings.Default.language);
            if (ci.ToString() == "zh")
            {
                label35.Text = "Y轴对刀位置设定";
            }
            else if (ci.ToString() == "en")
            {
                label35.Text = "Y axis tool position setting";
            }
        }

        private void txt_Z_Enter(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo(Properties.Settings.Default.language);
            if (ci.ToString() == "zh")
            {
                label35.Text = "Z轴对刀位置设定";
            }
            else if (ci.ToString() == "en")
            {
                label35.Text = "Z axis tool position setting";
            }
        }
        private void switchTheColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //更改颜色
            GCodeVisuAndTransform.MyShape myshape = GCodeVisuAndTransform.list.FirstOrDefault(p => p.Rectangle.Contains(colorPoint));
            if (myshape != null)
            {
                ColorDialog colorDia = new ColorDialog();

                if (colorDia.ShowDialog() == DialogResult.OK)
                {
                    colorChoosed = colorDia.Color;
                    Graphics g = pictureBox1.CreateGraphics();

                    foreach (var item in GCodeVisuAndTransform.list)
                    {
                        if (myshape.Name == "线条" && item.Rectangle == myshape.Rectangle)
                        {
                            UpdateGr.AddLine(myshape.Rectangle.X, myshape.Rectangle.Y, myshape.Rectangle.Width, myshape.Rectangle.Height);
                        }
                        else if (item.Rectangle == myshape.Rectangle && item.Name == "圆弧")
                        {
                            UpdateGr.AddRectangle(myshape.Rectangle);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (generateGCode != "")
            {
                fCTBCode.Text = generateGCode;
            }
            else
            {
                MessageBox.Show("请选择要生成G代码的文件");
            }
        }
    }
}
