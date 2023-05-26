using System.Net.Quic;
using System.Security;

namespace projektni_zadatak_oop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Background bg = new Background();
        Random r = new Random();

        private void tLogoShow_Tick(object sender, EventArgs e)
        {
            pbLogo.Visible = true;
            bStart.Visible = true;
            bExit.Visible = true;
            tLogoShow.Enabled = false;
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            var f = new Form2();
            f.Show();
            this.Hide();         
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tBackgroundStart_Tick(object sender, EventArgs e)
        {            
            for (int i = 0; i < 175; ++i)
            {
                switch (r.Next(0, 5))
                {
                    case 0:
                        bg.Add(new Particle(r.Next(0, ClientRectangle.Width), 0, 10, Color.White));
                        break;
                    case 1:
                        bg.Add(new Particle(r.Next(0, ClientRectangle.Width), 0, 10, Color.Red));
                        break;
                    case 2:
                        bg.Add(new Particle(r.Next(0, ClientRectangle.Width), 0, 10, Color.Green));
                        break;
                    case 3:
                        bg.Add(new Particle(r.Next(0, ClientRectangle.Width), 0, 10, Color.Yellow));
                        break;
                    case 4:
                        bg.Add(new Particle(r.Next(0, ClientRectangle.Width), 0, 10, Color.Blue));
                        break;
                    default:
                        break;
                }
            }           
            tBackgroundAnim.Enabled = true;
            tBackgroundStart.Enabled = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Particle part in bg.listOfParticles) { part.Draw(e.Graphics); }
        }

        private void tBackgroundAnim_Tick(object sender, EventArgs e)
        {
            Refresh();
            
            foreach (Particle part in bg.listOfParticles)
            {
                switch (r.Next(0, 2))
                {
                    case 0:
                        if (part.y > ClientRectangle.Height) { part.Set(part.x, 0, 10); }
                        part.Move(r.Next(5, 20), r.Next(5, 20));
                        break;
                    case 1:
                        if (part.y > ClientRectangle.Height) { part.Set(part.x, 0, 10); }
                        part.Move(r.Next(5, 20) * (-1), r.Next(5, 20));
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public class Background
    {
        public List<Particle> listOfParticles { get; set; }

        public Background() { listOfParticles = new List<Particle>(); }

        public void Add(Particle particle) { listOfParticles.Add(particle); }
    }
    
    public class Particle
    {
        public int x, y, size;
        Color color;

        public Particle(int x, int y, int size, Color color)
        {
            this.x = x;
            this.y = y;
            this.size = size;
            this.color = color;
        }

        public void Move(int dx, int dy)
        {
            this.x += dx;
            this.y += dy;
        }

        public void Set(int x, int y, int size) 
        {
            this.x = x;
            this.y = y;
            this.size = size;
        }

        public void Draw(Graphics g)
        {
            SolidBrush brush = new SolidBrush(color);
            g.FillRectangle(brush, x, y, size, size);
        }
    }
}