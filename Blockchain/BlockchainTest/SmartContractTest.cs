using Common.Klase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainTest
{
    [TestFixture]
    public class SmartContractTest
    {
        [Test]
        public void KreirajBlok_ReturnsTrue()
        {
            SmartContract sc = new SmartContract();
            Podatak p = new Podatak();
            p.vrednost = "test";
            p.vreme = DateTime.Now;

            Miner m = new Miner();
            sc.Miners.Add(m);

            bool result = sc.NapraviBlock(p);

            Assert.False(result);
        }

        [Test]
        public void KreirajBlok_ReturnFalse()
        {
            SmartContract sc = new SmartContract();
            Podatak p = new Podatak();
            p.vrednost = null;

            Miner m = new Miner();
            sc.Miners.Add(m);

            bool result = sc.NapraviBlock(p);

            Assert.False(result);
        }

        [Test]
        public void Provera_VrednostNull_ReturnsFalse()
        {
            SmartContract sc = new SmartContract();
            Podatak p = new Podatak();
            p.vrednost = null;
           
            bool result = sc.Provera(p);

            Assert.False(result);
        }

        [Test]
        public void Provera_VrednostNotNull_ReturnsTrue()
        {
            SmartContract sc = new SmartContract();
            Podatak p = new Podatak();
            p.vrednost = "test";

            bool result = sc.Provera(p);

            Assert.True(result);
        }

        [Test]
        public void ConstructorTest()
        {
            SmartContract sc = new SmartContract();

            Assert.NotNull(sc.Clients);
            Assert.NotNull(sc.Miners);
        }
    }
}
