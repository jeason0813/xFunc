﻿// Copyright 2012-2017 Dmitry Kischenko
//
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either 
// express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License.
using System;
using System.Numerics;
using xFunc.Maths;
using xFunc.Maths.Expressions;
using xFunc.Maths.Expressions.ComplexNumbers;
using xFunc.Maths.Expressions.Hyperbolic;
using Xunit;

namespace xFunc.Tests.Expressionss.Hyperbolic
{

    public class HyperbolicArcotangentTest
    {

        [Fact]
        public void ExecuteTest()
        {
            var exp = new Arcoth(new Number(1));

            Assert.Equal(MathExtensions.Acoth(1), exp.Execute());
        }

        [Fact]
        public void ExecuteComplexNumberTest()
        {
            var complex = new Complex(3, 2);
            var exp = new Arcoth(new ComplexNumber(complex));
            var result = (Complex)exp.Execute();

            Assert.Equal(ComplexExtensions.Acoth(complex), result);
            Assert.Equal(0.2290726829685388, result.Real, 15);
            Assert.Equal(-0.16087527719832109, result.Imaginary, 15);
        }

        [Fact]
        public void CloneTest()
        {
            var exp = new Arcoth(new Number(1));
            var clone = exp.Clone();

            Assert.Equal(exp, clone);
        }

    }

}
