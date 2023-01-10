
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;

public class Program
{
  public static void Main(string[] args)
  {
    DemoReceta receta = new DemoReceta();
    Console.WriteLine("Hola Mundo");

    receta.Receta(AppDomain.CurrentDomain.BaseDirectory, "prueba.pdf");
  }
}




public class DemoReceta
{
  public void Receta(string path, string fileName)
  {
    Document documento = new Document(PageSize.Letter);
    documento.SetMargins(36.0F, 36.0F, 36.0F, 150.0F);  

    FileStream archivo = null;
    PdfWriter writter = null;


    try
    {
      archivo = new FileStream(Path.Combine(path, fileName), FileMode.Create);
      writter = PdfWriter.GetInstance(documento, archivo);



      //Fuentes de documento
      BaseFont _normal = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.EMBEDDED);
      
      //Normal
      Font normal = new Font(_normal, 9, Font.NORMAL, BaseColor.Black);

      //Negrita 
      Font negrita = new Font(_normal, 9, Font.BOLD, BaseColor.Black);

      //Cursiva
      Font cursiva = new Font(_normal, 9, Font.ITALIC, BaseColor.Black);

      Font underline = new Font(_normal, 9, Font.BOLD | Font.UNDERLINE, BaseColor.Black);


      var imagen = Image.GetInstance(Path.Combine(path, "Logo.jpg"));
      imagen.WidthPercentage = 10;

      documento.Open();


      PdfPTable header = new PdfPTable(new float[] { 10 });

      header.AddCell(new PdfPCell(imagen, false) { HorizontalAlignment = Element.ALIGN_CENTER, Border = iTextSharp.text.Rectangle.NO_BORDER });
      header.AddCell(new PdfPCell(new Phrase("")) { HorizontalAlignment = Element.ALIGN_CENTER, Border = iTextSharp.text.Rectangle.NO_BORDER });
      header.AddCell(new PdfPCell(new Phrase("")) { HorizontalAlignment = Element.ALIGN_CENTER, Border = iTextSharp.text.Rectangle.NO_BORDER });
      header.AddCell(new PdfPCell(new Phrase("DR. ELOY GARCIA CEJA".ToUpper(), normal)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = iTextSharp.text.Rectangle.NO_BORDER });
      header.AddCell(new PdfPCell(new Phrase("GINECÓLOGO".ToUpper(), normal)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = iTextSharp.text.Rectangle.NO_BORDER });

      documento.Add(header);
      documento.Add(new Paragraph(" "));



      PdfPTable generalidades = new PdfPTable(new float[] { 20, 20, 20, 20, 20 }) { WidthPercentage = 100 };
      PdfPTable firma = new PdfPTable(1);
      
      generalidades.AddCell(new PdfPCell(new Phrase("Nombre del paciente: ", normal)) { Border = iTextSharp.text.Rectangle.NO_BORDER, Colspan = 1, PaddingBottom = 5 });
      generalidades.AddCell(new PdfPCell(new Phrase("GIOVANNA FIGUEROA MARQUEZ ", underline)) { Border = iTextSharp.text.Rectangle.NO_BORDER, Colspan = 3, PaddingBottom = 5 });
      generalidades.AddCell(new PdfPCell(new Phrase("Fecha ", normal)) { Border = iTextSharp.text.Rectangle.NO_BORDER });


      var lblPeso = new Phrase("Peso: ", normal);
      var peso = new Chunk(" 75 ", underline);
      var kg = new Chunk(" Kg  |", normal);

      lblPeso.Add(peso);
      lblPeso.Add(kg);

      var lblEstatura = new Phrase("Estatura: ", normal);
      var estatura = new Chunk(" 1.60 ", underline);
      var m = new Chunk(" m  |", normal);

      lblEstatura.Add(estatura);
      lblEstatura.Add(m);

      var lblPresion = new Phrase("Presión: ", normal);
      var presion = new Chunk("120/80", underline);
      var mmhg = new Chunk(" mmHg |", normal);

      lblPresion.Add(presion);
      lblPresion.Add(mmhg);


      var lblTemperatura = new Phrase("Temperatura: ", normal);
      var temperatura = new Chunk(" 36.5 ", underline);
      var c = new Chunk(" °C |", normal);
      lblTemperatura.Add(temperatura);
      lblTemperatura.Add(c);

      var lblIMC = new Phrase("IMC: ", normal);
      var imc = new Chunk("28.12 ", underline);
      lblIMC.Add(imc);


      generalidades.AddCell(new PdfPCell(new Phrase(lblPeso)) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_JUSTIFIED, PaddingBottom = 10.5f });
      generalidades.AddCell(new PdfPCell(new Phrase(lblEstatura)) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_JUSTIFIED, PaddingBottom = 10.5f });
      generalidades.AddCell(new PdfPCell(new Phrase(lblPresion)) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_JUSTIFIED, PaddingBottom = 10.5f });
      generalidades.AddCell(new PdfPCell(new Phrase(lblTemperatura)) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_JUSTIFIED, PaddingBottom = 10.5f });
      generalidades.AddCell(new PdfPCell(new Phrase(lblIMC)) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_JUSTIFIED, PaddingBottom = 10.5f });

      generalidades.AddCell(new PdfPCell(new Phrase("")) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_JUSTIFIED, PaddingBottom = 20, Colspan = 5 });



      generalidades.AddCell(new PdfPCell(new Phrase("IBUPROFENO 200 MG", normal)) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_JUSTIFIED, Colspan = 5});
      generalidades.AddCell(new PdfPCell(new Phrase("Tomar una cada 8 hrs. No exceder por más de 5 días", normal)) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_JUSTIFIED, Colspan = 5});

      generalidades.AddCell(new PdfPCell(new Phrase("")) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_JUSTIFIED, PaddingBottom = 30, Colspan = 5 });


      generalidades.AddCell(new PdfPCell(new Phrase("DICLOFENACO 500 MG", normal)) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_JUSTIFIED, Colspan = 5 });
      generalidades.AddCell(new PdfPCell(new Phrase("Tomar solamenre cuando haya dolor", normal)) { Border = iTextSharp.text.Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_JUSTIFIED, Colspan = 5 });
     
      documento.Add(generalidades);




      firma.AddCell(new PdfPCell(new Phrase("_____________________________________________________")) { HorizontalAlignment = Element.ALIGN_CENTER, Border = iTextSharp.text.Rectangle.NO_BORDER });
      firma.AddCell(new PdfPCell(new Phrase("Dr. Eloy Garcia Ceja")) { HorizontalAlignment = Element.ALIGN_CENTER, Border = iTextSharp.text.Rectangle.NO_BORDER });


      documento.Add(new Paragraph(" "));
      documento.Add(new Paragraph(" "));
      


      documento.Add(firma);

      documento.Close();
      archivo.Close();
      writter.Close();


    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
    
  }
  
}