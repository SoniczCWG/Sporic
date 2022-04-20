using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sporic123
{
    
    public partial class Form1 : Form
    {
        public bool detect_collision_X(myButton bt, Button bt2 = null)
        {
            bool intersection = false;
            if (bt.Location.X + bt.Size.Width >= this.Size.Width) { intersection = true; }
            else if (bt.Location.X <= 0) { intersection = true; }
            return intersection;
        }
        public bool detect_collision_Y(myButton bt, Button bt2 = null)
        {


            bool intersection = false;
            if (bt.Location.Y + bt.Size.Height >= this.Size.Height) { intersection = true; } //1
            else if ((bt.Location.Y) <= 0) { intersection = true; } //2
            return intersection;
        }
        public List<myButton> Tlacitkaa { get; set; } = new List<myButton>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myButton1.smer = new myButton.Smer(1, 1);
            myButton2.smer = new myButton.Smer(1, 1);
            Tlacitkaa.Add(myButton1);
            Tlacitkaa.Add(myButton2);
            timer1.Start();
        }

        private void myButton1_Click(object sender, EventArgs e)
        {
            label1.Text = (int.Parse(label1.Text)+1).ToString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (detect_collision_X(myButton1)) { myButton1.smer.x *= (-1); }
            if (detect_collision_Y(myButton1)) { myButton1.smer.y *= (-1); }
            if (detect_collision_X(myButton2)) { myButton2.smer.x *= (-1); }
            if (detect_collision_Y(myButton2)) { myButton2.smer.y *= (-1); }

            
            if (myButton1.intersects(myButton2))
            {
                if (myButton2.top >= myButton1.bottom | myButton2.bottom >= myButton1.top)
                {
                    myButton1.smer.y *= (-1); myButton2.smer.y *= (-1);
                }
                if (myButton2.left <= myButton1.right | myButton2.Right >= myButton1.left)
                { myButton1.smer.x *= (-1); myButton2.smer.x *= (-1); }
            }

            
            move();

        }

        private void move()
        {
            myButton1.Location = new Point(myButton1.Location.X + myButton1.smer.x, myButton1.Location.Y + myButton1.smer.y);
            myButton2.Location = new Point(myButton2.Location.X + myButton2.smer.x, myButton2.Location.Y + myButton2.smer.y);
        }

        private void myButton2_Click(object sender, EventArgs e)
        {
            label1.Text = (int.Parse(label1.Text) + 1).ToString();
        }
    }
    }

