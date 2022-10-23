using GestaoDocumento.Models;

namespace GestaoDocumento.Data
{
    public interface ICrudOperation
    {
        void Create(Documento rota);
        void Delete(int id);
        List<Documento> Read();
        Documento Read(int id);
        void Update(Documento rota);
    }
}
