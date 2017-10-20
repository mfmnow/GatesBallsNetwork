using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFM.GatesBallsNetwork.Contracts
{
    public interface IOpenable
    {
        bool IsOpen { get; set; }
    }
}
