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
        public List<User> Users { get; set; }
        public List<Miner> Miners { get; set; }

        //potrebno je napraviti klase Miner i user kako ne bi bacalo greske
        public SmartContract()
        {
            Users = new List<Client>();
            Miners = new List<Miner>();

        }

        public bool NapraviBlock(Podatak podatak)
        {

            if (podatak.vrednost != null)
            {

                Block block = new Block(podatak);
                Random rand = new Random();
                int br = rand.Next(0, Miners.Count);
                Miner miner = Miners[br];
                throw new NotImplementedException();
            }

            return false;
        }
    }
}
