using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SORBETE
{
    public partial class MainPage : MasterDetailPage
    {
        ContentPage song1;
        ContentPage inicial;
        public MainPage()
        {
            InitializeComponent();
            var st = new StackLayout
            {
                Children =
                {
                    new Label()
                    {
                        Text = "HARRY STYLES",
                        HorizontalOptions = LayoutOptions.Center,
                        FontSize = 18
                    }
                }
            };
            Button bt = new Button
            {
                Text = "Meet Me in the Hallway",
                BackgroundColor = Color.GhostWhite,
            };
            Button bt2 = new Button
            {
                Text = "Sign of the Times",
                BackgroundColor = Color.WhiteSmoke,
            };
            Button bt3 = new Button
            {
                Text = "Carolina",
                BackgroundColor = Color.WhiteSmoke,
            };
            Button bt4 = new Button
            {
                Text = "Two Ghosts",
                BackgroundColor = Color.WhiteSmoke,
            };
            Button bt5 = new Button
            {
                Text = "Sweet Creature",
                BackgroundColor = Color.WhiteSmoke,
            };
            Button bt6 = new Button
            {
                Text = "Only Angel",
                BackgroundColor = Color.WhiteSmoke,
            };
            Button bt7 = new Button
            {
                Text = "Kiwi",
                BackgroundColor = Color.WhiteSmoke,
            };
            Button bt8 = new Button
            {
                Text = "Ever Since New York",
                BackgroundColor = Color.WhiteSmoke,
            };
            Button bt9 = new Button
            {
                Text = "Woman",
                BackgroundColor = Color.WhiteSmoke,
            };
            Button bt10 = new Button
            {
                Text = "From the Dining Table",
                BackgroundColor = Color.WhiteSmoke,
            };

            bt.Clicked += delegate { Detail = creator(bt.Text, "meetmeinthehallway.jpg"); };
            bt2.Clicked += delegate { Detail = creator(bt2.Text, "signofthetimes.jpg"); };
            bt3.Clicked += delegate { Detail = creator(bt3.Text, "carolina.jpg"); };
            bt4.Clicked += delegate { Detail = creator(bt4.Text, "twoghosts.jpg"); };
            bt5.Clicked += delegate { Detail = creator(bt5.Text, "sweetcreature.jpg"); };
            bt6.Clicked += delegate { Detail = creator(bt6.Text, "onlyangel.jpg"); };
            bt7.Clicked += delegate { Detail = creator(bt7.Text, "kiwi.jpg"); };
            bt8.Clicked += delegate { Detail = creator(bt8.Text, "eversincenewyork.jpg"); };
            bt9.Clicked += delegate { Detail = creator(bt9.Text, "woman.jpg"); };
            bt10.Clicked += delegate { Detail = creator(bt10.Text, "fromthediningtable.jpg"); };

            st.Children.Add(bt);
            st.Children.Add(bt2);
            st.Children.Add(bt3);
            st.Children.Add(bt4);
            st.Children.Add(bt5);
            st.Children.Add(bt6);
            st.Children.Add(bt7);
            st.Children.Add(bt8);
            st.Children.Add(bt9);
            st.Children.Add(bt10);

            Master = new ContentPage
            {
                Content = st, Title = "master"
            };

            inicial = new ContentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label()
                        {
                            Text = "Arraste para a direita para ver o álbum Harry Styles",
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Gray,
                            FontSize = 30
                        }
                    }
                }
            };
            song1 = new ContentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label()
                        {
                            Text = "Meet Me in the Hallway",
                            HorizontalOptions = LayoutOptions.Center
                        }
                    }
                }
            };
            Detail = inicial;
        }

        private void Bt_Clicked(object sender, EventArgs e)
        {
            Detail = song1;
        }
        ContentPage creator(string title, string imagePath)
        {
            DependencyService.Get<INatives>().notify("Você escolheu " + title, title + " é uma ótima escolha");
            return new ContentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label()
                        {
                            Text = title,
                            HorizontalOptions = LayoutOptions.Center,
                            FontSize = 20
                        },
                        new Image()
                        {
                            Source = ImageSource.FromFile(imagePath),
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.Center,
                            Aspect = Aspect.AspectFit
                        }
                    }
                }
            };
        }
    }
    public interface INatives
    {
        void notify(string title, string contentTitle);
    }
}
