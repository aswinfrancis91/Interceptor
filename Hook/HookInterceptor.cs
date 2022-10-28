using Castle.DynamicProxy;
using ProxyAttributes;
using System.Reflection;

namespace Hook
{
    public class HookInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            //Info: Look for existence of hook attribute
            var hookAttr = invocation.MethodInvocationTarget
                .GetCustomAttributes(typeof(HookAttribute), false)
                .FirstOrDefault() as HookAttribute;

            if (hookAttr != null)
            {
                //Info: Do something if hook attribute exists. Sort of a pre hook
            }

            invocation.Proceed(); //Info: Continue with the rest of the code. Can be in else condition if you want to completely skip the executing the original code block
        }
    }
}