using MediatR;
using System;

namespace AddressBook.Application.Commands
{
    public class CreateNewDepartmentCommand : IRequest<int>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
      
    }
}