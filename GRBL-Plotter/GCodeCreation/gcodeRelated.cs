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

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace GRBL_Plotter
{
    public static class gcode
    {   private static string formatCode = "00";
        private static string formatNumber = "0.###";

        private static int gcodeLines = 0;              // counter for GCode lines
        private static float gcodeDistance = 0;         // counter for GCode move distance
        private static int gcodeDownUp = 0;             // counter for GCode Pen Down / Up
        private static float gcodeTime = 0;             // counter for GCode work time
        private static int gcodePauseCounter = 0;       // counter for GCode pause M0 commands
        private static int gcodeToolCounter = 0;       // counter for GCode Tools
        private static string gcodeToolText = "";       // counter for GCode Tools

        public static float gcodeXYFeed = 1999;        // XY feed to apply for G1
        private static bool gcodeComments = true;       // if true insert additional comments into GCode

        private static bool gcodeToolChange = false;          // Apply tool exchange command

        // Using Z-Axis for Pen up down
        private static bool gcodeZApply = true;         // if true insert Z movements for Pen up/down
        private static float gcodeZUp = 1.999f;         // Z-up position
        public static float gcodeZDown = -1.999f;      // Z-down position
        public static float gcodeZFeed = 499;          // Z feed to apply for G1
        public static float gcodeZRepitition;          // Z feed to apply for G1

        // Using Spindle pwr. to switch on/off laser
        private static bool gcodeSpindleToggle = false; // Switch on/off spindle for Pen down/up (M3/M5)
        public static float gcodeSpindleSpeed = 999; // Spindle speed to apply
        private static string gcodeSpindleCmd = "3"; // Spindle Command M3 / M4

        // Using Spindle-Speed als PWM output to control RC-Servo
        private static bool gcodePWMEnable = false;     // Change Spindle speed for Pen down/up
        private static float gcodePWMUp = 199;          // Spindle speed for Pen-up
        private static float gcodePWMDlyUp = 0;         // Delay to apply after Pen-up (because servo is slow)
        private static float gcodePWMDown = 799;        // Spindle speed for Pen-down
        private static float gcodePWMDlyDown = 0;       // Delay to apply after Pen-down (because servo is slow)

        private static bool gcodeIndividualTool = false;     // Use individual Pen down/up
        private static string gcodeIndividualUp = "";
        private static string gcodeIndividualDown = "";

        private static bool gcodeCompress = false;      // reduce code by avoiding sending again same G-Nr and unchanged coordinates
        public static bool gcodeRelative = false;      // calculate relative coordinates for G91
        private static bool gcodeNoArcs = false;        // replace arcs by line segments
        private static float gcodeAngleStep = 0.1f;

        public static void setup()
        {
            setDecimalPlaces((int)Properties.Settings.Default.importGCDecPlaces);
            gcodeXYFeed = (float)Properties.Settings.Default.importGCXYFeed;

            gcodeComments = Properties.Settings.Default.importGCAddComments;
            gcodeSpindleToggle = Properties.Settings.Default.importGCSpindleToggle;
            gcodeSpindleSpeed = (float)Properties.Settings.Default.importGCSSpeed;
            if (Properties.Settings.Default.importGCSpindleCmd)
                gcodeSpindleCmd = "3";
            else
                gcodeSpindleCmd = "4";

            gcodeZApply = Properties.Settings.Default.importGCZEnable;
            gcodeZUp = (float)Properties.Settings.Default.importGCZUp;
            gcodeZDown = (float)Properties.Settings.Default.importGCZDown;
            gcodeZFeed = (float)Properties.Settings.Default.importGCZFeed;

            gcodePWMEnable = Properties.Settings.Default.importGCPWMEnable;
            gcodePWMUp = (float)Properties.Settings.Default.importGCPWMUp;
            gcodePWMDlyUp = (float)Properties.Settings.Default.importGCPWMDlyUp;
            gcodePWMDown = (float)Properties.Settings.Default.importGCPWMDown;
            gcodePWMDlyDown = (float)Properties.Settings.Default.importGCPWMDlyDown;

            gcodeIndividualTool = Properties.Settings.Default.importGCIndEnable;
            gcodeIndividualUp = Properties.Settings.Default.importGCIndPenUp;
            gcodeIndividualDown = Properties.Settings.Default.importGCIndPenDown;

            gcodeReduce = Properties.Settings.Default.importSVGReduce;
            gcodeReduceVal = (float)Properties.Settings.Default.importSVGReduceLimit;

            gcodeToolChange = Properties.Settings.Default.importGCTool;

            gcodeCompress = Properties.Settings.Default.importGCCompress;        // reduce code by 
            gcodeRelative = Properties.Settings.Default.importGCRelative;        // reduce code by 
            gcodeNoArcs = Properties.Settings.Default.importGCNoArcs;        // reduce code by 
            gcodeAngleStep = (float)Properties.Settings.Default.importGCSegment;

            gcodeLines = 1;             // counter for GCode lines
            gcodeDistance = 0;          // counter for GCode move distance
            gcodeDownUp = 0;            // counter for GCode Down/Up
            gcodeTime = 0;              // counter for GCode work time
            gcodePauseCounter = 0;      // counter for GCode pause M0 commands
            gcodeToolCounter = 0;
            gcodeToolText = "";
            lastx = -1; lasty = -1; lastz = 0;
            if (gcodeRelative)
            { lastx = 0; lasty = 0; }
        }

        public static bool reduceGCode
        {
            get { return gcodeCompress; }
            set {   gcodeCompress = value;
                    setDecimalPlaces((int)Properties.Settings.Default.importGCDecPlaces);
                }
        }

        public static void setDecimalPlaces(int num)
        {   formatNumber = "0.";
            if (gcodeCompress)
                formatNumber = formatNumber.PadRight(num + 2, '#'); //'0'
            else
                formatNumber = formatNumber.PadRight(num + 2, '0'); //'0'
        }

        // get GCode one or two digits
        public static int getIntGCode(char code, string tmp)
        {   string cmdG = getStrGCode(code, tmp);
            if (cmdG.Length > 0)
            {  return Convert.ToInt16(cmdG.Substring(1));  }
            return -1;
        }
        public static string getStrGCode(char code,string tmp)
        {
            var cmdG = Regex.Matches(tmp, code+"\\d{1,2}");
            if (cmdG.Count > 0)
            {  return cmdG[0].ToString();  }
            return "";
        }

        // get value from X,Y,Z F, S etc.
        public static int getIntValue(char code, string tmp)
        {
            string cmdG = getStringValue(code, tmp);
//            MessageBox.Show(cmdG);
            if (cmdG.Length > 0)
            {  return Convert.ToInt16(cmdG.Substring(1));  }
            return -1;
        }
        public static string getStringValue(char code, string tmp)
        {
            var cmdG = Regex.Matches(tmp, code+ "-?\\d+(.\\d+)?");
            if (cmdG.Count > 0)
            {  return cmdG[cmdG.Count-1].ToString(); }
            return "";
        }

        public static string frmtCode(int number)      // convert int to string using format pattern
        {   return number.ToString(formatCode); }
        public static string frmtNum(float number)     // convert float to string using format pattern
        {   return number.ToString(formatNumber); }
        public static string frmtNum(double number)     // convert double to string using format pattern
        {   return number.ToString(formatNumber); }

        private static bool gcodeReduce = false;        // if true remove G1 commands if distance is < limit
        private static float gcodeReduceVal = 0.1f;     // limit when to remove G1 commands
        private static StringBuilder secondMove = new StringBuilder();
        private static bool applyXYFeedRate = true; // apply XY feed after each Pen-move

        public static void Pause(StringBuilder gcodeString, string cmt="")
        {
            if (cmt.Length > 0) cmt = string.Format("({0})", cmt);
            gcodeString.AppendFormat("M{0:00} {1}\r\n",0,cmt);
            gcodeLines++; 
            gcodePauseCounter++;
        }

        public static void SpindleOn(StringBuilder gcodeString, string cmt="")
        {
            if (cmt.Length > 0) cmt = string.Format("({0})", cmt);
            gcodeString.AppendFormat("M{0} S{1} {2}\r\n", gcodeSpindleCmd, gcodeSpindleSpeed, cmt);
            gcodeLines++;
        }

        public static void SpindleOff(StringBuilder gcodeString, string cmt="")
        {
            if (cmt.Length > 0) cmt = string.Format("({0})", cmt);
            gcodeString.AppendFormat("M{0} {1}\r\n", frmtCode(5), cmt);
            gcodeLines++;
        }

        public static void PenDown(StringBuilder gcodeString, string cmt = "")
        {   if (gcodeComments) { gcodeString.Append("\r\n"); }
            if (gcodeRelative) { cmt += string.Format("rel {0}", lastz); }
            if (cmt.Length >0) { cmt = string.Format("({0})", cmt); }

            if (gcodeSpindleToggle)
            {   if (gcodeComments) gcodeString.AppendFormat("({0})\r\n", "Pen down: Spindle-On");
                SpindleOn(gcodeString, cmt);
            }
            if (gcodeZApply)
            {   if (gcodeComments) gcodeString.AppendFormat("({0})\r\n", "Pen down: Z-Axis");
                float z_relative = gcodeZDown - lastz;
                if (gcodeRelative)
                    gcodeString.AppendFormat("G{0} Z{1} F{2} {3}\r\n", frmtCode(1), frmtNum(z_relative), gcodeZFeed, cmt);
                else
                    gcodeString.AppendFormat("G{0} Z{1} F{2} {3}\r\n", frmtCode(1), frmtNum(gcodeZDown), gcodeZFeed, cmt);//写第二条G01

                gcodeTime += Math.Abs((gcodeZUp - gcodeZDown) / gcodeZFeed);
                gcodeLines++; lastg = 1; lastf = gcodeZFeed;
                applyXYFeedRate = true;
                lastz = gcodeZDown;
            }
            if (gcodePWMEnable)
            {   if (gcodeComments) gcodeString.AppendFormat("({0})\r\n", "Pen down: Servo control");
                gcodeString.AppendFormat("M{0} S{1} {2}\r\n", gcodeSpindleCmd, gcodePWMDown, cmt);
                gcodeString.AppendFormat("G{0} P{1}\r\n", frmtCode(4), frmtNum(gcodePWMDlyDown));
                gcodeTime += gcodePWMDlyDown;
                gcodeLines++;
            }
            if (gcodeIndividualTool)
            {   if (gcodeComments) gcodeString.AppendFormat("({0})\r\n", "Pen down: Individual Cmd");
                string[] commands = gcodeIndividualDown.Split(';');
                foreach (string cmd in commands)
                { gcodeString.AppendFormat("{0}\r\n", cmd.Trim()); }
//                gcodeString.AppendFormat("{0}\r\n", gcodeIndividualDown);
            }
            if (gcodeComments) gcodeString.Append("\r\n");

            gcodeDownUp++;
        }

        public static void PenUp(StringBuilder gcodeString, string cmt = "")
        {   if (gcodeComments) { gcodeString.Append("\r\n"); }
            if (gcodeRelative) { cmt += string.Format("rel {0}", lastz); }
            if (cmt.Length >0) { cmt = string.Format("({0})", cmt); }

            if (gcodeIndividualTool)
            {   if (gcodeComments) gcodeString.AppendFormat("({0})\r\n", "Pen up: Individual Cmd");
                string[] commands = gcodeIndividualUp.Split(';'); 
                foreach (string cmd in commands)
                {   gcodeString.AppendFormat("{0}\r\n", cmd.Trim());}
//                gcodeString.AppendFormat("{0}\r\n", gcodeIndividualUp);
            }

            if (gcodePWMEnable)
            {   if (gcodeComments) gcodeString.AppendFormat("({0})\r\n", "Pen up: Servo control");
                gcodeString.AppendFormat("M{0} S{1} {2}\r\n", gcodeSpindleCmd, gcodePWMUp, cmt);
                gcodeString.AppendFormat("G{0} P{1}\r\n", frmtCode(4), frmtNum(gcodePWMDlyUp));
                gcodeTime += gcodePWMDlyUp;
                gcodeLines++;
            }

            if (gcodeZApply)
            {   if (gcodeComments) gcodeString.AppendFormat("({0})\r\n", "Pen up: Z-Axis");
                float z_relative = gcodeZUp - lastz;
                if (gcodeRelative)
                    gcodeString.AppendFormat("G{0} Z{1} {2}\r\n", frmtCode(0), frmtNum(z_relative), cmt); // use G0 without feedrate
                else
                    gcodeString.AppendFormat("G{0} Z{1} {2}\r\n", frmtCode(0), frmtNum(gcodeZUp), cmt); // use G0 without feedrate

                gcodeTime += Math.Abs((gcodeZUp - gcodeZDown) / gcodeZFeed);
                gcodeLines++; lastg = 1; lastf = gcodeZFeed;
                lastz = gcodeZUp;
            }

            if (gcodeSpindleToggle)
            {   if (gcodeComments) gcodeString.AppendFormat("({0})\r\n", "Pen up: Spindle-Off");
                SpindleOff(gcodeString, cmt);
            }
            if (gcodeComments) gcodeString.Append("\r\n");
        }

        public static float lastx, lasty, lastz, lastg, lastf;

        public static void MoveTo(StringBuilder gcodeString, Point coord, string cmt = "")
        {   Move(gcodeString, 1, (float)coord.X, (float)coord.Y, applyXYFeedRate, cmt); }
        public static void MoveTo(StringBuilder gcodeString, float x, float y, string cmt = "")
        {   Move(gcodeString, 1, x, y, applyXYFeedRate, cmt); }
        public static void MoveTo(StringBuilder gcodeString, float x, float y, float z, string cmt = "")
        {   Move(gcodeString, 1, x, y, z, applyXYFeedRate, cmt); }
        public static void MoveToRapid(StringBuilder gcodeString, Point coord, string cmt = "")
        {   Move(gcodeString, 0, (float)coord.X, (float)coord.Y, false, cmt); }
        public static void MoveToRapid(StringBuilder gcodeString, float x, float y, string cmt = "")
        {   Move(gcodeString, 0, x, y, false, cmt); }

        private static void Move(StringBuilder gcodeString, int gnr, float x, float y, bool applyFeed, string cmt)
        { Move(gcodeString, gnr, x, y, null, applyFeed, cmt); }
        private static void Move(StringBuilder gcodeString, int gnr, float x, float y, float? z, bool applyFeed, string cmt)
        {
            string feed = "";
            StringBuilder gcodeTmp = new StringBuilder();
            bool isneeded = false;
            float x_relative = x - lastx;
            float y_relative = y - lasty;
            float z_relative = lastz;
            float tz = 0;
            if (z != null)
            {   z_relative = (float)z - lastz;
                tz = (float)z;
            }

            if (applyFeed && (gnr > 0))
            {
                feed = string.Format("F{0}", gcodeXYFeed);
                applyXYFeedRate = false;                        // don't set feed next time
            }
            if (cmt.Length > 0) cmt = string.Format("({0})", cmt);

            if (gcodeCompress)
            {
                if (((gnr > 0) || (lastx != x) || (lasty != y) || (lastz != tz)))  // else nothing to do
                {
                    if (lastg != gnr) { gcodeTmp.AppendFormat("G{0}", frmtCode(gnr)); isneeded = true; }
                    if (gcodeRelative)
                    {
                        if (lastx != x) { gcodeTmp.AppendFormat("X{0}", frmtNum(x_relative)); isneeded = true; }
                        if (lasty != y) { gcodeTmp.AppendFormat("Y{0}", frmtNum(y_relative)); isneeded = true; }
                        if (z!=null)
                        {
                            if (lastz != z) { gcodeTmp.AppendFormat("Z{0}", frmtNum(z_relative)); isneeded = true; }
                        }
                    }
                    else
                    {
                        if (lastx != x) { gcodeTmp.AppendFormat("X{0}", frmtNum(x)); isneeded = true; }
                        if (lasty != y) { gcodeTmp.AppendFormat("Y{0}", frmtNum(y)); isneeded = true; }
                        if (z != null)
                        {
                            if (lastz != z) { gcodeTmp.AppendFormat("Z{0}", frmtNum((float)z)); isneeded = true; }
                        }
                    }

                    if ((gnr == 1) && (lastf != gcodeXYFeed) || applyFeed)
                    {
                        gcodeTmp.AppendFormat("F{0} ", gcodeXYFeed);
                        lastf = gcodeXYFeed;
                        isneeded = true;
                    }
                    gcodeTmp.AppendFormat("{0}\r\n", cmt);
                    if (isneeded)
                        gcodeString.Append(gcodeTmp);
                }
            }
            else
            {
                if (z != null)
                {
                    if (gcodeRelative)
                        gcodeString.AppendFormat("G{0} X{1} Y{2} Z{3} {4} {5}\r\n", frmtCode(gnr), frmtNum(x_relative), frmtNum(y_relative), frmtNum(z_relative), feed, cmt);
                    else
                        gcodeString.AppendFormat("G{0} X{1} Y{2} Z{3} {4} {5}\r\n", frmtCode(gnr), frmtNum(x), frmtNum(y), frmtNum((float)z), feed, cmt);
                }
                else
                {
                    if (gcodeRelative)
                        gcodeString.AppendFormat("G{0} X{1} Y{2} {3} {4}\r\n", frmtCode(gnr), frmtNum(x_relative), frmtNum(y_relative), feed, cmt);
                    else
                        gcodeString.AppendFormat("G{0} X{1} Y{2} {3} {4}\r\n", frmtCode(gnr), frmtNum(x), frmtNum(y), feed, cmt);
                }
            }
            //gcodeDistance += fdistance(lastx, lasty, x, y);
            gcodeTime += fdistance(lastx, lasty, x, y) / gcodeXYFeed;
            lastx = x; lasty = y; lastz = tz; lastg = gnr; 
            gcodeLines++;
        }
       
        public static void splitLine(StringBuilder gcodeString, int gnr, float x1, float y1, float x2, float y2, float maxStep, bool applyFeed, string cmt = "")
        {
            float dx = x2 - x1;
            float dy = y2 - y1;
            float c = (float)Math.Sqrt(dx * dx + dy * dy);
            float tmpX,tmpY;
            int divid = (int)Math.Ceiling(c / maxStep);
            lastg = -1;
            for (int i = 1; i <= divid; i++)
            {
                tmpX = x1 + i * dx / divid;
                tmpY = y1 + i * dy / divid;
                if (i > 1) { applyFeed = false; cmt = ""; }
                if (gnr == 0)
                { Move(gcodeString, gnr, tmpX, tmpY, false, cmt); }
                else
                { Move(gcodeString, gnr, tmpX, tmpY, applyFeed, cmt); }
            }
        }


        public static void Arc(StringBuilder gcodeString, int gnr, Point coordxy, Point coordij, string cmt = "", bool avoidG23 = false)
        { MoveArc(gcodeString, gnr, (float)coordxy.X, (float)coordxy.Y, (float)coordij.X, (float)coordij.Y, applyXYFeedRate, cmt, avoidG23); }
        public static void Arc(StringBuilder gcodeString, int gnr, float x, float y, float i, float j,string cmt = "", bool white = false, bool avoidG23 = false)
        { MoveArc(gcodeString, gnr, x, y, i, j, applyXYFeedRate, cmt, white, avoidG23); }
        public static void Arc(StringBuilder gcodeString, int gnr, float x, float y, float i, float j,double Z, double R, double F, double S, string knife,double Q=0,string cmt = "", bool avoidG23 = false)
        {MoveArc(gcodeString, gnr, x, y, i, j, applyXYFeedRate, Z, R, F, S, knife,Q, cmt, avoidG23);}
        public static void Arc1(StringBuilder gcodeString, int gnr, float x, float y, float i, float j, double Z, double R, double F, double S,double Q, string knife, string cmt = "", bool avoidG23 = false)
        { MoveArc1(gcodeString, gnr, x, y, i, j, applyXYFeedRate, Z, R, F, S,Q, knife, cmt, avoidG23); }

        private static void MoveArc(StringBuilder gcodeString, int gnr, float x, float y, float i, float j, bool applyFeed, string cmt = "", bool white=false, bool avoidG23 = false)
        {
            string feed = "";
            float x_relative = x - lastx;
            float y_relative = y - lasty;

            if (applyFeed)
            {   feed = string.Format("F{0}", gcodeXYFeed);
                applyXYFeedRate = false;                        // don't set feed next time
            }
            if (cmt.Length > 0) cmt = string.Format("({0})", cmt);
            if (gcodeNoArcs || avoidG23)
            {
                    splitArc(gcodeString, gnr, lastx, lasty, x, y, i, j, applyFeed, cmt);
            }
            else
            {
                if (gcodeRelative)
                    gcodeString.AppendFormat("G{0} X{1} Y{2}  I{3} J{4} {5} {6}\r\n", frmtCode(gnr), frmtNum(x_relative), frmtNum(y_relative), frmtNum(i), frmtNum(j), feed, cmt);
                else
                {
                    if (white)
                    {
                        gcodeString.AppendFormat("G{0} X{1} Y{2}  I{3} J{4} {5} {6} ssss\r\n", frmtCode(gnr), frmtNum(x), frmtNum(y), frmtNum(i), frmtNum(j), feed, cmt);
                    }
                    else
                    {
                        gcodeString.AppendFormat("G{0} X{1} Y{2}  I{3} J{4} {5} {6}\r\n", frmtCode(gnr), frmtNum(x), frmtNum(y), frmtNum(i), frmtNum(j), feed, cmt);
                    }
                }
                //写第三条G03
                lastg = gnr;
            }
//            gcodeDistance += fdistance(lastx, lasty, x, y);
            gcodeTime += fdistance(lastx, lasty, x, y) / gcodeXYFeed;
            lastx = x; lasty = y; lastf = gcodeXYFeed;
            gcodeLines++;
        }
        private static void MoveArc(StringBuilder gcodeString, int gnr, float x, float y, float i, float j, bool applyFeed, double Z, double R, double F, double S, string knife, double Q, string cmt = "", bool avoidG23 = false)
        {
            string feed = "";
            float x_relative = x - lastx;
            float y_relative = y - lasty;

            feed = string.Format("F{0}", F);

            applyXYFeedRate = false;                        // don't set feed next time
            if (cmt.Length > 0) cmt = string.Format("({0})", cmt);
            if (gcodeNoArcs || avoidG23)
            {
                splitArc(gcodeString, gnr, lastx, lasty, x, y, i, j, applyFeed, cmt);
            }
            else
            {
                string knifer = gcode.Knife(knife);
                string zhongjian = "M8\r\n";
                //转数
                string re = gcode.Revolutions(S.ToString());
                gcodeString.AppendFormat(knifer);
                gcodeString.AppendFormat(zhongjian);
                gcodeString.AppendFormat(re);
                if (gcodeRelative)
                    if (Q != 0)
                    {
                        gcodeString.AppendFormat("G99 G43 H{0} G{1} X{2} Y{3} Z{4} R{5} Q{6} {7} M3 S{8}\r\n", knife, frmtCode(gnr), frmtNum(x + (i)), frmtNum(y), frmtNum(Z), R.ToString("0.000"), Q.ToString("0.000"), feed, S);
                    }
                    else
                    {
                        gcodeString.AppendFormat("G99 G43 H{0} G{1} X{2} Y{3} Z{4} R{5} {6} M3 S{7}\r\n", knife, frmtCode(gnr), frmtNum(x + (i)), frmtNum(y), frmtNum(Z), R.ToString("0.000"), feed, S);
                    }
                else
                {
                    //写第三条G03
                    //81 X0.000 Y0.000 Z-25.000 R2.000 F30 M3 S800
                    if (Q != 0)
                    {
                        gcodeString.AppendFormat("G99 G43 H{0} G{1} X{2} Y{3} Z{4} R{5} Q{6} {7} M3 S{8}\r\n", knife, frmtCode(gnr), frmtNum(x + (i)), frmtNum(y), frmtNum(Z), R.ToString("0.000"), Q.ToString("0.000"), feed, S);
                    }
                    else
                    {
                        gcodeString.AppendFormat("G99 G43 H{0} G{1} X{2} Y{3} Z{4} R{5} {6} M3 S{7}\r\n", knife, frmtCode(gnr), frmtNum(x + (i)), frmtNum(y), frmtNum(Z), R.ToString("0.000"), feed, S);
                    }
                }
                string zuihou = "G80\r\n";
                gcodeString.AppendFormat(zuihou);
                lastg = gnr;
            }
            //            gcodeDistance += fdistance(lastx, lasty, x, y);
            gcodeTime += fdistance(lastx, lasty, x, y) / gcodeXYFeed;
            lastx = x; lasty = y; lastf = gcodeXYFeed;
            gcodeLines++;
        }
        private static void MoveArc1(StringBuilder gcodeString, int gnr, float x, float y, float i, float j, bool applyFeed, double Z, double R, double F, double S,double Q, string knife, string cmt = "", bool avoidG23 = false)
        {
            string feed = "";
            float x_relative = x - lastx;
            float y_relative = y - lasty;

           
            
                feed = string.Format("F{0}", F);
                applyXYFeedRate = false;                        // don't set feed next time
            
            if (cmt.Length > 0) cmt = string.Format("({0})", cmt);
            if (gcodeNoArcs || avoidG23)
            {
                splitArc(gcodeString, gnr, lastx, lasty, x, y, i, j, applyFeed, cmt);
            }
            else
            {
                string knifer = gcode.Knife(knife);
                string zhongjian = "M8\r\n";
                //转数
                string re = gcode.RevolutionsTapping(S.ToString());
                gcodeString.AppendFormat(knifer);
                gcodeString.AppendFormat(zhongjian);
                gcodeString.AppendFormat(re);
                if (gcodeRelative)
                    gcodeString.AppendFormat("G99 G43 H{0} G{1} X{2} Y{3} Z{4} R{5} Q{6} {7} S{8}\r\n", knife, frmtCode(gnr), frmtNum(x + i), frmtNum(y), frmtNum(Z), R.ToString("0.000"), Q.ToString("0.000"), feed, S);
                else
                {
                    //写第三条G03
                    //81 X0.000 Y0.000 Z-25.000 R2.000 F30 M3 S800
                    gcodeString.AppendFormat("G99 G43 H{0} G{1} X{2} Y{3} Z{4} R{5} Q{6} {7} S{8}\r\n",knife, frmtCode(gnr), frmtNum(x + i), frmtNum(y), frmtNum(Z), R.ToString("0.000"),Q.ToString("0.000"), feed, S);
                }
                string zuihou = "G80\r\n";
                gcodeString.AppendFormat(zuihou);
                lastg = gnr;
            }
            //            gcodeDistance += fdistance(lastx, lasty, x, y);
            gcodeTime += fdistance(lastx, lasty, x, y) / gcodeXYFeed;
            lastx = x; lasty = y; lastf = gcodeXYFeed;
            gcodeLines++;
        }

        public static void splitArc(StringBuilder gcodeString, int gnr, float x1, float y1, float x2, float y2, float i, float j, bool applyFeed, string cmt = "")
        {
            float radius = (float)Math.Sqrt(i * i + j * j);					// get radius of circle
            float cx = x1 + i, cy = y1 + j;                                 // get center point of circle

            float cos1 = (float)i / radius;									// get start angle
            if (cos1 > 1) cos1 = 1;
            if (cos1 < -1) cos1 = -1;
            float a1 = 180 - 180 * (float)(Math.Acos(cos1) / Math.PI);

            if (j > 0) { a1 = -a1; }										// get stop angle
            float cos2 = (float)(x1 + i - x2) / radius;
            if (cos2 > 1) cos2 = 1;
            if (cos2 < -1) cos2 = -1;
            float a2 = 180 - 180 * (float)(Math.Acos(cos2) / Math.PI);

            if ((y1 + j - y2) > 0) { a2 = -a2; }							// get delta angle
            float da = -(360 + a1 - a2);
            if (gnr == 3) { da = Math.Abs(360 + a2 - a1); }
            if (da > 360) { da -= 360; }
            if (da < -360) { da += 360; }

            float step = (float)(Math.Asin((double)gcodeAngleStep / (double)radius) * 180 / Math.PI);
            //            Comment(gcodeString, radius.ToString()+" "+a1.ToString() + " " + a2.ToString() + " " + da.ToString() + " " + step.ToString());
            applyXYFeedRate = true;
            if (da > 0)                                             // if delta >0 go counter clock wise
            {
                for (float angle = (a1+step); angle < (a1+da); angle+= step)
                {
                    float x = cx + radius * (float)Math.Cos(Math.PI * angle / 180);
                    float y = cy + radius * (float)Math.Sin(Math.PI * angle / 180);
                    MoveTo(gcodeString, x, y,cmt);
                    if (cmt.Length > 1) cmt = "";
                }
            }
            else                                                       // else go clock wise
            {
                for (float angle = (a1-step); angle > (a1+da); angle-= step)
                {
                    float x = cx + radius * (float)Math.Cos(Math.PI * angle / 180);
                    float y = cy + radius * (float)Math.Sin(Math.PI * angle / 180);
                    MoveTo(gcodeString, x, y,cmt);
                    if (cmt.Length > 1) cmt = "";
                }
            }
            MoveTo(gcodeString, x2, y2,"End Arc conversion");
        }

        public static void Tool(StringBuilder gcodeString, int toolnr, string cmt="")
        {
            if (gcodeToolChange)                // otherweise no command needed
            {
                if (cmt.Length > 0) cmt = string.Format("({0})", cmt);
                gcodeString.AppendFormat("M{0} T{1:D2} {2}\r\n", frmtCode(6), toolnr, cmt);
                gcodeToolCounter++;
                gcodeLines++;
                gcodeToolText += string.Format("( {0}) ToolNr: {1:D2}, Name: {2})\r\n", gcodeToolCounter,toolnr, cmt);
            }
        }
        public static string Knife(string knife)
        {
            if (knife != "")
            {
                if (gcodeRelative)
                    knife = string.Format("M06 T0{0}\r\n", knife);
                else
                    //写第一条刀指令
                    knife = string.Format("M06 T0{0}\r\n", knife);
            }
            return knife;
        }
        public static string Revolutions(string S)
        {
            if (S != "")
            {
                if (gcodeRelative)
                    S = string.Format("M3 S{0}\r\n", S);
                else
                    //写第一条刀指令
                    S = string.Format("M3 S{0}\r\n", S);
            }
            return S;
        }
        public static string RevolutionsTapping(string S)
        {
            if (S != "")
            {
                if (gcodeRelative)
                    S = string.Format("M29 S{0}\r\n", S);
                else
                    //写第一条刀指令
                    S = string.Format("M29 S{0}\r\n", S);
            }
            return S;
        }
        public static string Parameter(int z, int r, int f, int s)
        {
            string par = "";
                if (gcodeRelative)
                    par = string.Format("G99 G43 H2 G81 X0.000 Y0.000 Z-{0} R{1} F{2} M3 S{3}\r\n", z, r, f, s);
                else
                    par = string.Format("G99 G43 H2 G81 X0.000 Y0.000 Z-{0} R{1} F{2} M3 S{3}\r\n", z.ToString("0.000"), r.ToString("0.000"), f, s);
            return par;
        }
        public static string GetHeader(string cmt,string source="")
        {
            gcodeTime += gcodeDistance / gcodeXYFeed;
            string header = "";
            //string header = "( "+cmt+" by GRBL-Plotter )\r\n";
            //if (source.Length>1)
            //    header += string.Format("( Source: {0} )\r\n", source);

            //header += string.Format("( G-Code lines: {0} )\r\n", gcodeLines);
            //header += string.Format("( Pen Down/Up : {0} times )\r\n", gcodeDownUp);
            //header += string.Format("( Path length : {0:0.0} units )\r\n", gcodeDistance);
            //header += string.Format("( Duration    : {0:0.0} min. )\r\n", gcodeTime);
            if (gcodeToolChange)
            {
                header += string.Format("( Tool changes: {0})\r\n", gcodeToolCounter);
                header += gcodeToolText;
            }
            if (gcodePauseCounter>0)
                header += string.Format("( M0 count    : {0})\r\n", gcodePauseCounter);
            string[] commands = Properties.Settings.Default.importGCHeader.Split(';');
            foreach (string cmd in commands)
                if (cmd.Length > 1)
                { header += string.Format("{0} (Setup - GCode-Header)\r\n", cmd.Trim()); gcodeLines++; }
            if (gcodeRelative)
            { header += string.Format("G91 (Setup relative movement)\r\n"); gcodeLines++; }

            return header;
        }

        public static string GetFooter()
        {
            string footer = "";
            string[] commands = Properties.Settings.Default.importGCFooter.Split(';');
            foreach (string cmd in commands)
                if (cmd.Length > 1)
                { footer += string.Format("{0} (Setup - GCode-Footer)\r\n", cmd.Trim()); gcodeLines++; }
                    return footer;
        }

        public static void Comment(StringBuilder gcodeString, string cmt)
        {   if (cmt.Length>1)
                gcodeString.AppendFormat("({0})\r\n", cmt);
        }

        // helper functions
        private static float fsqrt(float x) { return (float)Math.Sqrt(x); }
        private static float fvmag(float x, float y) { return fsqrt(x * x + y * y); }
        private static float fdistance(float x1, float y1, float x2, float y2) { return fvmag(x2 - x1, y2 - y1); }
    }
}
