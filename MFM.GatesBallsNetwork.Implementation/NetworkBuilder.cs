using MFM.GatesBallsNetwork.Contracts;
using DryIoc;
using System;

namespace MFM.GatesBallsNetwork.Implementation
{
    public class NetworkBuilder : INetworkBuilder
    {
        private readonly IRootIntersection _rootIntersection;
        private readonly IContainer _container;
        private readonly Random _random;

        public NetworkBuilder(IRootIntersection rootIntersection, IContainer container)
        {
            _rootIntersection = rootIntersection;
            _container = container;
            _random = new Random();
        }

        public IRootIntersection BuildNetwork(int depth)
        {
            int _id = 65; //First Container will always be called A (Ascii code)
            BuildIntersection(1, depth, intersection: _rootIntersection,id: ref _id); //1 refers to Root Intersection
            return _rootIntersection;
        }

        void BuildIntersection(int level, int depth, IRootIntersection intersection, ref int id)
        {
            if (level < depth)//Create Gates
            {
                intersection.LeftNode = _container.Resolve<IIntersection>();
                intersection.RightNode = _container.Resolve<IIntersection>();
                BuildIntersection(level + 1, depth, (IRootIntersection)intersection.LeftNode, ref id);
                BuildIntersection(level + 1, depth, (IRootIntersection)intersection.RightNode, ref id);
            }
            else //Create Ball Containers
            {
                //Both are not full at the moment
                intersection.LeftNode = CreateBallContainer(ref id);
                intersection.RightNode = CreateBallContainer(ref id);
            }
            if (_random.NextDouble() > 0.5) //Random Open/Close of Gates
                ((IOpenable)intersection.RightNode).IsOpen = true;
            else
                ((IOpenable)intersection.LeftNode).IsOpen = true;
        }

        IBallContainer CreateBallContainer(ref int id)
        {
            var _icontainer = _container.Resolve<IBallContainer>();
            _icontainer.Id = (char)id++;
            return _icontainer;
        }
    }
}
