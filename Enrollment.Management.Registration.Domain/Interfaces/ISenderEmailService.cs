using Enrollment.Management.Registration.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment.Management.Registration.Domain.Interfaces
{
    public interface ISenderEmailService
    {
        Task SenderEmailAsync(MatriculasDto matriculasDto);
    }
}
