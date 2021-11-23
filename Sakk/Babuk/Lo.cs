namespace Sakk.Babuk
{
	public class Lo : Babu
	{
		
		public Lo(int sor, int oszlop) : base(sor, oszlop)
		{
			
		}

        public override void LepesBeallitas(Mezo babuHelyzete, Tabla tabla)
        {
            //felfele balra
            if (babuHelyzete.sor - 2 > -1 && babuHelyzete.oszlop - 1 > -1)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 2], babuHelyzete);
            }
            //felfele jobbra
            if (babuHelyzete.sor - 2 > -1 && babuHelyzete.oszlop + 1 < 8)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 2], babuHelyzete);
            }
            //jobbra fel
            if (babuHelyzete.sor - 1 > -1 && babuHelyzete.oszlop + 2 < 8)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + 2, babuHelyzete.sor - 1], babuHelyzete);
            }
            //jobbra le
            if (babuHelyzete.sor + 1 < 8 && babuHelyzete.oszlop + 2 < 8)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + 2, babuHelyzete.sor + 1], babuHelyzete);
            }
            //balra fel
            if (babuHelyzete.sor - 1 > -1 && babuHelyzete.oszlop - 2 > -1)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - 2, babuHelyzete.sor - 1], babuHelyzete);
            }
            //balra le
            if (babuHelyzete.sor + 1 < 8 && babuHelyzete.oszlop - 2 > -1)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - 2, babuHelyzete.sor + 1], babuHelyzete);
            }
            //le balra
            if (babuHelyzete.sor + 2 < 8 && babuHelyzete.oszlop - 1 > -1)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 2], babuHelyzete);
            }
            //le jobbra
            if (babuHelyzete.sor + 2 < 8 && babuHelyzete.oszlop + 1 < 8)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 2], babuHelyzete);
            }
        }
    }
}
