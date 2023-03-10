namespace Lab_2_Inheritance.Entities
{
    internal class Employee
    {
        protected string id;
        protected string name;
        protected string address;

        public string ID { get { return id; } }
        public string Name { get { return name; } }
        public string Address { get { return address; } }

        public Employee () { }  

        public Employee(string id, string name, string address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }
        public  virtual double CalcWeeklyPay()
        {
            return 0;
        }
    }
}