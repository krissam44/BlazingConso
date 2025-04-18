namespace BlazingConso.Helpers;

public class MoisState
{
    public event Action? OnChange;

    private DateTime _moisSelectionne = DateTime.Today;
    public DateTime MoisSelectionne
    {
        get => _moisSelectionne;
        set
        {
            if (_moisSelectionne != value)
            {
                _moisSelectionne = value;
                NotifyStateChanged();
            }
        }
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
