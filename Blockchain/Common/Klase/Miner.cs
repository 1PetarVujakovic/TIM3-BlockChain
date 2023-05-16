using Common.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Klase
{
    public class Miner : IMiner
    {
        public Guid Id { get; set; }

        public List<Miner> Miners { get; set; } = new List<Miner>();

        public Block Block { get; set; }
        public BlockChain BlockChain { get; set; }
        public ISmartContract SmartContract { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public double StanjeNaRacunu { get; set; }

        public int indikator { get; set; }

        public Miner() { }
        public Miner(SmartContract smart, string userName, string password, double stanjeNaRacunu)
        {
            Id = Guid.NewGuid();
            UserName = userName;
            Password = password;
            StanjeNaRacunu = stanjeNaRacunu;
            SmartContract = smart;
            Miners = smart.Miners;
            BlockChain = new BlockChain();
        }

        public bool Provera(string hash)
        {
            if (string.Compare(hash.Substring(0, 4), "0.00") == 0)
            {
                return true;
            }
            return false;
        }


        public bool Validiraj(Block block)
        {
            indikator = 0;
            if (ResiZadatak(block))
            {
                indikator = 1;
                ObavestiOstaleMinere(block);
                indikator = 0;
                return true;
            }
            return false;

        }

        public bool ResiZadatak(Block block)
        {
            string hashValue = block.KreirajSHA256();
            byte[] bytes = Encoding.ASCII.GetBytes(hashValue);
            int hashValueNum = BitConverter.ToInt16(bytes, 0);



            while (true)
            {
                block.broj = block.broj - 0.000001;
                double komb = block.broj * hashValueNum;
                string s = komb.ToString();
                if (s.Length >= 3)
                {
                    if (block.broj < 0.00000001)
                    {
                        return false;
                    }

                    if (Provera(komb.ToString()))
                    {
                        if (indikator == 0)
                        {
                            StanjeNaRacunu += 1;
                            Console.WriteLine("Resenje nadjeno za vrednost unesenu od strane: " + UserName);
                        }
                        return true;
                    }


                }
                else
                {
                    return false;
                }

            }

        }

        public bool ObavestiOstaleMinere(Block block)
        {
            if (block == null)
            {
                return false;
            }
            foreach (Miner miner in Miners)
            {
                if (!miner.ResiZadatak(block))
                {

                    return false;
                }
            }

            foreach (Miner miner in Miners)
            {
                miner.BlockChain.DodajUBlockChain(block);
            }

            return true;

        }
    }
}
