using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Model
{
    public class DataModel
    {
        [Required]
        [Range(1, 10)]
        public int RowCount { get; set; }
    }
}
