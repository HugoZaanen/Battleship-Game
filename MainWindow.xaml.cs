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

namespace Battleship_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Cell[] cellsPlayer = new Cell[4];
        Cell[] cellsComputer = new Cell[4];

        bool gameStarted = false;
        bool userTurn = false;
        bool gameEnd = false;


        int playerX;
        int playerY;
        
        int pointX;
        int pointY;

        public MainWindow()
        {
            InitializeComponent();

            //int point = Button0_0.GetValue(Grid.RowProperty);
            Random rand = new Random(DateTime.Now.Millisecond);
            Random rand1 = new Random(DateTime.Now.Millisecond);

            //
            pointX = rand.Next(0,4);
            pointY = rand1.Next(0,4);
            
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            int count = 0;
            if ((int)button.GetValue(Grid.RowProperty) == pointX && (int)button.GetValue(Grid.ColumnProperty) == pointY)
            {
                button.Content = "Hit!";
            }
            else
            {
                button.Content = "Miss!" + count;
                count++;
            }
            
            while(button.Name.Substring(0,) == "")
            {

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            playerX = (int)button.GetValue(Grid.RowProperty);
            playerY = (int)button.GetValue(Grid.ColumnProperty);

            MessageBox.Show("" + playerX);
            MessageBox.Show("" + playerY);
        }
    }

    public class Cell
    {
        public string name;
        public Point position;
    }
}
