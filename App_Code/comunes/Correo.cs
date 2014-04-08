using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;


public class Correo
    {
        public string Origen;
        public string Asunto;
        public string Cuerpo;
        public List<string> Destinatarios;
        public string copiaOculta;
        public string usuario;
        public string password;
        
        public Correo()
        {
            Destinatarios = new List<string>();
            Origen = string.Empty;
            Asunto = string.Empty;
            Cuerpo = string.Empty;
            usuario = string.Empty;
            password = string.Empty;
        }

        public void Envio(Correo c)
        {
            MailMessage mensaje1 = new MailMessage();
            MailAddress dirCorreo = new MailAddress(c.Origen);
           
            SmtpClient cliente = new SmtpClient("smtp.1and1.es",25);
            NetworkCredential nc = new NetworkCredential(usuario, password);
            
            cliente.Credentials = nc;

            foreach (string x in c.Destinatarios)
            {
                mensaje1.To.Add(x);                
            }

            if (copiaOculta != null)
            {
                mensaje1.Bcc.Add(copiaOculta);
            }

            mensaje1.IsBodyHtml = true;
            mensaje1.From = dirCorreo;
            mensaje1.Subject = c.Asunto;
            mensaje1.Body = c.Cuerpo;
           
            cliente.Send(mensaje1);
        }

    }
