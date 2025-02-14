namespace UrunSatisSistemi.Models
{
    public class Products
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Stok { get; set; }

        public int PurchasePrice { get; set; }

        public int SalesPrice { get; set; }

        public string ImageURL { get; set; }
    }
}
