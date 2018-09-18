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

        int counter = 0;
        int maxShip = 4;
        
        bool gameStarted = false;
        bool fieldIsSet = false;
        bool playerTurn = false;
        bool gameEnd = false;
        bool playerIsSet = false;

        //int playerX;
        //int playerY;

        int pointX;
        int pointY;

        Button[] playerButtons;
            
        Button[] buttons = new Button[4];

        public MainWindow()
        {
            InitializeComponent();
            
            //int point = Button0_0.GetValue(Grid.RowProperty);
            Random rand = new Random(DateTime.Now.Millisecond);
            Random rand1 = new Random(DateTime.Now.Millisecond);

            playerButtons = new Button[]
                {
                    buttonPlayer0_0,
                    buttonPlayer1_0,
                    buttonPlayer2_0,
                    buttonPlayer3_0,
                    buttonPlayer0_1,
                    buttonPlayer1_1,
                    buttonPlayer2_1,
                    buttonPlayer3_1,
                    buttonPlayer0_2,
                    buttonPlayer1_2,
                    buttonPlayer2_2,
                    buttonPlayer3_2,
                    buttonPlayer0_3,
                    buttonPlayer1_3,
                    buttonPlayer2_3,
                    buttonPlayer3_3
                };

            pointX = rand.Next(0,4);
            pointY = rand1.Next(0,4);
                       
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (playerIsSet)
            {
                while (playerTurn)
                {
                    if (playerTurn)
                    {
                        Button button = sender as Button;

                        int count = 0;
                        if ((int)button.GetValue(Grid.RowProperty) == pointX && (int)button.GetValue(Grid.ColumnProperty) == pointY)
                        {
                            button.Content = "Hit!";
                            playerTurn = false;
                        }
                        else
                        {
                            button.Content = "Miss!";
                            playerTurn = false;
                        }
                    }
                    
                }
            }
        }

        private void SelectButton(object sender, RoutedEventArgs e)
        {
            if (!playerIsSet)
            {
                Button button = sender as Button;

                if (button.Content != "Ship")
                {
                    button.Content = "Ship";
                    buttons[counter] = button;
                    counter++;
                }

                if(counter == 4)
                {
                    playerIsSet = true;
                }
            }

            if(playerIsSet)
            {
                gameStarted = true;
                playerTurn = true;
            }
        }

        private void StartButton(object sender, RoutedEventArgs e)
        {          
            gameStarted = true;
        }

        private void compTurn()
        {
            while (gameStarted)
            {

                if (!playerTurn)
                {
                    Random random = new Random();
                    Random random1 = new Random();

                    int i = random1.Next(0, 16);

                    if (playerButtons[i].Content == "ship")
                    {
                        playerButtons[i].Content = "Hit!";
                    }
                    else
                    {
                        while (playerButtons[i].Content == "Miss")
                        {
                            i = random1.Next();
                        }
                        playerButtons[i].Content = "Miss";
                    }
                }
                playerTurn = true;
            }
        }
    }

    public class Cell
    {
        public string name;
        public Point position;
    }
}
