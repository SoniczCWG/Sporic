using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sporic123
{
    public class myButton : Button
    {
        public int top { get; set; }
        public int bottom { get; set; }

        public int left { get; set; }
        public int right { get; set; }

        public void initStrany() { top = base.Top; bottom = base.Bottom; left = base.Left; right = base.Right; }

        public class Smer
        {
            public int x { get; set; }
            public int y { get; set; }
            public Smer(int x, int y) { this.x = x; this.y = y; }
        }
        public Smer smer { get; set; } 

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }

        public bool intersects(myButton bt)
        {
            this.initStrany();
            bt.initStrany();
            if (this.left >= bt.right || this.top >= bt.bottom ||
            this.right <= bt.left || this.bottom <= bt.top)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool intersectsX(myButton bt)
        {
            this.initStrany();
            bt.initStrany();
            if (this.left >= bt.right || this.right <= bt.left)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool intersectsY(myButton bt)
        {
            this.initStrany();
            bt.initStrany();
            if (this.top >= bt.bottom || this.bottom <= bt.top)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



    }
}
