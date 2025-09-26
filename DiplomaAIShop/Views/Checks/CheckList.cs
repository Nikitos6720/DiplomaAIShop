using DiplomaAIShop.Controllers;
using DiplomaAIShop.Controls;
using DiplomaAIShop.Views.General;

using Microsoft.EntityFrameworkCore;

namespace DiplomaAIShop.Views;

public partial class CheckList : Form, IListForm
{
    private readonly IMainForm _form;
    public CheckList(IMainForm form)
    {
        InitializeComponent();
        _form = form;
    }

    private void button1_Click(object sender, EventArgs e) => _form.CloseForm();

    public void LoadsData() => LoadChecks();

    private async void LoadChecks()
    {
        using var db = new DatabaseController(new());

        ActiveCheck.Controls.Clear();
        flowLayoutPanel1.Controls.Clear();

        var list = await db.Checks.Include(x => x.Lines).ThenInclude(x => x.Product).ThenInclude(x => x.ProductCategory).ToListAsync();

        var openCheck = list.FirstOrDefault(x => !x.IsClosed);
        if (openCheck is not null)
        {
            var openCheckObject = new CheckObject(_form, openCheck);
            ActiveCheck.Controls.Add(openCheckObject);
        }

        foreach (var check in list.Where(x => x.IsClosed))
        {
            var checkObject = new CheckObject(_form, check);
            flowLayoutPanel1.Controls.Add(checkObject);
        }
    }
}