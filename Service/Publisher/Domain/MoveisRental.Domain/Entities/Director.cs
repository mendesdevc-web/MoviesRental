using MoveisRental.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MoveisRental.Domain.Entities
{
    public class Director : Entity
    {
        protected Director()
        {

        }
        public Director(
            string name,
            string surname)
        {
            UpdateName(name);
            UpdateSurname(surname);
        }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public const int Min_Length = 3;
        public const int Max_Length = 30;

        private List<Dvd> _dvds = new List<Dvd>();
        public IReadOnlyList<Dvd> Dvds => _dvds;

        public string FullName ()
        {
            return $"{Name} {Surname}";
        }

        public void UpdateName(string name)
        {
            if(!ValidateNome(name))
                throw new DomainException($"Invalid name for director.");

            Name = name;
        }

        public void UpdateSurname(string surname)
        {
            if (!ValidateNome(surname))
                throw new DomainException($"Invalid surname for director.");

            Surname = surname;
        }

        private bool ValidateNome(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length < Min_Length || value.Length > Max_Length)
                return false;
            return Regex.IsMatch(value, @"^[a-zA-Z]+$");
        }
    }
}
