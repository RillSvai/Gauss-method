using GaussTask;

SquareMatrix matrix = new SquareMatrix(@"C:\Kiril\C#\num-methods\hw1\hw1\matrix.txt", 4);
Console.WriteLine($"=====Start matrix=====\n{matrix.ToString()}\n\n=====Transformed matrix=====\n");
double _determinate = matrix.ToTriangularForm();
Console.WriteLine(_determinate == 0 ? "Matrix is degenerate" : $"Determinate:\n{_determinate}\n");
matrix.FindJunctions();
Console.WriteLine(matrix.ToString());
matrix.CheckResult();