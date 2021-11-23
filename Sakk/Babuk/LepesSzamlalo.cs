using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakk.Babuk
{
    public class LepesSzamlalo : Mezo
    {
        public LepesSzamlalo(int sor, int oszlop) : base(sor, oszlop)
        {
            nemLepettMeg = true;
        }

        public bool nemLepettMeg { get; private set; }
        public override void Lepes(int sor, int oszlop)
        {
            nemLepettMeg = false;
            base.Lepes(sor, oszlop);
        }
    }
}
