namespace FakeItEasy.Configuration
{
    using System;
    using System.Collections.Generic;
    using FakeItEasy.Core;

    internal class AnyCallConfiguration
        : IAnyCallConfigurationWithNoReturnTypeSpecified
    {
        private readonly IConfigurationFactory configurationFactory;
        private readonly AnyCallCallRule configuredRule;
        private readonly FakeManager manager;

        public AnyCallConfiguration(FakeManager manager, AnyCallCallRule configuredRule, IConfigurationFactory configurationFactory)
        {
            this.manager = manager;
            this.configuredRule = configuredRule;
            this.configurationFactory = configurationFactory;
        }

        private IVoidArgumentValidationConfiguration VoidConfiguration =>
            this.configurationFactory.CreateConfiguration(this.manager, this.configuredRule);

        public IAnyCallConfigurationWithReturnTypeSpecified<TMember> WithReturnType<TMember>()
        {
            this.configuredRule.ApplicableToMembersWithReturnType = typeof(TMember);
            return this.configurationFactory.CreateConfiguration<TMember>(this.manager, this.configuredRule);
        }

        public IAnyCallConfigurationWithReturnTypeSpecified<object> WithNonVoidReturnType()
        {
            this.configuredRule.ApplicableToAllNonVoidReturnTypes = true;
            return this.configurationFactory.CreateConfiguration<object>(this.manager, this.configuredRule);
        }

        public IAfterCallSpecifiedConfiguration<IVoidConfiguration> DoesNothing()
        {
            return this.VoidConfiguration.DoesNothing();
        }

        public IAfterCallSpecifiedConfiguration<IVoidConfiguration> Throws(Func<IFakeObjectCall, Exception> exceptionFactory)
        {
            return this.VoidConfiguration.Throws(exceptionFactory);
        }

        public IAfterCallSpecifiedConfiguration<IVoidConfiguration> Throws<T1>(Func<T1, Exception> exceptionFactory)
        {
            return this.Throws<IVoidConfiguration, T1>(exceptionFactory);
        }

        public IAfterCallSpecifiedConfiguration<IVoidConfiguration> Throws<T1, T2>(Func<T1, T2, Exception> exceptionFactory)
        {
            return this.Throws<IVoidConfiguration, T1, T2>(exceptionFactory);
        }

        public IAfterCallSpecifiedConfiguration<IVoidConfiguration> Throws<T1, T2, T3>(Func<T1, T2, T3, Exception> exceptionFactory)
        {
            return this.Throws<IVoidConfiguration, T1, T2, T3>(exceptionFactory);
        }

        public IAfterCallSpecifiedConfiguration<IVoidConfiguration> Throws<T1, T2, T3, T4>(Func<T1, T2, T3, T4, Exception> exceptionFactory)
        {
            return this.Throws<IVoidConfiguration, T1, T2, T3, T4>(exceptionFactory);
        }

        public IAfterCallSpecifiedConfiguration<IVoidConfiguration> Throws<T>() where T : Exception, new()
        {
            return this.Throws<IVoidConfiguration, T>();
        }

        public IVoidConfiguration Invokes(Action<IFakeObjectCall> action)
        {
            return this.VoidConfiguration.Invokes(action);
        }

        public IAfterCallSpecifiedConfiguration<IVoidConfiguration> CallsBaseMethod()
        {
            return this.VoidConfiguration.CallsBaseMethod();
        }

        public IAfterCallSpecifiedConfiguration<IVoidConfiguration> AssignsOutAndRefParametersLazily(Func<IFakeObjectCall, ICollection<object>> valueProducer)
        {
            return this.VoidConfiguration.AssignsOutAndRefParametersLazily(valueProducer);
        }

        public UnorderedCallAssertion MustHaveHappened(Repeated repeatConstraint)
        {
            return this.VoidConfiguration.MustHaveHappened(repeatConstraint);
        }

        public IAnyCallConfigurationWithNoReturnTypeSpecified Where(Func<IFakeObjectCall, bool> predicate, Action<IOutputWriter> descriptionWriter)
        {
            this.configuredRule.ApplyWherePredicate(predicate, descriptionWriter);
            return this;
        }

        public IVoidConfiguration WhenArgumentsMatch(Func<ArgumentCollection, bool> argumentsPredicate)
        {
            this.configuredRule.UsePredicateToValidateArguments(argumentsPredicate);
            return this;
        }
    }
}
