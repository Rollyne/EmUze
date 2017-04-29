using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Picture
    {
        public Picture()
        {
            ProviderType = new PictureProviderType();
            this.ProviderTypeId = 1;
        }

        public string FilePath { get; set; }

        public string FileName { get; set; }
        
        public string FileFormat { get; set; }

        public int ProviderTypeId { get; set; }

        public PictureProviderType ProviderType { get; set; }
    }
}