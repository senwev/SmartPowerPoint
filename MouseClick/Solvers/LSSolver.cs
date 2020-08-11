using LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseClick.Solvers
{
    public class LSSolver
    {

        public LSSolver(Matrix A)
        {
            Matrix At = A.Transpose();
            Matrix B = At * A;
            Matrix C = B.Inverse() * At;
            PreMatrix = C;
        }

        public Matrix PreMatrix { get; private set; }

        public double[] Calculate(double[] Y)
        {
            var row = this.PreMatrix.RowCount;
            var col = this.PreMatrix.ColumnCount;
            if (col != Y.Length)
            {
                throw new ArgumentException("参数维度与系数矩阵行数不一致");
            }
            double[] beta = new double[row];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    beta[i] += this.PreMatrix[i, j] * Y[j];
                }

            }
            return beta;
        }


    }
}
