using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball_dll.Interfaces
{
    public interface ICalculateRanking
    {
        void CalcRanking(int GoalsCount1, int GoalsCount2);
    }
}
