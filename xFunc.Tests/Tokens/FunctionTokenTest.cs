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
using xFunc.Maths.Tokens;
using Xunit;

namespace xFunc.Tests.Tokens
{

    public class FunctionTokenTest
    {

        [Fact]
        public void EqualsNullTest()
        {
            var token = new FunctionToken(Functions.Sine, 1);

            Assert.False(token.Equals(null));
            Assert.NotEqual(null, token);
        }

        [Fact]
        public void EqualsSameObjectTest()
        {
            var token = new FunctionToken(Functions.Sine, 1);

            Assert.True(token.Equals(token));
            Assert.Equal(token, token);
        }

        [Fact]
        public void EqualsDiffTypeTest()
        {
            var token = new FunctionToken(Functions.Sine, 1);

            Assert.False(token.Equals(1));
            Assert.NotEqual((object)1, token);
        }

        [Fact]
        public void EqualsDiffFuncTest()
        {
            var token1 = new FunctionToken(Functions.Sine, 1);
            var token2 = new FunctionToken(Functions.Cosine, 1);

            Assert.False(token1.Equals(token2));
            Assert.NotEqual(token1, token2);
        }

        [Fact]
        public void ToStringTest()
        {
            var token = new FunctionToken(Functions.Sine, 1);

            Assert.Equal("Function: Sine (1)", token.ToString());
        }

    }

}
