using MediatR;
using System;

namespace AddressBook.Application.Commands
{
    public class DeleteDepartmentCommand : IRequest
    {
        public int Id { get; set; }
      
    }
}