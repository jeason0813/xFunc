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

namespace xFunc.Maths.Tokens
{

    public class UserFunctionToken : IToken
    {

        private string function;
        private int countOfParams;

        public UserFunctionToken(string function) : this(function, -1) { }

        public UserFunctionToken(string function, int countOfParams)
        {
            this.function = function;
            this.countOfParams = countOfParams;
        }

        public override bool Equals(object obj)
        {
            UserFunctionToken token = obj as UserFunctionToken;
            if (token != null && this.Function == token.Function && this.countOfParams == token.CountOfParams)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return "User Function: " + function;
        }

        public int Priority
        {
            get
            {
                return 100;
            }
        }

        public string Function
        {
            get
            {
                return function;
            }
        }

        public int CountOfParams
        {
            get
            {
                return countOfParams;
            }
            set
            {
                countOfParams = value;
            }
        }

    }

}