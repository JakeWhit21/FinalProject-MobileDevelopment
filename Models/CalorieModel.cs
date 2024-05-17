using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{

    public class CalorieModel
    {
        public CalorieModel() { }

        public int calories = 0;

        public void addCalories(int caloriesFromView)
        {
            this.calories += caloriesFromView;
        }
    }

   
}
