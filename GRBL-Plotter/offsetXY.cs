using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GRBL_Plotter
{
    public partial class offsetXY : Form
    {
        double X;double Y;
        public delegate void DelTest(double X,double Y);
        private DelTest _del;// 存储Form1传送过来的函数
        public offsetXY(double? x,double? y, DelTest del)
        {
            InitializeComponent();
            this._del = del;
            X = Convert.ToDouble(x);
            Y = Convert.ToDouble(y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._del(Convert.ToDouble(txt_x.Text),Convert.ToDouble(txt_y.Text));
            this.Close();
        }

        private void offsetXY_Load(object sender, EventArgs e)
        {
            txt_x.Text = X.ToString();
            txt_y.Text = Y.ToString();
        }

        private void offsetXY_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this._del(Convert.ToDouble(txt_x.Text), Convert.ToDouble(txt_y.Text));
            //this.Close();
        }

        private void offsetXY_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._del(Convert.ToDouble(txt_x.Text), Convert.ToDouble(txt_y.Text));
            this.Close();
        }
    }
}
