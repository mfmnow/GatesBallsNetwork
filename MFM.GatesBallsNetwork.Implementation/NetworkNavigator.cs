using MFM.GatesBallsNetwork.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MFM.GatesBallsNetwork.Implementation
{
    public class NetworkNavigator : INetworkNavigator
    {
        public async Task<List<char>> GetEmptyBallContainers(IRootIntersection rootIntersection)
        {
            List<char> _list = new List<char>();

            return await FindBalls(rootIntersection, _list);
        }

        async Task<List<char>> FindBalls(IRootIntersection intersection,List<char> _list)
        {
            var _gate = intersection.LeftNode as IIntersection;
            if (_gate != null) //Gate Level not Container
            {
                await FindBalls(intersection.LeftNode as IRootIntersection, _list);
                await FindBalls(intersection.RightNode as IRootIntersection, _list);
                return _list;
            }//if
            else //Container Level
            {
                var _left = intersection.LeftNode as IBallContainer;
                if (!_left.IsFull)
                    _list.Add(_left.Id);
                var _right = intersection.RightNode as IBallContainer;
                if (!_right.IsFull)
                    _list.Add(_right.Id);
                return _list;
            }
        }
    }
}
