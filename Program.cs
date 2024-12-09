var downloadPath = "C:\\Users\\ncgui\\Downloads\\";
var outputPath = "C:\\Users\\ncgui\\Desktop\\machinelearning\\docs\\examples\\datasets\\fashion-mnist";

var trainPrefix = "train";
var testPrefix = "t10k";
var imagesSuffix = "-images-idx3-ubyte";
var labelsSuffix = "-labels-idx1-ubyte";

var trainImagesPath = Path.Combine(downloadPath, trainPrefix + imagesSuffix + "\\" + trainPrefix + imagesSuffix);
var trainLabelsPath = Path.Combine(downloadPath, trainPrefix + labelsSuffix + "\\" + trainPrefix + labelsSuffix);

FashionMnistExporter.Export(trainImagesPath, trainLabelsPath, outputPath, trainPrefix);

var testImagesPath = Path.Combine(downloadPath, testPrefix + imagesSuffix + "\\" + testPrefix + imagesSuffix);
var testLabelsPath = Path.Combine(downloadPath, testPrefix + labelsSuffix + "\\" + testPrefix + labelsSuffix);

FashionMnistExporter.Export(testImagesPath, testLabelsPath, outputPath, testPrefix);