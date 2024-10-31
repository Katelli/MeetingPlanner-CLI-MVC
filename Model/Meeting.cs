public class Meeting
{
    public string Title { get; set; }
    public string Organizer { get; set; }
    // TODO: Figure out if this gives DD/MM/YYYY, MM/DD/YYYY, YYYY/MM/DD or YYYY/DD/MM
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public string[] Participants { get; set; }


    public Meeting(string title, string organizer, DateOnly date, TimeOnly time, string[] participants)
    {
        Title = title;
        Organizer = organizer;
        Date = date;
        Time = time;
        Participants = participants;
    }

    public override string ToString()
    {
        return $"Meeting: {Title}\nOrganized by: {Organizer}\nDate: {Date}\tTime: {Time}\nParticipants: {Participants}";
    }
}
public class Model
{
    public List<Meeting> Meetings {get; set;}
    public Model()
    {
        Meetings = new List<Meeting>
        {
            new Meeting("Social Committee", "Donna", DateOnly.Parse("12.12.2025"), TimeOnly.Parse("14:00"), ["Joe", "Marie, Jane"]),
            new Meeting("Executive Meeting", "Frank", DateOnly.Parse("14.05.2025"), TimeOnly.Parse("10:30"), ["Lily", "Melody"]),
        };
    }

    public void CreateMeeting(string title, string organizer, DateOnly date, TimeOnly time, string[] participants)
    {
        Meetings.Add(new Meeting(title, organizer, date, time, participants));
    }

    public List<Meeting> GetMeetings()
    {
        return Meetings;
    }
}