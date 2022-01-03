using Contact_DataAccess.Interface;
using Contact_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Business.Service
{
    public class ContactService
    {
        private readonly IRepository<Contact> _contact;

        public ContactService(IRepository<Contact> contact)
        {
            _contact = contact;
        }
        //Get Contact Details By Contact Id  
        public Contact GetContactById(int Id)
        {
            try
            {
                var contact = _contact.GetAll().Where(x => x.Id == Id).FirstOrDefault();
                if(contact != null)
                {
                    return contact;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        //Get Contact Details By Email  
        public Contact GetContactByEmail(string Email)
        {
            try
            {
                var data = _contact.GetAll().Where(x => x.Email == Email).FirstOrDefault();
                if(data != null)
                {
                    return data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //GET All Contact Details   
        public IEnumerable<Contact> GetAllContacts()
        {
            try
            {
                return _contact.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        //Add Contact  
        public Contact AddContact(Contact Contact)
        {
            try
            {
                return _contact.Create(Contact);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Delete Contact   
        public bool DeleteContact(string UserEmail)
        {
            try
            {
                var Data = _contact.GetAll().Where(x => x.Email == UserEmail).FirstOrDefault();
                if(Data != null)
                {
                    _contact.Delete(Data);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        //Delete Contact by changing the status
        public bool DeleteContactByStatus(string UserEmail)
        {
            var data = _contact.GetAll().Where(x => x.Email == UserEmail).FirstOrDefault();
            try
            {
                if (data != null)
                {
                    _contact.DeleteByStatus(data);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        //Update Contact Details  
        public Contact UpdateContact(Contact updatedContact)
        {
            if (_contact.GetAll().Where(x => x.Id == updatedContact.Id).Any())
            {
                try
                {
                    var contact = _contact.Update(updatedContact);
                    return contact;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }

        }
    }
}
