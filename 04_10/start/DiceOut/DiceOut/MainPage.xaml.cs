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

        public Random RandomGenerator = new Random();

        public MainPage()
        {
            this.InitializeComponent();
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
            // If the first die is equal to the second
            // AND
            // If the first die is equal to the third
            // then we have a triple!

            if (Dice[0] == Dice[1] && Dice[0] == Dice[2])
            {
                // Triple
            } else if (Dice[0] == Dice[1] || Dice[1] == Dice[2] || Dice[0] == Dice[2])
            {
                // Double
            } else
            {
                // No matches
            }
        }
    }
}
