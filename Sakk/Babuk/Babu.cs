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
            throw new NotImplementedException();
        }
    }
}
