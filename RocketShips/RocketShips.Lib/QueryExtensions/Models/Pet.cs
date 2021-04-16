namespace RocketShips.Lib.QueryExtensions.Models
{

    class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Vaccinated { get; set; }
        public Person Owner { get; set; }
    }

}
