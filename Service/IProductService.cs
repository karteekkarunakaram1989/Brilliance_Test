using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface IProductService
    {
        int[] ArrayReverse(int[] productIds);

        int[] ArrayRemoveAt(int[] productIds, int toBeDeletedProductId);
    }
}
