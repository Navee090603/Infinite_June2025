using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_9_Question_2_.Repo
{
    public interface IMovieRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(object Id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object Id);
        void Save();
        IEnumerable<T> GetByYear(int year);
        IEnumerable<T> GetByDirector(string directorName);
    }
}
