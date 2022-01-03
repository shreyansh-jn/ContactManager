using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_DataAccess.Interface
{
    public interface IRepository<T>
    {
        public T Create(T _object);

        public T Update(T _object);

        public IEnumerable<T> GetAll();

        public T GetById(int Id);

        public void Delete(T _object);

        public void DeleteByStatus(T _object);
    }
}
