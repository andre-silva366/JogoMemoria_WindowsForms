namespace JogoMemoria;

public partial class FormTelaInicial : Form
{
    List<PictureBox> pictureBoxes;
    List<string> caminhoDeImagens = new();
    List<string> caminhoDeImagens2 = new();
    List<string> listaImagens = new();
    List<PictureBox> picBox = new List<PictureBox>();
    int cartasAbertas = 0;
    string pasta = "D:\\andre\\Projetos\\JogoDaMemoria\\JogoMemoria\\JogoMemoria\\Images";
    string imagemPadrao = "D:\\andre\\Projetos\\JogoDaMemoria\\JogoMemoria\\JogoMemoria\\Images2\\visualstudio2022.jpg";
    int indice1 = -1;
    int indice2 = -1;
    int pontuacao = 0;
    int tempo = 120;

    private static System.Timers.Timer timer;

    bool jogoComecou;

    List<int> numeroIndices = new();

    public FormTelaInicial()
    {
        InitializeComponent();

        try
        {
            string[] arquivos = Directory.GetFiles(pasta);
            int i = 0;
            foreach (var item in arquivos)
            {
                caminhoDeImagens.Add(item);
                numeroIndices.Add(i);
                i++;
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        pictureBoxes = new List<PictureBox>()
        {
            pictureBox1A, pictureBox2A, pictureBox3A, pictureBox4A, pictureBox5A, pictureBox6A,
            pictureBox1B, pictureBox2B, pictureBox3B, pictureBox4B, pictureBox5B, pictureBox6B,
            pictureBox1C, pictureBox2C, pictureBox3C, pictureBox4C, pictureBox5C, pictureBox6C,
            pictureBox1D, pictureBox2D, pictureBox3D, pictureBox4D, pictureBox5D, pictureBox6D,
            pictureBox1E, pictureBox2E, pictureBox3E, pictureBox4E, pictureBox5E, pictureBox6E,
            pictureBox1F, pictureBox2F, pictureBox3F, pictureBox4F, pictureBox5F, pictureBox6F,
            pictureBox1G, pictureBox2G, pictureBox3G, pictureBox4G, pictureBox5G, pictureBox6G
        };

        Random random = new Random();

        //Duplicar os indices
        List<int> numeroCartas = new List<int>(numeroIndices);
        numeroCartas.AddRange(numeroIndices);

        //Duplicar caminho de imagens
        caminhoDeImagens2 = new List<string>(caminhoDeImagens);
        caminhoDeImagens2.AddRange(caminhoDeImagens);

        //Embaralhar a lista

        var listaDeIndicesEmbaralhada = EmbaralharLista(numeroCartas);

        listaImagens = EmbaralharLista(caminhoDeImagens2);

        int n = numeroCartas.Count;
       
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            int valor = numeroCartas[k];
            numeroCartas[k] = numeroCartas[n];
            numeroCartas[n] = valor;

        }

        //lista embaralhada = 42
        //caminhos de imagem = 21

        int indice = 0;

        foreach (var item in pictureBoxes)
        {
            item.Image = Image.FromFile(imagemPadrao);
        }

        foreach (var item in pictureBoxes)
        {
            item.Click += new EventHandler(PictureBox_Click);
        }

    }

    private void PictureBox_Click(object sender, EventArgs e)
    {
        PictureBox pictureBox = sender as PictureBox;
        cartasAbertas++;

        if (cartasAbertas == 1)
        {
            indice1 = pictureBoxes.IndexOf(pictureBox);
            pictureBox.Image = Image.FromFile(listaImagens[indice1]);
            picBox.Add(pictureBox);
        }
        if (cartasAbertas == 2)
        {
            indice2 = pictureBoxes.IndexOf(pictureBox);
            pictureBox.Image = Image.FromFile(listaImagens[indice2]);
            picBox.Add(pictureBox);
            if (listaImagens[indice1] == listaImagens[indice2])
            {
                pontuacao += 10;
                labelPontuacaoJogador.Text = pontuacao.ToString();
                foreach (var item in picBox)
                {
                    item.Visible = false;
                }

            }
            else
            {
                picBox.Clear();
            }
        }
        else if (cartasAbertas == 3)
        {
            DefineImagemPadrao();
            cartasAbertas = 0;
        }

    }

    private List<string> EmbaralharLista(List<string> lista)
    {
        Random rnd = new Random();
        int n = lista.Count;

        while (n > 1)
        {
            n--;
            int k = rnd.Next(n + 1);
            string valor = lista[k];
            lista[k] = lista[n];
            lista[n] = valor;

        }

        return lista;
    }

    private List<int> EmbaralharLista(List<int> lista)
    {
        Random rnd = new Random();
        int n = lista.Count;

        while (n > 1)
        {
            n--;
            int k = rnd.Next(n + 1);
            int valor = lista[k];
            lista[k] = lista[n];
            lista[n] = valor;

        }

        return lista;
    }

    private void DefineImagemPadrao()
    {
        foreach (var item in pictureBoxes)
        {
            item.Image = Image.FromFile(imagemPadrao);
        }
    }
            
}
