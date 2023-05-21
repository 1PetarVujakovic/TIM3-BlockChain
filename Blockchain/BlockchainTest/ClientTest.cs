using Common.Klase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Common.Interfejsi;

namespace BlockchainTest
{
    [TestFixture]
    public class ClientTest
    {

        [Test]
        public void SendData_ReturnsTrue()
        {
            var mock = new Mock<ISmartContract>();
            mock.Setup(x => x.NapraviBlock(It.IsAny<Podatak>())).Returns(true);
            Client c = new Client(mock.Object);

            bool result = c.PosaljiPodatak();

            Assert.True(result);


        }

        [Test]
        public void SendData_ReturnsFalse()
        {

            var mock = new Mock<ISmartContract>();
            mock.Setup(x => x.NapraviBlock(It.IsAny<Podatak>())).Returns(false);
            Client c = new Client(mock.Object);
          
            bool result = c.PosaljiPodatak();

            Assert.False(result);

        }

        [Test]
        public void ConstructorTest()
        {

            SmartContract sm = new SmartContract();
            Client c = new Client(sm);

            Assert.NotNull(c.SmartContract);

        }
    }
}
