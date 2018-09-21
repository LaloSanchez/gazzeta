using System;
using System.Collections.Generic;
using System.Diagnostics;
using ecUAQ.Models;
using ecUAQ.Services;
using Xamarin.Forms;

namespace ecUAQ.Views
{
    public partial class MenuPrincipal : MasterDetailPage
    {
        public MenuPrincipal()
        {

            InitializeComponent();
            inicio();
        }

        void inicio()
        {
            List<Models.Menu> menu = new List<Models.Menu>{//Le cambie Menu a Models.Menu porque al ejecutarlo en iOS manda error de ambiguo
                //new Models.Menu { id= 0, titulo = "Gazzeta UAQ"/*, detalle = "Regresa a la página de inicio."*/, icono = "iconoUAQ.png" },
                new Models.Menu { id= 1, titulo = "Inicio"/*, detalle = "Regresa a la página de proyecto cultura."*/, icono = "inicio.png"},
                new Models.Menu { id= 2, titulo = "Galeria"/*, detalle = "Regresa a la página de proximos eventos."*/, icono = "galeria.png"},
                new Models.Menu { id= 3, titulo = "Gazzetas PDF"/*, detalle = "Regresa a la página de acerca de."*/, icono = "gaceta.png"},
                new Models.Menu { id= 4, titulo = "Acerca de"/*, detalle = "Regresa a la página de acerca de."*/, icono = "acerca.png"},
                new Models.Menu { id= 5, titulo = "Facebook"/*, detalle = "Regresa a la página de acerca de."*/, icono = "facebook.png"},
                new Models.Menu { id= 6, titulo = "Instagram"/*, detalle = "Regresa a la página de acerca de."*/, icono = "instagram.png"},
                new Models.Menu { id= 7, titulo = "Noticias UAQ"/*, detalle = "Regresa a la página de acerca de."*/, icono = "noticias.png"},
                new Models.Menu { id= 8, titulo = "Twitter"/*, detalle = "Regresa a la página de acerca de."*/, icono = "twitter.png"},
                new Models.Menu { id= 9, titulo = "Tv UAQ"/*, detalle = "Regresa a la página de acerca de."*/, icono = "tvuaq.png"},
                new Models.Menu { id= 10, titulo = "Radio UAQ"/*, detalle = "Regresa a la página de acerca de."*/, icono = "radiouaq.png"},
                new Models.Menu { id= 11, titulo = "Salir"/*, detalle = "Cerrar la aplicación."*/, icono = "salir.png"}
            };
            ListaMenu.ItemsSource = menu;

            Detail = new NavigationPage(new PaginaInicio()){BarBackgroundColor = Color.FromHex("#04468d") };
        }

        public async void ListaMenu_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Models.Menu;
            if (menu != null)
            {
                //if (menu.titulo.Equals("Inicio"))
                if (menu.id == 1)//Inicio
                {
                    IsPresented = false;//Para que el menu desapasca cuando se le haga click
                    Detail = new NavigationPage(new PaginaInicio()){ BarBackgroundColor = Color.FromHex("#04468d") };
                }
                if (menu.id == 2)//Proyecto cultura
                {
                    IsPresented = false;//Para que el menu desapasca cuando se le haga click
                    Detail = new NavigationPage(new GaleriaView()){ BarBackgroundColor = Color.FromHex("#04468d") };
                }
                if (menu.id == 3)//Proximos eventos
                {
                    IsPresented = false;//Para que el menu desapasca cuando se le haga click
                    Detail = new NavigationPage(new GazzetasAnteriores()){ BarBackgroundColor = Color.FromHex("#04468d") };
                }
                if (menu.id == 4)//Acerca de
                {
                    IsPresented = false;//Para que el menu desapasca cuando se le haga click
                    Detail = new NavigationPage(new AcercaDe()){ BarBackgroundColor = Color.FromHex("#04468d") };
                }
                if (menu.id == 5)//Facebook
                {
                    IsPresented = false;//Para que el menu desapasca cuando se le haga click
                    Device.OpenUri(new Uri("http://www.facebook.com/uaq.mx/"));
                }
                if (menu.id == 6)//Instagram
                {
                    IsPresented = false;//Para que el menu desapasca cuando se le haga click
                    Device.OpenUri(new Uri("http://www.instagram.com/UAQmx"));
                }
                if (menu.id == 7)//Noticias
                {
                    IsPresented = false;//Para que el menu desapasca cuando se le haga click
                    Device.OpenUri(new Uri("http://noticias.uaq.mx "));
                }
                if (menu.id == 8)//Twitter
                {
                    IsPresented = false;//Para que el menu desapasca cuando se le haga click
                    Device.OpenUri(new Uri("http://www.twitter.com/uaqmx "));
                }
                if (menu.id == 9)//Tv UAQ
                {
                    IsPresented = false;//Para que el menu desapasca cuando se le haga click
                    Device.OpenUri(new Uri("http://tv.uaq.mx "));
                }
                if (menu.id == 10)//Radio UAQ
                {
                    IsPresented = false;//Para que el menu desapasca cuando se le haga click
                    Device.OpenUri(new Uri("http://cgsi.uaq.mx/streaming/canales/cgsi.aspx"));
                }
                if (menu.id == 11)//Salir
                {
                    IsPresented = false;//Para que el menu desapasca cuando se le haga click
                    var resp = await this.DisplayAlert("Confirmación", "¿Salir de la app?", "SI", "NO");
                    if (resp)
                    {
                        System.Environment.Exit(0); 
                    }
                }
                ListaMenu.SelectedItem = null;//Para que automaticamente se deseleccione el elemento
            }
        }
    }
}
