using DiplomaAIShop.Mockups;

namespace DiplomaAIShop.Extenshions;

internal static class ButtonExtensions
{
    private static ButtonScheme _scheme = new();

    public static void SetButtonActive(this Button button) =>
        ChangeActiveButton(true, button);

    public static void SetButtonDeactive(this Button button) =>
        ChangeActiveButton(false, button);

    public static void ChangeButtonMouseEnter(this Button button) =>
        ChangeColor(button, _scheme.BackActiveColor, _scheme.ForeActiveColor);

    public static void ChangeButtonMouseLeave(this Button button) =>
        ChangeColor(button, _scheme.BackDeactiveColor, _scheme.ForeDeactiveColor);

    private static void ChangeActiveButton(bool isActive, Button button)
    {
        if (isActive)
        {
            ChangeColor(button, _scheme.BackActiveColor, _scheme.ForeActiveColor);
            button.Tag = "Active";
        }

        else
        {
            ChangeColor(button, _scheme.BackDeactiveColor, _scheme.ForeDeactiveColor);
            button.Tag = string.Empty;
        }
    }

    private static void ChangeColor(Button button, Color backColor, Color foreColor)
    {
        button.BackColor = backColor;
        button.ForeColor = foreColor;
    }
}