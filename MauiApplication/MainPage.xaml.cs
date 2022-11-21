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
        { // try evaluating the string expression as mathmatical equation
            var DataTable = new DataTable();
            var DataColumn = new DataColumn("Eval", typeof(double), expression);

            DataTable.Columns.Add(DataColumn);
            DataTable.Rows.Add(0);
            return (double)(DataTable.Rows[0]["Eval"]); // if we succeed return that value as a double
        }
        catch
        { // if the expression is invalid return 0
            return 0;
        }
    }
    private void Click(object sender, EventArgs e)
    {
        string[] zeroOps = { "+0", "-0", "*0", "/0" };
        bool zeroCase = false;

        if ( Display.Text is not null ) // if we have any input check for leading zero's
            zeroCase = zeroOps.Any(x => Display.Text.EndsWith(x)) || Display.Text is "0";

        if ( (sender as Button).Text is "0" && zeroCase )
            return; // if we are inputting leading zero's return and we are equal to 0 => return

        if ( zeroCase && (sender as Button).Text is not "0" && Display.Text.EndsWith("0") ) 
            Display.Text = Display.Text.Substring(0, Display.Text.Length - 1); // replace a zero with the number we want
        
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
        
        if (entry is null || entry is "NaN") 
            entry = "Undefined"; // don't leave divided by 0 or other invalid processes unhandeled

        bool answer = false;

        if (entry is not "Undefined")
            answer = await DisplayAlert($"Answer: {entry}", "Do you want to save your Answer as the ANS variable?", "Yes", "No");
        
        if (answer)
            ans = entry;

        Display.Text = entry;
    }
    private void Op(object sender, EventArgs e)
    {
        string[] operators = { "+", "-", "*", "/" };
        bool endOperator = true;

        if (Display.Text is not null)
            endOperator = operators.Any(x => Display.Text.EndsWith(x)); // avoid appending operators to each other
                
        if ( endOperator )
            Display.Text = Display.Text.Substring(0, Display.Text.Length - 1); // replace operator with new operator

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