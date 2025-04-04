﻿using MongoDB.Bson;

namespace SecondMVC.Models
{
    public class User : DB_SaveableObject
    {
        public string username { get; set; }
        public string password { get; set; }
        public List<Doggo> user_dogs { get; set; } = new List<Doggo>();
        public User() { }
    }
}
