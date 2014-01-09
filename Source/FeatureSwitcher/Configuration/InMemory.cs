using System;
using System.Collections.Generic;

namespace FeatureSwitcher
{
	/// <summary>
	/// In memory behavior. 
	/// For testing purposes, besides unit testing, this class allows you to temporarily enabled or disable features.
	/// </summary>
	public class InMemory
	{
		private readonly ISet<Type> _enabledTypes;
		private readonly ISet<Type> _disabledTypes;

		/// <summary>
		/// Initializes a new instance of the <see cref="FeatureSwitcher.InMemory"/> class.
		/// </summary>
		public InMemory()
		{
			_enabledTypes = new HashSet<Type>();
			_disabledTypes = new HashSet<Type>();
		}

		/// <summary>
		/// Gets the <see cref="Feature.Behavior"/> created from this configuration
		/// </summary>
		public Feature.Behavior IsEnabled 
		{
			get  { return CheckFeatureIsEnabled; }
		}

		private bool? CheckFeatureIsEnabled(Feature.Name featureName)
		{
			if(_enabledTypes.Contains(featureName.Type))
			{
				return true;
			}
			if(_disabledTypes.Contains(featureName.Type))
			{
				return false;
			}
			return null;
		}

		/// <summary>
		/// Enables a feature of the given type.
		/// </summary>
		/// <typeparam name="TFeature">The type of the feature to enable.</typeparam>
		public void Enable<TFeature>() where TFeature : IFeature
		{
			_enabledTypes.Add(typeof(TFeature));
			_disabledTypes.Remove(typeof(TFeature));
		}

		/// <summary>
		/// Enables a feature of the given type.
		/// </summary>
		/// <typeparam name="TFeature">The type of the feature to disable</typeparam>
		public void Disable<TFeature>() where TFeature : IFeature
		{
			_enabledTypes.Remove(typeof(TFeature));
			_disabledTypes.Add(typeof(TFeature));
		}

		/// <summary>
		/// Reset the state of a feature to the default.
		/// </summary>
		/// <typeparam name="TFeature">The type of the feature to reset.</typeparam>
		public void Reset<TFeature>() where TFeature : IFeature
		{
			_enabledTypes.Remove(typeof(TFeature));
			_disabledTypes.Remove(typeof(TFeature));
		}
	}
}