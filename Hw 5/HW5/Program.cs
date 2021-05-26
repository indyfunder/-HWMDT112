using System;

namespace HW5
{
    class Program
    {
        
        static double[,] ReadImageDataFromFile(string imageDataFilePath)
        {
            string[] lines = System.IO.File.ReadAllLines(imageDataFilePath);
            int imageHeight = lines.Length;
            int imageWidth = lines[0].Split(',').Length;
            double[,] imageDataArray = new double[imageHeight, imageWidth];

            for (int i = 0; i < imageHeight; i++)
            {
                string[] items = lines[i].Split(',');
                for (int j = 0; j < imageWidth; j++)
                {
                    imageDataArray[i, j] = double.Parse(items[j]);
                }
            }
            return imageDataArray;
        }

        static void WriteImageDataToFile(string imageDataFilePath,
                                 double[,] imageDataArray)
        {
            string imageDataString = "";
            for (int i = 0; i < imageDataArray.GetLength(0); i++)
            {
                for (int j = 0; j < imageDataArray.GetLength(1) - 1; j++)
                {
                    imageDataString += imageDataArray[i, j] + ", ";
                }
                imageDataString += imageDataArray[i,
                                                imageDataArray.GetLength(1) - 1];
                imageDataString += "\n";
            }

            System.IO.File.WriteAllText(imageDataFilePath, imageDataString);
        }

        static double[,] WriteArray(double[,] inputimageArray, int Collum, int Row, int ArrayCollum, int ArrayRow, int convoCollum, int convoRow)
        {
            double[,] infomationArray = new double[Collum, Row];
            for (int i = 0; i < Collum; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    infomationArray[i, j] = inputimageArray[(i + (ArrayCollum - 1)) % ArrayCollum, (j + (ArrayRow - 1)) % ArrayRow];
                }
            }
            return infomationArray;
        }

        static double[,] Convolution(double[,] informationArray, double[,] convoArray, int ArrayCollum, int ArrayRow)
        {
            double[,] outputArray = new double[ArrayCollum, ArrayRow];
            for (int i = 0; i < ArrayCollum; i++)
            {
                for (int j = 0; j < ArrayRow; j++)
                {
                    for (int k = 0; k < convoArray.GetLength(0); k++)
                    {
                        for (int l = 0; l < convoArray.GetLength(1); l++)
                        {
                            outputArray[i, j] += informationArray[i + k, j + l] * convoArray[k, l];
                        }
                    }

                }
            }
            return outputArray;
        }

        static void Main(string[] args)
        {
            string inputimage = Console.ReadLine();
            double[,] inputimageArray = ReadImageDataFromFile(inputimage);

            string convo = Console.ReadLine();
            ReadImageDataFromFile(convo);
            double[,] convoArray = ReadImageDataFromFile(convo);

            string output = Console.ReadLine();


            int imageArrayCollum = inputimageArray.GetLength(0) + convoArray.GetLength(0) - 1;
            int imageArrayRow = inputimageArray.GetLength(1) + convoArray.GetLength(1) - 1;


            double[,] informationArray = WriteArray(inputimageArray, imageArrayCollum, imageArrayRow, inputimageArray.GetLength(0), inputimageArray.GetLength(1),convoArray.GetLength(0),convoArray.GetLength(1));


            double[,] outputinformation = Convolution(informationArray, convoArray, inputimageArray.GetLength(0), inputimageArray.GetLength(1));


            WriteImageDataToFile(output, outputinformation);
        }

    }
}
