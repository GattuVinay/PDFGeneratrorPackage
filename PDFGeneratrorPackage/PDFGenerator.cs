using DinkToPdf;

namespace PDFGeneratrorPackageLibrary
{
    public class PDFGenerator
    {
        public static byte[] GeneratePDF(string htmlContent)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                //HtmlContent = "<h1>Hello World</h1><p>This is a PDF document generated from HTML using DinkToPdf.</p>",
                HtmlContent = htmlContent,

            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            var converter = new BasicConverter(new PdfTools());
            byte[] pdfBytes = converter.Convert(pdf);
            // Save the PDF to a file
            System.IO.File.WriteAllBytes("output.pdf", pdfBytes);
            return pdfBytes;
        }
    }
}
