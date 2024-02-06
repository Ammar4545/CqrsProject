using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsProject.Entities.Dbset
{
    public class Achievement : BaseEntity
    {
        public int RaceWin { get; set; }
        public int PolePostion { get; set; }
        public int FastestLap { get; set; }
        public int WorldChampionship { get; set; }
        public Guid DriverId { get; set; }
        public virtual Driver? Driver { get;set; }
    }
}
