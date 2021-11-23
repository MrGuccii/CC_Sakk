using Sakk.Babuk;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sakk
{
    public class Tabla
    {
        public Mezo[,] tabla { get; set; }
        private Koordinata aktivMezo { get; set; }
        public BabuSzine kovetkezoSzin { get; set; }      
        public bool jatekVege { get; set; }

        //tábla legenerálása
        public Tabla(int tablameret)
        {
            tabla = new Mezo[tablameret, tablameret];
            int gombMeret = 70;

            for (int i = 0; i < tablameret; i++)
            {
                for (int h = 0; h < tablameret; h++)
                {
                    tabla[i, h] = new Mezo(h, i);
                    tabla[i, h].gomb.Height = gombMeret;
                    tabla[i, h].gomb.Width = gombMeret;
                }
            }
        }
        //bábu kiválasztása vagy léptetése
        public void GombNyomas(Mezo mezo)
        {
            if (mezo.foglalt && !mezo.lepesek && kovetkezoSzin == mezo.babuSzine)
            {
                LehetosegekTorlese();
                LehetosegekBeallitasa(mezo, mezo.babuTipus);
                aktivMezo = new Koordinata(mezo.oszlop, mezo.sor);
            }
            else if (mezo.lepesek)
            {
                Mezo regiMezo = tabla[aktivMezo.x, aktivMezo.y];
                Lepes(regiMezo,mezo);
                if (kovetkezoSzin == BabuSzine.FEHER)
                {
                    kovetkezoSzin = BabuSzine.FEKETE;
                }
                else
                {
                    kovetkezoSzin = BabuSzine.FEHER;
                }
            }
        }
        private bool FeherFelfeleSancolt(Mezo honnan, Mezo hova)
        {
            return honnan.sor == 3 && honnan.oszlop == 0 && hova.sor == 1 && hova.oszlop == 0 && honnan is Kiraly;
        }
        private bool FeherLefeleSancolt(Mezo honnan, Mezo hova)
        {
            return honnan.sor == 3 && honnan.oszlop == 0 && hova.sor == 5 && hova.oszlop == 0 && honnan is Kiraly;
        }
        private bool FeketeFelfeleSancolt(Mezo honnan, Mezo hova)
        {
            return honnan.sor == 3 && honnan.oszlop == 7 && hova.sor == 1 && hova.oszlop == 7 && honnan is Kiraly;
        }
        private bool FeketeLefeleSancolt(Mezo honnan, Mezo hova)
        {
            return honnan.sor == 3 && honnan.oszlop == 7 && hova.sor == 5 && hova.oszlop == 7 && honnan is Kiraly;
        }
        //bábu léptetése
        public void Lepes(Mezo honnan, Mezo hova)
        {
			if (FeherFelfeleSancolt(honnan, hova))
			{
                Lepes(tabla[0, 0],tabla[0, 2]);
			}
            if (FeherLefeleSancolt(honnan, hova))
            {
                Lepes(tabla[0, 7], tabla[0, 4]);
            }
            if (FeketeFelfeleSancolt(honnan, hova))
            {
                Lepes(tabla[7, 0], tabla[7, 2]);
            }
            if (FeketeLefeleSancolt(honnan, hova))
            {
                Lepes(tabla[7, 7], tabla[7, 4]);
            }

            if ((honnan.babuFekete && hova.babuFeher) || (honnan.babuFeher && hova.babuFekete))
            {
                int honnanSor = honnan.sor;
                int honnanOszlop = honnan.oszlop;
                honnan.Lepes(hova.sor, hova.oszlop);
                hova = new Mezo(honnanSor, honnanOszlop);
                hova.setChanged();
                honnan.setChanged();
                tabla[honnan.oszlop, honnan.sor] = honnan;
                tabla[hova.oszlop, hova.sor] = hova;
            }
            else
            {
                int hovaSor = hova.sor;
                int hovaOszlop = hova.oszlop;
                hova.Lepes(honnan.sor, honnan.oszlop);
                honnan.Lepes(hovaSor, hovaOszlop);
                honnan.setChanged();
                hova.setChanged();
                tabla[honnan.oszlop, honnan.sor] = honnan;
                tabla[hova.oszlop, hova.sor] = hova;
            }
            
            LehetosegekTorlese();
			if (hova is Kiraly && hova.babuFekete)
			{
                MessageBox.Show("A fehér nyert!");
                jatekVege = true;
			}
            if (hova is Kiraly && hova.babuFeher)
            {
                MessageBox.Show("A fekete nyert!");
                jatekVege = true;
            }
        }
        public bool FeherFelfeleTudSancolni()
        {
            return tabla[0, 3] is Kiraly && tabla[0, 3].babuFeher && (tabla[0, 3] as LepesSzamlalo).nemLepettMeg && tabla[0, 0] is Bastya && (tabla[0, 0] as LepesSzamlalo).nemLepettMeg && tabla[0, 0].babuFeher && !tabla[0, 1].foglalt && !tabla[0, 2].foglalt;
        }
        public bool FeherLefeleTudSancolni()
        {
            return tabla[0, 3] is Kiraly && tabla[0, 3].babuFeher && (tabla[0, 3] as LepesSzamlalo).nemLepettMeg && tabla[0, 7] is Bastya && (tabla[0, 7] as LepesSzamlalo).nemLepettMeg && tabla[0, 7].babuFeher && !tabla[0, 4].foglalt && !tabla[0, 5].foglalt && !tabla[0, 6].foglalt; 
        }
        public bool FeketeFelfeleTudSancolni()
        {
            return tabla[7, 3] is Kiraly && tabla[7, 3].babuFekete && (tabla[7, 3] as LepesSzamlalo).nemLepettMeg && tabla[7, 0] is Bastya && (tabla[7, 0] as LepesSzamlalo).nemLepettMeg && tabla[7, 0].babuFekete && !tabla[7, 1].foglalt && !tabla[7, 2].foglalt;
        }
        public bool FeketeLefeleTudSancolni()
        {
            return tabla[7, 3] is Kiraly && tabla[7, 3].babuFekete && (tabla[7, 3] as LepesSzamlalo).nemLepettMeg && tabla[7, 7] is Bastya && (tabla[7, 7] as LepesSzamlalo).nemLepettMeg && tabla[7, 7].babuFekete && !tabla[7, 4].foglalt && !tabla[7, 5].foglalt && !tabla[7, 6].foglalt;
        }
        //előzőleg kijelölt területek törlése
        public void LehetosegekTorlese()
        {
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int h = 0; h < tabla.GetLength(1); h++)
                {
                    tabla[i, h].lepesek = false;
                    tabla[i, h].setChanged();
                }
            }
        }
        //azoknak a mezőkek a kijelölése ahová léphet a bábu
        public void lepesiLehetoseg(Mezo cel, Mezo start) 
        {
            if ((cel.foglalt && cel.babuSzine != start.babuSzine) || !cel.foglalt)
            {
                tabla[cel.oszlop, cel.sor].lepesek = true;
                tabla[cel.oszlop, cel.sor].setChanged();
            }
        }
        //bábuk lépés szabályai
        public void LehetosegekBeallitasa(Mezo babuHelyzete, Babu babu)
        {
            babu.LepesBeallitas(babuHelyzete, this);
            /*switch (babu)
            {                                   
                /*case "Ló":
                    //felfele balra
                    if (babuHelyzete.sor - 2 > -1 && babuHelyzete.oszlop - 1 > -1)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 2], babuHelyzete);
                    }
                    //felfele jobbra
                    if (babuHelyzete.sor - 2 > -1 && babuHelyzete.oszlop + 1 < 8)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 2], babuHelyzete);
                    }
                    //jobbra fel
                    if (babuHelyzete.sor - 1 > -1 && babuHelyzete.oszlop + 2 < 8)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop + 2, babuHelyzete.sor - 1], babuHelyzete);
                    }
                    //jobbra le
                    if (babuHelyzete.sor + 1 < 8 && babuHelyzete.oszlop + 2 < 8)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop + 2, babuHelyzete.sor + 1], babuHelyzete);
                    }
                    //balra fel
                    if (babuHelyzete.sor - 1 > -1 && babuHelyzete.oszlop - 2 > -1)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop - 2, babuHelyzete.sor - 1], babuHelyzete);
                    }
                    //balra le
                    if (babuHelyzete.sor + 1 < 8 && babuHelyzete.oszlop - 2 > -1)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop - 2, babuHelyzete.sor + 1], babuHelyzete);
                    }
                    //le balra
                    if (babuHelyzete.sor + 2 < 8 && babuHelyzete.oszlop - 1 > -1)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 2], babuHelyzete);
                    }
                    //le jobbra
                    if (babuHelyzete.sor + 2 < 8 && babuHelyzete.oszlop + 1 < 8)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 2], babuHelyzete);
                    }
                    break;*/

                /*case "Király":
                    //rosálás ha lehetséges
					if (FeherFelfeleTudSancolni())
					{
                        tabla[0, 1].lepesek = true;	
					}
                    if (FeherLefeleTudSancolni())
                    {
                        tabla[0, 5].lepesek = true;
                    }
                    if (FeketeFelfeleTudSancolni())
                    {
                        tabla[7, 1].lepesek = true;
                    }
                    if (FeketeLefeleTudSancolni())
                    {
                        tabla[7, 5].lepesek = true;
                    }
                    //felfelé
                    if (babuHelyzete.sor - 1 > -1)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop, babuHelyzete.sor - 1], babuHelyzete);
                    }
                    //felfelé jobbra
                    if (babuHelyzete.sor - 1 > -1 && babuHelyzete.oszlop + 1 < 8)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1], babuHelyzete);
                    }
                    //felfelé balra
                    if (babuHelyzete.sor - 1 > -1 && babuHelyzete.oszlop - 1 > -1)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1], babuHelyzete);
                    }
                    //jobbra
                    if (babuHelyzete.oszlop + 1 < 8)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor], babuHelyzete);
                    }
                    //balra
                    if (babuHelyzete.oszlop - 1 > -1)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor], babuHelyzete);
                    }
                    //lefelé
                    if (babuHelyzete.sor + 1 < 8)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop, babuHelyzete.sor + 1], babuHelyzete);
                    }
                    //lefelé jobbra
                    if (babuHelyzete.oszlop + 1 < 8 && babuHelyzete.sor + 1 < 8)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1], babuHelyzete);
                    }
                    //lefelé balra
                    if (babuHelyzete.oszlop - 1 > -1 && babuHelyzete.sor + 1 < 8)
                    {
                        lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1], babuHelyzete);
                    }
                    break;*/

                /*case "Királynő":
                    //felfelé
                        while (babuHelyzete.sor - seged > -1)
                        {
                            if (tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged], babuHelyzete);                               
                            }
                            seged++;
                        }
                    seged = 1;
                    //lefelé
                        while (babuHelyzete.sor + seged < 8)
                        {
                            if (tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    //jobbra
                        while (babuHelyzete.oszlop + seged < 8)
                        {
                            if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    //balra
                        while (babuHelyzete.oszlop - seged > -1)
                        {
                            if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    //felfelé jobbra
                        while (babuHelyzete.oszlop + seged < 8 && babuHelyzete.sor - seged > -1)
                        {
                            if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged], babuHelyzete);
                                    break;
                                }
                                break;  
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged], babuHelyzete);
                            }                            
                            seged++;
                        }
                    seged = 1;
                    //felfelé balra
                        while (babuHelyzete.oszlop - seged > -1 && babuHelyzete.sor - seged > -1)
                        {
                            if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    //lefelé jobbra
                        while (babuHelyzete.oszlop + seged < 8 && babuHelyzete.sor + seged < 8)
                        {
                            if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    //lefelé balra
                        while (babuHelyzete.oszlop - seged > -1 && babuHelyzete.sor + seged < 8)
                        {
                            if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    break;*/

                /*case "Futó":
                    //felfelé jobbra
                        while (babuHelyzete.oszlop + seged < 8 && babuHelyzete.sor - seged > -1)
                        {
                            if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor - seged], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    //felfelé balra
                        while (babuHelyzete.oszlop - seged > -1 && babuHelyzete.sor - seged > -1)
                        {
                            if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor - seged], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    //lefelé jobbra
                        while (babuHelyzete.oszlop + seged < 8 && babuHelyzete.sor + seged < 8)
                        {
                            if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor + seged], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    //lefelé balra
                        while (babuHelyzete.oszlop - seged > -1 && babuHelyzete.sor + seged < 8)
                        {
                            if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor + seged], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    break;*/

                /*case "Bástya":
                    //felfelé
                        
                    while (babuHelyzete.sor - seged > -1)
                        {
                            if (tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop, babuHelyzete.sor - seged], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    //lefelé
                        while (babuHelyzete.sor + seged < 8)
                        {
                            if (tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop, babuHelyzete.sor + seged], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    //jobbra
                        while (babuHelyzete.oszlop + seged < 8)
                        {
                            if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop + seged, babuHelyzete.sor], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    //balra
                        while (babuHelyzete.oszlop - seged > -1)
                        {
                            if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor].foglalt)
                            {
                                if (tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor], babuHelyzete);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop - seged, babuHelyzete.sor], babuHelyzete);
                            }
                            seged++;
                        }
                    seged = 1;
                    break;
                    
                case "Paraszt":
                    //fehér
                    if (tabla[babuHelyzete.oszlop,babuHelyzete.sor].babuFeher)
                    {
                        if (babuHelyzete.oszlop + 1 < 8)
                        {
                            if (!tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor].foglalt)
                            {
                                if (!tabla[babuHelyzete.oszlop + 2, babuHelyzete.sor].foglalt && (babuHelyzete as LepesSzamlalo).nemLepettMeg)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop + 2, babuHelyzete.sor], babuHelyzete);
                                }
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor], babuHelyzete);
                                if (babuHelyzete.sor - 1 > -1 && tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1].foglalt)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1], babuHelyzete);
                                }
                                if (babuHelyzete.sor + 1 < 8 && tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1].foglalt)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1], babuHelyzete);
                                }
                            }
                            else if(babuHelyzete.sor -1 > -1 && tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor -1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1].foglalt)
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1], babuHelyzete);
                                if (babuHelyzete.sor + 1 < 8 && tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1].foglalt)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1], babuHelyzete);
                                }
                            }
                            else if (tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1].foglalt)
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1], babuHelyzete);
                                if (babuHelyzete.sor - 1 > -1 && tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1].foglalt)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1], babuHelyzete);
                                }
                            }                           
                        }
                    }
                    //fekete
                    if (tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuFekete)
                    {
                        if (babuHelyzete.oszlop - 1 > -1)
                        {
                            if (!tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor].foglalt)
                            {
								if (!tabla[babuHelyzete.oszlop - 2, babuHelyzete.sor].foglalt && (babuHelyzete as LepesSzamlalo).nemLepettMeg)
								{
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop - 2, babuHelyzete.sor], babuHelyzete);
                                }
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor], babuHelyzete);
                                if (babuHelyzete.sor - 1 > -1 && tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1].foglalt)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1], babuHelyzete);
                                }
                                if (babuHelyzete.sor + 1 < 8 && tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1].foglalt)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1], babuHelyzete);
                                }
                            }
                            else if (tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1].foglalt)
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1], babuHelyzete);
                                if (babuHelyzete.sor + 1 < 8 && tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1].foglalt)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1], babuHelyzete);
                                }
                            }
                            else if (tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1].foglalt)
                            {
                                lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1], babuHelyzete);
                                if (babuHelyzete.sor - 1 > -1 && tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1].babuSzine != tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuSzine && tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1].foglalt)
                                {
                                    lepesiLehetoseg(tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1], babuHelyzete);
                                }
                            }
                        }
                    }
                    break;

                default:
                    break;
            }*/
        }
        //tábla alaphelyzet
        public void jatekInditasa()
        {
            kovetkezoSzin = BabuSzine.FEHER;

            tabla[0, 0] = new Bastya(0, 0);
            tabla[0, 0].babuTipus = new Babu(0, 0);
            tabla[0, 0].babuNeve = "Bástya";
            tabla[0, 0].babuSzine = BabuSzine.FEHER;

            tabla[0, 1] = new Lo(1, 0);
            tabla[0, 1].babuNeve = "Ló";
            tabla[0, 1].babuSzine = BabuSzine.FEHER;

            tabla[0, 2] = new Futo(2, 0);
            tabla[0, 2].babuNeve = "Futó";
            tabla[0, 2].babuSzine = BabuSzine.FEHER;

            tabla[0, 3] = new Kiraly(3, 0);
            tabla[0, 3].babuNeve = "Király";
            tabla[0, 3].babuSzine = BabuSzine.FEHER;

            tabla[0, 4] = new Kiralyno(4, 0);
            tabla[0, 4].babuNeve = "Királynő";
            tabla[0, 4].babuSzine = BabuSzine.FEHER;

            tabla[0, 5] = new Futo(5, 0);
            tabla[0, 5].babuNeve = "Futó";
            tabla[0, 5].babuSzine = BabuSzine.FEHER;

            tabla[0, 6] = new Lo(6, 0);
            tabla[0, 6].babuNeve = "Ló";
            tabla[0, 6].babuSzine = BabuSzine.FEHER;

            tabla[0, 7] = new Bastya(7, 0);
            tabla[0, 7].babuNeve = "Bástya";
            tabla[0, 7].babuSzine = BabuSzine.FEHER;

            tabla[1, 0] = new Paraszt(0, 1);
            tabla[1, 0].babuTipus = new Babu(0, 1);
            tabla[1, 0].babuNeve = "Paraszt";
            tabla[1, 0].babuSzine = BabuSzine.FEHER;

            tabla[1, 1] = new Paraszt(1, 1);
            tabla[1, 1].babuNeve = "Paraszt";
            tabla[1, 1].babuSzine = BabuSzine.FEHER;

            tabla[1, 2] = new Paraszt(2, 1);
            tabla[1, 2].babuNeve = "Paraszt";
            tabla[1, 2].babuSzine = BabuSzine.FEHER;

            tabla[1, 3] = new Paraszt(3, 1);
            tabla[1, 3].babuNeve = "Paraszt";
            tabla[1, 3].babuSzine = BabuSzine.FEHER;

            tabla[1, 4] = new Paraszt(4, 1);
            tabla[1, 4].babuNeve = "Paraszt";
            tabla[1, 4].babuSzine = BabuSzine.FEHER;

            tabla[1, 5] = new Paraszt(5, 1);
            tabla[1, 5].babuNeve = "Paraszt";
            tabla[1, 5].babuSzine = BabuSzine.FEHER;

            tabla[1, 6] = new Paraszt(6, 1);
            tabla[1, 6].babuNeve = "Paraszt";
            tabla[1, 6].babuSzine = BabuSzine.FEHER;

            tabla[1, 7] = new Paraszt(7, 1);
            tabla[1, 7].babuNeve = "Paraszt";
            tabla[1, 7].babuSzine = BabuSzine.FEHER;

            tabla[7, 0] = new Bastya(0, 7);
            tabla[7, 0].babuNeve = "Bástya";
            tabla[7, 0].babuSzine = BabuSzine.FEKETE;

            tabla[7, 1] = new Lo(1, 7);
            tabla[7, 1].babuNeve = "Ló";
            tabla[7, 1].babuSzine = BabuSzine.FEKETE;

            tabla[7, 2] = new Futo(2, 7);
            tabla[7, 2].babuNeve = "Futó";
            tabla[7, 2].babuSzine = BabuSzine.FEKETE;

            tabla[7, 3] = new Kiraly(3, 7);
            tabla[7, 3].babuNeve = "Király";
            tabla[7, 3].babuSzine = BabuSzine.FEKETE;

            tabla[7, 4] = new Kiralyno(4, 7);
            tabla[7, 4].babuNeve = "Királynő";
            tabla[7, 4].babuSzine = BabuSzine.FEKETE;

            tabla[7, 5] = new Futo(5, 7);
            tabla[7, 5].babuNeve = "Futó";
            tabla[7, 5].babuSzine = BabuSzine.FEKETE;

            tabla[7, 6] = new Lo(6, 7);
            tabla[7, 6].babuNeve = "Ló";
            tabla[7, 6].babuSzine = BabuSzine.FEKETE;

            tabla[7, 7] = new Bastya(7, 7);
            tabla[7, 7].babuNeve = "Bástya";
            tabla[7, 7].babuSzine = BabuSzine.FEKETE;

            tabla[6, 0] = new Paraszt(0, 6);
            tabla[6, 0].babuNeve = "Paraszt";
            tabla[6, 0].babuSzine = BabuSzine.FEKETE;

            tabla[6, 1] = new Paraszt(1, 6);
            tabla[6, 1].babuNeve = "Paraszt";
            tabla[6, 1].babuSzine = BabuSzine.FEKETE;

            tabla[6, 2] = new Paraszt(2, 6);
            tabla[6, 2].babuNeve = "Paraszt";
            tabla[6, 2].babuSzine = BabuSzine.FEKETE;

            tabla[6, 3] = new Paraszt(3, 6);
            tabla[6, 3].babuNeve = "Paraszt";
            tabla[6, 3].babuSzine = BabuSzine.FEKETE;

            tabla[6, 4] = new Paraszt(4, 6);
            tabla[6, 4].babuNeve = "Paraszt";
            tabla[6, 4].babuSzine = BabuSzine.FEKETE;

            tabla[6, 5] = new Paraszt(5, 6);
            tabla[6, 5].babuNeve = "Paraszt";
            tabla[6, 5].babuSzine = BabuSzine.FEKETE;

            tabla[6, 6] = new Paraszt(6, 6);
            tabla[6, 6].babuNeve = "Paraszt";
            tabla[6, 6].babuSzine = BabuSzine.FEKETE;

            tabla[6, 7] = new Paraszt(7, 6);
            tabla[6, 7].babuNeve = "Paraszt";
            tabla[6, 7].babuSzine = BabuSzine.FEKETE;
        }
    }
}
