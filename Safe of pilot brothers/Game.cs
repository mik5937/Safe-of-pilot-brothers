using System;
using System.Drawing;
using System.Windows.Forms;

namespace Safe_of_pilot_brothers
{

    public partial class Game : Form
    {
        private  int n = 2 ;
       
        int[,] matrix = new int[2, 2];
        Button[,] spots = new Button[2, 2];
        public Game(int N)
        {
           InitializeComponent();
            n = N;
        }
        void ResizeArray<T>(ref T[,] original, int newCoNum, int newRoNum)
        {
            var newArray = new T[newCoNum, newRoNum];
            int columnCount = original.GetLength(1);
            int columnCount2 = newRoNum;
            int columns = original.GetUpperBound(0);
            for (int co = 0; co <= columns; co++)
                Array.Copy(original, co * columnCount, newArray, co * columnCount2, columnCount);
            original = newArray;
        }
        int  MainMenu()
        {
 
                int index = 0;
                for (int x = 0; x < spots.GetLength(0); ++x)
                    for (int y = 0; y < spots.GetLength(1); ++y)
                    {
                        index++;
                        spots[x, y] = new Button();
                        spots[x, y].Size = new Size(40, 40);
                        spots[x, y].Location = new Point(x * 40, y * 40);
                        spots[x, y].Tag = index;
                        Controls.Add(spots[x, y]); spots[x, y].Click += new EventHandler(Form1_Click);
                        this.Controls.Add(spots[x, y]);
                        spots[x, y].BringToFront();            
                    }
            return 0;
        }
        void UpdateColor()
        {
            for (int x = 0; x < n; ++x)
            {
                for (int y = 0; y < n; ++y)
                {
                    if (matrix[x, y] == 1)
                    {
                        spots[x, y].BackColor = Color.Green;
                    }
                    else
                    {
                        if (matrix[x, y] == 0) { spots[x, y].BackColor = Color.Red; }
                    }
                }
            }
        }
      
        private void Game_Load(object sender, EventArgs e)
        {
            ResizeArray<int>(ref matrix, n, n);
            ResizeArray<Button>(ref spots, n, n);
            MainMenu();

        }
        private void Form1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ChangeMatrix(Convert.ToInt32(button.Tag));   
        }

        int ChangeMatrix(int Tag)
        {
            int x,y = 0;
            x = (Tag-1) / n;
            y = (Tag-1) % n;
            for (int i = 0; i < n; i++)
            {
                if (matrix[x, i] == 0)
                {matrix[x, i] = 1;}
                else
                { matrix[x, i] = 0;}
                if (matrix[i, y] == 0)
                { matrix[i, y] = 1;}
                else
                {matrix[i, y] = 0;}
            }
            if (matrix[x, y] == 0)
            {matrix[x, y] = 1;}
            else { matrix[x, y] = 0; }
            UpdateColor();
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            Random k = new Random();
            int Step = r.Next(7, 15);
            for(int i = 0; i < Step; i++)
            {              
                int Tag = k.Next(1, n*n-1);
                ChangeMatrix(Tag);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
       
            int sum=0;
            for (int i =0; i<n;i++)
            {
                for (int j = 0; j < n; j++)
                { sum = sum + matrix[i, j]; }
            }          
            if (sum==0 | sum == n*n)
            { label1.Text = "Вы выиграли!"; }
            else { label1.Text = "Пока не решено."; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}

