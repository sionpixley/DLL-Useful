using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sion.Useful.BehindScenes {
	public class Exception : System.Exception {
		public Enums.ExceptionCode Code { get; set; }

		public Exception() : base() { }
		public Exception(Enums.ExceptionCode code, string message) : base(message) => Code = code;
	}
}
