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
using xFunc.Maths.Expressions;
using xFunc.Maths.Expressions.LogicalAndBitwise;
using Xunit;

namespace xFunc.Tests.Expressionss.LogicalAndBitwise
{

    public class EqualityTest
    {

        [Fact]
        public void ExecuteTest1()
        {
            var eq = new Equality(new Bool(true), new Bool(true));

            Assert.Equal(true, eq.Execute());
        }

        [Fact]
        public void ExecuteTest2()
        {
            var eq = new Equality(new Bool(true), new Bool(false));

            Assert.Equal(false, eq.Execute());
        }

        [Fact]
        public void CloneTest()
        {
            var exp = new Equality(new Bool(true), new Bool(false));
            var clone = exp.Clone();

            Assert.Equal(exp, clone);
        }

    }

}
