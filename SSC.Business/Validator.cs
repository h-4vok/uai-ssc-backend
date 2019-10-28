using SSC.Common;
using SSC.Common.Exceptions;
using SSC.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class Validator<T>
    {
        public Validator(T model)
        {
            this.model = model;
            this.i10n = DependencyResolver.Obj.Resolve<ILocalizationProvider>();
        }

        private readonly T model;
        private ILocalizationProvider i10n;

        public string ValidationResult { get; private set; }

        public void ThrowExceptionIfApplicable()
        {
            if (!String.IsNullOrEmpty(this.ValidationResult))
            {
                throw new UnprocessableEntityException(this.ValidationResult);
            }
        }

        public static Validator<T> Start(T model)
        {
            return new Validator<T>(model);
        }

        private bool ShouldRun { get { return String.IsNullOrWhiteSpace(this.ValidationResult); } }

        private Validator<T> SetAndReturn(string validationResult)
        {
            this.ValidationResult = validationResult;
            return this;
        }

        public Validator<T> MandatoryString(Func<T, string> propertyAccessor, string fieldName)
        {
            if (!this.ShouldRun) return this;

            if (String.IsNullOrWhiteSpace(propertyAccessor(this.model)))
            {
                return this.SetAndReturn(String.Format(this.i10n["validator.api.mandatory-string"], fieldName));
            }

            return this;
        }

        public Validator<T> MandatoryDecimal(Func<T, decimal?> propertyAccessor, string fieldName)
        {
            if (!this.ShouldRun) return this;

            if(!propertyAccessor(this.model).HasValue)
            {
                return this.SetAndReturn(String.Format(this.i10n["validator.api.mandatory-decimal"], fieldName));
            }

            return this;
        }

        public Validator<T> MaxStringLength(Func<T, string> propertyAccessor, string fieldName, int length)
        {
            if (!this.ShouldRun) return this;

            if (propertyAccessor(this.model).Length > length)
            {
                return this.SetAndReturn(String.Format(this.i10n["validator.api.max-string-length"], fieldName, length));
            }

            return this;
        }

        public Validator<T> MinStringLength(Func<T, string> propertyAccessor, string fieldName, int minLength)
        {
            if (!this.ShouldRun) return this;

            if (propertyAccessor(this.model).Length < minLength)
            {
                return this.SetAndReturn(String.Format(this.i10n["validator.api.min-string-length"], fieldName, minLength));
            }

            return this;
        }

        public Validator<T> ValidEmailAddress(Func<T, string> propertyAccessor, string fieldName)
        {
            if (!this.ShouldRun) return this;

            try
            {
                var mailAddress = new MailAddress(propertyAccessor(this.model));
            }
            catch
            {
                return this.SetAndReturn(String.Format(this.i10n["validator.api.valid-email-address"], fieldName));
            }

            return this;
        }

        public Validator<T> NotNull(Func<T, object> propertyAccessor, string fieldName)
        {
            if (!this.ShouldRun) return this;

            if (propertyAccessor(this.model) == null)
            {
                return this.SetAndReturn(String.Format(this.i10n["validator.api.not-null"], fieldName));
            }

            return this;
        }

        public Validator<T> MandatoryDropdownSelection(Func<T, int> propertyAccessor, string fieldName)
        {
            if (!this.ShouldRun) return this;

            if (propertyAccessor(this.model) <= 0)
            {
                return this.SetAndReturn(String.Format(this.i10n["validator.api.mandatory-dropdown-selection"], fieldName));
            }

            return this;
        }

        public Validator<T> IsNumber(Func<T, string> propertyAccessor, string fieldName)
        {
            if (!this.ShouldRun) return this;

            Regex regex = new Regex(@"^[0-9]+$");

            if (!regex.IsMatch(propertyAccessor(this.model)))
            {
                return this.SetAndReturn(String.Format(this.i10n["validator.api.is-number"], fieldName));
            }

            return this;
        }

        public Validator<T> DateFormat(Func<T, string> propertyAccessor, string fieldName, string format)
        {
            if (!this.ShouldRun) return this;

            var output = DateTime.TryParseExact(propertyAccessor(this.model), format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
            if (!output)
            {
                return this.SetAndReturn(String.Format(this.i10n["validator.api.date-format"], fieldName, format));
            }

            return this;
        }

        public Validator<T> ListNotEmpty<Y>(Func<T, IEnumerable<Y>> propertyAccessor, string fieldName)
        {
            if (!this.ShouldRun) return this;

            var output = propertyAccessor(this.model);
            if (output == null || output.Count() == 0)
            {
                return this.SetAndReturn(String.Format(this.i10n["validator.api.list-not-empty"], fieldName));
            }

            return this;
        }
    }
}
