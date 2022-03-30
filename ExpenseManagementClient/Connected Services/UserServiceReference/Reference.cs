﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExpenseManagementClient.UserServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserModel", Namespace="http://schemas.datacontract.org/2004/07/ExpenseManagement.Models")]
    [System.SerializableAttribute()]
    public partial class UserModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float UserCreditField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float UserDebitField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserEmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserPasswordField;
        
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
        public float UserCredit {
            get {
                return this.UserCreditField;
            }
            set {
                if ((this.UserCreditField.Equals(value) != true)) {
                    this.UserCreditField = value;
                    this.RaisePropertyChanged("UserCredit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float UserDebit {
            get {
                return this.UserDebitField;
            }
            set {
                if ((this.UserDebitField.Equals(value) != true)) {
                    this.UserDebitField = value;
                    this.RaisePropertyChanged("UserDebit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserEmail {
            get {
                return this.UserEmailField;
            }
            set {
                if ((object.ReferenceEquals(this.UserEmailField, value) != true)) {
                    this.UserEmailField = value;
                    this.RaisePropertyChanged("UserEmail");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserPassword {
            get {
                return this.UserPasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.UserPasswordField, value) != true)) {
                    this.UserPasswordField = value;
                    this.RaisePropertyChanged("UserPassword");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserServiceReference.IUserService")]
    public interface IUserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/AddUser", ReplyAction="http://tempuri.org/IUserService/AddUserResponse")]
        string AddUser(ExpenseManagementClient.UserServiceReference.UserModel user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/AddUser", ReplyAction="http://tempuri.org/IUserService/AddUserResponse")]
        System.Threading.Tasks.Task<string> AddUserAsync(ExpenseManagementClient.UserServiceReference.UserModel user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/LoginUser", ReplyAction="http://tempuri.org/IUserService/LoginUserResponse")]
        bool LoginUser(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/LoginUser", ReplyAction="http://tempuri.org/IUserService/LoginUserResponse")]
        System.Threading.Tasks.Task<bool> LoginUserAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUser", ReplyAction="http://tempuri.org/IUserService/GetUserResponse")]
        ExpenseManagementClient.UserServiceReference.UserModel GetUser(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUser", ReplyAction="http://tempuri.org/IUserService/GetUserResponse")]
        System.Threading.Tasks.Task<ExpenseManagementClient.UserServiceReference.UserModel> GetUserAsync(int userId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceChannel : ExpenseManagementClient.UserServiceReference.IUserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceClient : System.ServiceModel.ClientBase<ExpenseManagementClient.UserServiceReference.IUserService>, ExpenseManagementClient.UserServiceReference.IUserService {
        
        public UserServiceClient() {
        }
        
        public UserServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string AddUser(ExpenseManagementClient.UserServiceReference.UserModel user) {
            return base.Channel.AddUser(user);
        }
        
        public System.Threading.Tasks.Task<string> AddUserAsync(ExpenseManagementClient.UserServiceReference.UserModel user) {
            return base.Channel.AddUserAsync(user);
        }
        
        public bool LoginUser(string username, string password) {
            return base.Channel.LoginUser(username, password);
        }
        
        public System.Threading.Tasks.Task<bool> LoginUserAsync(string username, string password) {
            return base.Channel.LoginUserAsync(username, password);
        }
        
        public ExpenseManagementClient.UserServiceReference.UserModel GetUser(int userId) {
            return base.Channel.GetUser(userId);
        }
        
        public System.Threading.Tasks.Task<ExpenseManagementClient.UserServiceReference.UserModel> GetUserAsync(int userId) {
            return base.Channel.GetUserAsync(userId);
        }
    }
}
