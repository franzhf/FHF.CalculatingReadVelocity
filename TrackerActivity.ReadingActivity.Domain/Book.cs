using System;
using TrackerActivity.Domain.Activity;
namespace TrackerActivity.Domain.ReadingActivity
{
    public class Book:Entity
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }

        public Book()
        {
        }
        
    }
}