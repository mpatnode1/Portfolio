using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog2_CardGame
{
    public interface IPlay
    {
        void Play();

        /// <summary>
        /// Print Instructions
        /// </summary>
        void Instructions();
        void Setup();
            
      
    }
}