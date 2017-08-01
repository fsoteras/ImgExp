using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImgExpnd.Commands
{
  
    public class DoubleSizeCommand : ICommand, ICommandFactory
    {


        public void Execute(string[] args)
        {

            string path = args[1];
            // if user didn't pass a new name , use orginal picture name plus some instance data/

            string pictName = Path.GetFileName(path);
            string folderPath = Path.GetDirectoryName(path);

            // if folder path is empty, search it on /Pictures
            if (folderPath == "")
            {
               
                folderPath = @"C:\Users\fsoteras_admin\Pictures";
            }
            int percentage = 200;

            Size size = new Size(150, 0);

            try
            {
                // use ImageProcessor
                byte[] photoBytes = File.ReadAllBytes(folderPath + "\\" + pictName);
                // Format is automatically detected though can be changed.
                ISupportedImageFormat format = new JpegFormat { Quality = 70 };

               

                using (MemoryStream inStream = new MemoryStream(photoBytes))
                {
                   

                    using (MemoryStream outStream = new MemoryStream())
                    {
                       
                        using (ImageFactory imFactory = new ImageFactory(preserveExifData: true))
                        {
                            

                            imFactory.Load(inStream);

                           

                            size = new Size((imFactory.Image.Size.Height * percentage) / 100, (imFactory.Image.Size.Width * percentage) / 100);

                            var Resl = new ImageProcessor.Imaging.ResizeLayer(size, ImageProcessor.Imaging.ResizeMode.Max);

                            imFactory.Resize(Resl)

                             .Format(format)
                             .Save(outStream);

                            var dims = imFactory.Image.PhysicalDimension;



                        }

                        Image img = System.Drawing.Image.FromStream(outStream);
                        string fileName = folderPath + "\\" + pictName + "_Resized.Jpeg";
                        img.Save(fileName, ImageFormat.Jpeg);
                        Console.WriteLine("image generated at: " + fileName);
                    };
                };
            }

            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access to path denied ");

            }


        }




        public ICommand MakeCommand(string[] arguments)
        {

            return new DoubleSizeCommand { };

        }

        public string CommandName { get { return "double"; } }
        public string CommandDescription { get { return "Double the size of the image"; } }
    }
}
