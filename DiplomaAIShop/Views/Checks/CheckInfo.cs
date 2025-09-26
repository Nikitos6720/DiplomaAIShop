using DiplomaAIShop.Controllers;
using DiplomaAIShop.Controls;
using DiplomaAIShop.Models;
using DiplomaAIShop.Views.General;

using Microsoft.EntityFrameworkCore;

namespace DiplomaAIShop.Views;

public partial class CheckInfo : Form, IRemovableList
{
    private readonly IMainForm _form;
    private Check _check;

    public CheckInfo(IMainForm main, Check check)
    {
        InitializeComponent();
        _form = main;
        _check = check;
        GetData();
    }

    private void button1_Click(object sender, EventArgs e) => _form.CloseForm();

    private async void button3_Click(object sender, EventArgs e)
    {
        using var db = new DatabaseController(new());
        var history = await db.Sales.FirstOrDefaultAsync(x => x.Date.Date == _check.Date.Date);

        if (history is null)
        {
            history = new();
            db.Sales.Add(history);
            await db.SaveChangesAsync();
        }

        _check.IsClosed = true;
        _check.SellsHistoryId = history.Id;

        db.Checks.Update(_check);
        await db.SaveChangesAsync();

        _form.CloseForm();
    }

    public void Remove(Control c)
    {
        flowLayoutPanel1.Controls.Remove(c);
    }

    private void GetData()
    {
        CheckId.Text = $"{_check.Id}";
        CheckDate.Text = $"{_check.Date}";
        Price.Text = $"{_check.Price} ₴";

        foreach (var line in _check.Lines)
        {
            flowLayoutPanel1.Controls.Add(new CheckLineInfo(this, line));
        }

        if (_check.IsClosed)
        {
            button3.Visible = false;
        }
    }
}