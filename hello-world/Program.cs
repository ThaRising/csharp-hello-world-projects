using hello_world;
// ReSharper disable InconsistentNaming

var actions = new Dictionary<string, string>()
{
    { "list", "List all Employees" },
    { "add", "Add a new Employee" },
    { "edit", "Edit an existing Employees profile" },
    { "delete", "Remove an Employee (such as when leaving the company)" },
    { "exit", "Exit this Program" }
};

// Initialize Application
var application = new Application();
Console.WriteLine("Welcome to Drizm HR -- The Fabulous Employee Management Platform");
var app_state_ask = true;

while (true)
{
    var user_selected_action = "list";
    while (app_state_ask)
    {
        Console.WriteLine("Choose the Action you want to Perform: ");
        // ReSharper disable once SuggestVarOrType_BuiltInTypes
        int index = -1;
        // ReSharper disable once SuggestVarOrType_Elsewhere
        foreach (KeyValuePair<string, string> action in actions)
        {
            index++;
            Console.WriteLine($"'{action.Key}' ({index}) -- {action.Value}");
        }
        Console.WriteLine();
        Console.WriteLine("Please select an Action (Name or Number): ");

        // ReSharper disable once SuggestVarOrType_BuiltInTypes
        user_selected_action = Console.ReadLine() ?? "list";
    
        if (int.TryParse(user_selected_action, out var user_selected_index))
        {
            try
            {
                user_selected_action = actions.Keys.ElementAt(user_selected_index);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid Input!");
                continue;
            }
        }
        else
        {
            if (!actions.ContainsKey(user_selected_action))
            {
                Console.WriteLine("Invalid Input!");
                continue;
            }
        }

        app_state_ask = false;
    }
    var exit_code = (int)(typeof(Application).GetMethod(user_selected_action)?.Invoke(application, null) ?? -1);
    if (exit_code == -1)
    {
        app_state_ask = true;
        continue;
    }
    Environment.Exit(exit_code);
}
