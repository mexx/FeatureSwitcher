using System;
using System.Collections.Generic;

namespace FeatureSwitcher.Configuration
{
	/// <summary>
	/// In memory behavior. 
	/// This class allows features to be temporarily turned on or off.
	/// </summary>
	public class InMemory
	{
		private readonly ISet<Type> _enabledTypes = new HashSet<Type>();
		private readonly ISet<Type> _disabledTypes = new HashSet<Type>();

		/// <summary>
		/// Determines if a feature is enabled by the specified featureName.
		/// </summary>
		/// <returns>
		///     <c>true</c> if the specified featureName enabled;
		///     <c>false</c> if the specified featureName is disabled;
		///     <c>null</c> otherwise
		/// </returns>
		/// <param name="featureName">Feature name.</param>
		public bool? IsEnabled (Feature.Name featureName)
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