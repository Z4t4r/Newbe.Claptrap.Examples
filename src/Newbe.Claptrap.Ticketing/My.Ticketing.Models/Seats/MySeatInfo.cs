using Newbe.Claptrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Ticketing.Models.Seats
{
    public class MySeatInfo : IStateData
    {
        /// <summary>
        /// station ids.
        /// </summary>
        public IReadOnlyList<int> Stations { get; set; }

        /// <summary>
        ///  station ids dictionary.
        /// {key:stationId, value:index of <see cref="Stations"/>}
        /// Stations的索引反向字典
        /// </summary>
        public IDictionary<int, int> StationDic { get; set; }

        /// <summary>
        /// request ids.
        /// data in index 0 means that journey interval from station 0 to station 1 is taken by which request id. it is string.Empty if no one take it.
        /// </summary>
        public IList<string> RequestIds { get; set; }

        public static MySeatInfo Create(IReadOnlyList<int> stations)
        {
            var re = new MySeatInfo
            {
                Stations = stations,
                StationDic = stations
                    .Select((station, index) => (station, index))
                    .ToDictionary(x => x.station, x => x.index),
                RequestIds = stations.Take(stations.Count - 1)
                    .Select((x, i) => string.Empty)
                    .ToList()
            };
            return re;
        }
    }
}
