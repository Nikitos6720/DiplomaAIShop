using DiplomaAIShop.Controllers;
using DiplomaAIShop.Models;
using DiplomaAIShop.Views.General;

namespace DiplomaAIShop.Controls;

public partial class CheckLineInfo : UserControl
{
    private CheckLine _line;
    private IRemovableList _removableList;

    public CheckLineInfo(IRemovableList removableList, CheckLine line)
    {
        InitializeComponent();

        _removableList = removableList;
        _line = line;

        LoadData();
    }

    private async void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
        using var db = new DatabaseController(new());
        LinePrice.Text = $"{_line.Product?.Price * numericUpDown1.Value}";
        _line.Count = (uint)numericUpDown1.Value;

        db.Lines.Update(_line);
        await db.SaveChangesAsync();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        using var db = new DatabaseController(new());

        var lineInDb = db.Lines.FirstOrDefault(x => x.Id == _line.Id);
        if (lineInDb is not null)
            db.Lines.Remove(lineInDb);

        _removableList.Remove(this);
        db.SaveChanges();
    }

    private void LoadData()
    {
        ProductName.Text = _line.Product?.Name;
        ProductPrice.Text = $"{_line.Product?.Price} ₴";
        CategoryName.Text = _line.Product?.ProductCategory?.Name;
        LinePrice.Text = $"{_line.Price} ₴";
        numericUpDown1.Value = _line.Count;
        numericUpDown1.Maximum = _line.Product?.Count ?? 0;

        if (_line.Check.IsClosed)
        {
            numericUpDown1.Enabled = false;
            button1.Visible = false;
        }
    }
}