using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                Projectile playerProjecile = new Projectile(1);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Character player = new Character(ClientRectangle.Width / 2, ClientRectangle.Height - 50);
            player.Draw();
        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }

    public class Character
    {
        int x, y;
        public Character(int x, int y) 
        {
            this.x = x;
            this.y = y;
        }
    
        public void Move(int dx, int dy)
        {

        }

        public void Draw()
        {
            PictureBox pbPlayer = new PictureBox();
            pbPlayer.Location = new Point(x, y);
            pbPlayer.Image = Image.FromFile("C:\\Users\\ck3jo\\Documents\\GitHub\\projektni-zadatak-oop\\projektni-zadatak-oop\\player.jpg");
            pbPlayer.Show();
        }
    }

    public class Projectile
    {
        int strength;

        public Projectile(int strength)
        {
            this.strength = strength;
        }

        public void IncreaseStrength(int d)
        {
            strength += d;
        }
    }

    public abstract class Enemy
    {
        int x, y;
    }
}
