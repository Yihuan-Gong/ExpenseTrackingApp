using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 記帳
{
    internal class ChartData<Tx, Ty>
    {
        public List<Tx> x;
        public List<Ty> y;
        public List<string> labels;
        public string seriesName;
    }
}
