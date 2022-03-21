namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        bool playerTurn = true; //True is X turn; False is O turn
        int turnCount = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Michael Valdes", "Tic Tac Toe About");
        }

        private void exitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if(playerTurn)
            {
                b.Text = "X";
            } else
            {
                b.Text = "O";
            }
            playerTurn = !playerTurn;
            b.Enabled = false;
            turnCount++;

            checkForWinner();
        }

        private void checkForWinner()
        {
            bool is_winner = false;

            //Horizontal Win Conditions
            if ((A0.Text == A1.Text) && (A0.Text == A2.Text) && (!A0.Enabled))
                is_winner = true;
            else if ((B0.Text == B1.Text) && (B0.Text == B2.Text) && (!B0.Enabled))
                is_winner = true;
            else if ((C0.Text == C1.Text) && (C0.Text == C2.Text) && (!C0.Enabled))
                is_winner = true;

            //Vertical Win Conditions
            if ((A0.Text == B0.Text) && (A0.Text == C0.Text) && (!A0.Enabled))
                is_winner = true;
            else if ((A1.Text == B1.Text) && (A1.Text == C1.Text) && (!A1.Enabled))
                is_winner = true;
            else if ((A2.Text == B2.Text) && (A2.Text == C2.Text) && (!A2.Enabled))
                is_winner = true;

            //Diagonal Win Conditions
            if ((A0.Text == B1.Text) && (A0.Text == C2.Text) && (!A0.Enabled))
                is_winner = true;
            else if ((A2.Text == B1.Text) && (A2.Text == C0.Text) && (!A2.Enabled))
                is_winner = true;


            if (is_winner)
            {
                String winner = "";
                if (playerTurn)
                {
                    winner = "O";
                }else
                {
                    winner = "X";
                }
                disableGame();
                MessageBox.Show($"{winner} wins!", "Congratulations!");
            }
            else
            {
                if(turnCount == 9)
                {
                    MessageBox.Show("It's a draw!", "Sorry!");
                }
            }
        }

        private void disableGame()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playerTurn = true;
            turnCount = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { }
        }
    }
}