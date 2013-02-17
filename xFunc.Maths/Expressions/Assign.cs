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

namespace xFunc.Maths.Expressions
{

    public class Assign : IMathExpression
    {

        private Variable variable;
        private IMathExpression value;

        public Assign()
            : this(null, null)
        {

        }

        public Assign(Variable variable, IMathExpression value)
        {
            this.variable = variable;
            this.value = value;
        }

        public override string ToString()
        {
            return string.Format("{0} := {1}", variable, value);
        }

        public double Calculate(MathParameterCollection parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException("parameters");

            parameters[variable.Character] = value.Calculate(parameters);

            return double.NaN;
        }

        public IMathExpression Differentiation()
        {
            throw new NotSupportedException();
        }

        public IMathExpression Differentiation(Variable variable)
        {
            throw new NotSupportedException();
        }

        public IMathExpression Clone()
        {
            return new Assign((Variable)variable.Clone(), value.Clone());
        }

        public Variable Variable
        {
            get
            {
                return variable;
            }
            set
            {
                variable = value;
            }
        }

        public IMathExpression Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }

        public IMathExpression Parent
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

    }

}