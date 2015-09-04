﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseConversion.Common {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DatabaseConversion.Common.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Blob already exists at &apos;{0}&apos;..
        /// </summary>
        internal static string BlobStoreProvider_ErrorBlobExists {
            get {
                return ResourceManager.GetString("BlobStoreProvider_ErrorBlobExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Category &apos;{0}&apos; contains invalid characters. Only alphanumeric characters are accepted..
        /// </summary>
        internal static string BlobStoreProvider_ErrorCategorySyntax {
            get {
                return ResourceManager.GetString("BlobStoreProvider_ErrorCategorySyntax", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid key &apos;{1}&apos;: {0}.
        /// </summary>
        internal static string BlobStoreProvider_ErrorInvalidKey {
            get {
                return ResourceManager.GetString("BlobStoreProvider_ErrorInvalidKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Name &apos;{0}&apos; contains invalid characters. Only alphanumeric characters, dot, underscore and dash are accepted..
        /// </summary>
        internal static string BlobStoreProvider_ErrorNameSyntax {
            get {
                return ResourceManager.GetString("BlobStoreProvider_ErrorNameSyntax", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot find blob at &apos;{0}&apos;.
        /// </summary>
        internal static string BlobStoreProvider_ErrorNotFound {
            get {
                return ResourceManager.GetString("BlobStoreProvider_ErrorNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot find field &apos;{0}&apos;.
        /// </summary>
        internal static string Database_ErrorFieldNotFound {
            get {
                return ResourceManager.GetString("Database_ErrorFieldNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot find primary key.
        /// </summary>
        internal static string Database_ErrorPKNotFound {
            get {
                return ResourceManager.GetString("Database_ErrorPKNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot find table &apos;{0}&apos;.
        /// </summary>
        internal static string Database_ErrorTableNotFound {
            get {
                return ResourceManager.GetString("Database_ErrorTableNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid value &apos;{1}&apos; for application setting &apos;{0}&apos;.
        /// </summary>
        internal static string Service_ErrorAppSetting {
            get {
                return ResourceManager.GetString("Service_ErrorAppSetting", resourceCulture);
            }
        }
    }
}
