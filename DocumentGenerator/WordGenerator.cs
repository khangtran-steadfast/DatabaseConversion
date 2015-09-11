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
using System.IO;
using Aspose.Words;
using Aspose.Words.Lists;
using System.Drawing;
using Aspose.Words.BuildingBlocks;
using Aspose.Words.Fields;
using System.Text.RegularExpressions;
using System.Globalization;
using Aspose.Words.Drawing;
using Aspose.Words.Tables;
using System.Collections;
using System.Reflection;

namespace DocumentGenerator
{
    /// <summary>
    /// WordGenerator Class
    /// </summary>
    public class WordGenerator
    {
        static WordGenerator()
        {
            Aspose.Words.License license = new Aspose.Words.License();
            license.SetLicense("Aspose.Total.lic");
        }

        /// <summary>
        /// Get BOA.dotx as embedded resourse.
        /// </summary>
        /// <returns>Document obeject</returns>
        public static Document GetBOADocumentTemplate()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string fileName = "DocumentGenerator.BOA.dotx";
            using (Stream stream = assembly.GetManifestResourceStream(fileName))
            {
                return new Document(stream);
            }
        }

        /// <summary>
        /// Generate the document 
        /// </summary>
        /// <param name="configData">object of ConfigurationData</param>
        /// <returns>stream object converted to byte array</returns>
        public static byte[] GenerateDoc(ConfigurationData configData)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            //Read BOA document template
            Document boaDocumentTemplate = GetBOADocumentTemplate(); 
                        
            //Declared a pol_particular_bookmark string to identify Is it a task or Invoice doc
            string polParticularBookmark="";
            string fsraNotice1Bookmark = "";
            string fsraNotice2Bookmark = "";
            string fsraNotice3Bookmark = "";
            string fsraAdviceBookmark = "";
            string fsraRecommendationBookmark = "";
            string branchLogoBookmark = "";

            MemoryStream newStream = null;
            if (configData.DocumentTemplate != null)
            {
                newStream = new MemoryStream(configData.DocumentTemplate);
            }

