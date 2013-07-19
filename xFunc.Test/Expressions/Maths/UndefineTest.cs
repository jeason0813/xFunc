﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xFunc.Maths.Expressions;
using System.Collections.Generic;

namespace xFunc.Test.Expressions.Maths
{

    [TestClass]
    public class UndefineTest
    {

        [TestMethod]
        public void UndefVarTest()
        {
            MathParameterCollection parameters = new MathParameterCollection();
            parameters.Add("a", 1);

            var undef = new Undefine(new Variable("a"));
            undef.Calculate(parameters);
            Assert.IsFalse(parameters.ContainsKey("a"));
        }

        [TestMethod]
        public void UndefFuncTest()
        {
            var key1 = new UserFunction("f", 0);
            var key2 = new UserFunction("f", 1);

            MathFunctionCollection functions = new MathFunctionCollection();
            functions.Add(key1, new Number(1));
            functions.Add(key2, new Number(2));

            var undef = new Undefine(key1);
            undef.Calculate(null, functions);
            Assert.IsFalse(functions.ContainsKey(key1));
            Assert.IsTrue(functions.ContainsKey(key2));
        }

    }

}