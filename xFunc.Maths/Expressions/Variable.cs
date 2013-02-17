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
    
    public class Variable : IMathExpression
    {

        private IMathExpression parentMathExpression;
        private char variable;

        public Variable(char variable)
        {
            this.variable = variable;
        }

        public static implicit operator char(Variable variable)
        {
            return variable.Character;
        }

        public static implicit operator Variable(char variable)
        {
            return new Variable(variable);
        }

        public override bool Equals(object obj)
        {
            Variable @var = obj as Variable;
            if (@var != null && @var.Character == variable)
                return true;

            return false;
        }

        public override string ToString()
        {
            return variable.ToString();
        }

        public double Calculate(MathParameterCollection parameters)
        {
            return parameters[variable];
        }

        public IMathExpression Clone()
        {
            return new Variable(variable);
        }

        public IMathExpression Differentiation()
        {
            return Differentiation(new Variable('x'));
        }

        public IMathExpression Differentiation(Variable variable)
        {
            if (Equals(variable))
                return new Number(1);

            return Clone();
        }

        public char Character
        {
            get
            {
                return variable;
            }
        }

        public IMathExpression Parent
        {
            get
            {
                return parentMathExpression;
            }
            set
            {
                parentMathExpression = value;
            }
        }

    }

}