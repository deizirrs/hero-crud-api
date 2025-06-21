using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.Models
{
    public class PersonModel
    {
        public PersonModel(string name)
        {
            Name = name;
            Id = Guid.NewGuid();

        }
        public Guid Id { get; init; }
        public string Name { get; private set; }

        //Boa prática no conceito de encapsulamento.
        //Não permiti que o valor seja alterado diretamente de fora e controla as alterações via método.
        public void ChangeName(string name)
        {
            Name = name;
        }

        public void SetInactive()
        {
            Name = "Desativado";
        }
    }
}