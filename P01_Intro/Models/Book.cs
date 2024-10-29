namespace P01_Intro.Models
{
    public class Book
    {
        public Book() { }

        public Book(int id, string pavadinimas, List<Author> autoriai, int metai)
        {
            Id = id;
            Pavadinimas = pavadinimas;
            Autoriai = autoriai;
            LeidybosMetai = metai;
        }

        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public List<Author> Autoriai { get; set; }
        public int LeidybosMetai { get; set; }

    }
}
