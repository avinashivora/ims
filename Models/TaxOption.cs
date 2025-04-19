namespace ims.Models
{
    public class TaxOption
    {
        public decimal Rate { get; set; }
        public string Display { get; set; }

        public TaxOption(decimal rate, string display)
        {
            Rate = rate;
            Display = display;
        }
    }
}