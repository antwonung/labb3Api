using labb3Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace labb3Api.Repository
{
    public class RepositoryClass<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private ApiDatabaseContext _context = null;
        private DbSet<TEntity> table = null;
       
        public RepositoryClass()
        {
            this._context = new ApiDatabaseContext();
            table = _context.Set<TEntity>();
        }
        public RepositoryClass(ApiDatabaseContext _context)
        {
            this._context = _context;
            table = _context.Set<TEntity>();
        }
        
        //JOINA ANDRA MODELLER
        public IQueryable<TEntity> Query => table;
  
        //HÄMTA ALLA RADER UR MODELLEN
        public IEnumerable<TEntity> GetAll()
        {
            //hämta hela tabell från db
            try
            {
                
                if (table == null)
                {
                    return StatusCode(404, "No user found");
                }
                return table.ToList();
                

            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occurred");

            }
            
            
        }
    



       

        private IEnumerable<TEntity> StatusCode(int v1, string v2)
        {
            throw new NotImplementedException();
        }

    
        //LÄGG TILL EN RAD I MODELLEN
        public void Insert(TEntity obj)
        {
            table.Add(obj);
            
        }

        //SPARA ÄNDRINGAR
        public void Save()
        {
            _context.SaveChanges();
        }

        //UPPDATERA EN RAD I MODELL 
        public void Update(TEntity obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

       
    }
}
