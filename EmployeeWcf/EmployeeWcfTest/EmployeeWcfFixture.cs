using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeWcfTest.EmployeeService;
using System.Collections.Generic;
using System.Diagnostics;

namespace EmployeeWcfTest
{
    [TestClass]
    public class EmployeeWcfFixture
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }



        EmployeeAddandCreateClient _employeeAddandCreateClient = null; 
        EmployeeRetrieveClient _employeeRetrieveClient =null;
        Employee _employee = null;
        List<Employee> _employeeList = null;

        [TestInitialize]
        public void InitTestData()
        {
            _employeeAddandCreateClient = new EmployeeAddandCreateClient("WSHttpBinding_IEmployeeAddandCreate");
            _employeeRetrieveClient = new EmployeeRetrieveClient("BasicHttpBinding_IEmployeeRetrieve");
            _employee = new Employee();
            _employeeList = new List<Employee>();
         
        }

        [TestMethod]

        [DeploymentItem(@"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        @"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml",
        "AddEmployee", DataAccessMethod.Sequential)]
        
        public void AddEmployeeTest()
        {
            _employee.Name = testContextInstance.DataRow["EmployeeName"].ToString();
            _employee.Id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            _employee.Text = testContextInstance.DataRow["EmployeeRemark"].ToString();
            _employee.Date = Convert.ToDateTime(testContextInstance.DataRow["EmployeeRemarkDate"].ToString());
            
            _employeeList.AddRange(_employeeAddandCreateClient.CreateEmployee(_employee));
            
            Assert.AreEqual(_employeeList[0].Id, _employee.Id);
        }

        [TestMethod]

        [DeploymentItem(@"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        @"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml",
        "AddAgainEmployee", DataAccessMethod.Sequential)]

        [ExpectedException(typeof(System.ServiceModel.FaultException<FaultExceptionContract>))]

        public void AddAgainEmployeeTest()
        {

            _employee.Name = testContextInstance.DataRow["EmployeeName"].ToString();
            _employee.Id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            _employee.Text = testContextInstance.DataRow["EmployeeRemark"].ToString();
            _employee.Date = Convert.ToDateTime(testContextInstance.DataRow["EmployeeRemarkDate"].ToString());
            _employeeList.AddRange(_employeeAddandCreateClient.CreateEmployee(_employee));

            Employee employeeSecond = new Employee();
            employeeSecond.Name = testContextInstance.DataRow["EmployeeName"].ToString();
            employeeSecond.Id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            employeeSecond.Text = testContextInstance.DataRow["EmployeeRemark"].ToString();
            employeeSecond.Date = Convert.ToDateTime(testContextInstance.DataRow["EmployeeRemarkDate"].ToString());
            _employeeList.AddRange(_employeeAddandCreateClient.CreateEmployee(employeeSecond));

        }

        [TestMethod]

        [DeploymentItem(@"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        @"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml",
        "RetrieveEmployeeById", DataAccessMethod.Sequential)]
        
        public void RetrieveEmployeeByIdTest()
        {

            _employee.Name = testContextInstance.DataRow["EmployeeName"].ToString();
            _employee.Id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            _employee.Text = testContextInstance.DataRow["EmployeeRemark"].ToString();
            _employee.Date = Convert.ToDateTime(testContextInstance.DataRow["EmployeeRemarkDate"].ToString());
           
            _employeeList.AddRange(_employeeAddandCreateClient.CreateEmployee(_employee)); 
            
            Employee empSearch = _employeeRetrieveClient.SearchById(_employee.Id);
            
            Assert.AreEqual(_employee.Id, empSearch.Id);
        }

       
        [TestMethod]

        [DeploymentItem(@"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        @"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml",
        "RetrieveEmployeeByIdButIdNotPresent", DataAccessMethod.Sequential)]
        
        [ExpectedException(typeof(System.ServiceModel.FaultException<FaultExceptionContract>))]
        
        public void RetrieveEmployeeByIdButIdNotPresentTest()
        {
            _employee.Name = testContextInstance.DataRow["EmployeeName"].ToString();
            _employee.Id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            _employee.Text = testContextInstance.DataRow["EmployeeRemark"].ToString();
            _employee.Date = Convert.ToDateTime(testContextInstance.DataRow["EmployeeRemarkDate"].ToString());
          
            _employeeList.AddRange(_employeeAddandCreateClient.CreateEmployee(_employee)); 
            
            Employee empSearch = _employeeRetrieveClient.SearchById(Int32.Parse(testContextInstance.DataRow["EmployeeIdNotPresent"].ToString()));
        }

       
        [TestMethod]

        [DeploymentItem(@"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        @"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml",
        "RetrieveEmployeeByName", DataAccessMethod.Sequential)]
        
        public void RetrieveEmployeeByNameTest()
        {
            _employee.Name = testContextInstance.DataRow["EmployeeName"].ToString();
            _employee.Id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            _employee.Text = testContextInstance.DataRow["EmployeeRemark"].ToString();
            _employee.Date = Convert.ToDateTime(testContextInstance.DataRow["EmployeeRemarkDate"].ToString());
            
            _employeeList.AddRange(_employeeAddandCreateClient.CreateEmployee(_employee));
            
            Employee employeeSearch = _employeeRetrieveClient.SearchByName(_employee.Name);
            
            Assert.AreEqual(_employee.Name, employeeSearch.Name);
        }

        [TestMethod]

        [DeploymentItem(@"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        @"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml",
        "RetrieveEmployeeByNameButNameNotPresent", DataAccessMethod.Sequential)]

        [ExpectedException(typeof(System.ServiceModel.FaultException<FaultExceptionContract>))]
        
        public void RetrieveEmployeeByNameButNameNotPresentTest()
        {

            _employee.Name = testContextInstance.DataRow["EmployeeName"].ToString();
            _employee.Id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            _employee.Text = testContextInstance.DataRow["EmployeeRemark"].ToString();
            _employee.Date = Convert.ToDateTime(testContextInstance.DataRow["EmployeeRemarkDate"].ToString());
            
            _employeeList.AddRange(_employeeAddandCreateClient.CreateEmployee(_employee)); 
            
            Employee employeeSearch = _employeeRetrieveClient.SearchByName(testContextInstance.DataRow["EmployeeNameNotPresent"].ToString());
        }


        [TestMethod]

        [DeploymentItem(@"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        @"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml",
        "RetrieveAllEmployees", DataAccessMethod.Sequential)]
        
        public void RetrieveAllEmployeesTest()
        {
            _employee.Name = testContextInstance.DataRow["EmployeeName"].ToString();
            _employee.Id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            _employee.Text = testContextInstance.DataRow["EmployeeRemark"].ToString();
            _employee.Date = Convert.ToDateTime(testContextInstance.DataRow["EmployeeRemarkDate"].ToString());
            
            _employeeList.AddRange(_employeeAddandCreateClient.CreateEmployee(_employee)); 

            _employeeList.AddRange(_employeeRetrieveClient.GetAllEmployees());
            foreach (Employee empList in _employeeList)
            {
                Debug.WriteLine("EmployeeId:"+ empList.Id);
                Debug.WriteLine("EmployeeName:" + empList.Name);
                Debug.WriteLine("EmployeeRemark:" + empList.Text);
                Debug.WriteLine("EmployeeDate:" + empList.Date);
            }
           
        }

      
        [TestMethod]

        [DeploymentItem(@"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        @"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml",
        "AddRemark", DataAccessMethod.Sequential)]

        public void AddRemarkForExistingEmployeeTest()
        {
            _employee.Name = testContextInstance.DataRow["EmployeeName"].ToString();
            _employee.Id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            _employee.Text = testContextInstance.DataRow["EmployeeRemark"].ToString();
            _employee.Date = Convert.ToDateTime(testContextInstance.DataRow["EmployeeRemarkDate"].ToString());
            
            _employeeList.AddRange(_employeeAddandCreateClient.CreateEmployee(_employee));
            
            Employee employeeRemarkId = _employeeAddandCreateClient.AddRemarksById(_employee.Id, testContextInstance.DataRow["NewRemark"].ToString());
            
            Assert.AreEqual(employeeRemarkId.Text, testContextInstance.DataRow["NewRemark"].ToString());           
        }

        [TestMethod]

        [DeploymentItem(@"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        @"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml",
        "AddRemarkButEmployeeNotPresent", DataAccessMethod.Sequential)]

        [ExpectedException(typeof(System.ServiceModel.FaultException<FaultExceptionContract>))]
        
        public void AddRemarkForExistingEmployeeButEmployeeNotPresentTest()
        {

            _employee.Name = testContextInstance.DataRow["EmployeeName"].ToString();
            _employee.Id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            _employee.Text = testContextInstance.DataRow["EmployeeRemark"].ToString();
            _employee.Date = Convert.ToDateTime(testContextInstance.DataRow["EmployeeRemarkDate"].ToString());
           
            _employeeList.AddRange(_employeeAddandCreateClient.CreateEmployee(_employee));
            
            Employee employeeRemarkId = _employeeAddandCreateClient.AddRemarksById(Int32.Parse(testContextInstance.DataRow["EmployeeIdNotPresent"].ToString()), testContextInstance.DataRow["NewRemark"].ToString());    
        }


        [TestMethod]

        [DeploymentItem(@"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        @"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml",
        "GetEmployeeByRemark", DataAccessMethod.Sequential)]

        public void GetEmployeeByRemarkTest()
        {

            _employee.Name = testContextInstance.DataRow["EmployeeName"].ToString();
            _employee.Id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            _employee.Text = testContextInstance.DataRow["EmployeeRemark"].ToString();
            _employee.Date = Convert.ToDateTime(testContextInstance.DataRow["EmployeeRemarkDate"].ToString());
           
            _employeeList.AddRange(_employeeAddandCreateClient.CreateEmployee(_employee));
            
            _employeeList.AddRange(_employeeRetrieveClient.SearchByRemark(_employee.Text));
            
            Assert.AreEqual(_employeeList[0].Text, _employee.Text);
        }

        [TestMethod]

        [DeploymentItem(@"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        @"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml",
        "GetEmployeeByRemarkButRemarkNotPresent", DataAccessMethod.Sequential)]

        [ExpectedException(typeof(System.ServiceModel.FaultException<FaultExceptionContract>))]
        
        public void GetEmployeeByRemarkButRemarkNotPresentTest()
        {

            _employee.Name = testContextInstance.DataRow["EmployeeName"].ToString();
            _employee.Id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            _employee.Text = testContextInstance.DataRow["EmployeeRemark"].ToString();
            _employee.Date = Convert.ToDateTime(testContextInstance.DataRow["EmployeeRemarkDate"].ToString());
            
            _employeeList.AddRange(_employeeAddandCreateClient.CreateEmployee(_employee));

            _employeeList.AddRange(_employeeRetrieveClient.SearchByRemark(testContextInstance.DataRow["EmployeeRemarkNotPresent"].ToString()));
            
        }


        [TestMethod]

        [DeploymentItem(@"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        @"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml",
        "AddRemarksByIdValidatorId", DataAccessMethod.Sequential)]

        [ExpectedException(typeof(System.ServiceModel.FaultException))]

        public void AddRemarksByIdButIdNotValidTest()
        {

            _employee.Name = testContextInstance.DataRow["EmployeeName"].ToString();
            _employee.Id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            _employee.Text = testContextInstance.DataRow["EmployeeRemark"].ToString();
            _employee.Date = Convert.ToDateTime(testContextInstance.DataRow["EmployeeRemarkDate"].ToString());

            _employeeList.AddRange(_employeeAddandCreateClient.CreateEmployee(_employee));
            Employee employeeRemark = _employeeAddandCreateClient.AddRemarksById(_employee.Id, _employee.Name);
        }

        [TestMethod]

        [DeploymentItem(@"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        @"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml",
        "AddRemarksByIdValidatorRemark", DataAccessMethod.Sequential)]

        [ExpectedException(typeof(System.ServiceModel.FaultException))]

        public void AddRemarksByIdButRemarkNotValidTest()
        {

            _employee.Name = testContextInstance.DataRow["EmployeeName"].ToString();
            _employee.Id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            _employee.Text = testContextInstance.DataRow["EmployeeRemark"].ToString();
            _employee.Date = Convert.ToDateTime(testContextInstance.DataRow["EmployeeRemarkDate"].ToString());

            _employeeList.AddRange(_employeeAddandCreateClient.CreateEmployee(_employee));
            
            Employee employeeRemark = _employeeAddandCreateClient.AddRemarksById(_employee.Id, _employee.Name);
        }

        [TestMethod]

        [DeploymentItem(@"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        @"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml",
        "GetEmployeesByIdValidatorId", DataAccessMethod.Sequential)]

        [ExpectedException(typeof(System.ServiceModel.FaultException))]

        public void GetEmployeesByIdButIdNotValidTest()
        {

            _employee.Name = testContextInstance.DataRow["EmployeeName"].ToString();
            _employee.Id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            _employee.Text = testContextInstance.DataRow["EmployeeRemark"].ToString();
            _employee.Date = Convert.ToDateTime(testContextInstance.DataRow["EmployeeRemarkDate"].ToString());

            _employeeList.AddRange(_employeeAddandCreateClient.CreateEmployee(_employee));

            Employee employeeRemark = _employeeRetrieveClient.SearchById(_employee.Id);
        }


        [TestMethod]

        [DeploymentItem(@"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        @"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml",
        "GetEmployeesByNameValidatorName", DataAccessMethod.Sequential)]

        [ExpectedException(typeof(System.ServiceModel.FaultException))]

        public void GetEmployeesByNameButNameNotValidTest()
        {

            _employee.Name = testContextInstance.DataRow["EmployeeName"].ToString();
            _employee.Id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            _employee.Text = testContextInstance.DataRow["EmployeeRemark"].ToString();
            _employee.Date = Convert.ToDateTime(testContextInstance.DataRow["EmployeeRemarkDate"].ToString());

            _employeeList.AddRange(_employeeAddandCreateClient.CreateEmployee(_employee));

            Employee employeeRemark = _employeeRetrieveClient.SearchByName(_employee.Name);
        }

        [TestMethod]

        [DeploymentItem(@"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        @"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml",
        "GetEmployeesByRemarkValidatorRemark", DataAccessMethod.Sequential)]

        [ExpectedException(typeof(System.ServiceModel.FaultException))]

        public void GetEmployeesByRemarkButRemarkNotValidTest()
        {

            _employee.Name = testContextInstance.DataRow["EmployeeName"].ToString();
            _employee.Id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            _employee.Text = testContextInstance.DataRow["EmployeeRemark"].ToString();
            _employee.Date = Convert.ToDateTime(testContextInstance.DataRow["EmployeeRemarkDate"].ToString());

            _employeeList.AddRange(_employeeAddandCreateClient.CreateEmployee(_employee));

            List<Employee> employeeRemark = new List<Employee>();
            employeeRemark.AddRange(_employeeRetrieveClient.SearchByRemark(_employee.Text));
        }

        [TestMethod]

        [DeploymentItem(@"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        @"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml",
        "CreateEmployeeValidatorId", DataAccessMethod.Sequential)]

        [ExpectedException(typeof(System.ServiceModel.FaultException))]

        public void CreateEmployeeButIdNotValidTest()
        {

            _employee.Name = testContextInstance.DataRow["EmployeeName"].ToString();
            _employee.Id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            _employee.Text = testContextInstance.DataRow["EmployeeRemark"].ToString();
            _employee.Date = Convert.ToDateTime(testContextInstance.DataRow["EmployeeRemarkDate"].ToString());

            _employeeList.AddRange(_employeeAddandCreateClient.CreateEmployee(_employee));          
        }

        [TestMethod]

        [DeploymentItem(@"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        @"E:\EmployeeWcf\EmployeeWcfTest\EmployeeServiceXmlData.xml",
        "CreateEmployeeValidatorName", DataAccessMethod.Sequential)]

        [ExpectedException(typeof(System.ServiceModel.FaultException))]

        public void CreateEmployeeButNameNotValidTest()
        {

            _employee.Name = testContextInstance.DataRow["EmployeeName"].ToString();
            _employee.Id = Int32.Parse(testContextInstance.DataRow["EmployeeId"].ToString());
            _employee.Text = testContextInstance.DataRow["EmployeeRemark"].ToString();
            _employee.Date = Convert.ToDateTime(testContextInstance.DataRow["EmployeeRemarkDate"].ToString());

            _employeeList.AddRange(_employeeAddandCreateClient.CreateEmployee(_employee));
        }

    }
}
