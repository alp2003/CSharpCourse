using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class SubMenu : MenuItem
    {
        private const int k_ExitMenuOption = 0;
        private readonly string r_TypeOfZeroAction;
        private readonly List<MenuItem> r_MenuItems;

        public SubMenu(string i_MenuName, bool i_IsMainMenu)
            : base(i_MenuName)
        {
            const string k_MainMenuExitString = "Exit";
            const string k_SubMenuExitString = "Back";
            r_MenuItems = new List<MenuItem>();
            r_TypeOfZeroAction = i_IsMainMenu ? k_MainMenuExitString : k_SubMenuExitString;
        }

        public void AddItemToSubMenu(MenuItem i_MenuItem)
        {
            r_MenuItems.Add(i_MenuItem);
        }

        public override void PerformActionOrOpenSubMenu()
        {
            StringBuilder currentSubMenuOptionText = new StringBuilder(this.ToString());
            int indexOfItem = 1;
            int userMenuChoice = 0;
            bool isUserInputCorrect = false;

            currentSubMenuOptionText.AppendFormat("{0}{1}{2}", Environment.NewLine, new string('=', this.ToString().Length), Environment.NewLine);
            
            foreach (MenuItem menuItem in r_MenuItems)
            {
                currentSubMenuOptionText.AppendFormat("{0} - {1}{2}", indexOfItem, menuItem.ToString(), Environment.NewLine);
                indexOfItem++;
            }

            currentSubMenuOptionText.AppendFormat("0 - {0}{1}Press: ", r_TypeOfZeroAction, Environment.NewLine);
            Console.Write(currentSubMenuOptionText.ToString());

            do
            {
                isUserInputCorrect = getInputFromUser(out userMenuChoice);
                if (!isUserInputCorrect)
                {
                    Console.Write("Please try again! ");
                    Console.Write("Press: ");
                }
            }
            while (!isUserInputCorrect);

            Console.Clear();
            if (userMenuChoice != k_ExitMenuOption)
            {
                r_MenuItems[userMenuChoice - 1].PerformActionOrOpenSubMenu();
                this.PerformActionOrOpenSubMenu();
            }
        }

        private bool getInputFromUser(out int o_UserMenuChoice)
        {
            o_UserMenuChoice = 0;
            string getInputFromUser = Console.ReadLine();
            bool isGoodMenuInput = int.TryParse(getInputFromUser, out o_UserMenuChoice);
            isGoodMenuInput = isGoodMenuInput && k_ExitMenuOption <= o_UserMenuChoice &&
                o_UserMenuChoice <= r_MenuItems.Count;

            return isGoodMenuInput;
        }
    }
}
