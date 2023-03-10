using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6
{
    internal class Class1
    {

        public void ThrowsException(int inputA) 
        {
            if (inputA == 0) 
            {
                throw new InvalidInputException("Invalid Input, cannot be 0");
            }
        }

    }

    internal class InvalidInputException : Exception 
    {
        public InvalidInputException(string message) : base(message) 
        {
            
        }
        
    }
}
