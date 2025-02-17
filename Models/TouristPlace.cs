using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TpCrApp.Models
{
    public class TouristPlace
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TouristPlaceId { set; get; }

        //[Required]
        //[MaxLength(80)]
        public string TouristPlaceName { set; get; } = "";

        //[Required]
        //[MaxLength(50)]
        public string TouristPlaceType { set; get; } = "";

        //[Required]
        //[MaxLength(50)]
        public string Location { set; get; } = "";

    }
}
