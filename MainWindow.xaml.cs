using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace speedchecker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeArticleList();
           
        }

        public void InitializeArticleList()
        {

            ArticleList.Items.Add(new Article("The State of the World's Health", 913));
            ArticleList.Items.Add(new Article("Changing Attitudes Toward Cardiovascular Disease", 772));
            ArticleList.Items.Add(new Article("Medicine and Genetic Research", 976));
            ArticleList.Items.Add(new Article("Malaria: Portrait of a Disease", 1220));
            ArticleList.Items.Add(new Article("The Health Care Divide", 2018));

            ArticleList.Items.Add(new Article("The Age of Immigration", 978));
            ArticleList.Items.Add(new Article("Who Are Today's Immigrants?", 684));
            ArticleList.Items.Add(new Article("The Meeting of Cultures", 1330));
            ArticleList.Items.Add(new Article("One World: One Culture?", 1227));
            ArticleList.Items.Add(new Article("The Challenge of Diversity", 2217));

            ArticleList.Items.Add(new Article("When Does Language Learning Begin?", 931));
            ArticleList.Items.Add(new Article("Learning a Language as an Adult", 843));
            ArticleList.Items.Add(new Article("Rules of Speaking", 1173));
            ArticleList.Items.Add(new Article("Languages in Contact", 1264));
            ArticleList.Items.Add(new Article("The Advantages of Multilingualism", 2353));

            ArticleList.Items.Add(new Article("Ecology, Overpopulation, and Economic Development", 1311));
            ArticleList.Items.Add(new Article("The Aral Sea: An Environmental Crisis", 1019));
            ArticleList.Items.Add(new Article("Biodiversity and Tropical Rainforests", 1190));
            ArticleList.Items.Add(new Article("The Water Crisis", 1153));
            ArticleList.Items.Add(new Article("Managing Earth's Greenhouse", 2835));

        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            var selecteditem = ArticleList.SelectedItem as Article;
            if (selecteditem == null)
            {
                FeedbackTB.Text = "Did you select Article?";
                return;
            }

            var isNumeric = int.TryParse(InputMinute.Text, out int iminute);
            if(isNumeric==false)
            {
                FeedbackTB.Text = "check Minute";
                return;
            }
                

            var isNumeric2 = int.TryParse(InputSecond.Text, out int isecond);
            if (isNumeric2 == false)
            {
                FeedbackTB.Text = "check Seconds";
                return;
            }
            else if (isecond >= 60)
            {
                FeedbackTB.Text = "Seconds must be below 60";
                return;
            }
                

            float fdecimalsecond = (float)isecond / 60.0f;
            float freadtime = (float)iminute + fdecimalsecond;

            int iwords = selecteditem.words;

            float fWordPerMinute = (float)iwords / freadtime;

            WpmTB.Text = fWordPerMinute.ToString("n2");
        }
    }


    public class Article
    {
        public string title { get; set; }
        public int words { get; set; } 
        
        public Article(string _title, int _words)
        {
            title = _title;
            words = _words;
        }
    }
}


