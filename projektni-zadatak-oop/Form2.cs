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

        Random r = new Random();

        Character player;
        List<Particle> backgroundParticles;
        List<Projectile> listOfProjectiles;
        List<Enemy> listOfEnemies;

        SoundPlayer projectileSound = new SoundPlayer("C:\\Users\\ck3jo\\Documents\\GitHub\\projektni-zadatak-oop\\projektni-zadatak-oop\\projectile.wav");
        SoundPlayer explosion = new SoundPlayer("C:\\Users\\ck3jo\\Documents\\GitHub\\projektni-zadatak-oop\\projektni-zadatak-oop\\explosion.wav");
        
        int startingStrength = 1;
        int startingLives = 3;
        int score = 0;

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                if (player.x - 25 < 0) { }
                else
                {
                    Refresh();
                    player.Move(5, 0);
                }
            }

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                if (player.x + 25 > ClientRectangle.Width) { }
                else
                {
                    Refresh();
                    player.Move(-5, 0);
                }
            }

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                if (player.y - 25 < 0) { }
                else
                {
                    Refresh();
                    player.Move(0, 5);
                }
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                if (player.y + 25 > ClientRectangle.Height) { }
                else
                {
                    Refresh();
                    player.Move(0, -5);
                }
            }
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {          
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Z)
            {
                listOfProjectiles.Add(new Projectile(player.x + 10, player.y - 20, startingStrength));
                projectileSound.Play();
                Graphics g = CreateGraphics();
                tProjectileMover.Enabled = true;
                foreach (Projectile p in listOfProjectiles)
                {
                    if (p.detectedHit != true) p.Draw(g);
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            player = new Character(ClientRectangle.Width / 2 - 10, ClientRectangle.Height - 50);
            backgroundParticles = new List<Particle>();
            listOfProjectiles = new List<Projectile>();
            listOfEnemies = new List<Enemy>();

            for (int i = 0; i < 95; ++i)
            {
                switch (r.Next(0, 6))
                {
                    case 0:                    
                        backgroundParticles.Add(new Particle(r.Next(0, ClientRectangle.Width), r.Next(0, ClientRectangle.Height), 2, Color.White));
                        break;
                    case 1:
                        backgroundParticles.Add(new Particle(r.Next(0, ClientRectangle.Width), r.Next(0, ClientRectangle.Height), 2, Color.Blue));
                        break;
                    case 2:
                        backgroundParticles.Add(new Particle(r.Next(0, ClientRectangle.Width), r.Next(0, ClientRectangle.Height), 2, Color.Green));
                        break;
                    case 3:
                        backgroundParticles.Add(new Particle(r.Next(0, ClientRectangle.Width), r.Next(0, ClientRectangle.Height), 2, Color.Yellow));
                        break;
                    case 4:
                        backgroundParticles.Add(new Particle(r.Next(0, ClientRectangle.Width), r.Next(0, ClientRectangle.Height), 2, Color.Aqua));
                        break;
                    case 5:
                        backgroundParticles.Add(new Particle(r.Next(0, ClientRectangle.Width), r.Next(0, ClientRectangle.Height), 2, Color.Orange));
                        break;
                    default:
                        break;
                }
            }

            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 12; ++j)
                {
                    listOfEnemies.Add(new EasyEnemy(200 + 25 * j, 125 + 30 * i));
                }
            }
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {   
            e.Graphics.Clear(Color.Black);

            foreach (Particle part in backgroundParticles) part.Draw(e.Graphics);

            foreach (Projectile p in listOfProjectiles) p.Draw(e.Graphics);

            foreach (Enemy enemy in listOfEnemies) enemy.Draw(e.Graphics);
            
            player.Draw(e.Graphics);
        }

        private void tProjectileMover_Tick(object sender, EventArgs e)
        {
            Refresh();

            lbScore.Text = score.ToString();
            int pLim = listOfProjectiles.Count;
            int eLim = listOfEnemies.Count;

            for (int i = 0; i < pLim; ++i) 
            { 
                if (listOfProjectiles[i].y < 0) listOfProjectiles.RemoveAt(i);
                pLim = listOfProjectiles.Count;
            }

            for (int i = 0; i < pLim; ++i)
            {
                listOfProjectiles[i].Move(0, 50);

                for (int j = 0; j < eLim; ++j)
                {
                    if (listOfProjectiles[i].x >= listOfEnemies[j].x && listOfProjectiles[i].x <= listOfEnemies[j].x + 20 && listOfProjectiles[i].y - 40 == listOfEnemies[j].y + 20)
                    {
                        Graphics g = CreateGraphics();
                        g.Clear(Color.Black);
                        listOfProjectiles.RemoveAt(i);
                        listOfEnemies.RemoveAt(j);
                        pLim = listOfProjectiles.Count;
                        eLim = listOfEnemies.Count;
                        score += 100;
                    }
                }
            }
        }

        private void tEnemyMover_Tick(object sender, EventArgs e)
        {
            Refresh();

            switch (r.Next(0, 2))
            {
                case 0:
                    foreach (Enemy enemy in listOfEnemies) enemy.Move(15, 0);
                    break;
                case 1:
                    foreach (Enemy enemy in listOfEnemies) enemy.Move(-15, 0);
                    break;
                default:
                    break;
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
            this.x -= dx;
            this.y -= dy;
        }

        public void Draw(Graphics g)
        {
            SolidBrush rBrush = new SolidBrush(Color.Red);
            SolidBrush bBrush = new SolidBrush(Color.LightBlue);
            Point[] listOfPoints = new Point[] 
            { 
                new Point(x + 2, y - 13),
                new Point(x + 2, y),
                new Point(x + 6, y),
                new Point(x + 6, y - 1),
                new Point(x + 7, y - 1),
                new Point(x + 7, y - 2),
                new Point(x + 8, y - 2),
                new Point(x + 8, y - 3),
                new Point(x + 12, y - 3),
                new Point(x + 12, y - 2),
                new Point(x + 13, y - 2),
                new Point(x + 13, y - 1),
                new Point(x + 14, y - 1),
                new Point(x + 14, y),
                new Point(x + 18, y),
                new Point(x + 18, y - 13),
                new Point(x + 16, y - 13),
                new Point(x + 16, y - 12),
                new Point(x + 15, y - 12),
                new Point(x + 15, y - 11),
                new Point(x + 13, y - 11),
                new Point(x + 13, y - 17),
                new Point(x + 11, y - 17),
                new Point(x + 11, y - 18),
                new Point(x + 9, y - 18),
                new Point(x + 9, y - 17),
                new Point(x + 7, y - 17),
                new Point(x + 7, y - 11),
                new Point(x + 5, y - 11),
                new Point(x + 5, y - 12),
                new Point(x + 4, y - 12),
                new Point(x + 4, y - 13),
            };

            Point[] listOfPointsCockpit = new Point[] 
            {
                new Point(x + 8, y - 9),
                new Point(x + 12, y - 9),
                new Point(x + 12, y - 5),
                new Point(x + 8, y - 5)
            };


            g.FillPolygon(rBrush, listOfPoints);
            g.FillPolygon(bBrush, listOfPointsCockpit);
        }
    }

    public class Projectile
    {
        public int x { get; set; }
        public int y { get; set; }
        public int strength { get; set; }
        public bool detectedHit { get; set; }

        public Projectile(int x, int y, int strength, bool detectedHit = false)
        {
            this.x = x;
            this.y = y;
            this.strength = strength;
            this.detectedHit = detectedHit;
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
            if (!detectedHit)
            {
                Pen yPen = new Pen(new SolidBrush(Color.Yellow), 2);
                Pen gPen = new Pen(new SolidBrush(Color.Green), 2);
                Pen pPen = new Pen(new SolidBrush(Color.Purple), 2);

                switch (strength)
                {
                    case 1:
                        g.DrawLine(yPen, new Point(x, y - 2), new Point(x, y - 40));
                        break;
                    case 2:
                        g.DrawLine(gPen, new Point(x, y - 2), new Point(x, y - 40));
                        break;
                    case 3:
                        g.DrawLine(pPen, new Point(x, y - 2), new Point(x, y - 40));
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public abstract class Enemy
    {
        public int x { get; set; }
        public int y { get; set; } 
        public int health { get; set; }
        public Rectangle bounds { get; set; }

        public bool alive { get; set; }

        public Enemy(int x, int y, int health, bool alive)
        {
            this.x = x;
            this.y = y;
            this.health = 1;
            this.alive = alive; 
        }

        public abstract void Set(int x, int y, int health, bool alive);

        public abstract void Move(int dx, int dy);

        public abstract void Draw(Graphics g);

        public abstract void IsAlive();
    }

    public class EasyEnemy : Enemy
    {
        public EasyEnemy(int x, int y, int health = 1, bool alive = true) : base(x, y, health, alive) 
        {
            bounds = new Rectangle(x, y, 20, 20);
        }

        public override void Set(int x, int y, int health, bool alive)
        {
            this.x = x;
            this.y = y;
            this.health = health;
            this.alive = alive;
        }

        public override void Move(int dx, int dy)
        {
            x -= dx;
            y -= dy;
        }

        public override void Draw(Graphics g) 
        {
            if (alive) 
            {
                SolidBrush yBrush = new SolidBrush(Color.Yellow);
                SolidBrush rBrush = new SolidBrush(Color.Red);
                Point[] listOfPoints = new Point[]
                {
                    new Point(x + 2, y - 4),
                    new Point(x + 2, y - 11),
                    new Point(x + 3, y - 11),
                    new Point(x + 3, y - 12),
                    new Point(x + 5, y - 12),
                    new Point(x + 5, y - 20),
                    new Point(x + 7, y - 20),
                    new Point(x + 7, y - 17),
                    new Point(x + 8, y - 17),
                    new Point(x + 8, y - 14),
                    new Point(x + 9, y - 14),
                    new Point(x + 9, y - 13),
                    new Point(x + 11, y - 13),
                    new Point(x + 11, y - 14),
                    new Point(x + 12, y - 14),
                    new Point(x + 12, y - 17),
                    new Point(x + 13, y - 17),
                    new Point(x + 13, y - 20),
                    new Point(x + 15, y - 20),
                    new Point(x + 15, y - 12),
                    new Point(x + 17, y - 12),
                    new Point(x + 17, y - 11),
                    new Point(x + 18, y - 11),
                    new Point(x + 18, y - 4),
                    new Point(x + 17, y - 4),
                    new Point(x + 17, y - 3),
                    new Point(x + 3, y - 3),
                    new Point(x + 3, y - 4)
                };

                Point[] listOfPointsCockpit = new Point[]
                {
                new Point(x + 4, y - 5),
                new Point(x + 16, y - 5),
                new Point(x + 16, y - 9),
                new Point(x + 4, y - 9)
                };

                g.FillPolygon(yBrush, listOfPoints);
                g.FillPolygon(rBrush, listOfPointsCockpit);
            }
        }

        public override void IsAlive() 
        {
            if (health == 0) alive = false;
        }
    }
}
