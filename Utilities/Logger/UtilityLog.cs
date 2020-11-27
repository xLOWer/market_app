using System;
using System.Net;
using System.Net.Mail;
using NLog;

namespace Utilities.Logger
{
	public class UtilityLog
	{
		private NLog.Logger _logger;


		public string GetRecursiveInnerException(Exception ex)
		{
			Exception realerror = ex;
			while (realerror.InnerException != null)
				realerror = realerror.InnerException;
			return ex.Message + "\r\n" + realerror.Message + "\r\n===StackTrace\r\n" + ex.StackTrace + "\r\n===Source\r\n " + ex.Source;
		}


		public string Log(string Message)
		{
			_logger.Debug( Message );
			return Message;
		}

		public string Log(Exception Exception)
		{
			_logger.Debug( Exception );
			return GetRecursiveInnerException( Exception );
		}



		public string Error(string errorText)
		{
			_logger.Error( errorText );
			return errorText;
		}

		public string Error(Exception Exception)
		{
			_logger.Error( Exception );
			return GetRecursiveInnerException( Exception );
		}



		public string Mail(Exception Exception)
		{
			Mail( Exception, _mailErrorSubject );
			return GetRecursiveInnerException( Exception );
		}

		public string Mail(string Message)
		{
			Mail( Message, _mailErrorSubject );
			return Message;
		}

		public string Mail(Exception exception, string subject)
		{
			MailAddress from = new MailAddress( _mailUserEmailAddress );
			MailAddress to = new MailAddress( _mailUserEmailAddress );
			MailMessage m = new MailMessage( from, to );
			m.Subject = subject;
			m.Body = GetRecursiveInnerException( exception );
			// DOTO: прикреплять логи к письму
			//m.Attachments.Add( new Attachment( LogManager.Configuration.FindTargetByName("") ) );
			// письмо представляет код html
			//m.IsBodyHtml = true;
			SmtpClient smtp = new SmtpClient( _mailSmtpServerAddress );
			smtp.Credentials = new NetworkCredential( _mailUserLogin, _mailUserPassword );
			smtp.EnableSsl = false;
			smtp.Send( m );
			return m.Body;
		}
		
		public string Mail(string message, string subject)
		{
			MailAddress from = new MailAddress( _mailUserEmailAddress );
			MailAddress to = new MailAddress( _mailUserEmailAddress );
			MailMessage m = new MailMessage( from, to );
			m.Subject = subject;
			m.Body = message;
			// DOTO: прикреплять логи к письму
			//m.Attachments.Add( new Attachment( LogManager.Configuration.FindTargetByName("") ) );
			// письмо представляет код html
			//m.IsBodyHtml = true;
			SmtpClient smtp = new SmtpClient( _mailSmtpServerAddress );
			smtp.Credentials = new NetworkCredential( _mailUserLogin, _mailUserPassword );
			smtp.EnableSsl = false;
			smtp.Send( m );
			return m.Body;
		}

		public void ConfigureMailLogger(
			string MailSmtpServerAddress,
			string MailUserLogin,
			string MailUserPassword,
			string MailUserEmailAddress,
			string MailErrorSubject)
		{
			_mailSmtpServerAddress = MailSmtpServerAddress;
			_mailUserLogin = MailUserLogin;
			_mailUserPassword = MailUserPassword;
			_mailUserEmailAddress = MailUserEmailAddress;
			_mailErrorSubject = MailErrorSubject;
		}

		private string _mailSmtpServerAddress;
		private string _mailUserLogin;
		private string _mailUserPassword;
		private string _mailUserEmailAddress;
		private string _mailErrorSubject;






		[NonSerialized]
		private static volatile UtilityLog _instance;

		[NonSerialized]
		private static readonly object syncRoot = new object();


		public static UtilityLog GetInstance()
		{
			if (_instance == null)
			{
				lock (syncRoot)
				{
					if (_instance == null)
					{
						_instance = new UtilityLog();
					}
				}
			}

			return _instance;
		}

		private UtilityLog()
		{
			_logger = LogManager.GetCurrentClassLogger();
		}
	}
}
