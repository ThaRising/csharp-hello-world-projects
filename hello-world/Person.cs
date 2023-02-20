namespace hello_world;

public class Person
{
    private string _name;

    public Person(string? name)
    {
        this._name = name ?? "";
    }

    public string get_name()
    {
        return this._name;
    }

    // ReSharper disable once UnusedMember.Global
    public void set_name(string name)
    {
        this._name = name;
    }
}
