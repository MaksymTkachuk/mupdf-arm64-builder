using MuPDF.NET;
using PDF4LLM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TestOcr();
            TestTable1_();

            return;
        }

        private static void TestTable1_()
        {
            string testFilePath = Path.GetFullPath(@"national-capitals.pdf");
            MuPDF.NET.Document doc = new MuPDF.NET.Document(testFilePath);
            string md = PdfExtractor.ToMarkdown(doc);
            string outputPath = Path.ChangeExtension(testFilePath, ".txt");
            File.WriteAllText(outputPath, md);
            Console.WriteLine(md);
            Console.WriteLine($"Saved markdown to {outputPath}");
        }

        private static void TestOcr()
        {
            PdfExtractor.UseLayout = true;
            string pdfPath = Path.GetFullPath(@"Ocr.pdf");
            string md = PdfExtractor.ToMarkdown(pdfPath);
            string markdownOutputPath = Path.ChangeExtension(pdfPath, ".md.txt");
            File.WriteAllText(markdownOutputPath, md);
            Console.WriteLine(md);
            Console.WriteLine($"Saved markdown to {markdownOutputPath}");
            string text = PdfExtractor.ToText(pdfPath, useOcr: true);
            string textOutputPath = Path.ChangeExtension(pdfPath, ".ocr.txt");
            File.WriteAllText(textOutputPath, text);
            Console.WriteLine(text);
            Console.WriteLine($"Saved OCR text to {textOutputPath}");
        }
    }
}
