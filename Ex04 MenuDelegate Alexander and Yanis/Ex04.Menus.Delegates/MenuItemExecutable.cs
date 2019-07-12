namespace Ex04.Menus.Delegates
{
    public delegate void MenuClickDelegate();

    public class MenuItemExecutable : MenuItem
    {
        public event MenuClickDelegate MenuItemClicked;

        public MenuItemExecutable(string i_MenuItemName)
            : base(i_MenuItemName)
        {
        }

        public override void PerformActionOrOpenSubMenu()
        {
            OnMenuItemClicked();
        }

        protected virtual void OnMenuItemClicked()
        {
            if (MenuItemClicked != null)
            {
                MenuItemClicked.Invoke();
            }
        }
    }
}
