using Microsoft.VisualStudio.TestTools.UnitTesting;
using MFM.GatesBallsNetwork.Implementation;
using MFM.GatesBallsNetwork.Contracts;
using DryIoc;

namespace MFM.GatesBallsNetwork.Test
{
    [TestClass]
    public class NetworkBuilderTest
    {
        [TestMethod]
        public void TestBuildNetwork_Build()
        {
            var _container = ContainerConfig.Build();

            var _networkBuilder = _container.Resolve<INetworkBuilder>();

            var _root = _networkBuilder.BuildNetwork(4);

            Assert.IsTrue(_root != null);
            Assert.IsTrue(_root as IRootIntersection != null);
            Assert.IsTrue(_root.LeftNode as IRootIntersection != null);
            Assert.IsTrue(_root.LeftNode as IIntersection != null);
            Assert.IsTrue(_root.LeftNode as IBallContainer == null);
        }
    }
}
