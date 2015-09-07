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
    /// (All documentation for this enum taken from MSDN [http://msdn.microsoft.com/en-us/library/aa380336(VS.85).aspx])
    /// 
    /// The STGMOVE enumeration values indicate whether a storage element is to
    /// be moved or copied. They are used in the IStorage.MoveElementTo method.
    /// </summary>
    public enum STGMOVE
    {
        /// <summary>
        /// Indicates that the method should move the data from the source to the destination.
        /// </summary>
        STGMOVE_MOVE = 0,

        /// <summary>
        /// Indicates that the method should copy the data from the source to the destination. 
        /// A copy is the same as a move except that the source element is not removed after 
        /// copying the element to the destination. Copying an element on top of itself is 
        /// undefined.
        /// </summary>
        STGMOVE_COPY = 1,

        /// <summary>
        /// Not implemented.
        /// </summary>
        STGMOVE_SHALLOWCOPY = 2
    }
}