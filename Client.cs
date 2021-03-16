namespace MortgageCalculator
{
    //**Constructor**
    class Client
    {
        private string name;
        //Property tool if required
        public string Name   // **property**
        {
            get { return name; }
            set { name = value; }
        }

        public Client(string name)
        {
            this.name = name;
        }

        //**Non-static non-void method**
        public string DisplayName()
        {
            return name;
        }
    }
}
