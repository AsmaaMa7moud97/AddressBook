using MediatR;
using System;

namespace AddressBook.Application.Commands
{
    public class CreateJobCommand : IRequest<int>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
      
    }
}