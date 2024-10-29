namespace P01_Intro.Models
{
    public class Author
    {
        public Author() { }

        public Author(int id, string vardas, string pavarde)
        {
            Id = id;
            Vardas = vardas;
            Pavarde = pavarde;
        }

        public int Id { get; set; }
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
    }
}
