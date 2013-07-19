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
using System.Collections.Generic;
using System.Globalization;
using xFunc.Maths;
using xFunc.Maths.Expressions;
using xFunc.Resources;

namespace xFunc.Presenters
{

    public class MathWorkspace
    {

        private MathParser parser;

        private int countOfExps;
        private List<MathWorkspaceItem> expressions;

        private NumeralSystem numberSystem;

        private MathParameterCollection parameters;
        private MathFunctionCollection functions;

        public MathWorkspace()
            : this(20)
        {

        }

        public MathWorkspace(int countOfExps)
        {
            this.countOfExps = countOfExps;
            expressions = new List<MathWorkspaceItem>(countOfExps);
            parser = new MathParser();
            parameters = new MathParameterCollection();
            functions = new MathFunctionCollection();
        }

        public void Add(string strExp)
        {
            if (string.IsNullOrWhiteSpace(strExp))
                throw new ArgumentNullException("strExp");

            string[] exps = strExp.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            while (expressions.Count + exps.Length > countOfExps)
                expressions.RemoveAt(0);

            foreach (var s in exps)
            {
                IMathExpression exp = parser.Parse(s);
                MathWorkspaceItem item = new MathWorkspaceItem(s, exp);
                if (exp is Derivative)
                {
                    item.Answer = parser.Differentiate(exp, null).ToString();
                }
                else if (exp is Simplify)
                {
                    var simp = exp as Simplify;

                    item.Answer = simp.FirstMathExpression.ToString();
                }
                else if (exp is Define)
                {
                    Define assign = exp as Define;
                    assign.Calculate(parameters, functions);
                    if (assign.Key is Variable)
                        item.Answer = string.Format(Resource.AssignVariable, assign.Key, assign.Value);
                    else if (assign.Key is UserFunction)
                        item.Answer = string.Format(Resource.AssignFunction, assign.Key, assign.Value);
                }
                else if (exp is Undefine)
                {
                    Undefine undef = exp as Undefine;
                    undef.Calculate(parameters, functions);
                    if (undef.Key is Variable)
                        item.Answer = string.Format(Resource.UndefineVariable, undef.Key);
                    else if (undef.Key is UserFunction)
                        item.Answer = string.Format(Resource.UndefineFunction, undef.Key);
                }
                else
                {
                    if (numberSystem == NumeralSystem.Decimal)
                        item.Answer = exp.Calculate(parameters, functions).ToString(CultureInfo.InvariantCulture);
                    else
                        item.Answer = MathExtentions.ToNewBase((int)exp.Calculate(parameters, functions), numberSystem);
                }

                expressions.Add(item);
            }
        }

        public void Clear()
        {
            expressions.Clear();
        }

        public void Remove(MathWorkspaceItem item)
        {
            expressions.Remove(item);
        }

        public void RemoveAt(int index)
        {
            expressions.RemoveAt(index);
        }

        public MathParser Parser
        {
            get
            {
                return parser;
            }
        }

        public int CountOfExpressions
        {
            get
            {
                return countOfExps;
            }
            set
            {
                countOfExps = value;
            }
        }

        public IEnumerable<MathWorkspaceItem> Expressions
        {
            get
            {
                return expressions.AsReadOnly();
            }
        }

        public NumeralSystem Base
        {
            get
            {
                return numberSystem;
            }
            set
            {
                numberSystem = value;
            }
        }

    }

}