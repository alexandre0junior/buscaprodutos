using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.Controls;

public partial class MainPage : ContentPage
{
    public ObservableCollection<string> Produtos { get; set; }
    public ObservableCollection<string> ProdutosFiltrados { get; set; }

    public MainPage()
    {
        InitializeComponent();
        
        Produtos = new ObservableCollection<string>
        {
            "Arroz", "Feijão", "Macarrão", "Açúcar", "Café"
        };
        
        ProdutosFiltrados = new ObservableCollection<string>(Produtos);
        BindingContext = this;
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = e.NewTextValue.ToLower();
        ProdutosFiltrados.Clear();

        foreach (var item in Produtos.Where(p => p.ToLower().Contains(searchText)))
        {
            ProdutosFiltrados.Add(item);
        }
    }
}