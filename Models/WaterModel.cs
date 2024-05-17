using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class WaterModel
    {
        public WaterModel() { }

        public int waterDrank = 0;

        public void addWater(int waterFromView)
        {
            this.waterDrank += waterFromView;
        }
    }
}
