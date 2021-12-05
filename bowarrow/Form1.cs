using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bowarrow
{
    public partial class Form1 : Form
    {
        int iSayac = 12;
        int iArrowSayisi = 5;
        int iPuan = 0;
        DateTime dtLastMove;
        clsInsan insan;
        clsBalon balon;
        clsArrow arrow;
        clsArrow silinecekArrow;
        clsBalon silinecekBalon;
        List<clsBalon> lBalonlar = new List<clsBalon>();
        List<clsArrow> lArrows = new List<clsArrow>();

        int iYInsan=100;
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 50;
            insan = new clsInsan(100, iYInsan, panel1);
            lblOkSayisi.Text = iArrowSayisi.ToString();
            dtLastMove = DateTime.Now;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            iSayac++;
            if (iSayac >= 12)
            {
                balon = new clsBalon(panel1);
                lBalonlar.Add(balon);
                iSayac = 0;
            }
            
            foreach (clsBalon n in this.lBalonlar)
            {
                n.HareketEttir();
            }

            foreach (clsArrow n in this.lArrows)
            {
                n.HareketEttir();
                if (n._iX >= panel1.Width)
                {
                    silinecekArrow = n;
                    iArrowSayisi++;
                }
            }
            lArrows.Remove(silinecekArrow);

            foreach (clsBalon degiskenBalon in this.lBalonlar)
            {
                foreach (clsArrow degiskenArrow in this.lArrows)
                {
                    bool carptiMi=carpismaKontrol(degiskenArrow._iX, degiskenArrow._iY, degiskenBalon._iX, degiskenBalon._iY);
                    if (carptiMi)
                    {
                        silinecekBalon = degiskenBalon;
                        iPuan++;
                        lblPuan.Text = "Puan = " + iPuan.ToString();
                    }
                }
            }
            if (silinecekBalon != null)
            {
                silinecekBalon.BalonSil();
            }
            lBalonlar.Remove(silinecekBalon);
            lArrows.Remove(silinecekArrow);
            lblOkSayisi.Text = "Ok sayısı = "+iArrowSayisi.ToString();
        }

        

        public bool carpismaKontrol(int iXArrow,int iYArrow,int iXBalon,int iYBalon)
        {
            if (iXArrow+49>=iXBalon && iXArrow <= iXBalon+40 && iYArrow+7>=iYBalon && iYArrow <= iYBalon+40)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (dtLastMove.AddMilliseconds(50) >= DateTime.Now)
                return;
            dtLastMove = DateTime.Now;
            switch (e.KeyCode)
            {
                case Keys.Down:
                    iYInsan = insan.HareketEttir((int)Yonler.asagi);
                    break;

                case Keys.Up:
                    iYInsan = insan.HareketEttir((int)Yonler.yukari);
                    break;

                case Keys.Space:
                    if (iArrowSayisi > 0)
                    {
                        iArrowSayisi--;
                        arrow = new clsArrow(panel1, iYInsan + (insan.pbInsan.Height / 2));
                        lArrows.Add(arrow);

                    }
                    break;
            }
        }
    }
}
