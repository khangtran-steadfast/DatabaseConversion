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
    public class WordGenerator
    {
        static WordGenerator()
        {
            Aspose.Words.License license = new Aspose.Words.License();
            license.SetLicense("Aspose.Total.lic");
        }

        static Document GetBOADOTX()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            const string NAME = "DocumentGenerator.BOA.dotx";
            using (Stream stream = assembly.GetManifestResourceStream(NAME))
            {
                return new Document(stream);
            }
        }


        public static byte[] GenerateDoc(
            byte[] docTemplate, byte[] bodyTemplate, byte[] particularsRTF, string notice1, string notice2, string notice3,
            string recommendations, string scopeOfAdvice,
            Dictionary<string, string> documentValues, int docType, string format, 
            bool draft, 
            bool hasMacros, bool showWaterMark, ConfigurationData configData, bool IsCIP = false, bool lockDocument = false, bool IsGenerateTaskDocument = false)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            Document boaDot = GetBOADOTX(); 
            Dictionary<string, string> docValues = documentValues;
            
            //Declared a pol_particular_bookmark string to identify Is it a task or Invoice doc
            string pol_particular_bookmark="";
            string Fsra_Notice_1_bookmark = "";
            string Fsra_Notice_2_bookmark = "";
            string Fsra_Notice_3_bookmark = "";
            string Fsra_advice_bookmark = "";
            string Fsra_recommendation_bookmark = "";
            string branch_logo_bookmark = "";

            MemoryStream newStream = null;
            if (docTemplate != null)
                newStream = new MemoryStream(docTemplate);

            // Read the document from the stream.
            Document doc = new Document(newStream);
            if (!string.IsNullOrWhiteSpace(notice1))
            {
                // Use the indexer of the Bookmarks collection to obtain the desired bookmark.
                Bookmark bookmark_notice1 = doc.Range.Bookmarks["fsra_notice1"];
                if (bookmark_notice1 != null)
                {
                    if (bookmark_notice1.Name != null)
                    {
                        bookmark_notice1.Name = "fsra_notice1";
                        bookmark_notice1.Text = "";
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(notice2))
            {
                // Use the indexer of the Bookmarks collection to obtain the desired bookmark.
                Bookmark bookmark_notice2 = doc.Range.Bookmarks["fsra_notice2"];
                if (bookmark_notice2 != null)
                {
                    if (bookmark_notice2.Name != null)
                    {
                        bookmark_notice2.Name = "fsra_notice2";
                        bookmark_notice2.Text = "";
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(notice3))
            {
                // Use the indexer of the Bookmarks collection to obtain the desired bookmark.
                Bookmark bookmark_notice3 = doc.Range.Bookmarks["fsra_notice3"];
                if (bookmark_notice3 != null)
                {
                    if (bookmark_notice3.Name != null)
                    {
                        bookmark_notice3.Name = "fsra_notice3";
                        bookmark_notice3.Text = "";
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(recommendations))
            {
                // Use the indexer of the Bookmarks collection to obtain the desired bookmark.
                Bookmark bookmark_recommendation = doc.Range.Bookmarks["fsra_recommendations"];
                if (bookmark_recommendation != null)
                {
                    if (bookmark_recommendation.Name != null)
                    {
                        bookmark_recommendation.Name = "fsra_recommendations";
                        bookmark_recommendation.Text = "";
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(scopeOfAdvice))
            {
                // Use the indexer of the Bookmarks collection to obtain the desired bookmark.
                Bookmark bookmark_nature_of_advice = doc.Range.Bookmarks["fsra_nature_of_advice"];
                if (bookmark_nature_of_advice != null)
                {
                    if (bookmark_nature_of_advice.Name != null)
                    {
                        bookmark_nature_of_advice.Name = "fsra_nature_of_advice";
                        bookmark_nature_of_advice.Text = "";
                    }
                }
            }
            InsertBlockAtBookamrk(boaDot, "Bplus_Premiums", doc, docType);

            //  The following statement produces BPLUS_SCHEDULE_3 and BPLUS_SCHEDULE_4
            // if the transaction type is CANCELLATION or ENDORSEMENT
            if (configData != null)
            {
                bool isCancellationOrEndorsement = configData.TransactionType.Equals("cancellation", StringComparison.OrdinalIgnoreCase)
                || configData.TransactionType.Equals("endorsement", StringComparison.OrdinalIgnoreCase);

                if (isCancellationOrEndorsement)
                {
                    if (docType == 1)
                        InsertBlockAtBookamrk(boaDot, "BPLUS_SCHEDULE", doc, 3);
                    else if (docType == 2)
                        InsertBlockAtBookamrk(boaDot, "BPLUS_SCHEDULE", doc, 4);
                }
                else
                {
                    InsertBlockAtBookamrk(boaDot, "BPLUS_SCHEDULE", doc, docType);
                }
            }
            else
            {
                InsertBlockAtBookamrk(boaDot, "BPLUS_SCHEDULE", doc, docType);
            }

            InsertBlockAtBookamrk(boaDot, "BPLUS_PARTICULARS", doc, docType);
            InsertBlockAtBookamrk(boaDot, "BPLUS_HEADER", doc, docType);
            InsertBlockAtBookamrk(boaDot, "BPLUS_PAYMENT ", doc, docType);
            InsertBlockAtBookamrk(boaDot, "BPLUS_DUTYOFDISCLOSURE", doc, docType);

            if (!IsCIP)
            {
                if (bodyTemplate != null)
                {
                    MemoryStream newStream2 = null;
                    if (bodyTemplate != null)
                    {
                        using (newStream2 = new MemoryStream(bodyTemplate))
                        {
                            Document bodyDoc = new Document(newStream2);
                            InsertDocumentAtBookmark("BPLUS_BODY", doc, bodyDoc);
                        }
                    }
                }
                else
                {
                    if (doc.Range.Bookmarks["BPLUS_BODY"] != null)
                        doc.Range.Bookmarks["BPLUS_BODY"].Text = "";
                }
            }

            for (int index = 0; index < doc.Range.Bookmarks.Count; index++)
            {
                Bookmark bookmark = doc.Range.Bookmarks[index];
                if(bookmark.Name=="pol_particulars")
                {
                    pol_particular_bookmark=bookmark.Name;
                }
                if (bookmark.Name == "fsra_notice1" || bookmark.Name == "ab_fsra_notice1")
                {
                    Fsra_Notice_1_bookmark = bookmark.Name;
                }
                if (bookmark.Name == "fsra_notice2" || bookmark.Name == "ab_fsra_notice2")
                {
                    Fsra_Notice_2_bookmark = bookmark.Name;
                }
                if (bookmark.Name == "fsra_notice3" || bookmark.Name == "ab_fsra_notice3")
                {
                    Fsra_Notice_3_bookmark = bookmark.Name;
                }
                if (bookmark.Name == "fsra_nature_of_advice" || bookmark.Name == "ab_fsra_nature_of_advice")
                {
                    Fsra_advice_bookmark = bookmark.Name;
                }
                if (bookmark.Name == "fsra_recommendations" || bookmark.Name == "ab_fsra_recommendations")
                {
                    Fsra_recommendation_bookmark = bookmark.Name;
                }
                if (bookmark.Name == "logo")
                {
                    branch_logo_bookmark = bookmark.Name;
                }
                
                string bookmarkName = bookmark.Name;
                

                string key = null;

                if (TryGetKeyWithCorrectCase(docValues.Keys, bookmarkName, out key) && bookmarkName != "pol_particulars" && bookmarkName != "fsra_nature_of_advice" && bookmarkName != "fsra_recommendations" && bookmarkName != "fsra_notice1" && bookmarkName != "fsra_notice2" && bookmarkName != "fsra_notice3")
                {
                    string suffix = "";
                    string tempValue;
                    if (docValues[key] != "" && (bookmark.Text.EndsWith("\r") || bookmark.Text.EndsWith("\r\n")))
                    {
                        suffix = Environment.NewLine;
                    }
                  
                    try
                    {
                        tempValue = docValues[key] ?? "" + suffix;

                        //Checking if the bookmark is a having values in 'docValues[key]' if true than remove any RTF text and insert the clean text in the Document
                        if (!String.IsNullOrWhiteSpace(tempValue))
                        {
                            if (tempValue.StartsWith("{\rtf"))
                            {
                                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                                Byte[] Stringbytes = encoding.GetBytes(tempValue);
                                LoadOptions loadOptions = new LoadOptions();
                                loadOptions.LoadFormat = Aspose.Words.LoadFormat.Rtf;
                                using (MemoryStream rtfStream = new MemoryStream(Stringbytes))
                                {
                                    Document rtfDoc = new Document(rtfStream, loadOptions);
                                    InsertDocumentAtBookmark(tempValue, doc, rtfDoc);
                                }
                            }
                            else
                            {
                                DateTime dateResult;
                                decimal decResult;

                                //Tony, 13/08/12: without this check first, DateTime.TryParse values like 16.5 results in true and interpreted as 16 May 
                                //So first do decimal.tryparse then datetime.tryparse
                                if (decimal.TryParse(tempValue, out decResult))
                                    bookmark.Text = tempValue;
                                else
                                    if (DateTime.TryParse(tempValue, out dateResult))
                                        bookmark.Text = dateResult.ToString("dd/MM/yyyy");
                                    else
                                        bookmark.Text = tempValue;
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
                                    fieldCode += ((Run)currentNode).Text;

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
                        
                        if (docVarName.StartsWith("CI___", true, CultureInfo.CurrentCulture) && !docValues.ContainsKey(docVarName))
                        {
                            docVarName = docVarName.Substring(5);
                            if (docValues.ContainsKey("I___" + docVarName))
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
                            if (TryGetKeyWithCorrectCase(docValues.Keys, docVarName, out keyWithCorrectCase))
                            {
                                if (DateTime.TryParse(docValues[keyWithCorrectCase], out dtResult) && (!docValues[keyWithCorrectCase].Contains(".")))
                                    strValue = dtResult.ToString("dd/MM/yyyy");
                                else
                                    strValue = docValues[keyWithCorrectCase];
                                
                                if (docVarName == "pol_policy_number")
                                    doc.Variables[match.Groups["name"].Value] = strValue + "\t";
                                else
                                    doc.Variables[match.Groups["name"].Value] = strValue;
                            }
                            else
                            {
                                if (TryGetKeyWithCorrectCase(docValues.Keys, "I___" + docVarName, out keyWithCorrectCase))
                                {
                                    if (DateTime.TryParse(docValues[keyWithCorrectCase], out dtResult))
                                        strValue = dtResult.ToString("dd/MM/yyyy");
                                    else
                                        strValue = docValues[keyWithCorrectCase];

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
            if (Fsra_Notice_1_bookmark == "fsra_notice1" || Fsra_Notice_1_bookmark == "ab_fsra_notice1")
            {
                if (!string.IsNullOrWhiteSpace(notice1))
                {
                    try
                    {
                        LoadOptions loadOptions = new LoadOptions();
                        loadOptions.LoadFormat = Aspose.Words.LoadFormat.Html;

                        using (MemoryStream rtfStream = new MemoryStream(Encoding.UTF8.GetBytes(notice1)))
                        {
                            Document rtfDoc = new Document(rtfStream, loadOptions);
                            //if (Fsra_Notice_1_bookmark == "fsra_notice1")
                            //    InsertDocumentAtBookmark("fsra_notice1", doc, rtfDoc);
                            InsertDocumentAtBookmark(Fsra_Notice_1_bookmark, doc, rtfDoc);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }


            if (Fsra_Notice_2_bookmark == "fsra_notice2" || Fsra_Notice_2_bookmark == "ab_fsra_notice2")
            {
                if (!string.IsNullOrWhiteSpace(notice2))
                {
                    try
                    {
                        LoadOptions loadOptions = new LoadOptions();
                        loadOptions.LoadFormat = Aspose.Words.LoadFormat.Html;

                        using (MemoryStream rtfStream = new MemoryStream(Encoding.UTF8.GetBytes(notice2)))
                        {
                            Document rtfDoc = new Document(rtfStream, loadOptions);
                            InsertDocumentAtBookmark(Fsra_Notice_2_bookmark, doc, rtfDoc);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }

            if (Fsra_Notice_3_bookmark == "fsra_notice3" || Fsra_Notice_3_bookmark == "ab_fsra_notice3")
            {
                if (!string.IsNullOrWhiteSpace(notice3))
                {
                    try
                    {
                        LoadOptions loadOptions = new LoadOptions();
                        loadOptions.LoadFormat = Aspose.Words.LoadFormat.Html;

                        using (MemoryStream rtfStream = new MemoryStream(Encoding.UTF8.GetBytes(notice3)))
                        {
                            Document rtfDoc = new Document(rtfStream, loadOptions);
                            InsertDocumentAtBookmark(Fsra_Notice_3_bookmark, doc, rtfDoc);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }

            if (Fsra_recommendation_bookmark == "fsra_recommendations" || Fsra_recommendation_bookmark == "ab_fsra_recommendations")
            {
                if (!string.IsNullOrWhiteSpace(recommendations))
                {
                    try
                    {
                        LoadOptions loadOptions = new LoadOptions();
                        loadOptions.LoadFormat = Aspose.Words.LoadFormat.Html;

                        using (MemoryStream rtfStream = new MemoryStream(Encoding.UTF8.GetBytes(recommendations)))
                        {
                            Document rtfDoc = new Document(rtfStream, loadOptions);
                            InsertDocumentAtBookmark(Fsra_recommendation_bookmark, doc, rtfDoc);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
            if (Fsra_advice_bookmark == "fsra_nature_of_advice" || Fsra_advice_bookmark == "ab_fsra_nature_of_advice")
            {
                if (!string.IsNullOrWhiteSpace(scopeOfAdvice))
                {
                    try
                    {
                        LoadOptions loadOptions = new LoadOptions();
                        loadOptions.LoadFormat = Aspose.Words.LoadFormat.Html;

                        using (MemoryStream rtfStream = new MemoryStream(Encoding.UTF8.GetBytes(scopeOfAdvice)))
                        {
                            Document rtfDoc = new Document(rtfStream, loadOptions);
                            InsertDocumentAtBookmark(Fsra_advice_bookmark, doc, rtfDoc);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
            #endregion
            
            if (particularsRTF != null && particularsRTF.Length != 0)
            {
                try
                {
                    LoadOptions loadOptions = new LoadOptions();
                    loadOptions.LoadFormat = Aspose.Words.LoadFormat.Rtf;

                    using (MemoryStream rtfStream = new MemoryStream(particularsRTF))
                    {
                        Document rtfDoc = new Document(rtfStream, loadOptions);
                        //Checking for creating a Task Doc or an Invoice
                        if (pol_particular_bookmark == "pol_particulars")
                            InsertDocumentAtBookmark("pol_particulars", doc, rtfDoc);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }


            bool _useSalesTeamLogo = false;
            switch (docType)
            {
                case 1:
                    if(docValues.ContainsKey("saltea_Use_Billing") && docValues["saltea_Use_Billing"] == "True")
                        _useSalesTeamLogo = true;
                    break;

                case 2:
                    if(docValues.ContainsKey("saltea_Use_Closing") && docValues["saltea_Use_Closing"] == "True")
                        _useSalesTeamLogo = true;
                    break;

                default:
                    if(docValues.ContainsKey("saltea_Use_other") && docValues["saltea_Use_other"] == "True")
                        _useSalesTeamLogo = true;
                    break;
            }
                                   
            // Insert Logo
            if (branch_logo_bookmark == "logo")
            {
                string value = "";

                if (_useSalesTeamLogo && docValues.ContainsKey("saltea_logo"))
                {
                    value = docValues["saltea_logo"];
                }

                if (string.IsNullOrEmpty(value))
                {
                    if (docValues.ContainsKey("sap_logo"))
                    {
                        value = docValues["sap_logo"];
                    }
                }

                if (string.IsNullOrEmpty(value))
                {
                    if (docValues.ContainsKey("bra_logo") && (doc.Variables["bra_desc"] == "Electronic" || docType == 3 || IsGenerateTaskDocument))
                    {
                         value = docValues["bra_logo"];
                    }
                }
                    if (!string.IsNullOrEmpty(value))
                    {
                        string logopath = path + "\\logos\\" + value;
                        if(File.Exists(logopath))  
                            InsertImage(doc, "logo", logopath);
                    }
            }            
            
            if (showWaterMark)
            {
                InsertWatermarkText(doc, "DRAFT");
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
                                run.Text = run.Range.Text.Remove(0, 1);
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

            if (IsCIP)
            {
                if (bodyTemplate != null)
                {
                    MemoryStream newStream2 = null;
                    if (bodyTemplate != null)
                    {
                        using (newStream2 = new MemoryStream(bodyTemplate))
                        {
                            Document bodyDoc = new Document(newStream2);
                            InsertDocumentAtBookmark("BPLUS_BODY", doc, bodyDoc);
                        }
                    }
                }
                else
                {
                    if (doc.Range.Bookmarks["BPLUS_BODY"] != null)
                        doc.Range.Bookmarks["BPLUS_BODY"].Text = "";
                }

            }
                       
            try
            {
                if (lockDocument)
                {
                    doc.Protect(ProtectionType.ReadOnly);
                }

                if (IsGenerateTaskDocument && doc.ProtectionType == ProtectionType.AllowOnlyFormFields)
                {
                    doc.Unprotect();
                    doc.Protect(ProtectionType.AllowOnlyFormFields, "NAQ1234"); 
                }

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

            return stream.ToArray();
        }

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

        public const string SunriseInvalidScheduleErrorMessage = "The schedule text received from Sunrise is invalid and cannot be saved. Please contact Sunrise.";

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
                    throw new Exception(SunriseInvalidScheduleErrorMessage);
                else
                    throw (e);
            }
        }

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



        public static byte[] InsertDocumentAtBookamrk(string bookmarkName, byte[] mainDoc, byte[] mergedDoc)
        {
            using (MemoryStream newStream = new MemoryStream(mainDoc))
            {
                using (MemoryStream newStream2 = new MemoryStream(mergedDoc))
                {

                    // Read the document from the stream.
                    Document MainDoc = new Document(newStream);

                    // Read the document from the stream.
                    Document MergedDoc = new Document(newStream2);

                    InsertDocumentAtBookmark(bookmarkName, MainDoc, MergedDoc);

                    using (MemoryStream stream = new MemoryStream())
                    {
                        MainDoc.Save(stream, SaveFormat.Docx);

                        return stream.ToArray();
                    }
                }
            }
        }
        
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
                return;
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
                                list = dstParagraph.ListFormat.List;
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
                                ((Paragraph)newNode).ListFormat.List = list;
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

        public static byte[] GenerateBodyDoc(byte[] bodyTemplate, byte[] particularsRTF, byte[] fsra_notice1RTF, byte[] fsra_recommendation, byte[] fsra_nature_of_advice,
            Tuple<Dictionary<string, string>, Dictionary<string, string[,]>> documentValues, bool draft, SaveFormat saveFormat)
        {
            Dictionary<string, string> docValues = documentValues.Item1;
            Dictionary<string, string[,]> docArrayValues = documentValues.Item2;

            MemoryStream newStream = null;
            if(bodyTemplate != null)
                 newStream = new MemoryStream(bodyTemplate);
            

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
                if (TryGetKeyWithCorrectCase(docValues.Keys, bookmarkName, out caseCorrectKey) && bookmarkName != "pol_particulars")  //if (docValues.ContainsKey(bookmarkName) && bookmarkName != "pol_particulars")               
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
                            bookmark.Text = tempValue;
                    }
                    catch (Exception e)
                    {
                        string temp = e.Message;
                        bookmark.Remove();
                    }
                }

                string correctKey;
                if (TryGetKeyWithCorrectCase(docArrayValues.Keys, bookmarkName, out correctKey) && bookmarkName != "pol_particulars") //(docArrayValues.ContainsKey(bookmarkName) && bookmarkName != "pol_particulars")
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
                                        currentCell = MoveToNextCell(builder, currentCell);
                                }
                                else
                                {
                                    if (!(rowIndex == data.GetUpperBound(0) && colIndex == data.GetUpperBound(1)))
                                        currentCell = MoveToNextCell(builder, currentCell);
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
                                    fieldCode += ((Run)currentNode).Text;

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

            if (particularsRTF != null && particularsRTF.Count() > 0)
            {
                try
                {

                    using (MemoryStream rtfStream = new MemoryStream(particularsRTF))
                    {
                        Document rtfDoc = new Document(rtfStream);
                        InsertDocumentAtBookmark("pol_particulars", doc, rtfDoc);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            if (fsra_notice1RTF != null && fsra_notice1RTF.Count() > 0)
            {
                try
                {

                    using (MemoryStream rtfStream = new MemoryStream(fsra_notice1RTF))
                    {
                        Document rtfDoc = new Document(rtfStream);
                        InsertDocumentAtBookmark("fsra_notice1", doc, rtfDoc);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            if (draft)
            {
                InsertWatermarkText(doc, "DRAFT");
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
            byte[] particularsRTF, int docType, string path, string format, bool draft, int ScheduleType)
        {

            Document brokerPlusDot = new Document(path + "\\BrokerPlus.dotx");

            MemoryStream newStream = null;
            if(bodyTemplate != null)
                newStream = new MemoryStream(bodyTemplate);
            

            // Read the document from the stream.
            Document doc = new Document(newStream);

            InsertBlockAtBookamrk(brokerPlusDot, "Bplus_Premiums", doc, docType);
            InsertBlockAtBookamrk(brokerPlusDot, "BPLUS_SCHEDULE", doc, ScheduleType);
            InsertBlockAtBookamrk(brokerPlusDot, "BPLUS_PARTICULARS", doc, docType);
            InsertBlockAtBookamrk(brokerPlusDot, "fsra_notice1", doc, docType);
            InsertBlockAtBookamrk(brokerPlusDot, "BPLUS_HEADER", doc, docType);
            InsertBlockAtBookamrk(brokerPlusDot, "BPLUS_PAYMENT ", doc, docType);
            InsertBlockAtBookamrk(brokerPlusDot, "BPLUS_DUTYOFDISCLOSURE", doc, 0);

            // Save Document after adding BookMark and call 
            MemoryStream Middlestream = new MemoryStream();
            doc.Save(Middlestream, SaveFormat.Doc);

            docTemplate = GenerateBodyDoc(Middlestream.GetBuffer(), null,null,null,null, documentValues, false, SaveFormat.Doc);
            newStream = new MemoryStream(docTemplate);
            doc = new Document(newStream);

    
            if (bodyTemplate != null)
            {
                MemoryStream rtfStream = new MemoryStream(bodyTemplate);
                Document rtfDoc = new Document(rtfStream);
                InsertDocumentAtBookmark("BPLUS_BODY", doc, rtfDoc);
            }
            else
            {
                if (doc.Range.Bookmarks["BPLUS_BODY"] != null)
                    doc.Range.Bookmarks["BPLUS_BODY"].Text = "";
            }
          
            
            if (particularsRTF != null)
            {
                MemoryStream rtfStream = new MemoryStream(particularsRTF);
                Document rtfDoc = new Document(rtfStream);
                InsertDocumentAtBookmark("pol_particulars", doc, rtfDoc);
            }
            //if (fsra_notice1RTF != null)
            //{
            //    MemoryStream rtfStream = new MemoryStream(fsra_notice1RTF);
            //    Document rtfDoc = new Document(rtfStream);
            //    InsertDocumentAtBookmark("fsra_notice1", doc, rtfDoc);
            //}

            if (draft)
            {
                InsertWatermarkText(doc, "DRAFT");
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
             mainDoc.Range.Bookmarks[bookmarkName].Text = "";
            builder.MoveToBookmark(bookmarkName);
            builder.InsertImage(path); 
        }

    }
}
