using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Win113.Shell.Helpers
{
    public static class ProgmanHelper
    {
        public static List<KeyValuePair<string, List<ListViewItem>>> LoadCategoryShortcuts()
        {
            var categoriesJson = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\bobshell.progman.json");
            JObject categories = JObject.Parse(categoriesJson);

            List<KeyValuePair<string, List<ListViewItem>>> result = new List<KeyValuePair<string, List<ListViewItem>>>();

            foreach (JProperty category in categories.Children())
            {
                List<ListViewItem> categoryShortcuts = new List<ListViewItem>();
                foreach(JObject shortcut in category.First().Children())
                {
                    ListViewItem shortcutResult = new ListViewItem((string)shortcut["Text"], (string)shortcut["Icon"]);
                    ShortcutItem shortcutItem = new ShortcutItem();
                    shortcutItem.Path = (string)shortcut["Path"];
                    shortcutItem.Arguments = (string)shortcut["Args"];
                    shortcutItem.UseShell = (bool)shortcut["UseShell"];
                    shortcutItem.ShowWindow = (bool)shortcut["ShowWindow"];
                    shortcutResult.Tag = shortcutItem;

                    categoryShortcuts.Add(shortcutResult);
                }

                KeyValuePair<string, List<ListViewItem>> resultCategory = new KeyValuePair<string, List<ListViewItem>>(category.Name, categoryShortcuts);
                result.Add(resultCategory);
            }
            return result;
        }

        public struct ShortcutItem
        {
            public string Path;
            public string Arguments;
            public bool UseShell;
            public bool ShowWindow;
        };
    }
}
