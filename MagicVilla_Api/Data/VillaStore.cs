using MagicVilla_Api.Models.DTO;

namespace MagicVilla_Api.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>
            {
                new VillaDTO{ Id=1, Name="Blumenau" },
                new VillaDTO{ Id=2, Name="Cotonou" }
            };
    }
}
