using DryIoc;
using MFM.GatesBallsNetwork.Contracts;
using MFM.GatesBallsNetwork.Implementation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MFM.GatesBallsNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            var _container = ContainerConfig.Build();

            var _networkBuilder = _container.Resolve<INetworkBuilder>();

            Console.Write("Please enter depth of the systeme (number):");
            string _iDepth = Console.ReadLine();

            int _depth=0;

            //Looping till I get a valid int
            while (!Int32.TryParse(_iDepth, out _depth) || _depth == 0)
            {
                Console.WriteLine("Not a valid number, try again.");
                Console.Write("Please enter depth of the systeme (number):");
                _iDepth = Console.ReadLine();
            }
            
            var _root = _networkBuilder.BuildNetwork(_depth);

            var _ballRouter = _container.Resolve<IBallRouter>();
            for (int i = 0; i < (int)Math.Pow(2, _depth)-1; i++)
            {
                _ballRouter.RouteBallToContainer(_root).Wait();
            }

            var _networkNavigator = _container.Resolve<INetworkNavigator>();
            Task<List<char>> _getEmptyBallContainersTask = Task.Run(() => _networkNavigator.GetEmptyBallContainers(_root));
            _getEmptyBallContainersTask.Wait();
            Console.WriteLine("");
            Console.WriteLine("************** Empty Container: "+ _getEmptyBallContainersTask.Result[0] + " **************");
            Console.WriteLine("");

            var _networkVisualizer = _container.Resolve<INetworkVisualizer>();
            Task<string> _getNetworkDiagramTask = Task.Run(() => _networkVisualizer.GetNetworkDiagram(_depth, _root));
            _getNetworkDiagramTask.Wait();
            var _diagram = _getNetworkDiagramTask.Result;
            Console.WriteLine("************** Visual Diagram **************");
            Console.WriteLine("********************************************");
            Console.Write(_diagram);
            Console.WriteLine("********************************************");

            Console.WriteLine("");
            Console.WriteLine("Press Any Key to exit.");
            Console.ReadLine();
        }
    }
}
