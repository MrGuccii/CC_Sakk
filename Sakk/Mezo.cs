using System;
using System.Windows.Forms;

namespace Sakk.Babuk
{
    public class Mezo
    {
        public bool lepesek { get; set; }
        public bool foglalt { get{
				if (babuNeve==null)
				{
                    return false;
				}
				return babuNeve.Length>0;
            }
        }
        public int oszlop { get; private set; }
        public int sor { get; private set; }
        public string babuNeve { get; set; }
		public BabuSzine babuSzine { get; set; }
        public bool babuFekete { get => babuSzine == BabuSzine.FEKETE && !IsType(typeof(Mezo)); }
        public bool babuFeher { get => babuSzine == BabuSzine.FEHER && !IsType(typeof(Mezo)); }
        //public bool nemLepettMeg { get => lepesekSzama == 0; }
        public Button gomb { get; set; }
		//public int lepesekSzama { get; set; }
        public bool changed { get; private set; }
        public Babu babuTipus { get; set; }
        public Tabla tabla { get; set; }

        public Mezo(int sor, int oszlop)
        {
            this.sor = sor;
            this.oszlop = oszlop;
            gomb = new Button();
            //lepesekSzama = 0;
            changed = true;
        }

        virtual public void Lepes(int sor, int oszlop)
        {
            this.oszlop = oszlop;
            this.sor = sor;
        }

        public bool IsType(Type type)
        {
            return GetType() == type;
        }

        public void clearChanged() => changed = false;

        public void setChanged() => changed = true;
    }
}
