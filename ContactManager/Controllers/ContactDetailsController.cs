using Contact_Business.Service;
using Contact_DataAccess.Interface;
using Contact_DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ContactManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactDetailsController : ControllerBase
    {
        private readonly ContactService _contactService;


        public ContactDetailsController(ContactService ContactService)
        {
            _contactService = ContactService;
        }
        //Add Contact  
        [HttpPost("AddContact")]
        public ResponseModel AddContact([FromBody] Contact contact)
        {
            ResponseModel responseModel = new ResponseModel();
            if(contact != null)
            {
                var result = _contactService.AddContact(contact);
                if (result != null)
                {
                    responseModel.Data = result;
                    responseModel.Message = "Contact added successfully";
                    responseModel.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    responseModel.Data = null;
                    responseModel.Message = "Some error occured";
                    responseModel.StatusCode = HttpStatusCode.BadRequest;
                }
            }
            else
            {
                responseModel.Data = null;
                responseModel.Message = "Invalid contact details";
                responseModel.StatusCode = HttpStatusCode.NotAcceptable;
            }
            
            return responseModel;
        }
        //Delete Contact  
        [HttpDelete("DeleteContact")]
        public ResponseModel DeleteContact(string Email)
        {
            ResponseModel responseModel = new ResponseModel();
            if (!String.IsNullOrEmpty(Email))
            {
                var result = _contactService.DeleteContact(Email);
                if(result)
                {
                    responseModel.Data = true;
                    responseModel.Message = "Contact deleted successfully";
                    responseModel.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    responseModel.Data = false;
                    responseModel.Message = "User not found";
                    responseModel.StatusCode = HttpStatusCode.NotAcceptable;
                }
            }
            else
            {
                responseModel.Data = null;
                responseModel.Message = "Please provide an email value";
                responseModel.StatusCode = HttpStatusCode.NotAcceptable;
            }
            return responseModel;
        }

        //Delete Contact By Status 
        [HttpDelete("DeleteContactByStatus")]
        public ResponseModel DeleteContactByStatus(string Email)
        {
            ResponseModel responseModel = new ResponseModel();
            if(!String.IsNullOrEmpty(Email))
            {
                var result = _contactService.DeleteContactByStatus(Email);
                if(result)
                {
                    responseModel.Data = true;
                    responseModel.Message = "Contact deleted successfully";
                    responseModel.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    responseModel.Data = false;
                    responseModel.Message = "User not found";
                    responseModel.StatusCode = HttpStatusCode.NotFound;
                }
            }
            else
            {
                responseModel.Data = null;
                responseModel.Message = "Please provide an email value";
                responseModel.StatusCode = HttpStatusCode.NotAcceptable;
            }
            return responseModel;
        }

        //Update Contact  
        [HttpPut("UpdateContact")]
        public ResponseModel UpdateContact(Contact Object)
        {
            ResponseModel responseModel = new ResponseModel();
            if(Object!= null)
            {
                var data = _contactService.UpdateContact(Object);
                if (data != null)
                {
                    responseModel.Data = data;
                    responseModel.Message = "Contact updated successfully";
                    responseModel.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    responseModel.Data = null;
                    responseModel.Message = "Contact not found";
                    responseModel.StatusCode = HttpStatusCode.NotFound;
                }
            }
            else
            {
                responseModel.Data = null;
                responseModel.Message = "Invalid contact details";
                responseModel.StatusCode = HttpStatusCode.NotAcceptable;
            }
            
            return responseModel;
        }
        //GET Contact by Id  
        [HttpGet("GetContactById")]
        public ResponseModel GetContactById(int Id)
        {
            ResponseModel responseModel = new ResponseModel();
            if(Id != 0)
            {
                var data = _contactService.GetContactById(Id);
                if (data != null)
                {
                    responseModel.Data = data;
                    responseModel.Message = "Success";
                    responseModel.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    responseModel.Data = null;
                    responseModel.Message = "Contact not found";
                    responseModel.StatusCode = HttpStatusCode.NotFound;
                }
            }
            else
            {
                responseModel.Data = null;
                responseModel.Message = "Invalid ID value";
                responseModel.StatusCode = HttpStatusCode.NotAcceptable;
            }
            
            return responseModel;
        }

        //GET Contact by Email  
        [HttpGet("GetContactByEmail")]
        public ResponseModel GetContactByEmail(string Email)
        {
            ResponseModel responseModel = new ResponseModel();
            if(!String.IsNullOrEmpty(Email))
            {
                var data = _contactService.GetContactByEmail(Email);

                if (data != null)
                {
                    responseModel.Data = data;
                    responseModel.Message = "Success";
                    responseModel.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    responseModel.Data = null;
                    responseModel.Message = "Contact not found";
                    responseModel.StatusCode = HttpStatusCode.NotFound;
                }
            }
            else
            {
                responseModel.Data = null;
                responseModel.Message = "Invalid email value";
                responseModel.StatusCode = HttpStatusCode.NotAcceptable;
            }
            
            return responseModel;
        }


        //GET All Contacts  
        [HttpGet("GetAllContacts")]
        public ResponseModel GetAllContacts()
        {
            ResponseModel responseModel = new ResponseModel();
            var data = _contactService.GetAllContacts();

            if(data != null)
            {
                responseModel.Data = data;
                responseModel.Message = "Success";
                responseModel.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                responseModel.Data = null;
                responseModel.Message = "No Contacts found";
                responseModel.StatusCode = HttpStatusCode.NotFound;
            }
            
            return responseModel;
        }
    }
}
