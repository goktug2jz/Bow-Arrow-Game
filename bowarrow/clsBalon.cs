using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

class clsBalon
{
    string sDosyaYolu="resimler\\balloon.png";
    public int _iX;
    public int _iY;
    int _iHareketMiktari=10;
    PictureBox pbBalon;
    public clsBalon(Panel pnl)
    {
        pbBalon = new PictureBox();
        pbBalon.ImageLocation = sDosyaYolu;
        Random rndSayi = new Random();
        _iX = rndSayi.Next(300) + 400;
        _iY = pnl.Height;
        pbBalon.Location = new Point(_iX, _iY);
        pbBalon.Width = 40;
        pbBalon.Height = 40;
        pbBalon.SizeMode = PictureBoxSizeMode.Zoom;
        pnl.Controls.Add(pbBalon);
    }

    public void HareketEttir()
    {
        _iY -= _iHareketMiktari;
        pbBalon.Location = new Point(_iX, _iY);
        
    }
    public void BalonSil()
    {
        pbBalon.Visible = false;
    }
}

