﻿using System;
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
                new Models.Menu { id= 0, titulo = "Gazzeta UAQ"/*, detalle = "Regresa a la página de inicio."*/, icono = "inicio.png"},
                new Models.Menu { id= 1, titulo = "Inicio"/*, detalle = "Regresa a la página de proyecto cultura."*/, icono = "proyectoCultura.png"},
                new Models.Menu { id= 2, titulo = "Galeria"/*, detalle = "Regresa a la página de proximos eventos."*/, icono = "proximos.png"},
                new Models.Menu { id= 3, titulo = "Gazzetas PDF"/*, detalle = "Regresa a la página de acerca de."*/, icono = "acerca.png"},
                new Models.Menu { id= 4, titulo = "Acerca de"/*, detalle = "Regresa a la página de acerca de."*/, icono = "acerca.png"},
                new Models.Menu { id= 5, titulo = "Salir"/*, detalle = "Cerrar la aplicación."*/, icono = "salir.png"}
            };
            ListaMenu.ItemsSource = menu;

            Detail = new NavigationPage(new PaginaInicio());
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
                    Detail = new NavigationPage(new PaginaInicio());
                }
                if (menu.id == 2)//Proyecto cultura
                {
                    IsPresented = false;//Para que el menu desapasca cuando se le haga click
                    Detail = new NavigationPage(new GaleriaView());
                }
                if (menu.id == 3)//Proximos eventos
                {
                    IsPresented = false;//Para que el menu desapasca cuando se le haga click
                    Detail = new NavigationPage(new ProximosEventos());
                }
                if (menu.id == 4)//Acerca de
                {
                    IsPresented = false;//Para que el menu desapasca cuando se le haga click
                    Detail = new NavigationPage(new AcercaDe());
                }
                if (menu.id == 5)//Salir
                {
                    IsPresented = false;//Para que el menu desapasca cuando se le haga click
                    var resp = await this.DisplayAlert("Confirmación", "¿Salir de la app?", "SI", "NO");
                    if (resp)
                    {
                        await this.Navigation.PopAsync();//Cierra la aplicación
                    }
                }
                ListaMenu.SelectedItem = null;//Para que automaticamente se deseleccione el elemento
            }
        }
    }
}