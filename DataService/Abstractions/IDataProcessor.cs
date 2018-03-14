using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataService.Abstractions
{
    public interface IDataProcessor<T>
    {
        IEnumerable<IRequestData<T>> RequestDataList { get; }

        IEnumerable<IResponseData> ProcessRequestData(Expression<Func<IRequestData<T>, bool>> predicate);
    }
}
