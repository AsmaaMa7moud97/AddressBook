using MediatR;
using System.Collections.Generic;

namespace AddressBook.Application
{
    public class GetDepartmentsQuery : IRequest<List<DepartmentModel>>
    {
        
    }
}