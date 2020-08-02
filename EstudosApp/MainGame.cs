using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace EstudosApp
{
    [Activity(Label = "MainGame", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainGame : Activity
    {
        TextView text_tentativas;
        EditText edit_valor;
        Button cmd_adivinhar;
        Button cmd_reiniciar;

        int Valor_Sorteado;
        int Numero_Tentativa;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MainGame);


            text_tentativas = FindViewById<TextView>(Resource.Id.text_tentativas);
            cmd_reiniciar = FindViewById<Button>(Resource.Id.cmd_reiniciar);
            edit_valor = FindViewById<EditText>(Resource.Id.edit_valor);
            cmd_adivinhar = FindViewById<Button>(Resource.Id.cmd_adivinhar);


            Cmd_reiniciar_Click(this, EventArgs.Empty);
            //first game
            Random Rnd = new Random();
            Valor_Sorteado = Rnd.Next(0, 1000);

            //iniciar tentativas
            Numero_Tentativa = 0;

            cmd_adivinhar.Click += Cmd_adivinhar_Click;
            cmd_reiniciar.Click += Cmd_reiniciar_Click;      



        }

        private void Cmd_reiniciar_Click(object sender, EventArgs e)
        {
            Random Rnd = new Random();
            Valor_Sorteado = Rnd.Next(0, 1000);

            //iniciar tentativas
            Numero_Tentativa = 0;
        }

        private void Cmd_adivinhar_Click(object sender, EventArgs e)
        {
            //analisa dados inseridos
            //se dado valido
            if (edit_valor.Text == "" ) return;

            int Valor_Inserido = int.Parse(edit_valor.Text);

            string mensagen = "";

            if (Valor_Inserido < Valor_Sorteado)
            {
                mensagen = "O valor inserido é inferior ao sorteado";
                Atualizar_Tentativas();
            }else if (Valor_Inserido > Valor_Sorteado)
            {
                mensagen = "O valor inserido é superior ao sorteado";
                Atualizar_Tentativas();
            }
            else
            {
                //acertou
                var AtividadeFinal = new Intent(this, typeof(GameOver));

                AtividadeFinal.PutExtra("Sorteado", Valor_Sorteado.ToString());
                AtividadeFinal.PutExtra("Tentativas", Numero_Tentativa.ToString());
                StartActivity(AtividadeFinal);

                return;

            }
            AlertDialog.Builder caixa = new AlertDialog.Builder(this);
            caixa.SetTitle("Adivinha o número");
            caixa.SetMessage(mensagen);
            caixa.SetPositiveButton("OK", delegate { });
            caixa.SetCancelable(false);
            caixa.Show();

        }
        private void Atualizar_Tentativas()
        {
            Numero_Tentativa++;
            text_tentativas.Text = "Tentativas: " + Numero_Tentativa.ToString();
        }
    }
}