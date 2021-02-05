using System.ComponentModel.DataAnnotations;

namespace lawliet.Domain
{
    public class NotificationDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Message cannot be empty.")]
        public string Message { get; set; }
    }
}