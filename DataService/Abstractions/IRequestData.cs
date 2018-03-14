using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Abstractions
{
    public interface IRequestData<T> : IEnumerable<T>
    {
    }
}
