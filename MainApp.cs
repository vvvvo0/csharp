﻿using System; 

namespace Hello 
{
    class MainApp 
    {
        static void Main(string[] args)  
        {
            int i = 10;

            while(i>0) 
            {
                Console.WriteLine($"i : {i--}");
            }
        }
    }
}
