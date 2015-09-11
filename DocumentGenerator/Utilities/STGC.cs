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
    /// Specifies the conditions for performing the commit operation in the IStorage::Commit and IStream::Commit methods.
    /// </summary>
    public enum STGC
    {
        /// <summary>
        /// You can specify this condition with STGC_CONSOLIDATE, or some combination of 
        /// the other three flags in this list of elements. Use this value mainly to make 
        /// your code more readable. 
        /// </summary>
        STGC_DEFAULT = 0,

        /// <summary>
        /// The commit operation can overwrite existing data to reduce overall space requirements.
        /// This value is not recommended for typical usage because it is not as robust 
        /// as the default value. In this case, it is possible for the commit operation 
        /// to fail after the old data is overwritten but before the new data is completely 
        /// committed. Then, neither the old version nor the new version of the storage 
        /// object will be intact.
        ///
        /// The following list shows the use cases for this value:
        /// * The user has indicated a willingness to risk losing the data.
        /// * The low-memory save sequence will be used to safely save the storage object 
        /// to a smaller file.
        /// * A previous commit returned STG_E_MEDIUMFULL but overwriting the existing 
        /// data would provide enough space to commit changes to the storage object.
        /// 
        /// Note: The commit operation checks for adequate space before any overwriting 
        /// occurs. Therefore, even with this value specified, if the commit operation 
        /// fails because of space requirements, the old data will remain safe. 
        ///
        /// It is possible however, for data loss to occur with the STGC_OVERWRITE value 
        /// specified, if the commit operation fails for any reason other than lack of 
        /// disk space. 
        /// </summary>
        STGC_OVERWRITE = 1,

        /// <summary>
        /// Prevents multiple users of a storage object from overwriting each other's changes.
        ///
        /// The commit operation occurs only if there have been no changes to the saved storage 
        /// object since the user most recently opened it. Therefore, the saved version of the 
        /// storage object is the same version that the user has been editing.
        ///
        /// If other users have changed the storage object, the commit operation fails and 
        /// returns the STG_E_NOTCURRENT value.
        /// 
        /// You can override this behavior by calling the IStorage::Commit or IStream::Commit 
        /// method again using the STGC_DEFAULT value. 
        /// </summary>
        STGC_ONLYIFCURRENT = 2,

        /// <summary>
        /// Commits the changes to a write-behind disk cache, but does not save the cache to 
        /// the disk.
        ///
        /// In a write-behind disk cache, the operation that writes to disk actually writes 
        /// to a disk cache, and therefore increasing performance. The cache is eventually 
        /// written to the disk, but usually not until after the write operation has already 
        /// returned.
        ///
        /// The performance increase comes at the expense of an increased risk of losing data 
        /// if a problem occurs before the cache is saved and the data in the cache is lost.
        ///
        /// If you do not specify this value, then committing changes to root-level storage 
        /// objects is robust even if a disk cache is used. The two-phase commit process 
        /// ensures that data is stored on the disk and not just to the disk cache. 
        /// </summary>
        STGC_DANGEROUSLYCOMMITMERELYTODISKCACHE = 4,
    }
}