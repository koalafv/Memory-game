using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Memory_game
{
    public partial class MainPage : ContentPage
    {
        public List<String> Things = new List<String>()
        {
           "malina.png",
           "malina.png",

            "banan.png",
            "banan.png",

            "japko.png",
            "japko.png",
            "orange.png",
            "orange.png",
            "brocoli.png",
            "brocoli.png",
            "burak.png",
            "burak.png",
            "gruchang.png",
            "gruchang.png",
            "ananas.png",
            "ananas.png",
            "paprik.png",
            "paprik.png"
        };
        public List<string> ThingsReady = new List<string>();
      

        public MainPage()
        {
            List<int> ints = new List<int>();
            InitializeComponent();
            


        }
        private int proba = 0;
        private async  void btnStart_Clicked(object sender, EventArgs e)
        {
            btnStart.IsVisible = false;

            Random rand = new Random();
            var shuffled = Things.OrderBy(_ => rand.Next()).ToList();
            ThingsReady = shuffled.ToList();

            int clicked = 0;
            int columnsNum = 3;
            int rowNum = 6;
            int a = 0;
            int indHolder = 0;
            Style style;
            ImageButton btnHolder = new ImageButton();
            for (int i = 0; i < columnsNum; i++) 
            {
                for (int j = 0; j < rowNum; j++)
                {

                    int lastInd = indHolder;
                    ImageButton btn = new ImageButton() { BackgroundColor = Color.Green, HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Fill, Margin = 5 };    
                    
                    indHolder++;

                   

                    a++;
                    tabHolder.Children.Add(btn, i, j);
                  
                    style = btn.Style;
                   
                        btn.Clicked += async (sendere, args) =>
                        {
                            btn.Source = $"{ThingsReady[lastInd]}";
                            btn.BackgroundColor = Color.Transparent;
                            btn.IsEnabled = false;
                            btn.Style = style;


                            if (clicked == 0)
                            {
                                btnHolder = btn;
                                btnHolder.BackgroundColor = Color.Transparent;
                                clicked++;
                            }
                            if (clicked == 1)
                            {
                                clicked++;
                            }
                            else if (clicked == 2)
                            {

                                proba++;
                                probyTxt.Text = $"Proba {proba}";
                                foreach (ImageButton btns in tabHolder.Children)
                                {
                                    btns.IsEnabled = false;

                                }
                                await Task.Delay(TimeSpan.FromSeconds(1.5f));
                                if (btnHolder.Source.ToString() == btn.Source.ToString())
                                {

                                    tabHolder.Children.Remove(btn);
                                    tabHolder.Children.Remove(btnHolder);
                                    if(tabHolder.Children.Count ==0)
                                    {
                                        btnStart.IsVisible = true;
                                        clicked = 0;
                                        proba = 0;
                                        probyTxt.Text = $"Proba {proba}";
                                        await DisplayAlert("Gratulacje", "Gratulacje udało Ci się!", "Close");
                                    }

                                }
                        


                                foreach (ImageButton btns in tabHolder.Children)
                                {
                                    btns.IsEnabled = true;
                                    clicked = 0;
                                    btns.Source = null;
                                    btns.BackgroundColor = Color.Green;
                                }

                            };

                    







                    };
                    }
            }
            int ind = 0;

            await Task.Delay(TimeSpan.FromSeconds(0.5f));

            foreach (ImageButton aaa in tabHolder.Children)
            {
                aaa.Source = $"{ThingsReady[ind]}";
                aaa.IsEnabled = false; 
                ind++;

            }
            await Task.Delay(TimeSpan.FromSeconds(3f));
            foreach (ImageButton aaa in tabHolder.Children)
            {
                aaa.Source = null;
                aaa.IsEnabled = true;
            }
        }
    }
}
