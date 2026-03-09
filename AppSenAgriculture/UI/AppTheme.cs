using System.Drawing;

namespace AppSenAgriculture.UI
{
    /// <summary>
    /// Palette de couleurs du thème SenAgriculture
    /// Vert nature + blanc + accents dorés/sable
    /// </summary>
    public static class AppTheme
    {
        // Couleurs principales
        public static readonly Color PrimaryGreen    = Color.FromArgb(46, 125, 50);   // Vert foncé
        public static readonly Color LightGreen      = Color.FromArgb(76, 175, 80);   // Vert moyen
        public static readonly Color PaleGreen       = Color.FromArgb(232, 245, 233); // Vert très clair
        public static readonly Color AccentGold      = Color.FromArgb(255, 193, 7);   // Doré/Sable
        public static readonly Color SideBarColor    = Color.FromArgb(33, 90, 36);    // Sidebar foncée
        public static readonly Color SideBarHover    = Color.FromArgb(56, 142, 60);   // Hover sidebar
        public static readonly Color SideBarActive   = Color.FromArgb(76, 175, 80);   // Actif sidebar

        // Neutres
        public static readonly Color White           = Color.White;
        public static readonly Color LightGray       = Color.FromArgb(245, 247, 245);
        public static readonly Color MediumGray      = Color.FromArgb(158, 158, 158);
        public static readonly Color DarkGray        = Color.FromArgb(66, 66, 66);
        public static readonly Color TextDark        = Color.FromArgb(33, 33, 33);

        // Statuts
        public static readonly Color Success         = Color.FromArgb(56, 142, 60);
        public static readonly Color Danger          = Color.FromArgb(211, 47, 47);
        public static readonly Color Warning         = Color.FromArgb(245, 124, 0);

        // Polices
        public static readonly Font TitleFont        = new Font("Segoe UI", 14f, FontStyle.Bold);
        public static readonly Font SubtitleFont     = new Font("Segoe UI", 11f, FontStyle.Bold);
        public static readonly Font NormalFont       = new Font("Segoe UI", 9.5f);
        public static readonly Font SmallFont        = new Font("Segoe UI", 8.5f);
        public static readonly Font SideBarFont      = new Font("Segoe UI", 10f, FontStyle.Regular);
        public static readonly Font SideBarFontBold  = new Font("Segoe UI", 10f, FontStyle.Bold);
    }
}
