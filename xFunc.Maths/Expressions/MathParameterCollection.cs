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
#if !PORTABLE
using System.Runtime.Serialization;
#endif

namespace xFunc.Maths.Expressions
{

#if !PORTABLE
    [Serializable]
#endif
    public class MathParameterCollection : Dictionary<string, double>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="MathParameterCollection"/> class.
        /// </summary>
        public MathParameterCollection()
        {
            Add("π", Math.PI);
            Add("e", Math.E);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MathParameterCollection"/> class.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        public MathParameterCollection(IDictionary<string, double> dictionary) : base(dictionary) { }

#if !PORTABLE
        /// <summary>
        /// Initializes a new instance of the <see cref="MathParameterCollection"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="context">The context.</param>
        protected MathParameterCollection(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif

    }

}