using FinalProject.Models;
namespace FinalProject
{
    public partial class AppShell : Shell
    {
        public static CalorieModel calorieModel = new CalorieModel();
        public static WaterModel waterModel = new WaterModel();

        public AppShell()
        {
            InitializeComponent();
        }
    }
}
