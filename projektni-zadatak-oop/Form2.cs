using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projektni_zadatak_oop
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Character player;
        List<Projectile> listOfProjectiles;
        int startingStrength = 1;

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                if (player.x - 2 < 0) { }
                else
                {
                    Refresh();
                    player.Move(-5, 0);
                }
            }

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                if (player.x + 2 > ClientRectangle.Width) { }
                else
                {
                    Refresh();
                    player.Move(5, 0);
                }
            }

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                if (player.y + 2 > ClientRectangle.Height) { }
                else
                {
                    Refresh();
                    player.Move(0, -5);
                }
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                if (player.y - 2 < 0) { }
                else
                {
                    Refresh();
                    player.Move(0, 5);
                }
            }

        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {          
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Z)
            {
                listOfProjectiles.Add(new Projectile(player.x + 5, player.y, startingStrength));
                Graphics g = CreateGraphics();
                tProjectileMover.Enabled = true;
                foreach (Projectile p in listOfProjectiles)
                {
                    p.Draw(g);
                }
            }

            if (e.KeyCode == Keys.E)
            {
                if (startingStrength + 1 > 3) { }
                else ++startingStrength; 
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            player = new Character(ClientRectangle.Width / 2 - 5, ClientRectangle.Height - 50);
            listOfProjectiles = new List<Projectile>();
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            player.Draw(e.Graphics);
            foreach (Projectile p in listOfProjectiles)
            {
                p.Draw(e.Graphics);
            }
        }

        private void tProjectileMover_Tick(object sender, EventArgs e)
        {
            Refresh();
            for (int i = 0; i < listOfProjectiles.Count; ++i)
            {
                if (listOfProjectiles[i].y < 0)
                {
                    listOfProjectiles.RemoveAt(i);
                }
                else
                {
                    listOfProjectiles[i].Move(0, 20);
                }
            }
        }
    }

    public class Character
    {
        public int x { get; set; }
        public int y { get; set; }
       

        public Character(int x, int y) 
        {
            this.x = x;
            this.y = y;
        }
    
        public void Move(int dx, int dy)
        {
            this.x += dx;
            this.y += dy;
        }

        public void Draw(Graphics g)
        {
            SolidBrush rBrush = new SolidBrush(Color.Red);
            SolidBrush bBrush = new SolidBrush(Color.Blue);

            g.FillRectangle(rBrush, x, y, 10, 10);
        }
    }

    public class Projectile
    {
        public int x { get; set; }
        public int y { get; set; }
        public int strength { get; set; }

        public Projectile(int x, int y, int strength)
        {
            this.x = x;
            this.y = y;
            this.strength = strength;
        }

        public void Set(int x, int y, int strength)
        {
            this.x = x;
            this.y = y;
            this.strength = strength;
        }

        public void IncreaseStrength(int d)
        {
            strength += d;
        }

        public void Move(int dx, int dy)
        {
            this.x -= dx;
            this.y -= dy;
        }

        public void Draw(Graphics g)
        {
            Pen yPen = new Pen(new SolidBrush(Color.Yellow), 2);
            Pen gPen = new Pen(new SolidBrush(Color.Green), 2);
            Pen pPen = new Pen(new SolidBrush(Color.Purple), 2);

            switch (strength)
            {
                case 1:
                    g.DrawLine(yPen, new Point(x, y - 2), new Point(x, y - 30));
                    break;
                case 2:
                    g.DrawLine(gPen, new Point(x, y - 2), new Point(x, y - 30));
                    break;
                case 3:
                    g.DrawLine(pPen, new Point(x, y - 2), new Point(x, y - 30));
                    break;
                default:
                    break;
            }
        }
    }

    public abstract class Enemy
    {
        int x, y;
    }
}
