namespace Ex04.Menus.Delegates
{
    public abstract class MenuItem
    {
        public string m_MenuItemName;

        public string MenuItemName
        {
            get
            {
                return m_MenuItemName;
            }

            set
            {
                m_MenuItemName = value;
            }
        }

        public MenuItem(string i_MenuItemName)
        {
            m_MenuItemName = i_MenuItemName;
        }

        public abstract void PerformActionOrOpenSubMenu();

        public override string ToString()
        {
            return MenuItemName;
        }
    }
}
