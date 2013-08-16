﻿// Copyright 2012-2013 Dmitry Kischenko
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

namespace xFunc.Maths.Expressions.Trigonometric
{

    /// <summary>
    /// Represents the Cosecant function.
    /// </summary>
    public class Csc : TrigonometryMathExpression
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Csc"/> class.
        /// </summary>
        public Csc()
            : base(null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Csc"/> class.
        /// </summary>
        /// <param name="firstMathExpression">The argument of function.</param>
        public Csc(IMathExpression firstMathExpression)
            : base(firstMathExpression)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Csc"/> class.
        /// </summary>
        /// <param name="firstMathExpression">The argument of function.</param>
        /// <param name="angleMeasurement">The angle measurement.</param>
        public Csc(IMathExpression firstMathExpression, AngleMeasurement angleMeasurement) : base(firstMathExpression, angleMeasurement) { }

        /// <summary>
        /// Converts this expression to the equivalent string.
        /// </summary>
        /// <returns>The string that represents this expression.</returns>
        public override string ToString()
        {
            return ToString("csc({0})");
        }

        protected override double CalculateDergee(MathParameterCollection parameters, MathFunctionCollection functions)
        {
            var radian = argument.Calculate(parameters, functions) * Math.PI / 180;

            return MathExtentions.Csc(radian);
        }

        protected override double CalculateRadian(MathParameterCollection parameters, MathFunctionCollection functions)
        {
            return MathExtentions.Csc(argument.Calculate(parameters, functions));
        }

        protected override double CalculateGradian(MathParameterCollection parameters, MathFunctionCollection functions)
        {
            var radian = argument.Calculate(parameters, functions) * Math.PI / 200;

            return MathExtentions.Csc(radian);
        }

        protected override IMathExpression _Differentiation(Variable variable)
        {
            var unary = new UnaryMinus(argument.Clone().Differentiate(variable));
            var cot = new Cot(argument.Clone(), angleMeasurement);
            var csc = new Csc(argument.Clone(), angleMeasurement);
            var mul1 = new Mul(cot, csc);
            var mul2 = new Mul(unary, mul1);

            return mul2;
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>The new instance of <see cref="IMathExpression"/> that is a clone of this instance.</returns>
        public override IMathExpression Clone()
        {
            return new Csc(argument.Clone());
        }

    }

}
