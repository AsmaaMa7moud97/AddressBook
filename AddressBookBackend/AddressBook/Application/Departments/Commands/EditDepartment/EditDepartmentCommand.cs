using MediatR;
using System;

namespace AddressBook.Application.Commands
{
    public class EditDepartmentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
      
    }
}