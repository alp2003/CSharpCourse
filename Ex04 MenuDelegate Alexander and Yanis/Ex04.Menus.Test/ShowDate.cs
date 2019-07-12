using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowDate : IMenuClickListener
    {
        public void MenuClick()
        {
            showDate();
        }

        private void showDate()
        {
            Console.WriteLine(string.Format("Current Date: {0}", DateTime.Now.ToShortDateString()));
        }
    }
}
