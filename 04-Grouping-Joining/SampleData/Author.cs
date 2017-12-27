using System;

namespace SampleData
{
    public class Author
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String WebSite { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}