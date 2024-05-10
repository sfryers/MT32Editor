using System.Windows.Forms;
using System.Drawing;
namespace MT32Edit_legacy;

/// <summary>
/// Custom drawing tools for MT-32 Editor UI
/// </summary>
internal class DrawingTools
{
    // MT32Edit: DrawingTools class
    // S.Fryers Feb 2024 

    /// <summary>
    /// Custom comboBox- creates vertical divider between structure type and structure description.
    /// </summary>
    /// <param name="e"></param>
    /// <param name="isPartial12"></param>
    /// <param name="droppedDown"></param>
    /// <param name="UIScale"></param>
    public void DrawStructureList(DrawItemEventArgs e, bool isPartial12, bool droppedDown, float UIScale)
    {
        if (e.Index < 0)
        {
            return;
        }

        e.DrawBackground();
        string partialConfigType = $"{e.Index + 1}: {MT32Strings.partialConfig[e.Index]}";
        string partialConfigDescription = isPartial12 ? MT32Strings.partialConfig12Desc[e.Index] : MT32Strings.partialConfig34Desc[e.Index];

        int xLeft = e.Bounds.Location.X;
        int xMid = (int)(58 * UIScale);
        int yTop = e.Bounds.Location.Y;
        int yBottom = yTop + e.Bounds.Height;

        TextRenderer.DrawText(e.Graphics, partialConfigType, e.Font, new Point(xLeft, yTop), e.ForeColor);
        if (droppedDown)
        {
            e.Graphics.DrawLine(SystemPens.ButtonFace, xMid, yTop, xMid, yBottom);
            TextRenderer.DrawText(e.Graphics, partialConfigDescription, e.Font, new Point(xMid + 5, yTop), e.ForeColor, TextFormatFlags.Left);
            e.DrawFocusRectangle();
        }
    }
}
