using Common.Klase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfejsi
{
    public interface ISmartContract
    {
        bool NapraviBlock(Podatak data);

        bool Provera(Podatak data);
    }
}
