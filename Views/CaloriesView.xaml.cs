namespace FinalProject.Views;

public partial class CaloriesView : ContentPage
{

    public CaloriesView()
	{
		InitializeComponent();
        
    }

	private void SetCalorieGoal(object sender, EventArgs e)
        {
		int CalorieGoal = Convert.ToInt32(_CalorieGoalInput.Text);
		OutputCalorieGoal.Text = $" {CalorieGoal}";
		}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        if (AppShell.calorieModel.calories == 0)
        {
            CalorieOutput.Text = "(Enter food to the food table to update consumed calories)";
        }
        else
        {
            CalorieOutput.Text = AppShell.calorieModel.calories.ToString();
        }

        int CalorieGoalOutput = Convert.ToInt32(OutputCalorieGoal.Text);

        if(AppShell.calorieModel.calories > 0)
        {
            if (CalorieGoalOutput <= AppShell.calorieModel.calories)
                    {
                        CalorieGoalCompleted.Text = "You have met your calorie goal!";
                    }
        }
    }


}