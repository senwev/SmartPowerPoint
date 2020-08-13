using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinearAlgebra.LinearEquations;
using LinearAlgebra;

namespace MouseClick.Solvers
{
    public class UWBPositionSolver3D
    {

        #region Property

        public Matrix CoeffMatrix
        {
            get;
            private set;
        }

        public double[] ConstantYVector
        {
            get;
            private set;
        }

        public double Coff_A { get; private set; }

        public double Coff_B { get; private set; }

        #endregion

        public UWBPositionSolver3D(IList<Tuple<double, double, double>> baseAnchors, double coff_a, double coff_b)
        {
            FormCoefficientMatrix(baseAnchors);
            FormConstantYVector(baseAnchors);
            Coff_A = coff_a;
            Coff_B = coff_b;
            this.solver = new LSSolver(CoeffMatrix);
        }

        private LSSolver solver;

        public IList<double> Update(IList<double> distances)
        {
            var Y = CalculateYVector(distances);
            var solution = solver.Calculate(Y);
            return solution;
        }

        #region Method

        private Matrix FormCoefficientMatrix(IList<Tuple<double, double, double>> baseStations)
        {
            if (baseStations == null || baseStations.Count == 0)
            {
                throw new ArgumentNullException(nameof(baseStations));
            }
            var elements = new double[baseStations.Count - 1, 3];
            var length = baseStations.Count - 1;
            var refStation = baseStations[baseStations.Count - 1];
            for (int i = 0; i < length; i++)
            {
                var currentStation = baseStations[i];
                elements[i, 0] = 2 * (refStation.Item1 - currentStation.Item1);
                elements[i, 1] = 2 * (refStation.Item2 - currentStation.Item2);
                elements[i, 2] = 2 * (refStation.Item3 - currentStation.Item3);
            }
            this.CoeffMatrix = new Matrix(elements);
            return this.CoeffMatrix;
        }

        private double[] CalculateYVector(IList<double> distances)
        {
            if (distances == null || distances.Count == 0)
            {
                throw new ArgumentNullException(nameof(distances));
            }
            if (distances.Count - 1 != ConstantYVector.Length)
            {
                throw new ArgumentException("参数维度不一致");
            }
            var length = distances.Count - 1;
            var refDistance = Coff_A * distances[length] + Coff_B;
            var refDistance2 = refDistance * refDistance;
            var Y = new double[length];
            for (int i = 0; i < length; i++)
            {
                var currentDistance = Coff_A * distances[i] + Coff_B;
                Y[i] = currentDistance * currentDistance - refDistance2 - ConstantYVector[i];
            }
            return Y;
        }

        private double[] FormConstantYVector(IList<Tuple<double, double, double>> baseStations)
        {
            if (baseStations == null || baseStations.Count == 0)
            {
                throw new ArgumentNullException(nameof(baseStations));
            }
            var length = baseStations.Count - 1;
            var Y = new double[length];
            var refStation = baseStations[baseStations.Count - 1];
            for (int i = 0; i < length; i++)
            {
                var currentStation = baseStations[i];
                Y[i] = currentStation.Item1 * currentStation.Item1 - refStation.Item1 * refStation.Item1 +
                    currentStation.Item2 * currentStation.Item2 - refStation.Item2 * refStation.Item2+
                    currentStation.Item3 * currentStation.Item3 - refStation.Item3 * refStation.Item3;
            }

            this.ConstantYVector = Y;
            return this.ConstantYVector;

        }

        #endregion
    }
}
