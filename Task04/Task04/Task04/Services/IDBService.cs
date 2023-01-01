using System.Collections.Generic;
using Task04.Models;

namespace Task04.Services
{
    public interface IDBService
    {
        List<Animal> GetAnimals(string orderBy);
        void CreateAnimal(Animal animal);
        void ChangeAnimal(int idAnimal, Animal animal);
        void DeleteAnimal(int idAnimal);
    }
}
