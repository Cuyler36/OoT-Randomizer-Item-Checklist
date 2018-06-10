using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace OoT_Randomizer_Item_Checklist
{
    class CyclicImage : Grid
    {
        private int m_imageIndex = -1;
        private int counterLimit = -1;
        private int counterValue = 0;
        private Image ItemImage;
        private OutlinedTextBlock Counter;

        private readonly string[] InternalImageList;
        public int ImageIndex
        {
            get => m_imageIndex;
            private set
            {
                m_imageIndex = value;
                if (value < 0)
                {
                    ItemImage.Source = Utilities.MakeGrayscale2(Utilities.GetBitmapSourceFromResource(InternalImageList[0]));
                }
                else
                {
                    ItemImage.Source = Utilities.GetBitmapSourceFromResource(InternalImageList[value]);
                }
            }
        }
        public int CounterValue
        {
            get => counterValue;
            private set
            {
                counterValue = value;
                if (Counter != null)
                {
                    Counter.Text = value.ToString();
                }
            }
        }

        public CyclicImage(int ItemIndex, int CounterLimit = -1, int Width = 42, int Height = 42) : base()
        {
            this.Width = Width;
            this.Height = Height;

            ItemImage = new Image
            {
                Width = Width,
                Height = Height
            };
            Children.Add(ItemImage);

            InternalImageList = ItemList.ItemPictureList[ItemIndex];
            counterLimit = CounterLimit;
            ItemImage.Source = Utilities.MakeGrayscale2(Utilities.GetBitmapSourceFromResource(InternalImageList[0]));

            if (CounterLimit > 0)
            {
                Counter = new OutlinedTextBlock
                {
                    Text = "0",
                    Fill = new SolidColorBrush(Colors.White),
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    FontSize = 18,
                    FontWeight = FontWeights.Bold,
                    StrokeThickness = 3,
                    Stroke = new SolidColorBrush(Colors.Black)
                };

                Children.Add(Counter);
                SetZIndex(Counter, 100);
            }

            MouseDown += OnClick;
        }

        private void OnClick(object sender, MouseButtonEventArgs e)
        {
            if (counterLimit < 1)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    if (ImageIndex + 1 >= InternalImageList.Length)
                    {
                        ImageIndex = -1;
                    }
                    else
                    {
                        ImageIndex++;
                    }
                }
                else if (e.RightButton == MouseButtonState.Pressed)
                {
                    if (ImageIndex - 1 > -2)
                    {
                        ImageIndex--;
                    }
                    else
                    {
                        ImageIndex = InternalImageList.Length - 1;
                    }
                }
            }
            else
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    if (CounterValue + 1 > counterLimit)
                    {
                        ImageIndex = -1;
                        CounterValue = 0;
                    }
                    else
                    {
                        CounterValue++;
                        ImageIndex = 0;
                    }
                }
                else if (e.RightButton == MouseButtonState.Pressed)
                {
                    if (CounterValue - 1 == 0)
                    {
                        ImageIndex = -1;
                        CounterValue = 0;
                    }
                    else if (CounterValue - 1 < 0)
                    {
                        ImageIndex = 0;
                        CounterValue = counterLimit;
                    }
                    else
                    {
                        ImageIndex = 0;
                        CounterValue--;
                    }
                }
            }
        }
    }
}
