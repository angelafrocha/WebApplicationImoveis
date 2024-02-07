using WebApplicationImoveis.Models;

namespace WebApplicationImoveis.Repository
{
    public static class ImovelRepository
    {
        public static List<Imovel> listaImoveis = new List<Imovel>
        {
            new Imovel { Id = 1, Tipo = "Casa", Status = "Disponível" },
            new Imovel { Id = 2, Tipo = "Apartamento", Status = "Indisponível" },
            new Imovel { Id = 3, Tipo = "Terreno", Status = "Disponível" }
        };
        public static List<Imovel> GetImoveis()
        {
            return listaImoveis;
        }

        public static Imovel GetImovelId(int id)
        {
            return listaImoveis.Find(i => i.Id == id);
        }

        public static Imovel AddImovel(Imovel imovel)
        {
            imovel.Id = listaImoveis.Count + 1;
            listaImoveis.Add(imovel);
            return imovel;
        }

        public static bool UpdateImovel(int id, Imovel imovel)
        {
            var index = listaImoveis.FindIndex(i => i.Id == id);
            if (index == -1)
            {
                return false;
            }
            imovel.Id = id;
            listaImoveis[index] = imovel;
            return true;
        }

        public static bool DeleteImovel(int id)
        {
            var imovel = listaImoveis.Find(i => i.Id == id);
            if (imovel == null)
            {
                return false;
            }
            listaImoveis.Remove(imovel);
            return true;
        }
    }
}
