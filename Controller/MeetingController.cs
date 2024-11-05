using System.Reflection;

public class Controller
{
    MeetingList controllerMeetingList;
    View controllerView;

    public Controller(MeetingList model, View view)
    {
        controllerMeetingList = model;
        controllerView = view;
    }

    public void Run()
    {    
        controllerView.Run();       
    }

    //Methods

    // Create
    public void CreateMeeting(string title, string organizer, DateOnly date, TimeOnly time, string[] participants)
    {
        controllerMeetingList.CreateMeeting(title, organizer, date, time, participants);
    }

    // Read
    public List<Meeting> GetMeetings()
    {
        return controllerMeetingList.GetMeetings();
    }

    // Update

    // Delete
}