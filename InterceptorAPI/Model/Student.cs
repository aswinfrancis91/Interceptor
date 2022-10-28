using ProxyAttributes;

namespace InterceptorAPI.Model;

public interface IStudent
{
    void SetName(string name);
    char GetFirstLetterOfName();
}

public class Student : IStudent
{
    public string Name { get; set; }

    [Hook]
    public char GetFirstLetterOfName()
    {
        return Name[0];
    }

    public void SetName(string name)
    {
        Name = name;
    }
}