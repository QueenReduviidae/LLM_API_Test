using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LLM_Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Responses.ModelList models = Http.Get() ?? new Responses.ModelList();
            Debug.WriteLine(" Amount of models found: " + models.data.Count());
            if(models.data.Count > 0)
            {
                ModelCombobox.Items.Clear();
                foreach (Responses.Model model in models.data)
                {
                    ModelCombobox.Items.Add(model);
                }
            }
        }

        private void ModelCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //TODO: Save chat history locally and load on change
        }
    }
}