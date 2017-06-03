namespace Data.Models
{
    public class Picture
    {
        public Picture()
        {
            this.ProviderType = PictureProviderType.None;
        }

        public string FilePath { get; set; }

        public string FileName { get; set; }
        
        public string FileFormat { get; set; }

        public PictureProviderType ProviderType { get; set; }
    }
}