
# Readme
This project gives a basic idea of how to implement pre/post/alternate hook. What this means is that we can have the ability to execute an alternate code before/after/or instead of an existing code just by marking the function with a custom attribute.
We use Castle.Core's dynamicproxies to accomplish this
http://www.castleproject.org/projects/dynamicproxy/


**Steps to follow/What I did**
1. Create a latest .net standard project. This is an API
2. Add references to Castle.Core
3. Create `AddProxiedScoped()` as extenstion to IServiceCollection
4. Create a custom attribute. In this case `HookAttribute`
5. The method that need to be hooked should have this attribute. Make sure the method is virtual or the class with the method implements an interface. This this case its `IStudent` and `Student` class and the method is `GetFirstLetterOfName()`
6. Create your interceptor. In this case `HookInterceptor` is the interceptor class
7. Register everything. Below lines were added to Program.cs
 ```
    builder.Services.AddSingleton(new ProxyGenerator());  
    builder.Services.AddScoped<IInterceptor, HookInterceptor>();  
    builder.Services.AddProxiedScoped<IStudent, Student>();
```
8. Now place debugger in the attribute, the interceptor and controller method to see how the code gets into custom code if hookattribute is found for a method in the student class and skipped when its not found. `SetName()` doesnt have the attribute but `GetFirstLetterOfName()` has.
9. Search for 'Info:' to see comments related to hook specific code change

