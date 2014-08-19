﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeConsumer.EmployeeService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Employee", Namespace="http://schemas.datacontract.org/2004/07/EmployeeWcf")]
    [System.SerializableAttribute()]
    public partial class Employee : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TextField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Date {
            get {
                return this.DateField;
            }
            set {
                if ((this.DateField.Equals(value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Text {
            get {
                return this.TextField;
            }
            set {
                if ((object.ReferenceEquals(this.TextField, value) != true)) {
                    this.TextField = value;
                    this.RaisePropertyChanged("Text");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FaultExceptionContract", Namespace="http://schemas.datacontract.org/2004/07/EmployeeWcf")]
    [System.SerializableAttribute()]
    public partial class FaultExceptionContract : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusCodeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StatusCode {
            get {
                return this.StatusCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusCodeField, value) != true)) {
                    this.StatusCodeField = value;
                    this.RaisePropertyChanged("StatusCode");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeService.IEmployeeRetrieve")]
    public interface IEmployeeRetrieve {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeRetrieve/GetAllEmployees", ReplyAction="http://tempuri.org/IEmployeeRetrieve/GetAllEmployeesResponse")]
        EmployeeConsumer.EmployeeService.Employee[] GetAllEmployees();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeRetrieve/GetAllEmployees", ReplyAction="http://tempuri.org/IEmployeeRetrieve/GetAllEmployeesResponse")]
        System.Threading.Tasks.Task<EmployeeConsumer.EmployeeService.Employee[]> GetAllEmployeesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeRetrieve/SearchById", ReplyAction="http://tempuri.org/IEmployeeRetrieve/SearchByIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmployeeConsumer.EmployeeService.FaultExceptionContract), Action="http://tempuri.org/IEmployeeRetrieve/SearchByIdFaultExceptionContractFault", Name="FaultExceptionContract", Namespace="http://schemas.datacontract.org/2004/07/EmployeeWcf")]
        EmployeeConsumer.EmployeeService.Employee SearchById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeRetrieve/SearchById", ReplyAction="http://tempuri.org/IEmployeeRetrieve/SearchByIdResponse")]
        System.Threading.Tasks.Task<EmployeeConsumer.EmployeeService.Employee> SearchByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeRetrieve/SearchByName", ReplyAction="http://tempuri.org/IEmployeeRetrieve/SearchByNameResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmployeeConsumer.EmployeeService.FaultExceptionContract), Action="http://tempuri.org/IEmployeeRetrieve/SearchByNameFaultExceptionContractFault", Name="FaultExceptionContract", Namespace="http://schemas.datacontract.org/2004/07/EmployeeWcf")]
        EmployeeConsumer.EmployeeService.Employee SearchByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeRetrieve/SearchByName", ReplyAction="http://tempuri.org/IEmployeeRetrieve/SearchByNameResponse")]
        System.Threading.Tasks.Task<EmployeeConsumer.EmployeeService.Employee> SearchByNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeRetrieve/SearchByRemark", ReplyAction="http://tempuri.org/IEmployeeRetrieve/SearchByRemarkResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmployeeConsumer.EmployeeService.FaultExceptionContract), Action="http://tempuri.org/IEmployeeRetrieve/SearchByRemarkFaultExceptionContractFault", Name="FaultExceptionContract", Namespace="http://schemas.datacontract.org/2004/07/EmployeeWcf")]
        EmployeeConsumer.EmployeeService.Employee[] SearchByRemark(string remark);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeRetrieve/SearchByRemark", ReplyAction="http://tempuri.org/IEmployeeRetrieve/SearchByRemarkResponse")]
        System.Threading.Tasks.Task<EmployeeConsumer.EmployeeService.Employee[]> SearchByRemarkAsync(string remark);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEmployeeRetrieveChannel : EmployeeConsumer.EmployeeService.IEmployeeRetrieve, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmployeeRetrieveClient : System.ServiceModel.ClientBase<EmployeeConsumer.EmployeeService.IEmployeeRetrieve>, EmployeeConsumer.EmployeeService.IEmployeeRetrieve {
        
        public EmployeeRetrieveClient() {
        }
        
        public EmployeeRetrieveClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EmployeeRetrieveClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeRetrieveClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeRetrieveClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public EmployeeConsumer.EmployeeService.Employee[] GetAllEmployees() {
            return base.Channel.GetAllEmployees();
        }
        
        public System.Threading.Tasks.Task<EmployeeConsumer.EmployeeService.Employee[]> GetAllEmployeesAsync() {
            return base.Channel.GetAllEmployeesAsync();
        }
        
        public EmployeeConsumer.EmployeeService.Employee SearchById(int id) {
            return base.Channel.SearchById(id);
        }
        
        public System.Threading.Tasks.Task<EmployeeConsumer.EmployeeService.Employee> SearchByIdAsync(int id) {
            return base.Channel.SearchByIdAsync(id);
        }
        
        public EmployeeConsumer.EmployeeService.Employee SearchByName(string name) {
            return base.Channel.SearchByName(name);
        }
        
        public System.Threading.Tasks.Task<EmployeeConsumer.EmployeeService.Employee> SearchByNameAsync(string name) {
            return base.Channel.SearchByNameAsync(name);
        }
        
        public EmployeeConsumer.EmployeeService.Employee[] SearchByRemark(string remark) {
            return base.Channel.SearchByRemark(remark);
        }
        
        public System.Threading.Tasks.Task<EmployeeConsumer.EmployeeService.Employee[]> SearchByRemarkAsync(string remark) {
            return base.Channel.SearchByRemarkAsync(remark);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeService.IEmployeeAddandCreate")]
    public interface IEmployeeAddandCreate {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeAddandCreate/CreateEmployee", ReplyAction="http://tempuri.org/IEmployeeAddandCreate/CreateEmployeeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmployeeConsumer.EmployeeService.FaultExceptionContract), Action="http://tempuri.org/IEmployeeAddandCreate/CreateEmployeeFaultExceptionContractFaul" +
            "t", Name="FaultExceptionContract", Namespace="http://schemas.datacontract.org/2004/07/EmployeeWcf")]
        EmployeeConsumer.EmployeeService.Employee[] CreateEmployee(EmployeeConsumer.EmployeeService.Employee employee);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeAddandCreate/CreateEmployee", ReplyAction="http://tempuri.org/IEmployeeAddandCreate/CreateEmployeeResponse")]
        System.Threading.Tasks.Task<EmployeeConsumer.EmployeeService.Employee[]> CreateEmployeeAsync(EmployeeConsumer.EmployeeService.Employee employee);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeAddandCreate/AddRemarksById", ReplyAction="http://tempuri.org/IEmployeeAddandCreate/AddRemarksByIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmployeeConsumer.EmployeeService.FaultExceptionContract), Action="http://tempuri.org/IEmployeeAddandCreate/AddRemarksByIdFaultExceptionContractFaul" +
            "t", Name="FaultExceptionContract", Namespace="http://schemas.datacontract.org/2004/07/EmployeeWcf")]
        EmployeeConsumer.EmployeeService.Employee AddRemarksById(int id, string remark);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeAddandCreate/AddRemarksById", ReplyAction="http://tempuri.org/IEmployeeAddandCreate/AddRemarksByIdResponse")]
        System.Threading.Tasks.Task<EmployeeConsumer.EmployeeService.Employee> AddRemarksByIdAsync(int id, string remark);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEmployeeAddandCreateChannel : EmployeeConsumer.EmployeeService.IEmployeeAddandCreate, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmployeeAddandCreateClient : System.ServiceModel.ClientBase<EmployeeConsumer.EmployeeService.IEmployeeAddandCreate>, EmployeeConsumer.EmployeeService.IEmployeeAddandCreate {
        
        public EmployeeAddandCreateClient() {
        }
        
        public EmployeeAddandCreateClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EmployeeAddandCreateClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeAddandCreateClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeAddandCreateClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public EmployeeConsumer.EmployeeService.Employee[] CreateEmployee(EmployeeConsumer.EmployeeService.Employee employee) {
            return base.Channel.CreateEmployee(employee);
        }
        
        public System.Threading.Tasks.Task<EmployeeConsumer.EmployeeService.Employee[]> CreateEmployeeAsync(EmployeeConsumer.EmployeeService.Employee employee) {
            return base.Channel.CreateEmployeeAsync(employee);
        }
        
        public EmployeeConsumer.EmployeeService.Employee AddRemarksById(int id, string remark) {
            return base.Channel.AddRemarksById(id, remark);
        }
        
        public System.Threading.Tasks.Task<EmployeeConsumer.EmployeeService.Employee> AddRemarksByIdAsync(int id, string remark) {
            return base.Channel.AddRemarksByIdAsync(id, remark);
        }
    }
}
