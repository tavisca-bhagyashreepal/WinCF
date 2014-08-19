using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
namespace EmployeeWcf
{

    
   // [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class EmployeeService : IEmployeeAddandCreate, IEmployeeRetrieve
    {
        private static List<Employee> EmpList = new List<Employee>();
    
        public List<Employee> CreateEmployee(Employee employee)
        {
           
            int index = EmpList.FindIndex(a => a.Id.Equals(employee.Id));

            if (index < 0)
            {

                EmpList.Add(employee);
                return EmpList;
            }
            else
            {
                FaultExceptionContract fault = new FaultExceptionContract
                {
                    StatusCode = "101",
                    Message = "Employee with Id " + employee.Id + " already exists"
                };
                throw new FaultException<FaultExceptionContract>
                (fault, "Employee with Id " + employee.Id + " already  exists");
            }    
        }

        public List<Employee> GetAllEmployees()
        {
            return EmpList;
        }

        public Employee GetEmployeeDetails(int id)
        {

            int index = EmpList.FindIndex(a => a.Id.Equals(id));
           
            if (index >= 0)
            {
                return EmpList[index];

            }
            else
            {
                FaultExceptionContract fault = new FaultExceptionContract
                {
                    StatusCode = "101",
                    Message = "Employee with Id " + id + " doesnot exist"
                };
                throw new FaultException<FaultExceptionContract>
                (fault, "Employee with Id " + id + " doesnot  exist");
            }         
        }

        public Employee GetEmployeeDetails(string name)
        {

            int index = EmpList.FindIndex(a => a.Name == name);
                
            if (index >= 0)
            {
                return EmpList[index];
            }   
            else
            {
                FaultExceptionContract fault = new FaultExceptionContract
                {
                    StatusCode = "101",
                    Message = "Employee with name " + name + " doesnot exist"
                };
                throw new FaultException<FaultExceptionContract>
                (fault, "Employee with name " + name + " doesnot exist");
            }          
        }

        public Employee AddRemarksById(int id ,String remark)
        {
            int index = EmpList.FindIndex(a => a.Id.Equals(id));
           
                if (index >= 0)
                {
                    EmpList[index].Text = remark;
                    return EmpList[index];

                }
                else
                {
                    FaultExceptionContract fault = new FaultExceptionContract
                    {
                        StatusCode = "101",
                        Message = "Employee with Id " + id + " doesnot exist"
                    };
                    throw new FaultException<FaultExceptionContract>
                    (fault, "Employee with Id " + id + " doesnot exist");
                }
        }

        public List<Employee> GetEmployeeByRemarks(string remark)
        {
            List<Employee> employeeList =EmpList.Where(x => x.Text == remark).Select(s => s).ToList();

            if (employeeList.Count != 0)
            {
                return employeeList;
            }         
            else
            {
                FaultExceptionContract fault = new FaultExceptionContract
                {
                    StatusCode = "101",
                    Message = "Employee with remark " + remark + " doesnot exist"
                };
                throw new FaultException<FaultExceptionContract>
                (fault, "Employee with remark " + remark + " doesnot exist");
            }          
        }

    }
}
