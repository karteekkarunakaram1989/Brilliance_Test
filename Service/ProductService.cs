using System;

namespace Service
{
    public class ProductService : IProductService
    {
        public int[] ArrayRemoveAt(int[] productIds, int position)
        {
            if (position < 0 || position >= productIds.Length)
            {
                throw new Exception("Position out of the index");
            }
            for (int i = position; i < productIds.Length - 1; i++)
            {
                productIds[i] = productIds[i + 1];
            }
            var temp = new int[productIds.Length - 1];
            for (int i = 0; i < productIds.Length - 1; i++)
            {
                temp[i] = productIds[i];
            }
            productIds = temp;
            return productIds;
        }

        public int[] ArrayReverse(int[] productIds)
        {
            for (int i = 0; i < productIds.Length - i; i++)
            {
                var value = productIds[productIds.Length - i - 1];
                productIds[productIds.Length - i - 1] = productIds[i];
                productIds[i] = value;
            }
            return productIds;
        }
    }
}
