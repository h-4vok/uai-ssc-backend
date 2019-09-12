using System;
using System.Collections.Generic;
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
        }

        private readonly T model;
        public string ValidationResult { get; private set; }

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
                return this.SetAndReturn(String.Format("El campo {0} es obligatorio.", fieldName));
            }

            return this;
        }

        public Validator<T> MaxStringLength(Func<T, string> propertyAccessor, string fieldName, int length)
        {
            if (!this.ShouldRun) return this;

            if (propertyAccessor(this.model).Length > length)
            {
                return this.SetAndReturn(String.Format("El campo {0} supera los {1} caracteres.", fieldName, length));
            }

            return this;
        }

        public Validator<T> MinStringLength(Func<T, string> propertyAccessor, string fieldName, int minLength)
        {
            if (!this.ShouldRun) return this;

            if (propertyAccessor(this.model).Length < minLength)
            {
                return this.SetAndReturn(String.Format("El campo {0} debe tener al menos {1} caracteres.", fieldName, minLength));
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
                return this.SetAndReturn(String.Format("El campo {0} no es un correo electrónico válido.", fieldName));
            }

            return this;
        }

        public Validator<T> NotNull(Func<T, object> propertyAccessor, string fieldName)
        {
            if (!this.ShouldRun) return this;

            if (propertyAccessor(this.model) == null)
            {
                return this.SetAndReturn(String.Format("El campo {0} no puede ser vacío.", fieldName));
            }

            return this;
        }

        public Validator<T> MandatoryDropdownSelection(Func<T, int> propertyAccessor, string fieldName)
        {
            if (!this.ShouldRun) return this;

            if (propertyAccessor(this.model) <= 0)
            {
                return this.SetAndReturn(String.Format("El campo {0} es obligatorio.", fieldName));
            }

            return this;
        }
    }
}
