using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace MergePDF2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get some file names
            //string[] files = Directory.GetFiles(@"C:\Projects\CSharp\MergePDF", "*.pdf");
            //string[] files = Directory.GetFiles(@"C:\Projects\CSharp\MergePDF");
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.pdf");

            const string filename = "Merged_PDF.pdf";

            if (File.Exists(filename))
                File.Delete(filename);

            MergeMultiplePDFIntoSinglePDF(filename, files);

            //PdfDocument outputDocument = new PdfDocument();
            //foreach (string file in files)
            //{
            //    PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import);
            //    int count = inputDocument.PageCount;
            //    for (int i = 0; i < count; i++)
            //    {
            //        // Get the page from the external document...
            //        PdfPage page = inputDocument.Pages[i];
            //        // ...and add it to the output document.
            //        outputDocument.AddPage(page);
            //    }
            //}
            //// Save the document...
            //const string filename = "Merged_PDF.pdf";
            //outputDocument.Save(filename);
            //// ...and start a viewer.
            //Process.Start(filename);
        }

        private static void MergeMultiplePDFIntoSinglePDF(string outputFilePath, string[] pdfFiles)
        {
            //Console.WriteLine("Merging started.....");
            PdfDocument outputPDFDocument = new PdfDocument();
            foreach (string pdfFile in pdfFiles)
            {
                if (pdfFile.Contains("Merged_PDF"))
                {
                    continue;
                }
                PdfDocument inputPDFDocument = PdfReader.Open(pdfFile, PdfDocumentOpenMode.Import);

                outputPDFDocument.Version = inputPDFDocument.Version;
                foreach (PdfPage page in inputPDFDocument.Pages)
                {
                    outputPDFDocument.AddPage(page);
                }
            }
            outputPDFDocument.Save(outputFilePath);
            //Console.WriteLine("Merging Completed");
            Process.Start(outputFilePath);
        }
    }
}
