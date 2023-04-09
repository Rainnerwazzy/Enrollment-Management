using EASendMail;
using Enrollment.Management.Registration.Domain.Dtos;
using Enrollment.Management.Registration.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment.Management.Registration.Domain.Services
{
    public class SenderEmailService : ISenderEmailService
    {
        public async Task SenderEmailAsync(MatriculasDto matriculasDto)
        {
            try
            {
                SmtpMail email = new SmtpMail("TryIt")
                {
                    From = "universidade@gmail.com",
                    To = matriculasDto?.Aluno?.Email,
                    Subject = "Matricula concluída com sucesso",
                    TextBody = $"Matricula do número {matriculasDto.Id} com as seguintes matérias { matriculasDto.Curso.ListDisciplinas.ToList().Select( x=> { return x.Split(',');})} e valor total {matriculasDto.ValorTotal}"
                };

                SmtpServer server = new SmtpServer("smtp.gmail.com")
                {
                    User = "universidade@gmail.com",
                    Password = "universidadepassword",
                    ConnectType = SmtpConnectType.ConnectTryTLS
                };
                SmtpClient oSmtp = new SmtpClient();
                await oSmtp.SendMailAsync(server, email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
