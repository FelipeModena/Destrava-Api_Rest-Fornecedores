using Api_Fornecedor.Model;
using Api_Fornecedor.Model.Base;
using ApiRestComASPNet.Model;
using ApiRestComASPNet.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestComASPNet.Repository.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private MySqlContext _mySqlContext;
        private DbSet<T> dataSet;

        public GenericRepository(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
            dataSet = _mySqlContext.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                dataSet.Add(item);
                _mySqlContext.SaveChanges();
            }
            catch (Exception e )
            {

                LogDesenvolvedor logDesenvolvedor = new LogDesenvolvedor {
                    DateTime = DateTime.Now,
                    Error=e.Message,
                };
                _mySqlContext.LogDesenvolvedor.Add(logDesenvolvedor);
            }
            return item;
        }

        public void Delete(long id)
        {
            var result = dataSet.SingleOrDefault(personDb => personDb.Id == id);
            if (result != null)
            {
                try
                {
                    dataSet.Remove(result);
                    _mySqlContext.SaveChanges();
                }
                catch (Exception e)
                {

                    LogDesenvolvedor logDesenvolvedor = new LogDesenvolvedor
                    {
                        DateTime = DateTime.Now,
                        Error = e.Message,
                    };
                    _mySqlContext.LogDesenvolvedor.Add(logDesenvolvedor);
                }
            }
        }

        public bool Exists(long id)
        {
            if (dataSet.FirstOrDefault(person => person.Id == id) != null)
            {
                return true;
            }
            else return false;
        }

        public List<T> FindAll()
        {
            return dataSet.ToList();
        }

        public T FindById(long id)
        {
            return dataSet.SingleOrDefault(personDb => personDb.Id == id);
        }

        public T Update(T item)
        {
            var result = dataSet.SingleOrDefault(personDb => personDb.Id == item.Id);
            if (result != null)
            {
                try
                {
                    _mySqlContext.Entry(result).CurrentValues.SetValues(item);
                    _mySqlContext.SaveChanges();
                    return result;
                }
                catch (Exception e)
                {

                    LogDesenvolvedor logDesenvolvedor = new LogDesenvolvedor
                    {
                        DateTime = DateTime.Now,
                        Error = e.Message,
                    };
                    _mySqlContext.LogDesenvolvedor.Add(logDesenvolvedor);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}

