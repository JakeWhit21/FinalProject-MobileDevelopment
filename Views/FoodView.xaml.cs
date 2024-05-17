using Microsoft.Maui;
using System.Collections.ObjectModel;
using System.Windows;

namespace FinalProject.Views;

public partial class FoodView : ContentPage
{

    private int rowCount = 1; // Track the number of rows added (starting from 1)
    public FoodView()
	{
		InitializeComponent();
    }

    private void AddRow_Clicked(object sender, EventArgs e)
    {
        // Create Editor controls for the new row
        Editor editor1 = new Editor();
        Editor editor2 = new Editor();
        Editor editor3 = new Editor();

        // Set Grid.Row and Grid.Column attached properties
        gridLayout.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // Add new row definition

        // Set Grid.Row and Grid.Column attached properties for Editors
        Grid.SetRow(editor1, rowCount);
        Grid.SetColumn(editor1, 0);

        Grid.SetRow(editor2, rowCount);
        Grid.SetColumn(editor2, 1);

        Grid.SetRow(editor3, rowCount);
        Grid.SetColumn(editor3, 2);

        // Add Editors to the grid layout
        gridLayout.Children.Add(editor1);
        gridLayout.Children.Add(editor2);
        gridLayout.Children.Add(editor3);

        addRowButton.IsEnabled = false;

        // Enable the Save button
        saveButton.IsEnabled = true;

        // Increment row count for the next row
        rowCount++;
    }

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        // Get the Editors from the last row (current row being edited)
        Editor editor1 = null;
        Editor editor2 = null;
        Editor editor3 = null;

        foreach (View child in gridLayout.Children)
        {
            int row = Grid.GetRow(child);
            int column = Grid.GetColumn(child);

            if (row == rowCount - 1) // Check if the child is in the last row
            {
                if (column == 0)
                    editor1 = child as Editor;
                else if (column == 1)
                    editor2 = child as Editor;
                else if (column == 2)
                    editor3 = child as Editor;
            }
        }

        if (editor1 != null && editor2 != null && editor3 != null)
        {
            // Get the entered text from each Editor
            string text1 = editor1.Text;
            string text2 = editor2.Text;
            string text3 = editor3.Text;

            // Create Labels with the entered text
            Label label1 = new Label { Text = text1 };
            Label label2 = new Label { Text = text2 };
            Label label3 = new Label { Text = text3 };

            // Set Grid.Row and Grid.Column attached properties for Labels
            Grid.SetRow(label1, rowCount - 1); // Use rowCount - 1 because it's the previous row
            Grid.SetColumn(label1, 0);

            Grid.SetRow(label2, rowCount - 1);
            Grid.SetColumn(label2, 1);

            Grid.SetRow(label3, rowCount - 1);
            Grid.SetColumn(label3, 2);

            // Add Labels to the grid layout
            gridLayout.Children.Add(label1);
            gridLayout.Children.Add(label2);
            gridLayout.Children.Add(label3);

            // Remove Editors from the grid layout
            gridLayout.Children.Remove(editor1);
            gridLayout.Children.Remove(editor2);
            gridLayout.Children.Remove(editor3);

            addRowButton.IsEnabled = true;

            int convertedCaloriesToInt = int.Parse(text2);

            AppShell.calorieModel.addCalories(convertedCaloriesToInt);

            // Disable the Save button
            saveButton.IsEnabled = false;
        }
    }
    }