using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuItemExecutable : MenuItem
    {
        private readonly List<IMenuClickListener> r_MenuClickListeners = new List<IMenuClickListener>();

        public MenuItemExecutable(string i_MenuItemName)
            : base(i_MenuItemName)
        {
        }

        public void AddListener(IMenuClickListener i_MenuClickListener)
        {
            r_MenuClickListeners.Add(i_MenuClickListener);
        }

        public void RemoveListener(IMenuClickListener i_MenuClickListener)
        {
            r_MenuClickListeners.Remove(i_MenuClickListener);
        }

        public override void PerformActionOrOpenSubMenu()
        {
            foreach (IMenuClickListener menuItemListener in r_MenuClickListeners)
            {
                menuItemListener.MenuClick();
            }
        }
    }
}
