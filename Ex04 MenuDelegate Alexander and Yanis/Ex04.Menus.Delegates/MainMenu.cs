namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private readonly SubMenu r_MainMenu;

        public MainMenu(string i_MenuTitle)
        {
            const bool v_IsMainMenu = true;
            r_MainMenu = new SubMenu(i_MenuTitle, v_IsMainMenu);
        }

        public void Show()
        {
            r_MainMenu.PerformActionOrOpenSubMenu();
        }

        public void AddMenuItemToMainMenu(MenuItem i_MenuItemToAdd)
        {
            r_MainMenu.AddItemToSubMenu(i_MenuItemToAdd);
        }
    }
}
