using Common.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Klase
{
    public struct Podatak
    {
        public string vrednost;
        public DateTime? vreme;
    }

    public class Client : IClient
    {
        public Guid Id { get; set; }

        public ISmartContract SmartContract { get; set; }

        public int Vrednost { get; set; }

        public Client(ISmartContract smart)
        {
            SmartContract = smart;
        }

        public bool PosaljiPodatak()
        {

            Podatak data;
            /*Random rand = new Random();
            int d = rand.Next();*/
            data.vrednost = Vrednost.ToString();
            data.vreme = DateTime.Now;
            return SmartContract.NapraviBlock(data);
        }


    }
}
