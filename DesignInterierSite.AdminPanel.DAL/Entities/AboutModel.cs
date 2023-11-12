using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignInterierSite.AdminPanel.DAL.Entities
{
    public class AboutModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int ImagesModelId { get; set; }
        public ImagesModel Image { get; set; }

        [NotMapped]
        public IFormFile FormFile { get; set; }
    }
}
