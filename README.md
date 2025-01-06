# fashion-mnist-dataset-export

Simple dotnet console app to export the fashion-mnist dataset. 
Loads data directly from `.gz` file and exports images to PNG and labels to TXT files.
Creates a unique png and text file for each example. 
The name of the images and labels follow the prefix name of the dataset (i.e. `train` or `t10k`).

## Running

To run, you have to have dotnet sdk 8 installed, which can be done by following the instructions [here](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

Once installed, open a terminal and change the directory:

```cmd
cd path/to/fashion-mnist-dataset-export
```

Finally, do:

```cmd
dotnet run
```

## Notes

The program expects the `.gz` files to be placed inside of the folder. After running the script, this will place all exported files into a folder called "fashion-mnist". Alternatively, you can specify the input/output directories by changing the first 2 lines in the `Program.cs` file.