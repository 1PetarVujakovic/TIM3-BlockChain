using Common.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Klase
{
    public class SmartContract : ISmartContract
    {
        public List<Client> Clients { get; set; }
        public List<Miner> Miners { get; set; }

        public SmartContract()
        {
            Clients = new List<Client>();
            Miners = new List<Miner>();
        }

        public bool NapraviBlock(Podatak podatak)
        {
            if (Provera(podatak))
            {
                Block block = new Block(podatak);
                Random rand = new Random();
                int br = rand.Next(0, Miners.Count);
                Miner miner = Miners[br];
                return miner.Validiraj(block);
            }
            return false;
        }

        public bool Provera(Podatak data)
        {
            return data.vrednost != null;
        }
    }
}
