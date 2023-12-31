﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace teste_bola_fifa
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        bool certo;
        

        private async void DropGestureRecognizer_Drop(object sender, DropEventArgs e)
        {
            certo = true; 
            var image = e.Data.Properties["Demo"] as Image;
            var frame = (sender as Element)?. Parent as Frame;
            frame.Content = image;
            Task.Run(async () => {
                await image.ScaleTo(1.4, 400);
                await image.FadeTo(1, 600);
            });
            verificador();
        }

        private void DragGestureRecognizer_DragStarting_1(object sender, DragStartingEventArgs e)
        {
            Image image = (sender as Element)?.Parent as Image;
            image.Opacity = 0.4;
            e.Data.Properties.Add("Demo", image);
        }

        private void DropGestureRecognizer_Drop_1(object sender, DropEventArgs e)
        {
            certo = false;
            var image = e.Data.Properties["Demo"] as Image;
            var frame = (sender as Element)?.Parent as Frame;
            frame.Content = image;
            Task.Run(async () => {
                await image.ScaleTo(1.4, 400);
                await image.FadeTo(1, 600);
               
            });
            verificador();
           
        }

        public async void verificador() 
        {
            if (certo == false)
            {
                await DisplayAlert("Que Pena", "Você errou o quadrado", "ok");
            }
            else
            {
                await DisplayAlert("parabéns", "Você acertou o quadrado", "ok" );
            }

        }
    }
}
