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

namespace OoT_Randomizer_Item_Checklist
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < ItemList.ItemPictureList.Length; i++)
            {
                var CyclicImageControl = new CyclicImage(i, ItemList.ItemCycleCount(i));
                ItemWrapPanel.Children.Add(CyclicImageControl);
            }
        }
    }
}
