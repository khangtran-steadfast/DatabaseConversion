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
using System.Linq;
using System.Text;

namespace DocumentGenerator
{
    public class ConfigurationData
    {
        public string TransactionType { get; set; }
         public byte[] DocumentTemplate { get; set; }
        public byte[] BodyTemplate { get; set; }
        public byte[] Schedule { get; set; }
        public string Notice1 { get; set; }
        public string Notice2 { get; set; }
        public string Notice3 { get; set; }
        public string Recommendations { get; set; }
        public string ScopeOfAdvice { get; set; }
        public Dictionary<string, string> DocumentValues { get; set; }
        public int DocType { get; set; }
        public string Format { get; set; }
        public bool Draft { get; set; }
        public bool HasMacros { get; set; }
        public bool ShowWaterMark { get; set; }

        private bool _isCIP = false;
        public bool IsCIP
        {
            get { return _isCIP; }
            set { _isCIP = value; }
        }

        private bool _lockDocument = false;
        public bool LockDocument
        {
            get { return _lockDocument; }
            set { _lockDocument = value; }
        }

        private bool _isGenerateTaskDocument = false;
        public bool IsGenerateTaskDocument
        {
            get { return _isGenerateTaskDocument; }
            set { _isGenerateTaskDocument = value; }
        }
    }
}
