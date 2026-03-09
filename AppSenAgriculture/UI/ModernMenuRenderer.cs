using System.Drawing;
using System.Windows.Forms;
 
namespace AppSenAgriculture.UI
{
    internal sealed class ModernMenuColorTable : ProfessionalColorTable
    {
        public ModernMenuColorTable()
        {
            // On désactive les couleurs Windows par défaut pour avoir
            // un rendu cohérent (mêmes couleurs sur toutes les machines).
            UseSystemColors = false;
        }
 
        // Top menu bar
        public override Color MenuStripGradientBegin => Color.FromArgb(15, 23, 42);  // slate-900
        public override Color MenuStripGradientEnd => Color.FromArgb(15, 23, 42);
 
        // Drop-down
        public override Color ToolStripDropDownBackground => Color.FromArgb(30, 41, 59); // slate-800
        public override Color ImageMarginGradientBegin => Color.FromArgb(30, 41, 59);
        public override Color ImageMarginGradientMiddle => Color.FromArgb(30, 41, 59);
        public override Color ImageMarginGradientEnd => Color.FromArgb(30, 41, 59);
 
        // Items
        public override Color MenuItemSelected => Color.FromArgb(51, 65, 85); // slate-700
        public override Color MenuItemBorder => Color.FromArgb(59, 130, 246); // blue-500
        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(51, 65, 85);
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(51, 65, 85);
        public override Color MenuItemPressedGradientBegin => Color.FromArgb(71, 85, 105); // slate-600
        public override Color MenuItemPressedGradientEnd => Color.FromArgb(71, 85, 105);
 
        public override Color SeparatorDark => Color.FromArgb(51, 65, 85);
        public override Color SeparatorLight => Color.FromArgb(51, 65, 85);
 
        public override Color ToolStripBorder => Color.FromArgb(30, 41, 59);
    }
 
    internal sealed class ModernMenuRenderer : ToolStripProfessionalRenderer
    {
        public ModernMenuRenderer() : base(new ModernMenuColorTable())
        {
            // Les bords arrondis de ToolStrip ont tendance à faire "ancien style" :
            // on force un rendu plus net/rectangulaire.
            RoundedEdges = false;
        }
 
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (e.ToolStrip is MenuStrip || e.ToolStrip is ToolStripDropDown)
            {
                // Texte clair sur fond sombre (lisible et constant).
                e.TextColor = Color.WhiteSmoke;
            }
 
            base.OnRenderItemText(e);
        }
 
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            // Même logique : flèche claire sur fond sombre.
            e.ArrowColor = Color.WhiteSmoke;
            base.OnRenderArrow(e);
        }
 
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            // Pour un rendu plus moderne, on évite les dégradés "old school" :
            // la sélection est un simple bloc de couleur.
            if (e.Item.Selected || e.Item.Pressed)
            {
                using (var b = new SolidBrush(((ProfessionalColorTable)ColorTable).MenuItemSelected))
                {
                    e.Graphics.FillRectangle(b, new Rectangle(Point.Empty, e.Item.Size));
                }
                return;
            }
 
            base.OnRenderMenuItemBackground(e);
        }
    }
}
