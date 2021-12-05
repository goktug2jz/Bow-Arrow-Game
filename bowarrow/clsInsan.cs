using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

class clsInsan
{
    string sDosyaYolu="resimler\\Man.png";
    int _iX;
    int _iY;
    int _iHareketMiktari = 10;
    public PictureBox pbInsan;

    public clsInsan(int ix,int iy,Panel pnl)
    {
        _iX = ix;
        _iY = iy;

        pbInsan = new PictureBox();
        pbInsan.ImageLocation = sDosyaYolu;
        pbInsan.Location = new Point(_iX, _iY);
        pbInsan.SizeMode = PictureBoxSizeMode.Zoom;
        pbInsan.Height = 100;

        pnl.Controls.Add(pbInsan);
    }

    public int HareketEttir(int iYon)
    {
        switch (iYon)
        {
            case (int)Yonler.asagi:
                _iY += _iHareketMiktari;
                break;
            case (int)Yonler.yukari:
                _iY -= _iHareketMiktari;
                break;
        }
        pbInsan.Location = new Point(_iX, _iY);
        return _iY;
    }
}

