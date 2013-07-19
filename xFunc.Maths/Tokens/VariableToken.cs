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

    /// <summary>
    /// Represents a variable token.
    /// </summary>
    public class VariableToken : IToken
    {

        private string variable;

        /// <summary>
        /// Initializes the <see cref="VariableToken"/> class.
        /// </summary>
        /// <param name="variable">A name of variable.</param>
        public VariableToken(string variable)
        {
            this.variable = variable;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            VariableToken token = obj as VariableToken;
            if (token != null && this.Variable == token.Variable)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return "Variable: " + variable;
        }

        /// <summary>
        /// Gets a priority of current token.
        /// </summary>
        public int Priority
        {
            get
            {
                return 102;
            }
        }

        /// <summary>
        /// Gets a name of variable.
        /// </summary>
        public string Variable
        {
            get
            {
                return variable;
            }
        }

    }

}