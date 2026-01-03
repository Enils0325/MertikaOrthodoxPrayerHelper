namespace OrthodoxPrayerBlazorSite2.Workers;

public class NilsEventService
{
    public event Func<Task> OnRandomClicked = null!;

    public void NotifyRandomClicked() => OnRandomClicked?.Invoke();
}
