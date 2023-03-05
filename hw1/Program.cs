using GaussTask;

SquareMatrix matrix = new SquareMatrix(@"C:\Kiril\C#\num-methods\hw1\hw1\matrix.txt", 3);
Console.WriteLine(matrix.ToTriangularForm());
Console.WriteLine(matrix.ToString());
matrix.FindJunctions();