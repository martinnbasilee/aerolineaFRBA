﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AerolineaFrba.Properties
{


    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
    {

        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));

        public static Settings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2014-01-01 00:00:00.000")]
        public string fechaDelSistema
        {
            get
            {
                return ((string)(this["fechaDelSistema"]));
            }
            set
            {
                this["fechaDelSistema"] = value;
            }
        }

        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        //Cuando tengamos la base posta, cambiar Initial Catalog=GD2C2015
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=localhost\\SQLSERVER2012;Initial Catalog=Pruebas;Integrated Security="+
            "False;User ID=gd;Password=gd2015")]
        
        public string GD1C2015ConnectionString
        {
            get
            {
                return ((string)(this["GD1C2015ConnectionString"]));
            }
        }
    }
}



        
