class Libro{

    private string Titulo {get; set;}
    private string Autor {get; set;}
    private int Anyo {get; set;}
    private string Genero {get; set;}
    private bool Disponible {get; set;}
    public static List<string> todosLosLibros = new List<string>();


    public Libro(string titulo)
    {
        this.Titulo = titulo;
        this.Autor = "Desconocido/Por rellenar";
        this.Anyo = 0;
        this.Genero = "Desconocido/Por rellenar";
        this.Disponible = true;
        TodosLosLibros.Add(titulo);
    }
    public Libro(string titulo, string autor)
    {
        this.Titulo = titulo;
        this.Autor = autor;
        this.Anyo = 0;
        this.Genero = "Desconocido/Por rellenar";
        this.Disponible = true;
        TodosLosLibros.Add(titulo);
    }

    public Libro(string titulo, int anyo)
    {
        this.Titulo = titulo;
        this.Autor = "Desconocido/Por rellenar";
        this.Anyo = anyo;
        this.Genero = "Desconocido/Por rellenar";
        TodosLosLibros.Add(titulo); 
    }
    public Libro(string titulo, string genero)
    {
        this.Titulo = titulo;
        this.Autor = "Desconocido/Por rellenar";
        this.Anyo = 0;
        this.Genero = genero;
        TodosLosLibros.Add(titulo);
    }



    public Libro(string titulo, string autor, int anyo)
    {
        this.Titulo = titulo;
        this.Autor = autor;
        this.Anyo = anyo;
        this.Genero = "Desconocido/Por rellenar";
        TodosLosLibros.Add(titulo); 
    }

    public Libro(string titulo, string autor, string genero)
    {
        this.Titulo = titulo;
        this.Autor = autor;
        this.Anyo = 0;
        this.Genero = genero;
        TodosLosLibros.Add(titulo); 
    }

}
