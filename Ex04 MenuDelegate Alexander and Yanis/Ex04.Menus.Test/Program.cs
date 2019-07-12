using System;
using MenuInterfaces = Ex04.Menus.Interfaces;
using MenuDelegates = Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            beginMenu();
            endProgramShow();
            Console.ReadKey();
        }

        private static void beginMenu()
        {
            runInterfaceMenu();
            runDelegateMenu();
        }

        private static void runInterfaceMenu()
        {
            const bool v_IsMainMenu = false;

            MenuInterfaces.MainMenu mainMenuInterfaces = new MenuInterfaces.MainMenu("Interfaces Main Menu");

            MenuInterfaces.SubMenu subMenuDateAndTimeInterface = new MenuInterfaces.SubMenu("Show Date/Time", v_IsMainMenu);
            MenuInterfaces.SubMenu subMenuVersionAndDigitsInterface = new MenuInterfaces.SubMenu("Version and Digits", v_IsMainMenu);

            MenuInterfaces.MenuItemExecutable showDateInterface = new MenuInterfaces.MenuItemExecutable("Show Date");
            showDateInterface.AddListener(new ShowDate() as MenuInterfaces.IMenuClickListener);
            MenuInterfaces.MenuItemExecutable showTimeInterface = new MenuInterfaces.MenuItemExecutable("Show Time");
            showTimeInterface.AddListener(new ShowTime() as MenuInterfaces.IMenuClickListener);
            MenuInterfaces.MenuItemExecutable countDigitsInterface = new MenuInterfaces.MenuItemExecutable("Count Digits");
            countDigitsInterface.AddListener(new CountDigits() as MenuInterfaces.IMenuClickListener);
            MenuInterfaces.MenuItemExecutable showVersionInterface = new MenuInterfaces.MenuItemExecutable("Show Version");
            showVersionInterface.AddListener(new ShowVersion() as MenuInterfaces.IMenuClickListener);

            subMenuDateAndTimeInterface.AddItemToSubMenu(showDateInterface);
            subMenuDateAndTimeInterface.AddItemToSubMenu(showTimeInterface);
            subMenuVersionAndDigitsInterface.AddItemToSubMenu(countDigitsInterface);
            subMenuVersionAndDigitsInterface.AddItemToSubMenu(showVersionInterface);

            mainMenuInterfaces.AddMenuItemToMainMenu(subMenuDateAndTimeInterface);
            mainMenuInterfaces.AddMenuItemToMainMenu(subMenuVersionAndDigitsInterface);
            mainMenuInterfaces.Show();
        }

        private static void runDelegateMenu()
        {
            const bool v_IsMainMenu = false;
            MethodsForMenusDelegates methodsForMenusDelegates = new MethodsForMenusDelegates();

            MenuDelegates.MainMenu mainMenuDelegates = new MenuDelegates.MainMenu("Delegates Main Menu");

            MenuDelegates.SubMenu subMenuDateAndTimeDelegate = new MenuDelegates.SubMenu("Show Date/Time", v_IsMainMenu);
            MenuDelegates.SubMenu subMenuVersionAndDigitsDelegate = new MenuDelegates.SubMenu("Version and Digits", v_IsMainMenu);

            MenuDelegates.MenuItemExecutable showDateDelegate = new MenuDelegates.MenuItemExecutable("Show Date");
            showDateDelegate.MenuItemClicked += methodsForMenusDelegates.ShowDate;
            MenuDelegates.MenuItemExecutable showTimeDelegate = new MenuDelegates.MenuItemExecutable("Show Time");
            showTimeDelegate.MenuItemClicked += methodsForMenusDelegates.ShowTime;
            MenuDelegates.MenuItemExecutable countDigitsDelegate = new MenuDelegates.MenuItemExecutable("Count Digits");
            countDigitsDelegate.MenuItemClicked += methodsForMenusDelegates.CountDigits;
            MenuDelegates.MenuItemExecutable showVersionDelegate = new MenuDelegates.MenuItemExecutable("Show Version");
            showVersionDelegate.MenuItemClicked += methodsForMenusDelegates.ShowVersion;

            subMenuDateAndTimeDelegate.AddItemToSubMenu(showDateDelegate);
            subMenuDateAndTimeDelegate.AddItemToSubMenu(showTimeDelegate);
            subMenuVersionAndDigitsDelegate.AddItemToSubMenu(countDigitsDelegate);
            subMenuVersionAndDigitsDelegate.AddItemToSubMenu(showVersionDelegate);

            mainMenuDelegates.AddMenuItemToMainMenu(subMenuDateAndTimeDelegate);
            mainMenuDelegates.AddMenuItemToMainMenu(subMenuVersionAndDigitsDelegate);
            mainMenuDelegates.Show();
        }

        private static void endProgramShow()
        {
            Console.WriteLine("Goodbye");
            Console.Write("Press any key for continue...");
        }
    }
}
