using Contact_DataAccess.Data;
using Contact_DataAccess.Interface;
using Contact_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_DataAccess.Repository
{
    public class ContactRepository : IRepository<Contact>
    {
        ApplicationDbContext _dbContext;
        public ContactRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public Contact Create(Contact _object)
        {
            var obj = _dbContext.Contacts.Add(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        //Deleting the Contact permanently from the DB
        public void Delete(Contact _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        //Marking the contact as deleted by changing the status
        public void DeleteByStatus(Contact _object)
        {
            var contact = _dbContext.Contacts.Where(x => x.Email == _object.Email).FirstOrDefault();
            contact.Status = true;
            _dbContext.SaveChanges();
        }

        public IEnumerable<Contact> GetAll()
        {
            return _dbContext.Contacts.Where(x => x.Status == false).ToList();
        }

        public Contact GetById(int Id)
        {
            return _dbContext.Contacts.Where(x => x.Status == false && x.Id == Id).FirstOrDefault();
        }

        public Contact Update(Contact _object)
        {
            var contact = _dbContext.Contacts.Where(x => x.Id == _object.Id).FirstOrDefault();
            contact.FirstName = _object.FirstName;
            contact.LastName = _object.LastName;
            contact.Phone = _object.Phone;
            contact.Email = _object.Email;
            contact.Status = false;
            _dbContext.SaveChanges();
            return contact;
        }
    }
}
