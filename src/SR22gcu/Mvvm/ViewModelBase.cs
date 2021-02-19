using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SR22Panel.Mvvm
{
    public class ViewModelBase : ObservableObject
    {
        /// <summary>
        /// Raises the PropertyChanged event if needed, and broadcasts a
        /// PropertyChangedMessage using the Messenger instance (or the
        /// static default instance if no Messenger instance is available).
        /// </summary>
        /// <typeparam name="T">The type of the property that
        /// changed.</typeparam>
        /// <param name="propertyName">The name of the property that
        /// changed.</param>
        /// <param name="oldValue">The property's value before the change
        /// occurred.</param>
        /// <param name="newValue">The property's value after the change
        /// occurred.</param>
        public virtual void RaisePropertyChanged<T>(
            string propertyName,
            T oldValue = default(T),
            T newValue = default(T))
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("This method cannot be called with an empty string", "propertyName");
            }
            RaisePropertyChanged(propertyName);
        }

        /// <summary>
        /// Raises the PropertyChanged event if needed, and broadcasts a
        /// PropertyChangedMessage using the Messenger instance (or the
        /// static default instance if no Messenger instance is available).
        /// </summary>
        /// <typeparam name="T">The type of the property that
        /// changed.</typeparam>
        /// <param name="propertyExpression">An expression identifying the property
        /// that changed.</param>
        /// <param name="oldValue">The property's value before the change
        /// occurred.</param>
        /// <param name="newValue">The property's value after the change
        /// occurred.</param>
        public virtual void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression, T oldValue, T newValue)
        {
            RaisePropertyChanged(propertyExpression);
        }

        /// <summary>
        /// Assigns a new value to the property. Then, raises the
        /// PropertyChanged event if needed, and broadcasts a
        /// PropertyChangedMessage using the Messenger instance (or the
        /// static default instance if no Messenger instance is available). 
        /// </summary>
        /// <typeparam name="T">The type of the property that
        /// changed.</typeparam>
        /// <param name="propertyExpression">An expression identifying the property
        /// that changed.</param>
        /// <param name="field">The field storing the property's value.</param>
        /// <param name="newValue">The property's value after the change
        /// occurred.</param>
        /// <returns>True if the PropertyChanged event was raised, false otherwise.</returns>
        protected new bool Set<T>(
            Expression<Func<T>> propertyExpression,
            ref T field,
            T newValue)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return false;
            }

            var oldValue = field;
            field = newValue;
            RaisePropertyChanged(propertyExpression, oldValue, field);
            return true;
        }

        /// <summary>
        /// Assigns a new value to the property. Then, raises the
        /// PropertyChanged event if needed, and broadcasts a
        /// PropertyChangedMessage using the Messenger instance (or the
        /// static default instance if no Messenger instance is available). 
        /// </summary>
        /// <typeparam name="T">The type of the property that
        /// changed.</typeparam>
        /// <param name="propertyName">The name of the property that
        /// changed.</param>
        /// <param name="field">The field storing the property's value.</param>
        /// <param name="newValue">The property's value after the change
        /// occurred.</param>
        /// <returns>True if the PropertyChanged event was raised, false otherwise.</returns>
        protected new bool Set<T>(
            string propertyName,
            ref T field,
            T newValue = default(T))
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return false;
            }

            var oldValue = field;
            field = newValue;
            RaisePropertyChanged(propertyName, oldValue, field);
            return true;
        }
    }
}
