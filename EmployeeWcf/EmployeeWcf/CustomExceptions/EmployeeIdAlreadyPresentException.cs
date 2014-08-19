using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeWcf;
using System.Runtime.Serialization;

namespace EmployeeWcf.CustomExceptions
{
    [Serializable]
    public class EmployeeIdAlreadyPresentException : Exception
    {

        public EmployeeIdAlreadyPresentException(String message)
        {
            Console.WriteLine(message);
        }
        // This constructor is needed for serialization.
        protected EmployeeIdAlreadyPresentException(SerializationInfo info, StreamingContext context)
        {

        }
    }
}