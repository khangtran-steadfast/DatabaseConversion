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
using System.Diagnostics.CodeAnalysis;

namespace DocumentGenerator
{
    /// <summary>
    /// specifies features of the storage object, such as sector size, in the StgCreateStorageEx and StgOpenStorageEx functions.
    /// </summary>
    struct STGOPTIONS
    {
        /// <summary>
        /// Weird summary courtesy of MSDN:
        /// Specifies the version of the STGOPTIONS structure. It is set to STGOPTIONS_VERSION.
        /// Note: When usVersion is set to 1, the ulSectorSize member can be set. This is useful 
        /// when creating a large-sector documentation file. However, when usVersion is set to 1, 
        /// the pwcsTemplateFile member cannot be used.
        ///
        /// In Windows 2000 and later:  STGOPTIONS_VERSION can be set to 1 for version 1.
        /// In Windows XP and later:  STGOPTIONS_VERSION can be set to 2 for version 2.
        /// For operating systems prior to Windows 2000:  STGOPTIONS_VERSION will be set to 0 
        /// for version 0.
        /// </summary>
        public ushort usVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Reserved for future use; must be zero.
        /// </summary>
        public ushort reserved
        {
            get;
            set;
        }

        /// <summary>
        /// Specifies the sector size of the storage object. The default is 512 bytes.
        /// </summary>
        public ulong ulSectorSize
        {
            get;
            set;
        }

        /// <summary>
        /// Specifies the name of a file whose Encrypted File System (EFS) metadata will be
        /// transferred to a newly created Structured Storage file. This member is valid only
        /// when STGFMT_DOCFILE is used with StgCreateStorageEx.
        /// 
        /// In Windows XP and later: The pwcsTemplateFile member is only valid if version 2 or
        /// later is specified in the usVersion member.
        /// </summary>
        public String pwcsTemplateFile
        {
            get;
            set;
        }
    }
}