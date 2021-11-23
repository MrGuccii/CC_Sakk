﻿namespace Sakk.Babuk
{
	public class Kiralyno : Babu
	{

		public Kiralyno(int sor, int oszlop) : base(sor, oszlop)
		{

		}
		public override void LepesBeallitas(Mezo babuHelyzete, Tabla tabla)
		{
            int seged = 1;
            //felfelé
            while (babuHelyzete.sor - seged > -1)
            {
                if (tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged].foglalt)
                {
                    if (tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                    {
                        tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged], babuHelyzete);
                        break;
                    }
                    break;
                }
                else
                {
                    tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged], babuHelyzete);
                }
                seged++;
            }
            seged = 1;
            //lefelé
            while (babuHelyzete.sor + seged < 8)
            {
                if (tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged].foglalt)
                {
                    if (tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                    {
                        tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged], babuHelyzete);
                        break;
                    }
                    break;
                }
                else
                {
                    tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged], babuHelyzete);
                }
                seged++;
            }
            seged = 1;
            //jobbra
            while (babuHelyzete.oszlop + seged < 8)
            {
                if (tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor].foglalt)
                {
                    if (tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                    {
                        tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor], babuHelyzete);
                        break;
                    }
                    break;
                }
                else
                {
                    tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor], babuHelyzete);
                }
                seged++;
            }
            seged = 1;
            //balra
            while (babuHelyzete.oszlop - seged > -1)
            {
                if (tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor].foglalt)
                {
                    if (tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                    {
                        tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor], babuHelyzete);
                        break;
                    }
                    break;
                }
                else
                {
                    tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor], babuHelyzete);
                }
                seged++;
            }
            seged = 1;
            //felfelé jobbra
            while (babuHelyzete.oszlop + seged < 8 && babuHelyzete.sor - seged > -1)
            {
                if (tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged].foglalt)
                {
                    if (tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                    {
                        tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged], babuHelyzete);
                        break;
                    }
                    break;
                }
                else
                {
                    tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged], babuHelyzete);
                }
                seged++;
            }
            seged = 1;
            //felfelé balra
            while (babuHelyzete.oszlop - seged > -1 && babuHelyzete.sor - seged > -1)
            {
                if (tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged].foglalt)
                {
                    if (tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                    {
                        tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged], babuHelyzete);
                        break;
                    }
                    break;
                }
                else
                {
                    tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged], babuHelyzete);
                }
                seged++;
            }
            seged = 1;
            //lefelé jobbra
            while (babuHelyzete.oszlop + seged < 8 && babuHelyzete.sor + seged < 8)
            {
                if (tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged].foglalt)
                {
                    if (tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                    {
                        tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged], babuHelyzete);
                        break;
                    }
                    break;
                }
                else
                {
                    tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged], babuHelyzete);
                }
                seged++;
            }
            seged = 1;
            //lefelé balra
            while (babuHelyzete.oszlop - seged > -1 && babuHelyzete.sor + seged < 8)
            {
                if (tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged].foglalt)
                {
                    if (tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                    {
                        tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged], babuHelyzete);
                        break;
                    }
                    break;
                }
                else
                {
                    tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged], babuHelyzete);
                }
                seged++;
            }
            seged = 1;
        }
	}
}
