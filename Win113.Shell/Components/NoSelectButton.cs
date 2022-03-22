using System.Windows.Forms;

namespace Win113.Shell.Components
{
    public class NoSelectButton : Button
    {
        public NoSelectButton()
        {
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
