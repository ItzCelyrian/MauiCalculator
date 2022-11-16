using System.ComponentModel;
using System.Data;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MauiApplication;

public partial class MainPage : ContentPage
{
    string entry;
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

        if ( DisplayEntry.Text is not null )
            zeroCase = zeroOps.Any(x => DisplayEntry.Text.EndsWith(x)) || DisplayEntry.Text == "0";

        if ( (sender as Button).Text == "0" && zeroCase )
            return;

        if ( DisplayEntry.Text is not null && (sender as Button).Text != "0" && DisplayEntry.Text.EndsWith("0") ) 
            DisplayEntry.Text = DisplayEntry.Text.Substring(0, DisplayEntry.Text.Length - 1);
        
        entry += (sender as Button).Text;
        DisplayEntry.Text = entry;
    }
    private void ClickC(object sender, EventArgs e)
    {
        entry = null;
        DisplayEntry.Text = entry;
        DisplayAlert("Cleared", "Cleared the Calculator.", "OK");
    }
    private void ClickE(object sender, EventArgs e)
    {
        entry = Convert.ToString(Evaluate(DisplayEntry.Text)).Replace(",", ".");
        if (entry == null || entry == "NaN")
            entry = "Undefined";
        DisplayEntry.Text = entry;
    }
    private void Add(object sender, EventArgs e)
    {
        if (entry == null || entry.EndsWith("+") || entry.EndsWith("-") || entry.EndsWith("*") || entry.EndsWith("/")) return;
        else entry = entry + "+";
        DisplayEntry.Text = entry;
    }
    private void Sub(object sender, EventArgs e)
    {
        if (entry == null || entry.EndsWith("+") || entry.EndsWith("-") || entry.EndsWith("*") || entry.EndsWith("/")) return;
        else entry = entry + "-";
        DisplayEntry.Text = entry;
    }
    private void Mult(object sender, EventArgs e)
    {
        if (entry == null || entry.EndsWith("+") || entry.EndsWith("-") || entry.EndsWith("*") || entry.EndsWith("/")) return;
        else entry = entry + "*";
        DisplayEntry.Text = entry;
    }
    private void Div(object sender, EventArgs e)
    {
        if (entry == null || entry.EndsWith("+") || entry.EndsWith("-") || entry.EndsWith("*") || entry.EndsWith("/")) return;
        else entry = entry + "/";
        DisplayEntry.Text = entry;
    }

    private void UpdateEntry(object sender, TextChangedEventArgs e)
    {
        entry = DisplayEntry.Text;
    }
}

