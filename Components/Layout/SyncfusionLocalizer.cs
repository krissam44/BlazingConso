using Syncfusion.Blazor;

namespace BlazingConso.Components.Layout;

public class SyncfusionLocalizer : ISyncfusionStringLocalizer
{
    public string GetText(string key)
    {
        return this.ResourceManager.GetString(key);
    }

    public System.Resources.ResourceManager ResourceManager
    {
        get
        {
            return XCel4Akeneo.Resources.SfResources.ResourceManager;
        }
    }
}
