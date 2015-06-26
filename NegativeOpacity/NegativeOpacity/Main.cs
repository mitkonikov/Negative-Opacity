using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NegativeOpacity
{
    public partial class Main : Form
    {
        Bitmap bmpON = new Bitmap(NegativeOpacity.Properties.Resources.ON_200SQ);
        Bitmap bmpOFF = new Bitmap(NegativeOpacity.Properties.Resources.OFF_200SQ);

        // Settings
        int AnimateState = 1;
        int SeparateState = 0;
        int NegativeState = 1;
        int TransparencyOpacity = 0;

        int RedResult = 0;
        int GreenResult = 0;
        int BlueResult = 0;

        float Opacityint;

        // Animation Graphics
        Graphics g;
        Bitmap bmpAnimate = new Bitmap(742, 94);
        int Rect1LocationXDef = 100;
        int Rect1LocationYDef = 20;
        int Rect2LocationXDef = 300;
        int Rect2LocationYDef = 20;

        int Rect1LocationX = 100;
        int Rect2LocationX = 300;

        int RectTargetX = 600;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            pictureBox2.Image = bmpON;
            pictureBox3.Image = bmpOFF;
            pictureBox4.Image = bmpON;
            pictureBox5.Image = bmpOFF;
            TraOpa1.Text = "Opacity:";
            TraOpa2.Text = "Opacity:";
            TraOpa1.Location = new Point(this.TraOpa1.Location.X + 40, this.TraOpa1.Location.Y);
            TraOpa2.Location = new Point(this.TraOpa2.Location.X + 40, this.TraOpa2.Location.Y);
            TraOpaTextBox2.Text = "100";
            TraOpaTextBox2.Enabled = false;
            button2.Enabled = false; //Use Image Button
            pictureBox3.Enabled = false; // Separate PictureBox
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (AnimateState == 1)
            {
                pictureBox2.Image = bmpOFF;
                AnimateState = 0;
                pictureBox3.Enabled = true;
            }
            else
            {
                pictureBox2.Image = bmpON;
                AnimateState = 1;
                pictureBox3.Enabled = false;
                pictureBox3.Image = bmpOFF;
                SeparateState = 0;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (SeparateState == 1)
            {
                pictureBox3.Image = bmpOFF;
                SeparateState = 0;
            }
            else
            {
                pictureBox3.Image = bmpON;
                SeparateState = 1;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (NegativeState == 1)
            {
                pictureBox4.Image = bmpOFF;
                NegativeState = 0;
                NegativeLabel1.Text = "";
            }
            else
            {
                pictureBox4.Image = bmpON;
                NegativeState = 1;
                NegativeLabel1.Text = "-";
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (TransparencyOpacity == 1)
            {
                pictureBox5.Image = bmpOFF;
                TransparencyOpacity = 0;
                TraOpa1.Text = "Opacity:";
                TraOpa2.Text = "Opacity:";
                TraOpa1.Location = new Point(this.TraOpa1.Location.X + 40, this.TraOpa1.Location.Y);
                TraOpa2.Location = new Point(this.TraOpa2.Location.X + 40, this.TraOpa2.Location.Y);
            }
            else
            {
                pictureBox5.Image = bmpON;
                TransparencyOpacity = 1;
                TraOpa1.Text = "Transparency:";
                TraOpa2.Text = "Transparency:";
                TraOpa1.Location = new Point(this.TraOpa1.Location.X - 40, this.TraOpa1.Location.Y);
                TraOpa2.Location = new Point(this.TraOpa2.Location.X - 40, this.TraOpa2.Location.Y);
            }
        }

        #region Value Changed
        private void RedUpDown1_ValueChanged(object sender, EventArgs e)
        {
            RedBar1.Value = Convert.ToInt32(RedUpDown1.Value);
        }

        private void GreenUpDown1_ValueChanged(object sender, EventArgs e)
        {
            GreenBar1.Value = Convert.ToInt32(GreenUpDown1.Value);
        }

        private void BlueUpDown1_ValueChanged(object sender, EventArgs e)
        {
            BlueBar1.Value = Convert.ToInt32(BlueUpDown1.Value);
        }

        private void RedUpDown2_ValueChanged(object sender, EventArgs e)
        {
            RedBar2.Value = Convert.ToInt32(RedUpDown2.Value);
        }

        private void GreenUpDown2_ValueChanged(object sender, EventArgs e)
        {
            GreenBar2.Value = Convert.ToInt32(GreenUpDown2.Value);
        }

        private void BlueUpDown2_ValueChanged(object sender, EventArgs e)
        {
            BlueBar2.Value = Convert.ToInt32(BlueUpDown2.Value);
        }

        private void RedBar1_ValueChanged(object sender, EventArgs e)
        {
            RedUpDown1.Value = RedBar1.Value;
        }

        private void GreenBar1_ValueChanged(object sender, EventArgs e)
        {
            GreenUpDown1.Value = GreenBar1.Value;
        }

        private void BlueBar1_ValueChanged(object sender, EventArgs e)
        {
            BlueUpDown1.Value = BlueBar1.Value;
        }

        private void RedBar2_ValueChanged(object sender, EventArgs e)
        {
            RedUpDown2.Value = RedBar2.Value;
        }

        private void GreenBar2_ValueChanged(object sender, EventArgs e)
        {
            GreenUpDown2.Value = GreenBar2.Value;
        }

        private void BlueBar2_ValueChanged(object sender, EventArgs e)
        {
            BlueUpDown2.Value = BlueBar2.Value;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            try
            {
                Opacityint = (Convert.ToInt32(TraOpaTextBox1.Text) / 100f);
                if (NegativeState == 0)
                {
                    //Calculating Positive Opacity
                    RedResult = Convert.ToInt32((float)RedBar2.Value * (1f - Opacityint) + (float)RedBar1.Value * Opacityint);
                    GreenResult = Convert.ToInt32((float)GreenBar2.Value * (1f - Opacityint) + (float)GreenBar1.Value * Opacityint);
                    BlueResult = Convert.ToInt32((float)BlueBar2.Value * (1f - Opacityint) + (float)BlueBar1.Value * Opacityint);
                    //Writing to "output console"
                    textBox1.Text += "RedResult = Convert.ToInt32((float)RedBar2.Value * (1f - Opacityint) + (float)RedBar1.Value * Opacityint)";
                    textBox1.Text += Environment.NewLine + "GreenResult = Convert.ToInt32((float)GreenBar2.Value * (1f - Opacityint) + (float)GreenBar1.Value * Opacityint)";
                    textBox1.Text += Environment.NewLine + "BlueResult = Convert.ToInt32((float)BlueBar2.Value * (1f - Opacityint) + (float)BlueBar1.Value * Opacityint)";
                    textBox1.Text += Environment.NewLine;
                    textBox1.Text += Environment.NewLine + "RedResult = Convert.ToInt32((float)" + (RedBar2.Value).ToString() + " * (1f - " + Opacityint.ToString() + ") + (float)" + (RedBar1.Value).ToString() + "* " + Opacityint.ToString() +")";
                    textBox1.Text += Environment.NewLine + "GreenResult = Convert.ToInt32((float)" + (GreenBar2.Value).ToString() + " * (1f - " + Opacityint.ToString() + ") + (float)" + (GreenBar1.Value).ToString() + "* " + Opacityint.ToString() + ")";
                    textBox1.Text += Environment.NewLine + "BlueResult = Convert.ToInt32((float)" + (BlueBar2.Value).ToString() + " * (1f - " + Opacityint.ToString() + ") + (float)" + (BlueBar1.Value).ToString() + "* " + Opacityint.ToString() + ")";
                }
                else
                {
                    //Calculating Negative Opacity
                    RedResult = Convert.ToInt32((float)RedBar2.Value * (1f + Opacityint) + (float)RedBar1.Value * -(Opacityint));
                    GreenResult = Convert.ToInt32((float)GreenBar2.Value * (1f + Opacityint) + (float)GreenBar1.Value * -(Opacityint));
                    BlueResult = Convert.ToInt32((float)BlueBar2.Value * (1f + Opacityint) + (float)BlueBar1.Value * -(Opacityint));
                    //Writing to "output console"
                    textBox1.Text += "RedResult = Convert.ToInt32((float)RedBar2.Value * (1f + Opacityint) + (float)RedBar1.Value * -(Opacityint))";
                    textBox1.Text += Environment.NewLine + "GreenResult = Convert.ToInt32((float)GreenBar2.Value * (1f + Opacityint) + (float)GreenBar1.Value * -(Opacityint))";
                    textBox1.Text += Environment.NewLine + "BlueResult = Convert.ToInt32((float)BlueBar2.Value * (1f + Opacityint) + (float)BlueBar1.Value * -(Opacityint))";
                    textBox1.Text += Environment.NewLine;
                    textBox1.Text += Environment.NewLine + "RedResult = Convert.ToInt32((float)" + (RedBar2.Value).ToString() + " * (1f + " + Opacityint.ToString() + ") + (float)" + (RedBar1.Value).ToString() + "* -(" + Opacityint.ToString() + "))";
                    textBox1.Text += Environment.NewLine + "GreenResult = Convert.ToInt32((float)" + (GreenBar2.Value).ToString() + " * (1f + " + Opacityint.ToString() + ") + (float)" + (GreenBar1.Value).ToString() + "* -(" + Opacityint.ToString() + "))";
                    textBox1.Text += Environment.NewLine + "BlueResult = Convert.ToInt32((float)" + (BlueBar2.Value).ToString() + " * (1f + " + Opacityint.ToString() + ") + (float)" + (BlueBar1.Value).ToString() + "* -(" + Opacityint.ToString() + "))";
                }
            } 
            catch
            {
                if (TransparencyOpacity == 0)
                {
                    textBox1.Text = textBox1.Text + "ERROR: POSSIBLY NOT VALID VALUE OPACITY VALUE!";
                }
                else
                {
                    textBox1.Text = textBox1.Text + "ERROR: POSSIBLY NOT VALID VALUE TRANSPARENCY VALUE!";
                }
            }

            // If some of the results are below 0 or above 255
            if (RedResult < 0)
            {
                RedResult = 0;
            }
            else if (RedResult > 255)
            {
                RedResult = 255;
            }

            if (GreenResult < 0)
            {
                GreenResult = 0;
            }
            else if (GreenResult > 255)
            {
                GreenResult = 255;
            }

            if (BlueResult < 0)
            {
                BlueResult = 0;
            }
            else if (BlueResult > 255)
            {
                BlueResult = 255;
            }

            RedLabel1.Text = (RedResult).ToString();
            GreenLabel1.Text = (GreenResult).ToString();
            BlueLabel1.Text = (BlueResult).ToString();

            if (AnimateState == 1)
            {
                AnimateTimer1.Start();
            }
            else
            {
                g = Graphics.FromImage(bmpAnimate);
                g.Clear(Color.White);
                g.FillRectangle(new System.Drawing.SolidBrush(Color.FromArgb(RedBar1.Value, GreenBar1.Value, BlueBar1.Value)), Rect1LocationXDef, Rect1LocationYDef, 50, 50);
                g.FillRectangle(new System.Drawing.SolidBrush(Color.FromArgb(RedBar2.Value, GreenBar2.Value, BlueBar2.Value)), Rect2LocationXDef, Rect2LocationYDef, 50, 50);
                if (SeparateState == 0)
                {
                    g.FillRectangle(new System.Drawing.SolidBrush(Color.FromArgb(RedResult, GreenResult, BlueResult)), RectTargetX, Rect2LocationYDef, 50, 50);
                    g.DrawString("Result", new Font("Arial", 10), new SolidBrush(Color.Red), new PointF(RectTargetX, 70));
                }
                else
                {
                    if (NegativeState == 1)
                    {
                        g.FillRectangle(new System.Drawing.SolidBrush(Color.FromArgb(RedResult, GreenResult, BlueResult)), RectTargetX, Rect2LocationYDef, 50, 50);
                        g.FillRectangle(new System.Drawing.SolidBrush(Color.FromArgb(RedBar1.Value + ((RedBar2.Value - RedBar1.Value) / (100 / (Convert.ToInt32(TraOpaTextBox1.Text)))), GreenBar1.Value + ((GreenBar2.Value - GreenBar1.Value) / (100 / (Convert.ToInt32(TraOpaTextBox1.Text)))), BlueBar1.Value + ((BlueBar2.Value - BlueBar1.Value) / (100 / (Convert.ToInt32(TraOpaTextBox1.Text)))))), RectTargetX - 80, Rect2LocationYDef, 50, 50);
                        g.DrawString("Negative", new Font("Arial", 10), new SolidBrush(Color.Red), new PointF(RectTargetX, 70));
                        g.DrawString("Positive", new Font("Arial", 10), new SolidBrush(Color.Red), new PointF(RectTargetX - 80, 70));
                    }
                    else
                    {
                        g.FillRectangle(new System.Drawing.SolidBrush(Color.FromArgb(RedResult, GreenResult, BlueResult)), RectTargetX, Rect2LocationYDef, 50, 50);
                        g.DrawString("Result", new Font("Arial", 10), new SolidBrush(Color.Red), new PointF(RectTargetX, 70));
                    }
                }
                g.Dispose();
                pictureBox1.Image = bmpAnimate;
            }
        }

        private void AnimateTimer1_Tick(object sender, EventArgs e)
        {
            g = Graphics.FromImage(bmpAnimate);
            g.Clear(Color.White);
            if ((Rect2LocationX - Rect1LocationX) <= 50 && (Rect2LocationX - Rect1LocationX) != 0)
            {
                g.FillRectangle(new System.Drawing.SolidBrush(Color.FromArgb(RedBar1.Value, GreenBar1.Value, BlueBar1.Value)), Rect1LocationX, Rect1LocationYDef, (Rect2LocationX - Rect1LocationX), 50);
                g.FillRectangle(new System.Drawing.SolidBrush(Color.FromArgb(RedResult, GreenResult, BlueResult)), RectTargetX, Rect1LocationYDef, 50 - (Rect2LocationX - Rect1LocationX), 50);
                g.FillRectangle(new System.Drawing.SolidBrush(Color.FromArgb(RedBar2.Value, GreenBar2.Value, BlueBar2.Value)), RectTargetX + (50 - (Rect2LocationX - Rect1LocationX)), Rect2LocationYDef, (Rect2LocationX - Rect1LocationX), 50);
                Rect1LocationX = Rect1LocationX + 10;
                g.Dispose();
                pictureBox1.Image = bmpAnimate;
            }
            else if ((Rect2LocationX - Rect1LocationX) == 0)
            {
                g.FillRectangle(new System.Drawing.SolidBrush(Color.FromArgb(RedResult, GreenResult, BlueResult)), RectTargetX, Rect1LocationYDef, 50, 50);
                g.Dispose();
                pictureBox1.Image = bmpAnimate;
                Rect1LocationX = Rect1LocationXDef;
                Rect2LocationX = Rect2LocationXDef;
                AnimateTimer1.Stop();
            }
            else
            {
                if (Rect2LocationX == RectTargetX)
                {
                    g.FillRectangle(new System.Drawing.SolidBrush(Color.FromArgb(RedBar1.Value, GreenBar1.Value, BlueBar1.Value)), Rect1LocationX, Rect1LocationYDef, 50, 50);
                    g.FillRectangle(new System.Drawing.SolidBrush(Color.FromArgb(RedBar2.Value, GreenBar2.Value, BlueBar2.Value)), RectTargetX, Rect2LocationYDef, 50, 50);
                    Rect1LocationX = Rect1LocationX + 10;
                    g.Dispose();
                    pictureBox1.Image = bmpAnimate;
                }
                else
                {
                    g.FillRectangle(new System.Drawing.SolidBrush(Color.FromArgb(RedBar1.Value, GreenBar1.Value, BlueBar1.Value)), Rect1LocationX, Rect1LocationYDef, 50, 50); //Rect1
                    g.FillRectangle(new System.Drawing.SolidBrush(Color.FromArgb(RedBar2.Value, GreenBar2.Value, BlueBar2.Value)), Rect2LocationX, Rect2LocationYDef, 50, 50); //Rect2
                    Rect1LocationX = Rect1LocationX + 10;
                    Rect2LocationX = Rect2LocationX + 10;
                    g.Dispose();
                    pictureBox1.Image = bmpAnimate;
                }
            }
        }
    }
}
