using CodingFactoryBlog.Enums;

namespace CodingFactoryBlog.Models.ViewModels
{
    public class Notification
    {
        public string Message { get; set; }

        public NotificationType Type { get; set; }
    }
}