            // Read the document from the stream.
            Document doc = new Document(newStream);
            if (!string.IsNullOrWhiteSpace(configData.Notice1))
            {
                // Use the indexer of the Bookmarks collection to obtain the desired bookmark.
                Bookmark bookmarkNotice1 = doc.Range.Bookmarks[Bookmarks.FSRA_NOTICE1];
                if (bookmarkNotice1 != null)
                {
                    if (bookmarkNotice1.Name != null)
                    {
                        bookmarkNotice1.Name = Bookmarks.FSRA_NOTICE1;
                        bookmarkNotice1.Text = "";
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(configData.Notice2))
            {
                // Use the indexer of the Bookmarks collection to obtain the desired bookmark.
                Bookmark bookmarkNotice2 = doc.Range.Bookmarks[Bookmarks.FSRA_NOTICE2];
                if (bookmarkNotice2 != null)
                {
                    if (bookmarkNotice2.Name != null)
                    {
                        bookmarkNotice2.Name = Bookmarks.FSRA_NOTICE2;
                        bookmarkNotice2.Text = "";
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(configData.Notice3))
            {
                // Use the indexer of the Bookmarks collection to obtain the desired bookmark.
                Bookmark bookmarkNotice3 = doc.Range.Bookmarks[Bookmarks.FSRA_NOTICE3];
                if (bookmarkNotice3 != null)
                {
                    if (bookmarkNotice3.Name != null)
                    {
                        bookmarkNotice3.Name = Bookmarks.FSRA_NOTICE3;
                        bookmarkNotice3.Text = "";
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(configData.Recommendations))
            {
                // Use the indexer of the Bookmarks collection to obtain the desired bookmark.
                Bookmark bookmarkRecommendation = doc.Range.Bookmarks[Bookmarks.FSRA_RECOMMENDATIONS];
                if (bookmarkRecommendation != null)
                {
                    if (bookmarkRecommendation.Name != null)
                    {
                        bookmarkRecommendation.Name = Bookmarks.FSRA_RECOMMENDATIONS;
                        bookmarkRecommendation.Text = "";
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(configData.ScopeOfAdvice))
            {
                // Use the indexer of the Bookmarks collection to obtain the desired bookmark.
                Bookmark bookmarkNatureOfAdvice = doc.Range.Bookmarks[Bookmarks.FSRA_NATURE_OF_ADVICE];
                if (bookmarkNatureOfAdvice != null)
                {
                    if (bookmarkNatureOfAdvice.Name != null)
                    {
                        bookmarkNatureOfAdvice.Name = Bookmarks.FSRA_NATURE_OF_ADVICE;
                        bookmarkNatureOfAdvice.Text = "";
                    }
                }
            }
            InsertBlockAtBookamrk(boaDocumentTemplate, Bookmarks.BPLUS_PREMIUMS, doc, configData.DocType);

            //  The following statement produces BPLUS_SCHEDULE_3 and BPLUS_SCHEDULE_4
            // if the transaction type is CANCELLATION or ENDORSEMENT
            if (configData != null)
            {
                bool isCancellationOrEndorsement = configData.TransactionType.Equals("cancellation", StringComparison.OrdinalIgnoreCase)
                || configData.TransactionType.Equals("endorsement", StringComparison.OrdinalIgnoreCase);

                if (isCancellationOrEndorsement)
                {
                    if (configData.DocType == 1)
                    {
                        InsertBlockAtBookamrk(boaDocumentTemplate, Bookmarks.BPLUS_SCHEDULE, doc, 3);
                    }
                    else if (configData.DocType == 2)
                    {
                        InsertBlockAtBookamrk(boaDocumentTemplate, Bookmarks.BPLUS_SCHEDULE, doc, 4);
                    }
                }
                else
                {
                    InsertBlockAtBookamrk(boaDocumentTemplate, Bookmarks.BPLUS_SCHEDULE, doc, configData.DocType);
                }
            }
            else
            {
                InsertBlockAtBookamrk(boaDocumentTemplate, Bookmarks.BPLUS_SCHEDULE, doc, configData.DocType);
            }

            InsertBlockAtBookamrk(boaDocumentTemplate, Bookmarks.BPLUS_PARTICULARS, doc, configData.DocType);
            InsertBlockAtBookamrk(boaDocumentTemplate, Bookmarks.BPLUS_HEADER, doc, configData.DocType);
            InsertBlockAtBookamrk(boaDocumentTemplate, Bookmarks.BPLUS_PAYMENT, doc, configData.DocType);
            InsertBlockAtBookamrk(boaDocumentTemplate, Bookmarks.BPLUS_DUTYOFDISCLOSURE, doc, configData.DocType);

            if (!configData.IsCIP)
            {
                if (configData.BodyTemplate != null)
                {
                    MemoryStream newStream2 = null;
                    if (configData.BodyTemplate != null)
                    {
                        using (newStream2 = new MemoryStream(configData.BodyTemplate))
                        {
                            Document bodyDoc = new Document(newStream2);
                            InsertDocumentAtBookmark(Bookmarks.BPLUS_BODY, doc, bodyDoc);
                        }
                    }
                }
                else
                {
                    if (doc.Range.Bookmarks[Bookmarks.BPLUS_BODY] != null)
                    {
                        doc.Range.Bookmarks[Bookmarks.BPLUS_BODY].Text = "";
                    }
                }
            }

            for (int index = 0; index < doc.Range.Bookmarks.Count; index++)
            {
                Bookmark bookmark = doc.Range.Bookmarks[index];
                if (bookmark.Name == Bookmarks.POL_PARTICULARS)
                {
                    polParticularBookmark=bookmark.Name;
                }
                if (bookmark.Name == Bookmarks.FSRA_NOTICE1 || bookmark.Name == Bookmarks.AB_FSRA_NOTICE1)
                {
                    fsraNotice1Bookmark = bookmark.Name;
                }
                if (bookmark.Name == Bookmarks.FSRA_NOTICE2 || bookmark.Name == Bookmarks.AB_FSRA_NOTICE2)
                {
                    fsraNotice2Bookmark = bookmark.Name;
                }
                if (bookmark.Name == Bookmarks.FSRA_NOTICE3 || bookmark.Name == Bookmarks.AB_FSRA_NOTICE3)
                {
                    fsraNotice3Bookmark = bookmark.Name;
                }
                if (bookmark.Name == Bookmarks.FSRA_NATURE_OF_ADVICE || bookmark.Name == Bookmarks.AB_FSRA_NATURE_OF_ADVICE)
                {
                    fsraAdviceBookmark = bookmark.Name;
                }
                if (bookmark.Name == Bookmarks.FSRA_RECOMMENDATIONS || bookmark.Name == Bookmarks.AB_FSRA_RECOMMENDATIONS)
                {
                    fsraRecommendationBookmark = bookmark.Name;
                }
                if (bookmark.Name == Bookmarks.LOGO)
                {
                    branchLogoBookmark = bookmark.Name;
                }
                
                string bookmarkName = bookmark.Name;
                

                string key = null;

                if (TryGetKeyWithCorrectCase(configData.DocumentValues.Keys, bookmarkName, out key) && bookmarkName != Bookmarks.POL_PARTICULARS && bookmarkName != Bookmarks.FSRA_NATURE_OF_ADVICE && bookmarkName != Bookmarks.FSRA_RECOMMENDATIONS && bookmarkName != Bookmarks.FSRA_NOTICE1 && bookmarkName != Bookmarks.FSRA_NOTICE2 && bookmarkName != Bookmarks.FSRA_NOTICE3)
                {
                    string suffix = "";
                    string tempValue;
                    if (configData.DocumentValues[key] != "" && (bookmark.Text.EndsWith("\r") || bookmark.Text.EndsWith("\r\n")))
                    {
                        suffix = Environment.NewLine;
                    }
                  
                    try
                    {
                        tempValue = configData.DocumentValues[key] ?? "" + suffix;

                        //Checking if the bookmark is a having values in 'docValues[key]' if true than remove any RTF text and insert the clean text in the Document
                        if (!String.IsNullOrWhiteSpace(tempValue))
                        {
                            if (tempValue.StartsWith("{\rtf"))
                            {
                                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                                Byte[] stringBytes = encoding.GetBytes(tempValue);
                                LoadOptions loadOptions = new LoadOptions();
                                loadOptions.LoadFormat = Aspose.Words.LoadFormat.Rtf;
                                using (MemoryStream rtfStream = new MemoryStream(stringBytes))
                                {
                                    Document rtfDoc = new Document(rtfStream, loadOptions);
                                    InsertDocumentAtBookmark(tempValue, doc, rtfDoc);
                                }
                            }
                            else
                            {
                                DateTime dateResult;
                                decimal decResult;

                                // without this check first, DateTime.TryParse values like 16.5 results in true and interpreted as 16 May 
                                //So first do decimal.tryparse then datetime.tryparse
                                if (decimal.TryParse(tempValue, out decResult))
                                {
                                    bookmark.Text = tempValue;
                                }
                                else
                                {
                                    if (DateTime.TryParse(tempValue, out dateResult))
                                    {
                                        bookmark.Text = dateResult.ToString("dd/MM/yyyy");
                                    }
                                    else
                                    {
                                        bookmark.Text = tempValue;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        string temp = e.Message;
                        bookmark.Remove();
                    }
                }
            }

            // Get collection of all FieldStart nodes in the document.
            NodeCollection fieldStarts = doc.GetChildNodes(NodeType.FieldStart, true);

            // We will use regular expression to get name of DOCVARIABLE.
            Regex regex = new Regex("DOCVARIABLE\\s+(?<name>[^\\s\"]+)|(\"(?<name>[^\"]+)\").*");

            // Look through all the field starts for the DOCVARIABLE field start.
            foreach (FieldStart start in fieldStarts)
            {
                try
                {
                    // Check whether the FieldStart is start of DOCVARIABLE field.
                    if (start.FieldType.Equals(FieldType.FieldDocVariable))
                    {
                        // We should get field code.
                        // Field code is the text between FieldStart and FieldSeparator nodes.
                        string fieldCode = "";
                        Node currentNode = start;
                        try
                        {
                            while (!(currentNode == null || currentNode.NodeType.Equals(NodeType.FieldSeparator)))
                            {
                                if (currentNode.NodeType.Equals(NodeType.Run))
                                {
                                    fieldCode += ((Run)currentNode).Text;
                                }

                                currentNode = currentNode.NextSibling;
                            }
                        }
                        catch (Exception ex3)
                        {
                            throw ex3;
                        }
                        // Get name of the DOCVARIABLE.
                        Match match = regex.Match(fieldCode);

                        // Print name of the DOCVARIABLE. 
                        string docVarName = match.Groups["name"].Value;

                        if (docVarName.StartsWith("CI___", true, CultureInfo.CurrentCulture) && !configData.DocumentValues.ContainsKey(docVarName))
                        {
                            docVarName = docVarName.Substring(5);
                            if (configData.DocumentValues.ContainsKey("I___" + docVarName))
                            {
                                docVarName = "I___" + docVarName;
                            }
                        }

                        if (docVarName.StartsWith("UW___", true, CultureInfo.CurrentCulture))
                        {
                            docVarName = docVarName.Substring(5);
                        }
                        try
                        {
                            string keyWithCorrectCase = null;
                            string strValue = "";
                            DateTime dtResult;
                            if (TryGetKeyWithCorrectCase(configData.DocumentValues.Keys, docVarName, out keyWithCorrectCase))
                            {
                                if (DateTime.TryParse(configData.DocumentValues[keyWithCorrectCase], out dtResult) && (!configData.DocumentValues[keyWithCorrectCase].Contains(".")))
                                {
                                    strValue = dtResult.ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    strValue = configData.DocumentValues[keyWithCorrectCase];
                                }

                                if (docVarName == "pol_policy_number")
                                {
                                    doc.Variables[match.Groups["name"].Value] = strValue + "\t";
                                }
                                else
                                {
                                    doc.Variables[match.Groups["name"].Value] = strValue;
                                }
                            }
                            else
                            {
                                if (TryGetKeyWithCorrectCase(configData.DocumentValues.Keys, "I___" + docVarName, out keyWithCorrectCase))
                                {
                                    if (DateTime.TryParse(configData.DocumentValues[keyWithCorrectCase], out dtResult))
                                    {
                                        strValue = dtResult.ToString("dd/MM/yyyy");
                                    }
                                    else
                                    {
                                        strValue = configData.DocumentValues[keyWithCorrectCase];
                                    }

                                    doc.Variables[match.Groups["name"].Value] = strValue;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            /*
            if (hasMacros)
                ExecuteMacros(doc, path);
             */ 
            //Bookmarks for SOA (Scope of Advice)Workbook which also removes any rtf text from the bookmark
            #region SOA BookMarks
            if (fsraNotice1Bookmark == Bookmarks.FSRA_NOTICE1 || fsraNotice1Bookmark == Bookmarks.AB_FSRA_NOTICE1)
            {
                if (!string.IsNullOrWhiteSpace(configData.Notice1))
                {
                    try
                    {
                        LoadOptions loadOptions = new LoadOptions();
                        loadOptions.LoadFormat = Aspose.Words.LoadFormat.Html;

                        using (MemoryStream rtfStream = new MemoryStream(Encoding.UTF8.GetBytes(configData.Notice1)))
                        {
                            Document rtfDoc = new Document(rtfStream, loadOptions);
                            InsertDocumentAtBookmark(fsraNotice1Bookmark, doc, rtfDoc);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }


            if (fsraNotice2Bookmark == Bookmarks.FSRA_NOTICE2 || fsraNotice2Bookmark == Bookmarks.AB_FSRA_NOTICE2)
            {
                if (!string.IsNullOrWhiteSpace(configData.Notice2))
                {
                    try
                    {
                        LoadOptions loadOptions = new LoadOptions();
                        loadOptions.LoadFormat = Aspose.Words.LoadFormat.Html;

                        using (MemoryStream rtfStream = new MemoryStream(Encoding.UTF8.GetBytes(configData.Notice2)))
                        {
                            Document rtfDoc = new Document(rtfStream, loadOptions);
                            InsertDocumentAtBookmark(fsraNotice2Bookmark, doc, rtfDoc);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }

            if (fsraNotice3Bookmark == Bookmarks.FSRA_NOTICE3 || fsraNotice3Bookmark == Bookmarks.AB_FSRA_NOTICE3)
            {
                if (!string.IsNullOrWhiteSpace(configData.Notice3))
                {
                    try
                    {
                        LoadOptions loadOptions = new LoadOptions();
                        loadOptions.LoadFormat = Aspose.Words.LoadFormat.Html;

                        using (MemoryStream rtfStream = new MemoryStream(Encoding.UTF8.GetBytes(configData.Notice3)))
                        {
                            Document rtfDoc = new Document(rtfStream, loadOptions);
                            InsertDocumentAtBookmark(fsraNotice3Bookmark, doc, rtfDoc);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }

            if (fsraRecommendationBookmark == Bookmarks.FSRA_RECOMMENDATIONS || fsraRecommendationBookmark == Bookmarks.AB_FSRA_RECOMMENDATIONS)
            {
                if (!string.IsNullOrWhiteSpace(configData.Recommendations))
                {
                    try
                    {
                        LoadOptions loadOptions = new LoadOptions();
                        loadOptions.LoadFormat = Aspose.Words.LoadFormat.Html;

                        using (MemoryStream rtfStream = new MemoryStream(Encoding.UTF8.GetBytes(configData.Recommendations)))
                        {
                            Document rtfDoc = new Document(rtfStream, loadOptions);
                            InsertDocumentAtBookmark(fsraRecommendationBookmark, doc, rtfDoc);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
            if (fsraAdviceBookmark == Bookmarks.FSRA_NATURE_OF_ADVICE || fsraAdviceBookmark == Bookmarks.AB_FSRA_NATURE_OF_ADVICE)
            {
                if (!string.IsNullOrWhiteSpace(configData.ScopeOfAdvice))
                {
                    try
                    {
                        LoadOptions loadOptions = new LoadOptions();
                        loadOptions.LoadFormat = Aspose.Words.LoadFormat.Html;

                        using (MemoryStream rtfStream = new MemoryStream(Encoding.UTF8.GetBytes(configData.ScopeOfAdvice)))
                        {
                            Document rtfDoc = new Document(rtfStream, loadOptions);
                            InsertDocumentAtBookmark(fsraAdviceBookmark, doc, rtfDoc);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
            #endregion

            if (configData.Schedule != null && configData.Schedule.Length != 0)
            {
                try
                {
                    LoadOptions loadOptions = new LoadOptions();
                    loadOptions.LoadFormat = Aspose.Words.LoadFormat.Rtf;

                    using (MemoryStream rtfStream = new MemoryStream(configData.Schedule))
                    {
                        Document rtfDoc = new Document(rtfStream, loadOptions);
                        //Checking for creating a Task Doc or an Invoice
                        if (polParticularBookmark == Bookmarks.POL_PARTICULARS)
                            InsertDocumentAtBookmark(Bookmarks.POL_PARTICULARS, doc, rtfDoc);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }


            bool useSalesTeamLogo = false;
            switch (configData.DocType)
            {
                case 1:
                    if (configData.DocumentValues.ContainsKey(Bookmarks.SALTEA_USE_BILLING) && configData.DocumentValues[Bookmarks.SALTEA_USE_BILLING] == "True")
                        useSalesTeamLogo = true;
                    break;

                case 2:
                    if (configData.DocumentValues.ContainsKey(Bookmarks.SALTEA_USE_CLOSING) && configData.DocumentValues[Bookmarks.SALTEA_USE_CLOSING] == "True")
                        useSalesTeamLogo = true;
                    break;

                default:
                    if (configData.DocumentValues.ContainsKey(Bookmarks.SALTEA_USE_OTHER) && configData.DocumentValues[Bookmarks.SALTEA_USE_OTHER] == "True")
                        useSalesTeamLogo = true;
                    break;
            }
                                   
            // Insert Logo
            if (branchLogoBookmark == Bookmarks.LOGO)
            {
                string value = "";

                if (useSalesTeamLogo && configData.DocumentValues.ContainsKey(Bookmarks.SALTEA_LOGO))
                {
                    value = configData.DocumentValues[Bookmarks.SALTEA_LOGO];
                }

                if (string.IsNullOrEmpty(value))
                {
                    if (configData.DocumentValues.ContainsKey(Bookmarks.SAP_LOGO))
                    {
                        value = configData.DocumentValues[Bookmarks.SAP_LOGO];
                    }
                }

                if (string.IsNullOrEmpty(value))
                {
                    if (configData.DocumentValues.ContainsKey(Bookmarks.BRA_LOGO) && (doc.Variables[Bookmarks.BRA_DESC] == Bookmarks.ELECTRONIC || configData.DocType == 3 || configData.IsGenerateTaskDocument))
                    {
                        value = configData.DocumentValues[Bookmarks.BRA_LOGO];
                    }
                }
                    if (!string.IsNullOrEmpty(value))
                    {
                        string logoPath = path + "\\logos\\" + value;
                        if(File.Exists(logoPath))  
                            InsertImage(doc, Bookmarks.LOGO, logoPath);
                    }
            }

            if (configData.ShowWaterMark)
            {
                InsertWatermarkText(doc, Bookmarks.DRAFT);
            }

            try
            {
                doc.UpdateFields(); 
                doc.Range.UpdateFields();
            }
            catch (Exception)
            {
                // Error sometimes occurrs in Aspose when calling UpdateFields.
            }

            NodeCollection paragraphs = doc.GetChildNodes(NodeType.Paragraph, true);

            foreach (Paragraph para in paragraphs)
            {
                if (para.IsListItem)
                {
                    foreach (Node node in para.ChildNodes)
                    {
                        Run run = node as Run;

                        if (run != null)
                        {
                            bool runBeginsWithATab = run.Range.Text.Count() > 0 && run.Range.Text[0] == '\t';

                            if (runBeginsWithATab)
                            {
                                run.Text = run.Range.Text.Remove(0, 1);
                            }
                        }
                    }
                }
            }

            MemoryStream stream = new MemoryStream();
            doc.BuiltInDocumentProperties.LastSavedTime = DateTime.UtcNow;
            try
            {
                doc.UpdateFields();
            }
            catch (Exception)
            {
                // Error sometimes occurrs in Aspose when calling UpdateFields.
            }
            doc.AcceptAllRevisions();

            if (configData.IsCIP)
            {
                if (configData.BodyTemplate != null)
                {
                    MemoryStream newStream2 = null;
                    if (configData.BodyTemplate != null)
                    {
                        using (newStream2 = new MemoryStream(configData.BodyTemplate))
                        {
                            Document bodyDoc = new Document(newStream2);
                            InsertDocumentAtBookmark(Bookmarks.BPLUS_BODY, doc, bodyDoc);
                        }
                    }
                }
                else
                {
                    if (doc.Range.Bookmarks[Bookmarks.BPLUS_BODY] != null)
                    {
                        doc.Range.Bookmarks[Bookmarks.BPLUS_BODY].Text = "";
                    }
                }

            }
                       
            try
            {
                if (configData.LockDocument)
                {
                    doc.Protect(ProtectionType.ReadOnly);
                }

                if (configData.IsGenerateTaskDocument && doc.ProtectionType == ProtectionType.AllowOnlyFormFields)
                {
                    doc.Unprotect();
                    doc.Protect(ProtectionType.AllowOnlyFormFields, "BOA1234"); 
                }

                // Save the document to the memory stream.
                switch (configData.Format)
                {
                    case "pdf":
                        doc.Save(stream, SaveFormat.Pdf);
                        break;
                    default:
                        doc.Save(stream, SaveFormat.Doc);
                        break;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return stream.ToArray();
        }

        /// <summary>
        /// check whether the inputkey exists in DocumentValues.
        /// </summary>
        /// <param name="keyValues">documentvalues</param>
        /// <param name="inputKey">key to search</param>
        /// <param name="inputKeyWithCorrectCase">output param</param>
        /// <returns>true whether key exists</returns>
        private static bool TryGetKeyWithCorrectCase(IEnumerable<string> keyValues, string inputKey, out string inputKeyWithCorrectCase)
        {
            if (
                inputKey.StartsWith("ai_", true, CultureInfo.CurrentCulture)
                || inputKey.StartsWith("ae_", true, CultureInfo.CurrentCulture)
                )
            {
                inputKey = "ab_" + inputKey.Substring(3);
            }
            
            foreach (string key in keyValues)
            {
                if (key.Equals(inputKey, StringComparison.OrdinalIgnoreCase))
                {
                    inputKeyWithCorrectCase = key;
                    return true;
                }
            }

            //if we don't find the inputkey and starts with the ai,ae,ab prefix remove the prefix and search for it
            if (inputKey.StartsWith("ab_", true, CultureInfo.CurrentCulture))
            {
                inputKey = inputKey.Substring(3);
            }
            else
            {
                //if we didn't find the inputkey then ad ab_ to see if its an attv key
                inputKey = "ab_" + inputKey;
            }

            foreach (string key in keyValues)
            {
                if (key.Equals(inputKey, StringComparison.OrdinalIgnoreCase))
                {
                    inputKeyWithCorrectCase = key;
                    return true;
                }
            }
            

            inputKeyWithCorrectCase = null;
            return false;
        }

        /* Macros - need to ask 
        private static void ExecuteMacros(Document document, string path)
        {
            Assembly assembly;

            try
            {
                //
                // Attempt to load any custom macro dll.
                //
                assembly = Assembly.LoadFile(path + "\\CustomMacros\\Macros.dll");
            }
            catch (Exception)
            {
                //
                // Error loading custom macro, use default macro dll isntead.
                //
                Macros.Macros macro = new Macros.Macros();
                macro.ExecuteMacros(document);
                return;
            }
            Type [] types = assembly.GetTypes();
            Type type = assembly.GetType("Macros.Macros");
            object runnable = Activator.CreateInstance(type);

            type.InvokeMember("ExecuteMacros", BindingFlags.Default | BindingFlags.InvokeMethod, null, runnable, new object[] { document});

            runnable = null;
        }
         */ 

        /// <summary>
        /// Functon to move to next cell in document.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="currentCell"></param>
        /// <returns></returns>
        private static Cell MoveToNextCell(DocumentBuilder builder, Cell currentCell)
        {
            Cell nextCell;

            // Get current row, where the current cell is located.
            Row currentRow = currentCell.ParentRow;

            // Get current table
            Table currentTable = currentRow.ParentTable;

            if (currentCell.NextSibling != null)
            {
                nextCell = (Cell)currentCell.NextSibling;
            }
            else
            {
                if (currentRow.NextSibling == null)
                {
                    // And new row to the table.
                    currentTable.Rows.Add(currentRow.Clone(true));
                    currentRow = currentTable.LastRow;
                }
                else
                {
                    currentRow = (Row)currentRow.NextSibling;
                }

                nextCell = currentRow.FirstCell;
            }

            // Remove old value
            nextCell.RemoveAllChildren();
            nextCell.EnsureMinimum();

            // Move DocumentBuilder cursor to the cell
            builder.MoveTo(nextCell.FirstParagraph);

            return nextCell;
        }

        private static void InsertWatermarkText(Document doc, string watermarkText)
        {
            // Create a watermark shape. This will be a WordArt shape.
            // You are free to try other shape types as watermarks.
            Shape watermark = new Shape(doc, ShapeType.TextPlainText);

            // Set up the text of the watermark.
            watermark.TextPath.Text = watermarkText;
            watermark.TextPath.FontFamily = "Arial Black";
            // Font size does not have effect if you specify height of the shape.
            // So you can just specify height instead of specifying font size.
            double fontSize = 280;
            watermark.Height = fontSize;
            // Widht of each leter is aproximately half of font size.
            // So we can use thefollowing formula to calculate widht of the shape (approximately).
            watermark.Width = watermarkText.Length * fontSize / 2 - 25;

            // Text will be directed from the bottom-left to the top-right corner.
            watermark.Rotation = 60;
            watermark.Font.Outline = true;
            // Remove the following two lines if you need a solid black text.
            //watermark.Fill.Color = Color.LightGray; // Try LightGray to get more Word-style watermark
            //watermark.StrokeColor = Color.LightGray; // Try LightGray to get more Word-style watermark

            // Place the watermark in the page center.
            watermark.RelativeHorizontalPosition = RelativeHorizontalPosition.Page;
            watermark.RelativeVerticalPosition = RelativeVerticalPosition.Page;
            watermark.WrapType = WrapType.None;
            watermark.VerticalAlignment = VerticalAlignment.Center;
            watermark.HorizontalAlignment = HorizontalAlignment.Center;

            // Create a new paragraph and append the watermark to this paragraph.
            Paragraph watermarkPara = new Paragraph(doc);
            watermarkPara.AppendChild(watermark);

            // Insert the watermark into all headers of each document section.
            foreach (Section sect in doc.Sections)
            {
                // There could be up to three different headers in each section, since we want
                // the watermark to appear on all pages, insert into all headers.
                InsertWatermarkIntoHeader(watermarkPara, sect, HeaderFooterType.HeaderPrimary);
                InsertWatermarkIntoHeader(watermarkPara, sect, HeaderFooterType.HeaderFirst);
                InsertWatermarkIntoHeader(watermarkPara, sect, HeaderFooterType.HeaderEven);
            }
        }

        private static void InsertWatermarkIntoHeader(Paragraph watermarkPara, Section sect, HeaderFooterType headerType)
        {
            HeaderFooter header = sect.HeadersFooters[headerType];

            if (header == null)
            {
                // There is no header of the specified type in the current section, create it.
                header = new HeaderFooter(sect.Document, headerType);
                sect.HeadersFooters.Add(header);
            }

            // Insert a clone of the watermark into the header.
            header.AppendChild(watermarkPara.Clone(true));
        }

        /// <summary>
        /// Convert text to Docx
        /// </summary>
        /// <param name="text">string value</param>
        /// <param name="font">font name</param>
        /// <returns>byte array</returns>
        public static byte[] ConvertTextToDocx(string text, string font)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                DocumentBuilder builder = new DocumentBuilder();

                builder.Writeln(text);

                if (font != "")
                {
                    foreach (Style style in builder.Document.Styles)
                    {
                        if (style.Font != null)
                        {
                            style.Font.ClearFormatting();
                            style.Font.Size = 10;
                            style.Font.Name = font;
                        }
                    }

                    //Get collection of runs and set the same formating
                    NodeCollection runs = builder.Document.GetChildNodes(NodeType.Run, true);
                    foreach (Run run in runs)
                    {
                        run.Font.ClearFormatting();
                        run.Font.Size = 10;
                        run.Font.Name = font;
                    }
                }

                builder.Document.Save(stream, SaveFormat.Docx);

                return stream.ToArray();
            }
        }

        

        /// <summary>
        /// Convert RTF to Docx.
        /// </summary>
        /// <param name="rtf">rtf</param>
        /// <param name="isSunriseSchedule"></param>
        /// <returns>byte array</returns>
        public static byte[] ConvertRTFToDocx(string rtf, bool isSunriseSchedule = false)
        {
            try
            {
                using (MemoryStream rtfStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(rtf)))
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        Document rtfDoc = new Document(rtfStream);
                        rtfDoc.Save(stream, SaveFormat.Docx);
                        return stream.ToArray();
                    }
                }
            }
            catch (Exception e)
            {
                if (isSunriseSchedule)
                    throw new Exception(Bookmarks.SunriseInvalidScheduleErrorMessage);
                else
                    throw (e);
            }
        }

        /// <summary>
        /// Convert RTF to Html.
        /// </summary>
        /// <param name="rtf"></param>
        /// <returns></returns>
        public static string ConvertRtfToHtml(string rtf)
        {
            using (MemoryStream rtfStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(rtf)))
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    Document rtfDoc = new Document(rtfStream);
                    rtfDoc.Save(stream, SaveFormat.Html);
                    stream.Position = 0;
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }

        /// <summary>
        /// Convert Docx to rtf.
        /// </summary>
        /// <param name="mainDoc"></param>
        /// <returns></returns>
        public static string ConvertDocxToRTF(byte[] mainDoc)
        {
            try
            {
                using (MemoryStream docStream = new MemoryStream(mainDoc))
                {
                    using (MemoryStream stream = new MemoryStream())
                    {

                        Document doc = new Document(docStream);
                        doc.Save(stream, SaveFormat.Rtf);

                        return ASCIIEncoding.Default.GetString(stream.ToArray());
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Insert document at given Bookmark in main document.
        /// </summary>
        /// <param name="bookmarkName">name of the bookmark where the merge document is inserted. (byte array)</param>
        /// <param name="mainDocument">main document in which the merge document is inserted.(byte array)</param>
        /// <param name="mergedDocument">this is inserted in main doc.</param>
        /// <returns>obejct contains the main doc and merge doc.</returns>
        public static byte[] InsertDocumentAtBookamrk(string bookmarkName, byte[] mainDocument, byte[] mergedDocument)
        {
            using (MemoryStream newStream = new MemoryStream(mainDocument))
            {
                using (MemoryStream newStream2 = new MemoryStream(mergedDocument))
                {

                    // Read the document from the stream.
                    Document mainDoc = new Document(newStream);

                    // Read the document from the stream.
                    Document mergedDoc = new Document(newStream2);

                    InsertDocumentAtBookmark(bookmarkName, mainDoc, mergedDoc);

                    using (MemoryStream stream = new MemoryStream())
                    {
                        mainDoc.Save(stream, SaveFormat.Docx);

                        return stream.ToArray();
                    }
                }
            }
        }

        /// <summary>
        /// Insert document at given Bookmark in main document.
        /// </summary>
        /// <param name="bookmarkName">name of the bookmark where the merge document is inserted. (Document)</param>
        /// <param name="mainDocument">main document in which the merge document is inserted.(Document)</param>
        /// <param name="mergedDocument">this is inserted in main doc.</param>
        /// <returns>obejct contains the main doc and merge doc.</returns>
        public static void InsertDocumentAtBookmark(string bookmarkName, Document docDest, Document docSrc)
        {

            Bookmark bookmark = docDest.Range.Bookmarks[bookmarkName];
            if(bookmark != null)
                InsertDocument(bookmark.BookmarkStart.ParentNode, docSrc);

        }

        /// <summary>
        /// Inserts content of the external document after the specified node.
        /// Section breaks and section formatting of the inserted document are ignored.
        /// </summary>
        /// <param name="insertAfterNode">Node in the destination document after which the content 
        /// should be inserted. This node should be a block level node (paragraph or table).</param>
        /// <param name="srcDoc">The document to insert.</param>
        static void InsertDocument(Node insertAfterNode, Document srcDoc)
        {
            try
            {
                // Make sure that the node is either a paragraph or table.
                if ((!insertAfterNode.NodeType.Equals(NodeType.Paragraph)) &
                  (!insertAfterNode.NodeType.Equals(NodeType.Table)))
                    throw new ArgumentException("The destination node should be either a paragraph or table.");

                // We will be inserting into the parent of the destination paragraph.
                CompositeNode dstStory = insertAfterNode.ParentNode;

                // This object will be translating styles and lists during the import.
                NodeImporter importer = new NodeImporter(srcDoc, insertAfterNode.Document, ImportFormatMode.KeepSourceFormatting);

                // Loop through all sections in the source document.
                foreach (Section srcSection in srcDoc.Sections)
                {
                    // Loop through all block level nodes (paragraphs and tables) in the body of the section.
                    foreach (Node srcNode in srcSection.Body)
                    {
                        // Let's skip the node if it is a last empty paragraph in a section.
                        if (srcNode.NodeType.Equals(NodeType.Paragraph))
                        {
                            Paragraph para = (Paragraph)srcNode;
                            if (para.IsEndOfSection && !para.HasChildNodes)
                                continue;
                        }

                        // This creates a clone of the node, suitable for insertion into the destination document.
                        Node newNode = importer.ImportNode(srcNode, true);

                        // Insert new node after the reference node.
                        dstStory.InsertAfter(newNode, insertAfterNode);
                        insertAfterNode = newNode;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
 
        public static void InsertBlockAtBookamrk(Document brokerPlusDot, string bookmarkName, Document MainDoc, int type)
        {
          
            BuildingBlock block = null;
            string bmark = type == 0 ? bookmarkName.ToUpper() : (bookmarkName.ToUpper() + "_" + type.ToString());

                foreach (BuildingBlock b in brokerPlusDot.GlossaryDocument.BuildingBlocks)
                {
                    if (b.Name.ToUpper() == bmark)
                    {
                        block = b;
                        break;
                    }
                }
                       //Create DocumentBuilder 
            DocumentBuilder builder = new DocumentBuilder(MainDoc);
            //Move cursor to bookmark and insert paragraph break 
            if (!builder.MoveToBookmark(bookmarkName, false, true) || block == null)
            {
                return;
            }
            //builder.MoveToBookmark(bookmarkName);
            builder.Writeln();
            //Content of srcdoc will be inserted after this node 
            Node insertAfterNode = builder.CurrentParagraph.PreviousSibling;
            //Content of first paragraph of srcDoc will be apended to this parafraph 
            Paragraph insertAfterParagraph = (Paragraph)insertAfterNode;
            //Content of last paragraph of srcDoc will be apended to this parafraph 
            Paragraph insertBeforeParagraph = builder.CurrentParagraph;
            //We will be inserting into the parent of the destination paragraph. 
            CompositeNode dstStory = insertAfterNode.ParentNode;

            //Get list if current paragraph is list item
            List list = null;
            Color listFontColor = Color.Black;
            if (insertAfterParagraph.IsListItem)
            {
                list = insertAfterParagraph.ListFormat.List;
                listFontColor = insertAfterParagraph.ListFormat.ListLevel.Font.Color;
            }
            //Loop through all sections in the source document. 
            foreach (Section srcSection in block.Sections)
            {
                //Loop through all block level nodes (paragraphs and tables) in the body of the section. 
                foreach (Node srcNode in srcSection.Body)
                {
                    //Do not insert node if it is a last empty paragarph in the section. 
                    Paragraph para = srcNode as Paragraph;

                    //If current paragraph is first paragraph of srcDoc 
                    //then appent its content to insertAfterParagraph 
                    if (para != null && (para.Equals(block.FirstSection.Body.FirstParagraph)))
                    {
                        Paragraph dstParagraph = (Paragraph)MainDoc.ImportNode(para, true, ImportFormatMode.KeepSourceFormatting);
                        while (dstParagraph.HasChildNodes)
                        {
                            //Node dstNode = MainDoc.ImportNode(node, true, ImportFormatMode.KeepSourceFormatting);
                            insertAfterParagraph.AppendChild(dstParagraph.FirstChild);
                        }

                        if (!insertAfterParagraph.IsListItem && dstParagraph.IsListItem)
                        {
                            if (list == null)
                            {
                                list = dstParagraph.ListFormat.List;
                            }
                            insertAfterParagraph.ListFormat.List = list;
                            listFontColor = para.ListFormat.ListLevel.Font.Color;

                        }
                        //If subdocument contains only one paragraph 
                        //then copy content of insertBeforeParagraph to insertAfterParagraph 
                        //and remove insertBeforeParagraph 
                        if ((block.FirstSection.Body.FirstParagraph.Equals(block.LastSection.Body.LastParagraph)))
                        {
                            while ((insertBeforeParagraph.HasChildNodes))
                            {
                                insertAfterParagraph.AppendChild(insertBeforeParagraph.FirstChild);
                            }
                            insertBeforeParagraph.Remove();
                        }
                    }
                    //If current paragraph is last paragraph of srcDoc 
                    //then appent its content to insertBeforeParagraph 
                    else if (para != null && (para.Equals(block.LastSection.Body.LastParagraph)))
                    {
                        Node tofix;
                        Node previouseNode = null;
                        foreach (Node node in para.ChildNodes)
                        {
                            Node dstNode = MainDoc.ImportNode(node, true, ImportFormatMode.KeepSourceFormatting);
                            if ((previouseNode == null))
                            {
                                //insertBeforeParagraph.InsertBefore(dstNode, insertBeforeParagraph.FirstChild);
                                tofix = insertBeforeParagraph.InsertBefore(dstNode, insertBeforeParagraph.FirstChild);
                            }
                            else
                            {
                                //insertBeforeParagraph.InsertAfter(dstNode, previouseNode);
                                tofix = insertBeforeParagraph.InsertAfter(dstNode, previouseNode);
                            }
                            previouseNode = dstNode;

                            // If last paragraph to be inserted is not numbering, then remove Numbering
                            if ((!para.IsListItem) && ((Paragraph)dstNode.ParentNode).IsListItem)
                            {
                                ((Paragraph)tofix.ParentNode).ListFormat.RemoveNumbers();
                            }
                            // Apply numbering according to the collected List
                            else
                            {
                                insertBeforeParagraph.ListFormat.List = list;
                            }
                        }
                        // insertBeforeParagraph.ListFormat.List = list;
                    }
                    else
                    {
                        //This creates a clone of the node, suitable for insertion into the destination document. 

                        Node newNode = MainDoc.ImportNode(srcNode, true, ImportFormatMode.KeepSourceFormatting);

                        //Set list if it is needed
                        if (newNode.NodeType == NodeType.Paragraph)
                        {
                            if (((Paragraph)newNode).IsListItem && list != null)
                            {
                                ((Paragraph)newNode).ListFormat.List = list;
                            }
                        }

                        //Insert new node after the reference node. 
                        dstStory.InsertAfter(newNode, insertAfterNode);
                        insertAfterNode = newNode;
                    }
                }
            }

            //Clear formating of list
            if (list != null)
            {
                foreach (ListLevel level in list.ListLevels)
                {
                    level.Font.Color = listFontColor;
                    level.Font.Bold = false;
                    level.NumberPosition = 0;
                }
            }
            MainDoc.Range.Bookmarks[bookmarkName].Text = "";
        }

        /// <summary>
        /// Append all docs in a list into one doc.
        /// </summary>
        /// <param name="AllDocs">list of all docs</param>
        /// <returns>one doc contains all docs.</returns>
        public static byte[] AppendDoc(List<Byte[]> AllDocs)
        {
            // MemoryStream newStream = new MemoryStream();
            Document masterDocument = new Document();

            foreach (Byte[] doc in AllDocs)
            {
                using (MemoryStream childStream = new MemoryStream(doc))
                {
                    Document child = new Document(childStream);
                    foreach (Section section in child.Sections)
                    {
                        Section dstSection = (Section)masterDocument.ImportNode(section, true, ImportFormatMode.UseDestinationStyles);
                        masterDocument.Sections.Add(dstSection);
                    }
                }
            }

            using (MemoryStream finalStream = new MemoryStream())
            {
                masterDocument.Save(finalStream, SaveFormat.Doc);
                return finalStream.GetBuffer();
            }
        }

        /// <summary>
        /// Function to generate the Body Document.
        /// </summary>
        /// <param name="bodyTemplate"></param>
        /// <param name="schedule"></param>
        /// <param name="notice1"></param>
        /// <param name="recommendation"></param>
        /// <param name="natureOfAdvice"></param>
        /// <param name="documentValues"></param>
        /// <param name="draft"></param>
        /// <param name="saveFormat"></param>
        /// <returns></returns>
        public static byte[] GenerateBodyDoc(byte[] bodyTemplate, byte[] schedule, byte[] notice1, byte[] recommendation, byte[] natureOfAdvice,
            Tuple<Dictionary<string, string>, Dictionary<string, string[,]>> documentValues, bool draft, SaveFormat saveFormat)
        {
            Dictionary<string, string> docValues = documentValues.Item1;
            Dictionary<string, string[,]> docArrayValues = documentValues.Item2;

            MemoryStream newStream = null;
            if (bodyTemplate != null)
            {
                newStream = new MemoryStream(bodyTemplate);
            }
            

            // Read the document from the stream.
            Document doc = new Document(newStream);

            for (int index = 0; index < doc.Range.Bookmarks.Count; index++)
            {
                Bookmark bookmark = doc.Range.Bookmarks[index];
                string bookmarkName = bookmark.Name;
                if (
                            bookmarkName.StartsWith("ai_", true, CultureInfo.CurrentCulture)
                            || bookmarkName.StartsWith("ae_", true, CultureInfo.CurrentCulture)
                            || bookmarkName.StartsWith("ab_", true, CultureInfo.CurrentCulture)
                            )
                {
                    bookmarkName = bookmarkName.Substring(3);
                }

                string caseCorrectKey;
                if (TryGetKeyWithCorrectCase(docValues.Keys, bookmarkName, out caseCorrectKey) && bookmarkName != Bookmarks.POL_PARTICULARS)  //if (docValues.ContainsKey(bookmarkName) && bookmarkName != "pol_particulars")               
                {
                    string suffix = "";
                    string tempValue;
                    if (docValues[caseCorrectKey] != "" && (bookmark.Text.EndsWith("\r") || bookmark.Text.EndsWith("\r\n")))
                    {
                        suffix = Environment.NewLine;
                    }

                    try
                    {
                        tempValue = docValues[caseCorrectKey] ?? "" + suffix;

                        if (String.IsNullOrWhiteSpace(bookmark.Text))
                        {
                            bookmark.Text = tempValue;
                        }
                    }
                    catch (Exception e)
                    {
                        string temp = e.Message;
                        bookmark.Remove();
                    }
                }

                string correctKey;
                if (TryGetKeyWithCorrectCase(docArrayValues.Keys, bookmarkName, out correctKey) && bookmarkName != Bookmarks.POL_PARTICULARS) //(docArrayValues.ContainsKey(bookmarkName) && bookmarkName != "pol_particulars")
                {
                    if (((Paragraph)bookmark.BookmarkStart.ParentNode).ParentNode.NodeType == NodeType.Cell)
                    {
                        DocumentBuilder builder = new DocumentBuilder(doc);
                        builder.MoveToBookmark(bookmark.Name);
                        Cell currentCell = (Cell)builder.CurrentParagraph.GetAncestor(NodeType.Cell);

                        string[,] data = docArrayValues[correctKey];

                        for (int rowIndex = 0; rowIndex <= data.GetUpperBound(0); rowIndex++)
                        {
                            for (int colIndex = 0; colIndex <= data.GetUpperBound(1); colIndex++)
                            {
                                if (data[rowIndex, colIndex] != null)
                                {
                                    builder.Write(data[rowIndex, colIndex]);
                                    if (!(rowIndex == data.GetUpperBound(0) && colIndex == data.GetUpperBound(1)))
                                    {
                                        currentCell = MoveToNextCell(builder, currentCell);
                                    }
                                }
                                else
                                {
                                    if (!(rowIndex == data.GetUpperBound(0) && colIndex == data.GetUpperBound(1)))
                                    {
                                        currentCell = MoveToNextCell(builder, currentCell);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // Get collection of all FieldStart nodes in the document.
            NodeCollection fieldStarts = doc.GetChildNodes(NodeType.FieldStart, true);

            // We will use regular expression to get name of DOCVARIABLE.
            Regex regex = new Regex("DOCVARIABLE\\s+(?<name>[^\\s\"]+)|(\"(?<name>[^\"]+)\").*");

            // Look through all the field starts for the DOCVARIABLE field start.
            foreach (FieldStart start in fieldStarts)
            {
                try
                {
                  
                    // Check whether the FieldStart is start of DOCVARIABLE field.
                    if (start.FieldType.Equals(FieldType.FieldDocVariable))
                    {
                        // We should get field code.
                        // Field code is the text between FieldStart and FieldSeparator nodes.
                        string fieldCode = "";

                        Node currentNode = start;

                        try
                        {
                            while (!(currentNode == null || currentNode.NodeType.Equals(NodeType.FieldSeparator)))
                            {
                                if (currentNode.NodeType.Equals(NodeType.Run))
                                {
                                    fieldCode += ((Run)currentNode).Text;
                                }

                                currentNode = currentNode.NextSibling;
                            }
                        }
                        catch (Exception ex3)
                        {
                            throw ex3;
                        }

                        // Get name of the DOCVARIABLE.
                        Match match = regex.Match(fieldCode);

                        // Print name of the DOCVARIABLE. 
                        string docVarName = match.Groups["name"].Value;
                        if (
                            docVarName.StartsWith("ai_", true, CultureInfo.CurrentCulture)
                            || docVarName.StartsWith("ae_", true, CultureInfo.CurrentCulture)
                            || docVarName.StartsWith("ab_", true, CultureInfo.CurrentCulture)
                            )
                        {
                            docVarName = docVarName.Substring(3);
                        }
                        string keyA;
                        if (docVarName.StartsWith("CI___", true, CultureInfo.CurrentCulture) && !TryGetKeyWithCorrectCase(docValues.Keys, docVarName, out keyA))//docValues.ContainsKey(docVarName))
                        {
                            docVarName = docVarName.Substring(5);

                            string keyD;
                            if (TryGetKeyWithCorrectCase(docValues.Keys, "I___" + docVarName, out keyD)) // (docValues.ContainsKey("I___" + docVarName))
                            {
                                docVarName = keyD;
                            }
                        }
                        try
                        {
                            string keyB;
                            if (TryGetKeyWithCorrectCase(docValues.Keys, docVarName, out keyB) && docValues[keyB] != null)//(docValues.ContainsKey(docVarName) && docValues[docVarName] != null)
                            {
                                doc.Variables[match.Groups["name"].Value] = docValues[keyB];
                            }
                            else
                            {
                                string keyC;
                                if (TryGetKeyWithCorrectCase(docValues.Keys, "I___" + docVarName, out keyC) && docValues[keyC] != null) //(docValues.ContainsKey("I___" + docVarName) && docValues[docVarName] != null)
                                {
                                    doc.Variables[match.Groups["name"].Value] = docValues[keyC];
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            doc.UpdateFields();

            if (schedule  != null && schedule.Count() > 0)
            {
                try
                {

                    using (MemoryStream rtfStream = new MemoryStream(schedule))
                    {
                        Document rtfDoc = new Document(rtfStream);
                        InsertDocumentAtBookmark(Bookmarks.POL_PARTICULARS, doc, rtfDoc);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            if (notice1 != null && notice1.Count() > 0)
            {
                try
                {

                    using (MemoryStream rtfStream = new MemoryStream(notice1))
                    {
                        Document rtfDoc = new Document(rtfStream);
                        InsertDocumentAtBookmark(Bookmarks.FSRA_NOTICE1, doc, rtfDoc);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            if (draft)
            {
                InsertWatermarkText(doc,Bookmarks.DRAFT);
            }

            using (MemoryStream stream = new MemoryStream())
            {

                try
                {
                    doc.Save(stream, saveFormat);
                }
                catch (Exception e)
                {
                    throw e;
                }

                return stream.ToArray();
            }
        }

        public static byte[] GenerateFinalCIPDoc(byte[] docTemplate, byte[] bodyTemplate, Tuple<Dictionary<string, string>, Dictionary<string, string[,]>> documentValues,
            byte[] schedule, int docType, string path, string format, bool draft, int scheduleType)
        {

            Document boaDocumentTemplate = GetBOADocumentTemplate();

            MemoryStream newStream = null;
            if (bodyTemplate != null)
            {
                newStream = new MemoryStream(bodyTemplate);
            }
            

            // Read the document from the stream.
            Document doc = new Document(newStream);

            InsertBlockAtBookamrk(boaDocumentTemplate, Bookmarks.BPLUS_PREMIUMS, doc, docType);
            InsertBlockAtBookamrk(boaDocumentTemplate, Bookmarks.BPLUS_SCHEDULE, doc, scheduleType);
            InsertBlockAtBookamrk(boaDocumentTemplate, Bookmarks.BPLUS_PARTICULARS, doc, docType);
            InsertBlockAtBookamrk(boaDocumentTemplate, Bookmarks.FSRA_NOTICE1, doc, docType);
            InsertBlockAtBookamrk(boaDocumentTemplate, Bookmarks.BPLUS_HEADER, doc, docType);
            InsertBlockAtBookamrk(boaDocumentTemplate, Bookmarks.BPLUS_PAYMENT, doc, docType);
            InsertBlockAtBookamrk(boaDocumentTemplate, Bookmarks.BPLUS_DUTYOFDISCLOSURE, doc, 0);

            // Save Document after adding BookMark and call 
            MemoryStream middleStream = new MemoryStream();
            doc.Save(middleStream, SaveFormat.Doc);

            docTemplate = GenerateBodyDoc(middleStream.GetBuffer(), null,null,null,null, documentValues, false, SaveFormat.Doc);
            newStream = new MemoryStream(docTemplate);
            doc = new Document(newStream);

    
            if (bodyTemplate != null)
            {
                MemoryStream rtfStream = new MemoryStream(bodyTemplate);
                Document rtfDoc = new Document(rtfStream);
                InsertDocumentAtBookmark(Bookmarks.BPLUS_BODY, doc, rtfDoc);
            }
            else
            {
                if (doc.Range.Bookmarks[Bookmarks.BPLUS_BODY] != null)
                {
                    doc.Range.Bookmarks[Bookmarks.BPLUS_BODY].Text = "";
                }
            }
          
            
            if (schedule  != null)
            {
                MemoryStream rtfStream = new MemoryStream(schedule);
                Document rtfDoc = new Document(rtfStream);
                InsertDocumentAtBookmark(Bookmarks.POL_PARTICULARS, doc, rtfDoc);
            }
            
            if (draft)
            {
                InsertWatermarkText(doc,Bookmarks.DRAFT);
            }

            MemoryStream stream = new MemoryStream();
            doc.BuiltInDocumentProperties.LastSavedTime = DateTime.UtcNow;
            doc.UpdateFields();
            doc.AcceptAllRevisions();
            try
            {
                // Save the document to the memory stream.
                switch (format)
                {
                    case "pdf":
                        doc.Save(stream, SaveFormat.Pdf);
                        break;
                    default:
                        doc.Save(stream, SaveFormat.Doc);
                        break;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return stream.GetBuffer();
        }

        public static byte[] ConvertDocToPDF(byte[] docTemplate)
        {
            using (MemoryStream newStream = new MemoryStream(docTemplate))
            {
                Document doc = new Document(newStream);
                using (MemoryStream stream = new MemoryStream())
                {
                    try
                    {
                        doc.Save(stream, SaveFormat.Pdf);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }

                    return stream.GetBuffer();
                }
            }
        }
		
		 public static string ConveryDocToPDFMobile(string docFullPath, string docName)
        {
            Aspose.Words.Document doc1 = new Aspose.Words.Document(docFullPath);
            doc1.Save(docFullPath.Replace(".doc", ".pdf"));
            return docName.Replace(".doc", ".pdf");
        }

        public static byte[] ConvertDocToDocx(byte[] docTemplate)
        {
            using (MemoryStream newStream = new MemoryStream(docTemplate))
            {
                Document doc = new Document(newStream);
                using (MemoryStream stream = new MemoryStream())
                {
                    try
                    {
                        doc.Save(stream, SaveFormat.Docx);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }

                    return stream.GetBuffer();
                }
            }
        }

        public static void InsertImage(Document mainDoc,string bookmarkName, string path)
        {
            DocumentBuilder builder = new DocumentBuilder(mainDoc);
            if (mainDoc.Range.Bookmarks[bookmarkName] != null)
            {
                mainDoc.Range.Bookmarks[bookmarkName].Text = "";
            }
            builder.MoveToBookmark(bookmarkName);
            builder.InsertImage(path); 
        }

    }
}
