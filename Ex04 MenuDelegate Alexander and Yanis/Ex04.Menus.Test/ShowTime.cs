using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowTime : IMenuClickListener
    {
        public void MenuClick()
        {
            showTime();
        }

        private void showTime()
        {
            Console.WriteLine(string.Format("Current Time: {0}", DateTime.Now.ToString("hh:mm:ss tt")));
        }
    }
}
