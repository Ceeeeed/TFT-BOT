using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;


public static class ImageFinder {

    public static Bitmap screen = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);

    public static void CaptureScreen() {
        Graphics graphics = Graphics.FromImage(screen);
        graphics.CopyFromScreen(0, 0, 0, 0, new Size(1920, 1080), CopyPixelOperation.SourceCopy);
    }

    public static bool FindOnScreen(Bitmap find, Rectangle scanPos, out List<Point> positions) {
        bool found = false;
        positions = new List<Point>();

        Bitmap search = screen.Clone(scanPos, screen.PixelFormat);

        Color col = find.GetPixel(0, 0);

        for (int x = 0; x < search.Width; x++) {
            for (int y = 0; y < search.Height; y++) {
                if (search.GetPixel(x, y) == col)
                    if (x + find.Width <= search.Width && y + find.Height <= search.Height && CheckPixels(search.Clone(new Rectangle(x, y, find.Width, find.Height), search.PixelFormat), find)) {
                        positions.Add(new Point(x + scanPos.X, y + scanPos.Y));
                        found = true;
                    }
            }
        }

        return found;
    }

    public static bool FindOnScreen(Bitmap find, Rectangle scanPos) {
        Bitmap search = screen.Clone(scanPos, screen.PixelFormat);

        Color col = find.GetPixel(0, 0);

        for (int x = 0; x < search.Width; x++) {
            for (int y = 0; y < search.Height; y++) {
                if (search.GetPixel(x, y) == col)
                    if (x + find.Width <= search.Width && y + find.Height <= search.Height && CheckPixels(search.Clone(new Rectangle(x, y, find.Width, find.Height), search.PixelFormat), find)) {
                        return true;
                    }
            }
        }

        return false;
    }

    private static bool CheckPixels(Bitmap search, Bitmap find) {

        for (int x = 0; x < find.Width; x++) {
            for (int y = 0; y < find.Height; y++) {
                if (find.GetPixel(x, y) != search.GetPixel(x, y)) {
                    return false;
                }
            }
        }

        return true;
    }


}
