var inputDirectory = Environment.CurrentDirectory;
var outputDirectory = Path.Combine(inputDirectory, "fashion-mnist");

var trainPrefix = "train";
var testPrefix = "t10k";
var imagesSuffix = "-images-idx3-ubyte";
var labelsSuffix = "-labels-idx1-ubyte";

var trainImagesPath = Path.Combine(inputDirectory, trainPrefix + imagesSuffix + "\\" + trainPrefix + imagesSuffix);
var trainLabelsPath = Path.Combine(inputDirectory, trainPrefix + labelsSuffix + "\\" + trainPrefix + labelsSuffix);

FashionMnistExporter.Export(trainImagesPath, trainLabelsPath, outputDirectory, trainPrefix);

var testImagesPath = Path.Combine(inputDirectory, testPrefix + imagesSuffix + "\\" + testPrefix + imagesSuffix);
var testLabelsPath = Path.Combine(inputDirectory, testPrefix + labelsSuffix + "\\" + testPrefix + labelsSuffix);

FashionMnistExporter.Export(testImagesPath, testLabelsPath, outputDirectory, testPrefix);