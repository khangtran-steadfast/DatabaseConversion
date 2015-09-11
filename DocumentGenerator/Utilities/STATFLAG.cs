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
    /// The STATFLAG enumeration values indicate whether the method should try to 
    /// return a name in the pwcsName member of the STATSTG structure. The values 
    /// are used in the ILockBytes::Stat, IStorage::Stat, and IStream::Stat methods 
    /// to save memory when the pwcsName member is not required.
    /// </summary>
    enum STATFLAG {
        /// <summary>
        /// Requests that the statistics include the pwcsName member of the STATSTG structure.
        /// </summary>
        STATFLAG_DEFAULT   = 0,

        /// <summary>
        /// Requests that the statistics not include the pwcsName member of the STATSTG structure. 
        /// If the name is omitted, there is no need for the ILockBytes::Stat, IStorage::Stat, 
        /// and IStream::Stat methods methods to allocate and free memory for the string value of 
        /// the name, therefore the method reduces time and resources used in an allocation and 
        /// free operation.
        /// </summary>
        STATFLAG_NONAME    = 1,

        /// <summary>
        /// Not implemented.
        /// </summary>
        STATFLAG_NOOPEN    = 2 
    }
}