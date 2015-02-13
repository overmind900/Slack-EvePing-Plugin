﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace SlackEvePingPlugin
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class SlackEvePingEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new SlackEvePingEntities object using the connection string found in the 'SlackEvePingEntities' section of the application configuration file.
        /// </summary>
        public SlackEvePingEntities() : base("name=SlackEvePingEntities", "SlackEvePingEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new SlackEvePingEntities object.
        /// </summary>
        public SlackEvePingEntities(string connectionString) : base(connectionString, "SlackEvePingEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new SlackEvePingEntities object.
        /// </summary>
        public SlackEvePingEntities(EntityConnection connection) : base(connection, "SlackEvePingEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<UserMapping> UserMappings
        {
            get
            {
                if ((_UserMappings == null))
                {
                    _UserMappings = base.CreateObjectSet<UserMapping>("UserMappings");
                }
                return _UserMappings;
            }
        }
        private ObjectSet<UserMapping> _UserMappings;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the UserMappings EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToUserMappings(UserMapping userMapping)
        {
            base.AddObject("UserMappings", userMapping);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="SlackEvePingModel", Name="UserMapping")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class UserMapping : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new UserMapping object.
        /// </summary>
        /// <param name="userID">Initial value of the UserID property.</param>
        public static UserMapping CreateUserMapping(global::System.String userID)
        {
            UserMapping userMapping = new UserMapping();
            userMapping.UserID = userID;
            return userMapping;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                if (_UserID != value)
                {
                    OnUserIDChanging(value);
                    ReportPropertyChanging("UserID");
                    _UserID = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("UserID");
                    OnUserIDChanged();
                }
            }
        }
        private global::System.String _UserID;
        partial void OnUserIDChanging(global::System.String value);
        partial void OnUserIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String KeyID
        {
            get
            {
                return _KeyID;
            }
            set
            {
                OnKeyIDChanging(value);
                ReportPropertyChanging("KeyID");
                _KeyID = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("KeyID");
                OnKeyIDChanged();
            }
        }
        private global::System.String _KeyID;
        partial void OnKeyIDChanging(global::System.String value);
        partial void OnKeyIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String vCode
        {
            get
            {
                return _vCode;
            }
            set
            {
                OnvCodeChanging(value);
                ReportPropertyChanging("vCode");
                _vCode = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("vCode");
                OnvCodeChanged();
            }
        }
        private global::System.String _vCode;
        partial void OnvCodeChanging(global::System.String value);
        partial void OnvCodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> LastPing
        {
            get
            {
                return _LastPing;
            }
            set
            {
                OnLastPingChanging(value);
                ReportPropertyChanging("LastPing");
                _LastPing = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastPing");
                OnLastPingChanged();
            }
        }
        private Nullable<global::System.DateTime> _LastPing;
        partial void OnLastPingChanging(Nullable<global::System.DateTime> value);
        partial void OnLastPingChanged();

        #endregion

    
    }

    #endregion

    
}