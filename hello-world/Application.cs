// ReSharper disable InconsistentNaming
namespace hello_world;

public class Application
{
    private readonly List<Person> _employees;
    
    public Application()
    {
        this._employees = new List<Person>();
    }

    private int _get_employee_id()
    {
        if (this._employees.Count == 0)
        {
            throw new IndexOutOfRangeException();
        }
        while (true)
        {
            Console.WriteLine("Select Employee-ID to Edit: ");
            string employee_id_input = Console.ReadLine() ?? "";
            if (int.TryParse(employee_id_input, out var employee_id))
            {
                employee_id--;
                if (employee_id <= this._employees.Count)
                {
                    return employee_id;
                }
            }
            Console.WriteLine("Invalid Employee ID.");   
        }
    }

    private Person _get_employee_from_id()
    {
        var employee_id = this._get_employee_id();
        return this._employees[employee_id];
    }
    
    public int list()
    {
        Console.WriteLine("All currently registered Employees: ");
        if (!this._employees.Any())
        {
            Console.WriteLine("No employees are currently registered.");
        }
        else
        {
            var index = -1;
            foreach (var employee in this._employees)
            {
                index++;
                Console.WriteLine($"Employee Nr. {index + 1}: '{employee.get_name()}'");
            }   
        }
        Console.WriteLine();
        return -1;
    }

    public int add()
    {
        var employee = new Person(null);
        Console.WriteLine("Adding a new Employee...");
        var attrs = new List<string>() { "name" };
        foreach (var attr in attrs)
        {
            Console.WriteLine($"Enter '{attr}': ");
            // ReSharper disable once SuggestVarOrType_BuiltInTypes
            string param = Console.ReadLine() ?? "";
            typeof(Person).GetMethod($"set_{attr}")?.Invoke(employee, new object?[] { param });
        }

        this._employees.Add(employee);
        Console.WriteLine();
        return -1;
    }

    public int edit()
    {
        Person employee;
        try
        {
            employee = this._get_employee_from_id();
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("No Employees have been added yet.");
            return -1;
        }

        var attrs = new List<string>() { "name" };
        foreach (var attr in attrs)
        {
            Console.WriteLine($"Enter '{attr}' (Empty to Skip): ");
            // ReSharper disable once SuggestVarOrType_BuiltInTypes
            string param = Console.ReadLine() ?? "";
            if (!string.IsNullOrEmpty(param))
            {
                typeof(Person).GetMethod($"set_{attr}")?.Invoke(employee, new object?[] { param });   
            }
            else
            {
                Console.WriteLine($"Skipping '{attr}'...");
            }
        }

        return -1;
    }

    public int delete()
    {
        int employee_id;
        try
        {
            employee_id = this._get_employee_id();
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("No Employees have been added yet.");
            return -1;
        }

        Console.WriteLine($"Removing Employee Nr. {employee_id + 1}");
        this._employees.RemoveAt(employee_id);
        Console.WriteLine();
        return -1;
    }
    
    public static int exit()
    {
        Console.WriteLine("Thank you for using Drizm HR!");
        Console.WriteLine("Goodbye o/");
        return 0;
    }
}
