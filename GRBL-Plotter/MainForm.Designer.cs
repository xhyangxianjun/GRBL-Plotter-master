/*  GRBL-Plotter. Another GCode sender for GRBL.
    This file is part of the GRBL-Plotter application.
   
    Copyright (C) 2015-2016 Sven Hasemann contact: svenhb@web.de

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
namespace GRBL_Plotter
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                picBoxBackround.Dispose();
     //           gcodeImage.Dispose();
                StyleComment.Dispose();
                StyleFWord.Dispose();
                StyleGWord.Dispose();
                StyleMWord.Dispose();
                StyleSWord.Dispose();
                StyleTool.Dispose();
                StyleXAxis.Dispose();
                StyleYAxis.Dispose();
                StyleZAxis.Dispose();
                penDown.Dispose();
                penMarker.Dispose();
                penRuler.Dispose();
                penTool.Dispose();
                penUp.Dispose();
                //                visuGCode.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.setupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.saveMachineParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMachineParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deutschToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chineseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createGCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textWizzardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createSimpleShapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mirrorXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mirrorYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.rotate90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate90ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateFreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_tb_rotate = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_tb_XY_scale = new System.Windows.Forms.ToolStripTextBox();
            this.skalierenXYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_tb_XY_X_scale = new System.Windows.Forms.ToolStripTextBox();
            this.skalierenXYUmXUnitsZuErreichenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_tb_XY_Y_scale = new System.Windows.Forms.ToolStripTextBox();
            this.skaliereXUmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_tb_X_scale = new System.Windows.Forms.ToolStripTextBox();
            this.skaliereAufXUnitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_tb_X_X_scale = new System.Windows.Forms.ToolStripTextBox();
            this.skaliereYUmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_tb_Y_scale = new System.Windows.Forms.ToolStripTextBox();
            this.skaliereAufYUnitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_tb_Y_Y_scale = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.rotaryDimaeterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_tb_rotary_diameter = new System.Windows.Forms.ToolStripTextBox();
            this.skaliereXAufDrehachseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_tb_X_A_scale = new System.Windows.Forms.ToolStripTextBox();
            this.skaliereYAufDrehachseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_tb_Y_A_scale = new System.Windows.Forms.ToolStripTextBox();
            this.ersetzteG23DurchLinienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.machineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heightMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlStreamingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.control2ndGRBLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOverrideSSGB = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblOverrideSSValue = new System.Windows.Forms.Label();
            this.btnOverrideSS2 = new System.Windows.Forms.Button();
            this.btnOverrideSS0 = new System.Windows.Forms.Button();
            this.btnOverrideSS1 = new System.Windows.Forms.Button();
            this.btnOverrideSS4 = new System.Windows.Forms.Button();
            this.btnOverrideSS3 = new System.Windows.Forms.Button();
            this.btnOverrideFRGB = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblOverrideFRValue = new System.Windows.Forms.Label();
            this.btnOverrideFR1 = new System.Windows.Forms.Button();
            this.btnOverrideFR2 = new System.Windows.Forms.Button();
            this.btnOverrideFR0 = new System.Windows.Forms.Button();
            this.btnOverrideFR4 = new System.Windows.Forms.Button();
            this.btnOverrideFR3 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnOffsetApply = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbOffsetY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbOffsetX = new System.Windows.Forms.TextBox();
            this.rBOrigin9 = new System.Windows.Forms.RadioButton();
            this.rBOrigin8 = new System.Windows.Forms.RadioButton();
            this.rBOrigin7 = new System.Windows.Forms.RadioButton();
            this.rBOrigin6 = new System.Windows.Forms.RadioButton();
            this.rBOrigin5 = new System.Windows.Forms.RadioButton();
            this.rBOrigin4 = new System.Windows.Forms.RadioButton();
            this.rBOrigin3 = new System.Windows.Forms.RadioButton();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.rBOrigin2 = new System.Windows.Forms.RadioButton();
            this.rBOrigin1 = new System.Windows.Forms.RadioButton();
            this.lbDimension = new System.Windows.Forms.TextBox();
            this.pbBuffer = new System.Windows.Forms.ProgressBar();
            this.btnStreamStop = new System.Windows.Forms.Button();
            this.btnStreamCheck = new System.Windows.Forms.Button();
            this.lbInfo = new System.Windows.Forms.Label();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.pbFile = new System.Windows.Forms.ProgressBar();
            this.lblElapsed = new System.Windows.Forms.Label();
            this.lblFileProgress = new System.Windows.Forms.Label();
            this.btnStreamStart = new System.Windows.Forms.Button();
            this.cmsCode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsCodeSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCodeCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCodePaste = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCodeSendLine = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnJogZeroXY = new System.Windows.Forms.Button();
            this.btnJogZeroZ = new System.Windows.Forms.Button();
            this.btnJogZeroY = new System.Windows.Forms.Button();
            this.btnJogZeroX = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnFeedHold = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnKillAlarm = new System.Windows.Forms.Button();
            this.btnJogStop = new System.Windows.Forms.Button();
            this.btnJogZeroA = new System.Windows.Forms.Button();
            this.virtualJoystickA = new virtualJoystick.virtualJoystick();
            this.virtualJoystickZ = new virtualJoystick.virtualJoystick();
            this.virtualJoystickXY = new virtualJoystick.virtualJoystick();
            this.btnZeroX = new System.Windows.Forms.Button();
            this.btnZeroY = new System.Windows.Forms.Button();
            this.btnZeroZ = new System.Windows.Forms.Button();
            this.btnZeroXY = new System.Windows.Forms.Button();
            this.btnZeroXYZ = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnZeroA = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTool = new System.Windows.Forms.Label();
            this.cBTool = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tBSpeed = new System.Windows.Forms.TextBox();
            this.cBCoolant = new System.Windows.Forms.CheckBox();
            this.cBSpindle = new System.Windows.Forms.CheckBox();
            this.fCTBCode = new FastColoredTextBoxNS.FastColoredTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmsPictureBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pasteFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.resetZoomingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.deletenotMarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteThisCodeLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToFirstPosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchTheColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tLPAussen = new System.Windows.Forms.TableLayoutPanel();
            this.tLPLinks = new System.Windows.Forms.TableLayoutPanel();
            this.tLPRechts = new System.Windows.Forms.TableLayoutPanel();
            this.tLPRechtsUnten = new System.Windows.Forms.TableLayoutPanel();
            this.tLPRechtsUntenRechts = new System.Windows.Forms.TableLayoutPanel();
            this.tLPMitteUnten = new System.Windows.Forms.TableLayoutPanel();
            this.txt_K10 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton32 = new System.Windows.Forms.RadioButton();
            this.radioButton16 = new System.Windows.Forms.RadioButton();
            this.radioButton31 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton30 = new System.Windows.Forms.RadioButton();
            this.radioButton15 = new System.Windows.Forms.RadioButton();
            this.radioButton29 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton28 = new System.Windows.Forms.RadioButton();
            this.radioButton27 = new System.Windows.Forms.RadioButton();
            this.radioButton14 = new System.Windows.Forms.RadioButton();
            this.radioButton26 = new System.Windows.Forms.RadioButton();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton25 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton24 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.radioButton23 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton22 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton21 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton20 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton19 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton18 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton17 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.tLPRechtsOben = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCustom8 = new System.Windows.Forms.Button();
            this.btnCustom7 = new System.Windows.Forms.Button();
            this.btnCustom6 = new System.Windows.Forms.Button();
            this.btnCustom5 = new System.Windows.Forms.Button();
            this.btnCustom1 = new System.Windows.Forms.Button();
            this.btnCustom2 = new System.Windows.Forms.Button();
            this.btnCustom3 = new System.Windows.Forms.Button();
            this.btnCustom4 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.com_TappingSetting = new System.Windows.Forms.ComboBox();
            this.com_drillingSetting = new System.Windows.Forms.ComboBox();
            this.com_ModelSetting = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_caoPlane = new System.Windows.Forms.TextBox();
            this.txt_caoRevolutions = new System.Windows.Forms.TextBox();
            this.txt_CutterDiameter = new System.Windows.Forms.TextBox();
            this.txt_yuanSpeed = new System.Windows.Forms.TextBox();
            this.txt_yuanDistance = new System.Windows.Forms.TextBox();
            this.txt_yuanSingleCutting = new System.Windows.Forms.TextBox();
            this.txt_daojiao = new System.Windows.Forms.TextBox();
            this.txt_hongkou = new System.Windows.Forms.TextBox();
            this.txt_yuanWidth = new System.Windows.Forms.TextBox();
            this.txt_yuanCutting = new System.Windows.Forms.TextBox();
            this.txt_juDistance = new System.Windows.Forms.TextBox();
            this.txt_juSingleCutting = new System.Windows.Forms.TextBox();
            this.txt_mangkong = new System.Windows.Forms.TextBox();
            this.txt_juWidth = new System.Windows.Forms.TextBox();
            this.txt_juCutting = new System.Windows.Forms.TextBox();
            this.txt_juDepth = new System.Windows.Forms.TextBox();
            this.txt_yuanDepth = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label_status0 = new System.Windows.Forms.Label();
            this.label_a = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label_ma = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label_wa = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_status = new System.Windows.Forms.Label();
            this.label_mx = new System.Windows.Forms.Label();
            this.label_my = new System.Windows.Forms.Label();
            this.label_mz = new System.Windows.Forms.Label();
            this.label_wz = new System.Windows.Forms.Label();
            this.label_wx = new System.Windows.Forms.Label();
            this.label_wy = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.btnOverrideSSGB.SuspendLayout();
            this.btnOverrideFRGB.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.cmsCode.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fCTBCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cmsPictureBox.SuspendLayout();
            this.tLPAussen.SuspendLayout();
            this.tLPLinks.SuspendLayout();
            this.tLPRechts.SuspendLayout();
            this.tLPRechtsUnten.SuspendLayout();
            this.tLPRechtsUntenRechts.SuspendLayout();
            this.tLPMitteUnten.SuspendLayout();
            this.txt_K10.SuspendLayout();
            this.tLPRechtsOben.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.createGCodeToolStripMenuItem,
            this.gCodeToolStripMenuItem,
            this.machineToolStripMenuItem,
            this.aboutToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripSeparator2,
            this.saveToolStripMenuItem,
            this.toolStripSeparator3,
            this.setupToolStripMenuItem1,
            this.toolStripSeparator7,
            this.saveMachineParametersToolStripMenuItem,
            this.loadMachineParametersToolStripMenuItem,
            this.toolStripMenuItem3});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            resources.ApplyResources(this.loadToolStripMenuItem, "loadToolStripMenuItem");
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // setupToolStripMenuItem1
            // 
            this.setupToolStripMenuItem1.Name = "setupToolStripMenuItem1";
            resources.ApplyResources(this.setupToolStripMenuItem1, "setupToolStripMenuItem1");
            this.setupToolStripMenuItem1.Click += new System.EventHandler(this.setupToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // saveMachineParametersToolStripMenuItem
            // 
            this.saveMachineParametersToolStripMenuItem.Name = "saveMachineParametersToolStripMenuItem";
            resources.ApplyResources(this.saveMachineParametersToolStripMenuItem, "saveMachineParametersToolStripMenuItem");
            this.saveMachineParametersToolStripMenuItem.Click += new System.EventHandler(this.saveMachineParametersToolStripMenuItem_Click);
            // 
            // loadMachineParametersToolStripMenuItem
            // 
            this.loadMachineParametersToolStripMenuItem.Name = "loadMachineParametersToolStripMenuItem";
            resources.ApplyResources(this.loadMachineParametersToolStripMenuItem, "loadMachineParametersToolStripMenuItem");
            this.loadMachineParametersToolStripMenuItem.Click += new System.EventHandler(this.loadMachineParametersToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.deutschToolStripMenuItem,
            this.chineseToolStripMenuItem});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // deutschToolStripMenuItem
            // 
            this.deutschToolStripMenuItem.Name = "deutschToolStripMenuItem";
            resources.ApplyResources(this.deutschToolStripMenuItem, "deutschToolStripMenuItem");
            this.deutschToolStripMenuItem.Click += new System.EventHandler(this.deutschToolStripMenuItem_Click);
            // 
            // chineseToolStripMenuItem
            // 
            this.chineseToolStripMenuItem.Name = "chineseToolStripMenuItem";
            resources.ApplyResources(this.chineseToolStripMenuItem, "chineseToolStripMenuItem");
            this.chineseToolStripMenuItem.Click += new System.EventHandler(this.chineseToolStripMenuItem_Click);
            // 
            // createGCodeToolStripMenuItem
            // 
            this.createGCodeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textWizzardToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.createSimpleShapesToolStripMenuItem});
            this.createGCodeToolStripMenuItem.Name = "createGCodeToolStripMenuItem";
            resources.ApplyResources(this.createGCodeToolStripMenuItem, "createGCodeToolStripMenuItem");
            // 
            // textWizzardToolStripMenuItem
            // 
            this.textWizzardToolStripMenuItem.Name = "textWizzardToolStripMenuItem";
            resources.ApplyResources(this.textWizzardToolStripMenuItem, "textWizzardToolStripMenuItem");
            this.textWizzardToolStripMenuItem.Click += new System.EventHandler(this.textWizzardToolStripMenuItem_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            resources.ApplyResources(this.imageToolStripMenuItem, "imageToolStripMenuItem");
            this.imageToolStripMenuItem.Click += new System.EventHandler(this.imageToolStripMenuItem_Click);
            // 
            // createSimpleShapesToolStripMenuItem
            // 
            this.createSimpleShapesToolStripMenuItem.Name = "createSimpleShapesToolStripMenuItem";
            resources.ApplyResources(this.createSimpleShapesToolStripMenuItem, "createSimpleShapesToolStripMenuItem");
            this.createSimpleShapesToolStripMenuItem.Click += new System.EventHandler(this.createSimpleShapesToolStripMenuItem_Click);
            // 
            // gCodeToolStripMenuItem
            // 
            this.gCodeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mirrorXToolStripMenuItem,
            this.mirrorYToolStripMenuItem,
            this.toolStripSeparator4,
            this.rotate90ToolStripMenuItem,
            this.rotate90ToolStripMenuItem1,
            this.rotateFreeToolStripMenuItem,
            this.toolStripSeparator5,
            this.sToolStripMenuItem,
            this.skalierenXYToolStripMenuItem,
            this.skalierenXYUmXUnitsZuErreichenToolStripMenuItem,
            this.skaliereXUmToolStripMenuItem,
            this.skaliereAufXUnitsToolStripMenuItem,
            this.skaliereYUmToolStripMenuItem,
            this.skaliereAufYUnitsToolStripMenuItem,
            this.toolStripSeparator6,
            this.rotaryDimaeterToolStripMenuItem,
            this.skaliereXAufDrehachseToolStripMenuItem,
            this.skaliereYAufDrehachseToolStripMenuItem,
            this.ersetzteG23DurchLinienToolStripMenuItem});
            this.gCodeToolStripMenuItem.Name = "gCodeToolStripMenuItem";
            resources.ApplyResources(this.gCodeToolStripMenuItem, "gCodeToolStripMenuItem");
            // 
            // mirrorXToolStripMenuItem
            // 
            this.mirrorXToolStripMenuItem.Name = "mirrorXToolStripMenuItem";
            resources.ApplyResources(this.mirrorXToolStripMenuItem, "mirrorXToolStripMenuItem");
            this.mirrorXToolStripMenuItem.Click += new System.EventHandler(this.mirrorXToolStripMenuItem_Click);
            // 
            // mirrorYToolStripMenuItem
            // 
            this.mirrorYToolStripMenuItem.Name = "mirrorYToolStripMenuItem";
            resources.ApplyResources(this.mirrorYToolStripMenuItem, "mirrorYToolStripMenuItem");
            this.mirrorYToolStripMenuItem.Click += new System.EventHandler(this.mirrorYToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // rotate90ToolStripMenuItem
            // 
            this.rotate90ToolStripMenuItem.Name = "rotate90ToolStripMenuItem";
            resources.ApplyResources(this.rotate90ToolStripMenuItem, "rotate90ToolStripMenuItem");
            this.rotate90ToolStripMenuItem.Click += new System.EventHandler(this.rotate90ToolStripMenuItem_Click);
            // 
            // rotate90ToolStripMenuItem1
            // 
            this.rotate90ToolStripMenuItem1.Name = "rotate90ToolStripMenuItem1";
            resources.ApplyResources(this.rotate90ToolStripMenuItem1, "rotate90ToolStripMenuItem1");
            this.rotate90ToolStripMenuItem1.Click += new System.EventHandler(this.rotate90ToolStripMenuItem1_Click);
            // 
            // rotateFreeToolStripMenuItem
            // 
            this.rotateFreeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_tb_rotate});
            this.rotateFreeToolStripMenuItem.Name = "rotateFreeToolStripMenuItem";
            resources.ApplyResources(this.rotateFreeToolStripMenuItem, "rotateFreeToolStripMenuItem");
            // 
            // toolStrip_tb_rotate
            // 
            this.toolStrip_tb_rotate.Name = "toolStrip_tb_rotate";
            resources.ApplyResources(this.toolStrip_tb_rotate, "toolStrip_tb_rotate");
            this.toolStrip_tb_rotate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStrip_tb_rotate_KeyDown);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_tb_XY_scale});
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            resources.ApplyResources(this.sToolStripMenuItem, "sToolStripMenuItem");
            // 
            // toolStrip_tb_XY_scale
            // 
            this.toolStrip_tb_XY_scale.Name = "toolStrip_tb_XY_scale";
            resources.ApplyResources(this.toolStrip_tb_XY_scale, "toolStrip_tb_XY_scale");
            this.toolStrip_tb_XY_scale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStrip_tb_XY_scale_KeyDown);
            // 
            // skalierenXYToolStripMenuItem
            // 
            this.skalierenXYToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_tb_XY_X_scale});
            this.skalierenXYToolStripMenuItem.Name = "skalierenXYToolStripMenuItem";
            resources.ApplyResources(this.skalierenXYToolStripMenuItem, "skalierenXYToolStripMenuItem");
            // 
            // toolStrip_tb_XY_X_scale
            // 
            this.toolStrip_tb_XY_X_scale.Name = "toolStrip_tb_XY_X_scale";
            resources.ApplyResources(this.toolStrip_tb_XY_X_scale, "toolStrip_tb_XY_X_scale");
            this.toolStrip_tb_XY_X_scale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStrip_tb_XY_X_scale_KeyDown);
            // 
            // skalierenXYUmXUnitsZuErreichenToolStripMenuItem
            // 
            this.skalierenXYUmXUnitsZuErreichenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_tb_XY_Y_scale});
            this.skalierenXYUmXUnitsZuErreichenToolStripMenuItem.Name = "skalierenXYUmXUnitsZuErreichenToolStripMenuItem";
            resources.ApplyResources(this.skalierenXYUmXUnitsZuErreichenToolStripMenuItem, "skalierenXYUmXUnitsZuErreichenToolStripMenuItem");
            // 
            // toolStrip_tb_XY_Y_scale
            // 
            this.toolStrip_tb_XY_Y_scale.Name = "toolStrip_tb_XY_Y_scale";
            resources.ApplyResources(this.toolStrip_tb_XY_Y_scale, "toolStrip_tb_XY_Y_scale");
            this.toolStrip_tb_XY_Y_scale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStrip_tb_XY_Y_scale_KeyDown);
            // 
            // skaliereXUmToolStripMenuItem
            // 
            this.skaliereXUmToolStripMenuItem.AutoToolTip = true;
            this.skaliereXUmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_tb_X_scale});
            this.skaliereXUmToolStripMenuItem.Name = "skaliereXUmToolStripMenuItem";
            resources.ApplyResources(this.skaliereXUmToolStripMenuItem, "skaliereXUmToolStripMenuItem");
            // 
            // toolStrip_tb_X_scale
            // 
            this.toolStrip_tb_X_scale.Name = "toolStrip_tb_X_scale";
            resources.ApplyResources(this.toolStrip_tb_X_scale, "toolStrip_tb_X_scale");
            this.toolStrip_tb_X_scale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStrip_tb_X_scale_KeyDown);
            // 
            // skaliereAufXUnitsToolStripMenuItem
            // 
            this.skaliereAufXUnitsToolStripMenuItem.AutoToolTip = true;
            this.skaliereAufXUnitsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.skaliereAufXUnitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_tb_X_X_scale});
            this.skaliereAufXUnitsToolStripMenuItem.Name = "skaliereAufXUnitsToolStripMenuItem";
            resources.ApplyResources(this.skaliereAufXUnitsToolStripMenuItem, "skaliereAufXUnitsToolStripMenuItem");
            // 
            // toolStrip_tb_X_X_scale
            // 
            this.toolStrip_tb_X_X_scale.Name = "toolStrip_tb_X_X_scale";
            resources.ApplyResources(this.toolStrip_tb_X_X_scale, "toolStrip_tb_X_X_scale");
            this.toolStrip_tb_X_X_scale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStrip_tb_X_X_scale_KeyDown);
            // 
            // skaliereYUmToolStripMenuItem
            // 
            this.skaliereYUmToolStripMenuItem.AutoToolTip = true;
            this.skaliereYUmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_tb_Y_scale});
            this.skaliereYUmToolStripMenuItem.Name = "skaliereYUmToolStripMenuItem";
            resources.ApplyResources(this.skaliereYUmToolStripMenuItem, "skaliereYUmToolStripMenuItem");
            // 
            // toolStrip_tb_Y_scale
            // 
            this.toolStrip_tb_Y_scale.Name = "toolStrip_tb_Y_scale";
            resources.ApplyResources(this.toolStrip_tb_Y_scale, "toolStrip_tb_Y_scale");
            this.toolStrip_tb_Y_scale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStrip_tb_Y_scale_KeyDown);
            // 
            // skaliereAufYUnitsToolStripMenuItem
            // 
            this.skaliereAufYUnitsToolStripMenuItem.AutoToolTip = true;
            this.skaliereAufYUnitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_tb_Y_Y_scale});
            this.skaliereAufYUnitsToolStripMenuItem.Name = "skaliereAufYUnitsToolStripMenuItem";
            resources.ApplyResources(this.skaliereAufYUnitsToolStripMenuItem, "skaliereAufYUnitsToolStripMenuItem");
            // 
            // toolStrip_tb_Y_Y_scale
            // 
            this.toolStrip_tb_Y_Y_scale.Name = "toolStrip_tb_Y_Y_scale";
            resources.ApplyResources(this.toolStrip_tb_Y_Y_scale, "toolStrip_tb_Y_Y_scale");
            this.toolStrip_tb_Y_Y_scale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStrip_tb_Y_Y_scale_KeyDown);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // rotaryDimaeterToolStripMenuItem
            // 
            this.rotaryDimaeterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_tb_rotary_diameter});
            this.rotaryDimaeterToolStripMenuItem.Name = "rotaryDimaeterToolStripMenuItem";
            resources.ApplyResources(this.rotaryDimaeterToolStripMenuItem, "rotaryDimaeterToolStripMenuItem");
            // 
            // toolStrip_tb_rotary_diameter
            // 
            this.toolStrip_tb_rotary_diameter.Name = "toolStrip_tb_rotary_diameter";
            resources.ApplyResources(this.toolStrip_tb_rotary_diameter, "toolStrip_tb_rotary_diameter");
            this.toolStrip_tb_rotary_diameter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStrip_tb_rotary_diameter_KeyDown);
            // 
            // skaliereXAufDrehachseToolStripMenuItem
            // 
            this.skaliereXAufDrehachseToolStripMenuItem.AutoToolTip = true;
            this.skaliereXAufDrehachseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_tb_X_A_scale});
            this.skaliereXAufDrehachseToolStripMenuItem.Name = "skaliereXAufDrehachseToolStripMenuItem";
            resources.ApplyResources(this.skaliereXAufDrehachseToolStripMenuItem, "skaliereXAufDrehachseToolStripMenuItem");
            // 
            // toolStrip_tb_X_A_scale
            // 
            this.toolStrip_tb_X_A_scale.Name = "toolStrip_tb_X_A_scale";
            resources.ApplyResources(this.toolStrip_tb_X_A_scale, "toolStrip_tb_X_A_scale");
            this.toolStrip_tb_X_A_scale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStrip_tb_X_A_scale_KeyDown);
            // 
            // skaliereYAufDrehachseToolStripMenuItem
            // 
            this.skaliereYAufDrehachseToolStripMenuItem.AutoToolTip = true;
            this.skaliereYAufDrehachseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_tb_Y_A_scale});
            this.skaliereYAufDrehachseToolStripMenuItem.Name = "skaliereYAufDrehachseToolStripMenuItem";
            resources.ApplyResources(this.skaliereYAufDrehachseToolStripMenuItem, "skaliereYAufDrehachseToolStripMenuItem");
            // 
            // toolStrip_tb_Y_A_scale
            // 
            this.toolStrip_tb_Y_A_scale.Name = "toolStrip_tb_Y_A_scale";
            resources.ApplyResources(this.toolStrip_tb_Y_A_scale, "toolStrip_tb_Y_A_scale");
            this.toolStrip_tb_Y_A_scale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStrip_tb_Y_A_scale_KeyDown);
            // 
            // ersetzteG23DurchLinienToolStripMenuItem
            // 
            this.ersetzteG23DurchLinienToolStripMenuItem.Name = "ersetzteG23DurchLinienToolStripMenuItem";
            resources.ApplyResources(this.ersetzteG23DurchLinienToolStripMenuItem, "ersetzteG23DurchLinienToolStripMenuItem");
            this.ersetzteG23DurchLinienToolStripMenuItem.Click += new System.EventHandler(this.ersetzteG23DurchLinienToolStripMenuItem_Click);
            // 
            // machineToolStripMenuItem
            // 
            this.machineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.heightMapToolStripMenuItem,
            this.controlStreamingToolStripMenuItem,
            this.control2ndGRBLToolStripMenuItem,
            this.toolStripMenuItem1,
            this.setupToolStripMenuItem});
            this.machineToolStripMenuItem.Name = "machineToolStripMenuItem";
            resources.ApplyResources(this.machineToolStripMenuItem, "machineToolStripMenuItem");
            // 
            // heightMapToolStripMenuItem
            // 
            this.heightMapToolStripMenuItem.Name = "heightMapToolStripMenuItem";
            resources.ApplyResources(this.heightMapToolStripMenuItem, "heightMapToolStripMenuItem");
            this.heightMapToolStripMenuItem.Click += new System.EventHandler(this.heightMapToolStripMenuItem_Click);
            // 
            // controlStreamingToolStripMenuItem
            // 
            this.controlStreamingToolStripMenuItem.Name = "controlStreamingToolStripMenuItem";
            resources.ApplyResources(this.controlStreamingToolStripMenuItem, "controlStreamingToolStripMenuItem");
            this.controlStreamingToolStripMenuItem.Click += new System.EventHandler(this.controlStreamingToolStripMenuItem_Click);
            // 
            // control2ndGRBLToolStripMenuItem
            // 
            this.control2ndGRBLToolStripMenuItem.Name = "control2ndGRBLToolStripMenuItem";
            resources.ApplyResources(this.control2ndGRBLToolStripMenuItem, "control2ndGRBLToolStripMenuItem");
            this.control2ndGRBLToolStripMenuItem.Click += new System.EventHandler(this.control2ndGRBLToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Click += new System.EventHandler(this.cameraToolStripMenuItem_Click);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            resources.ApplyResources(this.setupToolStripMenuItem, "setupToolStripMenuItem");
            this.setupToolStripMenuItem.Click += new System.EventHandler(this.setupToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainTimer
            // 
            this.MainTimer.Enabled = true;
            this.MainTimer.Interval = 500;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOverrideSSGB);
            this.groupBox1.Controls.Add(this.btnOverrideFRGB);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.lbDimension);
            this.groupBox1.Controls.Add(this.pbBuffer);
            this.groupBox1.Controls.Add(this.btnStreamStop);
            this.groupBox1.Controls.Add(this.btnStreamCheck);
            this.groupBox1.Controls.Add(this.lbInfo);
            this.groupBox1.Controls.Add(this.lblRemaining);
            this.groupBox1.Controls.Add(this.pbFile);
            this.groupBox1.Controls.Add(this.lblElapsed);
            this.groupBox1.Controls.Add(this.lblFileProgress);
            this.groupBox1.Controls.Add(this.btnStreamStart);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btnOverrideSSGB
            // 
            this.btnOverrideSSGB.Controls.Add(this.label8);
            this.btnOverrideSSGB.Controls.Add(this.label10);
            this.btnOverrideSSGB.Controls.Add(this.lblOverrideSSValue);
            this.btnOverrideSSGB.Controls.Add(this.btnOverrideSS2);
            this.btnOverrideSSGB.Controls.Add(this.btnOverrideSS0);
            this.btnOverrideSSGB.Controls.Add(this.btnOverrideSS1);
            this.btnOverrideSSGB.Controls.Add(this.btnOverrideSS4);
            this.btnOverrideSSGB.Controls.Add(this.btnOverrideSS3);
            resources.ApplyResources(this.btnOverrideSSGB, "btnOverrideSSGB");
            this.btnOverrideSSGB.Name = "btnOverrideSSGB";
            this.btnOverrideSSGB.TabStop = false;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // lblOverrideSSValue
            // 
            resources.ApplyResources(this.lblOverrideSSValue, "lblOverrideSSValue");
            this.lblOverrideSSValue.Name = "lblOverrideSSValue";
            // 
            // btnOverrideSS2
            // 
            resources.ApplyResources(this.btnOverrideSS2, "btnOverrideSS2");
            this.btnOverrideSS2.Name = "btnOverrideSS2";
            this.btnOverrideSS2.UseVisualStyleBackColor = true;
            this.btnOverrideSS2.Click += new System.EventHandler(this.btnOverrideSS2_Click);
            // 
            // btnOverrideSS0
            // 
            resources.ApplyResources(this.btnOverrideSS0, "btnOverrideSS0");
            this.btnOverrideSS0.Name = "btnOverrideSS0";
            this.btnOverrideSS0.UseVisualStyleBackColor = true;
            this.btnOverrideSS0.Click += new System.EventHandler(this.btnOverrideSS0_Click);
            // 
            // btnOverrideSS1
            // 
            resources.ApplyResources(this.btnOverrideSS1, "btnOverrideSS1");
            this.btnOverrideSS1.Name = "btnOverrideSS1";
            this.btnOverrideSS1.UseVisualStyleBackColor = true;
            this.btnOverrideSS1.Click += new System.EventHandler(this.btnOverrideSS1_Click);
            // 
            // btnOverrideSS4
            // 
            resources.ApplyResources(this.btnOverrideSS4, "btnOverrideSS4");
            this.btnOverrideSS4.Name = "btnOverrideSS4";
            this.btnOverrideSS4.UseVisualStyleBackColor = true;
            this.btnOverrideSS4.Click += new System.EventHandler(this.btnOverrideSS4_Click);
            // 
            // btnOverrideSS3
            // 
            resources.ApplyResources(this.btnOverrideSS3, "btnOverrideSS3");
            this.btnOverrideSS3.Name = "btnOverrideSS3";
            this.btnOverrideSS3.UseVisualStyleBackColor = true;
            this.btnOverrideSS3.Click += new System.EventHandler(this.btnOverrideSS3_Click);
            // 
            // btnOverrideFRGB
            // 
            this.btnOverrideFRGB.Controls.Add(this.label5);
            this.btnOverrideFRGB.Controls.Add(this.label7);
            this.btnOverrideFRGB.Controls.Add(this.lblOverrideFRValue);
            this.btnOverrideFRGB.Controls.Add(this.btnOverrideFR1);
            this.btnOverrideFRGB.Controls.Add(this.btnOverrideFR2);
            this.btnOverrideFRGB.Controls.Add(this.btnOverrideFR0);
            this.btnOverrideFRGB.Controls.Add(this.btnOverrideFR4);
            this.btnOverrideFRGB.Controls.Add(this.btnOverrideFR3);
            resources.ApplyResources(this.btnOverrideFRGB, "btnOverrideFRGB");
            this.btnOverrideFRGB.Name = "btnOverrideFRGB";
            this.btnOverrideFRGB.TabStop = false;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // lblOverrideFRValue
            // 
            resources.ApplyResources(this.lblOverrideFRValue, "lblOverrideFRValue");
            this.lblOverrideFRValue.Name = "lblOverrideFRValue";
            // 
            // btnOverrideFR1
            // 
            resources.ApplyResources(this.btnOverrideFR1, "btnOverrideFR1");
            this.btnOverrideFR1.Name = "btnOverrideFR1";
            this.btnOverrideFR1.UseVisualStyleBackColor = true;
            this.btnOverrideFR1.Click += new System.EventHandler(this.btnOverrideFR1_Click);
            // 
            // btnOverrideFR2
            // 
            resources.ApplyResources(this.btnOverrideFR2, "btnOverrideFR2");
            this.btnOverrideFR2.Name = "btnOverrideFR2";
            this.btnOverrideFR2.UseVisualStyleBackColor = true;
            this.btnOverrideFR2.Click += new System.EventHandler(this.btnOverrideFR2_Click);
            // 
            // btnOverrideFR0
            // 
            resources.ApplyResources(this.btnOverrideFR0, "btnOverrideFR0");
            this.btnOverrideFR0.Name = "btnOverrideFR0";
            this.btnOverrideFR0.UseVisualStyleBackColor = true;
            this.btnOverrideFR0.Click += new System.EventHandler(this.btnOverrideFR0_Click);
            // 
            // btnOverrideFR4
            // 
            resources.ApplyResources(this.btnOverrideFR4, "btnOverrideFR4");
            this.btnOverrideFR4.Name = "btnOverrideFR4";
            this.btnOverrideFR4.UseVisualStyleBackColor = true;
            this.btnOverrideFR4.Click += new System.EventHandler(this.btnOverrideFR4_Click);
            // 
            // btnOverrideFR3
            // 
            resources.ApplyResources(this.btnOverrideFR3, "btnOverrideFR3");
            this.btnOverrideFR3.Name = "btnOverrideFR3";
            this.btnOverrideFR3.UseVisualStyleBackColor = true;
            this.btnOverrideFR3.Click += new System.EventHandler(this.btnOverrideFR3_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnOffsetApply);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.tbOffsetY);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.tbOffsetX);
            this.groupBox4.Controls.Add(this.rBOrigin9);
            this.groupBox4.Controls.Add(this.rBOrigin8);
            this.groupBox4.Controls.Add(this.rBOrigin7);
            this.groupBox4.Controls.Add(this.rBOrigin6);
            this.groupBox4.Controls.Add(this.rBOrigin5);
            this.groupBox4.Controls.Add(this.rBOrigin4);
            this.groupBox4.Controls.Add(this.rBOrigin3);
            this.groupBox4.Controls.Add(this.tbFile);
            this.groupBox4.Controls.Add(this.btnOpenFile);
            this.groupBox4.Controls.Add(this.rBOrigin2);
            this.groupBox4.Controls.Add(this.rBOrigin1);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // btnOffsetApply
            // 
            resources.ApplyResources(this.btnOffsetApply, "btnOffsetApply");
            this.btnOffsetApply.Name = "btnOffsetApply";
            this.btnOffsetApply.UseVisualStyleBackColor = true;
            this.btnOffsetApply.Click += new System.EventHandler(this.btnOffsetApply_Click);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // tbOffsetY
            // 
            resources.ApplyResources(this.tbOffsetY, "tbOffsetY");
            this.tbOffsetY.Name = "tbOffsetY";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tbOffsetX
            // 
            resources.ApplyResources(this.tbOffsetX, "tbOffsetX");
            this.tbOffsetX.Name = "tbOffsetX";
            // 
            // rBOrigin9
            // 
            resources.ApplyResources(this.rBOrigin9, "rBOrigin9");
            this.rBOrigin9.Name = "rBOrigin9";
            this.rBOrigin9.UseVisualStyleBackColor = true;
            // 
            // rBOrigin8
            // 
            resources.ApplyResources(this.rBOrigin8, "rBOrigin8");
            this.rBOrigin8.Name = "rBOrigin8";
            this.rBOrigin8.UseVisualStyleBackColor = true;
            // 
            // rBOrigin7
            // 
            resources.ApplyResources(this.rBOrigin7, "rBOrigin7");
            this.rBOrigin7.Name = "rBOrigin7";
            this.rBOrigin7.UseVisualStyleBackColor = true;
            // 
            // rBOrigin6
            // 
            resources.ApplyResources(this.rBOrigin6, "rBOrigin6");
            this.rBOrigin6.Name = "rBOrigin6";
            this.rBOrigin6.UseVisualStyleBackColor = true;
            // 
            // rBOrigin5
            // 
            resources.ApplyResources(this.rBOrigin5, "rBOrigin5");
            this.rBOrigin5.Checked = true;
            this.rBOrigin5.Name = "rBOrigin5";
            this.rBOrigin5.TabStop = true;
            this.rBOrigin5.UseVisualStyleBackColor = true;
            // 
            // rBOrigin4
            // 
            resources.ApplyResources(this.rBOrigin4, "rBOrigin4");
            this.rBOrigin4.Name = "rBOrigin4";
            this.rBOrigin4.UseVisualStyleBackColor = true;
            // 
            // rBOrigin3
            // 
            resources.ApplyResources(this.rBOrigin3, "rBOrigin3");
            this.rBOrigin3.Name = "rBOrigin3";
            this.rBOrigin3.UseVisualStyleBackColor = true;
            // 
            // tbFile
            // 
            resources.ApplyResources(this.tbFile, "tbFile");
            this.tbFile.Name = "tbFile";
            // 
            // btnOpenFile
            // 
            resources.ApplyResources(this.btnOpenFile, "btnOpenFile");
            this.btnOpenFile.Name = "btnOpenFile";
            this.toolTip1.SetToolTip(this.btnOpenFile, resources.GetString("btnOpenFile.ToolTip"));
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // rBOrigin2
            // 
            resources.ApplyResources(this.rBOrigin2, "rBOrigin2");
            this.rBOrigin2.Name = "rBOrigin2";
            this.rBOrigin2.UseVisualStyleBackColor = true;
            // 
            // rBOrigin1
            // 
            resources.ApplyResources(this.rBOrigin1, "rBOrigin1");
            this.rBOrigin1.Name = "rBOrigin1";
            this.rBOrigin1.UseVisualStyleBackColor = true;
            // 
            // lbDimension
            // 
            this.lbDimension.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.lbDimension, "lbDimension");
            this.lbDimension.HideSelection = false;
            this.lbDimension.Name = "lbDimension";
            this.lbDimension.ReadOnly = true;
            // 
            // pbBuffer
            // 
            resources.ApplyResources(this.pbBuffer, "pbBuffer");
            this.pbBuffer.Name = "pbBuffer";
            // 
            // btnStreamStop
            // 
            this.btnStreamStop.Image = global::GRBL_Plotter.Properties.Resources.btn_stop;
            resources.ApplyResources(this.btnStreamStop, "btnStreamStop");
            this.btnStreamStop.Name = "btnStreamStop";
            this.toolTip1.SetToolTip(this.btnStreamStop, resources.GetString("btnStreamStop.ToolTip"));
            this.btnStreamStop.UseVisualStyleBackColor = true;
            this.btnStreamStop.Click += new System.EventHandler(this.btnStreamStop_Click);
            // 
            // btnStreamCheck
            // 
            resources.ApplyResources(this.btnStreamCheck, "btnStreamCheck");
            this.btnStreamCheck.Name = "btnStreamCheck";
            this.btnStreamCheck.UseVisualStyleBackColor = true;
            this.btnStreamCheck.Click += new System.EventHandler(this.btnStreamCheck_Click);
            // 
            // lbInfo
            // 
            resources.ApplyResources(this.lbInfo, "lbInfo");
            this.lbInfo.Name = "lbInfo";
            // 
            // lblRemaining
            // 
            resources.ApplyResources(this.lblRemaining, "lblRemaining");
            this.lblRemaining.Name = "lblRemaining";
            // 
            // pbFile
            // 
            resources.ApplyResources(this.pbFile, "pbFile");
            this.pbFile.Name = "pbFile";
            // 
            // lblElapsed
            // 
            resources.ApplyResources(this.lblElapsed, "lblElapsed");
            this.lblElapsed.Name = "lblElapsed";
            // 
            // lblFileProgress
            // 
            resources.ApplyResources(this.lblFileProgress, "lblFileProgress");
            this.lblFileProgress.Name = "lblFileProgress";
            // 
            // btnStreamStart
            // 
            this.btnStreamStart.Image = global::GRBL_Plotter.Properties.Resources.btn_play;
            resources.ApplyResources(this.btnStreamStart, "btnStreamStart");
            this.btnStreamStart.Name = "btnStreamStart";
            this.toolTip1.SetToolTip(this.btnStreamStart, resources.GetString("btnStreamStart.ToolTip"));
            this.btnStreamStart.UseVisualStyleBackColor = true;
            this.btnStreamStart.Click += new System.EventHandler(this.btnStreamStart_Click);
            // 
            // cmsCode
            // 
            this.cmsCode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsCodeSelect,
            this.cmsCodeCopy,
            this.cmsCodePaste,
            this.cmsCodeSendLine,
            this.saveToToolStripMenuItem});
            this.cmsCode.Name = "cmsCode";
            this.cmsCode.ShowImageMargin = false;
            resources.ApplyResources(this.cmsCode, "cmsCode");
            this.cmsCode.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsCode_ItemClicked);
            // 
            // cmsCodeSelect
            // 
            this.cmsCodeSelect.Name = "cmsCodeSelect";
            resources.ApplyResources(this.cmsCodeSelect, "cmsCodeSelect");
            // 
            // cmsCodeCopy
            // 
            this.cmsCodeCopy.Name = "cmsCodeCopy";
            resources.ApplyResources(this.cmsCodeCopy, "cmsCodeCopy");
            // 
            // cmsCodePaste
            // 
            this.cmsCodePaste.Name = "cmsCodePaste";
            resources.ApplyResources(this.cmsCodePaste, "cmsCodePaste");
            // 
            // cmsCodeSendLine
            // 
            this.cmsCodeSendLine.Name = "cmsCodeSendLine";
            resources.ApplyResources(this.cmsCodeSendLine, "cmsCodeSendLine");
            // 
            // saveToToolStripMenuItem
            // 
            this.saveToToolStripMenuItem.Name = "saveToToolStripMenuItem";
            resources.ApplyResources(this.saveToToolStripMenuItem, "saveToToolStripMenuItem");
            this.saveToToolStripMenuItem.Click += new System.EventHandler(this.saveToToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnJogZeroXY
            // 
            resources.ApplyResources(this.btnJogZeroXY, "btnJogZeroXY");
            this.btnJogZeroXY.Name = "btnJogZeroXY";
            this.toolTip1.SetToolTip(this.btnJogZeroXY, resources.GetString("btnJogZeroXY.ToolTip"));
            this.btnJogZeroXY.UseVisualStyleBackColor = true;
            this.btnJogZeroXY.Click += new System.EventHandler(this.btnJogXY_Click);
            // 
            // btnJogZeroZ
            // 
            resources.ApplyResources(this.btnJogZeroZ, "btnJogZeroZ");
            this.btnJogZeroZ.Name = "btnJogZeroZ";
            this.toolTip1.SetToolTip(this.btnJogZeroZ, resources.GetString("btnJogZeroZ.ToolTip"));
            this.btnJogZeroZ.UseVisualStyleBackColor = true;
            this.btnJogZeroZ.Click += new System.EventHandler(this.btnJogZ_Click);
            // 
            // btnJogZeroY
            // 
            resources.ApplyResources(this.btnJogZeroY, "btnJogZeroY");
            this.btnJogZeroY.Name = "btnJogZeroY";
            this.toolTip1.SetToolTip(this.btnJogZeroY, resources.GetString("btnJogZeroY.ToolTip"));
            this.btnJogZeroY.UseVisualStyleBackColor = true;
            this.btnJogZeroY.Click += new System.EventHandler(this.btnJogY_Click);
            // 
            // btnJogZeroX
            // 
            resources.ApplyResources(this.btnJogZeroX, "btnJogZeroX");
            this.btnJogZeroX.Name = "btnJogZeroX";
            this.toolTip1.SetToolTip(this.btnJogZeroX, resources.GetString("btnJogZeroX.ToolTip"));
            this.btnJogZeroX.UseVisualStyleBackColor = true;
            this.btnJogZeroX.Click += new System.EventHandler(this.btnJogX_Click);
            // 
            // btnFeedHold
            // 
            resources.ApplyResources(this.btnFeedHold, "btnFeedHold");
            this.btnFeedHold.Name = "btnFeedHold";
            this.toolTip1.SetToolTip(this.btnFeedHold, resources.GetString("btnFeedHold.ToolTip"));
            this.btnFeedHold.UseVisualStyleBackColor = true;
            this.btnFeedHold.Click += new System.EventHandler(this.btnFeedHold_Click);
            // 
            // btnReset
            // 
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.Name = "btnReset";
            this.toolTip1.SetToolTip(this.btnReset, resources.GetString("btnReset.ToolTip"));
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnResume
            // 
            resources.ApplyResources(this.btnResume, "btnResume");
            this.btnResume.Name = "btnResume";
            this.toolTip1.SetToolTip(this.btnResume, resources.GetString("btnResume.ToolTip"));
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnKillAlarm
            // 
            resources.ApplyResources(this.btnKillAlarm, "btnKillAlarm");
            this.btnKillAlarm.Name = "btnKillAlarm";
            this.toolTip1.SetToolTip(this.btnKillAlarm, resources.GetString("btnKillAlarm.ToolTip"));
            this.btnKillAlarm.UseVisualStyleBackColor = true;
            this.btnKillAlarm.Click += new System.EventHandler(this.btnKillAlarm_Click);
            // 
            // btnJogStop
            // 
            this.btnJogStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.btnJogStop, "btnJogStop");
            this.btnJogStop.Name = "btnJogStop";
            this.toolTip1.SetToolTip(this.btnJogStop, resources.GetString("btnJogStop.ToolTip"));
            this.btnJogStop.UseVisualStyleBackColor = false;
            this.btnJogStop.Click += new System.EventHandler(this.btnJogStop_Click);
            // 
            // btnJogZeroA
            // 
            resources.ApplyResources(this.btnJogZeroA, "btnJogZeroA");
            this.btnJogZeroA.Name = "btnJogZeroA";
            this.toolTip1.SetToolTip(this.btnJogZeroA, resources.GetString("btnJogZeroA.ToolTip"));
            this.btnJogZeroA.UseVisualStyleBackColor = true;
            this.btnJogZeroA.Click += new System.EventHandler(this.btnJogZeroA_Click);
            // 
            // virtualJoystickA
            // 
            resources.ApplyResources(this.virtualJoystickA, "virtualJoystickA");
            this.virtualJoystickA.Joystick2Dimension = false;
            this.virtualJoystickA.JoystickActive = System.Drawing.Color.Red;
            this.virtualJoystickA.JoystickLabel = new double[] {
        0.1D,
        0.5D,
        1D,
        5D,
        10D,
        50D};
            this.virtualJoystickA.JoystickRaster = 5;
            this.virtualJoystickA.JoystickStanby = System.Drawing.Color.Orange;
            this.virtualJoystickA.Name = "virtualJoystickA";
            this.toolTip1.SetToolTip(this.virtualJoystickA, resources.GetString("virtualJoystickA.ToolTip"));
            this.virtualJoystickA.JoyStickEvent += new virtualJoystick.JogEventHandler(this.virtualJoystickA_JoyStickEvent);
            this.virtualJoystickA.Enter += new System.EventHandler(this.virtualJoystickXY_Enter);
            this.virtualJoystickA.Leave += new System.EventHandler(this.virtualJoystickXY_Leave);
            // 
            // virtualJoystickZ
            // 
            resources.ApplyResources(this.virtualJoystickZ, "virtualJoystickZ");
            this.virtualJoystickZ.Joystick2Dimension = false;
            this.virtualJoystickZ.JoystickActive = System.Drawing.Color.Red;
            this.virtualJoystickZ.JoystickLabel = new double[] {
        0.1D,
        0.5D,
        1D,
        5D,
        10D,
        50D};
            this.virtualJoystickZ.JoystickRaster = 5;
            this.virtualJoystickZ.JoystickStanby = System.Drawing.Color.Orange;
            this.virtualJoystickZ.Name = "virtualJoystickZ";
            this.toolTip1.SetToolTip(this.virtualJoystickZ, resources.GetString("virtualJoystickZ.ToolTip"));
            this.virtualJoystickZ.JoyStickEvent += new virtualJoystick.JogEventHandler(this.virtualJoystickZ_JoyStickEvent);
            this.virtualJoystickZ.Enter += new System.EventHandler(this.virtualJoystickXY_Enter);
            this.virtualJoystickZ.Leave += new System.EventHandler(this.virtualJoystickXY_Leave);
            // 
            // virtualJoystickXY
            // 
            resources.ApplyResources(this.virtualJoystickXY, "virtualJoystickXY");
            this.virtualJoystickXY.Joystick2Dimension = true;
            this.virtualJoystickXY.JoystickActive = System.Drawing.Color.Red;
            this.virtualJoystickXY.JoystickLabel = new double[] {
        0.1D,
        0.5D,
        1D,
        5D,
        10D,
        50D};
            this.virtualJoystickXY.JoystickRaster = 5;
            this.virtualJoystickXY.JoystickStanby = System.Drawing.Color.Orange;
            this.virtualJoystickXY.Name = "virtualJoystickXY";
            this.toolTip1.SetToolTip(this.virtualJoystickXY, resources.GetString("virtualJoystickXY.ToolTip"));
            this.virtualJoystickXY.JoyStickEvent += new virtualJoystick.JogEventHandler(this.virtualJoystickXY_JoyStickEvent);
            this.virtualJoystickXY.Enter += new System.EventHandler(this.virtualJoystickXY_Enter);
            this.virtualJoystickXY.Leave += new System.EventHandler(this.virtualJoystickXY_Leave);
            // 
            // btnZeroX
            // 
            resources.ApplyResources(this.btnZeroX, "btnZeroX");
            this.btnZeroX.Name = "btnZeroX";
            this.toolTip1.SetToolTip(this.btnZeroX, resources.GetString("btnZeroX.ToolTip"));
            this.btnZeroX.UseVisualStyleBackColor = true;
            this.btnZeroX.Click += new System.EventHandler(this.btnZeroX_Click);
            // 
            // btnZeroY
            // 
            resources.ApplyResources(this.btnZeroY, "btnZeroY");
            this.btnZeroY.Name = "btnZeroY";
            this.toolTip1.SetToolTip(this.btnZeroY, resources.GetString("btnZeroY.ToolTip"));
            this.btnZeroY.UseVisualStyleBackColor = true;
            this.btnZeroY.Click += new System.EventHandler(this.btnZeroY_Click);
            // 
            // btnZeroZ
            // 
            resources.ApplyResources(this.btnZeroZ, "btnZeroZ");
            this.btnZeroZ.Name = "btnZeroZ";
            this.toolTip1.SetToolTip(this.btnZeroZ, resources.GetString("btnZeroZ.ToolTip"));
            this.btnZeroZ.UseVisualStyleBackColor = true;
            this.btnZeroZ.Click += new System.EventHandler(this.btnZeroZ_Click);
            // 
            // btnZeroXY
            // 
            resources.ApplyResources(this.btnZeroXY, "btnZeroXY");
            this.btnZeroXY.Name = "btnZeroXY";
            this.toolTip1.SetToolTip(this.btnZeroXY, resources.GetString("btnZeroXY.ToolTip"));
            this.btnZeroXY.UseVisualStyleBackColor = true;
            this.btnZeroXY.Click += new System.EventHandler(this.btnZeroXY_Click);
            // 
            // btnZeroXYZ
            // 
            resources.ApplyResources(this.btnZeroXYZ, "btnZeroXYZ");
            this.btnZeroXYZ.Name = "btnZeroXYZ";
            this.toolTip1.SetToolTip(this.btnZeroXYZ, resources.GetString("btnZeroXYZ.ToolTip"));
            this.btnZeroXYZ.UseVisualStyleBackColor = true;
            this.btnZeroXYZ.Click += new System.EventHandler(this.btnZeroXYZ_Click);
            // 
            // btnHome
            // 
            resources.ApplyResources(this.btnHome, "btnHome");
            this.btnHome.Name = "btnHome";
            this.toolTip1.SetToolTip(this.btnHome, resources.GetString("btnHome.ToolTip"));
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnZeroA
            // 
            resources.ApplyResources(this.btnZeroA, "btnZeroA");
            this.btnZeroA.Name = "btnZeroA";
            this.toolTip1.SetToolTip(this.btnZeroA, resources.GetString("btnZeroA.ToolTip"));
            this.btnZeroA.UseVisualStyleBackColor = true;
            this.btnZeroA.Click += new System.EventHandler(this.btnZeroA_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnResume);
            this.groupBox6.Controls.Add(this.virtualJoystickA);
            this.groupBox6.Controls.Add(this.btnJogStop);
            this.groupBox6.Controls.Add(this.groupBox3);
            this.groupBox6.Controls.Add(this.lblTool);
            this.groupBox6.Controls.Add(this.cBTool);
            this.groupBox6.Controls.Add(this.virtualJoystickZ);
            this.groupBox6.Controls.Add(this.virtualJoystickXY);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.tBSpeed);
            this.groupBox6.Controls.Add(this.cBCoolant);
            this.groupBox6.Controls.Add(this.cBSpindle);
            this.groupBox6.Controls.Add(this.btnKillAlarm);
            this.groupBox6.Controls.Add(this.btnFeedHold);
            this.groupBox6.Controls.Add(this.btnReset);
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnJogZeroA);
            this.groupBox3.Controls.Add(this.btnJogZeroX);
            this.groupBox3.Controls.Add(this.btnJogZeroXY);
            this.groupBox3.Controls.Add(this.btnJogZeroY);
            this.groupBox3.Controls.Add(this.btnJogZeroZ);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // lblTool
            // 
            resources.ApplyResources(this.lblTool, "lblTool");
            this.lblTool.Name = "lblTool";
            // 
            // cBTool
            // 
            resources.ApplyResources(this.cBTool, "cBTool");
            this.cBTool.Name = "cBTool";
            this.cBTool.UseVisualStyleBackColor = true;
            this.cBTool.CheckedChanged += new System.EventHandler(this.cBTool_CheckedChanged);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // tBSpeed
            // 
            resources.ApplyResources(this.tBSpeed, "tBSpeed");
            this.tBSpeed.Name = "tBSpeed";
            // 
            // cBCoolant
            // 
            resources.ApplyResources(this.cBCoolant, "cBCoolant");
            this.cBCoolant.Name = "cBCoolant";
            this.cBCoolant.UseVisualStyleBackColor = true;
            this.cBCoolant.CheckedChanged += new System.EventHandler(this.cBCoolant_CheckedChanged);
            // 
            // cBSpindle
            // 
            resources.ApplyResources(this.cBSpindle, "cBSpindle");
            this.cBSpindle.Name = "cBSpindle";
            this.cBSpindle.UseVisualStyleBackColor = true;
            this.cBSpindle.CheckedChanged += new System.EventHandler(this.cBSpindle_CheckedChanged);
            // 
            // fCTBCode
            // 
            this.fCTBCode.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fCTBCode.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+\\s*(?<range>=)\\s*(?<range>[^;]+);";
            resources.ApplyResources(this.fCTBCode, "fCTBCode");
            this.fCTBCode.BackBrush = null;
            this.fCTBCode.CharHeight = 13;
            this.fCTBCode.CharWidth = 7;
            this.fCTBCode.ContextMenuStrip = this.cmsCode;
            this.fCTBCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fCTBCode.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fCTBCode.IsReplaceMode = false;
            this.fCTBCode.Name = "fCTBCode";
            this.fCTBCode.Paddings = new System.Windows.Forms.Padding(0);
            this.fCTBCode.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fCTBCode.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fCTBCode.ServiceColors")));
            this.fCTBCode.ToolTip = null;
            this.fCTBCode.Zoom = 100;
            this.fCTBCode.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fCTBCode_TextChanged);
            this.fCTBCode.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fCTBCode_TextChangedDelayed);
            this.fCTBCode.Click += new System.EventHandler(this.fCTBCode_Click);
            this.fCTBCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fCTBCode_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = global::GRBL_Plotter.Properties.Resources.modell2;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.ContextMenuStrip = this.cmsPictureBox;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.SizeChanged += new System.EventHandler(this.pictureBox1_SizeChanged);
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseWheel);
            // 
            // cmsPictureBox
            // 
            this.cmsPictureBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteFromClipboardToolStripMenuItem,
            this.toolStripSeparator9,
            this.resetZoomingToolStripMenuItem,
            this.toolStripSeparator8,
            this.deletenotMarkToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteThisCodeLineToolStripMenuItem,
            this.moveToFirstPosToolStripMenuItem,
            this.deletePathToolStripMenuItem,
            this.switchTheColorToolStripMenuItem});
            this.cmsPictureBox.Name = "cmsPictureBox";
            resources.ApplyResources(this.cmsPictureBox, "cmsPictureBox");
            // 
            // pasteFromClipboardToolStripMenuItem
            // 
            this.pasteFromClipboardToolStripMenuItem.Name = "pasteFromClipboardToolStripMenuItem";
            resources.ApplyResources(this.pasteFromClipboardToolStripMenuItem, "pasteFromClipboardToolStripMenuItem");
            this.pasteFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.pasteFromClipboardToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            // 
            // resetZoomingToolStripMenuItem
            // 
            this.resetZoomingToolStripMenuItem.Name = "resetZoomingToolStripMenuItem";
            resources.ApplyResources(this.resetZoomingToolStripMenuItem, "resetZoomingToolStripMenuItem");
            this.resetZoomingToolStripMenuItem.Click += new System.EventHandler(this.resetZoomingToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // deletenotMarkToolStripMenuItem
            // 
            this.deletenotMarkToolStripMenuItem.Name = "deletenotMarkToolStripMenuItem";
            resources.ApplyResources(this.deletenotMarkToolStripMenuItem, "deletenotMarkToolStripMenuItem");
            this.deletenotMarkToolStripMenuItem.Click += new System.EventHandler(this.deletenotMarkToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // deleteThisCodeLineToolStripMenuItem
            // 
            this.deleteThisCodeLineToolStripMenuItem.Name = "deleteThisCodeLineToolStripMenuItem";
            resources.ApplyResources(this.deleteThisCodeLineToolStripMenuItem, "deleteThisCodeLineToolStripMenuItem");
            this.deleteThisCodeLineToolStripMenuItem.Click += new System.EventHandler(this.deleteThisCodeLineToolStripMenuItem_Click);
            // 
            // moveToFirstPosToolStripMenuItem
            // 
            this.moveToFirstPosToolStripMenuItem.Name = "moveToFirstPosToolStripMenuItem";
            resources.ApplyResources(this.moveToFirstPosToolStripMenuItem, "moveToFirstPosToolStripMenuItem");
            this.moveToFirstPosToolStripMenuItem.Click += new System.EventHandler(this.moveToFirstPosToolStripMenuItem_Click);
            // 
            // deletePathToolStripMenuItem
            // 
            this.deletePathToolStripMenuItem.Name = "deletePathToolStripMenuItem";
            resources.ApplyResources(this.deletePathToolStripMenuItem, "deletePathToolStripMenuItem");
            this.deletePathToolStripMenuItem.Click += new System.EventHandler(this.deletePathToolStripMenuItem_Click);
            // 
            // switchTheColorToolStripMenuItem
            // 
            this.switchTheColorToolStripMenuItem.Name = "switchTheColorToolStripMenuItem";
            resources.ApplyResources(this.switchTheColorToolStripMenuItem, "switchTheColorToolStripMenuItem");
            this.switchTheColorToolStripMenuItem.Click += new System.EventHandler(this.switchTheColorToolStripMenuItem_Click);
            // 
            // tLPAussen
            // 
            resources.ApplyResources(this.tLPAussen, "tLPAussen");
            this.tLPAussen.Controls.Add(this.tLPLinks, 0, 0);
            this.tLPAussen.Controls.Add(this.tLPRechts, 1, 0);
            this.tLPAussen.Name = "tLPAussen";
            // 
            // tLPLinks
            // 
            resources.ApplyResources(this.tLPLinks, "tLPLinks");
            this.tLPLinks.Controls.Add(this.fCTBCode, 0, 1);
            this.tLPLinks.Controls.Add(this.groupBox1, 0, 0);
            this.tLPLinks.Name = "tLPLinks";
            // 
            // tLPRechts
            // 
            resources.ApplyResources(this.tLPRechts, "tLPRechts");
            this.tLPRechts.Controls.Add(this.tLPRechtsUnten, 0, 1);
            this.tLPRechts.Controls.Add(this.tLPRechtsOben, 0, 0);
            this.tLPRechts.Name = "tLPRechts";
            // 
            // tLPRechtsUnten
            // 
            resources.ApplyResources(this.tLPRechtsUnten, "tLPRechtsUnten");
            this.tLPRechtsUnten.Controls.Add(this.tLPRechtsUntenRechts, 1, 0);
            this.tLPRechtsUnten.Controls.Add(this.tLPMitteUnten, 0, 0);
            this.tLPRechtsUnten.Name = "tLPRechtsUnten";
            // 
            // tLPRechtsUntenRechts
            // 
            resources.ApplyResources(this.tLPRechtsUntenRechts, "tLPRechtsUntenRechts");
            this.tLPRechtsUntenRechts.Controls.Add(this.groupBox6, 0, 0);
            this.tLPRechtsUntenRechts.Name = "tLPRechtsUntenRechts";
            // 
            // tLPMitteUnten
            // 
            resources.ApplyResources(this.tLPMitteUnten, "tLPMitteUnten");
            this.tLPMitteUnten.BackColor = System.Drawing.SystemColors.Control;
            this.tLPMitteUnten.Controls.Add(this.pictureBox1, 0, 0);
            this.tLPMitteUnten.Controls.Add(this.txt_K10, 1, 0);
            this.tLPMitteUnten.Name = "tLPMitteUnten";
            // 
            // txt_K10
            // 
            this.txt_K10.Controls.Add(this.button1);
            this.txt_K10.Controls.Add(this.radioButton32);
            this.txt_K10.Controls.Add(this.radioButton16);
            this.txt_K10.Controls.Add(this.radioButton31);
            this.txt_K10.Controls.Add(this.radioButton8);
            this.txt_K10.Controls.Add(this.radioButton30);
            this.txt_K10.Controls.Add(this.radioButton15);
            this.txt_K10.Controls.Add(this.radioButton29);
            this.txt_K10.Controls.Add(this.radioButton7);
            this.txt_K10.Controls.Add(this.radioButton28);
            this.txt_K10.Controls.Add(this.radioButton27);
            this.txt_K10.Controls.Add(this.radioButton14);
            this.txt_K10.Controls.Add(this.radioButton26);
            this.txt_K10.Controls.Add(this.radioButton13);
            this.txt_K10.Controls.Add(this.radioButton25);
            this.txt_K10.Controls.Add(this.radioButton6);
            this.txt_K10.Controls.Add(this.radioButton24);
            this.txt_K10.Controls.Add(this.radioButton12);
            this.txt_K10.Controls.Add(this.radioButton23);
            this.txt_K10.Controls.Add(this.radioButton5);
            this.txt_K10.Controls.Add(this.radioButton22);
            this.txt_K10.Controls.Add(this.radioButton11);
            this.txt_K10.Controls.Add(this.radioButton21);
            this.txt_K10.Controls.Add(this.radioButton4);
            this.txt_K10.Controls.Add(this.radioButton20);
            this.txt_K10.Controls.Add(this.radioButton10);
            this.txt_K10.Controls.Add(this.radioButton19);
            this.txt_K10.Controls.Add(this.radioButton3);
            this.txt_K10.Controls.Add(this.radioButton18);
            this.txt_K10.Controls.Add(this.radioButton9);
            this.txt_K10.Controls.Add(this.radioButton17);
            this.txt_K10.Controls.Add(this.radioButton2);
            this.txt_K10.Controls.Add(this.radioButton1);
            this.txt_K10.Controls.Add(this.label49);
            this.txt_K10.Controls.Add(this.label48);
            this.txt_K10.Controls.Add(this.label47);
            this.txt_K10.Controls.Add(this.label46);
            this.txt_K10.Controls.Add(this.label45);
            this.txt_K10.Controls.Add(this.label44);
            this.txt_K10.Controls.Add(this.label43);
            this.txt_K10.Controls.Add(this.label42);
            this.txt_K10.Controls.Add(this.label41);
            this.txt_K10.Controls.Add(this.label40);
            this.txt_K10.Controls.Add(this.label39);
            this.txt_K10.Controls.Add(this.label38);
            this.txt_K10.Controls.Add(this.label37);
            this.txt_K10.Controls.Add(this.label36);
            this.txt_K10.Controls.Add(this.label33);
            this.txt_K10.Controls.Add(this.label32);
            resources.ApplyResources(this.txt_K10, "txt_K10");
            this.txt_K10.Name = "txt_K10";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton32
            // 
            resources.ApplyResources(this.radioButton32, "radioButton32");
            this.radioButton32.Name = "radioButton32";
            this.radioButton32.TabStop = true;
            this.radioButton32.UseVisualStyleBackColor = true;
            // 
            // radioButton16
            // 
            resources.ApplyResources(this.radioButton16, "radioButton16");
            this.radioButton16.Name = "radioButton16";
            this.radioButton16.TabStop = true;
            this.radioButton16.UseVisualStyleBackColor = true;
            // 
            // radioButton31
            // 
            resources.ApplyResources(this.radioButton31, "radioButton31");
            this.radioButton31.Name = "radioButton31";
            this.radioButton31.TabStop = true;
            this.radioButton31.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            resources.ApplyResources(this.radioButton8, "radioButton8");
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.TabStop = true;
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton30
            // 
            resources.ApplyResources(this.radioButton30, "radioButton30");
            this.radioButton30.Name = "radioButton30";
            this.radioButton30.TabStop = true;
            this.radioButton30.UseVisualStyleBackColor = true;
            // 
            // radioButton15
            // 
            resources.ApplyResources(this.radioButton15, "radioButton15");
            this.radioButton15.Name = "radioButton15";
            this.radioButton15.TabStop = true;
            this.radioButton15.UseVisualStyleBackColor = true;
            // 
            // radioButton29
            // 
            resources.ApplyResources(this.radioButton29, "radioButton29");
            this.radioButton29.Name = "radioButton29";
            this.radioButton29.TabStop = true;
            this.radioButton29.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            resources.ApplyResources(this.radioButton7, "radioButton7");
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.TabStop = true;
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton28
            // 
            resources.ApplyResources(this.radioButton28, "radioButton28");
            this.radioButton28.Name = "radioButton28";
            this.radioButton28.TabStop = true;
            this.radioButton28.UseVisualStyleBackColor = true;
            // 
            // radioButton27
            // 
            resources.ApplyResources(this.radioButton27, "radioButton27");
            this.radioButton27.Name = "radioButton27";
            this.radioButton27.TabStop = true;
            this.radioButton27.UseVisualStyleBackColor = true;
            // 
            // radioButton14
            // 
            resources.ApplyResources(this.radioButton14, "radioButton14");
            this.radioButton14.Name = "radioButton14";
            this.radioButton14.TabStop = true;
            this.radioButton14.UseVisualStyleBackColor = true;
            // 
            // radioButton26
            // 
            resources.ApplyResources(this.radioButton26, "radioButton26");
            this.radioButton26.Name = "radioButton26";
            this.radioButton26.TabStop = true;
            this.radioButton26.UseVisualStyleBackColor = true;
            // 
            // radioButton13
            // 
            resources.ApplyResources(this.radioButton13, "radioButton13");
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.TabStop = true;
            this.radioButton13.UseVisualStyleBackColor = true;
            // 
            // radioButton25
            // 
            resources.ApplyResources(this.radioButton25, "radioButton25");
            this.radioButton25.Name = "radioButton25";
            this.radioButton25.TabStop = true;
            this.radioButton25.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            resources.ApplyResources(this.radioButton6, "radioButton6");
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.TabStop = true;
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton24
            // 
            resources.ApplyResources(this.radioButton24, "radioButton24");
            this.radioButton24.Name = "radioButton24";
            this.radioButton24.TabStop = true;
            this.radioButton24.UseVisualStyleBackColor = true;
            // 
            // radioButton12
            // 
            resources.ApplyResources(this.radioButton12, "radioButton12");
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.TabStop = true;
            this.radioButton12.UseVisualStyleBackColor = true;
            // 
            // radioButton23
            // 
            resources.ApplyResources(this.radioButton23, "radioButton23");
            this.radioButton23.Name = "radioButton23";
            this.radioButton23.TabStop = true;
            this.radioButton23.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            resources.ApplyResources(this.radioButton5, "radioButton5");
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.TabStop = true;
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton22
            // 
            resources.ApplyResources(this.radioButton22, "radioButton22");
            this.radioButton22.Name = "radioButton22";
            this.radioButton22.TabStop = true;
            this.radioButton22.UseVisualStyleBackColor = true;
            // 
            // radioButton11
            // 
            resources.ApplyResources(this.radioButton11, "radioButton11");
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.TabStop = true;
            this.radioButton11.UseVisualStyleBackColor = true;
            // 
            // radioButton21
            // 
            resources.ApplyResources(this.radioButton21, "radioButton21");
            this.radioButton21.Name = "radioButton21";
            this.radioButton21.TabStop = true;
            this.radioButton21.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            resources.ApplyResources(this.radioButton4, "radioButton4");
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.TabStop = true;
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton20
            // 
            resources.ApplyResources(this.radioButton20, "radioButton20");
            this.radioButton20.Name = "radioButton20";
            this.radioButton20.TabStop = true;
            this.radioButton20.UseVisualStyleBackColor = true;
            // 
            // radioButton10
            // 
            resources.ApplyResources(this.radioButton10, "radioButton10");
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.TabStop = true;
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // radioButton19
            // 
            resources.ApplyResources(this.radioButton19, "radioButton19");
            this.radioButton19.Name = "radioButton19";
            this.radioButton19.TabStop = true;
            this.radioButton19.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            resources.ApplyResources(this.radioButton3, "radioButton3");
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.TabStop = true;
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton18
            // 
            resources.ApplyResources(this.radioButton18, "radioButton18");
            this.radioButton18.Name = "radioButton18";
            this.radioButton18.TabStop = true;
            this.radioButton18.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            resources.ApplyResources(this.radioButton9, "radioButton9");
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.TabStop = true;
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton17
            // 
            resources.ApplyResources(this.radioButton17, "radioButton17");
            this.radioButton17.Name = "radioButton17";
            this.radioButton17.TabStop = true;
            this.radioButton17.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label49
            // 
            resources.ApplyResources(this.label49, "label49");
            this.label49.Name = "label49";
            // 
            // label48
            // 
            resources.ApplyResources(this.label48, "label48");
            this.label48.Name = "label48";
            // 
            // label47
            // 
            resources.ApplyResources(this.label47, "label47");
            this.label47.Name = "label47";
            // 
            // label46
            // 
            resources.ApplyResources(this.label46, "label46");
            this.label46.Name = "label46";
            // 
            // label45
            // 
            resources.ApplyResources(this.label45, "label45");
            this.label45.Name = "label45";
            // 
            // label44
            // 
            resources.ApplyResources(this.label44, "label44");
            this.label44.Name = "label44";
            // 
            // label43
            // 
            resources.ApplyResources(this.label43, "label43");
            this.label43.Name = "label43";
            // 
            // label42
            // 
            resources.ApplyResources(this.label42, "label42");
            this.label42.Name = "label42";
            // 
            // label41
            // 
            resources.ApplyResources(this.label41, "label41");
            this.label41.Name = "label41";
            // 
            // label40
            // 
            resources.ApplyResources(this.label40, "label40");
            this.label40.Name = "label40";
            // 
            // label39
            // 
            resources.ApplyResources(this.label39, "label39");
            this.label39.Name = "label39";
            // 
            // label38
            // 
            resources.ApplyResources(this.label38, "label38");
            this.label38.Name = "label38";
            // 
            // label37
            // 
            resources.ApplyResources(this.label37, "label37");
            this.label37.Name = "label37";
            // 
            // label36
            // 
            resources.ApplyResources(this.label36, "label36");
            this.label36.Name = "label36";
            // 
            // label33
            // 
            resources.ApplyResources(this.label33, "label33");
            this.label33.Name = "label33";
            // 
            // label32
            // 
            resources.ApplyResources(this.label32, "label32");
            this.label32.Name = "label32";
            // 
            // tLPRechtsOben
            // 
            resources.ApplyResources(this.tLPRechtsOben, "tLPRechtsOben");
            this.tLPRechtsOben.Controls.Add(this.groupBox5, 1, 0);
            this.tLPRechtsOben.Controls.Add(this.groupBox2, 0, 0);
            this.tLPRechtsOben.Name = "tLPRechtsOben";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.btnCustom8, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCustom7, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCustom6, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCustom5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCustom1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCustom2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCustom3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCustom4, 0, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // btnCustom8
            // 
            resources.ApplyResources(this.btnCustom8, "btnCustom8");
            this.btnCustom8.Name = "btnCustom8";
            this.btnCustom8.UseVisualStyleBackColor = true;
            this.btnCustom8.Click += new System.EventHandler(this.btnCustomButton_Click);
            // 
            // btnCustom7
            // 
            resources.ApplyResources(this.btnCustom7, "btnCustom7");
            this.btnCustom7.Name = "btnCustom7";
            this.btnCustom7.UseVisualStyleBackColor = true;
            this.btnCustom7.Click += new System.EventHandler(this.btnCustomButton_Click);
            // 
            // btnCustom6
            // 
            resources.ApplyResources(this.btnCustom6, "btnCustom6");
            this.btnCustom6.Name = "btnCustom6";
            this.btnCustom6.UseVisualStyleBackColor = true;
            this.btnCustom6.Click += new System.EventHandler(this.btnCustomButton_Click);
            // 
            // btnCustom5
            // 
            resources.ApplyResources(this.btnCustom5, "btnCustom5");
            this.btnCustom5.Name = "btnCustom5";
            this.btnCustom5.UseVisualStyleBackColor = true;
            this.btnCustom5.Click += new System.EventHandler(this.btnCustomButton_Click);
            // 
            // btnCustom1
            // 
            resources.ApplyResources(this.btnCustom1, "btnCustom1");
            this.btnCustom1.Name = "btnCustom1";
            this.btnCustom1.UseVisualStyleBackColor = true;
            this.btnCustom1.Click += new System.EventHandler(this.btnCustomButton_Click);
            // 
            // btnCustom2
            // 
            resources.ApplyResources(this.btnCustom2, "btnCustom2");
            this.btnCustom2.Name = "btnCustom2";
            this.btnCustom2.UseVisualStyleBackColor = true;
            this.btnCustom2.Click += new System.EventHandler(this.btnCustomButton_Click);
            // 
            // btnCustom3
            // 
            resources.ApplyResources(this.btnCustom3, "btnCustom3");
            this.btnCustom3.Name = "btnCustom3";
            this.btnCustom3.UseVisualStyleBackColor = true;
            this.btnCustom3.Click += new System.EventHandler(this.btnCustomButton_Click);
            // 
            // btnCustom4
            // 
            resources.ApplyResources(this.btnCustom4, "btnCustom4");
            this.btnCustom4.Name = "btnCustom4";
            this.btnCustom4.UseVisualStyleBackColor = true;
            this.btnCustom4.Click += new System.EventHandler(this.btnCustomButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.com_TappingSetting);
            this.groupBox2.Controls.Add(this.com_drillingSetting);
            this.groupBox2.Controls.Add(this.com_ModelSetting);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txt_caoPlane);
            this.groupBox2.Controls.Add(this.txt_caoRevolutions);
            this.groupBox2.Controls.Add(this.txt_CutterDiameter);
            this.groupBox2.Controls.Add(this.txt_yuanSpeed);
            this.groupBox2.Controls.Add(this.txt_yuanDistance);
            this.groupBox2.Controls.Add(this.txt_yuanSingleCutting);
            this.groupBox2.Controls.Add(this.txt_daojiao);
            this.groupBox2.Controls.Add(this.txt_hongkou);
            this.groupBox2.Controls.Add(this.txt_yuanWidth);
            this.groupBox2.Controls.Add(this.txt_yuanCutting);
            this.groupBox2.Controls.Add(this.txt_juDistance);
            this.groupBox2.Controls.Add(this.txt_juSingleCutting);
            this.groupBox2.Controls.Add(this.txt_mangkong);
            this.groupBox2.Controls.Add(this.txt_juWidth);
            this.groupBox2.Controls.Add(this.txt_juCutting);
            this.groupBox2.Controls.Add(this.txt_juDepth);
            this.groupBox2.Controls.Add(this.txt_yuanDepth);
            this.groupBox2.Controls.Add(this.label35);
            this.groupBox2.Controls.Add(this.label34);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.label_status0);
            this.groupBox2.Controls.Add(this.label_a);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.btnZeroA);
            this.groupBox2.Controls.Add(this.label_ma);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label_wa);
            this.groupBox2.Controls.Add(this.btnHome);
            this.groupBox2.Controls.Add(this.btnZeroXYZ);
            this.groupBox2.Controls.Add(this.btnZeroXY);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnZeroZ);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnZeroY);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnZeroX);
            this.groupBox2.Controls.Add(this.label_status);
            this.groupBox2.Controls.Add(this.label_mx);
            this.groupBox2.Controls.Add(this.label_my);
            this.groupBox2.Controls.Add(this.label_mz);
            this.groupBox2.Controls.Add(this.label_wz);
            this.groupBox2.Controls.Add(this.label_wx);
            this.groupBox2.Controls.Add(this.label_wy);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // com_TappingSetting
            // 
            this.com_TappingSetting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_TappingSetting.FormattingEnabled = true;
            resources.ApplyResources(this.com_TappingSetting, "com_TappingSetting");
            this.com_TappingSetting.Name = "com_TappingSetting";
            // 
            // com_drillingSetting
            // 
            this.com_drillingSetting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_drillingSetting.FormattingEnabled = true;
            resources.ApplyResources(this.com_drillingSetting, "com_drillingSetting");
            this.com_drillingSetting.Name = "com_drillingSetting";
            // 
            // com_ModelSetting
            // 
            this.com_ModelSetting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_ModelSetting.FormattingEnabled = true;
            resources.ApplyResources(this.com_ModelSetting, "com_ModelSetting");
            this.com_ModelSetting.Name = "com_ModelSetting";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_caoPlane
            // 
            resources.ApplyResources(this.txt_caoPlane, "txt_caoPlane");
            this.txt_caoPlane.Name = "txt_caoPlane";
            this.txt_caoPlane.TextChanged += new System.EventHandler(this.txt_caoPlane_TextChanged);
            this.txt_caoPlane.Enter += new System.EventHandler(this.txt_caoPlane_Enter);
            // 
            // txt_caoRevolutions
            // 
            resources.ApplyResources(this.txt_caoRevolutions, "txt_caoRevolutions");
            this.txt_caoRevolutions.Name = "txt_caoRevolutions";
            this.txt_caoRevolutions.TextChanged += new System.EventHandler(this.txt_caoRevolutions_TextChanged);
            this.txt_caoRevolutions.Enter += new System.EventHandler(this.txt_caoRevolutions_Enter);
            // 
            // txt_CutterDiameter
            // 
            resources.ApplyResources(this.txt_CutterDiameter, "txt_CutterDiameter");
            this.txt_CutterDiameter.Name = "txt_CutterDiameter";
            this.txt_CutterDiameter.Enter += new System.EventHandler(this.txt_CutterDiameter_Enter);
            // 
            // txt_yuanSpeed
            // 
            resources.ApplyResources(this.txt_yuanSpeed, "txt_yuanSpeed");
            this.txt_yuanSpeed.Name = "txt_yuanSpeed";
            this.txt_yuanSpeed.TextChanged += new System.EventHandler(this.txt_yuanSpeed_TextChanged);
            this.txt_yuanSpeed.Enter += new System.EventHandler(this.txt_yuanSpeed_Enter);
            // 
            // txt_yuanDistance
            // 
            resources.ApplyResources(this.txt_yuanDistance, "txt_yuanDistance");
            this.txt_yuanDistance.Name = "txt_yuanDistance";
            this.txt_yuanDistance.Enter += new System.EventHandler(this.txt_yuanDistance_Enter);
            // 
            // txt_yuanSingleCutting
            // 
            resources.ApplyResources(this.txt_yuanSingleCutting, "txt_yuanSingleCutting");
            this.txt_yuanSingleCutting.Name = "txt_yuanSingleCutting";
            this.txt_yuanSingleCutting.Enter += new System.EventHandler(this.txt_yuanSingleCutting_Enter);
            // 
            // txt_daojiao
            // 
            resources.ApplyResources(this.txt_daojiao, "txt_daojiao");
            this.txt_daojiao.Name = "txt_daojiao";
            this.txt_daojiao.Enter += new System.EventHandler(this.txt_daojiao_Enter);
            // 
            // txt_hongkou
            // 
            resources.ApplyResources(this.txt_hongkou, "txt_hongkou");
            this.txt_hongkou.Name = "txt_hongkou";
            this.txt_hongkou.Enter += new System.EventHandler(this.txt_hongkou_Enter);
            // 
            // txt_yuanWidth
            // 
            resources.ApplyResources(this.txt_yuanWidth, "txt_yuanWidth");
            this.txt_yuanWidth.Name = "txt_yuanWidth";
            this.txt_yuanWidth.Enter += new System.EventHandler(this.txt_yuanWidth_Enter);
            // 
            // txt_yuanCutting
            // 
            resources.ApplyResources(this.txt_yuanCutting, "txt_yuanCutting");
            this.txt_yuanCutting.Name = "txt_yuanCutting";
            this.txt_yuanCutting.Enter += new System.EventHandler(this.txt_yuanCutting_Enter);
            // 
            // txt_juDistance
            // 
            resources.ApplyResources(this.txt_juDistance, "txt_juDistance");
            this.txt_juDistance.Name = "txt_juDistance";
            this.txt_juDistance.Enter += new System.EventHandler(this.txt_juDistance_Enter);
            // 
            // txt_juSingleCutting
            // 
            resources.ApplyResources(this.txt_juSingleCutting, "txt_juSingleCutting");
            this.txt_juSingleCutting.Name = "txt_juSingleCutting";
            this.txt_juSingleCutting.Enter += new System.EventHandler(this.txt_juSingleCutting_Enter);
            // 
            // txt_mangkong
            // 
            resources.ApplyResources(this.txt_mangkong, "txt_mangkong");
            this.txt_mangkong.Name = "txt_mangkong";
            this.txt_mangkong.Enter += new System.EventHandler(this.txt_mangkong_Enter);
            // 
            // txt_juWidth
            // 
            resources.ApplyResources(this.txt_juWidth, "txt_juWidth");
            this.txt_juWidth.Name = "txt_juWidth";
            this.txt_juWidth.Enter += new System.EventHandler(this.txt_juWidth_Enter);
            // 
            // txt_juCutting
            // 
            resources.ApplyResources(this.txt_juCutting, "txt_juCutting");
            this.txt_juCutting.Name = "txt_juCutting";
            this.txt_juCutting.Enter += new System.EventHandler(this.txt_juCutting_Enter);
            // 
            // txt_juDepth
            // 
            resources.ApplyResources(this.txt_juDepth, "txt_juDepth");
            this.txt_juDepth.Name = "txt_juDepth";
            this.txt_juDepth.Enter += new System.EventHandler(this.txt_juDepth_Enter);
            // 
            // txt_yuanDepth
            // 
            resources.ApplyResources(this.txt_yuanDepth, "txt_yuanDepth");
            this.txt_yuanDepth.Name = "txt_yuanDepth";
            this.txt_yuanDepth.Enter += new System.EventHandler(this.txt_yuanDepth_Enter);
            // 
            // label35
            // 
            resources.ApplyResources(this.label35, "label35");
            this.label35.ForeColor = System.Drawing.Color.Red;
            this.label35.Name = "label35";
            // 
            // label34
            // 
            resources.ApplyResources(this.label34, "label34");
            this.label34.ForeColor = System.Drawing.Color.Red;
            this.label34.Name = "label34";
            // 
            // label30
            // 
            resources.ApplyResources(this.label30, "label30");
            this.label30.Name = "label30";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // label29
            // 
            resources.ApplyResources(this.label29, "label29");
            this.label29.Name = "label29";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // label27
            // 
            resources.ApplyResources(this.label27, "label27");
            this.label27.Name = "label27";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // label28
            // 
            resources.ApplyResources(this.label28, "label28");
            this.label28.Name = "label28";
            // 
            // label31
            // 
            resources.ApplyResources(this.label31, "label31");
            this.label31.Name = "label31";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label26
            // 
            resources.ApplyResources(this.label26, "label26");
            this.label26.Name = "label26";
            // 
            // label_status0
            // 
            resources.ApplyResources(this.label_status0, "label_status0");
            this.label_status0.Name = "label_status0";
            // 
            // label_a
            // 
            resources.ApplyResources(this.label_a, "label_a");
            this.label_a.Name = "label_a";
            // 
            // label25
            // 
            resources.ApplyResources(this.label25, "label25");
            this.label25.Name = "label25";
            // 
            // label_ma
            // 
            resources.ApplyResources(this.label_ma, "label_ma");
            this.label_ma.Name = "label_ma";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // label_wa
            // 
            resources.ApplyResources(this.label_wa, "label_wa");
            this.label_wa.Name = "label_wa";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label_status
            // 
            resources.ApplyResources(this.label_status, "label_status");
            this.label_status.Name = "label_status";
            // 
            // label_mx
            // 
            resources.ApplyResources(this.label_mx, "label_mx");
            this.label_mx.Name = "label_mx";
            // 
            // label_my
            // 
            resources.ApplyResources(this.label_my, "label_my");
            this.label_my.Name = "label_my";
            // 
            // label_mz
            // 
            resources.ApplyResources(this.label_mz, "label_mz");
            this.label_mz.Name = "label_mz";
            // 
            // label_wz
            // 
            resources.ApplyResources(this.label_wz, "label_wz");
            this.label_wz.Name = "label_wz";
            // 
            // label_wx
            // 
            resources.ApplyResources(this.label_wx, "label_wx");
            this.label_wx.Name = "label_wx";
            // 
            // label_wy
            // 
            resources.ApplyResources(this.label_wy, "label_wy");
            this.label_wy.Name = "label_wy";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.tLPAussen);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.btnOverrideSSGB.ResumeLayout(false);
            this.btnOverrideSSGB.PerformLayout();
            this.btnOverrideFRGB.ResumeLayout(false);
            this.btnOverrideFRGB.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.cmsCode.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fCTBCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cmsPictureBox.ResumeLayout(false);
            this.tLPAussen.ResumeLayout(false);
            this.tLPLinks.ResumeLayout(false);
            this.tLPRechts.ResumeLayout(false);
            this.tLPRechtsUnten.ResumeLayout(false);
            this.tLPRechtsUnten.PerformLayout();
            this.tLPRechtsUntenRechts.ResumeLayout(false);
            this.tLPMitteUnten.ResumeLayout(false);
            this.txt_K10.ResumeLayout(false);
            this.txt_K10.PerformLayout();
            this.tLPRechtsOben.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar pbFile;
        private System.Windows.Forms.Label lblElapsed;
        private System.Windows.Forms.Label lblFileProgress;
        private System.Windows.Forms.ProgressBar pbBuffer;
        private System.Windows.Forms.Button btnStreamStart;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnJogZeroXY;
        private System.Windows.Forms.Button btnJogZeroZ;
        private System.Windows.Forms.Button btnJogZeroY;
        private System.Windows.Forms.Button btnJogZeroX;
        private System.Windows.Forms.Button btnFeedHold;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.ContextMenuStrip cmsCode;
        private System.Windows.Forms.ToolStripMenuItem cmsCodeSelect;
        private System.Windows.Forms.ToolStripMenuItem cmsCodeCopy;
        private System.Windows.Forms.ToolStripMenuItem cmsCodeSendLine;
        private System.Windows.Forms.ToolStripMenuItem cmsCodePaste;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tLPAussen;
        private System.Windows.Forms.TableLayoutPanel tLPLinks;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TableLayoutPanel tLPRechts;
        private System.Windows.Forms.TableLayoutPanel tLPRechtsUnten;
        private System.Windows.Forms.TableLayoutPanel tLPRechtsUntenRechts;
        private FastColoredTextBoxNS.FastColoredTextBox fCTBCode;
        private System.Windows.Forms.Button btnKillAlarm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tBSpeed;
        private System.Windows.Forms.CheckBox cBCoolant;
        private System.Windows.Forms.CheckBox cBSpindle;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tLPMitteUnten;
        private virtualJoystick.virtualJoystick virtualJoystickZ;
        private virtualJoystick.virtualJoystick virtualJoystickXY;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button btnStreamCheck;
        private System.Windows.Forms.Button btnStreamStop;
        private System.Windows.Forms.ContextMenuStrip cmsPictureBox;
        private System.Windows.Forms.ToolStripMenuItem moveToFirstPosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteThisCodeLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deletenotMarkToolStripMenuItem;
        private System.Windows.Forms.CheckBox cBTool;
        private System.Windows.Forms.Label lblTool;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem machineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlStreamingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem createGCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textWizzardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createSimpleShapesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMachineParametersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMachineParametersToolStripMenuItem;
        private System.Windows.Forms.Button btnJogStop;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripMenuItem control2ndGRBLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deutschToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mirrorXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mirrorYToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem rotate90ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotate90ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rotateFreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_tb_rotate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem sToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_tb_XY_scale;
        private System.Windows.Forms.ToolStripMenuItem skalierenXYToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_tb_XY_X_scale;
        private System.Windows.Forms.ToolStripMenuItem skalierenXYUmXUnitsZuErreichenToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_tb_XY_Y_scale;
        private System.Windows.Forms.ToolStripMenuItem skaliereXUmToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_tb_X_scale;
        private System.Windows.Forms.ToolStripMenuItem skaliereAufXUnitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_tb_X_X_scale;
        private System.Windows.Forms.ToolStripMenuItem skaliereXAufDrehachseToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_tb_X_A_scale;
        private System.Windows.Forms.ToolStripMenuItem skaliereYUmToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_tb_Y_scale;
        private System.Windows.Forms.ToolStripMenuItem skaliereAufYUnitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_tb_Y_Y_scale;
        private System.Windows.Forms.ToolStripMenuItem skaliereYAufDrehachseToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_tb_Y_A_scale;
        private System.Windows.Forms.TextBox lbDimension;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rBOrigin9;
        private System.Windows.Forms.RadioButton rBOrigin8;
        private System.Windows.Forms.RadioButton rBOrigin7;
        private System.Windows.Forms.RadioButton rBOrigin6;
        private System.Windows.Forms.RadioButton rBOrigin5;
        private System.Windows.Forms.RadioButton rBOrigin4;
        private System.Windows.Forms.RadioButton rBOrigin3;
        private System.Windows.Forms.RadioButton rBOrigin2;
        private System.Windows.Forms.RadioButton rBOrigin1;
        private System.Windows.Forms.Button btnOffsetApply;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbOffsetY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbOffsetX;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem rotaryDimaeterToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_tb_rotary_diameter;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem ersetzteG23DurchLinienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heightMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetZoomingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private virtualJoystick.virtualJoystick virtualJoystickA;
        private System.Windows.Forms.Button btnJogZeroA;
        private System.Windows.Forms.ToolStripMenuItem pasteFromClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.GroupBox btnOverrideFRGB;
        private System.Windows.Forms.Button btnOverrideFR1;
        private System.Windows.Forms.Button btnOverrideFR2;
        private System.Windows.Forms.Button btnOverrideFR0;
        private System.Windows.Forms.Button btnOverrideFR4;
        private System.Windows.Forms.Button btnOverrideFR3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblOverrideFRValue;
        private System.Windows.Forms.GroupBox btnOverrideSSGB;
        private System.Windows.Forms.Button btnOverrideSS2;
        private System.Windows.Forms.Button btnOverrideSS0;
        private System.Windows.Forms.Button btnOverrideSS1;
        private System.Windows.Forms.Button btnOverrideSS4;
        private System.Windows.Forms.Button btnOverrideSS3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblOverrideSSValue;
        private System.Windows.Forms.ToolStripMenuItem chineseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tLPRechtsOben;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCustom8;
        private System.Windows.Forms.Button btnCustom7;
        private System.Windows.Forms.Button btnCustom6;
        private System.Windows.Forms.Button btnCustom5;
        private System.Windows.Forms.Button btnCustom1;
        private System.Windows.Forms.Button btnCustom2;
        private System.Windows.Forms.Button btnCustom3;
        private System.Windows.Forms.Button btnCustom4;
        private System.Windows.Forms.Panel txt_K10;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ToolStripMenuItem switchTheColorToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioButton32;
        private System.Windows.Forms.RadioButton radioButton16;
        private System.Windows.Forms.RadioButton radioButton31;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton30;
        private System.Windows.Forms.RadioButton radioButton15;
        private System.Windows.Forms.RadioButton radioButton29;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton28;
        private System.Windows.Forms.RadioButton radioButton27;
        private System.Windows.Forms.RadioButton radioButton14;
        private System.Windows.Forms.RadioButton radioButton26;
        private System.Windows.Forms.RadioButton radioButton13;
        private System.Windows.Forms.RadioButton radioButton25;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton24;
        private System.Windows.Forms.RadioButton radioButton12;
        private System.Windows.Forms.RadioButton radioButton23;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton22;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.RadioButton radioButton21;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton20;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton19;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton18;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton17;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_caoPlane;
        private System.Windows.Forms.TextBox txt_caoRevolutions;
        private System.Windows.Forms.TextBox txt_CutterDiameter;
        private System.Windows.Forms.TextBox txt_yuanSpeed;
        private System.Windows.Forms.TextBox txt_yuanDistance;
        private System.Windows.Forms.TextBox txt_yuanSingleCutting;
        private System.Windows.Forms.TextBox txt_yuanWidth;
        private System.Windows.Forms.TextBox txt_yuanCutting;
        private System.Windows.Forms.TextBox txt_juDistance;
        private System.Windows.Forms.TextBox txt_juSingleCutting;
        private System.Windows.Forms.TextBox txt_juWidth;
        private System.Windows.Forms.TextBox txt_juCutting;
        private System.Windows.Forms.TextBox txt_juDepth;
        private System.Windows.Forms.TextBox txt_yuanDepth;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label_status0;
        private System.Windows.Forms.Label label_a;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnZeroA;
        private System.Windows.Forms.Label label_ma;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label_wa;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnZeroXYZ;
        private System.Windows.Forms.Button btnZeroXY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnZeroZ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnZeroY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnZeroX;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Label label_mx;
        private System.Windows.Forms.Label label_my;
        private System.Windows.Forms.Label label_mz;
        private System.Windows.Forms.Label label_wz;
        private System.Windows.Forms.Label label_wx;
        private System.Windows.Forms.Label label_wy;
        private System.Windows.Forms.TextBox txt_daojiao;
        private System.Windows.Forms.TextBox txt_hongkou;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txt_mangkong;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox com_ModelSetting;
        private System.Windows.Forms.ComboBox com_TappingSetting;
        private System.Windows.Forms.ComboBox com_drillingSetting;
        private System.Windows.Forms.Timer timer1;
    }
}

