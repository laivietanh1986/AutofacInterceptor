using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace AutofacInterceptor
{
    public class LogInterceptor :IInterceptor
    {
        private readonly TextWriter _textWriter;

        public LogInterceptor(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }
        
        public void Intercept(IInvocation invocation)
        {
            try
            {
                _textWriter.WriteLine("before call method {0}", invocation.Method);
                invocation.Proceed();
                _textWriter.WriteLine("after call method {0}", invocation.Method);
            }
            catch (Exception e)
            {
                _textWriter.WriteLine("error {0}",e.Message);
            }
            
        }
    }
}
