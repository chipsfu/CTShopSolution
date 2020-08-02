using System;
using System.Collections.Generic;
using System.Text;

namespace CTShopSolution.Utilities.Exceptions
{
   public class CTShopException : Exception
    {
        public CTShopException()
        {
        }

        public CTShopException(string message)
            : base(message)
        {
        }

        public CTShopException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
