using DemoRazorPages.Interfacce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRazorPages.Implementazione
{
    public class StaticMessage : IMessage
    {
        public string GetMessage()
        {
            return $"L'ora sul server è la seguente {DateTime.Now}";
        }
    }
}
