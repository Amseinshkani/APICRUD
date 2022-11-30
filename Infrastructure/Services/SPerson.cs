using Core.Domain;
using Core.Interface;
using Infrastructure.Data.DBContext;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SPerson : IPerson
    {
        private readonly DataConnection _DataConnection;
        public SPerson(DataConnection Connection)
        {
            _DataConnection= Connection;
        }

        private async Task<List<Person>> AllData() 
        {
            var data = await _DataConnection.People.ToListAsync();
            List<Person> list = new List<Person>();

            foreach (var item in data)
            {
                var Pr = new Person
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    City = item.City
                };
                list.Add(Pr);
            }
            return list;
        }

        public async Task<List<Person>> AddPerson(Person person)
        {
            TPerson TP = new TPerson()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                City = person.City,
            };
            _DataConnection.People.Add(TP);
            await _DataConnection.SaveChangesAsync();

            return await AllData();
        }
        public async Task<Person> findingOut(int Id)
        {
            var Select = await _DataConnection.People.FindAsync(Id);

            Person FindModel = new Person 
            {
            Id = Select.Id,
            FirstName = Select.FirstName,
            LastName = Select.LastName,
            City = Select.City,
            };

            return FindModel;
        }

        public async Task<Person> Updating(Person person)
        {
          var Select = await _DataConnection.People.FindAsync(person.Id);

            Select.Id = person.Id;
            Select.FirstName = person.FirstName;
            Select.LastName = person.LastName;
            Select.City = person.City;

            _DataConnection.People.Update(Select);
            await _DataConnection.SaveChangesAsync();

            var sender =new Person
            {
                Id = Select.Id,
                FirstName = Select.FirstName,
                LastName = Select.LastName,
                City = Select.City
            };
            return sender;

        }

        public async Task<List<Person>> Deleted(int Id)
        {
            var Select = await _DataConnection.People.FindAsync(Id);
            _DataConnection.People.Remove(Select);
            await _DataConnection.SaveChangesAsync();


            return await AllData();
        }

        public async Task<List<Person>> presentation()
        {
            return await AllData();
        }
    }
}
