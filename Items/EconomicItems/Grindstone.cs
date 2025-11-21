namespace GamePrototype.Items.EconomicItems
{
    public sealed class Grindstone : EconomicItem
    {
        public void Repair()
        { 


        }

        public override bool Stackable => false;

        public Grindstone(string name) : base(name)
        {
        }    
    }
}
