using BorjaProject.iws.api.Models;
using BorjaProject.iws.api.Models.Dto;

namespace BorjaProject.iws.api.Datos
{
    public static class BorjaPStore
    {
        public static List<BorjaP_Dto> StoreB = new List<BorjaP_Dto>
        {
            new BorjaP_Dto{Id=1, Name="Arturo dto", Edad= 25, Peso=95 },
            new BorjaP_Dto{Id=2, Name="Borja dto", Edad= 30, Peso=80}
        };

    }
}
