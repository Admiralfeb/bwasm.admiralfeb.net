using System;
using System.Collections.Generic;

public class AlertService
{
    public List<IAlert> messages { get; private set; }
    public event Action RefreshRequested;

    public AlertService()
    {
        this.messages = new List<IAlert>();
    }

    public void addMessage(Alert alert)
    {
        this.messages.Add(alert);
        System.Console.WriteLine($"Message count: {this.messages.Count}");
        RefreshRequested?.Invoke();

        // pop message off after delay
        new System.Threading.Timer((_) =>
        {
            this.messages.RemoveAt(0);
            RefreshRequested?.Invoke();
        }, null, 8000, System.Threading.Timeout.Infinite);
    }
}
