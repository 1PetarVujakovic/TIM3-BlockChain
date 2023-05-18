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
    public class BlockChainTest
    {
        [Test]
        public void DodajUBlockChain_UspesnoDodato()
        {
            BlockChain bc = new BlockChain();
            Podatak p = new Podatak();
            Block b = new Block(p);


            bc.DodajUBlockChain(b);


            CollectionAssert.IsNotEmpty(bc.Blocks);
        }

        [Test]
        public void DodajUBlockChain_Empty()
        {
            BlockChain bc = new BlockChain();
            Podatak p = new Podatak();
            Block b = new Block(p);



            CollectionAssert.IsEmpty(bc.Blocks);
        }

        [Test]
        public void DodajUBlockChain_NonEmpty()
        {
            BlockChain bc = new BlockChain();
            Podatak p = new Podatak();
            Block b = new Block(p);


            bc.DodajUBlockChain(b);
            bc.DodajUBlockChain(b);


            CollectionAssert.IsNotEmpty(bc.Blocks);
        }


        [Test]
        public void ConstructorTest()
        {
            BlockChain bc = new BlockChain();


            Assert.NotNull(bc.Blocks);

        }


    }
}
