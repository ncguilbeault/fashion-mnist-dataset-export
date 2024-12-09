using System.Drawing;

public static class BitMapHelper
{
    public static Bitmap FloatArrayToBitmap(float[] array, int height, int width)
    {
        Bitmap bitmap = new Bitmap(width, height);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var value = array[y * width + x];
                var color = (byte)(value * 255);
                bitmap.SetPixel(x, y, Color.FromArgb(color, color, color));
            }
        }

        return bitmap;
    }
}