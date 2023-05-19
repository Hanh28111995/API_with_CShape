using Microsoft.AspNetCore.Http;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace wcl_employee_admin.FileUpload
{
    public class FileUpload
    {
        public async static void SingleFile(IFormFile file, string webRootPath, string path, string uniqueFileName)
        {
            string uploadFolder = Path.Combine(webRootPath, path);
            string filePath = Path.Combine(uploadFolder, uniqueFileName);
            var stream = new FileStream(webRootPath + filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            stream.Close();
        }

        public static void SingleFileCurrentProject(IFormFile file, string webRootPath, string path, string uniqueFileName)
        {
            if (IsImage(file) == true)
            {
                string uploadFolder = Path.Combine(webRootPath, path);
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                Image image = Image.FromStream(file.OpenReadStream(), true, true);
                if (Array.IndexOf(image.PropertyIdList, 274) > -1)
                {
                    var orientation = (int)image.GetPropertyItem(274).Value[0];
                    switch (orientation)
                    {
                        case 1:
                            // No rotation required.
                            break;
                        case 2:
                            image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                            break;
                        case 3:
                            image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case 4:
                            image.RotateFlip(RotateFlipType.Rotate180FlipX);
                            break;
                        case 5:
                            image.RotateFlip(RotateFlipType.Rotate90FlipX);
                            break;
                        case 6:
                            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case 7:
                            image.RotateFlip(RotateFlipType.Rotate270FlipX);
                            break;
                        case 8:
                            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                    }
                    // This EXIF data is now invalid and should be removed.
                    image.RemovePropertyItem(274);
                }
                string newSize = ImageResize(image, 800, 800);
                string[] aSize = newSize.Split(",");
                var newImage = new Bitmap(int.Parse(aSize[0]), int.Parse(aSize[1]));
                using (var a = Graphics.FromImage(newImage))
                {
                    a.DrawImage(image, 0, 0, int.Parse(aSize[0]), int.Parse(aSize[1]));
                    newImage.Save(filePath);
                }
            }
            else
            {
                string uploadFolder = Path.Combine(webRootPath, path);
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                //file.CopyTo(new FileStream(filePath, FileMode.Create));

                using (var iNeedToLearnAboutDispose = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(iNeedToLearnAboutDispose);
                }
            }
        }

        public static void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                File.Delete(path);
            }
        }

        public static string ImageResize(Image img, int MaxWidth, int MaxHeight)
        {
            if (img.Width > MaxWidth || img.Height > MaxHeight)
            {
                double widthratio = (double)img.Width / (double)MaxWidth;
                double heighthratio = (double)img.Height / (double)MaxHeight;
                double ratio = Math.Max(widthratio, heighthratio);
                int newWidth = (int)(img.Width / ratio);
                int newHeight = (int)(img.Height / ratio);
                return newWidth.ToString() + "," + newHeight.ToString();
            }
            else
            {
                return img.Width.ToString() + "," + img.Height.ToString();
            }
        }

        public static bool IsImage(IFormFile postedFile)
        {
            //-------------------------------------------
            //  Check the image mime types
            //-------------------------------------------
            if (!string.Equals(postedFile.ContentType, "image/jpg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "image/jpeg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "image/pjpeg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "image/gif", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "image/x-png", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "image/png", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            //-------------------------------------------
            //  Check the image extension
            //-------------------------------------------
            var postedFileExtension = Path.GetExtension(postedFile.FileName);
            if (!string.Equals(postedFileExtension, ".jpg", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".png", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".gif", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".jpeg", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            return true;
        }
    }
}