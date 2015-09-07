using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using System.IO;
using DataConversionTool.Helpers;

namespace UnitTest
{
    [TestFixture]
    class FileTypeDetectorTests
    {
        [Test]
        public void DetectFileType()
        {
            // Is Doc
            byte[] docBytes = File.ReadAllBytes("../../TestData/Doc");
            Assert.IsTrue(FileTypeDetector.IsDoc(docBytes));

            // Is Xls
            byte[] xlsBytes = File.ReadAllBytes("../../TestData/Xls");
            Assert.IsTrue(FileTypeDetector.IsXls(xlsBytes));

            // Doc vs Xls
            Assert.IsFalse(FileTypeDetector.IsDoc(xlsBytes));
            Assert.IsFalse(FileTypeDetector.IsXls(docBytes));

            // Doc vs Docx
            byte[] docxBytes = File.ReadAllBytes("../../TestData/Docx");
            Assert.IsFalse(FileTypeDetector.IsDoc(docxBytes));

            // Xls vs Xlsx
            byte[] xlsxBytes = File.ReadAllBytes("../../TestData/Xlsx");
            Assert.IsFalse(FileTypeDetector.IsXls(xlsxBytes));
        }

        [Test]
        public void InvalidInput()
        {
            // NULL
            byte[] nullBytes = null;
            Assert.IsFalse(FileTypeDetector.IsDoc(nullBytes));
            Assert.IsFalse(FileTypeDetector.IsXls(nullBytes));

            // Empty
            byte[] emptyBytes = new byte[0];
            Assert.IsFalse(FileTypeDetector.IsXls(emptyBytes));
            Assert.IsFalse(FileTypeDetector.IsDoc(emptyBytes));

            // Not enough length
            byte[] notEnoughBytes = new byte[] { 1, 2, 3 };
            Assert.IsFalse(FileTypeDetector.IsXls(notEnoughBytes));
            Assert.IsFalse(FileTypeDetector.IsDoc(notEnoughBytes));
        }
    }
}
