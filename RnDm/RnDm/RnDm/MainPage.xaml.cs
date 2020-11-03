using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottie.Forms;
using Xamarin.Forms;

namespace RnDm
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            bool timer = true;
            double t = 0;

            Grid grid = new Grid
             {
                 RowDefinitions =
                 {
                 new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                 new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                 new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                 new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                 new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                 new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                 new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                 new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                 },
                 ColumnDefinitions =
                 {
                 new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                 new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                 }
             };

            Stepper stepper = new Stepper
             {
                 Maximum = 6,
                 Increment = 1,
                 Margin = new Thickness(10, 0, 0, 0),
                 HorizontalOptions = LayoutOptions.Center,
                 VerticalOptions = LayoutOptions.Center
             };
             grid.Children.Add(stepper, 0, 1);

             Label p_amount = new Label
             {
                 Text = "Amount",
                 TextColor = Color.Black,
                 FontSize = 18,
                 HorizontalOptions = LayoutOptions.Center,
                 VerticalOptions = LayoutOptions.CenterAndExpand
             };
            grid.Children.Add(p_amount, 1, 1);

             Label name_label = new Label
             {
                 Text = "Enter names",
                 HorizontalTextAlignment = TextAlignment.Center,
                 TextColor = Color.Black,
                 Margin = new Thickness(0, 20, 0, 0),
                 FontSize = 16
             };

             grid.Children.Add(name_label, 0, 2);

            var entry1 = new Entry
            {
                FontSize = 18
            };
            var entry2 = new Entry
            {
                FontSize = 18
            };
            var entry3 = new Entry
            {
                FontSize = 18
            };
            var entry4 = new Entry
            {
                FontSize = 18
            };
            var entry5 = new Entry
            {
                FontSize = 18
            };
            var entry6 = new Entry
            {
                FontSize = 18
            };

             Entry[] entries = { entry1, entry2, entry3, entry4, entry5, entry6 };

             stepper.ValueChanged += (sender, e) =>
             {
                 p_amount.Text = stepper.Value.ToString();

                if (stepper.Value > 0)
                {
                    grid.Children.Add(entries[(int)stepper.Value - 1], 1, (int)stepper.Value + 1);
                }

                if (stepper.Value == 0)
                {
                    for(int i = 0; i < entries.Length; i++)
                     {
                         grid.Children.Remove(entries[i]);
                     }
                }
                 if (e.NewValue < e.OldValue)
                 {
                     for (int i = 0; i < entries.Length; i++)
                     {
                         grid.Children.Remove(entries[(int)e.OldValue - 1]);
                     }
                 }
             };

            Button reset = new Button
             {
                 Text = "Reset",
                 FontSize = 12.5,
                 Margin = new Thickness(5, 5, 5, 5),
                 VerticalOptions = LayoutOptions.CenterAndExpand,
                 HorizontalOptions = LayoutOptions.Center
             };
             grid.Children.Add(reset, 0, 4);

             reset.Clicked += (sender, e) =>
             {
                 stepper.Value = 0;
                 p_amount.Text = "Amount";
                 for(int k = 0; k < entries.Length; k++)
                 {
                     entries[k].Text = string.Empty;
                 }
             };


            Button rndm = new Button
             {
                 Text = "Choose randomly",
                 FontSize = 12,
                 Margin = new Thickness(5, 5, 5, 5),
                 VerticalOptions = LayoutOptions.CenterAndExpand,
                 HorizontalOptions = LayoutOptions.Center
             };
             grid.Children.Add(rndm, 0, 5);

            /*var scroller = new ScrollView { Content = grid, VerticalOptions = LayoutOptions.FillAndExpand };
            var vScroller = new ScrollView() { Content = scroller };
            Content = vScroller;*/
            Content = grid;

            rndm.Clicked += (sender, e) =>
            {
                if (entry1.Text != null && stepper.Value != 0)
                {
                    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                    {
                        t++;

                        if (t > 3)
                        {
                            timer = false;
                            animationView.IsPlaying = false;
                            Content = ShowRandom;
                            t = 0;

                            Random rnd1 = new Random();
                            int value1 = rnd1.Next(0, (int)stepper.Value);

                            rndRes.Text = entries[value1].Text;
                        }
                        else
                        {
                            timer = true;
                            Content = animationView;
                            animationView.IsPlaying = true;
                        }
                        return timer;
                    });
                }
            };
            main.Clicked += (sender, e) =>
            {
                Content = grid;
            };
        }
    }
}
