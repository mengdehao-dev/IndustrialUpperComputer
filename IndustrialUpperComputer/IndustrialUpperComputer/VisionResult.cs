using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialUpperComputer
{
    public class VisionResult
    {
        public string SN { get; set; }          //产品编号
        public double Row {  get; set; }        //产品位置
        public double Column { get; set; }
        public double Angel { get; set; }       //产品角度
        public double Score {  get; set; }      //产品得分
        public bool IsOK {  get; set; }         //是否通过
        public DateTime Time {  get; set; }     //经过时间
    }
}
