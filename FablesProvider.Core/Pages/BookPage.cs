using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FablesProvider.Core.Pages;


public class BookPage() : DbEntityBase
{
    public int IdCover { get; set; }
    public string Text { get; set; } = "";
    public string ImageName { get; set; } = "";
    public int Page { get; set; }
};