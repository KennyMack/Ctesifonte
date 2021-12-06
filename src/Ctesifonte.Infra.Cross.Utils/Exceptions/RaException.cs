using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Infra.Cross.Utils.Exceptions
{
    public class RaException : ApplicationException
    {
        public ModelException ExceptionDetails { get; set; } = null;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RaException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public RaException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RaException"/> class.
        /// </summary>
        public RaException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RaException"/> class.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public RaException(string format, params object[] args) : base(string.Format(format, args))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RaException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public RaException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public RaException(string message, ModelException exceptionDetails) : base(message)
        {
            ExceptionDetails = exceptionDetails;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RaException"/> class.
        /// </summary>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public RaException(Exception innerException, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RaException" /> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        public RaException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion Constructor
    }
}
