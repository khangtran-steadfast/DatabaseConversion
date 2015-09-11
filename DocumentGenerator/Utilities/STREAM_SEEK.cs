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
    public enum STREAM_SEEK
    {
        /// <summary>
        /// The new seek pointer is an offset relative to the beginning of the stream. 
        /// In this case, the dlibMove parameter is the new seek position relative to 
        /// the beginning of the stream.
        /// </summary>
        STREAM_SEEK_SET = 0,

        /// <summary>
        /// The new seek pointer is an offset relative to the current seek pointer 
        /// location. In this case, the dlibMove parameter is the signed displacement 
        /// from the current seek position.
        /// </summary>
        STREAM_SEEK_CUR = 1,

        /// <summary>
        /// The new seek pointer is an offset relative to the end of the stream. In 
        /// this case, the dlibMove parameter is the new seek position relative to the 
        /// end of the stream.
        /// </summary>
        STREAM_SEEK_END = 2
    }
}