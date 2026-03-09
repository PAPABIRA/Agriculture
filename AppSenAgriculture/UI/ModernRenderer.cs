using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AppSenAgriculture.UI
{
    /// <summary>
    /// Bouton arrondi et coloré pour l'interface moderne
    /// </summary>
    public class RoundedButton : Button
    {
        private Color _backColor;
        private Color _hoverColor;
        private Color _textColor = Color.White;
        private bool _isHovered = false;
        private int _radius = 6;

        public RoundedButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;
            Font = AppTheme.NormalFont;
            _backColor = AppTheme.PrimaryGreen;
            _hoverColor = AppTheme.LightGreen;
            BackColor = _backColor;
            ForeColor = _textColor;
        }

        public Color ButtonColor
        {
            get => _backColor;
            set { _backColor = value; BackColor = value; Invalidate(); }
        }

        public Color HoverColor
        {
            get => _hoverColor;
            set { _hoverColor = value; Invalidate(); }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered = true;
            BackColor = _hoverColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered = false;
            BackColor = _backColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (var path = new GraphicsPath())
            {
                var rect = new Rectangle(0, 0, Width - 1, Height - 1);
                int r = _radius * 2;
                path.AddArc(rect.X, rect.Y, r, r, 180, 90);
                path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
                path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
                path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
                path.CloseAllFigures();
                Region = new Region(path);
            }
        }
    }

    /// <summary>
    /// TextBox avec bordure colorée en bas uniquement (style Material)
    /// </summary>
    public class BorderedTextBox : TextBox
    {
        public BorderedTextBox()
        {
            BorderStyle = BorderStyle.None;
            Font = AppTheme.NormalFont;
            BackColor = AppTheme.White;
        }
    }
}
