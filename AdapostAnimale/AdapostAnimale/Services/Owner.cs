using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdapostAnimale.Services
{
    interface IOwner
    {
        string OwnerName { get; set; }
        string OwnerEmail { get; set; }
    }
}
