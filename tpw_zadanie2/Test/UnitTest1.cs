using Logic;

namespace LogicTest
{
    [TestClass]
    public class LogicApiUT
    {
        [TestMethod]
        public void InstanceTest()
        {
            Api logicApi = Api.Instance();
            Assert.IsNotNull(logicApi);
        }

        [TestMethod]
        public void AddBallTest()
        {
            Api logicApi = Api.Instance();
            Assert.IsNotNull(logicApi);
            logicApi.CreateBalls(1);
            Assert.AreEqual(1, logicApi.GetNumberOfBalls());
            logicApi.CreateBalls(1);
            Assert.AreEqual(2, logicApi.GetNumberOfBalls());
        }

        [TestMethod]
        public void UpdatePositionTest()
        {
            Api logicApi = Api.Instance();
            Assert.IsNotNull(logicApi);
            logicApi.CreateBalls(1);
            float prev_x = logicApi.GetX(0);
            float prev_y = logicApi.GetY(0);
            logicApi.LogicApiEvent += (sender, args) =>
            {
                Assert.AreNotEqual(prev_y, logicApi.GetY(0));
                Assert.AreNotEqual(prev_x, logicApi.GetX(0));
                return;
            };
        }
    }
}