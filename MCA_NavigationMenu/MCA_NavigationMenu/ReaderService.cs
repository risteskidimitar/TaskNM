using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MCA_NavigationMenu
{
    public class ReaderService
    {
        private static int _counter;

        private List<MenuItem> _menuItems;

        public ReaderService(string link)
        {
            _menuItems = MenuItems(link);

            Recursion(_menuItems);
        }


        public List<MenuItem> MenuItems(string link)
        {
            using (StreamReader sr = new StreamReader(link))
            {
                List<MenuItem> menuItems = new List<MenuItem>();
                string fullText = sr.ReadToEnd();
                Console.WriteLine(fullText);
                string[] rows = fullText.Split('\n');

                for (int i = 1; i < rows.Length - 1; i++)
                {
                    string[] splittedRow = rows[i].Split(';');

                    MenuItem menuItem = new MenuItem
                    {
                        ID = Convert.ToInt32(splittedRow[0]),
                        MenuName = splittedRow[1],
                        ParentID = NullableInt(splittedRow[2]),
                        IsHidden = Convert.ToBoolean(splittedRow[3]),
                        LinkUrl = splittedRow[4]

                    };

                    menuItems.Add(menuItem);
                }
                return menuItems;
            }
        }
        private void Recursion(List<MenuItem> menuItems, int? parentId = null)
        {

            List<MenuItem> subList = menuItems
                                    .Where(x => x.ParentID == parentId && x.IsHidden == false)
                                    .OrderBy(y => y.MenuName).ToList();

            if (subList != null)
            {
                foreach (var item in subList)
                {
                    _counter++;
                    Console.WriteLine($"{_counter}-{item.MenuName}");
                    Recursion(menuItems, item.ID);
                }
            }
        }

        public static int? NullableInt(string num)
        {
            if (int.TryParse(num, out int i)) return i;
            return null;
        }
    }
}
