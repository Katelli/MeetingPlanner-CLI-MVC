public class Controller
{
    Model controllerModel;
    View controllerView;

    public Controller(Model model, View view)
    {
        controllerModel = model;
        controllerView = view;
    }

    public void Run()
    {
        bool exit = false;
        while(!exit)
        {
            //controllerView.Display();
            string? choice = Console.ReadLine()?.Trim().ToUpper();

            switch(choice)
            {
                case "Create":
                    break;
                
                case "Display":
                    break;

                case "Update":
                    break;

                case "Delete":
                    break;
            }
        }
    }

    //Methods

    // Create
    public void CreateMeeting()
    {
        controllerView.DisplayMessage("\n");
        controllerView.DisplayMessage("Enter the name of the meeting");
        string? title = Console.ReadLine();
        if(string.IsNullOrEmpty(title))
        {
            controllerView.DisplayMessage("Meeting name can not be empty, please try again:");
            title = Console.ReadLine();
        }
        

        controllerView.DisplayMessage("\n");
        controllerView.DisplayMessage("Who is the organizer of this meeting?");
        string? organizer = Console.ReadLine();
        if(string.IsNullOrEmpty(organizer))
        {
            controllerView.DisplayMessage("Meeting name can not be empty, please try again:");
            organizer = Console.ReadLine();
        }
        

        controllerView.DisplayMessage("\n");
        controllerView.DisplayMessage("On what day will the meeting take place? (Write it as DD.MM.YYYY)");
        if(!DateOnly.TryParse(Console.ReadLine(), out DateOnly date))
        {
            DateOnly.TryParse(Console.ReadLine(), out date);
        }

        controllerView.DisplayMessage("\n");
        controllerView.DisplayMessage("At what time will the meeting take place? (Write it as \"Hours:Minutes\")");
        if(!TimeOnly.TryParse(Console.ReadLine(), out TimeOnly time))
        {
            Console.WriteLine("Invalid time, please try again");
            TimeOnly.TryParse(Console.ReadLine(), out time);
        }
        
        controllerView.DisplayMessage("\n");
        controllerView.DisplayMessage("Who will participate in the meeting?");
        string? newParticipant = Console.ReadLine();
        string[]? participants = {newParticipant};
        if(participants.Length < 1 && string.IsNullOrWhiteSpace(newParticipant))
        {
            controllerView.DisplayMessage("You can't hold a meeting by yourself, please write some names");
            newParticipant = Console.ReadLine();            
        }
        
        if(!string.IsNullOrWhiteSpace(newParticipant))
        {
            participants.Append(newParticipant);
            controllerView.DisplayMessage("Do you want to add anyone else? (Write Yes to add someone else, or any key to continue)");
            string? choice = Console.ReadLine();
            while(choice == "Yes")
            {
                controllerView.DisplayMessage("Who will participate in the meeting?");
                newParticipant = Console.ReadLine();
                controllerView.DisplayMessage("Do you want to add anyone else? (Write Yes to add someone else, or any key to continue)");
                choice = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(newParticipant))
                {
                    Console.WriteLine("Name can not be empty");
                    newParticipant = Console.ReadLine();
                    controllerView.DisplayMessage("Do you want to add anyone else? (Write Yes to add someone else, or any key to continue)");
                    choice = Console.ReadLine();
                }                
            }
            controllerModel.CreateMeeting(title, organizer, date, time, participants);
            controllerView.Display(controllerModel.GetMeetings());
        }      
    }

    // Update

    // Delete
}