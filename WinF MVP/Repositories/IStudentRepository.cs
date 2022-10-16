using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinF_MVP.Models;

namespace WinF_MVP.Repositories;

internal interface IStudentRepository: IRepository<Student>
{
    Student? GetById(Guid Id);
}
