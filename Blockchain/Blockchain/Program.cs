using Common.Klase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain
{
    internal class Program
    {

        static void Main(string[] args)
        {
            SmartContract smartContract = new SmartContract();
        
            int rudari_count = 5;

            //kreiranje klijenata
            for (int i = 0; i < rudari_count; i++)
            {
                Client c = new Client(smartContract);
                smartContract.Clients.Add(c);
            }

            //kreiranje rudara
            for (int i = 0; i < rudari_count; i++)
            {
                Console.WriteLine(i + 1 + ".");
                Console.WriteLine("Unesite username: ");
                string userName = Console.ReadLine();

                Console.WriteLine("Unesite password: ");
                string password = Console.ReadLine();

                Miner m = new Miner(smartContract, userName, password, 0);
                smartContract.Miners.Add(m);
            }


            //resavanje zadataka
            int brojac = 0;

            while (brojac<=1000) {
                    Random rand = new Random();
                    int ind = rand.Next(0, smartContract.Clients.Count);
                    Client c = smartContract.Clients[ind];
                    c.PosaljiPodatak();
                brojac++;
            }

            //ispis stanja racuna
            Console.WriteLine();
            for (int i = 0; i < smartContract.Miners.Count; i++)
            {
                Console.WriteLine("UserName: " + smartContract.Miners[i].UserName);
                Console.WriteLine("Stanje na racunu: " + smartContract.Miners[i].StanjeNaRacunu);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
