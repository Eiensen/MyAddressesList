using MyList.Shared;
using System.Collections.Generic;

namespace UseCases
{
    public interface IViewAddresssUseCase
    {
        IEnumerable<Address> Execute();
    }
}