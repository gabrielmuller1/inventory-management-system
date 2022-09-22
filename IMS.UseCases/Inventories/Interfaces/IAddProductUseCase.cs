using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IMS.CoreBusiness;

namespace IMS.UseCases.Products
{
    public interface IAddProductUseCase
    {
        Task ExecuteAsync ( Product product );
    }
}
