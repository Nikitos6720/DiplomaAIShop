namespace DiplomaAIShop.Models;

public abstract class Removable : IRemovable
{
    public void RemoveItem()
    {
        var remove = GetType().GetMethod("Remove") ?? throw new MissingMethodException($"The method 'Remove' was not found in the class '{GetType().Name}'.");
        remove.Invoke(this, Array.Empty<object>());
    }
}