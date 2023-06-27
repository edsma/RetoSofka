using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetoSofka.Aplication.Services
{
    public class ShoppingException: Exception
    {
        public ShoppingException(string value) : base(string.Format($"No se puede realizar el proceso: {value}")) { }
    }
}
