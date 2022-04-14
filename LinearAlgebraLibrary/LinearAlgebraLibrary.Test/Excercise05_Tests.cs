using System;
using LinearAlgebraLibrary.Exercise;
using NUnit.Framework;

namespace LinearAlgebraLibrary.Test
{
    public class Excercise05_Tests
    {
        [Test]
        public void Ex05_Task01_Constructors()
        {
            var matrix1 = LinearAlgebraFactory.MakeMatrix(4, 7);
            Assert.AreEqual(4, matrix1.Rows);
            Assert.AreEqual(7, matrix1.Cols);

            var source = new double[,] 
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9}
            };

            var matrix2 = LinearAlgebraFactory.MakeMatrix(source);
            Assert.AreEqual(3, matrix2.Rows);
            Assert.AreEqual(3, matrix2.Cols);
            Assert.True(matrix2.IsSquare);
        }

        [Test]
        public void Ex05_Task01_Constructors_EdgeCase()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => LinearAlgebraFactory.MakeMatrix(-1, 2));
            Assert.Throws<ArgumentOutOfRangeException>(() => LinearAlgebraFactory.MakeMatrix(-1, -2));
            Assert.Throws<ArgumentOutOfRangeException>(() => LinearAlgebraFactory.MakeMatrix(1, -2));
            Assert.Throws<ArgumentOutOfRangeException>(() => LinearAlgebraFactory.MakeMatrix(0, 0));
        }

        [Test]
        public void Ex05_Task02_ComponentAccess()
        {
            var matrix1 = LinearAlgebraFactory.MakeMatrix(4, 7);
            AssertionTools.AssertSingleValue(0, matrix1);

            var source = new double[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9},
                { 4, 1, 6}
            };

            var matrix2 = LinearAlgebraFactory.MakeMatrix(source);
            Assert.True(matrix2.IsSquare);
            AssertionTools.AssertMatrix(source, matrix2);
        }

        [Test]
        public void Ex05_Task03_TransposeMatrix()
        {
            var matrix = LinearAlgebraFactory.MakeMatrix(new double[,]
            {
                { 3, 6, 1},
                { 2, 1, 0}
            });
            Assert.AreEqual(2, matrix.Rows);
            Assert.AreEqual(3, matrix.Cols);

            var transposed = matrix.T;
            Assert.AreEqual(3, transposed.Rows);
            Assert.AreEqual(2, transposed.Cols);
            AssertionTools.AssertMatrix(new double[,]
            {
                {3, 2},
                {1, 6},
                {1, 0}
            }, transposed);
            AssertionTools.AssertDistinctInstances(matrix, transposed);
        }

        [Test]
        public void Ex05_Task04_Adding()
        {
            var m1 = LinearAlgebraFactory.MakeMatrix(new double[,]
            {
                { 1, 2, -4, 5 },
                { 0, -5, 5, 1 },
                { 1, 1, -1, 0 }
            });

            var m2 = LinearAlgebraFactory.MakeMatrix(new double[,]
            {
                { 10, -12, 5, 7 },
                { 7, 4, -5, 3 },
                { 2, 1, 2, 1 }
            });

            var m3 = m1.Add(m2);
            AssertionTools.AssertMatrix(new double[,]
            {
                { 11, -10, 1, 12 },
                { 7, -1, 0, 4 },
                { 3, 2, 1, 1 }
            }, m3);
            AssertionTools.AssertDistinctInstances(m1, m3);
            AssertionTools.AssertDistinctInstances(m2, m3);

            var m4 = m1.Add(m2).Add(m1);
            AssertionTools.AssertMatrix(new double[,]
            {
                { 12, -8, -3, 17 },
                { 7, -6, 5, 5 },
                { 4, 3, 0, 1 }
            }, m4);
        }

        [Test]
        public void Ex05_Task04_Adding_EdgeCases()
        {
            var m1 = LinearAlgebraFactory.MakeMatrix(new double[,]
            {
                { 1, 2, -4, 5 },
                { 0, -5, 5, 1 },
                { 1, 1, -1, 0 }
            });

            var m2 = LinearAlgebraFactory.MakeMatrix(new double[,]
            {
                { 10, -12, 5, 7 },
                { 7, 4, -5, 3 }
            });

            var m3 = LinearAlgebraFactory.MakeMatrix(new double[,]
            {
                { 10, -12, 5},
                { 7, 4, -5},
                { 2, 1, 2}
            });

            Assert.Throws<ArgumentException>(() => m1.Add(m2));
            Assert.Throws<ArgumentException>(() => m1.Add(m3));
        }

        [Test]
        public void Ex05_Task04_Subtraction()
        {
            var m1 = LinearAlgebraFactory.MakeMatrix(new double[,]
            {
                { 1, 2, -4, 5 },
                { 0, -5, 5, 1 },
                { 1, 1, -1, 0 }
            });

            var m2 = LinearAlgebraFactory.MakeMatrix(new double[,]
            {
                { 10, -12, 5, 7 },
                { 7, 4, -5, 3 },
                { 2, 1, 2, 1 }
            });

            var m3 = m1.Subtract(m2);
            AssertionTools.AssertMatrix(new double[,]
            {
                { -9, 14, -9, -2 },
                { -7, -9, 10, -2 },
                { -1, 0, -3, -1 }
            }, m3);
            AssertionTools.AssertDistinctInstances(m1, m3);
            AssertionTools.AssertDistinctInstances(m2, m3);

            var m4 = m1.Subtract(m2).Subtract(m1);
            AssertionTools.AssertMatrix(new double[,]
            {
                { -10, 12, -5, -7 },
                { -7, -4, 5, -3 },
                { -2, -1, -2, -1 }
            }, m4);
        }

        [Test]
        public void Ex05_Task04_Subtraction_EdgeCases()
        {
            var m1 = LinearAlgebraFactory.MakeMatrix(new double[,]
            {
                { 1, 2, -4, 5 },
                { 0, -5, 5, 1 },
                { 1, 1, -1, 0 }
            });

            var m2 = LinearAlgebraFactory.MakeMatrix(new double[,]
            {
                { 10, -12, 5, 7 },
                { 7, 4, -5, 3 }
            });

            var m3 = LinearAlgebraFactory.MakeMatrix(new double[,]
            {
                { 10, -12, 5},
                { 7, 4, -5},
                { 2, 1, 2}
            });

            Assert.Throws<ArgumentException>(() => m1.Subtract(m2));
            Assert.Throws<ArgumentException>(() => m1.Subtract(m3));
        }

        [Test]
        public void Ex05_Task05_ScalarMultiplication()
        {
            var m1 = LinearAlgebraFactory.MakeMatrix(new double[,]
            {
                { 1, 2, -4, 5 },
                { 0, -5, 5, 1 },
                { 1, 1, -1, 0 }
            });

            var m2 = LinearAlgebraFactory.MakeMatrix(new double[,]
            {
                { 10, -12, 5, 7 },
                { 7, 4, -5, 3 }
            });

            var m3 = m1.Multiply(2.5);
            AssertionTools.AssertMatrix(new[,]
            {
                { 2.5, 5, -10, 12.5 },
                { 0, -12.5, 12.5, 2.5 },
                { 2.5, 2.5, -2.5, 0 }
            }, m3);
            AssertionTools.AssertDistinctInstances(m1, m3);

            var m4 = m2.Multiply(2.5);
            AssertionTools.AssertMatrix(new[,]
            {
                { -41, 49.2, -20.5, -28.7 },
                { -28.7, -16.4, 20.5, -12.3 }
            }, m4);

            var m5 = m1.Multiply(2).Multiply(0.5);
            AssertionTools.AssertMatrix(m1, m5);
        }

        [Test]
        public void Ex05_Task06_IdentityCreation()
        {
            var m1 = Matrix.CreateIdentityMatrix(2);
            AssertionTools.AssertMatrix(new double[,]
            {
                { 1, 0 },
                { 0, 1 }
            }, m1);

            var m2 = Matrix.CreateIdentityMatrix(3);
            AssertionTools.AssertMatrix(new double[,]
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1}
            }, m2);

            var m3 = Matrix.CreateIdentityMatrix(4);
            AssertionTools.AssertMatrix(new double[,]
            {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 }
            }, m3);
        }

        [Test]
        public void Ex05_Task06_IdentityCreation_EdgeCases()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Matrix.CreateIdentityMatrix(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => Matrix.CreateIdentityMatrix(-1));
        }

        [Test]
        public void Ex05_Task07_HStack()
        {
            var m1 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                { 1, 0.5, 1, 6 },
                { 2, 0.5, 1, 0.6 },
                { 3, 1.5, 2, 3 },
            });
            var m2 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                { 0.6, 2, 4 },
                { 0.1, 1, 1.6 },
                { 1.3, 7, 3 },
            });

            var m3 = m1.HStack(m2);
            var m4 = m2.HStack(m1);
            var m5 = m2.HStack(m1).HStack(m2);

            AssertionTools.AssertMatrix(new [,]
            {
                { 1, 0.5, 1, 6, 0.6, 2, 4 },
                { 2, 0.5, 1, 0.6, 0.1, 1, 1.6 },
                { 3, 1.5, 2, 3, 1.3, 7, 3 }
            }, m3);

            AssertionTools.AssertMatrix(new[,]
            {
                { 0.6, 2, 4, 1, 0.5, 1, 6 },
                { 0.1, 1, 1.6, 2, 0.5, 1, 0.6 },
                { 1.3, 7, 3, 3, 1.5, 2, 3 }
            }, m4);

            AssertionTools.AssertMatrix(new[,]
            {
                { 0.6, 2, 4, 1, 0.5, 1, 6, 0.6, 2, 4 },
                { 0.1, 1, 1.6, 2, 0.5, 1, 0.6, 0.1, 1, 1.6 },
                { 1.3, 7, 3, 3, 1.5, 2, 3, 1.3, 7, 3 }
            }, m5);

            AssertionTools.AssertDistinctInstances(m1, m3);
            AssertionTools.AssertDistinctInstances(m2, m3);
        }

        [Test]
        public void Ex05_Task07_HStack_EdgeCases()
        {
            var m1 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                { 1, 0.5, 1, 6 },
                { 2, 0.5, 1, 0.6 },
                { 3, 1.5, 2, 3 }
            });

            var m2 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                { 4, 4.4, 6, 1.2 },
                { 5, 1.4, 7, 8.3 },
                { 6, 6.1, 6, 0 },
                { 7, 3.6, 3, 6 },
                { 8, 7.2, 3, 0 }
            });

            Assert.Throws<ArgumentException>(() => m1.HStack(m2));
        }

        [Test]
        public void Ex05_Task08_VStack()
        {
            var m1 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                { 1, 0.5, 1, 6 },
                { 2, 0.5, 1, 0.6 },
                { 3, 1.5, 2, 3 }
            });

            var m2 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                { 4, 4.4, 6, 1.2 },
                { 5, 1.4, 7, 8.3 },
                { 6, 6.1, 6, 0 },
                { 7, 3.6, 3, 6 },
                { 8, 7.2, 3, 0 }
            });

            var m3 = m1.VStack(m2);
            var m4 = m2.VStack(m1);
            var m5 = m1.VStack(m2).VStack(m1);

            AssertionTools.AssertMatrix(new[,]
            {
                { 1, 0.5, 1, 6 },
                { 2, 0.5, 1, 0.6 },
                { 3, 1.5, 2, 3 },
                { 4, 4.4, 6, 1.2 },
                { 5, 1.4, 7, 8.3 },
                { 6, 6.1, 6, 0 },
                { 7, 3.6, 3, 6 },
                { 8, 7.2, 3, 0 }
            }, m3);
            AssertionTools.AssertMatrix(new[,]
            {
                { 4, 4.4, 6, 1.2 },
                { 5, 1.4, 7, 8.3 },
                { 6, 6.1, 6, 0 },
                { 7, 3.6, 3, 6 },
                { 8, 7.2, 3, 0 },
                { 1, 0.5, 1, 6 },
                { 2, 0.5, 1, 0.6 },
                { 3, 1.5, 2, 3 }
            }, m4);
            AssertionTools.AssertMatrix(new[,]
            {
                { 1, 0.5, 1, 6 },
                { 2, 0.5, 1, 0.6 },
                { 3, 1.5, 2, 3 },
                { 4, 4.4, 6, 1.2 },
                { 5, 1.4, 7, 8.3 },
                { 6, 6.1, 6, 0 },
                { 7, 3.6, 3, 6 },
                { 8, 7.2, 3, 0 },
                { 1, 0.5, 1, 6 },
                { 2, 0.5, 1, 0.6 },
                { 3, 1.5, 2, 3 }
            }, m5);
            AssertionTools.AssertDistinctInstances(m1, m3);
            AssertionTools.AssertDistinctInstances(m2, m3);
        }

        [Test]
        public void Ex05_Task08_VStack_EdgeCases()
        {
            var m1 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                { 1, 0.5, 1, 6 },
                { 2, 0.5, 1, 0.6 },
                { 3, 1.5, 2, 3 },
            });
            var m2 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                { 0.6, 2, 4 },
                { 0.1, 1, 1.6 },
                { 1.3, 7, 3 },
            });

            Assert.Throws<ArgumentException>(() => m1.VStack(m2));
        }

        [Test]
        public void Ex05_Task09_SubMatrix()
        {
            var m1 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                { 4, 4.4, 6, 1.2 },
                { 5, 1.4, 7, 8.3 },
                { 6, 6.1, 6, 0 },
                { 7, 3.6, 3, 6 },
                { 8, 7.2, 3, 0 }
            });

            AssertionTools.AssertMatrix(new[,]
            {
                { 4, 4.4 },
                { 5, 1.4 },
                { 6, 6.1 }
            }, m1.SubMatrix(0, 3, 0, 2));

            AssertionTools.AssertMatrix(new[,]
            {
                { 7, 8.3 },
                { 6, 0 },
                { 3, 6 },
                { 3, 0 }
            }, m1.SubMatrix(1, 4, 2, 2));

            AssertionTools.AssertMatrix(new[,]
            {
                { 3.6, 3 },
                { 7.2, 3 }
            }, m1.SubMatrix(3, 2, 1, 2));

            AssertionTools.AssertMatrix(m1, m1.SubMatrix(0, 5, 0, 4));
        }

        [Test]
        public void Ex05_Task09_SubMatrix_EdgeCases()
        {
            var m1 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                { 4, 4.4, 6, 1.2 },
                { 5, 1.4, 7, 8.3 },
                { 6, 6.1, 6, 0 },
                { 7, 3.6, 3, 6 },
                { 8, 7.2, 3, 0 }
            });

            Assert.Throws<ArgumentOutOfRangeException>(() => m1.SubMatrix(-1, 1, 1, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => m1.SubMatrix(1, -1, 1, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => m1.SubMatrix(-1, -1, 1, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => m1.SubMatrix(1, 1, 4, 6));
            Assert.Throws<ArgumentOutOfRangeException>(() => m1.SubMatrix(1, 1, 5, 2));
            Assert.Throws<ArgumentOutOfRangeException>(() => m1.SubMatrix(1, 1, 5, 4));
        }

        [Test]
        public void Ex05_Task10_MatrixMultiplication()
        {
            var m1 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                {0, 3.1, 5, 1},
                {2, 6, 6.2, 1},
                {1, 5.1, 7, 0}
            });
            var m2 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                { 0.1, 8, 9, 1, 0, 4},
                { 2.2, 1, 1, 1, 7, 1},
                { 5, 5, 5, -7, 0, 8},
                { 4, -2, 5, 7, 1, -1}
            });

            var m3 = m1.Multiply(m2);
            AssertionTools.AssertMatrix(new [,]
            {
                {35.82,  26.1 ,  33.1 , -24.9 ,  22.7 ,  42.1 },
                { 48.4 ,  51,  60, -28.4 ,  43,  62.6 },
                { 46.32,  48.1 ,  49.1 , -42.9 ,  35.7 ,  65.1 }
            }, m3);
            AssertionTools.AssertDistinctInstances(m1, m3);
            AssertionTools.AssertDistinctInstances(m2, m3);

            var m4 = m2.Multiply(m3.T);
            AssertionTools.AssertMatrix(new[,]
            {
                { 653.782, 1174.84 , 1048.832},
                { 314.104,  552.68 ,  471.204},
                { 986.2  , 1496.6  , 1538.7  },
                {  62.88 ,  173.2  ,    4.88 }
            }, m4);
        }

        [Test]
        public void Ex05_Task10_MatrixMultiplication_EdgeCases()
        {
            var m1 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                {0, 3.1, 5, 1},
                {2, 6, 6.2, 1},
                {1, 5.1, 7, 0}
            });
            var m2 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                { 0.1, 8, 9, 1, 0, 4},
                { 2.2, 1, 1, 1, 7, 1},
                { 5, 5, 5, -7, 0, 8},
                { 4, -2, 5, 7, 1, -1}
            });

            var m3 = m1.Multiply(m2);
            AssertionTools.AssertMatrix(new[,]
            {
                {35.82,  26.1 ,  33.1 , -24.9 ,  22.7 ,  42.1 },
                { 48.4 ,  51,  60, -28.4 ,  43,  62.6 },
                { 46.32,  48.1 ,  49.1 , -42.9 ,  35.7 ,  65.1 }
            }, m3);

            Assert.Throws<ArgumentException>(() => m2.Multiply(m1));
        }

        [Test]
        public void Ex05_Task11_VectorMultiplication()
        {
            const double eps = 1e-13;
            var m1 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                {0, 3.1, 5, 1},
                {2, 6, 6.2, 1},
                {1, 5.1, 7, 0}
            });
            var m2 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                { 0.1, 8, 9, 1, 0, 4},
                { 2.2, 1, 1, 1, 7, 1},
                { 5, 5, 5, -7, 0, 8},
                { 4, -2, 5, 7, 1, -1}
            });
            var m3 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                {0, 3.1, 5},
                {2, 6, 6.2},
                {1, 5.1, 7}
            });
            var m4 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                {0, 3.1},
                {2, 6},
                {1, 5.1}
            });

            var v1 = LinearAlgebraFactory.MakeVector(1, 3, 8, 1);
            var v2 = LinearAlgebraFactory.MakeVector(1, 3, 8, 1, 0, 1);
            var v3 = LinearAlgebraFactory.MakeVector3(1, 3, 1);
            var v4 = LinearAlgebraFactory.MakeVector2(-2, 5);

            var v11 = m1.Multiply(v1);
            var v21 = m2.Multiply(v2);
            var v31 = m3.Multiply(v3);
            var v41 = m4.Multiply(v4);

            AssertionTools.AssertDistinctInstances(v1, v11);
            AssertionTools.AssertDistinctInstances(v2, v21);
            AssertionTools.AssertDistinctInstances(v3, v31);
            AssertionTools.AssertDistinctInstances(v4, v41);

            AssertionTools.AssertVector(eps, v11, 50.3, 70.6, 72.3);
            AssertionTools.AssertVector(eps, v21, 101.1, 15.2, 61, 44);
            AssertionTools.AssertVector(eps, v31, 14.3, 26.2, 23.3);
            AssertionTools.AssertVector(eps, v41, 15.5, 26, 23.5);
        }

        [Test]
        public void Ex05_Task11_VectorMultiplication_EdgeCases()
        {
            var m1 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                {0, 3.1, 5, 1},
                {2, 6, 6.2, 1},
                {1, 5.1, 7, 0}
            });
            var m2 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                { 0.1, 8, 9, 1, 0, 4},
                { 2.2, 1, 1, 1, 7, 1},
                { 5, 5, 5, -7, 0, 8},
                { 4, -2, -1.1, 7, 1, -1}
            });
            var m3 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                {0, 3.1, 5},
                {2, 6, 6.2},
                {1, 5.1, 7}
            });
            var m4 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                {0, 3.1},
                {2, 6},
                {1, 5.1}
            });

            var v1 = LinearAlgebraFactory.MakeVector(1, 3, 8, 1);
            var v2 = LinearAlgebraFactory.MakeVector(1, 3, 8, 1, 0, 1);
            var v3 = LinearAlgebraFactory.MakeVector3(1, 3, 1);
            var v4 = LinearAlgebraFactory.MakeVector2(-2, 5);

            Assert.Throws<ArgumentException>(() => m4.Multiply(v1));
            Assert.Throws<ArgumentException>(() => m3.Multiply(v2));
            Assert.Throws<ArgumentException>(() => m2.Multiply(v3));
            Assert.Throws<ArgumentException>(() => m1.Multiply(v4));
        }

        [Test]
        public void Ex05_Task12_MatrixDeterminant()
        {
            const double eps = 1e-10;
            var m1 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                {0, 3.1, 5, 1},
                {2, 6, 6.2, 1},
                {1, 5.1, 7, 0}
            });
            var m2 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                { 0.1, 8, 9, 1, 0, 4},
                { 2.2, 1, 1, 1, 7, 1},
                { 5, 5, 5, -7, 0, 8},
                { 4, -2, -1.1, 7, 1, -1},
                { -3, -2, 3, 6, 2, 2},
                { 7, 0, 1, -4.2, 7, 9}
            });
            var m3 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                {0, 3.1, 5},
                {2, 6, 6.2},
                {1, 5.1, 7}
            });
            var m4 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                {0, 3.1},
                {2, 6},
                {1, 5.1}
            });
            var m5 = LinearAlgebraFactory.MakeMatrix(new[,]
            {
                { 1.0, 2.0, 2.0 },
                { 1.0, 2.0, 2.0 },
                { 3.0, 2.0, -1.0 },
            });

            Assert.AreEqual(double.NaN, m1.Determinant);
            Assert.AreEqual(-30624.29599999997, m2.Determinant, eps);
            Assert.AreEqual(-3.1800000000000037, m3.Determinant, eps);
            Assert.AreEqual(double.NaN, m4.Determinant);
            Assert.AreEqual(0, m5.Determinant, eps);
            Assert.False(m1.IsSingular);
            Assert.False(m2.IsSingular);
            Assert.False(m3.IsSingular);
            Assert.False(m4.IsSingular);
            Assert.True(m5.IsSingular);
        }
    }
}
