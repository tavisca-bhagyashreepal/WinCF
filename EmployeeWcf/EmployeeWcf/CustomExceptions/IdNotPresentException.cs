using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeWcf;
namespace EmployeeWcf.CustomExceptions
{
    public class IdNotPresentException: Exception
    {
        public IdNotPresentException(String message)
        {
            Console.WriteLine(message);
        }
    }
}