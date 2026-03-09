using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AppSenAgriculture.UI
{
    public class SidePanel : Panel
    {
        private List<SideMenuItem> _menuItems = new List<SideMenuItem>();
        private int _selectedIndex = -1;
        private int _itemHeight = 45;
        private int _headerHeight = 80;
        private int _subItemHeight = 38;

        public event EventHandler<string> MenuItemClicked;

        public SidePanel()
        {
            BackColor = AppTheme.SideBarColor;
            Width = 220;
            DoubleBuffered = true;
            Dock = DockStyle.Left;
        }

        public void AddMenuItem(string title, string tag, string icon = "●", List<SideSubItem> subItems = null)
        {
            _menuItems.Add(new SideMenuItem
            {
                Title = title,
                Tag = tag,
                Icon = icon,
                SubItems = subItems ?? new List<SideSubItem>(),
                IsExpanded = false
            });
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Header / Logo
            using (var brush = new SolidBrush(Color.FromArgb(25, 70, 28)))
                g.FillRectangle(brush, 0, 0, Width, _headerHeight);

            // Logo text
            using (var font = new Font("Segoe UI", 13f, FontStyle.Bold))
            using (var brush = new SolidBrush(AppTheme.AccentGold))
                g.DrawString("🌿 SenAgriculture", font, brush, new RectangleF(15, 15, Width - 20, 30),
                    new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });

            using (var font = new Font("Segoe UI", 8f))
            using (var brush = new SolidBrush(Color.FromArgb(180, 255, 255, 255)))
                g.DrawString("Gestion Agricole", font, brush, new RectangleF(15, 45, Width - 20, 20));

            // Séparateur
            using (var pen = new Pen(Color.FromArgb(60, 255, 255, 255)))
                g.DrawLine(pen, 10, _headerHeight - 1, Width - 10, _headerHeight - 1);

            // Menu items
            int y = _headerHeight + 10;
            for (int i = 0; i < _menuItems.Count; i++)
            {
                var item = _menuItems[i];
                bool isSelected = (_selectedIndex == i && item.SubItems.Count == 0);
                bool isHovered = item.IsHovered;

                // Fond item principal
                Color bgColor = isSelected ? AppTheme.SideBarActive
                              : isHovered ? AppTheme.SideBarHover
                              : Color.Transparent;

                if (bgColor != Color.Transparent)
                    using (var brush = new SolidBrush(bgColor))
                        g.FillRectangle(brush, 0, y, Width, _itemHeight);

                // Indicateur gauche si sélectionné
                if (isSelected)
                    using (var brush = new SolidBrush(AppTheme.AccentGold))
                        g.FillRectangle(brush, 0, y + 8, 4, _itemHeight - 16);

                // Icône
                using (var font = new Font("Segoe UI", 11f))
                using (var brush = new SolidBrush(Color.White))
                    g.DrawString(item.Icon, font, brush, new RectangleF(12, y, 30, _itemHeight),
                        new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                // Titre
                using (var font = isSelected ? AppTheme.SideBarFontBold : AppTheme.SideBarFont)
                using (var brush = new SolidBrush(Color.White))
                    g.DrawString(item.Title, font, brush, new RectangleF(48, y, Width - 70, _itemHeight),
                        new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });

                // Flèche si sous-menu
                if (item.SubItems.Count > 0)
                {
                    string arrow = item.IsExpanded ? "▾" : "▸";
                    using (var font = new Font("Segoe UI", 9f))
                    using (var brush = new SolidBrush(Color.FromArgb(180, 255, 255, 255)))
                        g.DrawString(arrow, font, brush, new RectangleF(Width - 25, y, 20, _itemHeight),
                            new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }

                item.Bounds = new Rectangle(0, y, Width, _itemHeight);
                y += _itemHeight;

                // Sous-items si expanded
                if (item.IsExpanded)
                {
                    foreach (var sub in item.SubItems)
                    {
                        bool subSelected = sub.IsSelected;
                        bool subHovered = sub.IsHovered;

                        Color subBg = subSelected ? Color.FromArgb(50, 255, 255, 255)
                                    : subHovered ? Color.FromArgb(30, 255, 255, 255)
                                    : Color.Transparent;

                        if (subBg != Color.Transparent)
                            using (var brush = new SolidBrush(subBg))
                                g.FillRectangle(brush, 0, y, Width, _subItemHeight);

                        if (subSelected)
                            using (var brush = new SolidBrush(AppTheme.AccentGold))
                                g.FillRectangle(brush, 0, y + 5, 3, _subItemHeight - 10);

                        // Ligne décorative
                        using (var pen = new Pen(Color.FromArgb(60, 255, 255, 255)))
                            g.DrawLine(pen, 55, y + _subItemHeight / 2, 65, y + _subItemHeight / 2);

                        using (var font = subSelected ? new Font("Segoe UI", 9.5f, FontStyle.Bold) : new Font("Segoe UI", 9.5f))
                        using (var brush = new SolidBrush(subSelected ? Color.White : Color.FromArgb(200, 255, 255, 255)))
                            g.DrawString(sub.Title, font, brush, new RectangleF(70, y, Width - 80, _subItemHeight),
                                new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });

                        sub.Bounds = new Rectangle(0, y, Width, _subItemHeight);
                        y += _subItemHeight;
                    }
                }
            }

            // Pied de page
            using (var pen = new Pen(Color.FromArgb(40, 255, 255, 255)))
                g.DrawLine(pen, 10, Height - 35, Width - 10, Height - 35);

            using (var font = new Font("Segoe UI", 7.5f))
            using (var brush = new SolidBrush(Color.FromArgb(120, 255, 255, 255)))
                g.DrawString("© 2025 SenAgriculture", font, brush, new RectangleF(0, Height - 28, Width, 20),
                    new StringFormat { Alignment = StringAlignment.Center });
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            bool needsRedraw = false;

            foreach (var item in _menuItems)
            {
                bool wasHovered = item.IsHovered;
                item.IsHovered = item.Bounds.Contains(e.Location);
                if (wasHovered != item.IsHovered) needsRedraw = true;

                foreach (var sub in item.SubItems)
                {
                    bool wasSubHovered = sub.IsHovered;
                    sub.IsHovered = sub.Bounds.Contains(e.Location);
                    if (wasSubHovered != sub.IsHovered) needsRedraw = true;
                }
            }

            if (needsRedraw) Invalidate();
            Cursor = Cursors.Hand;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            for (int i = 0; i < _menuItems.Count; i++)
            {
                var item = _menuItems[i];
                if (item.Bounds.Contains(e.Location))
                {
                    if (item.SubItems.Count > 0)
                    {
                        item.IsExpanded = !item.IsExpanded;
                        Invalidate();
                    }
                    else
                    {
                        // Désélectionner sous-items
                        foreach (var mi in _menuItems)
                            foreach (var si in mi.SubItems)
                                si.IsSelected = false;

                        _selectedIndex = i;
                        Invalidate();
                        MenuItemClicked?.Invoke(this, item.Tag);
                    }
                    return;
                }

                foreach (var sub in item.SubItems)
                {
                    if (sub.Bounds.Contains(e.Location))
                    {
                        foreach (var mi in _menuItems)
                            foreach (var si in mi.SubItems)
                                si.IsSelected = false;

                        sub.IsSelected = true;
                        _selectedIndex = -1;
                        Invalidate();
                        MenuItemClicked?.Invoke(this, sub.Tag);
                        return;
                    }
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            foreach (var item in _menuItems)
            {
                item.IsHovered = false;
                foreach (var sub in item.SubItems)
                    sub.IsHovered = false;
            }
            Invalidate();
        }
    }

    public class SideMenuItem
    {
        public string Title { get; set; }
        public string Tag { get; set; }
        public string Icon { get; set; }
        public List<SideSubItem> SubItems { get; set; } = new List<SideSubItem>();
        public bool IsExpanded { get; set; }
        public bool IsHovered { get; set; }
        public Rectangle Bounds { get; set; }
    }

    public class SideSubItem
    {
        public string Title { get; set; }
        public string Tag { get; set; }
        public bool IsSelected { get; set; }
        public bool IsHovered { get; set; }
        public Rectangle Bounds { get; set; }
    }
}
