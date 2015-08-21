using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Configuration;

namespace sniper.service
{
    public static class ImageHelper
    {
        public static Image MakeThumb(Image srcimage, Size thumbSize)
        {
            using (srcimage)
            {
                // 原图片宽,高
                int srcWidth = srcimage.Width;
                int srcHeight = srcimage.Height;

                System.Drawing.Rectangle rectDestination = new System.Drawing.Rectangle(0, 0, thumbSize.Width, thumbSize.Height);
                Image targetImage = new Bitmap(thumbSize.Width, thumbSize.Height);
                System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(targetImage);
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.CompositingQuality = CompositingQuality.HighQuality;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.High;

                gr.DrawImage(srcimage, rectDestination, 0, 0, srcWidth, srcHeight, GraphicsUnit.Pixel);
                gr.Dispose();
                return targetImage;
            }
        }
        public static void MakeThumb(string srcimageUrl, string fileName, ThumbImage thumbSize)
        {
            using (Image img = MakeThumb(Bitmap.FromFile(srcimageUrl), new Size(thumbSize.Width, thumbSize.Height)))
            {
                fileName = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/"), thumbSize.ImageFoler), fileName);

                if (!Directory.Exists(Path.GetDirectoryName(fileName)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                }

                img.Save(fileName);
            }
        }
        public static void SaveImage(Stream stream, string sourceImage)
        {
            if (!Directory.Exists(Path.GetDirectoryName(sourceImage)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(sourceImage));
            }

            using (Image img = Bitmap.FromStream(stream))
            {
                img.Save(sourceImage);
            }
        }
    }
    public class ThumbImage
    {
        public int Width
        { get; set; }

        public int Height
        { get; set; }

        public string ImageFoler
        { get; set; }

        public ThumbImage()
        { }

        public ThumbImage(int width, int height, string imageFoler)
        {
            ImageFoler = imageFoler;
            Width = width;
            Height = height;
        }
    }

    public class MemberHeaderSize
    {
        public string OriginHeaderImagePath
        {
            get
            {
                return "files/uploadimages/origin/";
            }
        }
        //public string SmallHeaderImagePath
        //{
        //    get
        //    {
        //        return "files/uploadimages/60x60/";
        //    }
        //}
        public string MiddleHeaderImagePath
        {
            get
            {
                return "files/uploadimages/240x152/";
            }
        }
        //public string LargeHeaderImagePath
        //{
        //    get
        //    {
        //        return "files/uploadimages/280x234/";
        //    }
        //}

        public Dictionary<string, ThumbImage> HeaderImageSizes
        {
            get
            {
                Dictionary<string, ThumbImage> list = new Dictionary<string, ThumbImage>();

                //list.Add("small", new ThumbImage(60, 60, "files/uploadimages/60x60"));
                list.Add("middle", new ThumbImage(240, 152, "files/uploadimages/240x152"));
                //list.Add("largest", new ThumbImage(280, 234, "files/uploadimages/280x234"));
                return list;
            }
        }


    }
}
