using System.ComponentModel;
using System.Data;
using System.Linq;

namespace MauiApplication;

public partial class MainPage : ContentPage
{
    string entry;
    static double Evaluate(string expression)
    {
        var DataTable = new DataTable();
        var DataColumn = new DataColumn("Eval", typeof(double), expression);
        DataTable.Columns.Add(DataColumn);
        DataTable.Rows.Add(0);
        return (double)(DataTable.Rows[0]["Eval"]);
    }
    public MainPage()
    {
        InitializeComponent();
    }
    private void Click0(object sender, EventArgs e)
    {
        entry += "0";
        DisplayEntry.Text = entry;
    }
    private void Click1(object sender, EventArgs e)
    {
        entry += "1";
        DisplayEntry.Text = entry;
    }
    private void Click2(object sender, EventArgs e)
    {
        entry += "2";
        DisplayEntry.Text = entry;
    }
    private void Click3(object sender, EventArgs e)
    {
        entry += "3";
        DisplayEntry.Text = entry;
    }
    private void Click4(object sender, EventArgs e)
    {
        entry += "4";
        DisplayEntry.Text = entry;
    }
    private void Click5(object sender, EventArgs e)
    {
        entry += "5";
        DisplayEntry.Text = entry;
    }
    private void Click6(object sender, EventArgs e)
    {
        entry += "6";
        DisplayEntry.Text = entry;
    }
    private void Click7(object sender, EventArgs e)
    {
        entry += "7";
        DisplayEntry.Text = entry;
    }
    private void Click8(object sender, EventArgs e)
    {
        entry += "8";
        DisplayEntry.Text = entry;
    }
    private void Click9(object sender, EventArgs e)
    {
        entry += "9";
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

