﻿// Copyright 2012 Dmitry Kischenko
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

namespace xFunc.Maths.Expressions
{
    
    public class SqrtMathExpression : UnaryMathExpression
    {

        public SqrtMathExpression() : base(null) { }

        public SqrtMathExpression(IMathExpression firstMathExpression) : base(firstMathExpression) { }

        public override string ToString()
        {
            return ToString("sqrt({0})");
        }

        public override double Calculate(MathParameterCollection parameters)
        {
            return Math.Sqrt(FirstMathExpression.Calculate(parameters));
        }

        protected override IMathExpression _Derivative(VariableMathExpression variable)
        {
            MultiplicationMathExpression mul = new MultiplicationMathExpression(new NumberMathExpression(2), this.Clone());
            DivisionMathExpression div = new DivisionMathExpression(firstMathExpression.Clone().Derivative(variable), mul);

            return div;
        }

        public override IMathExpression Clone()
        {
            return new SqrtMathExpression(firstMathExpression.Clone());
        }

    }

}