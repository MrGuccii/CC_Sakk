using System;

namespace Sakk.Babuk
{
    public class Babu : Mezo
    {
        public Babu(int sor, int oszlop) : base(sor, oszlop)
        {

        }

        public virtual void LepesBeallitas(Mezo babuHelyzete, Tabla tabla)
        {
            if (babuHelyzete.babuTipus is Paraszt)
            {
                new Paraszt(sor, oszlop).LepesBeallitas(babuHelyzete, tabla);
            }
            else if (babuHelyzete.babuTipus is Bastya)
            {
                new Bastya(sor, oszlop).LepesBeallitas(babuHelyzete, tabla);
            }
            new Paraszt(sor, oszlop).LepesBeallitas(babuHelyzete, tabla);
        }
    }
}
