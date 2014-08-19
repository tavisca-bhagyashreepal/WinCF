using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeWcf
{
    
    [ServiceContract]
    public interface IEmployeeAddandCreate
    {
        [OperationContract]
        [FaultContract(typeof(FaultExceptionContract))]
        List<Employee> CreateEmployee(Employee employee);

        [OperationContract]
        [FaultContract(typeof(FaultExceptionContract))]
        Employee AddRemarksById(int id , String remark);
     
    }


    [ServiceContract]
    public interface IEmployeeRetrieve
    {
        [OperationContract]
        List<Employee> GetAllEmployees();

        [OperationContract(Name = "SearchById")]
        [FaultContract(typeof(FaultExceptionContract))]
        Employee GetEmployeeDetails(int id);

        [OperationContract(Name = "SearchByName")]
        [FaultContract(typeof(FaultExceptionContract))]
        Employee GetEmployeeDetails(string name);


        [OperationContract(Name = "SearchByRemark")]
        [FaultContract(typeof(FaultExceptionContract))]
        List<Employee> GetEmployeeByRemarks(string remark);
       
    }


  

    [DataContract]
    public class Employee
    {
        [DataMember] //this proprty should be exposed
        public int Id {get; set;}

        [DataMember]
        public string Name { get; set; }

        [DataMember] //this proprty should be exposed
        public DateTime Date { get; set; }

        [DataMember]
        public string Text { get; set; }       
    }
}
