﻿// Copyright 2012-2016 Dmitry Kischenko
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

namespace xFunc.Maths.Expressions.ComplexNumbers
{

    public class Re : UnaryExpression
    {

        internal Re() { }

        public Re(IExpression argument)
            : base(argument)
        {
        }

        public override int GetHashCode()
        {
            return base.GetHashCode(12829);
        }

        public override string ToString()
        {
            return base.ToString("re({0})");
        }

        public override object Execute(ExpressionParameters parameters)
        {
            return ((Complex)m_argument.Execute(parameters)).Real;
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>Returns the new instance of <see cref="IExpression"/> that is a clone of this instance.</returns>
        public override IExpression Clone()
        {
            return new Re(m_argument.Clone());
        }

        /// <summary>
        /// Gets the count of parameters.
        /// </summary>
        /// <value>
        /// The count of parameters.
        /// </value>
        public override ExpressionResultType ArgumentType
        {
            get
            {
                return ExpressionResultType.ComplexNumber;
            }
        }

        /// <summary>
        /// Gets the type of the result.
        /// </summary>
        /// <value>
        /// The type of the result.
        /// </value>
        public override ExpressionResultType ResultType
        {
            get
            {
                return ExpressionResultType.Number;
            }
        }

    }

}