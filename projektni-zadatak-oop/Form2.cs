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

        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }

    public class Character
    {
        int x, y;
        public Character() { }
    
        public void Move(int dx, int dy)
        {

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
