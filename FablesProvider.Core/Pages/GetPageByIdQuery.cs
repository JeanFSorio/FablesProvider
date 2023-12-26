using FablesProvider.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FablesProvider.Core.Pages;

public class GetPageByIdQuery(IRepository repository)
{
    private readonly IRepository _repository = repository;

    public BookPage Handle(int id)
    {
        return _repository.Get<BookPage>(id).Result;
    }
}
