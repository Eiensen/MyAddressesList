using MyList.Shared;
using System;
using System.Collections.Generic;

namespace UseCases
{
    public class ViewAddresssUseCase : IViewAddresssUseCase
    {
        private readonly IAddressRepository productRepository;

        public ViewAddresssUseCase(IAddressRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Address> Execute()
        {
            return productRepository.GetAddresses();
        }
    }
}
