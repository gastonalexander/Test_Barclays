namespace Standard_VAT_Rates_Per_Country
{
    public class Rootobject
    {
        public string details { get; set; }
        public object version { get; set; }
        public Rate[] rates { get; set; }
    }

    public class Rate
    {
        public string name { get; set; }
        public string code { get; set; }
        public string country_code { get; set; }
        public Period[] periods { get; set; }
    }

    public class Period
    {
        public string effective_from { get; set; }
        public Rates rates { get; set; }
    }

    public class Rates
    {
        public float super_reduced { get; set; }
        public float reduced { get; set; }
        public float standard { get; set; }
        public float reduced1 { get; set; }
        public float reduced2 { get; set; }
        public float parking { get; set; }
    }

}