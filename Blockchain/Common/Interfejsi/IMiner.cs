using Common.Klase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfejsi
{
    public interface IMiner
    {
        
        bool ResiZadatak(Block block);
        bool Validiraj(Block block);
        bool Provera(string hash);
        bool ObavestiOstaleMinere(Block block);
    }
}
