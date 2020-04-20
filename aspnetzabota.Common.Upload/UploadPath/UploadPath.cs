namespace aspnetzabota.Common.Upload.UploadPath
{
    internal class UploadPath : IUploadPath
    {
        public Path GetPath()
        {
            return new Path
            {
                BaseImagePath = "images",
                Articles = "Articles",
                Licenses = "Licenses",
                Slider = "Slider",
                Staff = "staff"
            }; 
        }
    }
    public class Path
    {
        public string BaseImagePath { get; set; }
        public string Articles { get; set; } 
        public string Licenses { get; set; }
        public string Slider { get; set; }
        public string Staff { get; set; }
    }
}
