namespace WindowsForms
{
    

    public abstract class ProductType
    {
        public abstract string Type();
    }

    public class Kg : ProductType
    {
        public override string Type()
        {
            return "Kg";
        }
    }

    public class Funt : ProductType
    {
        public override string Type()
        {
            return "Funt";
        }
    }

    public class Gramm : ProductType
    {
        public override string Type()
        {
            return "Gramm";
        }
    }

    public abstract class ProductFactory
    {
        public abstract ProductType CreateType();
    }

    public class KgFactory : ProductFactory
    {
        public override ProductType CreateType()
        {
            return new Kg();
        }
    }

    public class FuntFactory : ProductFactory
    {
        public override ProductType CreateType()
        {
            return new Funt();
        }
    }

    public class GrammFactory : ProductFactory
    {
        public override ProductType CreateType()
        {
            return new Gramm();
        }
    }

    public class PaternDemonstration
    {
        private ProductType productType;
        public PaternDemonstration(ProductFactory factory)
        {
            productType = factory.CreateType();
        }
        public string Run()
        {
            return productType.Type();
        }
    }
}
