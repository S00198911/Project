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

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Characters> allCharacters = new List<Characters>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Character Objects - 12 Characters Total

            Characters Mario = new Characters() { Name = "Mario",  Image = "https://www.ssbwiki.com/images/thumb/4/44/Mario_SSBU.png/250px-Mario_SSBU.png" };
            Characters Luigi = new Characters() { Name = "Luigi", Image = "https://www.ssbwiki.com/images/thumb/b/bb/Luigi_SSBU.png/1200px-Luigi_SSBU.png" };
            Characters DK = new Characters() { Name = "D.K.", Image = "https://www.ssbwiki.com/images/thumb/c/c9/Donkey_Kong_SSBU.png/1200px-Donkey_Kong_SSBU.png" };
            Characters Link = new Characters() { Name = "Link", Image = "https://www.ssbwiki.com/images/thumb/0/00/Link_BotW.png/250px-Link_BotW.png" };
            Characters Samus = new Characters() { Name = "Samus", Image = "https://www.ssbwiki.com/images/thumb/0/03/Samus_SSBU.png/200px-Samus_SSBU.png" };
            Characters CF = new Characters() { Name = "Captain Falcon", Image = "https://www.ssbwiki.com/images/thumb/d/da/Captain_Falcon_SSBU.png/200px-Captain_Falcon_SSBU.png" };
            Characters Ness = new Characters() { Name = "Nes", Image = "https://www.ssbwiki.com/images/thumb/8/82/Ness_SSBU.png/200px-Ness_SSBU.png" };
            Characters Yoshi = new Characters() { Name = "Yoshi", Image = "https://www.ssbwiki.com/images/thumb/8/8d/Yoshi_SSBU.png/200px-Yoshi_SSBU.png" };
            Characters Kirby = new Characters() { Name = "Kirby", Image = "https://www.ssbwiki.com/images/thumb/0/07/Kirby_SSBU.png/200px-Kirby_SSBU.png" };
            Characters Fox = new Characters() { Name = "Fox", Image = "https://www.ssbwiki.com/images/thumb/2/2f/Fox_SSBU.png/200px-Fox_SSBU.png" };
            Characters Pikachu = new Characters() { Name = "Pikachu", Image = "https://www.ssbwiki.com/images/thumb/9/93/Pikachu_SSBU.png/200px-Pikachu_SSBU.png" };
            Characters Jigglypuff = new Characters() { Name = "Jigglypuff", Image = "https://www.ssbwiki.com/images/thumb/6/6a/Jigglypuff_SSBU.png/200px-Jigglypuff_SSBU.png" };

            // Adding Characters to list - 12 Characters Total

            allCharacters.Add(Mario);
            allCharacters.Add(Luigi);
            allCharacters.Add(DK);
            allCharacters.Add(Link);
            allCharacters.Add(Samus);
            allCharacters.Add(CF);
            allCharacters.Add(Ness);
            allCharacters.Add(Yoshi);
            allCharacters.Add(Kirby);
            allCharacters.Add(Fox);
            allCharacters.Add(Pikachu);
            allCharacters.Add(Jigglypuff);

            // Adding list to ListBox

            ListBoxCharacters.ItemsSource = allCharacters;
        }

        private void ListBoxCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Characters selectedCharacter = ListBoxCharacters.SelectedItem as Characters;

            if (selectedCharacter != null)
            {
                imageCharacter.Source = new BitmapImage(new Uri(selectedCharacter.Image));
                   
            }
        }

      
    }
}
