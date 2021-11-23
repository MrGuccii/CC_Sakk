namespace Sakk.Babuk
{
	public class Kiraly : LepesSzamlalo
	{
		public Kiraly(int sor, int oszlop) : base(sor, oszlop)
		{
		}
		public override void LepesBeallitas(Mezo babuHelyzete, Tabla tabla)
		{
            //rosálás ha lehetséges
            if (tabla.FeherFelfeleTudSancolni())
            {
                tabla.tabla[0, 1].lepesek = true;
            }
            if (tabla.FeherLefeleTudSancolni())
            {
                tabla.tabla[0, 5].lepesek = true;
            }
            if (tabla.FeketeFelfeleTudSancolni())
            {
                tabla.tabla[7, 1].lepesek = true;
            }
            if (tabla.FeketeLefeleTudSancolni())
            {
                tabla.tabla[7, 5].lepesek = true;
            }
            //felfelé
            if (babuHelyzete.sor - 1 > -1)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor - 1], babuHelyzete);
            }
            //felfelé jobbra
            if (babuHelyzete.sor - 1 > -1 && babuHelyzete.oszlop + 1 < 8)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1], babuHelyzete);
            }
            //felfelé balra
            if (babuHelyzete.sor - 1 > -1 && babuHelyzete.oszlop - 1 > -1)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1], babuHelyzete);
            }
            //jobbra
            if (babuHelyzete.oszlop + 1 < 8)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor], babuHelyzete);
            }
            //balra
            if (babuHelyzete.oszlop - 1 > -1)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor], babuHelyzete);
            }
            //lefelé
            if (babuHelyzete.sor + 1 < 8)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor + 1], babuHelyzete);
            }
            //lefelé jobbra
            if (babuHelyzete.oszlop + 1 < 8 && babuHelyzete.sor + 1 < 8)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1], babuHelyzete);
            }
            //lefelé balra
            if (babuHelyzete.oszlop - 1 > -1 && babuHelyzete.sor + 1 < 8)
            {
                tabla.lepesiLehetoseg(tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1], babuHelyzete);
            }
        }
	}
}
