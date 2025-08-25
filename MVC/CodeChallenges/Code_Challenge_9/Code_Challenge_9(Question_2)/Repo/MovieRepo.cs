using Code_Challenge_9_Question_2_.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Code_Challenge_9_Question_2_.Repo
{
    public class MovieRepo<T> : IMovieRepo<T> where T : class
    {
        MovieContext db;
        DbSet<T> dbset;

        public MovieRepo()
        {
            db = new MovieContext();
            dbset = db.Set<T>();
        }

        public void Delete(object Id)
        {
            T getModel = dbset.Find(Id);
            dbset.Remove(getModel);
        }

        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public T GetByID(object Id)
        {
            return dbset.Find(Id);
        }

        public void Insert(T obj)
        {
            dbset.Add(obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        // Extra methods for the requirements
        public IEnumerable<T> GetByYear(int year)
        {
            if (typeof(T) == typeof(Movie))
            {
                return db.Movies.Where(m => m.DateofRelease.Year == year).Cast<T>().ToList();
            }
            return new List<T>();
        }

        public IEnumerable<T> GetByDirector(string directorName)
        {
            if (typeof(T) == typeof(Movie))
            {
                return db.Movies.Where(m => m.DirectorName == directorName).Cast<T>().ToList();
            }
            return new List<T>();
        }
    }
}