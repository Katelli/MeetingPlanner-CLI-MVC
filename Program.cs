namespace MeetingPlanner_CLI_MVC;

class Program
{
    static void Main(string[] args)
    {
        MeetingList model = new MeetingList();
        View view = new View();
        Controller controller = new Controller(model, view);

        controller.Run();
    }
}
