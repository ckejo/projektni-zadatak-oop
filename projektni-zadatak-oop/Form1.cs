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
            tBackgroundAnim.Enabled = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Particle part in bg.listOfParticles) { part.Draw(e.Graphics); }
        }

        private void tBackgroundAnim_Tick(object sender, EventArgs e)
        {
            tBackgroundStart.Enabled = false;
            Refresh();
            
            foreach (Particle part in bg.listOfParticles)
            {
                if (r.Next(0, 2) == 0)
                {
                    if (part.y > ClientRectangle.Height) { part.Set(part.x, ClientRectangle.Height, part.size); }
                    part.Move(r.Next(10, 20), r.Next(10, 20));
                }
                else
                {
                    if (part.y > ClientRectangle.Height) { part.Set(part.x, ClientRectangle.Height, part.size); }
                    part.Move(r.Next(10, 20) * (-1), r.Next(10, 20));
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 175; ++i)
            {
                if (r.Next(0, 5) == 0)
                {
                    bg.AddParticle(new Particle(r.Next(20, ClientRectangle.Width - 20), r.Next(ClientRectangle.Height - 50, ClientRectangle.Height), 2, Color.White));
                }
                if (r.Next(0, 5) == 1)
                {
                    bg.AddParticle(new Particle(r.Next(20, ClientRectangle.Width - 20), r.Next(ClientRectangle.Height - 50, ClientRectangle.Height), 2, Color.Red));
                }
                if (r.Next(0, 5) == 2)
                {
                    bg.AddParticle(new Particle(r.Next(20, ClientRectangle.Width - 20), r.Next(ClientRectangle.Height - 50, ClientRectangle.Height), 2, Color.Green));
                }
                if (r.Next(0, 5) == 3)
                {
                    bg.AddParticle(new Particle(r.Next(20, ClientRectangle.Width - 20), r.Next(ClientRectangle.Height - 50, ClientRectangle.Height), 2, Color.Blue));
                }
                if (r.Next(0, 5) == 4)
                {
                    bg.AddParticle(new Particle(r.Next(20, ClientRectangle.Width - 20), r.Next(ClientRectangle.Height - 50, ClientRectangle.Height), 2, Color.Yellow));
                }
            }
        }
    }

    public class Background
    {
        public List<Particle> listOfParticles { get; set; }

        public Background() { listOfParticles = new List<Particle>(); }

        public void AddParticle(Particle particle) { listOfParticles.Add(particle); }
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
            this.x -= dx;
            this.y -= dy;
        }

        public void Set(int x, int y, int size) 
        {
            this.x = x;
            this.y = y;
            this.size = size;
        }

        public void Draw(Graphics g)
        {
            Pen pen = new Pen(color);
            SolidBrush brush = new SolidBrush(color);
            g.DrawRectangle(pen, x, y, size, size);
            g.FillRectangle(brush, x, y, size, size);
        }
    }
}