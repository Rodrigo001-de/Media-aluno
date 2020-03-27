using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaAluno
{
    public partial class r : Form
    {
        public r()
        {
            InitializeComponent();
        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            double Nota1, Nota2, Trabalho;

            //converte o conteúdo dos componentes TextBox e ComboBox para double e realiza a multiplicação
            Nota1 = Convert.ToDouble(txtNota1.Text) * Convert.ToDouble(cboPesoNota1.Text);
            Nota2 = double.Parse(txtNota2.Text) * double.Parse(cboPesoNota2.Text);
            Trabalho = Convert.ToDouble(txtTrabalho.Text) * Convert.ToDouble(cboPesoTrabalho.Text);

            double Media = Nota1 + Nota2 + Trabalho;

            txtMediaFinal.Text = Media.ToString(); //convertendo e atribuindo a variável Media


            double QdeAulas, QdeFaltas;

            //converte o conteúdo dos componentes TextBox(Qde Aulas e Qde Faltaas)
            QdeAulas = double.Parse(txtQdeAulas.Text);
            QdeFaltas = double.Parse(txtQdeFaltas.Text);

            //Realiza a conta necessária para achar a porcentagem da presença do aluno
            double PorcentagemPresenca = 100 - ((QdeFaltas / QdeAulas) * 100);

            //Realiza a conta do aproveitamento do aluno e converte o valor em string para ser exibido no txtAproveitamento
            txtAproveitamento.Text = Convert.ToString(((Media * 10) + (PorcentagemPresenca)) / 2) + "%";

            if (txtRecuperacao.Text == "")
            {
                if (Media >= Convert.ToDouble(numNotaCorte.Value) && PorcentagemPresenca >= 75)
                {
                    lblSituacao.Text = "Aprovado";
                    lblSituacao.ForeColor = Color.Green;
                }

                //Caso o if anterior retornar falso, será verificado se a média obtida é menor que 2.5
                //OU se a presença é inferior a 75%
                else
                    if (Media <= 2.5 || PorcentagemPresenca < 75)
                {
                    //No caso do Else if retornar verdade:
                    lblSituacao.Text = "Reprovado"; // irá aparecer Reprovado no campo lblSituacao.Text,
                    lblSituacao.ForeColor = Color.Firebrick; // com a cor firebrick(vermelho).
                }

                // No caso de o if e o Else if retornarem falso, obrigatóriamente a execução irá passar por este Else
                else
                {
                    lblSituacao.Text = "Recuperação"; //irá aparecer Recuperação no campo lblSituacao.Text,
                    lblSituacao.ForeColor = Color.Firebrick; // com a cor firebrick(vermelho).
                }
            }

            //No caso do campo lblRecuperacao possuir conteúdo, a execução do programa será devisada para este Else
            else
            {
                //Cálculo da nova Média, somando-a ela mesma com o conteúdo do componente txtRecuperacao.Text e dividindo por 2
                Media = (Media + Convert.ToDouble(txtRecuperacao.Text)) / 2;

                //Atribuiçaõ do novo cálculo sobre o aproveitamento do aluno para o campo txtAproveitamento
                txtAproveitamento.Text = Convert.ToString(((Media * 10) + (PorcentagemPresenca)) / 2) + "%";

                //A partir da nova média é verificado se o aluno atingiu nota igual ou superior a 5
                if (Media >= 5)
                {
                    //Se a condição retornar verdadeira, então:
                    lblSituacao.Text = "Aprovado"; // irá aparecer Aprovado no campo lblSituacao.Text,
                    lblSituacao.ForeColor = Color.Green; // com a cor verde.
                }

                    //Caso o if acima retornar falso, será executado as intruçãoes que estão dentro do else  abaixo.
                else
                {
                    lblSituacao.Text = "Reprovado"; //Irá aparecer Reprovado no campo ,
                    lblSituacao.ForeColor = Color.Firebrick; // com a cor Firebrick(vermelho).
                }

                txtMediaFinal.Text = Media.ToString();
            }
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            txtAproveitamento.Text = "";
            txtNota1.Text = "";
            txtNota2.Text = "";
            txtTrabalho.Text = "";
            txtQdeAulas.Text = "";
            txtQdeFaltas.Text = "";
            txtRecuperacao.Text = "";
            txtMediaFinal.Text = "";
            
        }
    }
}
