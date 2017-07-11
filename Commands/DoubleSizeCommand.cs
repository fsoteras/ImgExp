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
                // wich would be a general solution (an "on initialization-systemic-way" to retrieve a Pictures folder?)
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

                // In the using block below data is being transfered from an ooutside source 
                // ( a picture file).
                // into my program. That operation is called "reading from a stream".
                // MemoryStream is specialized in reading and writing from memory.

                using (MemoryStream inStream = new MemoryStream(photoBytes))
                {
                    //To transfer data from my program to some outside source (in this cas a new jeg
                    // file) this operation is called "writing to the stream".

                    using (MemoryStream outStream = new MemoryStream())
                    {
                        // Initialize the ImageFactory using the overload to preserve EXIF metadata.
                        using (ImageFactory imFactory = new ImageFactory(preserveExifData: true))
                        {
                            // Load, resize, set the format and quality and save an image.

                            imFactory.Load(inStream);

                            //recalculate size (ignore percentage parameter for now)

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
