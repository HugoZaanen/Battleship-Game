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

        int counter = 0;
        int maxShip = 4;

        bool fieldIsSet = false;
        bool gameStart = false;
        bool gameEnd = false;
        bool playerIsSet = false;

        int pointX;
        int pointY;

        Random rand1 = new Random();
        Random rand2 = new Random();

        Button[] playerButtons;

        Button[] buttons = new Button[4];

        public MainWindow()
        {
            InitializeComponent();
            playerButtons = new Button[100]
            {
                #region buttons
                playerButton0_0,
                playerButton1_0,
                playerButton2_0,
                playerButton3_0,
                playerButton4_0,
                playerButton5_0,
                playerButton6_0,
                playerButton7_0,
                playerButton8_0,
                playerButton9_0,

                playerButton0_1,
                playerButton1_1,
                playerButton2_1,
                playerButton3_1,
                playerButton4_1,
                playerButton5_1,
                playerButton6_1,
                playerButton7_1,
                playerButton8_1,
                playerButton9_1,

                playerButton0_2,
                playerButton1_2,
                playerButton2_2,
                playerButton3_2,
                playerButton4_2,
                playerButton5_2,
                playerButton6_2,
                playerButton7_2,
                playerButton8_2,
                playerButton9_2,

                playerButton0_3,
                playerButton1_3,
                playerButton2_3,
                playerButton3_3,
                playerButton4_3,
                playerButton5_3,
                playerButton6_3,
                playerButton7_3,
                playerButton8_3,
                playerButton9_3,

                playerButton0_4,
                playerButton1_4,
                playerButton2_4,
                playerButton3_4,
                playerButton4_4,
                playerButton5_4,
                playerButton6_4,
                playerButton7_4,
                playerButton8_4,
                playerButton9_4,

                playerButton0_5,
                playerButton1_5,
                playerButton2_5,
                playerButton3_5,
                playerButton4_5,
                playerButton5_5,
                playerButton6_5,
                playerButton7_5,
                playerButton8_5,
                playerButton9_5,

                playerButton0_6,
                playerButton1_6,
                playerButton2_6,
                playerButton3_6,
                playerButton4_6,
                playerButton5_6,
                playerButton6_6,
                playerButton7_6,
                playerButton8_6,
                playerButton9_6,

                playerButton0_7,
                playerButton1_7,
                playerButton2_7,
                playerButton3_7,
                playerButton4_7,
                playerButton5_7,
                playerButton6_7,
                playerButton7_7,
                playerButton8_7,
                playerButton9_7,

                playerButton0_8,
                playerButton1_8,
                playerButton2_8,
                playerButton3_8,
                playerButton4_8,
                playerButton5_8,
                playerButton6_8,
                playerButton7_8,
                playerButton8_8,
                playerButton9_8,

                playerButton0_9,
                playerButton1_9,
                playerButton2_9,
                playerButton3_9,
                playerButton4_9,
                playerButton5_9,
                playerButton6_9,
                playerButton7_9,
                playerButton8_9,
                playerButton9_9
                #endregion
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (playerIsSet)
            {
                Button button = sender as Button;

                int count = 0;

                if ((int)button.GetValue(Grid.RowProperty) == pointX && (int)button.GetValue(Grid.ColumnProperty) == pointY)
                {
                    button.Content = "Hit!";
                    compTurn();
                }
                else
                {
                    button.Content = "Miss!";
                    compTurn();
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
                    string name = button.Name;
                    string name1 = name.Substring(0, 12);
                    string pos = name.Substring(12, 1);
                    string pos1 = name.Substring(14, 1);
                    int posX = int.Parse(pos);
                    int posY = int.Parse(pos1);

                    Point bttnpos = new Point(Grid.GetColumn(button), Grid.GetRow(button));
                    List<Button> targetedButtons = new List<Button>();
                    for (int i = 0; i < playerButtons.Length; i++)
                    {
                        Button target = playerButtons[i];
                        int Targetx = Grid.GetColumn(target);
                        int Targety = Grid.GetRow(target);
                        if(Targety == bttnpos.Y | Targety== bttnpos.Y-1 | Targety == bttnpos.Y+1)
                        {
                            if (Targetx == bttnpos.X | Targetx == bttnpos.X - 1 | Targetx == bttnpos.X + 1)
                            {
                                targetedButtons.Add(target);
                                target.Content = "Found";
                            }
                        }
                        
                    }
                    //if ()
                    //{
                    //    MessageBox.Show("!");
                    //}

                    //for (int i = 0; i < buttons.Length; i++)
                    //{
                    //    string buttonName = buttons[i].Name;

                    //}

                    MessageBox.Show(posX + " " + pos1);

                    //button.Content = "Ship";

                    counter++;
                }

                //if (counter == 4)
                //{
                //    playerIsSet = true;
                //}
            }

            if (playerIsSet)
            {
                pointX = rand1.Next(0, 4);
                pointY = rand2.Next(0, 4);
            }
        }

        private void compTurn()
        {
            Random random = new Random();
            Random random1 = new Random();

            int i = random1.Next(0, 99);

            if (playerButtons[i].Content == "Ship")
            {
                playerButtons[i].Content = "Hit!";
            }
            else
            {
                while (playerButtons[i].Content == "Miss" || playerButtons[i].Content == "Hit!")
                {
                    i = random1.Next(0, 99);
                }

                playerButtons[i].Content = "Miss";
            }
        }
    }
}