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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace DiceOut
{
    public sealed partial class DieImage : UserControl
    {
        private const int NumFaces = 6;
        public Image[] Faces = new Image[NumFaces];

        public DieImage()
        {
            this.InitializeComponent();
            CreateFaceArray();
        }

        private void CreateFaceArray()
        {
            Faces[0] = Face1;
            Faces[1] = Face2;
            Faces[2] = Face3;
            Faces[3] = Face4;
            Faces[4] = Face5;
            Faces[5] = Face6;
        }

        public void DisplayFace(int FaceID)
        {
            FaceID = FaceID - 1;

            for (int i = 0; i < NumFaces; i++)
            {
                if (i == FaceID)
                {
                    Faces[i].Visibility = Visibility.Visible;
                }
                else
                {
                    Faces[i].Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
