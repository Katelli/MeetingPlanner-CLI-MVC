public class View
{
    private Controller controller;
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
    public void Run()
    {
        bool exit = false;
        while(!exit)
        {
            DisplayMessage("\nWelcome to my meeting planner");
            DisplayMessage("\nWhat do you want to do?");
            DisplayMessage("Write \"Display\" to display the list of meetings");
            DisplayMessage("Write \"Create\" to add a new meeting to the list");
            DisplayMessage("Write \"Update\" to change the details of a meeting");
            DisplayMessage("Write \"Delete\" to remove a meeting");
            DisplayMessage("Write anything else to exit the program");
            string? choice = Console.ReadLine()?.Trim().ToUpper();

            switch(choice)
            {
                case "CREATE":
                CreateMeeting();
                    break;

                case "DISPLAY":
                GetMeetings();
                    break;

                case "UPDATE":
                    break;

                case "DELETE":
                    break;

                default:
                exit = true;
                    break;
            }    
        }
    }


    public void CreateMeeting()
    {
        DisplayMessage("\n");
        DisplayMessage("Enter the name of the meeting");
        string title = Console.ReadLine()!;
        if(string.IsNullOrEmpty(title))
        {
            DisplayMessage("Meeting name can not be empty, please try again:");
            title = Console.ReadLine()!;
        }
        

        DisplayMessage("\n");
        DisplayMessage("Who is the organizer of this meeting?");
        string organizer = Console.ReadLine()!;
        if(string.IsNullOrEmpty(organizer))
        {
            DisplayMessage("Meeting name can not be empty, please try again:");
            organizer = Console.ReadLine()!;
        }
        

        DisplayMessage("\n");
        DisplayMessage("On what day will the meeting take place? (Write it as DD.MM.YYYY)");
        if(!DateOnly.TryParse(Console.ReadLine(), out DateOnly date))
        {
            DateOnly.TryParse(Console.ReadLine(), out date);
        }

        DisplayMessage("\n");
        DisplayMessage("At what time will the meeting take place? (Write it as \"Hours:Minutes\")");
        if(!TimeOnly.TryParse(Console.ReadLine(), out TimeOnly time))
        {
            Console.WriteLine("Invalid time, please try again");
            TimeOnly.TryParse(Console.ReadLine(), out time);
        }
        
        DisplayMessage("\n");
        DisplayMessage("Who will participate in the meeting?");
        string newParticipant = Console.ReadLine()!;
        string[] participants = {newParticipant};
        if(participants.Length < 1 && string.IsNullOrWhiteSpace(newParticipant))
        {
            DisplayMessage("You can't hold a meeting by yourself, please write some names");
            newParticipant = Console.ReadLine()!;            
        }
        
        if(!string.IsNullOrWhiteSpace(newParticipant))
        {
            participants.Append(newParticipant);
            DisplayMessage("Do you want to add anyone else? (Write Yes to add someone else, or any key to continue)");
            string? choice = Console.ReadLine();
            while(choice == "Yes")
            {
                DisplayMessage("Who will participate in the meeting?");
                newParticipant = Console.ReadLine()!;
                DisplayMessage("Do you want to add anyone else? (Write Yes to add someone else, or any key to continue)");
                choice = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(newParticipant))
                {
                    Console.WriteLine("Name can not be empty");
                    newParticipant = Console.ReadLine()!;
                    DisplayMessage("Do you want to add anyone else? (Write Yes to add someone else, or any key to continue)");
                    choice = Console.ReadLine();
                }                
            }
            controller.CreateMeeting(title, organizer, date, time, participants);
            Display(controller.GetMeetings());
        }
    }

    public List<Meeting> GetMeetings()
    {
        return controller.GetMeetings();
    }
}