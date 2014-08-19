using EmployeeConsumer.EmployeeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeConsumer
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            String employeeName = "";
            String employeeRemarks = "";
            int employeeId = 0 ;
            DateTime dateTime = DateTime.Now;
            
            
            int choice = 0;
            var employeeAddandCreateObject = new EmployeeAddandCreateClient("WSHttpBinding_IEmployeeAddandCreate");
            var employeeRetrieveObject = new EmployeeRetrieveClient("BasicHttpBinding_IEmployeeRetrieve");
            var employee = new Employee();
            
               try{
                do
                {
                    Console.WriteLine("Employee Management System:");
                    Console.WriteLine("1.Add Employee Details");
                    Console.WriteLine("2.Add Employee by Remark");
                    Console.WriteLine("3.Retrieve Employee By Employee Name");
                    Console.WriteLine("4.Retrieve Employee By Employee Id");
                    Console.WriteLine("5.Retrieve Employee By Employee Remark");
                    Console.WriteLine("6.Retrieve All Employees");
                    Console.WriteLine("7.Exit");
                    Console.WriteLine("Enter your Choice:");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                                Console.WriteLine("Enter Employee Name:");
                                employeeName = Console.ReadLine();
                                Console.WriteLine("Enter Employee Id:");
                                employeeId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter Remark:");
                                employeeRemarks = Console.ReadLine();
                                Console.WriteLine("Enter Date Time");
                                dateTime = Convert.ToDateTime(Console.ReadLine());
                                employee.Name = employeeName;
                                employee.Id = employeeId;
                                employee.Date = dateTime;
                                employee.Text = employeeRemarks;
                                List<Employee> empList = new List<Employee>();
                                empList.AddRange(employeeAddandCreateObject.CreateEmployee(employee));
                                break;

                        case 2: Console.WriteLine("Enter EmployeeId");
                                employeeId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter EmployeeRemark");
                                employeeRemarks = Console.ReadLine();
                                Employee empRemark = employeeAddandCreateObject.AddRemarksById(employeeId, employeeRemarks);
                                Console.WriteLine("EmployeeId:" + empRemark.Id);
                                Console.WriteLine("EmployeeRemark:" + empRemark.Text);
                                break;

                        case 3: Console.WriteLine("Enter EmployeeName");
                                employeeName = Console.ReadLine();
                                Employee empName = employeeRetrieveObject.SearchByName(employeeName);
                                Console.WriteLine("EmployeeId:" + empName.Id);
                                Console.WriteLine("EmployeeRemark:" + empName.Text);
                                Console.WriteLine("EmployeeName:" + empName.Name);
                                Console.WriteLine("EmployeeDate:" + empName.Date);
                                break;

                        case 4: Console.WriteLine("Enter EmployeeId");
                                employeeId = Convert.ToInt32(Console.ReadLine());
                                Employee empId =employeeRetrieveObject.SearchById(employeeId);
                                Console.WriteLine("EmployeeId:" + empId.Id);
                                Console.WriteLine("EmployeeRemark:" + empId.Text);
                                Console.WriteLine("EmployeeName:" + empId.Name);
                                Console.WriteLine("EmployeeDate:" + empId.Date);
                                break;

                        case 5: employeeRemarks = Console.ReadLine();
                                List<Employee> empRemarkList = new List<Employee>();
                                empRemarkList.AddRange(employeeRetrieveObject.SearchByRemark(employeeRemarks));
                                foreach (Employee emp in empRemarkList)
                                {
                                    Console.WriteLine("EmployeeId:" + emp.Id);
                                    Console.WriteLine("EmployeeRemark:" + emp.Text);
                                    Console.WriteLine("EmployeeName:" + emp.Name);
                                    Console.WriteLine("EmployeeDate:" + emp.Date);
                                }
                                break;

                        case 6: List<Employee> empAllEmployeeList = new List<Employee>();
                                empAllEmployeeList.AddRange(employeeRetrieveObject.GetAllEmployees());
                                foreach (Employee emp in empAllEmployeeList)
                                {
                                    Console.WriteLine("EmployeeId:" + emp.Id);
                                    Console.WriteLine("EmployeeRemark:" + emp.Text);
                                    Console.WriteLine("EmployeeName:" + emp.Name);
                                    Console.WriteLine("EmployeeDate:" + emp.Date);
                                }
                                break;

                        case 7: break;
                        default: Console.WriteLine("Invalid Choice");
                                break;
                    }


                } while (choice != 7);
               }
               catch (FaultException<FaultExceptionContract> ex)
               {
                   string msg = "StatusCode: " + ex.Detail.StatusCode;
                   msg += "\nMessage: " + ex.Detail.Message;
                   Console.WriteLine(msg);
               }
               
            Console.ReadKey();
        }

    }
}
