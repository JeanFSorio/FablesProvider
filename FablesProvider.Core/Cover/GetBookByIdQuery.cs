using FablesProvider.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FablesProvider.Core.Cover;

public class GetBookByIdQuery(IRepository repository)
{
    private readonly IRepository _repository = repository;

    public BookCover Handle(int id)
    {
        return _repository.Get<BookCover>(id).Result;
    }
}
