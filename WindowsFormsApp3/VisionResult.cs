using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class VisionResult
    {
        public string SN { get; set; }
        public double Row { get; set; }
        public double Column { get; set; }
        public double Angle { get; set; }
        public double Score { get; set; }
        public bool IsOk { get; set; }
        public DateTime Time { get; set; }
    }
}
