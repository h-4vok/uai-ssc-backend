using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.Exceptions
{
    public class UserAuthenticationException : Exception
    {
        public UserAuthenticationException()
        {
        }

        public static UserAuthenticationException AsUnexistingUserException()
        {
            return new UserAuthenticationException("El usuario no existe.");
        }

        public static UserAuthenticationException AsIncorrectPasswordException()
        {
            return new UserAuthenticationException("La contraseña ingresada es incorrecta.");
        }

        public static UserAuthenticationException AsBlockedUserException()
        {
            return new UserAuthenticationException("El usuario se encuentra bloqueado.");
        }

        public static UserAuthenticationException AsDisabledUserException()
        {
            return new UserAuthenticationException("El usuario se encuentra deshabilitado.");
        }

        public UserAuthenticationException(string message) : base(message)
        {
        }

        public UserAuthenticationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserAuthenticationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
