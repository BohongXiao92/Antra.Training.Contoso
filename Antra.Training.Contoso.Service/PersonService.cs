﻿using Antra.Training.Contoso.Data.Repositories;
using Antra.Training.Contoso.Model;
using System;
using System.Collections.Generic;

namespace Antra.Training.Contoso.Service
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository) => _personRepository = personRepository;

        public Person GetPersonByUserName(string username)
        {
            var person = _personRepository.Get(p => p.Email == username);
            return person;
        }

        public Person GetValidPerson(string username, string password)
        {
            var person = _personRepository.Get(p => p.Email == username && p.Password == password);
            return person;
        }

        public void AddPerson(Person person)
        {
            _personRepository.Add(person);
        }

        public List<Person> GetPeopleByRole(int roleId)
        {
            // TODO ... 
            throw new NotImplementedException();
        }
    }

    public interface IPersonService
    {
        Person GetPersonByUserName(string username);
        Person GetValidPerson(string username, string password);
        void AddPerson(Person person);
        List<Person> GetPeopleByRole(int roleId);
    }
}
