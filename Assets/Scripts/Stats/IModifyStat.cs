using System;
using System.Collections.Generic;

namespace MMORPG.Stats
{
    public interface IModifyStat
    {
        IEnumerable<float> AddStraight(Stat stat);
        IEnumerable<float> AddPercent(Stat stat);
    }

}