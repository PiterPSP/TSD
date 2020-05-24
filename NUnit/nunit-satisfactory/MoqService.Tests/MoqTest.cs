using NUnit.Framework;
using Moq;
using Moq.Protected;

namespace MoqService
{
    [TestFixture]
    public class MoqTest
    {

        [Test]
        public void MoqTestInterface()
        {
            var mock = new Mock<IParameters>();
            var robot = new Robot(mock.Object);
            mock.SetupGet(r => r.name).Returns("zucc");
            mock.SetupSequence(r => r.health).Returns(100).Returns(70);

            // You can't make any changes below this line.
            // -----------------------------------------------

            Assert.AreEqual("zucc", robot.Name());
            Assert.AreEqual(100, robot.Health());
            // meanwhile takes a bullet (-30 hp)
            Assert.AreEqual(70, robot.Health());
        }

        [Test]
        public void MoqTestProtected()
        {
            var mockObject = new Mock<RandomDamage>();
            var robot = new Robot(mockObject.Object);
            mockObject.Protected().Setup<int>("damageRand").Returns(7);

            // You can't make any changes below this line.
            // -----------------------------------------------

            Assert.AreEqual(7, robot.Damage());
        }
    }
}