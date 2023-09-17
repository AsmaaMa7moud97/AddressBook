using MediatR;
using System.Collections.Generic;

namespace AddressBook.Application
{
    public class GetSearchEmployeesQuery : IRequest<List<EmployeeModel>>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public int Age { get; set; }
        public int? JobTitleId { get; set; }
        public int? DepartmentId { get; set; }

    }
}