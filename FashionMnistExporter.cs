using System.Drawing;
using System.Drawing.Imaging;

public static class FashionMnistExporter
{
    public static void Export(string imagesPath, string labelsPath, string outputPath, string prefix, int take = int.MaxValue)
    {
        byte[] dataBytes = null;
        byte[] labelBytes = null;

        var count = -1;
        var height = 0;
        var width = 0;

        using (var file = File.Open(imagesPath, FileMode.Open, FileAccess.Read, FileShare.Read))
        using (var rdr = new BinaryReader(file)) {

            var reader = new BigEndianReader(rdr);
            var x = reader.ReadInt32(); // Magic number
            count = reader.ReadInt32();

            height = reader.ReadInt32();
            width = reader.ReadInt32();

            dataBytes = reader.ReadBytes(height * width * count);
        }

        using (var file = File.Open(labelsPath, FileMode.Open, FileAccess.Read, FileShare.Read))
        using (var rdr = new BinaryReader(file)) {

            var reader = new BigEndianReader(rdr);
            var x = reader.ReadInt32(); // Magic number
            var lblcnt = reader.ReadInt32();

            if (lblcnt != count) throw new InvalidDataException("Image data and label counts are different.");

            // Read all the data into memory.
            labelBytes = reader.ReadBytes(lblcnt);
        }

        var indices = Enumerable.Range(0, count).ToArray();
        var imgSize = height * width;

        for (var i = 0; i < count;) {
            Console.WriteLine($"Processing image {i}...");
            if (i >= take) break;

            var idx = indices[i++];
            var imgStart = idx * imgSize;

            var floats = dataBytes[imgStart.. (imgStart+imgSize)].Select(b => b/256.0f).ToArray();
            
            // Convert the float array to a Bitmap
            Bitmap bitmap = BitMapHelper.FloatArrayToBitmap(floats, height, width);

            // Save the Bitmap as a PNG image
            bitmap.Save($"{outputPath}\\{prefix}Image{i}.png", ImageFormat.Png);

            var label = labelBytes[idx];

            // Save the label as a text file
            File.WriteAllText($"{outputPath}\\{prefix}Label{i}.txt", label.ToString());
        }
    }
}