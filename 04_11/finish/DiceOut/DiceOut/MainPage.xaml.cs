using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DiceOut
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public int[] Dice = new int[3];
        public int Score = 0;

        public Random RandomGenerator = new Random();

        public MainPage()
        {
            this.InitializeComponent();
            SetupGame();
        }

        private void SetupGame()
        {
            WinText.Text = "Click the \"Roll Die\" button to play";
            ScoreText.Text = $"Score: {Score}";
        }

        private void RollButton_Click(object sender, RoutedEventArgs e)
        {
            // DieValueText.Text = "Button clicked!";

            for (int i = 0; i < Dice.Length; i++)
            {
                int DieValue = RandomGenerator.Next(1, 7);
                Dice[i] = DieValue;
            }

            DieValueText.Text = $"The values are {Dice[0]}, {Dice[1]}, and {Dice[2]}.";

            ApplyGameRules();
        }

        private void ApplyGameRules()
        {
            int NewScore = 0;
            string WinMessage = "";

            if (Dice[0] == Dice[1] && Dice[0] == Dice[2])
            {
                // Triple
                if (Dice[0] < 6)
                {
                    NewScore = Dice[0] * 100;
                    WinMessage = $"You rolled a {Dice[0]} for {NewScore} points.";
                }
                else
                {
                    NewScore = 1000;
                    WinMessage = "Triple 6's! You scored 1,000 points!";
                }


            } else if (Dice[0] == Dice[1] || Dice[1] == Dice[2] || Dice[0] == Dice[2])
            {
                // Double
                NewScore = 50;
                WinMessage = "You scored doubles for 50 points.";

            } else
            {
                // No matches
                NewScore = 0;
                WinMessage = "No matches this roll.";
            }

            Score = Score + NewScore;
            ScoreText.Text = $"Score: {Score}";
            WinText.Text = WinMessage;
        }
    }
}
