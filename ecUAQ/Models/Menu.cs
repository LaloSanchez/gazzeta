using System;
using Xamarin.Forms;

namespace ecUAQ.Models
{
    public class Menu
    {
        Image image;
        public Menu()
        {
            image = new Image
            {
                HeightRequest = 2,
                WidthRequest = 2,
            };

            image.Opacity = 0.5;
        }

        public int id{
            get;
            set;
        }

        public string titulo
        {
            get;
            set;
        }

        public string detalle
        {
            get;
            set;
        }

        /*public ImageSource icono{
            get;
            set;
        }*/

        public ImageSource icono
        {
            get { return image.Source; }
            set { image.Source = value; }
        }


    }
}
