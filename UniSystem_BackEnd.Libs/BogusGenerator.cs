using Bogus;
using Bogus.Extensions.Brazil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSystem_BackEnd.RepositoryTest.Lib
{
    public class BogusGenerator
    {
        private readonly Faker _faker;

        public BogusGenerator()
        {
            _faker = new Faker("pt_BR");
        }

        public string GerarNomeCompleto()
        {
            return _faker.Person.FullName;
        }

        public string GerarLogin()
        {
            return _faker.Person.Cpf(false);
        }

        public string GerarEmail()
        {
            return _faker.Internet.Email(_faker.Person.FirstName, _faker.Person.LastName);
        }

        //public string GerarNome()
        //{
        //    return _faker.Person.FirstName;
        //}

        //public string GerarSobrenome()
        //{
        //    return _faker.Person.LastName;
        //}
    }
}
