public class View
{
    public void Display(List<Meeting> Meetings)
    {
        foreach (var Meeting in Meetings)
        {
            Console.WriteLine(Meeting.ToString());
        }
    }

    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
}