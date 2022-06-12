namespace Laba_2
{
    public class Product
    {
        public string name { get; set; }

        public float price { get; set; }

        public int count { get; set; }

        public virtual float quality => price / count;

        public Product(string name, float price, int count = 1)
        {
            this.name = name;
            this.price = price;
            this.count = count;
        }

        public override string ToString()
        {
            return $"Наименование: {name}\nСтоимость: {price}\nКоличество: {count}\nКачество: {quality}";
        }

        public virtual void ToGridRow(string[] row)
        {
            row[0] = name;
            row[1] = price.ToString();
            row[2] = count.ToString();
            row[3] = quality.ToString();
        }
    }
}
