public class Alert : IAlert
{
    public string message { get; set; }
    public Alerts alert { get; set; }

    public Alert() { }
    public Alert(string message, Alerts alert)
    {
        this.message = message;
        this.alert = alert;
    }

}
