using DryIoc;
using MFM.GatesBallsNetwork.Contracts;

namespace MFM.GatesBallsNetwork.Implementation
{
    public class ContainerConfig
    {
        public static Container Build()
        {
            var _container = new Container();
            _container.Register<IRootIntersection, RootIntersection>();
            _container.Register<IIntersection, Intersection>();
            _container.Register<IBallContainer, BallContainer>();
            _container.Register<INetworkBuilder, NetworkBuilder>();
            _container.Register<IBallRouter, BallRouter>();
            _container.Register<INetworkNavigator, NetworkNavigator>();
            _container.Register<INetworkVisualizer, NetworkVisualizer>();
            _container.UseInstance<IContainer>(_container);
            return _container;
        }
    }
}
