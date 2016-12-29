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
using System.Linq;
using System.Text;
using xFunc.Maths.Analyzers;
using xFunc.Maths.Resources;

namespace xFunc.Maths.Expressions
{

    /// <summary>
    /// The base class for expressions with different number of parameters.
    /// </summary>
    public abstract class DifferentParametersExpression : IExpression
    {

        /// <summary>
        /// The parent expression of this expression.
        /// </summary>
        protected IExpression m_parent;
        /// <summary>
        /// The arguments.
        /// </summary>
        protected IExpression[] m_arguments;
        /// <summary>
        /// The count of parameters.
        /// </summary>
        protected int countOfParams;

        /// <summary>
        /// Initializes a new instance of the <see cref="DifferentParametersExpression"/> class.
        /// </summary>
        /// <param name="countOfParams">The count of parameters.</param>
        protected DifferentParametersExpression(int countOfParams)
            : this(null, countOfParams)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DifferentParametersExpression" /> class.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <param name="countOfParams">The count of parameters.</param>
        protected DifferentParametersExpression(IExpression[] arguments, int countOfParams)
        {
            this.countOfParams = countOfParams;
            this.Arguments = arguments;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj == null || this.GetType() != obj.GetType())
                return false;

            var diff = (DifferentParametersExpression)obj;

            if (this.m_arguments == null && diff.m_arguments == null)
                return true;

            if (this.m_arguments == null || diff.m_arguments == null ||
                this.m_arguments.Length != diff.m_arguments.Length)
                return false;

            return this.m_arguments.SequenceEqual(diff.m_arguments);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return GetHashCode(7951, 8807);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        protected int GetHashCode(int first, int second)
        {
            return m_arguments.Aggregate(first, (current, item) => current * second + item.GetHashCode());
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="function">The function.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        protected string ToString(string function)
        {
            var sb = new StringBuilder();

            sb.Append(function).Append('(');
            if (m_arguments != null)
            {
                foreach (var item in m_arguments)
                    sb.Append(item).Append(", ");
                sb.Remove(sb.Length - 2, 2);
            }
            sb.Append(')');

            return sb.ToString();
        }

        /// <summary>
        /// Executes this expression. Don't use this method if your expression has variables or user-functions.
        /// </summary>
        /// <returns>
        /// A result of the execution.
        /// </returns>
        public virtual object Execute()
        {
            return Execute(null);
        }

        /// <summary>
        /// Executes this expression.
        /// </summary>
        /// <param name="parameters">An object that contains all parameters and functions for expressions.</param>
        /// <returns>
        /// A result of the execution.
        /// </returns>
        /// <seealso cref="ExpressionParameters" />
        public abstract object Execute(ExpressionParameters parameters);

        /// <summary>
        /// Analyzes the current expression.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="analyzer">The analyzer.</param>
        /// <returns>
        /// The analysis result.
        /// </returns>
        public abstract TResult Analyze<TResult>(IAnalyzer<TResult> analyzer);

        /// <summary>
        /// Clones this instance of the <see cref="IExpression" />.
        /// </summary>
        /// <returns>
        /// Returns the new instance of <see cref="IExpression" /> that is a clone of this instance.
        /// </returns>
        public abstract IExpression Clone();

        /// <summary>
        /// Closes the arguments.
        /// </summary>
        /// <returns>The new array of <see cref="IExpression"/>.</returns>
        protected IExpression[] CloneArguments()
        {
            var args = new IExpression[m_arguments.Length];
            for (int i = 0; i < m_arguments.Length; i++)
                args[i] = m_arguments[i].Clone();

            return args;
        }

        /// <summary>
        /// Get or Set the parent expression.
        /// </summary>
        public IExpression Parent
        {
            get
            {
                return m_parent;
            }
            set
            {
                m_parent = value;
            }
        }

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        /// <value>The arguments.</value>
        public virtual IExpression[] Arguments
        {
            get
            {
                return m_arguments;
            }
            set
            {
                m_arguments = value;
                if (m_arguments != null)
                {
                    var types = ArgumentsTypes;
                    if (m_arguments.Length != types.Length)
                        throw new ArgumentException(Resource.InvalidExpression);

                    for (int i = 0; i < m_arguments.Length; i++)
                    {
                        var item = m_arguments[i];

                        if (item != null)
                        {
                            if ((types[i] & item.ResultType) == ExpressionResultType.None)
                                throw new ParameterTypeMismatchException(types[i], item.ResultType);

                            item.Parent = this;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the arguments types.
        /// </summary>
        /// <value>
        /// The arguments types.
        /// </value>
        public virtual ExpressionResultType[] ArgumentsTypes
        {
            get
            {
                var results = new ExpressionResultType[m_arguments?.Length ?? MinParameters];
                for (int i = 0; i < results.Length; i++)
                    results[i] = ExpressionResultType.All;

                return results;
            }
        }

        /// <summary>
        /// Gets the minimum count of parameters.
        /// </summary>
        /// <value>
        /// The minimum count of parameters.
        /// </value>
        public abstract int MinParameters { get; }

        /// <summary>
        /// Gets the maximum count of parameters. -1 - Infinity.
        /// </summary>
        /// <value>
        /// The maximum count of parameters.
        /// </value>
        public abstract int MaxParameters { get; }

        /// <summary>
        /// Gets or Sets the count of parameters.
        /// </summary>
        /// <value>
        /// The count of parameters.
        /// </value>
        public int ParametersCount
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

        /// <summary>
        /// Gets the type of the result.
        /// </summary>
        /// <value>
        /// The type of the result.
        /// </value>
        public virtual ExpressionResultType ResultType { get; } = ExpressionResultType.Number;

    }

}
