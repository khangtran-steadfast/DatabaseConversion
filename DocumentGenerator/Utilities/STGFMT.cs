//
// Actionquote Holdings Pty Ltd Confidential
// =========================================
//
// Copyright 2015 Actionquote Holdings Pty Ltd
// All Rights Reserved
// 
// All information contained herein is, and remains the property of Actionquote Holdings Pty Ltd and its suppliers, 
// if any.  The intellectual and technical concepts contained herein are proprietary to Actionquote Holdings Pty Ltd 
// and its suppliers and may be covered patents, patents in process, and are protected by trade secret or copyright law.
//
// Dissemination of this information or reproduction of this material is strictly forbidden unless prior written permission 
// is obtained from Actionquote Holdings Pty Ltd.
//
namespace DocumentGenerator
{
    /// <summary>
    /// The STGFMT enumeration values specify the format of a storage object 
    /// and are used in the StgCreateStorageEx and StgOpenStorageEx functions 
    /// in the stgfmt parameter. This value, in combination with the value in 
    /// the riid parameter, is used to determine the file format and the 
    /// interface implementation to use.
    /// </summary>
    /// <remarks>
    /// You know what would be better than copying and pasting all these
    /// enum definitions from MSDN? If Structured Storage was built into the
    /// .NET API, that's what.
    /// </remarks>
    public enum STGFMT
    {
        /// <summary>
        /// Indicates that the file must be a compound file.
        /// </summary>
        STGFMT_STORAGE = 0,

        /// <summary>
        /// Not relevant to our purposes here.
        /// 
        /// Indicates that the file must not be a compound file. This element 
        /// is only valid when using the StgCreateStorageEx or StgOpenStorageEx 
        /// functions to access the NTFS file system implementation of the 
        /// IPropertySetStorage interface. Therefore, these functions return an 
        /// error if the riid parameter does not specify the IPropertySetStorage 
        /// interface, or if the specified file is not located on an NTFS file 
        /// system volume.
        /// </summary>
        STGFMT_FILE = 3,

        /// <summary>
        /// Not relevant to our purposes here.
        /// 
        /// Indicates that the system will determine the file type and use the 
        /// appropriate structured storage or property set implementation. This 
        /// value cannot be used with the StgCreateStorageEx function.
        /// </summary>
        STGFMT_ANY = 4,

        /// <summary>
        /// Not relevant to our purposes here.
        /// 
        /// Indicates that the file must be a compound file, and is similar to 
        /// the STGFMT_STORAGE flag, but indicates that the compound-file form 
        /// of the compound-file implementation must be used. God knows what this
        /// actually means, just use STGFMT_STORAGE.
        /// </summary>
        STGFMT_DOCFILE = 5 
    }
}