using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

class clsArrow
{
    string sDosyaYolu = "resimler\\arrow.png";
    public int _iX;
    public int _iY;
    int _iHareketMiktari = 20;
    PictureBox pbArrow;
    public clsArrow(Panel pnl,int iYInsan)
    {
        _iY = iYInsan;
        _iX = 100;
        pbArrow = new PictureBox();
        pbArrow.ImageLocation = sDosyaYolu;
        pbArrow.Height =7;
        pbArrow.Width = 49;
        pbArrow.Location = new Point(_iX, _iY);
        pnl.Controls.Add(pbArrow);
    }

    public int HareketEttir()
    {
        _iX += _iHareketMiktari;
        pbArrow.Location = new Point(_iX, _iY);
        return 0;
    }

    public void ArrowSil()
    {
        pbArrow.Visible = false;
    }
}

