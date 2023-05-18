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
    public class BlockTest
    {

        [Test]
        public void CreateHash_ReturnsHash()
        {
            Podatak p = new Podatak();
            p.vrednost = "test";
            p.vreme = DateTime.Now;
            Block b1 = new Block(p);

            b1.Id = Guid.NewGuid();
            b1.broj = 1;

            Block b2 = new Block(p);
            b2.Id = b1.Id;
            b2.broj = b1.broj;


            string hash1 = b1.KreirajSHA256();
            string hash2 = b2.KreirajSHA256();


            Assert.AreEqual(hash1, hash2);
        }

        [Test]
        public void ConstructorTest()
        {
            Podatak p = new Podatak();
            p.vrednost = "test";
            p.vreme = DateTime.Now;


            Block b1 = new Block(p);


            Assert.AreEqual(p.vrednost, b1.Vrednost.vrednost);
            Assert.AreEqual(p.vreme, b1.Vrednost.vreme);


        }



    }
}
