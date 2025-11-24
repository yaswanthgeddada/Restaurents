using System;

namespace Restaurents.Domain.Exceptions;

public class NotFoundException(string Message) : Exception(Message)
{

}
