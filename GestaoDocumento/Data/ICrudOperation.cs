using GestaoDocumento.Models;

namespace GestaoDocumento.Data
{
    public interface ICrudOperation
    {
        void Add(Documento rota);
        void Delete(int id);
        List<Documento> Get();
        Documento Get(int id);
        void Update(Documento rota);
    }
}
