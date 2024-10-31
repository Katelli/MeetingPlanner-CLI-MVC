namespace MeetingPlanner_CLI_MVC;

class Program
{
    static void Main(string[] args)
    {
        Model model = new Model();
        View view = new View();
        Controller controller = new Controller(model, view);

        controller.CreateMeeting();
        Console.ReadLine();
    }
}
