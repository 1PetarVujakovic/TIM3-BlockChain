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
    public class MinerTest
    {
        [Test]
        public void ResiZadatak_ReturnsFalse()
        {

            //Arrange
            Podatak p = new Podatak();
            p.vrednost = "test";
            p.vreme = DateTime.Now;
            Block b = new Block(p);
            b.Datum = DateTime.Now;
            b.Id = Guid.NewGuid();
            b.broj = 0.000000001;
            b.Vrednost = p;

            Miner m = new Miner();

            //Act

            bool res = m.ResiZadatak(b);

            //Assert
            Assert.False(res);

        }

        [Test]
        public void ResiZadatak_ReturnsFalseEdge()
        {

            //Arrange
            Podatak p = new Podatak();
            p.vrednost = "test";
            p.vreme = DateTime.Now;
            Block b = new Block(p);
            b.Datum = DateTime.Now;
            b.Id = Guid.NewGuid();
            b.broj = 0.00000001;
            b.Vrednost = p;

            Miner m = new Miner();

            //Act

            bool res = m.ResiZadatak(b);

            //Assert
            Assert.False(res);

        }

        [Test]
        public void Provera_ReturnsTrue()
        {
            //Arrange
            Miner m = new Miner();
            string s = "0.00000";


            //Act
            bool res = m.Provera(s);


            //Assert

            Assert.True(res);
        }

        [Test]
        public void Provera_ReturnsFalse()
        {
            //Arrange
            Miner m = new Miner();
            string s = "111111";


            //Act
            bool res = m.Provera(s);


            //Assert

            Assert.False(res);
        }

        [Test]
        public void ObavestiOstaleMinere_ReturnsFalse()
        {
            //Arrange
            Miner m = new Miner();
            Podatak p = new Podatak();
            p.vreme = null;
            p.vrednost = null;
            Block b = null;

            //Act
            bool res = m.ObavestiOstaleMinere(b);

            Assert.False(res);
        }

        [Test]
        public void ObavestiOstaleMinere_ReturnsTrue()
        {
            Miner m = new Miner();
            Podatak p = new Podatak();
            p.vreme = DateTime.Now;
            p.vrednost = "test";


            Block b = new Block(p);
            bool res = m.ObavestiOstaleMinere(b);

            Assert.True(res);
        }

        [Test]
        public void Validiraj_ReturnFalse()
        {

            //Arrange
            Miner m = new Miner();
            Podatak p = new Podatak();
            p.vreme = DateTime.Now;
            p.vrednost = null;

            Block b = new Block(p);


            //Act
            bool resutl = m.Validiraj(b);


            //Asset
            Assert.False(resutl);
        }



        [Test]
        public void ConstructorTest()
        {

            //Arrange
            Podatak p = new Podatak();
            p.vreme = DateTime.Now;
            p.vrednost = null;
            SmartContract sm = new SmartContract();

            string username = "test";
            string password = "test";
            double stanje = 1;

            //Act
            Miner m = new Miner(sm, username, password, stanje);


            //Asset
            Assert.NotNull(m.SmartContract);
            Assert.AreEqual(username, m.UserName);
            Assert.AreEqual(password, m.Password);
            Assert.AreEqual(stanje, m.StanjeNaRacunu);
        }
    }
}
