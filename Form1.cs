using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraDaT6_ThiagoM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //enum é uma lista de opções
        enum Operacoes
        {
            Soma,
            Subtrai,
            Dividi,
            Multiplica,
            Nenhuma
        }
        //Declaração de variável "ultimaOperacao"
        static Operacoes ultimaOperacao = Operacoes.Nenhuma;

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Clear();
            ultimaOperacao = Operacoes.Nenhuma;
        }

        private void buttonApagar_Click(object sender, EventArgs e)
        {
            if (textBoxDisplay.Text.Length > 0)
            {
                textBoxDisplay.Text =
                textBoxDisplay.Text.Remove(textBoxDisplay.Text.Length - 1, 1);
            }
        }
        private void buttonCopiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxDisplay.Text);
        }

        private void buttonSoma_Click(object sender, EventArgs e)
        {
            if ((ultimaOperacao) == Operacoes.Nenhuma)
            {
                ultimaOperacao = Operacoes.Soma;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }

        private void buttonSubtração_Click(object sender, EventArgs e)
        {
            if ((ultimaOperacao) == Operacoes.Nenhuma)
            {
                ultimaOperacao = Operacoes.Subtrai;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }

        //Exibe os números no Display
        private void buttonMulti_Click(object sender, EventArgs e)
        {
            if ((ultimaOperacao) == Operacoes.Nenhuma)
            {
                ultimaOperacao = Operacoes.Multiplica;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }

        private void buttonDivisão_Click(object sender, EventArgs e)
        {
            if ((ultimaOperacao) == Operacoes.Nenhuma)
            {
                ultimaOperacao = Operacoes.Dividi;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }


        private void buttonIgual_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao != Operacoes.Nenhuma)
            {
                FazerCalculo(ultimaOperacao);
            }
            ultimaOperacao = Operacoes.Nenhuma;
        }

        private void FazerCalculo(Operacoes ultimaOperacao)
        {
            //Uma lista de números do tipo "double" (real)
            //Uma lista é um vetor variado
            List<double> listaDeNumeros = new List<double>();

            switch (ultimaOperacao)
            {
                case Operacoes.Soma:
                    listaDeNumeros = textBoxDisplay.Text.Split('+').Select(double.Parse).ToList();
                    textBoxDisplay.Text = (listaDeNumeros[0] + listaDeNumeros[1]).ToString();
                    break;
                case Operacoes.Subtrai:
                    listaDeNumeros = textBoxDisplay.Text.Split('-').Select(double.Parse).ToList();
                    textBoxDisplay.Text = (listaDeNumeros[0] - listaDeNumeros[1]).ToString();
                    break;
                case Operacoes.Dividi:
                    listaDeNumeros = textBoxDisplay.Text.Split('/').Select(double.Parse).ToList();
                    textBoxDisplay.Text = (listaDeNumeros[0] / listaDeNumeros[1]).ToString();
                    break;
                case Operacoes.Multiplica:
                    listaDeNumeros = textBoxDisplay.Text.Split('*').Select(double.Parse).ToList();
                    textBoxDisplay.Text = (listaDeNumeros[0] * listaDeNumeros[1]).ToString();
                    break;
                case Operacoes.Nenhuma:
                    break;
                default:
                    break;
            }
        }
        //Exibe os números do display
        private void buttonNum_Click(object sender, EventArgs e)
        {

            textBoxDisplay.Text += (sender as Button).Text;
        }
    }
 }   
      
