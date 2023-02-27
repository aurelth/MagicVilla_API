using MagicVilla_Api.Models.DTO;

namespace MagicVilla_Api.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>
            {
                new VillaDTO{ Id=1, Name="Blumenau", Occupancy=4, SquarFeet=100 },
                new VillaDTO{ Id=2, Name="Cotonou", Occupancy=3, SquarFeet=300 }
            };
    }
}
