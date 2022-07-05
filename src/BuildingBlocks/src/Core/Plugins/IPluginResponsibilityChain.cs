using System;

namespace Orun.Plugins
{
    /// <summary>
    /// define the sync responsibility chain plugin
    /// </summary>
    public interface IPluginResponsibilityChain<TParameter, TReturn>
    {
        /// <summary>
        /// register a new plugin instance into the plugin chain
        /// </summary>
        PluginResponsibilityChain<TParameter, TReturn> Chain(object instance);

        /// <summary>
        /// execute the plugin chain
        /// </summary>
        TReturn Execute(TParameter parameter);

        /// <summary>
        /// method to execute after the chain has finnished
        /// </summary>
        PluginResponsibilityChain<TParameter, TReturn> Finally(Func<TParameter, TReturn> finallyFun);
    }
}