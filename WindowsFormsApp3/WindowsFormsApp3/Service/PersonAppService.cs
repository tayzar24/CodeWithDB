using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp3.Common;
using WindowsFormsApp3.DataAccess.Dao;
using WindowsFormsApp3.Model;
using Dao= WindowsFormsApp3.DataAccess.Model;
using WindowsFormsApp3.Model.Response;

namespace WindowsFormsApp3.Service
{
    public class PersonAppService
    {
        public static ResGetPersonList GetAllPersonList()
        {
            ResGetPersonList result = new ResGetPersonList();
            try
            {
                var list = PersonDao.GetAllPersonList();

                result.IsSuccess = true;
                result.PersonList = ConvertToUIList(list);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = CreateMessage.CreateResultMessage(ex);
            }
            return result;
        }

        public static ResponseBase CreatePerson(Person input)
        {
            ResponseBase result = new ResponseBase();
            try
            {
                var personData = new Dao.Person
                {
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    Address = input.Address,
                    City = input.City
                };
                PersonDao.InsertPersonData(personData);

                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = CreateMessage.CreateResultMessage(ex);
            }
            return result;
        }

        #region Private Method

        private static List<Person> ConvertToUIList(List<Dao.Person> resultList)
        {
            List<Person> list = resultList.Select(s => new Person
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Address = s.Address,
                City = s.City
            }).ToList();

            return list;
        }
        #endregion
    }
}
