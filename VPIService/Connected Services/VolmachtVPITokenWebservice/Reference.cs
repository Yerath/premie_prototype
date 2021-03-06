﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VPIService.VolmachtVPITokenWebservice {
    using System.Runtime.Serialization;
    using System;


    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CasResult", Namespace="http://www.colimbra.net/cas/")]
    [System.SerializableAttribute()]
    public partial class CasResult : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CategoryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string InfoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private VPIService.VolmachtVPITokenWebservice.CasResult InnerCasResultField;
        
        private bool HasSucceededField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Category {
            get {
                return this.CategoryField;
            }
            set {
                if ((object.ReferenceEquals(this.CategoryField, value) != true)) {
                    this.CategoryField = value;
                    this.RaisePropertyChanged("Category");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Code {
            get {
                return this.CodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CodeField, value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
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
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Info {
            get {
                return this.InfoField;
            }
            set {
                if ((object.ReferenceEquals(this.InfoField, value) != true)) {
                    this.InfoField = value;
                    this.RaisePropertyChanged("Info");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public VPIService.VolmachtVPITokenWebservice.CasResult InnerCasResult {
            get {
                return this.InnerCasResultField;
            }
            set {
                if ((object.ReferenceEquals(this.InnerCasResultField, value) != true)) {
                    this.InnerCasResultField = value;
                    this.RaisePropertyChanged("InnerCasResult");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public bool HasSucceeded {
            get {
                return this.HasSucceededField;
            }
            set {
                if ((this.HasSucceededField.Equals(value) != true)) {
                    this.HasSucceededField = value;
                    this.RaisePropertyChanged("HasSucceeded");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.colimbra.net/cas/", ConfigurationName="VolmachtVPITokenWebservice.TokenWebServiceSoap")]
    public interface TokenWebServiceSoap {
        
        // CODEGEN: Generating message contract since element name appKey from namespace http://www.colimbra.net/cas/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://www.colimbra.net/cas/RemoveToken", ReplyAction="*")]
        VPIService.VolmachtVPITokenWebservice.RemoveTokenResponse RemoveToken(VPIService.VolmachtVPITokenWebservice.RemoveTokenRequest request);
        
        // CODEGEN: Generating message contract since element name appKey from namespace http://www.colimbra.net/cas/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://www.colimbra.net/cas/GetToken", ReplyAction="*")]
        VPIService.VolmachtVPITokenWebservice.GetTokenResponse GetToken(VPIService.VolmachtVPITokenWebservice.GetTokenRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class RemoveTokenRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="RemoveToken", Namespace="http://www.colimbra.net/cas/", Order=0)]
        public VPIService.VolmachtVPITokenWebservice.RemoveTokenRequestBody Body;
        
        public RemoveTokenRequest() {
        }
        
        public RemoveTokenRequest(VPIService.VolmachtVPITokenWebservice.RemoveTokenRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.colimbra.net/cas/")]
    public partial class RemoveTokenRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string appKey;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string token;
        
        public RemoveTokenRequestBody() {
        }
        
        public RemoveTokenRequestBody(string appKey, string token) {
            this.appKey = appKey;
            this.token = token;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class RemoveTokenResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="RemoveTokenResponse", Namespace="http://www.colimbra.net/cas/", Order=0)]
        public VPIService.VolmachtVPITokenWebservice.RemoveTokenResponseBody Body;
        
        public RemoveTokenResponse() {
        }

        

        public RemoveTokenResponse(VPIService.VolmachtVPITokenWebservice.RemoveTokenResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.colimbra.net/cas/")]
    public partial class RemoveTokenResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public VPIService.VolmachtVPITokenWebservice.CasResult RemoveTokenResult;
        
        public RemoveTokenResponseBody() {
        }
        
        public RemoveTokenResponseBody(VPIService.VolmachtVPITokenWebservice.CasResult RemoveTokenResult) {
            this.RemoveTokenResult = RemoveTokenResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetTokenRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetToken", Namespace="http://www.colimbra.net/cas/", Order=0)]
        public VPIService.VolmachtVPITokenWebservice.GetTokenRequestBody Body;
        
        public GetTokenRequest() {
        }
        
        public GetTokenRequest(VPIService.VolmachtVPITokenWebservice.GetTokenRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.colimbra.net/cas/")]
    public partial class GetTokenRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string appKey;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string username;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string password;
        
        public GetTokenRequestBody() {
        }
        
        public GetTokenRequestBody(string appKey, string username, string password) {
            this.appKey = appKey;
            this.username = username;
            this.password = password;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetTokenResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetTokenResponse", Namespace="http://www.colimbra.net/cas/", Order=0)]
        public VPIService.VolmachtVPITokenWebservice.GetTokenResponseBody Body;
        
        public GetTokenResponse() {
        }
        
        public GetTokenResponse(VPIService.VolmachtVPITokenWebservice.GetTokenResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.colimbra.net/cas/")]
    public partial class GetTokenResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public VPIService.VolmachtVPITokenWebservice.CasResult GetTokenResult;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string token;
        
        public GetTokenResponseBody() {
        }
        
        public GetTokenResponseBody(VPIService.VolmachtVPITokenWebservice.CasResult GetTokenResult, string token) {
            this.GetTokenResult = GetTokenResult;
            this.token = token;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface TokenWebServiceSoapChannel : VPIService.VolmachtVPITokenWebservice.TokenWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TokenWebServiceSoapClient : System.ServiceModel.ClientBase<VPIService.VolmachtVPITokenWebservice.TokenWebServiceSoap>, VPIService.VolmachtVPITokenWebservice.TokenWebServiceSoap {
        
        public TokenWebServiceSoapClient() {
        }
        
        public TokenWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TokenWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TokenWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TokenWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        VPIService.VolmachtVPITokenWebservice.RemoveTokenResponse VPIService.VolmachtVPITokenWebservice.TokenWebServiceSoap.RemoveToken(VPIService.VolmachtVPITokenWebservice.RemoveTokenRequest request) {
            return base.Channel.RemoveToken(request);
        }
        
        public VPIService.VolmachtVPITokenWebservice.CasResult RemoveToken(string appKey, string token) {
            VPIService.VolmachtVPITokenWebservice.RemoveTokenRequest inValue = new VPIService.VolmachtVPITokenWebservice.RemoveTokenRequest();
            inValue.Body = new VPIService.VolmachtVPITokenWebservice.RemoveTokenRequestBody();
            inValue.Body.appKey = appKey;
            inValue.Body.token = token;
            VPIService.VolmachtVPITokenWebservice.RemoveTokenResponse retVal = ((VPIService.VolmachtVPITokenWebservice.TokenWebServiceSoap)(this)).RemoveToken(inValue);
            return retVal.Body.RemoveTokenResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        VPIService.VolmachtVPITokenWebservice.GetTokenResponse VPIService.VolmachtVPITokenWebservice.TokenWebServiceSoap.GetToken(VPIService.VolmachtVPITokenWebservice.GetTokenRequest request) {
            return base.Channel.GetToken(request);
        }
        
        public VPIService.VolmachtVPITokenWebservice.CasResult GetToken(string appKey, string username, string password, out string token) {
            VPIService.VolmachtVPITokenWebservice.GetTokenRequest inValue = new VPIService.VolmachtVPITokenWebservice.GetTokenRequest();
            inValue.Body = new VPIService.VolmachtVPITokenWebservice.GetTokenRequestBody();
            inValue.Body.appKey = appKey;
            inValue.Body.username = username;
            inValue.Body.password = password;
            VPIService.VolmachtVPITokenWebservice.GetTokenResponse retVal = ((VPIService.VolmachtVPITokenWebservice.TokenWebServiceSoap)(this)).GetToken(inValue);
            token = retVal.Body.token;
            return retVal.Body.GetTokenResult;
        }
    }
}
