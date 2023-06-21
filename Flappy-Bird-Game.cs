using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{ 
    public partial class Form1 : Form
    { 
        int pipespeed = 20;
        int gravity = 15;
        int score = 0;  

        public Form1()
        {        
            InitializeComponent();
        }   
         
      

        private void gamekeyisup(object sender, KeyEventArgs e)
        { 
            if(e.KeyCode == Keys.Space)
            {
                gravity = -15;  
            }

        }
          
        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }

        private void gametimer_Tick(object sender, EventArgs e)
        {
            flappybird.Top += gravity;
            pipedown.Left -= pipespeed;
            pipetop.Left -= pipespeed;
            scoreText.Text = "Score :" + score;



            if (pipedown.Left < -150)
            {
                pipedown.Left = 800;
                score++;
            }
            if (pipetop.Left < -180)
            {
                pipetop.Left = 950;
                score++;
            }
            if(flappybird.Bounds.IntersectsWith(pipedown.Bounds) ||  
                    flappybird.Bounds.IntersectsWith(pipetop.Bounds) ||
                    flappybird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }    

            if(flappybird.Top < -25)
            {
                endGame();
            }
        }
        private void endGame()
        {
            gametimer.Stop();
            scoreText.Text += " You can play better my friend !!!";
        }
    }

}
