using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace EstudosApp
{
    [Activity(Label = "GameOver")]
    public class GameOver : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.GameOver);

            TextView text_final_sorteado = FindViewById<TextView>(Resource.Id.text_final_sorteado);
            TextView text_final_tentativas = FindViewById<TextView>(Resource.Id.text_final_tentativas);
            Button cmd_terminar = FindViewById<Button>(Resource.Id.cmd_terminar);

            int Sorteado = int.Parse(Intent.GetStringExtra("Sorteado"));
            int Tentativas = int.Parse(Intent.GetStringExtra("Tentativas"));

            text_final_sorteado.Text = "Número Sorteado" + Sorteado.ToString();

            if (Tentativas == 0)
            {
                text_final_tentativas.Text = "Foi necessária uma tentativa";


            }
            else
            {
                text_final_tentativas.Text = "Foram necessárias " + Tentativas.ToString()+ " Tentativas para adivinhar.";
            }

            cmd_terminar.Click += delegate
            {
                this.Finish();
            };
           
        }

        
    }
}