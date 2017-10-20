using Microsoft.VisualStudio.TestTools.UnitTesting;
using MFM.GatesBallsNetwork.Implementation;
using MFM.GatesBallsNetwork.Contracts;
using DryIoc;
using System.Collections.Generic;
using System.Text;

namespace MFM.GatesBallsNetwork.Test
{
    [TestClass]
    public class Test_BallRouter
    {
        IContainer _container;
        public Test_BallRouter()
        {
            _container = ContainerConfig.Build();
        }

        [TestMethod]
        public void TestBallRouter_RouteBallToContainer()
        {
            var _networkBuilder = _container.Resolve<INetworkBuilder>();

            var _root = _networkBuilder.BuildNetwork(4);

            var _ballRouter = _container.Resolve<IBallRouter>();
            StringBuilder _results = new StringBuilder();
            for (int i = 0; i < 15; i++)
            {
                _results.Append(_ballRouter.RouteBallToContainer(_root).Result);
            }
            var _networkNavigator = _container.Resolve<INetworkNavigator>();
            var _emptyList = _networkNavigator.GetEmptyBallContainers(_root).Result;
            Assert.IsTrue(_emptyList.Count>0);
            Assert.IsTrue(_results.ToString().IndexOf(_emptyList[0].ToString())==-1); //Empty container does not exist in string of filled containers

            var _networkVisualizer = _container.Resolve<INetworkVisualizer>();
            var _list = _networkVisualizer.GetNetworkDiagram(4, _root).Result;
            Assert.IsTrue(_list.Length > 0);
        }
    }
}
