using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guess_My_Number
{
    public partial class GuessMyForm : Form
    {

        public GuessMyForm()
        {
            InitializeComponent();
        }


        private static int Rando()
        {
            Random r = new Random();
            int rand = r.Next(1, 51);
            return rand;

        }
        int rand = Rando();
        int userGuess = 0;
        bool win = false;
        bool hard = false;


        private void btnGuess_Click(object sender, EventArgs e)
        {

            try
            {
                userGuess = Convert.ToInt32(txtNumber.Text);
                if (IsWithinRange())

                    if (hard)
                    {
    /*                    for (int g = 0; g < 5; g++)
                        {
                            int guesses = 5 - g;
                            if (g == 5)
                                MessageBox.Show("You have run out off attempts. Hard mode was too hard for you!!", "Sorry!");
                            else
                            {
                                if (userGuess == rand)
                                {
                                    MessageBox.Show("You completed hard mode in " + guesses + " attempts!! wow!!", "Congratulations!!",
                                        MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                                    btnGuess.Enabled = false;
                                    txtResult.Text = ("Your last guess of " + userGuess +
                                        " was correct!");
                                    btnGenerate.Focus();
                                    win = true;
                                                                        break;
                                }
                                else if (userGuess > rand)
                                {
                                    MessageBox.Show("Your guess was too high! Please try again. You have " + guesses + " attempts remaining",
                                        "Guess too high",
                                        MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                                    txtResult.Text = ("Your last guess of " + userGuess + "" +
                                        " was too high.");
                                    txtNumber.Focus();
                                    txtNumber.Text = "";
                                    g++;
                                    break;
                                }
                                else if (userGuess < rand)
                                {
                                    MessageBox.Show("Your guess was too low! Please try again. You have " + guesses + "attempts remaining",
                                        "Guess too low",
                                        MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                                    txtResult.Text = ("Your last guess of " + userGuess +
                                        " was too low.");
                                    txtNumber.Focus();
                                    txtNumber.Text = "";
                                    g++;
                                    break;
                                }
                            }
                        }
                        */
                    }


                    else
                    {

                        if (userGuess == rand)
                        {

                            MessageBox.Show("You win! Press the \"Generate New Number\" button to try again", "Congratulations!!",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            btnGuess.Enabled = false;
                            txtResult.Text = ("Your last guess of " + userGuess +
                                " was correct!");
                            btnGenerate.Focus();
                            win = true;
                            DialogResult dialogResult = MessageBox.Show("Do you wish to try hard mode?", "A greater challenge appears!",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                                hard = true;
                            rand = Rando();
                            txtNumber.Focus();
                            txtNumber.Text = "";

                        }
                        else if (userGuess > rand)
                        {
                            MessageBox.Show("Your guess was too high! Please try again.",
                                "Guess too high",
                                MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                            txtResult.Text = ("Your last guess of " + userGuess + "" +
                                " was too high.");
                            txtNumber.Focus();
                            txtNumber.Text = "";
                        }
                        else if (userGuess < rand)
                        {
                            MessageBox.Show("Your guess was too low! Please try again.",
                                "Guess too low",
                                MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                            txtResult.Text = ("Your last guess of " + userGuess +
                                " was too low.");
                            txtNumber.Focus();
                            txtNumber.Text = "";
                        }
                    }
                
                
            }


            catch (FormatException)
            {

                MessageBox.Show("Please enter a number", "Input Error",
                    MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n\n"
                    + ex.StackTrace, "Exception",
                    MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }

        }
    
        private bool IsWithinRange()
        {
            
            if (userGuess < 0 || userGuess > 50)
            {
                MessageBox.Show("Your entry must be between 1 and 50.", "Entry Error");
                txtNumber.Focus();
                txtResult.Text = ("Please enter a number between 1 and 50.");
                txtNumber.Text = ("");

                return false;
                           }
            else
                return true;
        }



        private void btnGenerate_Click(object sender, EventArgs e)
        {

            btnGuess.Enabled = true;
            userGuess = 0;
            txtNumber.Text = "";
            rand = Rando();
            MessageBox.Show("A new number has been generated", "Let's play again!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);

            txtNumber.Focus();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            if (win == true)
            {
                MessageBox.Show("Please play again later!", "See you later, Master of Numbers",
                    MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                this.Close();
            }
            else
                MessageBox.Show("So long loser!", "Go cry to your momma");
            this.Close();
            
        }
    }
}