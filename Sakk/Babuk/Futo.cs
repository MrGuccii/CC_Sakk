namespace Sakk.Babuk
{
	public class Futo : Babu
	{

		public Futo(int sor, int oszlop) : base(sor, oszlop)
		{

		}
		public override void LepesBeallitas(Mezo babuHelyzete, Tabla tabla)
		{
            int seged = 1;
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
