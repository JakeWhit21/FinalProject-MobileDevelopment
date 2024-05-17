namespace FinalProject.Views;

public partial class WaterIntakeView : ContentPage
{
	public WaterIntakeView()
	{
		InitializeComponent();
	}

    private void SetWaterGoal(object sender, EventArgs e)
    {
        int WaterGoal = Convert.ToInt32(_WaterGoalInput.Text);
        OutputWaterGoal.Text = $"{WaterGoal} Oz.";

    }

    private void SetWaterDrank(object sender, EventArgs e)
    {
        int waterDrankConvertedToInt = int.Parse(_WaterDrankInput.Text);
        AppShell.waterModel.addWater(waterDrankConvertedToInt);
        string waterDrankFromModel = AppShell.waterModel.waterDrank.ToString();
        OutputWaterDrank.Text = $"{waterDrankFromModel} Oz.";

        string WaterGoalOutputString = OutputWaterGoal.Text;

        string WaterGoalOutputNumberPart = WaterGoalOutputString.Replace(" Oz.", "");

        int WaterGoalOutput = int.Parse(WaterGoalOutputNumberPart);

        if (AppShell.waterModel.waterDrank > 0)
        {
            if (WaterGoalOutput <= AppShell.waterModel.waterDrank)
            {
                WaterGoalCompleted.Text = "You have met your water goal!";
            }
        }

       
    }
}