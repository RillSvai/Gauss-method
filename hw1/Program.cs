using GaussTask;

SquareMatrix matrix = new SquareMatrix(@"C:\Kiril\C#\num-methods\hw1\hw1\matrix.txt", 4);
Console.WriteLine($"=====Start matrix=====\n{matrix.ToString()}\n\n=====Transformed matrix=====\n");
double _determinate = matrix.ToTriangularForm();
if (_determinate == 0) 
{
    Console.WriteLine("Matrix is degenerated!");
    return;
} 
Console.WriteLine($"Determinate:\n{_determinate}\n");
matrix.FindJunctions();
Console.WriteLine(matrix.ToString());
matrix.CheckResult();