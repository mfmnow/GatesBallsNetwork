using MFM.GatesBallsNetwork.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFM.GatesBallsNetwork.Implementation
{
    /// <summary>
    /// Visualize Network
    /// Still not finalized
    /// </summary>
    public class NetworkVisualizer : INetworkVisualizer
    {
        public async Task<string> GetNetworkDiagram(int depth, IRootIntersection rootIntersection)
        {
            List<NodeVisualInfo> _list = new List<NodeVisualInfo>();
            await GetNodeLines(1, depth, "R", rootIntersection, _list);
            return RearrangeText(depth, _list);
        }

        async Task GetNodeLines(int level, int depth, string type, IRootIntersection intersection, List<NodeVisualInfo> list)
        {
            if (level < depth)//Gates
            {
                list.Add(new NodeVisualInfo(){ Level=level, Text= GetNodeLine(level, depth, type) });
                await GetNodeLines(level + 1, depth, "L", intersection.LeftNode as IRootIntersection, list);
                await GetNodeLines(level + 1, depth, "R", intersection.RightNode as IRootIntersection, list);
            }
            else //Final gate
            {
                list.Add(new NodeVisualInfo() { Level = level, Text = GetNodeLine(level, depth, type) });
                list.Add(new NodeVisualInfo() { Level = level + 1, Text = GetNodeLine(level + 1, depth, (intersection.LeftNode as IBallContainer).Id.ToString()) });
                var _text = (intersection.LeftNode as IBallContainer).IsFull ? "1" : "0";
                list.Add(new NodeVisualInfo() { Level = level + 2, Text = GetNodeLine(level + 1, depth, _text) });
                list.Add(new NodeVisualInfo() { Level = level + 1, Text = GetNodeLine(level + 1, depth, (intersection.RightNode as IBallContainer).Id.ToString()) });
                _text = (intersection.RightNode as IBallContainer).IsFull ? "1" : "0";
                list.Add(new NodeVisualInfo() { Level = level + 2, Text = GetNodeLine(level + 1, depth, _text) });
            }
        }

        string GetNodeLine(int level, int depth, string type)
        {
            return new String('=', (int)Math.Pow(2, depth - (level - 2)) / 2) +
                new String('=', (int)Math.Pow(2, depth - level) / 2) +
                type +
                new String('=', (int)Math.Pow(2, depth - level) / 2) +
                new String('=', (int)Math.Pow(2, depth - (level - 2)) / 2);
        }

        string RearrangeText(int depth, List<NodeVisualInfo> list)
        {
            var _returnString = "";
            for (int i = 1; i < depth+3; i++)
                _returnString += string.Join("", (list.Where(p => p.Level == i).ToArray()).Select(w=>w.Text))+"\r\n";
            return _returnString;
        }
    }

    class NodeVisualInfo
    {
        public int Level { get; set; }
        public string Text { get; set; }
    }    
}
