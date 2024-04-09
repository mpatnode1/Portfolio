using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog2_CardGame
{
    public class Player
    {
        private int score;


        public int Score
        {
            get { return score; }
            set { Score = value; }
        }


        private string name; 

        public string Name 
        {
            get { return name; }
            set { name = value; }
        }

        public void AddPoint()
        {
            score++;
        }

        public void Draw()
        {
            throw new System.NotImplementedException();
        }

        public void Fold()
        {
            throw new System.NotImplementedException();
        }

        public void SetWinner()
        {
            throw new System.NotImplementedException();
        }
    }
}