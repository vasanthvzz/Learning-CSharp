using FieldExample;

class Program
{
    static void Main()
    {
        Product product1, product2, product3;
        product1 = new Product();
        Product.TotalNoProduct++;
        product2 = new Product();
        Product.TotalNoProduct++;
        product3 = new Product();
        Product.TotalNoProduct++;

        product1.productId = 1001;
        product1.productName = "Mobile";
        product1.cost = 20000;
        product1.quantityInStock = 1200;

        product2.productId = 1002;
        product2.productName = "Laptop";
        product2.cost = 45000;
        product2.quantityInStock = 3400;

        product3.productId = 1003;
        product3.productName = "";
        product3.cost = 1000;
        product3.quantityInStock = 1000;

        Console.WriteLine("Product id : "+product1.productId);
        Console.WriteLine("Product name : "+product1.productName);
        Console.WriteLine("Product cost : "+product1.cost);
        Console.WriteLine("Product quantity : "+product1.quantityInStock);

        Console.WriteLine("Product id : " + product2.productId);
        Console.WriteLine("Product name : " + product2.productName);
        Console.WriteLine("Product cost : " + product2.cost);
        Console.WriteLine("Product quantity : " + product2.quantityInStock);

        Console.WriteLine("Product id : " + product3.productId);
        Console.WriteLine("Product name : " + product3.productName);
        Console.WriteLine("Product cost : " + product3.cost);
        Console.WriteLine("Product quantity : " + product3.quantityInStock);

        Console.WriteLine("Total number of products :"+Product.TotalNoProduct);
    }

}