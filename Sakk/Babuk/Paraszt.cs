namespace Sakk.Babuk
{
	public class Paraszt : LepesSzamlalo
	{
		public Paraszt(int sor, int oszlop) : base(sor, oszlop)
		{
		}
		public void LepesBeallitas(Mezo babuHelyzete, Tabla tabla)
		{
            //fehér
            if (tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuFeher)
            {
                if (babuHelyzete.oszlop + 1 < 8)
                {
                    if (!tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor].foglalt)
                    {
                        if (!tabla.tabla[babuHelyzete.oszlop + 2, babuHelyzete.sor].foglalt && (babuHelyzete as LepesSzamlalo).nemLepettMeg)
                        {
                            tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + 2, babuHelyzete.sor], babuHelyzete);
                        }
                        tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor], babuHelyzete);
                        if (babuHelyzete.sor - 1 > -1 && tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1].foglalt)
                        {
                            tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1], babuHelyzete);
                        }
                        if (babuHelyzete.sor + 1 < 8 && tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1].foglalt)
                        {
                            tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1], babuHelyzete);
                        }
                    }
                    else if (babuHelyzete.sor - 1 > -1 && tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1].foglalt)
                    {
                        tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1], babuHelyzete);
                        if (babuHelyzete.sor + 1 < 8 && tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1].foglalt)
                        {
                            tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1], babuHelyzete);
                        }
                    }
                    else if (tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1].foglalt)
                    {
                        tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1], babuHelyzete);
                        if (babuHelyzete.sor - 1 > -1 && tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1].foglalt)
                        {
                            tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1], babuHelyzete);
                        }
                    }
                }
            }
            //fekete
            if (tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuFekete)
            {
                if (babuHelyzete.oszlop - 1 > -1)
                {
                    if (!tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor].foglalt)
                    {
                        if (!tabla.tabla[babuHelyzete.oszlop - 2, babuHelyzete.sor].foglalt && (babuHelyzete as LepesSzamlalo).nemLepettMeg)
                        {
                            tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - 2, babuHelyzete.sor], babuHelyzete);
                        }
                        tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor], babuHelyzete);
                        if (babuHelyzete.sor - 1 > -1 && tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1].foglalt)
                        {
                            tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1], babuHelyzete);
                        }
                        if (babuHelyzete.sor + 1 < 8 && tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1].foglalt)
                        {
                            tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1], babuHelyzete);
                        }
                    }
                    else if (tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1].foglalt)
                    {
                        tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1], babuHelyzete);
                        if (babuHelyzete.sor + 1 < 8 && tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1].foglalt)
                        {
                            tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1], babuHelyzete);
                        }
                    }
                    else if (tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1].foglalt)
                    {
                        tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1], babuHelyzete);
                        if (babuHelyzete.sor - 1 > -1 && tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1].babuSzine != tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1].foglalt)
                        {
                            tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1], babuHelyzete);
                        }
                    }
                }
            }
        }
	}
}
