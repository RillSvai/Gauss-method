using GaussTask;

SquareMatrix matrix = new SquareMatrix(@"C:\Kiril\C#\num-methods\hw1\hw1\matrix.txt", 3);
double _determinate = matrix.ToTriangularForm();
Console.WriteLine(_determinate == 0 ? "Matrix is degenerate" : $"Determinate:\n{_determinate}");
matrix.FindJunctions();
Console.WriteLine(matrix.ToString());