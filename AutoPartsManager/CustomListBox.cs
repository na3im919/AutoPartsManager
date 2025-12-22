// في ملف CustomListBox.cs
using System.Windows.Forms;

public class CustomListBox : ListBox
{
    protected override bool IsInputKey(Keys keyData)
    {
        if (keyData == Keys.Up || keyData == Keys.Down)
        {
            return true;
        }
        return base.IsInputKey(keyData);
    }
}