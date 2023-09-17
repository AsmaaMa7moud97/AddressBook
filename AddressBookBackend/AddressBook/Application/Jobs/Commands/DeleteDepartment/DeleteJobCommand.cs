using MediatR;
using System;

namespace AddressBook.Application.Commands
{
    public class DeleteJobCommand : IRequest
    {
        public int Id { get; set; }
      
      
    }
}