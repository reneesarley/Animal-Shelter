using System.Collections.Generic;
using MySql.Data.MySqlClient;
using AnimalShelter;
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


        public Animal( string type, string breed, string name, int age, string gender, string size, int Id = 0)
        {
            _id = Id;
            _type = type;
            _breed = breed;
            _name = name;
            _age = age;
            _gender = gender;
            _size = size;
        }

        public static List<Animal> GetAll()
        {
            List<Animal> allAnimals = new List<Animal> { new Animal( "test type", "test breed", "test name", 1, "test gender", "test size", 0) };
             MySqlConnection conn = DB.Connection();
             conn.Open();
             MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
             cmd.CommandText = @"SELECT * FROM items;";
             MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
             while(rdr.Read())
             {
                 int animalId = rdr.GetInt32(0);
                 string animalType = rdr.GetString(1);
                string animalBreed = rdr.GetString(2);
                string animalName = rdr.GetString(3);
                int animalAge = rdr.GetInt32(4);
                string animalGender = rdr.GetString(5);
                string animalSize = rdr.GetString(6);
                Animal newAnimal = new Animal( animalType, animalBreed, animalName, animalAge, animalGender, animalSize, animalId);
                 allAnimals.Add(newAnimal);
             }

               conn.Close();

             if (conn != null)
             {
             conn.Dispose();
             }

            return allAnimals;
        }

        public override bool Equals(System.Object otherAnimal)
        {
            if (!(otherAnimal is Animal))
            {
                return false;
            }
            else
            {
                Animal newAnimal = (Animal) otherAnimal;
                bool typeEquality = (this._type == newAnimal._type);
                bool breedEquality = (this._breed == newAnimal._breed);
                bool nameEquality = (this._name == newAnimal._name);
                bool ageEquality = (this._age == newAnimal._age);
                bool genderEquality = (this._gender == newAnimal._gender);
                bool sizeEquality = (this._size == newAnimal._size);
                return (typeEquality && breedEquality && nameEquality && ageEquality && genderEquality && sizeEquality);
            }
        }

        public override int GetHashCode()
        {
            return this._id.GetHashCode();
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO animals (type, breed, name, age, gender, size) VALUES (@AnimalType, @AnimalBreed, @AnimalName, @AnimalAge, @AnimalGender, @AnimalSize);";

            MySqlParameter type = new MySqlParameter();
            type.ParameterName = "@AnimalType";
            type.Value = _type;
            cmd.Parameters.Add(type);

            MySqlParameter breed = new MySqlParameter();
            breed.ParameterName = "@AnimalBreed";
            breed.Value = _breed;
            cmd.Parameters.Add(breed);


            //cmd.ExecuteNonQuery();
            //_id = (int)cmd.LastInsertedId;  // Notice the slight update to this line of code!

            //conn.Close();
            //if (conn != null)
            //{
            //    conn.Dispose();
            //}
            
        }
    }
}
