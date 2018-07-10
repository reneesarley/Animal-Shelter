using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ToDoList;
using System;

namespace AnimalShelter.Models
{
    public class Animal
    {
        private int _id;
        private string _type;
        private string _breed;
        private string _name;
        private int _age;
        private string _gender;
        private string _size;

        public Animal(int Id = 0, string type, string breed, string name, int age, string gender, string size)
        {
            _id = Id;
            _type = type;
            _breed = breed;
            _name = name;
            _age = age;
            _gender = gender;
            _size = size;
        }
    }
}
