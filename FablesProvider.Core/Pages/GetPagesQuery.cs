using FablesProvider.Core.Models;
using FablesProvider.Core.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FablesProvider.Core.Pages;

public class GetPagesQuery (IRepository repository)
{
    private readonly IRepository _repository = repository;

    public IList<BookPage> Handle () {
        return _repository.GetAll<BookPage>().Result;
    }
}
