using System.Windows.Forms;
using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Utilities
{
    public static class FormThemeManager
    {
        public static readonly System.Drawing.Color Primary = System.Drawing.Color.FromArgb(0x2D, 0x86, 0x59);
        public static readonly System.Drawing.Color Background = System.Drawing.Color.FromArgb(0xF5, 0xF5, 0xF5);
        public static readonly System.Drawing.Color PrimaryForeground = System.Drawing.Color.White;
        public static readonly System.Drawing.Color TextColor = System.Drawing.Color.FromArgb(0x33, 0x33, 0x33);

        public static readonly Font FontBody = new Font("Segoe UI", 10F);
        public static readonly Font FontBodyBold = new Font("Segoe UI", 10F, FontStyle.Bold);
        public static readonly Font FontSection = new Font("Segoe UI", 12F, FontStyle.Bold);
        public const int ButtonHeight = 38;
        public static readonly System.Drawing.Color PanelBackground = System.Drawing.Color.White;

        public static void ApplyToForm(Form form)
        {
            if (form == null) return;
            form.BackColor = Background;
            form.Font = FontBody;
        }

        public static void ApplyIconButton(IconButton button)
        {
            if (button == null) return;
            button.Height = ButtonHeight;
            button.BackColor = Primary;
            button.ForeColor = PrimaryForeground;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = FontBodyBold;
            button.Cursor = Cursors.Hand;
            button.IconColor = PrimaryForeground;
        }

        public static void ApplyTitleLabel(Label label)
        {
            if (label == null) return;
            label.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label.ForeColor = Primary;
        }

        public static void ApplyStandardButton(Button button)
        {
            if (button == null) return;
            button.Height = ButtonHeight;
            button.BackColor = Primary;
            button.ForeColor = PrimaryForeground;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = FontBodyBold;
            button.Cursor = Cursors.Hand;
        }
    }
}
