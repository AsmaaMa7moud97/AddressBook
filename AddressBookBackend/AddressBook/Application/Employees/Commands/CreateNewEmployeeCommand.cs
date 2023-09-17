using MediatR;
using System;

namespace AddressBook.Application.Commands
{
    public class CreateNewEmployeeCommand : IRequest<int>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string LogoImageName { get; set; }
        public string LogoImageStorageFileName { get; set; }
        public string Password { get; set; }
        public int JobTitleId { get; set; }
        public int DepartmentId { get; set; }
        public string UserId { get; set; }
    }
}