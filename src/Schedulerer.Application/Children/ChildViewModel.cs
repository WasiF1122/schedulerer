using System;
using Schedulerer.Enums;

namespace Schedulerer.Application.Children
{
    public class ChildViewModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public DateTime Birthdate { get; set; }
        public Routine Routine { get; set; }
    }
}