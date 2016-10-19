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
using xFunc.Maths.Expressions;
using xFunc.Maths.Expressions.Collections;
using Xunit;

namespace xFunc.Tests.Expressions.Maths
{

    public class DelegateExpressionTest
    {

        [Fact]
        public void ExecuteTest1()
        {
            var parameters = new ParameterCollection()
            {
                new Parameter("x", 10)
            };
            var func = new DelegateExpression(p => (double)p.Variables["x"] + 1);

            var result = func.Execute(parameters);

            Assert.Equal(11.0, result);
        }

        [Fact]
        public void ExecuteTest2()
        {
            var func = new DelegateExpression(p => 10.0);

            var result = func.Execute(null);

            Assert.Equal(10.0, result);
        }

        [Fact]
        public void ExecuteTest3()
        {
            var uf1 = new UserFunction("func", new[] { new Variable("x") }, 1);
            var func = new DelegateExpression(p => (double)p.Variables["x"] == 10 ? 0 : 1);
            var funcs = new FunctionCollection();
            funcs.Add(uf1, func);

            var uf2 = new UserFunction("func", new[] { new Number(12) }, 1);
            var result = uf2.Execute(new ExpressionParameters(funcs));

            Assert.Equal(1, result);
        }

        [Fact]
        public void ExecuteTest4()
        {
            var func = new DelegateExpression(p => 1.0);
            var result = func.Execute();

            Assert.Equal(1.0, result);
        }

        [Fact]
        public void CloneTest()
        {
            Assert.Throws<NotSupportedException>(() => new DelegateExpression(x => null).Clone());
        }

    }

}
