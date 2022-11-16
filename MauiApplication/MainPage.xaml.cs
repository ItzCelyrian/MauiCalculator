using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MauiApplication;

public partial class MainPage : ContentPage
{
    string entry;
    string ans;
    public MainPage()
    {
        InitializeComponent();
    }
    private static double Evaluate(string expression)
    {
        try
        {
            var DataTable = new DataTable();
            var DataColumn = new DataColumn("Eval", typeof(double), expression);

            DataTable.Columns.Add(DataColumn);
            DataTable.Rows.Add(0);
            return (double)(DataTable.Rows[0]["Eval"]);
        }
        catch
        { 
            return 0;
        }
    }
    private void Click(object sender, EventArgs e)
    {
        string[] zeroOps = { "+0", "-0", "*0", "/0" };
        bool zeroCase = false;

        if ( Display.Text is not null )
            zeroCase = zeroOps.Any(x => Display.Text.EndsWith(x)) || Display.Text is "0";

        if ( (sender as Button).Text is "0" && zeroCase )
            return;

        if ( zeroCase && (sender as Button).Text is not "0" && Display.Text.EndsWith("0") ) 
            Display.Text = Display.Text.Substring(0, Display.Text.Length - 1);
        
        entry += (sender as Button).Text;
        Display.Text = entry;
    }
    private void Clear(object sender, EventArgs e)
    {
        entry = null;
        Display.Text = entry;
        DisplayAlert("Success", "The Calculator has been cleared.", "OK");
    }
    private async void Equals(object sender, EventArgs e)
    {
        entry = Convert.ToString(Evaluate(Display.Text.Replace("Ans", ans))).Replace(",", ".");
        
        if (entry is "NaN") 
            entry = "Undefined";

        bool answer = await DisplayAlert($"Answer: {entry}", "Do you want to save your Answer as the ANS variable?", "Yes", "No");
        if (answer)
            ans = entry;
    }
    private void Op(object sender, EventArgs e)
    {
        string[] operators = { "+", "-", "*", "/" };
        bool endOperator = true;

        if (Display.Text is not null)
            endOperator = operators.Any(x => Display.Text.EndsWith(x));
                
        if ( endOperator )
            Display.Text = Display.Text.Substring(0, Display.Text.Length - 1);

        entry += (sender as Button).Text;
        Display.Text = entry;
    }
    private void Update(object sender, TextChangedEventArgs e)
    {
        entry = Display.Text;
    }

    private void Backspace(object sender, EventArgs e)
    {
        if (Display.Text.Length > 0)
            Display.Text = Display.Text.Substring(0, Display.Text.Length - 1);
        else
            DisplayAlert("Error", "The Entry is already empty.", "OK");
    }
}