namespace ProxyAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class HookAttribute : Attribute
    {
        string foo = "foobar";//Info: Code here will also be executed before the hook code is invoked
    }
}