namespace Intersect.Framework.Core.GameObjects.Lighting;

public partial class LightDescriptor
{

    public LightDescriptor() : this(-1, -1) { }

    public LightDescriptor(int x, int y)
    {
        TileX = x;
        TileY = y;
        Color = Color.White;
        Intensity = 255;
    }

    public LightDescriptor(LightDescriptor copy)
    {
        TileX = copy.TileX;
        TileY = copy.TileY;
        OffsetX = copy.OffsetX;
        OffsetY = copy.OffsetY;
        Intensity = copy.Intensity;
        Size = copy.Size;
        Expand = copy.Expand;
        Color = Color.FromArgb(copy.Color.R, copy.Color.G, copy.Color.B);
    }

    public LightDescriptor(
        int tileX,
        int tileY,
        int offsetX,
        int offsetY,
        byte intensity,
        int size,
        float expand,
        Color color
    )
    {
        TileX = tileX;
        TileY = tileY;
        OffsetX = offsetX;
        OffsetY = offsetY;
        Intensity = intensity;
        Size = size;
        Expand = expand;
        Color = color;
    }

    public Color Color { get; set; }

    public float Expand { get; set; }

    public byte Intensity { get; set; }

    public int OffsetX { get; set; }

    public int OffsetY { get; set; }

    public int Size { get; set; }

    public int TileX { get; set; }

    public int TileY { get; set; }

    /// <summary>
    /// Only checks for matching colors, intensity, and expand values... so we know if we can group lights and render them with the same shader values to boost performance.
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Intensity, Expand, Color, TileX, TileY);
    }

    /// <summary>
    /// Only checks for matching colors, intensity, and expand values... so we know if we can group lights and render them with the same shader values to boost performance.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
        if (obj is LightDescriptor light)
        {
            return Intensity == light.Intensity && Color == light.Color && Expand == light.Expand && TileX == light.TileX && TileY == light.TileY;
        }

        return false;
    }
}
