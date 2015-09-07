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
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace DocumentGenerator
{
    [ComImport]
    [Guid("0000000b-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IStorage
    {
        /// <summary>
        /// Creates and opens a stream object with the specified name contained in this storage object. 
        /// The name must not exceed 31 characters in length (not including the string terminator). 
        /// The 000 through 01f characters, serving as the first character of the stream/storage name, 
        /// are reserved for use by OLE. This is a compound file restriction, not a structured storage 
        /// restriction.
        /// </summary>
        /// <param name="pwcsName">A pointer to a wide character null-terminated Unicode string that 
        /// contains the name of the newly created stream. The name can be used later to open or 
        /// reopen the stream. The name must not exceed 31 characters in length, not including the 
        /// string terminator. The 000 through 01f characters, serving as the first character of the 
        /// stream/storage name, are reserved for use by OLE. This is a compound file restriction, 
        /// not a structured storage restriction.</param>
        /// <param name="grfMode">Specifies the access mode to use when opening the newly created 
        /// stream. For more information and descriptions of the possible values, see STGM Constants.
        /// </param>
        /// <param name="reserved1">Reserved for future use; must be zero.</param>
        /// <param name="reserved2">Reserved for future use; must be zero.</param>
        /// <param name="ppstm">On return, pointer to the location of the new IStream interface pointer.
        /// This is only valid if the operation is successful. When an error occurs, this parameter is 
        /// set to NULL.</param>
        void CreateStream(
            /* [string][in] */ string pwcsName,
            /* [in] */ uint grfMode,
            /* [in] */ uint reserved1,
            /* [in] */ uint reserved2,
            /* [out] */ out IStream ppstm);

        void OpenStream(
            /* [string][in] */ string pwcsName,
            /* [unique][in] */ IntPtr reserved1,
            /* [in] */ uint grfMode,
            /* [in] */ uint reserved2,
            /* [out] */ out IStream ppstm);

        void CreateStorage(
            /* [string][in] */ string pwcsName,
            /* [in] */ uint grfMode,
            /* [in] */ uint reserved1,
            /* [in] */ uint reserved2,
            /* [out] */ out IStorage ppstg);

        void OpenStorage(
            /* [string][unique][in] */ string pwcsName,
            /* [unique][in] */ IStorage pstgPriority,
            /* [in] */ uint grfMode,
            /* [unique][in] */ IntPtr snbExclude,
            /* [in] */ uint reserved,
            /* [out] */ out IStorage ppstg);
        /*
        /// <summary>
        /// Copies the entire contents of an open storage object to another storage object.
        /// </summary>
        /// <param name="ciidExclude">The number of elements in the array pointed to by rgiidExclude. If rgiidExclude is NULL, then ciidExclude is ignored.</param>
        /// <param name="rgiidExclude">An array of interface identifiers (IIDs) that either the caller knows about and does not want copied or that the storage object does not support, but whose state the caller will later explicitly copy. The array can include IStorage, indicating that only stream objects are to be copied, and IStream, indicating that only storage objects are to be copied. An array length of zero indicates that only the state exposed by the IStorage object is to be copied; all other interfaces on the object are to be ignored. Passing NULL indicates that all interfaces on the object are to be copied.</param>
        /// <param name="snbExclude">A string name block (refer to SNB) that specifies a block of storage or stream objects that are not to be copied to the destination. These elements are not created at the destination. If IID_IStorage is in the rgiidExclude array, this parameter is ignored. This parameter may be NULL.</param>
        /// <param name="pstgDest">A pointer to the open storage object into which this storage object is to be copied. The destination storage object can be a different implementation of the IStorage interface from the source storage object. Thus, IStorage::CopyTo can use only publicly available methods of the destination storage object. If pstgDest is open in transacted mode, it can be reverted by calling its IStorage::Revert method.</param>
        void CopyTo(
            //[in]
            uint ciidExclude,
            // [size_is][unique][in] 
            Guid rgiidExclude, // should this be an array?
            // [unique][in] 
            IntPtr snbExclude,
            // [unique][in] IStorage pstgDest);
        */

        /// <summary>
        /// Copies the entire contents of an open storage object to another storage object. Overloaded to allow parameters 1 & 2 to accept "null" (the C# equivalent of C/C++ null is IntPtr.Zero)
        /// </summary>
        /// <param name="ciidExclude">The number of elements in the array pointed to by rgiidExclude. If rgiidExclude is NULL, then ciidExclude is ignored.</param>
        /// <param name="rgiidExclude">An array of interface identifiers (IIDs) that either the caller knows about and does not want copied or that the storage object does not support, but whose state the caller will later explicitly copy. The array can include IStorage, indicating that only stream objects are to be copied, and IStream, indicating that only storage objects are to be copied. An array length of zero indicates that only the state exposed by the IStorage object is to be copied; all other interfaces on the object are to be ignored. Passing NULL indicates that all interfaces on the object are to be copied.</param>
        /// <param name="snbExclude">A string name block (refer to SNB) that specifies a block of storage or stream objects that are not to be copied to the destination. These elements are not created at the destination. If IID_IStorage is in the rgiidExclude array, this parameter is ignored. This parameter may be NULL.</param>
        /// <param name="pstgDest">A pointer to the open storage object into which this storage object is to be copied. The destination storage object can be a different implementation of the IStorage interface from the source storage object. Thus, IStorage::CopyTo can use only publicly available methods of the destination storage object. If pstgDest is open in transacted mode, it can be reverted by calling its IStorage::Revert method.</param>
        void CopyTo(
            /* [in] */ IntPtr ciidExclude,
            /* [size_is][unique][in] */ IntPtr rgiidExclude, // should this be an array?
            /* [unique][in] */ IntPtr snbExclude,
            /* [unique][in] */ IStorage pstgDest);

        /// <summary>
        /// Copies or moves a substorage or stream from this storage object to another storage object.
        /// </summary>
        /// <param name="pwcsName">The name of the element in this storage object to be moved or copied</param>
        /// <param name="pstgDest">The destination storage object.</param>
        /// <param name="pwcsNewName">The new name for the element in its new storage object.</param>
        /// <param name="grfFlags">Specifies whether the operation should be a move (STGMOVE_MOVE) 
        /// or a copy (STGMOVE_COPY). See the STGMOVE enumeration.</param>
        /// <seealso cref="STGMOVE"/>
        void MoveElementTo(
            /* [string][in] */ string pwcsName,
            /* [unique][in] */ IStorage pstgDest,
            /* [string][in] */ string pwcsNewName,
            /* [in] */ uint grfFlags);

        void Commit(
            /* [in] */ uint grfCommitFlags);

        void Revert();

        void EnumElements(
            /* [in] */ uint reserved1,
            /* [size_is][unique][in] */ IntPtr reserved2,
            /* [in] */ uint reserved3,
            /* [out] */ out IEnumSTATSTG ppenum);

        /// <summary>
        /// Removes the specified storage or stream from this storage object.
        /// </summary>
        /// <param name="pwcsName">A pointer to a wide character null-terminated Unicode string 
        /// that contains the name of the storage or stream to be removed.</param>
        void DestroyElement(
            /* [string][in] */ string pwcsName);

        void RenameElement(
            /* [string][in] */ string pwcsOldName,
            /* [string][in] */ string pwcsNewName);

        void SetElementTimes(
            /* [string][unique][in] */ string pwcsName,
            /* [unique][in] */ System.Runtime.InteropServices.ComTypes.FILETIME pctime,
            /* [unique][in] */ System.Runtime.InteropServices.ComTypes.FILETIME patime,
            /* [unique][in] */ System.Runtime.InteropServices.ComTypes.FILETIME pmtime);

        void SetClass(
            /* [in] */ Guid clsid);

        void SetStateBits(
            /* [in] */ uint grfStateBits,
            /* [in] */ uint grfMask);

        void Stat(
            /* [out] */ out System.Runtime.InteropServices.ComTypes.STATSTG pstatstg,
            /* [in] */ uint grfStatFlag);

    }
}
