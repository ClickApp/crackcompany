using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

/// <summary>
/// Clase que manipula imagenes para cambiarlas de tonalidad, redimensionarlas,...
/// </summary>
public class ProcesarImagenes
{
	public ProcesarImagenes()
	{
		
	}

    //Función que redimensiona las imágenes en el tamaño especificado en función de la anchura
    public void ResizeImagen(string imagefrom, string imageto, int width)
    {
        Bitmap bm = new Bitmap(imagefrom);

        int tHeight;
        int tWidth;

        if (bm.Height > bm.Width)
        {
            tHeight = width;
            tWidth = (int)(bm.Width * ((float)width / (float)bm.Height));
        }
        else
        {
            tWidth = width;
            tHeight = (int)(bm.Height * ((float)width / (float)bm.Width));
        }

        Bitmap thumb = new Bitmap(tWidth, tHeight);

        Graphics g = Graphics.FromImage(thumb);

        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

        g.DrawImage(bm, new Rectangle(0, 0, tWidth, tHeight), new Rectangle(0, 0, bm.Width, bm.Height), GraphicsUnit.Pixel);
        g.Dispose();

        MemoryStream ms = new MemoryStream();
        bm.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        ms.Seek(0, SeekOrigin.Begin);
        bm.Dispose();
        
        //image path. better to make this dynamic. I am hardcoding a path just for example sake             
        thumb.Save(imageto);
        thumb.Dispose();        
    }

    //Función que redimensiona las imágenes en el tamaño especificado 
    public void ResizeImagenHeightWidth(string imagefrom, string imageto, int width, int height)
    {
        Bitmap bm = new Bitmap(imagefrom);

        Bitmap thumb = new Bitmap(width, height);

        Graphics g = Graphics.FromImage(thumb);

        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

        g.DrawImage(bm, new Rectangle(0, 0, width, height), new Rectangle(0, 0, bm.Width, bm.Height), GraphicsUnit.Pixel);
        g.Dispose();

        MemoryStream ms = new MemoryStream();
        bm.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        ms.Seek(0, SeekOrigin.Begin);
        bm.Dispose();

        //image path. better to make this dynamic. I am hardcoding a path just for example sake
        thumb.Save(imageto);       
        thumb.Dispose();        
    }

    //Función que convierte una imagen a escala de grises
    public void convertirGris(string imagefrom, string imageto)
    {
        //create a blank bitmap the same size as original
        Bitmap original = new Bitmap(imagefrom);
        Bitmap newBitmap = new Bitmap(original.Width, original.Height);

        //get a graphics object from the new image
        Graphics g = Graphics.FromImage(newBitmap);

        //create the grayscale ColorMatrix
        ColorMatrix colorMatrix = new ColorMatrix(new float[][]
         {
             new float[] {.30f, .30f, .30f, 0, 0},
             new float[] {.59f, .59f, .59f, 0, 0},
             new float[] {.11f, .11f, .11f, 0, 0},
             new float[] {0, 0, 0, 1, 0},
             new float[] {0, 0, 0, 0, 1}
         });

        //create some image attributes
        ImageAttributes attributes = new ImageAttributes();

        //set the color matrix attribute
        attributes.SetColorMatrix(colorMatrix);

        //draw the original image on the new image
        //using the grayscale color matrix
        g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
           0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

        //dispose the Graphics object
        g.Dispose();
        newBitmap.Save(imageto);
    }
    
    //Función que crea el directorio para guardar imagenes en caso de no existir
    public void crearDirectorio(string ruta)
    {
        if (!Directory.Exists(ruta))
            Directory.CreateDirectory(ruta);
    }

    //Función que valida si un fichero es una imagen
    public bool validaImagen(string ext)
    {
        bool correcto = false;

        if (ext == ".jpg" || ext == ".JPG" || ext == ".png" || ext == ".PNG" || ext == ".jpeg" || ext == ".JPEG" || ext == ".BMP" || ext == ".bmp" || ext == ".GIF" || ext == ".gif")
            correcto = true;

        return correcto;
    }
}