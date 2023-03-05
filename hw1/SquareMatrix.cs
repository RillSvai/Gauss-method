using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics.Metrics;

namespace GaussTask
{
    internal class SquareMatrix
    {
        private const double c_zeroValue = 0.000001;
        private double [][] _content;
        private double[] _junctions;
        public double [][] Content => _content;
        public SquareMatrix(int n) 
        {
            _content = new double[n][];
            for (int i = 0; i < n;++i) _content[i] = new double[n+1];
            _junctions = new double[n];
        }
        public SquareMatrix(string? pathMatrix, int n) : this(n) 
        {
            if (pathMatrix == null) throw new ArgumentNullException("The path isn`t specified!");
            _content = File.ReadAllLines(pathMatrix).Select(l=>l.Split(' ').Select(str => double.Parse(str)).ToArray()).ToArray();
        }
        public int Rows => _content.Length;
        public double this[int i,int j]
        {
            get => _content[i][j];
            set => _content[i][j] = value;
        }
        public override string ToString() => string.Join("\n", Enumerable.Range(0, Rows).
            Select(j => RowToString(j))) +
            $"\nVector:\n{string.Join(" ",Enumerable.Range(0, Rows).Select(j => this[j,Rows]))}"+
            $"\nAnswers:\n{string.Join(" ",_junctions.Select(j => j))}";
        private string RowToString(int i) => string.Join(" ", Enumerable.Range(0, Rows).
            Select(j => this[i, j]));

        public void FindJunctions()
        {
            double substractor=0;
            for (int i = Rows - 1;i >= 0; --i)
            {
                for (int j = Rows - 1;j >= 0; j--)
                {
                    if (j!=i)
                    substractor -=_content[i][j] * _junctions[j];
                }
                _junctions[i] = (_content[i][Rows]+substractor)/_content[i][i];
                substractor = 0;
            }
        }
        public double ToTriangularForm()
        {
            double key = 0, swaps = 0;
            for (int i = 0; i < Rows - 1; i++)
            {
                key = MaxElemColumn(i);
                if (Math.Abs(key) < c_zeroValue) return 0.0;
                if (_content[i][i] != key)
                {
                    SwapRows(key, i);
                    swaps++;
                }
                for (int j = i + 1; j < Rows; ++j)
                {
                     List<double> row = Enumerable.Range(i,Rows+1-i).Select(k => (_content[j][k]) - (_content[j][i] / key) * _content[i][k]).ToList();
                     row.InsertRange(0, new double[i]);
                    _content[j] = row.ToArray();

                }
            }
            return (Enumerable.Range(0, Rows).Select(i => _content[i][i]).Aggregate((x, y) => x * y)) * Math.Pow(-1, swaps);

        }
        public void SwapRows (double key,int position) 
        {
            int keyRow = Enumerable.Range(position, Rows - position).First(i => _content[i][position]==key);
            double[] temp = new double[Rows];
            temp = _content[position];
            _content[position] = _content[keyRow];
            _content[keyRow] = temp;
        }
        public double MaxElemColumn(int start) => Enumerable.Range(start, Rows - start).
            Select(j => _content[j][start]).Max();

    }
}
