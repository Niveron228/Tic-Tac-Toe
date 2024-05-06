using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bt11.Text = "";
            bt12.Text = "";
            bt13.Text = "";
            bt21.Text = "";
            bt22.Text = "";
            bt23.Text = "";
            bt31.Text = "";
            bt32.Text = "";
            bt33.Text = "";
        }
        public bool charac;
        public string my_char = null;
        public string enemy_char = null;

        private void button1_Click(object sender, EventArgs e)
        {

            charac = true;
            button1.Enabled = false;
            button2.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            charac = false;
            button2.Enabled = false;
            button1.Enabled = false;

        }

        private void bt11_Click(object sender, EventArgs e)
        {
            CheckSecondPlayer(bt11);
        }

        private void bt12_Click(object sender, EventArgs e)
        {
            CheckSecondPlayer(bt12);
        }

        private void bt13_Click(object sender, EventArgs e)
        {
            CheckSecondPlayer(bt13);
        }

        private void bt21_Click(object sender, EventArgs e)
        {
            CheckSecondPlayer(bt21);
        }

        private void bt22_Click(object sender, EventArgs e)
        {
            CheckSecondPlayer(bt22);
        }

        private void bt23_Click(object sender, EventArgs e)
        {
            CheckSecondPlayer(bt23);
        }

        private void bt31_Click(object sender, EventArgs e)
        {
            CheckSecondPlayer(bt31);
        }

        private void bt32_Click(object sender, EventArgs e)
        {
            CheckSecondPlayer(bt32);

        }

        private void bt33_Click(object sender, EventArgs e)
        {
            CheckSecondPlayer(bt33);
        }
        private bool CheckButtonsText(Button button1, Button button2, Button button3, out string winningText)
        {
            if (button1.Text == button2.Text && button2.Text == button3.Text && !string.IsNullOrEmpty(button1.Text))
            {
                winningText = button1.Text;
                return true;
            }
            else
            {
                winningText = null;
                return false;
            }
        }
        private void CheckSecondPlayer(Button button1)
        {
            if(Variables.IsGameWithBot == false)
            {
                GameWithPlayer(button1);
            }
            else
            {
                GameWithBot(button1);
            }
        }
        private void GameWithPlayer(Button button1)
        {
            button1.Text = MyOutPut();
            button1.Enabled = false;
            charac = !charac;
            CheckWin();
        }
        private void GameWithBot(Button button1)
        {
            MakePlayerMove(button1);
            PlayWithBot();
        }
        private void PlayWithBot()
        {
            List<Button> emptyButtons = new List<Button>();
            foreach (Button button in new Button[] { bt11, bt12, bt13, bt21, bt22, bt23, bt31, bt32, bt33 })
            {
                if (string.IsNullOrEmpty(button.Text))
                {
                    emptyButtons.Add(button);
                }
            }
            if (emptyButtons.Count > 0)
            {
                Random random = new Random();
                int index = random.Next(emptyButtons.Count);
                Button randomEmptyButton = emptyButtons[index];
                randomEmptyButton.Text = EnemySymbol();
                randomEmptyButton.Enabled = false;
                charac = !charac;
                CheckWin();
            }
        }

        private string EnemySymbol()
        {
            return (my_char == "X") ? "O" : "X";
        }
        private void MakePlayerMove(Button button)
        {
            button.Text = MyOutPut();
            button.Enabled = false;
            charac = !charac;
            CheckWin();
        }
    

    private void CheckWin()
        {
            string winningText;
            if (CheckButtonsText(bt11, bt12, bt13, out winningText) ||
                CheckButtonsText(bt21, bt22, bt23, out winningText) ||
                CheckButtonsText(bt31, bt32, bt33, out winningText))
            {
                MessageBox.Show($"\'{winningText}\' won!", "Result");
                BackMenu();

            }
            else if (CheckButtonsText(bt11, bt21, bt31, out winningText) ||
                     CheckButtonsText(bt12, bt22, bt32, out winningText) ||
                     CheckButtonsText(bt13, bt23, bt33, out winningText))
            {
                MessageBox.Show($"\'{winningText}\' won!", "Result");
                BackMenu();
            }
            else if (CheckButtonsText(bt11, bt22, bt33, out winningText) ||
                     CheckButtonsText(bt13, bt22, bt31, out winningText))
            {
                MessageBox.Show($"\'{winningText}\' won!", "Result");
                BackMenu();
            }
            else
            {
                bool isBoardFull = true;
                foreach (Button button in new Button[] { bt11, bt12, bt13, bt21, bt22, bt23, bt31, bt32, bt33 })
                {
                    if (string.IsNullOrEmpty(button.Text))
                    {
                        isBoardFull = false;
                        break;
                    }
                }
                if (isBoardFull)
                {
                    MessageBox.Show("It's a draw!", "Result");
                    BackMenu();
                }
            }
        }
        private void BackMenu()
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
            this.Close();
        }




        private string MyOutPut()
        {
            if (charac == false)
            {
                my_char = "O";
                enemy_char = "X";
            }
            else if (charac == true)
            {
                my_char = "X";
                enemy_char = "O";
            }
            return my_char;

        }
    }

}


