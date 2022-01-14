using System.ComponentModel.DataAnnotations;

namespace Common
{
    public class DataRequest
    {
        [Required]
        [Range(1, 10)]
        public int RowCount { get; set; }
    }
}