using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ecUAQ.Views
{
    public class listTemplate: ViewCell
    {
        public listTemplate()
        {
            var titleLabel = new Label()
            {
                FontFamily = "HelveticaNeue-Medium",
                FontSize = 12,
                TextColor = Color.Black
            };
            titleLabel.SetBinding(Label.TextProperty, "titulo");

            var discriptionLabel = new Label()
            {
                FontAttributes = FontAttributes.Bold,
                FontSize = 8,
                TextColor = Color.FromHex("#666")
            };
            discriptionLabel.SetBinding(Label.TextProperty, "resumen");
            //discriptionLabel.Text.Substring(0, 10);
                

            var ImagenPrincipal = new Image()
            {
                AnchorX = 0,
                HeightRequest = 100,
                WidthRequest = 100,
                Aspect = Aspect.Fill,

                VerticalOptions = LayoutOptions.CenterAndExpand 
            };
            ImagenPrincipal.SetBinding(Image.SourceProperty, "url_imagen");
            
            var statusLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { discriptionLabel }
            };

            var textLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { titleLabel,statusLayout }
            };

            var generalStack = new StackLayout()
            {
                Spacing = 5,
                Orientation = StackOrientation.Horizontal,
                Children = { ImagenPrincipal,textLayout }
            };

            var vetDetailsLayout = new StackLayout
            {
                Padding = new Thickness(10, 0, 0, 0),
                Spacing = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { generalStack }
            };

            var cellLayout = new StackLayout
            {
                Spacing = 0,
                Padding = new Thickness(10, 5, 10, 5),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { vetDetailsLayout }
            };

            this.View = cellLayout;
        }
    }
}
